using System;
using System.Xml;
using System.Text;
using System.IO;
using System.Runtime.Serialization;

namespace Djn.Framework
{
	public class ContractSerializer
	{
		/**
		 * Serialization method that uses DataContractSerializer - we can't use ordinary 
		 * methods with CRM 2011 entities anymore.
		 * Note that I have not put the non-generic versions here like we had for the
		 * other ser. methods. I don't think they are necessary.
		 */
		public static void Serialize<T>( T in_obj, Stream in_stream, DataContractResolver in_resolver ) {
			Serialize( typeof( T ), in_obj, in_stream, in_resolver );
		}

		public static void Serialize( Type in_type, object in_obj, Stream in_stream, DataContractResolver in_resolver ) {
			DataContractSerializer serializer =
				new DataContractSerializer( in_type, null, int.MaxValue, false, false, null, in_resolver );
			XmlTextWriter writer = new XmlTextWriter( in_stream, Encoding.UTF8 ) {
				Formatting = Formatting.Indented
			};
			serializer.WriteObject( writer, in_obj );
			writer.Close();
		}

		public static T Deserialize<T>( Stream in_stream, DataContractResolver in_resolver ) {
			return ( T )Deserialize( typeof( T ), in_stream, in_resolver );
		}

		public static object Deserialize( Type in_type, Stream in_stream, DataContractResolver in_resolver ) {
			System.Runtime.Serialization.DataContractSerializer serializer =
				new System.Runtime.Serialization.DataContractSerializer( in_type, null, int.MaxValue, false, false, null, in_resolver );
			return serializer.ReadObject( in_stream );
		}

		public static T DeserializeFromDisk<T>( string in_filename, DataContractResolver in_resolver ) {
			FileStream fs = new FileStream( in_filename, FileMode.Open, FileAccess.Read );
			return Deserialize<T>( fs, in_resolver );
		}

		public static void SerializeToDisk<T>( T in_data, string in_filename, DataContractResolver in_resolver ) {
			FileStream fs = new FileStream( in_filename, FileMode.Create, FileAccess.Write );
			Serialize<T>( in_data, fs, in_resolver );
			fs.Close();
		}
	} // class
} // namespace
