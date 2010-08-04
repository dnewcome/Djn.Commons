using System;
using System.IO;
using System.Xml;


namespace Djn.Framework
{
	/**
	 * Helper class for dealing with .NET serialization
	 */
	public class Serializer
	{
		public static void Serialize( Type in_type, Object in_instance, Stream out_stream ) {
			System.Xml.Serialization.XmlSerializer xser = new System.Xml.Serialization.XmlSerializer( in_type );
			xser.Serialize( out_stream, in_instance );
		}

		public static void Serialize<T>( object in_instance, Stream out_stream ) {
			Serialize( typeof( T ), in_instance, out_stream );
		}

		public static object Deserialize( Type in_type, Stream in_stream ) {
			System.Xml.Serialization.XmlSerializer xser = new System.Xml.Serialization.XmlSerializer( in_type );
			return xser.Deserialize( in_stream );
		}

		public static object Deserialize<T>( Stream in_stream ) {
			return Deserialize( typeof( T ), in_stream );
		}

		public void SerializeToDisk( Type in_type, object in_data, string in_filename ) {
			FileStream fs = new FileStream( in_filename, FileMode.Create, FileAccess.Write );
			Serializer.Serialize( in_type, in_data, fs );
			fs.Close();
		}

		public T DeserializeFromDisk<T>( Type in_type, string in_filename ) {
			FileStream fs = new FileStream( in_filename, FileMode.Open, FileAccess.Read );
			T data = ( T )Serializer.Deserialize( in_type, fs );
			fs.Close();
			return data;
		}
	}
}
