using System;
using System.ComponentModel;
using System.Net;

namespace JadBenAutho.EasySocket
{
	/// <summary>
	/// <c>ServerInfo</c> class describs the location of the server on the net and
	/// the port it's listens to.
	/// </summary>
	public sealed class ServerInfo : System.IDisposable
	{
		#region Fields members

		/// <summary>
		/// Indicated whether the server's location is valid or not(not testing port number).
		/// </summary>
		public readonly bool IsLegal;

		/// <summary>Holds all the server location and port data.
		/// </summary>
		private IPEndPoint ServerPoint;

		/// <summary>Indicator for the type of the server.
		/// </summary>
		private bool _IsEasyServer;

		#endregion

		#region Public properties

		/// <summary>Gets all the servers location and port data.
		/// </summary>
		[Category("Data"), Description("Gets all the server location and port data.")]
		public IPEndPoint ServerEndPoint
		{
			get { return ServerPoint; }
		}

		/// <summary>Gets the port number that the server listens to.
		/// </summary>
		[Category("Data"), Description("Gets the port number that the server listens to.")]
		public int PortNumner
		{
			get { return ServerPoint.Port; }
		}

		/// <summary>Gets the IP address of the server.
		/// </summary>
		[Category("Data"), Description("Gets the IP address of the server.")]
		public IPAddress IPAddress
		{
			get { return ServerPoint.Address; }
		}

		/// <summary>Gets the IP address of the server.
		/// </summary>
		[Category("Data"), Description("Gets the IP address of the server.")]
		public string IP
		{
			get { return ServerPoint.Address.ToString(); }
		}

		/// <summary>Indicates if the server is of <c>EasyServer</c> type.
		/// </summary>
		[Category("Misc"), Description("Indicates if the server is of EasyServer type.")]
		public bool IsEasyServer
		{
			get { return _IsEasyServer; }
		}

		#endregion

		//--------------------------------------------------------------------------------------
		#region  public functions

		/// <summary>Creates new instance of <c>ServerInfo</c> object.</summary>
		/// <param name="ServerLocation">The <c>IPEndPoint</c> of the server.</param>
		/// <param name="IsEasyServer">Is the server is a <c>EasyServer</c> type.</param>
		public ServerInfo(IPEndPoint ServerLocation, bool IsEasyServer)
		{
			try {
				ServerPoint = ServerLocation;
				Dns.Resolve(ServerLocation.Address.ToString());
				IsLegal = true;
			} catch (Exception) { IsLegal = false; } finally {
				_IsEasyServer = IsEasyServer;
			}
		}

		//---------------------------------------------------------------------------------------
		/// <summary>Creates new instance of <c>ServerInfo</c> object.</summary>
		/// <param name="ServerIP">The IP of the server machine or
		///  the name of the machine (on local neteork).</param>
		/// <param name="PortNumber">The port number that the server listen on.</param>
		/// <param name="IsEasyServer">Is the server is a <c>EasyServer</c> type.</param>
		public ServerInfo(String ServerIP, int PortNumber, bool IsEasyServer)
		{
			try {
				ServerPoint = new IPEndPoint(Dns.Resolve(ServerIP).AddressList[0], PortNumber);
				IsLegal = true;
			} catch (Exception) { IsLegal = false; } finally {
				_IsEasyServer = IsEasyServer;
			}
		}

		//------------------------------------------------------------------------------------------

		/// <summary>Creates new instance of <c>ServerInfo</c> object.</summary>
		/// <param name="ServerIP">The IP of the server machine.</param>
		/// <param name="PortNumber">The port number that the server listen on.</param>
		/// <param name="IsEasyServer">Is the server is a <c>EasyServer</c> type.</param>
		public ServerInfo(IPAddress ServerIP, int PortNumber, bool IsEasyServer)
		{
			try {
				ServerPoint = new IPEndPoint(Dns.Resolve(ServerIP.ToString()).AddressList[0], PortNumber);
				IsLegal = true;
			} catch (Exception) { IsLegal = false; } finally {
				_IsEasyServer = IsEasyServer;
			}
		}

		/// <summary>
		/// Returns the string representation of the object.
		/// </summary>
		/// <returns>string representation of the object.</returns>
		public override string ToString()
		{
			return (this.IP + " on port " + this.PortNumner);
		}
		#endregion

		//-----------------------------------------------------------------------------------------
		#region IDisposable Members

		/// <summary>
		/// Releases resources.
		/// </summary>
		public void Dispose()
		{
			ServerPoint = null;
		}

		#endregion

	}
}
