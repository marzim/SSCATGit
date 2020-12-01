//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;

namespace Ncr.Core.Net
{
	public class NcrServer : AbstractServer
	{
		NcrSocketServer server = null;
		
		public NcrServer(int port, string name, IRequestParser requestParser) : base(port, name, requestParser)
		{
			server = new NcrSocketServer(port, name);
			server.DataArrived += new EventHandler<NcrNetworkEventArgs>(ServerDataArrived);
			server.ClientRejected += new EventHandler(ServerClientRejected);
		}
		
		public event EventHandler ClientRejected;
		
		public override void Stop()
		{
			server.StopListen();
			OnStopping(null);
			OnServing(string.Format("{0} has stopped", Name));
		}
		
		public override void SendResponse(Response response)
		{
			string r = response.Serialize();
//			server.SendData(r, GetClientIndex(response.Client));
			server.SendData(r, 0);
			OnDataSent(new NetworkEventArgs(r));
		}
		
		public override void Listen()
		{
			OnServing(string.Format("{0} is starting", Name));
			server.StartListen();
			OnStarting(null);
			OnServing(string.Format("Listening for connections on port {0}", Port));
		}
		
		public override void Dispose()
		{
			server.StopListen();
			server.Dispose();
		}
		
		protected virtual void OnClientRejected(EventArgs e)
		{
			if (ClientRejected != null) {
				ClientRejected(this, e);
			}
		}
		
		protected override int GetClientIndex(string client)
		{
			throw new NotImplementedException();
		}

		void ServerClientRejected(object sender, EventArgs e)
		{
			OnClientRejected(e);
		}

		void ServerDataArrived(object sender, NcrNetworkEventArgs e)
		{
			OnDataArrived(new NetworkEventArgs(RequestParser.Parse(e.Data.ToString())));
		}
	}
}
