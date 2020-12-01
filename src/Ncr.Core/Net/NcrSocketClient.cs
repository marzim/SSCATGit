//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Ncr.Core.Net
{
	public enum NcrSocketClientStatus
	{
		None,
		Ok,
		Failed,
		Testing
	}
	
	public class NcrServerInfo : IDisposable
	{
		IPEndPoint serverPoint;
		bool legal;
		
		public NcrServerInfo(IPAddress address, int port)
		{
			try {
				serverPoint = new IPEndPoint(Dns.Resolve(address.ToString()).AddressList[0], port);
				Legal = true;
			} catch (Exception) {
				legal = false;
			}
		}
		
		public NcrServerInfo(string address, int port)
		{
			try {
				serverPoint = new IPEndPoint(Dns.Resolve(address).AddressList[0], port);
				Legal = true;
			} catch (Exception) {
				legal = false;
			}
		}
		
		public bool Legal {
			get { return legal; }
			set { legal = value; }
		}
		
		public IPEndPoint EndPoint {
			get { return serverPoint; }
			set { serverPoint = value; }
		}
		
		public void Dispose()
		{
			serverPoint = null;
		}
	}
	
	[Serializable()]
	public class NcrSocketException : Exception
	{
		public NcrSocketException(string message) : this(message, null)
		{
		}
		
		public NcrSocketException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
	
	public class NcrSocketClient
	{
		NcrServerInfo serverInfo;
		Socket socket;
		NetworkStream stream;
		Thread dataScanner;
		ThreadPriority dataScannerPriority = ThreadPriority.Normal;
		bool doThreads = true;
		BinaryFormatter formatter = new BinaryFormatter();
		NcrSocketClientStatus status;
		bool asyncMode;
		DateTime lastDataSentTime = DateTime.Now;
		float priority = 1;
		
		public NcrSocketClient(NcrServerInfo serverInfo)
		{
			if (!serverInfo.Legal) {
				throw new Exception(); // TODO:
			}
			this.serverInfo = serverInfo;
		}
		
		public event EventHandler Connecting;
		
		public event EventHandler Connected;
		
		public event EventHandler Disconnecting;
		
		public event EventHandler Disconnected;
		
		public event EventHandler ConnectionTimeout;
		
		public event EventHandler<NcrNetworkEventArgs> DataArrived;
		
		public event EventHandler<NcrNetworkEventArgs> DataSendAsyncError;
		
		public event EventHandler<NcrNetworkEventArgs> DataSent;
		
		public event EventHandler Testing;
		
		public event EventHandler Tested;
		
		public bool IsConnected {
			get { return socket != null && socket.Connected && stream != null; }
		}
		
		public bool IsReadyToConnect {
			get {
				return serverInfo != null && serverInfo.Legal;
			}
		}
		
		public void SendCommand(NcrSocketCommand command)
		{
			SendData(command);
		}
		
		public void Dispose()
		{
			if (!doThreads) {
				return;
			}
			formatter = null;
			if (stream != null) {
				stream.Close();
				stream = null;
			}
			if (socket != null && socket.Connected) {
				socket.Shutdown(SocketShutdown.Both);
				socket.Close();
			}
			if (dataScanner != null) {
				doThreads = false;
				priority = 100000;
				while ((byte)dataScanner.ThreadState == 34) {
					Thread.Sleep(100);
				}
				if (dataScanner.ThreadState == ThreadState.Suspended || (byte)dataScanner.ThreadState == 96) {
					dataScanner.Resume();
				}
				while (dataScanner.ThreadState != ThreadState.Stopped && dataScanner.ThreadState != ThreadState.Unstarted) {
					Thread.Sleep(100);
				}
			}
			serverInfo.Dispose();
			serverInfo = null;
			socket = null;
		}
		
		public void TestCommunication()
		{
			status = NcrSocketClientStatus.Failed;
			// FIXME: Refer to EasyClient checking for EasyServer
			if (!IsReadyToConnect) {
				return;
			}
			try {
				status = NcrSocketClientStatus.Testing;
				SendCommand(NcrSocketCommand.TestCom);
			} catch (Exception) {
				status = NcrSocketClientStatus.Failed;
				return;
			}
			DateTime now = DateTime.Now;
			OnTesting(null);
			while ((DateTime.Now - now).Seconds < 15 && status == NcrSocketClientStatus.Testing) {
				Thread.Sleep(200);
			}
			if (status == NcrSocketClientStatus.Ok) {
				OnTested(null);
			} else {
				status = NcrSocketClientStatus.Failed;
				OnTested(null);
			}
		}
		
		public void DisconnectFromServer()
		{
			OnDisconnecting(null);
			if (!IsConnected) {
				return;
			}
			if (dataScanner != null) {
				dataScanner.Suspend();
			}
			try {
				SendCommand(NcrSocketCommand.Disconnecting);
			} catch (Exception) { }
			while ((DateTime.Now - lastDataSentTime).TotalSeconds < 4) {
				Thread.Sleep(200);
			}
			try {
				stream.Close();
				socket.Shutdown(SocketShutdown.Both);
				socket.Close();
			} catch (Exception) {
			} finally {
				socket = null;
				stream = null;
			}
			OnDisconnected(null);
		}
		
		public void SendData(object data)
		{
			lock (this) {
				if (socket == null) {
					if (asyncMode) {
						asyncMode = false;
						OnDataSendAsyncError(new NcrNetworkEventArgs("Error on attempt to send data when the client is disconnected"));
						return;
					} else {
						throw new NcrSocketException("Error on attempt to send data when the client is disconnected");
					}
				}
				for (int i = 0; i < 25 && !IsConnected; ++i) {
					Thread.Sleep(200);
				}
				if (!IsConnected) {
					if (asyncMode) {
						asyncMode = false;
						OnDataSendAsyncError(new NcrNetworkEventArgs("Error on attempt to send data during connection establishment"));
						return;
					} else {
						throw new NcrSocketException("Error on attempt to send data during connection establishment");
					}
				}
				formatter.Serialize(stream, data);
				stream.Flush();
				lastDataSentTime = DateTime.Now;
				if (!data.GetType().Name.Equals(typeof(NcrSocketCommand).Name)) {
					OnDataSent(new NcrNetworkEventArgs(data, ""));
				}
			}
		}
		
		public void ConnectToServerAsync()
		{
			socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			if (socket.Connected) {
				return;
			}
			if (serverInfo == null) {
				throw new Exception(); // TODO:
			}
			if (!serverInfo.Legal) {
				throw new Exception(); // TODO:
			}
			AsyncCallback callback = new AsyncCallback(ConnectingToServer);
			try {
				socket.BeginConnect(serverInfo.EndPoint, callback, socket);
			} catch (Exception ex) {
				throw ex;
			}
		}
		
		protected virtual void OnTested(EventArgs e)
		{
			if (Tested != null) {
				Tested(this, e);
			}
		}
		
		protected virtual void OnTesting(EventArgs e)
		{
			if (Testing != null) {
				Testing(this, e);
			}
		}
		
		protected virtual void OnDataSent(NcrNetworkEventArgs e)
		{
			if (DataSent != null) {
				DataSent(this, e);
			}
		}
		
		protected virtual void OnDataSendAsyncError(NcrNetworkEventArgs e)
		{
			if (DataSendAsyncError != null) {
				DataSendAsyncError(this, e);
			}
		}
		
		protected virtual void OnDataArrived(NcrNetworkEventArgs e)
		{
			if (DataArrived != null && e.Data.GetType().Name != "NcrSocketCommand") {
				DataArrived(this, e);
			}
		}
		
		protected virtual void OnConnectionTimeout(EventArgs e)
		{
			if (ConnectionTimeout != null) {
				ConnectionTimeout(this, e);
			}
		}
		
		protected virtual void OnDisconnected(EventArgs e)
		{
			if (Disconnected != null) {
				Disconnected(this, e);
			}
		}
		
		protected virtual void OnDisconnecting(EventArgs e)
		{
			if (Disconnecting != null) {
				Disconnecting(this, e);
			}
		}
		
		protected virtual void OnConnected(EventArgs e)
		{
			if (Connected != null) {
				Connected(this, e);
			}
		}
		
		protected virtual void OnConnecting(EventArgs e)
		{
			if (Connecting != null) {
				Connecting(this, e);
			}
		}
		
		void ConnectingToServer(IAsyncResult status)
		{
			OnConnecting(null);
			for (int i = 0; i < 15 && !status.IsCompleted; ++i) {
				Thread.Sleep(500);
			}
			if (!socket.Connected) {
				try {
					socket.Close();
				} catch (Exception) {}
				socket = null;
				OnConnectionTimeout(null);
				return;
			}
			stream = new NetworkStream(socket);
			if (dataScanner == null) {
				dataScanner = new Thread(new ThreadStart(ScanForData));
				dataScanner.Priority = dataScannerPriority;
				dataScanner.Start();
			} else {
				try {
					dataScanner.Resume();
				} catch (Exception) {
					dataScanner = new Thread(new ThreadStart(ScanForData));
					dataScanner.Priority = dataScannerPriority;
					dataScanner.Start();
				}
			}
			OnConnected(null);
		}
		
		void ScanForData()
		{
			while (true) {
				if (!doThreads) {
					Thread.CurrentThread.Abort();
				}
				if (!socket.Connected) {
					dataScanner.Suspend();
				}
				if (socket.Available > 0) {
					object data = formatter.Deserialize(stream);
					if (data.GetType().Name == typeof(NcrSocketCommand).Name) {
						switch ((NcrSocketCommand)data) {
							case NcrSocketCommand.TestComOk:
								if (status == NcrSocketClientStatus.Testing) {
									status = NcrSocketClientStatus.Ok;
								}
								break;
							case NcrSocketCommand.TestCom:
								break;
							case NcrSocketCommand.Disconnecting:
								try {
									stream.Close();
									socket.Shutdown(SocketShutdown.Both);
									socket.Close();
								} catch (Exception) {
								} finally {
									socket = null;
									stream = null;
									dataScanner.Suspend();
								}
								break;
						}
					} else {
						OnDataArrived(new NcrNetworkEventArgs(data, ""));
					}
				}
				Thread.Sleep((int)(150 / priority));
			}
		}
	}
}
