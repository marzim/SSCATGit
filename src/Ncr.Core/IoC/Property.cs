//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Xml.Serialization;

namespace Ncr.Core.IoC
{
	public delegate void PropertyEventHandler(object sender, PropertyEventArgs e);
	
	public interface IProperty
	{
		bool HasReference { get; }
		
		string Name { get; set; }
		
		string Value { get; set; }
		
		string Type { get; set; }
		
		string Reference { get; set; }
	}
	
	public class PropertyEventArgs : EventArgs
	{
		Property property;
		
		public PropertyEventArgs(Property property)
		{
			this.property = property;
		}
		
		public Property Property {
			get { return property; }
			set { property = value; }
		}
	}
	
	public class Property : IProperty
	{
		string name;
		string type;
		string reference;
		string val;
		object referenceValue;
		
		public Property()
		{
		}
		
		public Property(string name, string val)
		{
			this.name = name;
			this.Value = val;
		}
		
		[XmlIgnore()] public object ReferenceValue {
			get { return referenceValue; }
			set { referenceValue = value; }
		}
		
		[XmlAttribute("Value")] public string Value {
			get { return val; }
			set { val = value; }
		}
		
		[XmlIgnore()] public bool HasReference {
			get { return (reference != null && !reference.Equals(string.Empty)); }
		}
		
		[XmlAttribute("Reference")] public string Reference {
			get { return reference; }
			set { reference = value; }
		}
		
		[XmlAttribute("Type")] public string Type {
			get { return type; }
			set { type = value; }
		}
		
		[XmlAttribute("Name")] public string Name {
			get { return name; }
			set { name = value; }
		}
		
		public object GetValue()
		{
			Type t = System.Type.GetType(Type);
			if (t == null) {
				throw new Exception(string.Format("Type for property '{0}' should not be null", Name));
			}
			if (t == typeof(bool)) {
				return Boolean.Parse(Value);
			} else if (t == typeof(int)) {
				return Int32.Parse(Value);
			} else {
				return Value;
			}
		}
	}
}
