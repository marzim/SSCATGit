//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//		<owner name="Apple Leo Chiong" email="apple_leo_derilo.chiong@ncr.com"/>
//	</file>

using System;
using System.Collections;
using Ncr.Core.Models;
using NUnit.Framework;
using PsxNet;

namespace Ncr.Core.Tests.Models
{
	public class PsxStub : IPsx
	{
		static Hashtable instances = new Hashtable();
		string connectionName;
		string serviceName;
		string hostName;
		
		public PsxStub()
		{
		}
		
		public PsxStub(string host, string service, string name, int timeout) : this(host, service, name, "", timeout)
		{
		}
		
		public PsxStub(string host, string service, string name, object param, int timeout)
		{
			this.HostName = host;
			this.ConnectionName = name;
			this.ServiceName = service;
		}
		
		public event PsxEventHandler PsxEvent;
		
		public bool IsConnected {
			get { return true; }
		}
		
		public string HostName {
			get { return hostName; }
			set { hostName = value; }
		}
		
		public string ServiceName {
			get { return serviceName; }
			set { serviceName = value; }
		}
		
		public string ConnectionName {
			get { return connectionName; }
			set { connectionName = value; }
		}
		
		public virtual bool ContextEquals(string contextName)
		{
			return true;
		}
		
		public virtual bool IsControlVisible(string controlName)
		{
			return true;
		}
		
		public virtual bool IsClickable(string controlName)
		{
			return true;
		}
		
		public void ConnectRemote(int timeout)
		{
			object param = "";
			ConnectRemote(HostName, ServiceName, ConnectionName, ref param, timeout);
		}
		
		public void ConnectRemote(string hostName, string serviceName, string connectionName, int timeout)
		{
			object param = "";
			ConnectRemote(hostName, serviceName, connectionName, ref param, timeout);
		}
		
		public void ConnectRemote(string hostName, string serviceName, string connectionName, ref object param, int timeout)
		{
			this.ConnectionName = connectionName;
		}
		
		public void GenerateEvent(string controlName, string contextName, string eventName, object param)
		{
		}
		
		public void GenerateEvent(string connectionName, string controlName, string contextName, string eventName, object param)
		{
		}
		
		public virtual object GetControlProperty(string controlName, string propertyName)
		{
			if (controlName == "CMButton1StoreLogIn") {
				return 0;
			} else {
				return string.Format("{0},{1},{2},{3}", 0, 0, 0, 0);
			}
		}
		
		public virtual object SendControlCommand(string controlName, string command)
		{
			return string.Format("{0},{1},{2},{3}", 0, 0, 0, 0);
		}
		
		public virtual object SendControlCommand(string controlName, string command, int noParams, object[] commandParams)
		{
			return string.Format("{0},{1},{2},{3}", 0, 0, 0, 0);
		}
		
		public void Dispose()
		{
			throw new NotImplementedException();
		}
		
		public void GenerateEvent(string connectionName, string controlName, string contextName, string eventName)
		{
			object param = "";
			GenerateEvent(connectionName, controlName, contextName, eventName, param);
		}
		
		public virtual string GetContext(uint displayTarget)
		{
			return "Attract";
		}
		
		public void DisconnectRemote()
		{
		}
		
		public void DisconnectRemote(string connectionName)
		{
		}
		
		public void Stop()
		{
		}
		
		protected virtual void OnPsxEvent(PsxEventArgs e)
		{
			if (PsxEvent != null) {
				PsxEvent(this, e);
			}
		}
	}
}
