//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using System.IO;
using System.Net;
using Ncr.Core.Util;

namespace Ncr.Core.Net
{
	public class NcrClient : AbstractClient
	{
		NcrSocketClient client = null;
		
		public NcrClient(int port, IResponseParser responseParser) : base(port, responseParser)
		{
		}
		
		public NcrClient(string server, int port, IResponseParser responseParser) : base(server, port, responseParser)
		{
		}
		
		public override string Server {
			get {
				return base.Server;
			}
			
			set {
				if (!value.Equals(string.Empty)) {
					base.Server = value;
					server = DnsHelper.GetIPAddress(value);
					NcrServerInfo serverInfo = new NcrServerInfo(IPAddress.Parse(server), Port);
					
					client = new NcrSocketClient(serverInfo);
					client.Connected += new EventHandler(ClientConnected);
					client.Disconnected += new EventHandler(ClientDisconnected);
					client.ConnectionTimeout += new EventHandler(ClientConnectionTimeout);
					client.DataSent += new EventHandler<NcrNetworkEventArgs>(ClientDataSent);
					client.DataArrived += new EventHandler<NcrNetworkEventArgs>(ClientDataArrived);
				}
			}
		}
		
		public override void Connect()
		{
			base.Connect();
			client.ConnectToServerAsync();
			client.TestCommunication();
		}
		
		public override void Disconnect()
		{
			client.DisconnectFromServer();
		}
		
		public override void SendRequest(string request)
		{
			client.SendData(request);
			OnDataSent(new NetworkEventArgs(request));
		}

		void ClientDataArrived(object sender, NcrNetworkEventArgs e)
		{
			OnDataArrived(new NetworkEventArgs(Response.Deserialize(new StringReader(e.Data.ToString()))));
		}

		void ClientDataSent(object sender, NcrNetworkEventArgs e)
		{
			OnDataSent(new NetworkEventArgs(e.Data.ToString()));
		}

		void ClientDisconnected(object sender, EventArgs e)
		{
			OnDisconnected(new NetworkEventArgs(string.Format("Disconnected from remote device server. IP Address: {0}", ServerName)));
			client.Dispose();
		}

		void ClientConnectionTimeout(object sender, EventArgs e)
		{
			OnConnectionTimeOut();
		}

		void ClientConnected(object sender, EventArgs e)
		{
			OnConnected(new NetworkEventArgs(string.Format("Connected to: {0}", ServerName)));
		}
	}
}
