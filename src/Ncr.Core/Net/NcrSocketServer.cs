//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using Ncr.Core.Util;

namespace Ncr.Core.Net
{
	public enum NcrSocketCommand
	{
		TestCom,
		TestComOk,
		Disconnecting
	}
	
	public class NcrSocketList : List<NcrSocket>, IDisposable
	{
		public event EventHandler FirstItemAdded;
		
		public event EventHandler Empty;
		
		public new void Add(NcrSocket item)
		{
			base.Add(item);
			OnFirstItemAdded(null);
		}
		
		public new void Clear()
		{
			base.Clear();
			OnEmpty(null);
		}
		
		public new void RemoveAt(int index)
		{
			base.RemoveAt(index);
			OnEmpty(null);
		}
		
		public new void Remove(NcrSocket item)
		{
			base.Remove(item);
			OnEmpty(null);
		}
		
		public virtual void Dispose()
		{
			foreach (NcrSocket s in this) {
				s.Dispose();
			}
		}
		
		protected virtual void OnEmpty(EventArgs e)
		{
			if (Count == 0 && Empty != null) {
				Empty(this, e);
			}
		}
		
		protected virtual void OnFirstItemAdded(EventArgs e)
		{
			if (Count == 1 && FirstItemAdded != null) {
				FirstItemAdded(this, e);
			}
		}
	}
	
	public class NcrSocket : IDisposable
	{
		Socket socket;
		NetworkStream stream;
		DateTime lastTransportTime = DateTime.Now;
		
		public NcrSocket(Socket socket)
		{
			this.socket = socket;
			this.stream = new NetworkStream(socket);
		}
		
		public DateTime LastTransportTime {
			get { return lastTransportTime; }
		}
		
		public NetworkStream Stream {
			get { return stream; }
		}
		
		public Socket Socket {
			get { return socket; }
		}
		
		public void UpdateTransportTime()
		{
			lastTransportTime = DateTime.Now;
		}
		
		public void Dispose()
		{
			stream.Close();
			socket.Shutdown(SocketShutdown.Both);
			socket.Close();
		}
	}
	
	public class NcrNetworkEventArgs : EventArgs
	{
		string message;
		object data;
		
		public NcrNetworkEventArgs(string message) : this(null, message)
		{
		}
		
		public NcrNetworkEventArgs(object data, string message)
		{
			this.data = data;
			this.message = message;
		}
		
		public object Data {
			get { return data; }
			set { data = value; }
		}
		
		public string Message {
			get { return message; }
			set { message = value; }
		}
	}
	
	public class NcrSocketServer : IDisposable
	{
		int port;
		string name;
		NcrSocketList clients = new NcrSocketList();
		TcpListener listener;
		bool asyncMode;
		BinaryFormatter formatter = new BinaryFormatter();
		bool smartManagementOn;
		Thread clientScanner;
		Thread dataScanner;
		NcrServerInfo serverInfo;
		Thread smartManagementThread;
		int minutesTillDisconnecting = 1;
		float priority = 1;
		bool doThreads = true;
		Hashtable blackLists = null;
		
		public NcrSocketServer(int port, string name) : this(port, name, false)
		{
		}
		
		public NcrSocketServer(int port, string name, bool smartManagementOn)
		{
			if (port < 0) {
				throw new NcrSocketException("Server's port number must be greater than 0");
			}
			IPAddress address;
			this.name = name;
			this.port = port;
			this.smartManagementOn = smartManagementOn;
			try {
//				address = Dns.GetHostByName(Dns.GetHostName()).AddressList[0];
				address = DnsHelper.GetHostByName(Dns.GetHostName()).AddressList[0];
				listener = new TcpListener(address, port);
			} catch (Exception ex) {
				throw new NcrSocketException("Error on attempt to resolve server's IP address", ex);
			}
			
			clientScanner = new Thread(new ThreadStart(ScanForClients));
			clientScanner.Name = "ClientScanner";
			
			dataScanner = new Thread(new ThreadStart(ScanForData));
			dataScanner.Name = "DataScanner";
			
			serverInfo = new NcrServerInfo(address, port);
			if (smartManagementOn) {
				smartManagementThread = new Thread(new ThreadStart(SmartManagement));
				smartManagementThread.Name = "SmartManagement";
			}
			
			clients.Empty += new EventHandler(ClientsEmpty);
			clients.FirstItemAdded += new EventHandler(ClientsFirstItemAdded);
		}
		
		public event EventHandler<NcrNetworkEventArgs> DataSendAsyncError;
		
		public event EventHandler ClientRejected;
		
		public event EventHandler DataSent;
		
		public event EventHandler<NcrNetworkEventArgs> DataArrived;
		
		public void Dispose()
		{
			// TODO:
		}
		
		public void StartListen()
		{
			switch (clientScanner.ThreadState) {
				case ThreadState.Unstarted:
					clientScanner.Start();
					break;
				case ThreadState.Suspended:
					listener.Start();
					clientScanner.Resume();
					break;
				default:
					if ((byte)clientScanner.ThreadState == 96) {
						listener.Start();
						clientScanner.Resume();
					}
					break;
			}
		}
		
		public void StopListen()
		{
			switch (clientScanner.ThreadState) {
				case ThreadState.WaitSleepJoin:
				case ThreadState.Running:
					clientScanner.Suspend();
					listener.Stop();
					break;
			}
			if (dataScanner.ThreadState == ThreadState.Running) {
				dataScanner.Suspend();
				listener.Stop();
			}
		}
		
		public bool SendData(object data, int index)
		{
			NcrSocket client = clients[index];
			lock (this) {
				if (!client.Socket.Connected) {
					if (asyncMode) {
						asyncMode = false;
						OnDataSendAsyncError(new NcrNetworkEventArgs("Client is not connected"));
					}
					return false;
				}
				formatter.Serialize(client.Stream, data);
				client.Stream.Flush();
				if (smartManagementOn) {
					client.UpdateTransportTime();
				}
			}
			if (data.GetType().Name.Equals(typeof(NcrSocketCommand).Name)) {
				OnDataSent(new NcrNetworkEventArgs(data, ""));
			}
			return true;
		}
		
		protected virtual void OnDataSendAsyncError(NcrNetworkEventArgs e)
		{
			if (DataSendAsyncError != null) {
				DataSendAsyncError(this, e);
			}
		}
		
		protected virtual void OnDataArrived(NcrNetworkEventArgs e)
		{
			if (DataArrived != null) {
				DataArrived(this, e);
			}
		}
		
		protected virtual void OnDataSent(NcrNetworkEventArgs e)
		{
			if (DataSent != null) {
				DataSent(this, e);
			}
		}
		
		protected virtual void OnClientRejected(EventArgs e)
		{
			if (ClientRejected != null) {
				ClientRejected(this, e);
			}
		}
		
		void SendCommand(NcrSocketCommand command, int index)
		{
			SendData(command, index);
		}

		void ClientsFirstItemAdded(object sender, EventArgs e)
		{
			ManageThread(dataScanner, dataScanner);
			if (smartManagementOn) {
				ManageThread(dataScanner, smartManagementThread);
			}
		}
		
		void ManageThread(Thread thread1, Thread thread2)
		{
			switch (thread1.ThreadState) {
				case ThreadState.Stopped:
				case ThreadState.Suspended:
					thread2.Resume();
					break;
				case ThreadState.Unstarted:
					thread2.Start();
					break;
				default:
					if ((byte)thread2.ThreadState == 96) {
						thread2.Resume();
					}
					break;
			}
		}

		void ClientsEmpty(object sender, EventArgs e)
		{
			SuspendThread(dataScanner);
			if (smartManagementOn) {
				SuspendThread(smartManagementThread);
			}
		}
		
		void SuspendThread(Thread thread)
		{
			if (thread.ThreadState != ThreadState.Stopped && thread.ThreadState != ThreadState.Suspended && thread.ThreadState != ThreadState.Unstarted && (byte)thread.ThreadState != 96) {
				thread.Suspend();
			}
		}
		
		void SmartManagement()
		{
			try {
				while (true) {
					if (!doThreads) {
						Thread.CurrentThread.Abort();
					}
					for (int i = 0; i < clients.Count; ++i) {
						if ((DateTime.Now - clients[i].LastTransportTime).Minutes > minutesTillDisconnecting) {
							clients[i].Dispose();
							clients.Remove(clients[i]);
							--i;
						}
					}
					Thread.Sleep((int)(30000 / priority));
				}
			} catch (Exception) {}
		}
		
		void ScanForClients()
		{
			listener.Start();
			while (true) {
				if (!doThreads) {
					Thread.CurrentThread.Abort();
				}
				if (!listener.Pending()) {
					Thread.Sleep((int)(2000 / priority));
					continue;
				}
				Socket client = listener.AcceptSocket();
				if (client == null) {
					continue;
				}
				if (blackLists != null && blackLists.Contains(GetClientIP(client))) {
					OnClientRejected(null);
				}
				clients.Add(new NcrSocket(client));
			}
		}
		
		string GetClientIP(Socket client)
		{
			string s = client.RemoteEndPoint.ToString();
			return s.Substring(0, s.IndexOf(':'));
		}
		
		void ScanForData()
		{
			while (true) {
				if (!doThreads) {
					Thread.CurrentThread.Abort();
				}
				for (int i = 0; i < clients.Count; ++i) {
					if (!clients[i].Socket.Connected) {
						clients.Remove(clients[i]);
						--i;
						continue;
					}
					if (clients[i].Socket.Available > 0) {
						if (smartManagementOn) {
							clients[i].UpdateTransportTime();
						}
						object data = formatter.Deserialize(clients[i].Stream);
						if (data.GetType().Name.Equals(typeof(NcrSocketCommand).Name)) {
							switch ((NcrSocketCommand)data) {
								case NcrSocketCommand.Disconnecting:
									clients[i].Dispose();
									clients.Remove(clients[i]);
									break;
								case NcrSocketCommand.TestCom:
									SendCommand(NcrSocketCommand.TestComOk, i);
									break;
							}
						} else {
							LoggingService.Debug(data.ToString());
							OnDataArrived(new NcrNetworkEventArgs(data, ""));
						}
					}
				}
				Thread.Sleep((int)(150 / priority));
			}
		}
	}
}
