using System;
using System.IO;

namespace Djn.Framework
{
	/**
	 * Helper class for dealing with .NET serialization
	 * TODO: move to another project
	 */
	public class Serializer
	{
		public static void Serialize( Type in_type, Object in_instance, Stream out_stream ) {
			System.Xml.Serialization.XmlSerializer xser = new System.Xml.Serialization.XmlSerializer( in_type );
			xser.Serialize( out_stream, in_instance );
		}

		public static object Deserialize( Type in_type, Stream in_stream ) {
			System.Xml.Serialization.XmlSerializer xser = new System.Xml.Serialization.XmlSerializer( in_type );
			return xser.Deserialize( in_stream );
		}
	}
}
