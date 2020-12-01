//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Collections;
using System.Xml.Serialization;

namespace Ncr.Core.IoC
{
	public class Method
	{
		string name;
		Parameter[] parameters;
		
		public Method()
		{
		}
		
		public Method(string name)
		{
			this.name = name;
		}
		
		[XmlElement("Parameter")] public Parameter[] Parameters {
			get { return parameters; }
			set { parameters = value; }
		}
		
		[XmlAttribute("Name")] public string Name {
			get { return name; }
			set { name = value; }
		}
		
		public void AddParameter(Parameter param)
		{
			ArrayList paramz = parameters == null ? new ArrayList() : new ArrayList(parameters);
			paramz.Add(param);
			parameters = new Parameter[paramz.Count];
			paramz.CopyTo(parameters);
		}
	}
}
