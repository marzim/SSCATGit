//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Collections;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Serialization;
using Ncr.Core.Models.Generics;
using Ncr.Core.Util;

namespace Ncr.Core.IoC
{
	[Obsolete()]
	public interface IApplicationContext
	{
		AppObjects Objects { get; }
		
		AppIncludes Includes { get; }
		
		bool HasIncludes { get; }
		
		object GetObject(string name);
		
		void AddContext(IApplicationContext context);
	}
	
	public interface IObject
	{
		event PropertyEventHandler PropertySetValue;
		
		string Id { get; set; }
		
		string Type { get; set; }
		
		Property[] Properties { get; set; }
		
		object Instantiate();
	}
	
	[XmlRoot("Context")]
	public class ApplicationContext : BaseSerializable<ApplicationContext>, IApplicationContext
	{
		AppObjects objects = new AppObjects();
		Hashtable mappedObjects = new Hashtable();
		AppIncludes includes = new AppIncludes();
		
		public ApplicationContext()
		{
		}
		
		public bool HasIncludes {
			get { return includes.Includes.Length > 0; }
		}
		
		[XmlElement("Includes")] public AppIncludes Includes {
			get { return includes; }
			set { includes = value; }
		}
		
		[XmlElement("Objects")] public AppObjects Objects {
			get { return objects; }
			set { objects = value; }
		}
		
		public static IApplicationContext GetContext(TextReader reader)
		{
			IApplicationContext context = Deserialize(reader);
			if (context.HasIncludes) {
				foreach (AppInclude i in context.Includes.Includes) {
					if (i.IsFile) {
						context.AddContext(GetContext(i.File));
					} else {
						context.AddContext(GetContext(new StringReader(i.Content)));
					}
				}
			}
			return context;
		}
		
		public static IApplicationContext GetContext()
		{
			string file = ConfigurationManager.AppSettings[ConfigurationManager.AppSettings["ApplicationContext"]];
			return GetContext(file);
		}
		
		public static IApplicationContext GetContext(string file)
		{
			return GetContext(new StringReader(new StreamReader(file).ReadToEnd()));
		}
		
		public void AddContext(IApplicationContext context)
		{
			AddObjects(context.Objects);
		}
		
		public void AddObjects(AppObjects objects)
		{
			foreach (AppObject o in objects.Objects) {
				AddObject(o);
			}
		}
		
		public void AddObject(AppObject o)
		{
			objects.AddObject(o);
		}
		
		public object GetObject(string id)
		{
			if (mappedObjects.ContainsKey(id)) {
				return (mappedObjects[id] as AppObject).Instantiate();
			} else {
				foreach (AppObject o in objects.Objects) {
					if (o.Id == id) {
						o.PropertySetValue += new PropertyEventHandler(ObjectPropertySetValue);
						o.MethodParameterSetValue += new ParameterEventHandler(ObjectMethodParameterSetValue);
						o.ConstructorParameterSetValue += new ParameterEventHandler(ObjectConstructorParameterSetValue);
						mappedObjects.Add(id, o);
						return o.Instantiate();
					}
				}
			}
			throw new Exception(string.Format("Application context doesn't contain object with ID '{0}'", id));
		}

		void ObjectConstructorParameterSetValue(object sender, ParameterEventArgs e)
		{
			e.Parameter.ReferenceObject = GetObject(e.Parameter.Reference);
		}

		void ObjectMethodParameterSetValue(object sender, ParameterEventArgs e)
		{
			e.Parameter.ReferenceObject = GetObject(e.Parameter.Reference);
		}

		void ObjectPropertySetValue(object sender, PropertyEventArgs e)
		{
			e.Property.ReferenceValue = GetObject(e.Property.Reference);
		}
	}
	
	public class AppIncludes
	{
		AppInclude[] includes;
		
		[XmlElementAttribute("Include")] public AppInclude[] Includes {
			get {
				if (includes == null) {
					return new AppInclude[0];
				}
				return includes;
			}
			
			set {
				includes = value;
			}
		}
	}
	
	public class AppInclude
	{
		string file;
		string content;
		
		[XmlText()] public string Content {
			get { return content; }
			set { content = value; }
		}
		
		public bool IsFile {
			get { return file != null && file != ""; }
		}
		
		[XmlAttribute("File")] public string File {
			get { return file; }
			set { file = value; }
		}
	}
	
	public class AppObjects
	{
		AppObject[] objects;
		
		[XmlElement("Object")] public AppObject[] Objects {
			get {
				if (objects == null) {
					return new AppObject[0];
				}
				return objects;
			}
			
			set {
				objects = value;
			}
		}
		
		public void AddObject(AppObject o)
		{
			ArrayList a = new ArrayList(Objects);
			a.Add(o);
			objects = new AppObject[a.Count];
			a.CopyTo(objects);
		}
	}
	
	[XmlRoot("Object")]
	public class AppObject : BaseSerializable<AppObject>, IObject
	{
		string id;
		string type;
		Property[] properties;
		Method[] methods;
		Constructor constructor;
		
		public event PropertyEventHandler PropertySetValue;
		
		public event ParameterEventHandler MethodParameterSetValue;
		
		public event ParameterEventHandler ConstructorParameterSetValue;
		
		public bool HasConstructor {
			get { return constructor != null; }
		}
		
		public Constructor Constructor {
			get { return constructor; }
			set { constructor = value; }
		}
		
		[XmlElement("Method")] public Method[] Methods {
			get {
				if (methods == null) {
					return new Method[0];
				}
				return methods;
			}
			
			set {
				methods = value;
			}
		}
		
		[XmlElement("Property")] public Property[] Properties {
			get {
				if (properties == null) {
					return new Property[0];
				}
				return properties;
			}
			
			set {
				properties = value;
			}
		}
		
		[XmlAttribute("Type")] public string Type {
			get { return type; }
			set { type = value; }
		}
		
		[XmlAttribute("Id")] public string Id {
			get { return id; }
			set { id = value; }
		}
		
		public object Instantiate()
		{
			Type t = System.Type.GetType(type);
			if (t == null) {
				throw new Exception(string.Format("Type {0} not found", type));
			}
			object obj = InvokeConstructor(t);
			SetProperties(t, obj);
			InvokeMethods(t, obj);
			return obj;
		}
		
		public void AddProperty(Property property)
		{
			ArrayList p = new ArrayList(Properties);
			p.Add(property);
			properties = new Property[p.Count];
			p.CopyTo(properties);
		}
		
		public void AddMethod(Method method)
		{
			ArrayList m = new ArrayList(Methods);
			m.Add(method);
			methods = new Method[m.Count];
			m.CopyTo(methods);
		}
		
		protected virtual void OnConstructorParameterSetValue(ParameterEventArgs e)
		{
			if (ConstructorParameterSetValue != null) {
				ConstructorParameterSetValue(this, e);
			}
		}
		
		protected virtual void OnMethodParameterSetValue(ParameterEventArgs e)
		{
			if (MethodParameterSetValue != null) {
				MethodParameterSetValue(this, e);
			}
		}
		
		protected virtual void OnPropertySetValue(PropertyEventArgs e)
		{
			if (PropertySetValue != null) {
				PropertySetValue(this, e);
			}
		}
		
		object InvokeConstructor(Type t)
		{
			try {
				object obj = null;
				if (HasConstructor) {
					Type[] types = new Type[constructor.Parameters.Length];
					object[] parameters = new object[constructor.Parameters.Length];
					int j = 0;
					foreach (Parameter p in constructor.Parameters) {
						if (!p.HasReference) {
							types[j] = System.Type.GetType(p.Type);
							parameters[j] = p.GetValue();
						} else {
							OnConstructorParameterSetValue(new ParameterEventArgs(p));
							types[j] = p.ReferenceType;
							parameters[j] = p.ReferenceObject;
						}
						j++;
					}
					ConstructorInfo ci = t.GetConstructor(types);
					if (ci == null) {
						string sig = "";
						for (int k = 0; k < types.Length; k++) {
							sig += types[k].Name;
							sig += k < types.Length - 1 ? ", " : "";
						}
						throw new Exception(string.Format("Type '{0}' has no constructor with signature ({1})", t.Name, sig));
					}
					obj = ci.Invoke(parameters);
				} else {
					obj = Activator.CreateInstance(t);
				}
				return obj;
			} catch (TargetInvocationException ex) {
				throw ex.InnerException;
//Removed exception catch to be able to catch the FileNotFoundException in GenerateScriptRequestDispatcher Dispatch method.				
//			} catch (Exception ex) {
//				throw new Exception(string.Format("Error occurred: {0} in '{1}' type", ex.ToString(), t.Name));
			}
		}
		
		void InvokeMethods(Type t, object obj)
		{
			foreach (Method m in Methods) {
				object[] values = new object[m.Parameters.Length];
				Type[] types = new Type[m.Parameters.Length];
				int i = 0;
				foreach (Parameter p in m.Parameters) {
					if (!p.HasReference) {
						types[i] = System.Type.GetType(p.Type);
						if (types[i] == null) {
							throw new Exception(string.Format("Type '{0}' not found for method {1}", p.Type, m.Name));
						}
						values[i] = p.GetValue();
					} else {
						OnMethodParameterSetValue(new ParameterEventArgs(p));
						types[i] = p.ReferenceType;
						values[i] = p.ReferenceObject;
					}
					i++;
				}
				MethodInfo mi = t.GetMethod(m.Name, types);
				if (mi == null) {
					throw new Exception(string.Format("No method name '{0}' available.", m.Name));
				}
				mi.Invoke(obj, values);
			}
		}
		
		void SetProperties(Type t, object obj)
		{
			foreach (Property p in Properties) {
				PropertyInfo i = t.GetProperty(p.Name);
				if (i == null) {
					throw new Exception(string.Format("No property with name '{0}' in {1}", p.Name, t.Name));
				}
				if (!p.HasReference) {
					i.SetValue(obj, p.GetValue(), null);
				} else {
					OnPropertySetValue(new PropertyEventArgs(p));
					i.SetValue(obj, p.ReferenceValue, null);
				}
			}
		}
	}
	
	public class Constructor
	{
		Parameter[] parameters;
		
		[XmlElement("Parameter")] public Parameter[] Parameters {
			get {
				if (parameters == null) {
					return new Parameter[0];
				}
				return parameters;
			}
			
			set {
				parameters = value;
			}
		}
	}
}
