using System;
using System.Reflection;

namespace Djn.Framework {
	public class Reflection {
		/**
		* Use reflection to set the value of one of our data objects
		*/
		public static void SetValue( object in_obj, string in_field, object in_val ) {
			in_obj.GetType().GetProperty(in_field).SetValue(in_obj, in_val, null);
		}
		public static object GetValue<T>(T in_obj, string in_field ) {
			return typeof(T).GetProperty(in_field).GetValue( in_obj, null );  
		}

		/**
		* Get the type of a class's method.
		*/
		public static Type GetPropertyType( Type in_type, string in_propertyName ) {
			PropertyInfo prop = in_type.GetProperty(in_propertyName);
			return prop.PropertyType;
		}

	}
}