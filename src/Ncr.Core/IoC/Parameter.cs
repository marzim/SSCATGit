//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Xml.Serialization;

namespace Ncr.Core.IoC
{
	public delegate void ParameterEventHandler(object sender, ParameterEventArgs e);
	
	public class ParameterEventArgs : EventArgs
	{
		Parameter parameter;
		
		public ParameterEventArgs(Parameter parameter)
		{
			this.parameter = parameter;
		}
		
		public Parameter Parameter {
			get { return parameter; }
			set { parameter = value; }
		}
	}
	
	public class Parameter
	{
		string name;
		string val;
		string reference;
		object referenceObject;
		string type;
		string innerValue;
		
		public Parameter()
		{
		}
		
		public Parameter(string name, string val)
		{
			this.name = name;
			this.Value = val;
		}
		
		[XmlText()] public string InnerValue {
			get { return (innerValue != null) ? innerValue : ""; }
			set { innerValue = value; }
		}
		
		[XmlIgnore()] public Type ReferenceType {
			get { return ReferenceObject.GetType(); }
		}
		
		[XmlAttribute("Type")] public string Type {
			get {
				if (type == null) {
					throw new Exception(string.Format("Type for parameter should not be null"));
				}
				return type;
			}
			
			set {
				type = value;
			}
		}
		
		[XmlIgnore()] public object ReferenceObject {
			get { return referenceObject; }
			set { referenceObject = value; }
		}
		
		public bool HasReference {
			get { return (reference != null && !reference.Equals(string.Empty)); }
		}
		
		[XmlAttribute("Reference")] public string Reference {
			get { return reference; }
			set { reference = value; }
		}
		
		[XmlAttribute("Name")] public string Name {
			get { return name; }
			set { name = value; }
		}
		
		[XmlAttribute("Value")] public string Value {
			get {
				return (val != null && !val.Equals(string.Empty)) ? val : InnerValue;
			}
			
			set {
				val = value;
			}
		}
		
		public object GetValue()
		{
			Type t = System.Type.GetType(Type);
			if (t.IsEnum) {
				return Enum.Parse(t, Value);
			} else if (t == typeof(int)) {
				return Int32.Parse(Value);
			} else if (t == typeof(bool)) {
				return Boolean.Parse(Value);
			} else if (t == typeof(char[])) {
				return Value.ToCharArray();
			} else {
				return Value;
			}
		}
	}
}
