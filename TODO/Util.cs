using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Text;

/**
* This file is from the spreedly project.
* I had to do a special addition to prevent the xml
* namespace declarations from appearing in the output.
*/
namespace Spreedly
{
	public class Util
	{
		public static T Deserialize<T>( Stream stream ) {
			XmlSerializer serializer = new XmlSerializer( typeof( T ) );
			return ( T )serializer.Deserialize( stream );
		}
		public static T DeserializeFromString<T>( string in_str ) {
			MemoryStream ms = new MemoryStream( Encoding.UTF8.GetBytes( in_str ) );
			ms.Seek( 0, SeekOrigin.Begin );
			return Deserialize<T>( ms );
		}

		public static void Serialize<T>( T obj, Stream stream ) {
			XmlSerializer serializer = new XmlSerializer( typeof( T ) );
			serializer.Serialize(
				stream,
				obj,
				new XmlSerializerNamespaces(
					new XmlQualifiedName[] { 
					new XmlQualifiedName( "", "" ) 
				}
				)
			 );
		}

		/**
		 * Convenience method for testing. Wrap serializer
		 * in memorystream, returning string
		 */
		public static string SerializeToString<T>( T obj ) {
			MemoryStream ms = new MemoryStream();
			
			Serialize<T>( obj, ms );
			StreamReader sr = new StreamReader( ms );
			ms.Seek( 0, SeekOrigin.Begin );
			return sr.ReadToEnd();
		}
	}
}
