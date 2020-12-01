using System;
using System.ComponentModel;
using System.Net.Sockets;

namespace JadBenAutho.EasySocket
{
	/// <summary>
	/// <c>SocketStream</c> combines a <c>Socket</c> objects and it's <c>NetworkStream</c>.
	/// </summary>
	public sealed class SocketStream : IDisposable
	{
		#region Private members

		/// <summary>
		/// The corresponding <c>Networkstream</c> to the <c>Socket</c>.
		/// </summary>
		private NetworkStream NetStream;
		/// <summary>
		/// The corresponding <c>Socket</c> to the <c>Networkstream</c>.
		/// </summary>
		private Socket socket;

		/// <summary>
		/// The last time the <c>Socket</c> was used for communication.
		/// </summary>
		private DateTime _LastTransportTime = DateTime.Now;

		#endregion

		#region Public functions

		/// <summary>
		/// Gets the <c>Socket</c>.
		/// </summary>
		public Socket GetSocket
		{
			get { return socket; }
		}

		/// <summary>
		/// Gets the <c>NetworkStream</c> of the <c>Socket</c>.
		/// </summary>
		public NetworkStream GetNetworkStream
		{
			get { return NetStream; }
		}

		/// <summary>
		/// Create a <c>SocketStream</c> object with a <c>Socket</c> and <c>NetworkStream</c>.
		/// </summary>
		/// <param name="socket">The Socket to put int the <c>SocketStream</c>.</param>
		public SocketStream(Socket socket)
		{
			this.socket = socket;
			this.NetStream = new NetworkStream(socket);
		}

		/// <summary>
		/// Indicates whether the two objects are qeual.
		/// </summary>
		/// <param name="obj"></param>
		/// <returns>true if objects are equal, false if not.</returns>
		public bool Equals(SocketStream obj)
		{
			return NetStream.Equals(obj.NetStream) && socket.Equals(obj.socket);
		}

		/// <summary>
		/// Updateing the last time the socket was used for communication
		/// to current time.
		/// </summary>
		public void UpdateTransportTime()
		{
			_LastTransportTime = DateTime.Now;
		}

		#endregion

		#region properties

		/// <summary>
		/// Gets the last time the <c>Socket</c> was used for communication.
		/// </summary>
		[Description("Gets the last time the socket was used for communication."),
		 Category("Misc")
		]
		public DateTime LastTransportTime
		{
			get { return _LastTransportTime; }
		}
		#endregion

		#region IDisposable Members

		/// <summary>
		/// releases resources.
		/// </summary>
		public void Dispose()
		{
			NetStream.Close();
			NetStream = null;
			socket.Shutdown(SocketShutdown.Both);
			socket.Close();
			socket = null;
		}

		#endregion
	}
}
