using System;

namespace PsxNet
{
    public class PsxEventArgs : EventArgs
    {
        string connectionName;
        string contextName;
        string controlName;
        string eventName;
        object param;
        string hostName;
        string serviceName;
        uint timeout;
        
        public PsxEventArgs(string hostName, string serviceName, string connectionName, object param, uint timeout)
        {
        	this.hostName = hostName;
        	this.serviceName = serviceName;
        	this.connectionName = connectionName;
        	this.param = param;
        	this.timeout = timeout;
        }

        public PsxEventArgs(string connectionName, string controlName, string contextName, string eventName, object param)
        {
            this.connectionName = connectionName;
            this.controlName = controlName;
            this.contextName = contextName;
            this.eventName = eventName;
            this.param = param;
        }
        
		public string HostName {
			get { return hostName; }
			set { hostName = value; }
		}
        
		public string ServiceName {
			get { return serviceName; }
			set { serviceName = value; }
		}
        
		public uint Timeout {
			get { return timeout; }
			set { timeout = value; }
		}

        public string ConnectionName {
            get { return this.connectionName; }
        }

        public string ContextName {
            get { return this.contextName; }
        }

        public string ControlName {
            get { return this.controlName; }
        }

        public string EventName {
            get { return this.eventName; }
        }

        public object Param {
            get { return this.param; }
        }
    }
}