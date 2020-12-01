using System;
using System.ComponentModel;
using System.Net;

namespace JadBenAutho.EasySocket
{
	/// <summary>
	/// <c>ClientInfo</c> class describs the location of the client machine on the net.
	/// </summary>
	public sealed class ClientInfo : System.IDisposable
	{
		#region Fields members

		/// <summary>
		/// Indicated whether the client's location is valid or not.
		/// </summary>
		public readonly bool IsLegal;

		/// <summary>Holds all the client location data.
		/// </summary>
		private IPAddress ClientPoint = null;

		/// <summary>Indicator for the type of the client.
		/// </summary>
		private bool _IsEasyClient = false;

		#endregion

		#region Public properties

		/// <summary>Gets the IP address of the client.
		/// </summary>
		[Category("Data"), Description("Gets the IP address of the client.")]
		public IPAddress ClientIPAddress
		{
			get { return ClientPoint; }
		}

		/// <summary>Gets the IP address of the client.
		/// </summary>
		[Category("Data"), Description("Gets the IP address of the client.")]
		public string ClientIP
		{
			get { return ClientPoint.ToString(); }
		}

		/// <summary>Indicates if the client is of <c>EasyClient</c> type.
		/// </summary>
		[Category("Misc"), Description("Indicates if the client is of EasyClient type.")]
		public bool IsEasyClient
		{
			get { return _IsEasyClient; }
		}

		#endregion

		//--------------------------------------------------------------------------------------
		#region  public functions

		/// <summary>Creates new instance of <c>ClientInfo</c> object.</summary>
		/// <param name="ClientIP">The IP of the client machine or
		///  the name of the machine (on local neteork).</param>
		/// <param name="IsEasyClient">Is the client is a <c>EasyClient</c> type.</param>
		public ClientInfo(String ClientIP, bool IsEasyClient)
		{
			try {
				ClientPoint = Dns.Resolve(ClientIP).AddressList[0];
				IsLegal = true;
			} catch (Exception) { IsLegal = false; } finally {
				_IsEasyClient = IsEasyClient;
			}
		}

		//------------------------------------------------------------------------------------------

		/// <summary>Creates new instance of <c>ClientInfo</c> object.</summary>
		/// <param name="ClientIP">The IP of the client machine.</param>
		/// <param name="IsEasyClient">Is the client is a <c>EasyClien</c>t type.</param>
		public ClientInfo(IPAddress ClientIP, bool IsEasyClient)
		{
			try {
				Dns.Resolve(ClientIP.ToString());
				ClientPoint = ClientIP;
				IsLegal = true;
			} catch (Exception) { IsLegal = false; } finally {
				_IsEasyClient = IsEasyClient;
			}
		}

		/// <summary>
		/// Returns the string representation of the <c>ClientInfo</c>.
		/// </summary>
		/// <returns>string representation of the <c>ClientInfo</c>.</returns>
		public override string ToString()
		{
			return ClientIP;
		}
		#endregion

		//-----------------------------------------------------------------------------------------
		#region IDisposable Members

		/// <summary>
		///	Releases resources.
		/// </summary>
		public void Dispose()
		{
			ClientPoint = null;
		}

		#endregion

	}
}