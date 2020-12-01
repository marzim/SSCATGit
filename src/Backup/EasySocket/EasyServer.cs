using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using JadBenAutho.EasySocket.Tools;

namespace JadBenAutho.EasySocket
{
	#region Delegates

	/// <summary>
	/// Been called when client on the black list, attempts to connect the server.
	/// </summary>

	public delegate void ClientRejected_EventHandler(Socket RejectedClientSocket);

	/// <summary>
	/// Been called when data is arrived from the server.
	/// </summary>
	public delegate void DataArrived2Server_EventHandler(Object Data, SocketStream DataSender);

	#endregion
	
	public class ClientEventArgs : EventArgs
	{
		bool cancel;
		
		public bool Cancel {
			get { return cancel; }
			set { cancel = value; }
		}
	}

	/// <summary>
	/// <c>EasyServer</c> is a advanced implementation of the .NET Winsock TCP\IP Server,
	/// It has almost everything build in.
	/// It was developeed and designed with the <c>EasyClient</c> class (Although they work
	/// excellent together and advice to do so, it can workwith any other client implementation).
	/// </summary>
	public sealed class EasyServer : IDisposable
	{
		#region EasyServer & EasyClient common data
		/// <summary>
		/// Set of commands to store commands from the server or the client.
		/// Not for client programmers, it's hidden from other users.
		/// </summary>
		private enum EasySocketCommands
		{
			/// <summary>
			/// Informing that the sended\arrived is a communication test
			/// and should be responded with <c>TestComOk</c> command.
			/// </summary>
			TestCom,
			/// <summary>
			/// An OK repsonce to the TestCom command.
			/// </summary>
			TestComOK,
			/// <summary>
			/// This command tells that the sender is disconnecting.
			/// </summary>
			Disconnecting,
			Rejected
		}
		#endregion
		//-----------------------------------------------------------------------------------
		#region private members

		/// <summary>Hold the port number that the server listens to.
		/// </summary>
		private int ServerPort;

		/// <summary>
		/// Indicates of the <c>SmartManagement</c> function enabled
		/// </summary>
		private bool SmartManagementOn = false;

		/// <summary>
		/// Relevant only if the <c>SmartManagement</c> function is running
		/// Number of minuts that a client "allowed" not to communicate with the server,
		/// without been disconnected by the server( default value is 1).
		/// </summary>
		private int _MinutsTillDisconnecting = 1;

		/// <summary>
		/// Holds the name of the <c>EasyServer</c> object;
		/// </summary>
		private string ServerName = "Anonymous";

		/// <summary>
		/// Holds the float value of the <c>EasyServer</c> process priority.
		/// Controls the response time of the <c>EasyServer</c> to some events.
		/// View the <c>GeneralPriority</c> propertie for more info.
		/// </summary>
		private float _GeneralPriority = 1;

		/// <summary>
		/// The actual priority of executing new data scan, over other system threads.
		/// </summary>
		/// <remarks>Default value is 'Normal'</remarks>
		private ThreadPriority _DataScanPriority = ThreadPriority.Normal;

		/// <summary>
		/// The actual priority of executing new clients scan, over other system threads.
		/// </summary>
		/// <remarks>Default value is 'Normal'</remarks>
		private ThreadPriority _ClientsScanPriority = ThreadPriority.Normal;

		/// <summary>
		/// The actual priority of executing <c>SmartManagment()</c> function,
		/// over other system threads.
		/// </summary>
		/// <remarks>Default value is 'Normal'</remarks>
		private ThreadPriority _SmartManagmentPriority = ThreadPriority.Normal;

		/// <summary>Holds all the clients sockets that are connected to the server.
		/// </summary>
		private SocketsList ClientsSocketsList = new SocketsList();

		/// <summary>
		/// List of clients IP address that the <c>EasyServer</c> should reject
		/// connection attempts from.
		/// </summary>
		private IPsBlackList BlackListIPs = null;

		/// <summary>Listens for initial connections from clients.
		/// </summary>
		private TcpListener Listener;

		/// <summary>
		/// This thread scans for new clients and adds them to the clients list.
		/// </summary>
		private Thread NewClientsScanner;

		/// <summary>
		/// This thread runs the <c>SmartManagement()</c> function.
		/// </summary>
		private Thread SmartManagementThread = null;

		/// <summary>
		/// This thread scans for data arrival from the clients.
		/// </summary>
		private Thread NewDataScanner;

		/// <summary>
		/// Holds the data of this server incase someone will want it.
		/// </summary>
		private ServerInfo ServInfo;

		/// <summary>A serialize tool to write objects to the <c>NetStream</c>.</summary>
		private BinaryFormatter BinaryCaster = new BinaryFormatter();

		/// <summary>
		/// Reffrence to object that is used in the <c>SendData</c> async overloads
		/// functions. This is used to pass data to the <c>SendDataByPass</c> function
		/// without arguments (To activate as a separate thread).
		/// </summary>
		private Object ByPassDataToSend = null;

		/// <summary>
		/// Index to a client in the <c>ClientSocketList</c> to send data in asyncronic way.
		/// been used in the <c>SendDataAsync(object DataToSend, int TargetClientIndex)</c>.
		/// </summary>
		private int ByPassTargetClient = -1;

		/// <summary>
		/// Info of client to send data in asyncronic way.
		/// been used in the <c>SendDataAsync(object DataToSend, ClientInfo TargetClient)</c>.
		/// </summary>
		private ClientInfo ByPassTargetClientInfo = null;

		/// <summary>
		/// Indicates for function is here current call is asynchronic.
		/// </summary>
		/// <remarks>By defalut is false and get so after every async call.</remarks>
		private bool IsAsyncMode = false;

		/// <summary>
		///When this flag will turn true, all the threads
		///will close themselfs(after <c>Dispose()</c> is called ).
		/// </summary>
		private bool DoThreads = true;


		#endregion

		//-------------------------------------------------------------------------------
		#region Private EventHandlers

		/// <summary>Data arrived event handlers delegate.</summary>
		private DataArrived2Server_EventHandler OnDataArrived;

		/// <summary>Data sent event handlers delegate.</summary>
		private DataSent_EventHandler OnDataSent;

		/// <summary>Client rejected arrived event handlers delegate.</summary>
		private ClientRejected_EventHandler OnClientRejected;
		
		//Error event handlers
		//******************************
		/// <summary>
		/// Been called when error accures while sending data Asynchronicly.
		/// </summary>
		private DataSendAsyncError_EventHandler OnDataSendAsyncError;

		#endregion

		//------------------------------------------------------------------------------------
		#region IDisposable Members
		
		bool isDisposed = false;
		
		public bool IsDisposed {
			get { return isDisposed; }
			set { isDisposed = value; }
		}

		/// <summary>
		/// Releases resources.
		/// </summary>
		public void Dispose()
		{
			//If this object was disposed before skip disposing.
			if (DoThreads == false) return;

			//Closing the threads
			CloseThread();

			BinaryCaster = null;
			ServerName = null;
			ServInfo = null;
			Listener.Stop();
			Listener = null;

			if (ClientsSocketsList != null) {
				ClientsSocketsList.Dispose();
				ClientsSocketsList = null;
			}

			if (BlackListIPs != null) {
				BlackListIPs.Dispose();
				BlackListIPs = null;
			}
			ByPassDataToSend = null;
			ByPassTargetClientInfo = null;
			isDisposed = true;
		}

		//-------------------------------------------------------------------------------

		/// <summary>
		/// This function keep on going till it's make sure all
		/// the threads are fully stoped.
		/// </summary>
		private void CloseThread()
		{
			//Stoping the infinite threads.
			DoThreads = false;

			/*Making the priority of th threads high so that they will
			 * execute the Abort command as soone as possible.*/
			_GeneralPriority = 100000;

			//If the ThreadState is comb' of suspend requested & WaitSleepJoin
			while ((byte)NewClientsScanner.ThreadState == 34 ||
			       (SmartManagementThread != null && (byte)SmartManagementThread.ThreadState == 34) ||
			       (byte)NewDataScanner.ThreadState == 34)
				Thread.Sleep(100);

			//Before aborting the threads I must be sure non of them is in suspend mode
			if (NewDataScanner.ThreadState == ThreadState.Suspended ||
			    (byte)NewDataScanner.ThreadState == 96)
				NewDataScanner.Resume();
			if (SmartManagementThread != null) {
				if (SmartManagementThread.ThreadState == ThreadState.Suspended ||
				    (byte)SmartManagementThread.ThreadState == 96)
					SmartManagementThread.Resume();
			}

			if (NewClientsScanner.ThreadState == ThreadState.Suspended ||
			    (byte)NewClientsScanner.ThreadState == 96)
				NewClientsScanner.Resume();

			/*Since SmartManagementThread sleeps most of the time
			 * I must interrupt it's sleep so that it could execute the Abort() :*/
			if (SmartManagementThread != null)
				switch (SmartManagementThread.ThreadState) {
				case ThreadState.WaitSleepJoin:
				case ThreadState.Suspended:
				case ThreadState.SuspendRequested:
					SmartManagementThread.Interrupt();
					break;
			}

			while (//Makeing sure no sub thread is active
			       (NewDataScanner.ThreadState != ThreadState.Stopped &&
			        NewDataScanner.ThreadState != ThreadState.Unstarted) ||
			       (NewClientsScanner.ThreadState != ThreadState.Stopped &&
			        NewClientsScanner.ThreadState != ThreadState.Unstarted) ||
			       (SmartManagementThread != null &&
			        (SmartManagementThread.ThreadState != ThreadState.Stopped &&
			         SmartManagementThread.ThreadState != ThreadState.Unstarted))
			      ) Thread.Sleep(100);
		}

		#endregion

		//------------------------------------------------------------------------------------
		#region public properties

		/// <summary>
		/// Gets the list of clients <c>SocketStream</c> that are connected to the server.
		/// </summary>
		[Category("Configurations"),
		 Description("Gets the list of clients SocketStream that are connected to the server.")
		]
		public SocketsList ClientsList
		{
			get { return ClientsSocketsList; }
		}

		//-------------------------------------------------------------------------------
		/// <summary>
		/// Gets or sets the <c>Priority</c>c of this <c>EasyServer</c> process
		/// and controls the response time of the <c>EasyServer</c> to some events.
		/// </summary>
		/// <remarks>
		/// This priority isn't actually priority over other process instead,
		/// it's controls the number of times, the proccess will call during a time sequence.
		/// </remarks>
		[Category("Configurations"),
		 Description("Gets or sets the general priority of this EasyServer process " +
		             "and controls the respose time of the EasyServer to some events.")
		]
		public Priority GeneralPriority
		{
			get { return PriorityTool.Resolve(_GeneralPriority); }
			set { _GeneralPriority = PriorityTool.GetValue(value); }
		}

		//-------------------------------------------------------------------------------
		/// <summary>
		/// Gets or sets the actual priority of executing new data scan process
		/// over other system threads (Deafult is normal).
		/// </summary>
		[Category("Configurations"),
		 Description("Gets or sets the actual priority of executing new data scan process" +
		             " over other system threads (Default is normal).")
		]
		public ThreadPriority DataScanPriority
		{
			get { return _DataScanPriority; }
			set
			{
				_DataScanPriority = value;
				if (NewDataScanner != null) NewDataScanner.Priority = value;
			}
		}
		//-------------------------------------------------------------------------------

		/// <summary>
		/// Gets or sets the actual priority of executing new clients scan process
		/// over other system threads (Deafult is normal).
		/// </summary>
		[Category("Configurations"),
		 Description("Gets or sets the actual priority of executing new clients scan process" +
		             " over other system threads (Default is normal).")
		]
		public ThreadPriority ClientsScanPriority
		{
			get { return _ClientsScanPriority; }
			set
			{
				_ClientsScanPriority = value;
				if (NewClientsScanner != null) NewClientsScanner.Priority = value;
			}
		}
		//-------------------------------------------------------------------------------

		/// <summary>
		/// Gets or sets the actual priority of executing <c>SmartManagment</c> process
		/// over other system threads (Deafult is normal).
		/// </summary>
		[Category("Configurations"),
		 Description("Gets or sets the actual priority of executing SmartManagment process" +
		             " over other system threads (Default is normal).")
		]
		public ThreadPriority SmartManagmentPriority
		{
			get { return _SmartManagmentPriority; }
			set
			{
				_SmartManagmentPriority = value;
				if (SmartManagementThread != null) SmartManagementThread.Priority = value;
			}
		}
		//-------------------------------------------------------------------------------

		/// <summary>
		/// Relevant only if the <c>SmartManagement</c> option choosed from the constructor.
		/// Number of minuts that a client "allowed" not to communicate with the server,
		/// without been disconnected by the server( default value is 1).
		/// </summary>
		[Category("Configurations"),
		 Description("Relevant only if the SmartManagement option choosed from the constructor. " +
		             "Number of minuts that a client \"allowed\" not to communicate with the server, " +
		             "without been disconnected by the server( default value is 1)..")
		]
		public int MinutsTillDisconnecting
		{
			get { return _MinutsTillDisconnecting; }
			set { _MinutsTillDisconnecting = value; }
		}

		//-------------------------------------------------------------------------------------

		/// <summary>
		/// Gets or sets the port number that the server listen to (default value is 2222).
		/// </summary>
		[Category("Configurations"),
		 Description("Gets the port number that the server listen to " +
		             "(default value is 2222).")
		]
		public int PortNumber
		{
			get { return ServerPort; }
		}

		//-------------------------------------------------------------------------------
		/// <summary>Gets data on the server location and port number.
		/// </summary>
		[Category("Data"),
		 Description("Gets data on the server location and port number.")
		]
		public ServerInfo ServerInfo
		{
			get { return ServInfo; }
		}

		//-------------------------------------------------------------------------------
		/// <summary>
		/// Gets or sets the name of this <c>EasyServer</c> object.
		/// </summary>
		/// <exception cref="EasySocketException">
		/// When attempting to set the name to null.
		/// </exception>
		[Category("Misc"),
		 Description("Gets or sets the name of this EasyServer object.")
		]
		public string Name
		{
			get { return ServerName; }
			set
			{
				if (value == null) throw
					new EasySocketException("EasyServer name cannot be null.");
				ServerName = value;
			}
		}

		//-------------------------------------------------------------------------------
		/// <summary>
		/// Gets the amount of clients that currently connected to the server.
		/// This info is reffrenced to the last data was
		/// send\received\connection was made so don't trust on it right away
		/// unless you've just send\received\connection was made.
		/// </summary>
		[Category("Misc"),
		 Description("Gets the amount of Clients that currently connected to the server.")
		]
		public int CountClients
		{
			get
			{
				return ClientsSocketsList.Count;
			}
		}

		//-------------------------------------------------------------------------------
		/// <summary>
		/// Indicated weather the <c>EasyServer</c> is ready for clients connections.
		/// If returns false, make sure you called the <c>StartListen()</c> function.
		/// </summary>
		[Category("Misc"),
		 Description("Indicated weather the EasyServer is ready for clients connections." +
		             " If returns false, make sure you called the StartListen() function.")
		]
		public bool IsReady
		{
			get
			{
				return (NewClientsScanner.ThreadState != ThreadState.Stopped &&
				        NewClientsScanner.ThreadState != ThreadState.Suspended &&
				        NewClientsScanner.ThreadState != ThreadState.Unstarted &&
				        //if combination betewwn Suspended and WaitSleepJoin
				        (byte)NewClientsScanner.ThreadState != 96);
			}
		}

		//-------------------------------------------------------------------------------

		/// <summary>
		/// Gets or sets list of clients IP address that the <c>EasyServer</c> should reject
		/// connection attempts from.
		/// </summary>
		[Category("Behaviour"),
		 Description("Gets or sets list of clients IP address that the " +
		             "EasyServer should reject connection attempts from.")
		]
		public IPsBlackList BlackList
		{
			get { return BlackListIPs; }
			set { BlackListIPs = value; }
		}

		#endregion

		//------------------------------------------------------------------------------------
		#region Public events

		/// <summary>Invoked when data is sent from the server to a client.</summary>
		[Description("Invoked when data is sent from the server to a client."),
		 Category("Misc")
		]
		public event DataSent_EventHandler DataSent
		{
			add { OnDataSent += value; }
			remove { OnDataSent -= value; }
		}


		//-------------------------------------------------------------------------------
		/// <summary>Invoked when data is arriving from a client to the server.</summary>
		[Description("Invoked when data is arriving from a client to the server."),
		 Category("Misc")
		]
		public event DataArrived2Server_EventHandler DataArrived
		{
			add { OnDataArrived += value; }
			remove { OnDataArrived -= value; }
		}

		//-------------------------------------------------------------------------------
		/// <summary>
		/// Invoked when client on the black list, attempts to connect the server.
		/// </summary>
		[Description("Invoked when client on the black list, attempt s connect the server."),
		 Category("Misc")
		]
		public event ClientRejected_EventHandler ClientRejected
		{
			add { OnClientRejected += value; }
			remove { OnClientRejected -= value; }
		}


		//-------------------------------------------------------------------------------
		/// <summary>
		/// Invoked when error accures while sending data asynchroniclly(instead of exception).
		/// </summary>
		[Description("Invoked when error accures while sending data" +
		             " asynchroniclly(instead of exception)."),
		 Category("Misc")
		]
		public event DataSendAsyncError_EventHandler DataSendAsyncError
		{
			add { OnDataSendAsyncError = value; }
			remove { OnDataSendAsyncError -= value; }
		}

		#endregion

		//------------------------------------------------------------------------------------
		#region Public functions

		/// <summary>
		/// Creates new instance of <c>EasyServer</c>,sets it's port number to 2222
		/// and creating a thread to listen for new clients.
		/// </summary>
		/// <param name="UseSmartManagement">
		/// Use\not use the <c>SmartManagment</c> advanced option, that uses set
		/// of rules to manage the list of clients and threads.
		/// </param>
		/// <exception cref="EasySocketException">
		/// When the <c>EasyServer</c> failed to resolve localhost\IP or creating
		/// <c>TCPListener</c> using the localhost and the selected port.
		/// </exception>
		public EasyServer(bool UseSmartManagement) : this(null, UseSmartManagement)
		{
//			SmartManagementOn = UseSmartManagement;
//			ServerPort = 2222;
//			IPAddress ServerAddress;
//			try {
//				ServerAddress = Dns.GetHostByName(Dns.GetHostName()).AddressList[0];
//				Listener = new TcpListener(ServerAddress, ServerPort);
//			} catch (Exception error) {
//				throw new EasySocketException("Error on attempt to resolve " +
//				                              "server's IP address.", error);
//			}
//
//			NewClientsScanner = new Thread(new ThreadStart(ScanForNewClients));
//			NewClientsScanner.Priority = _ClientsScanPriority;
//			NewClientsScanner.Name = "ClientsScanner";
//			NewDataScanner = new Thread(new ThreadStart(ScanForData));
//			NewDataScanner.Priority = _DataScanPriority;
//			NewDataScanner.Name = "DataScanner";
//			ServInfo = new ServerInfo(ServerAddress, ServerPort, true);
//
//			/*creating a SmartManagementThread thread that will start auto when
//			 * client will connect the server( view SetEventHandlers function ).*/
//			if (SmartManagementOn) {
//				SmartManagementThread = new Thread(new ThreadStart(SmartManagement));
//				SmartManagementThread.Priority = _SmartManagmentPriority;
//				SmartManagementThread.Name = "SmartManagement";
//			}
//			SetEventHandlers();
		}

		//-------------------------------------------------------------------------------
		/// <summary>
		/// Creates new instance of <c>EasyServer</c> with a name ,sets it's port
		/// number to 2222 and creating a thread to listen for new clients.
		/// </summary>
		/// <param name="ServerName">The name of the server</param>
		/// <param name="UseSmartManagement">
		/// Use\not use the <c>SmartManagment</c> advanced option, that uses set of rules
		/// to manage the list of clients and threads.
		/// </param>
		/// <exception cref="EasySocketException">
		/// When the <c>EasyServer</c> failed to resolve localhost\IP or
		/// creating <c>TCPListener</c> using the localhost and the selected port.
		/// </exception>
		public EasyServer(string ServerName, bool UseSmartManagement) : this(2222, ServerName, UseSmartManagement)
		{
//			SmartManagementOn = UseSmartManagement;
//			Name = ServerName;
//			ServerPort = 2222;
//			IPAddress ServerAddress;
//			try {
//				ServerAddress = Dns.GetHostByName(Dns.GetHostName()).AddressList[0];
//				Listener = new TcpListener(ServerAddress, ServerPort);
//			} catch (Exception error) {
//				throw new EasySocketException("Error on attempt to resolve " +
//				                              "server's IP address.", error);
//			}
//
//			NewClientsScanner = new Thread(new ThreadStart(ScanForNewClients));
//			NewClientsScanner.Priority = _ClientsScanPriority;
//			NewClientsScanner.Name = "ClientsScanner";
//			NewDataScanner = new Thread(new ThreadStart(ScanForData));
//			NewDataScanner.Priority = DataScanPriority;
//			NewDataScanner.Name = "DataScanner";
//			ServInfo = new ServerInfo(ServerAddress, ServerPort, true);
//
//			/*creating a SmartManagementThread thread that will start auto when
//			 * client will connect the server( view SetEventHandlers function ).*/
//			if (SmartManagementOn) {
//				SmartManagementThread = new Thread(new ThreadStart(SmartManagement));
//				SmartManagementThread.Priority = _SmartManagmentPriority;
//				SmartManagementThread.Name = "SmartManagementThread";
//			}
//
//			SetEventHandlers();
		}
		//-------------------------------------------------------------------------------------

		/// <summary>
		/// Creates new instance of <c>EasyServer</c>, sets it's port number to the given
		/// port number and creating a thread to listen for new clients.
		/// </summary>
		/// <param name="PortNumber">Port number that the server will listen on.</param>
		/// <param name="UseSmartManagement">
		/// Use\not use the <c>SmartManagment</c> advanced option, that uses set of rules
		/// to manage the list of clients and threads.
		/// </param>
		/// <exception cref="EasySocketException">
		/// When the <c>EasyServer</c> failed to resolve localhost\IP or creating
		/// <c>TCPListener</c> using the localhost and the selected port.
		/// </exception>
		public EasyServer(int PortNumber, bool UseSmartManagement) : this(PortNumber, null, UseSmartManagement)
		{
//			if (PortNumber <= 0) throw
//				new EasySocketException("Server's port number must be greater than 0");
//
//			IPAddress ServerAddress;
//			SmartManagementOn = UseSmartManagement;
//			ServerPort = PortNumber;
//			try {
//				ServerAddress = Dns.GetHostByName(Dns.GetHostName()).AddressList[0];
//				Listener = new TcpListener(ServerAddress, ServerPort);
//			} catch (Exception error) {
//				throw new EasySocketException("Error on attempt to resolve " +
//				                              "server's IP address.", error);
//			}
//
//			NewClientsScanner = new Thread(new ThreadStart(ScanForNewClients));
//			NewClientsScanner.Priority = _ClientsScanPriority;
//			NewClientsScanner.Name = "ClientsScanner";
//			NewDataScanner = new Thread(new ThreadStart(ScanForData));
//			NewDataScanner.Priority = DataScanPriority;
//			NewDataScanner.Name = "DataScanner";
//			ServInfo = new ServerInfo(ServerAddress, ServerPort, true);
//
//			/*creating a SmartManagementThread thread that will start auto when
//			 * client will connect the server( view SetEventHandlers function ).*/
//			if (SmartManagementOn) {
//				SmartManagementThread = new Thread(new ThreadStart(SmartManagement));
//				SmartManagementThread.Priority = _SmartManagmentPriority;
//				SmartManagementThread.Name = "SmartManagement";
//			}
//			SetEventHandlers();
		}

		//-----------------------------------------------------------------------------------
		/// <summary>
		/// Creates new instance of <c>EasyServer</c> with a name,
		/// sets it's port number to the given port number and creating a thread
		/// to listen for new clients.
		/// </summary>
		/// <param name="PortNumber">Port number that the server will listen on.</param>
		/// <param name="ServerName">The name of the server</param>
		/// <param name="UseSmartManagement">
		/// Use\not use the <c>SmartManagment</c> advanced option, that uses set of rules
		/// to manage the list of clients and threads.
		/// </param>
		/// <exception cref="EasySocketException">
		/// When the EasyServer failed to resolve localhost\IP or creating <c>TCPListener</c>
		/// using the localhost and the selected port.
		/// </exception>
		public EasyServer(int PortNumber, string ServerName, bool UseSmartManagement)
		{
			if (PortNumber <= 0) throw
				new EasySocketException("Server's port number must be greater than 0");

			IPAddress ServerAddress;
			Name = ServerName;
			SmartManagementOn = UseSmartManagement;
			ServerPort = PortNumber;
			try {
				ServerAddress = Dns.GetHostByName(Dns.GetHostName()).AddressList[0];
				Listener = new TcpListener(ServerAddress, ServerPort);
			} catch (Exception error) {
				throw new EasySocketException("Error on attempt to resolve " +
				                              "server's IP address.", error);
			}

			NewClientsScanner = new Thread(new ThreadStart(ScanForNewClients));
			NewClientsScanner.Priority = _ClientsScanPriority;
			NewClientsScanner.Name = "ClientsScanner";
			NewDataScanner = new Thread(new ThreadStart(ScanForData));
			NewDataScanner.Priority = DataScanPriority;
			NewDataScanner.Name = "DataScanner";
			ServInfo = new ServerInfo(ServerAddress, ServerPort, true);

			/*creating a SmartManagementThread thread that will start auto when
			 * client will connect the server( view SetEventHandlers function ).*/
			if (SmartManagementOn) {
				SmartManagementThread = new Thread(new ThreadStart(SmartManagement));
				SmartManagementThread.Priority = _SmartManagmentPriority;
				SmartManagementThread.Name = "SmartManagement";
			}
			SetEventHandlers();
		}

		//-----------------------------------------------------------------------------------

		/// <summary>
		/// Returns the string representation of the object.
		/// </summary>
		/// <returns>string representation of the object.</returns>
		public override string ToString()
		{
			if (Name != "Anonymous")
				return "Server: " + Name + " " + ServInfo.ToString();
			else return "Anonymous server " + ServInfo.ToString();
		}

		//-------------------------------------------------------------------------------
		/// <summary>
		/// Starts listening for connections attempts.
		/// </summary>
		public void StartListen()
		{
			switch (NewClientsScanner.ThreadState) {
				case ThreadState.Unstarted:
					NewClientsScanner.Start();
					break;
				case ThreadState.Suspended:
					Listener.Start();
					NewClientsScanner.Resume();
					break;
				default:
					//If it's a combination betewwn Suspended and WaitSleepJoin
					//meaning result of bitwise (32 XOR 64).
					if ((byte)NewClientsScanner.ThreadState == 96) {
						Listener.Start();
						NewClientsScanner.Resume();
					}
					break;
			}
			/*Don't scan for incoming data if no clients in list
			 * (Thread will start auto when a client will connect.*/
		}
		//-------------------------------------------------------------------------------
		/// <summary>
		/// Stops listening for connections attempts and new incoming data.
		/// </summary>
		public void StopListen()
		{
			switch (NewClientsScanner.ThreadState) {
				case ThreadState.WaitSleepJoin:
				case ThreadState.Running:
					NewClientsScanner.Suspend();
					Listener.Stop();
					break;
			}

			if (NewDataScanner.ThreadState == ThreadState.Running) {
				NewDataScanner.Suspend();
				Listener.Stop();
			}

		}

		//-------------------------------------------------------------------------------
		/// <summary>
		/// Sending an object to all the clients.
		/// </summary>
		/// <param name="DataToSend">The object to send to the clients.</param>
		/// <remarks>The sent object must be serializable.</remarks>
		public void SendDataToAllClients(Object DataToSend)
		{
			ByPassDataToSend = null; //Reseting to default value and getting ready to re-initilezed.
			short i; bool DataWasSent = false;

			lock (this)//don't allow more then one async data sending at a time
			{
				foreach (SocketStream Sock in ClientsSocketsList) {
					if (!Sock.GetSocket.Connected)
						//In case we're during connection establishment few sec' for connection
						for (i = 0; !Sock.GetSocket.Connected && i < 15; ++i)
							Thread.Sleep(500);

					//if still not connected skip client
					if (!Sock.GetSocket.Connected) continue;

					BinaryCaster.Serialize(Sock.GetNetworkStream, DataToSend);
					Sock.GetNetworkStream.Flush();

					//updating last communication time with the client
					if (SmartManagementOn) Sock.UpdateTransportTime();

					DataWasSent = true;
				}//end of foreach
			}//end of locking block

			//Don;t invoke event on special command
			if (DataWasSent && OnDataSent != null && DataToSend.GetType().Name != "EasySocketCommands")
				OnDataSent(DataToSend);

		}//end of function

		//-------------------------------------------------------------------------------
		/// <summary>
		/// This is the asynchronic overload of the function(Not waiting for results).
		/// Sending an object to all the clients.
		/// </summary>
		/// <param name="DataToSend">The object to send to the clients.</param>
		/// <remarks>
		/// The object must be serializable. Sending nulled object will take no action.
		/// </remarks>
		public void SendDataToAllClientsAsync(Object DataToSend)
		{
			if (DataToSend == null) return;
			while (ByPassDataToSend != null) Thread.Sleep(15); //Sleep till ready to use ByPassDataToSend
			//Run a separate thread to send data
			ByPassDataToSend = DataToSend;
			new Thread(new ThreadStart(SendDataToAllClientsByPass)).Start();
		}

		//-------------------------------------------------------------------------------

		/// <summary>
		/// Sending an object to a specific clients.
		/// </summary>
		/// <param name="DataToSend">The object to send to the clients.</param>
		/// <param name="TargetClient">
		/// The client to send the data.(Must be connected to the server).</param>
		/// <returns>true if data was send, false if not.</returns>
		/// <exception cref="EasySocketException">
		/// When the <c>ClientInfo</c> is illegal.
		/// </exception>
		/// <remarks>The send object must be serializable.</remarks>
		public bool SendData(Object DataToSend, ClientInfo TargetClient)
		{
			ByPassDataToSend = null; //Reseting to default value and getting ready to re-initilezed.

			bool ClientFound = false;
			String TargetIP = TargetClient.ClientIP;

			lock (this)//Don't allow more then async data sending at a time
			{
				if (!TargetClient.IsLegal)//If the TargetClient isn't legal.
				{
					if (IsAsyncMode)//Is this is async call?
					{
						IsAsyncMode = false; //Returning to default mode.
						if (OnDataSendAsyncError != null)//if there is event handler.
							OnDataSendAsyncError("Error on attempt to send data, ClientInfo isn't legal.");

						return false;//The value isn't relevant in this case(no way to read it)
					} else throw new EasySocketException("Error on attempt to send data," +
					                                     " ClientInfo isn't legal.");
				}
				/*Searching for the target client in the connected clients list:
				 * 
				 * The loop rus in a way that if there are more 1 client on a machine
				 * it will send the same data to eavh of them:						*/

				foreach (SocketStream Sock in ClientsSocketsList) {
					if (GetClientIP(Sock) == TargetIP && Sock.GetSocket.Connected) {
						ClientFound = true;
						//Send data
						BinaryCaster.Serialize(Sock.GetNetworkStream, DataToSend);
						Sock.GetNetworkStream.Flush();

						//updating last communication time with the client
						if (SmartManagementOn) Sock.UpdateTransportTime();

					}//end of if block
				}//end of foreach
			}//end of locking block

			//Call event user's handlers if exist (only if not special command)
			if (ClientFound && OnDataSent != null && DataToSend.GetType().Name != "EasySocketCommands")
				OnDataSent(DataToSend);

			return ClientFound;
		}

		//-------------------------------------------------------------------------------

		/// <summary>
		/// This is the asynchronic overload of the function(Not waiting for results).
		/// Sending an object to a specific clients.
		/// </summary>
		/// <param name="DataToSend">The object to send to the clients.</param>
		/// <param name="TargetClient">
		/// The client to send the data.(Must be connected to the server).
		/// </param>
		///<remarks>
		/// Since this function is asynchronic, no exceptions are thrown
		/// Instead use the <c>OnDataSendAsyncError</c> event handler.
		/// The send object must be serializable. Sending nulled object will take no action.
		///</remarks>
		public void SendDataAsync(Object DataToSend, ClientInfo TargetClient)
		{
			//Run a separate thread to send data
			if (DataToSend == null || TargetClient == null) return;
			while (ByPassDataToSend != null) Thread.Sleep(15); //Sleep till ready to use ByPassDataToSend
			ByPassDataToSend = DataToSend;
			ByPassTargetClientInfo = TargetClient;
			new Thread(new ThreadStart(SendDataInfoByPass)).Start();
		}
		//-------------------------------------------------------------------------------

		/// <summary>
		/// Sending an object to a specific clients.
		/// </summary>
		/// <param name="DataToSend">The object to send to the clients.</param>
		/// <param name="TargetClientIndex">
		/// The position of the client to send the data in the <c>ClientsList</c> collection.
		/// .(Must be connected to the server).
		/// </param>
		/// <returns>true if data was send, false if not.</returns>
		/// <remarks>The object must be serializable.</remarks>
		public bool SendData(Object DataToSend, int TargetClientIndex)
		{
			ByPassDataToSend = null; //Reseting to default value and getting ready to re-initilezed.

			SocketStream TargetClient = ClientsSocketsList[TargetClientIndex];

			lock (this)//Don't allow more then async data sending at a time
			{
				//If sending isn't possible.
				if (!TargetClient.GetSocket.Connected) {
					if (IsAsyncMode)//Is this is async call?
					{
						IsAsyncMode = false; //Returning to default mode.
						if (OnDataSendAsyncError != null)//If there is event hansler, use it
							OnDataSendAsyncError("Client isn't connected.");
					}
					return false; /*If this is a async call, no way to read the value,
					 *but if is regular call user will read the boolean value.*/
				}

				//Send data
				BinaryCaster.Serialize(TargetClient.GetNetworkStream, DataToSend);
				TargetClient.GetNetworkStream.Flush();

				//updating last communication time with the client
				if (SmartManagementOn) TargetClient.UpdateTransportTime();

			}//end of locking block

			//Call event user's handlers if exist( only if not special command)
			if (OnDataSent != null && DataToSend.GetType().Name != "EasySocketCommands")
				OnDataSent(DataToSend);

			return true;
		}

		//-------------------------------------------------------------------------------

		/// <summary>
		/// This is the asynchronic overload of the function(Not waiting for results).
		/// Sending an object to a specific clients.
		/// </summary>
		/// <param name="DataToSend">The object to send to the clients.</param>
		/// <param name="TargetClientIndex">
		/// The position of the client to send the data in the <c>ClientsList</c> collection.
		/// .(Must be connected to the server).
		/// </param>
		///<remarks>
		/// Since this function is asynchronic, no exceptions are thrown
		/// Instead use the <c>OnDataSendAsyncError</c> event handler.
		/// The send object must be serializable. Sending nulled object will take no action.
		///</remarks>
		public void SendDataAsync(Object DataToSend, int TargetClientIndex)
		{
			//Run a separate thread to send data
			if (DataToSend == null) return;
			while (ByPassDataToSend != null) Thread.Sleep(15); //Sleep till ready to use ByPassDataToSend
			ByPassDataToSend = DataToSend;
			ByPassTargetClient = TargetClientIndex;
			new Thread(new ThreadStart(SendDataIndexByPass)).Start();
		}

		#endregion

		#region private functions

		//-------------------------------------------------------------------------------
		/// <summary>
		/// Sending a spechial command or message to a client with
		/// the <c>SendData</c> function.
		/// </summary>
		/// <param name="Command">The command\message to the server.</param>
		/// <param name="TargetClientIndex">
		/// The position of a client in the <c>ClientsList</c> that the command ment for.
		/// </param>
		/// <remarks>This should be used only when communicating with
		/// <c>EasyClient</c> client type.
		/// </remarks>
		private void SendCommand(EasySocketCommands Command, int TargetClientIndex)
		{
			SendData(Command, TargetClientIndex);
		}

		//-------------------------------------------------------------------------------
		/// <summary>
		/// This function calls the <c>SendDataToAllClients</c> function and sends as an argument
		/// the <c>ByPassDataToSend</c> private member. It's should run as a separate
		/// thraed and by so creating asynchronic version of <c>SendData</c>.
		/// </summary>
		/// <remarks>
		/// <c>ByPassDataToSend</c> should refer the data to be sent.
		/// </remarks>
		private void SendDataToAllClientsByPass()
		{
			SendDataToAllClients(ByPassDataToSend);
			IsAsyncMode = false; //Restore to default mode
		}

		//-------------------------------------------------------------------------------
		/// <summary>
		/// This function calls the <c>SendData</c> function and sends as an argument
		/// the <c>ByPassDataToSend</c> and <c>ByPassTargetClient</c> private members.
		/// It's should run as a separate thraed and by so creating asynchronic version
		/// of <c>SendData</c>.
		/// </summary>
		/// <remarks>
		/// <c>ByPassDataToSend</c> should refer the data to be sent.
		/// <c>ByPassTargetClient</c> should index the TargetClient in the <c>ClientsSocketList</c>.
		/// </remarks>
		private void SendDataIndexByPass()
		{
			SendData(ByPassDataToSend, ByPassTargetClient);
			IsAsyncMode = false; //Restore to default mode
		}

		//-------------------------------------------------------------------------------
		/// <summary>
		/// This function calls the <c>SendData</c> function and sends as an argument
		/// the <c>ByPassDataToSend</c> and <c>ByPassTargetClientInfo</c> private members.
		/// It's should run as a separate thraed and by so creating asynchronic version
		/// of <c>SendData</c>.
		/// </summary>
		/// <remarks>
		/// <c>ByPassDataToSend</c> should refer the data to be sent.
		/// <c>ByPassTargetClientInfo</c> should refer to information about the target client.
		/// </remarks>
		private void SendDataInfoByPass()
		{
			SendData(ByPassDataToSend, ByPassTargetClientInfo);
			IsAsyncMode = false; //Restore to default mode
		}

		//-------------------------------------------------------------------------------

		/// <summary>
		/// This function scans for new clients that requests connect to the server
		/// and adds them to the <c>ClientsSocketsList</c>.
		/// </summary>
		private void ScanForNewClients()
		{
			Listener.Start();
			while (true) {
				//Requesting to close the thread( when Dispose() is called )
				if (!DoThreads) Thread.CurrentThread.Abort();

				//if no clients waiting sleep.
				if (!Listener.Pending()) {
					Thread.Sleep((int)(2000 / _GeneralPriority)); //Check for new clients every 2 sec'.
					continue;
				}

				Socket NewClient = Listener.AcceptSocket();
				//If the new client socket is null continue the loop.
				if (NewClient == null) continue;
				
				ClientEventArgs e = new ClientEventArgs();
				OnClientAdding(e);

				//If the client IP is in the BlackList, reject him and invoke Event handlers
				if ((BlackListIPs != null && BlackListIPs.Contains(GetClientIP(NewClient))) || e.Cancel) {
					//Calling handlers uf there are such.
					
					if (OnClientRejected != null) OnClientRejected(NewClient);
					int i = ClientsSocketsList.Add(new SocketStream(NewClient));
					SendCommand(EasySocketCommands.Rejected, i);
					continue;
				}
				ClientsSocketsList.Add(new SocketStream(NewClient));
			}
		}
		
		public event EventHandler<ClientEventArgs> ClientAdding;
		
		void OnClientAdding(ClientEventArgs e)
		{
			if (ClientAdding != null) {
				ClientAdding(this, e);
			}
		}

		//-------------------------------------------------------------------------------
		/// <summary>
		/// This function scans for data dispached from clients machine constantly.
		/// </summary>
		/// <exception cref="IOException">
		/// May be caused if the a client sent over data and closed the
		/// connection right away.
		/// </exception>
		private void ScanForData()
		{
			while (true) {
				//Requesting to close the thread( when Dispose() is called )
				if (!DoThreads) Thread.CurrentThread.Abort();

				for (short i = 0; i < ClientsSocketsList.Count; ++i) {
					if (!ClientsSocketsList[i].GetSocket.Connected) {
						ClientsSocketsList[i].Dispose();
						ClientsSocketsList.Remove(ClientsSocketsList[i]);
						--i;
						continue;
					}
					if (ClientsSocketsList[i].GetSocket.Available > 0)//Is there data for us?
					{
						/*If IOexceprion is thrown here, it's probably cos' the client sent data
						 *and closed the connection right away.(To fix let the client wait a bit
						 before closing the connection.*/

						//updating last communication time with the client
						if (SmartManagementOn) ClientsSocketsList[i].UpdateTransportTime();

						//Get data
						Object Data = BinaryCaster.Deserialize(ClientsSocketsList[i].GetNetworkStream);

						//If the data is a special command\msg from EasyClient
						if (Data.GetType().Name == "EasySocketCommands") {
							switch ((EasySocketCommands)Data) {
									/*If the client disconnecting lets close it's socket
									 *and remove from the ClientsSocketsList.*/
								case EasySocketCommands.Disconnecting:
									ClientsSocketsList[i].Dispose();
									ClientsSocketsList.Remove(ClientsSocketsList[i]);
									break;
									//If the data was sent to test communication, dend it a response.
								case EasySocketCommands.TestCom:
									SendCommand(EasySocketCommands.TestComOK, i);
									break;
							}
						}//end if
						else if (OnDataArrived != null) //if the data isn't special command, call event handlers
							OnDataArrived(Data, ClientsSocketsList[i]);
					}
				}//end of for
				//Give the CPU a break
				Thread.Sleep((int)(150 / _GeneralPriority));
			}//end of while
		}//end of function

		//-------------------------------------------------------------------------------

		/// <summary>Sets some event handlers for the <c>ClientsSocketsList</c>.</summary>
		private void SetEventHandlers()
		{
			ClientsSocketsList.EmptyList += new SocketsListEventHandler(ClientsSocketsList_EmptyList);
			ClientsSocketsList.FirstItemAdded += new SocketsListEventHandler(ClientsSocketsList_FirstItemAdded);
		}
		//-------------------------------------------------------------------------------

		/// <summary>
		/// Called when ever the <c>ClientsSocketList</c> gets empty and
		/// stoping the the incoming data scan thread, by so saving cpu time.
		/// </summary>
		private void ClientsSocketsList_EmptyList()
		{

			//handling the NewDataScanner thread

			if (NewDataScanner.ThreadState != ThreadState.Stopped &&
			    NewDataScanner.ThreadState != ThreadState.Suspended &&
			    NewDataScanner.ThreadState != ThreadState.Unstarted &&
			    //if combination betewwn Suspended and WaitSleepJoin
			    (byte)NewDataScanner.ThreadState != 96
			   )
				NewDataScanner.Suspend();


			//handling the SmartManagementThread thread

			if (!SmartManagementOn) return;

			if (SmartManagementThread.ThreadState != ThreadState.Stopped &&
			    SmartManagementThread.ThreadState != ThreadState.Suspended &&
			    SmartManagementThread.ThreadState != ThreadState.Unstarted &&
			    //if combination betewwn Suspended and WaitSleepJoin
			    (byte)SmartManagementThread.ThreadState != 96) {
				SmartManagementThread.Suspend();
			}
		}
		//-------------------------------------------------------------------------------

		/// <summary>
		/// Called when ever item is added to the <c>ClientsSocketList</c>
		/// for the first time (Only one item). Then starting the
		/// the incoming data scan thread, by so saving cpu time.
		/// </summary>
		private void ClientsSocketsList_FirstItemAdded()
		{
			//handling the new data scanner thread
			switch (NewDataScanner.ThreadState) {
				case ThreadState.Stopped:
				case ThreadState.Suspended:
					NewDataScanner.Resume();
					break;
				case ThreadState.Unstarted:
					NewDataScanner.Start();
					break;
				default:
					//If it's a combination betewwn Suspended and WaitSleepJoin
					//meaning result of bitwise (32 XOR 64).
					if ((byte)NewDataScanner.ThreadState == 96)
						NewDataScanner.Resume();
					break;
			}//end of switch

			//handling the SmartManagementThread thread

			if (!SmartManagementOn) return;

			switch (NewDataScanner.ThreadState) {
				case ThreadState.Stopped:
				case ThreadState.Suspended:
					SmartManagementThread.Resume();
					break;
				case ThreadState.Unstarted:
					SmartManagementThread.Start();
					break;
				default:
					//If it's a combination betewwn Suspended and WaitSleepJoin
					//meaning result of bitwise (32 XOR 64).
					if ((byte)SmartManagementThread.ThreadState == 96)
						SmartManagementThread.Resume();
					break;
			}//end of switch
		}

		//-------------------------------------------------------------------------------
		/// <summary>
		/// Gets the IP adderess of a <c>SocketStream</c> object client.
		/// </summary>
		/// <param name="Client">The <c>SocketStream</c> of the client to extract IP from.</param>
		/// <returns>IP adderess of the client.</returns>
		private string GetClientIP(SocketStream Client)
		{
			string S = Client.GetSocket.RemoteEndPoint.ToString();
			return S.Substring(0, S.IndexOf(':'));
		}

		//-------------------------------------------------------------------------------
		/// <summary>
		/// Gets the IP adderess of a <c>Socket</c> object client.
		/// </summary>
		/// <param name="Client">The Socket of the client to extract IP from.</param>
		/// <returns>IP adderess of the client.</returns>
		private string GetClientIP(Socket Client)
		{
			string S = Client.RemoteEndPoint.ToString();
			return S.Substring(0, S.IndexOf(':'));
		}

		//-------------------------------------------------------------------------------
		//TODO: Add this function the ability to manage other threads sleep time.

		/// <summary>
		/// Removes cilents that connected to the server and have'nt
		/// created any communication for some time.
		/// This function should be run as a separate thread
		/// </summary>
		/// <remarks>Runs only when the '<c>SmartManagementOn</c>' flag enabled.</remarks>
		private void SmartManagement()
		{
			//Must try catch here cos' this thread is interrupted from
			//the CloseThread() function, at the Dispose process.
			try {
				SocketStream Sock;
				while (true) {
					//Requesting to close the thread( when Dispose() is called )
					if (!DoThreads) Thread.CurrentThread.Abort();

					for (int i = 0; i < ClientsSocketsList.Count; ++i) {
						Sock = ClientsSocketsList[i];
						if ((DateTime.Now - Sock.LastTransportTime).Minutes > _MinutsTillDisconnecting) {
							Sock.Dispose();
							ClientsSocketsList.Remove(Sock);
							--i;
						}
					}//end of for loop
					Thread.Sleep((int)(30000 / _GeneralPriority));
				}//end of while
			}//end of try block
			catch (Exception) { }
		}
		//-------------------------------------------------------------------------------

		#endregion

		/////////////////////////////////////////////////////////////////////////////////////
	}//end of EasyServer class
}
