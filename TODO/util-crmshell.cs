using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Crm.Sdk;
using System.Xml;
using System.Text;
using System.IO;
using Microsoft.Xrm.Sdk;

/**
* This utility file came from the crmshell project. Need
* to get the Contract serializers into the djn project.
*/
namespace CrmShell
{
	public class Util
	{
		public Util() { }

		/**
		 * Serialization method that uses DataContractSerializer - we can't use ordinary 
		 * methods with CRM 2011 entities anymore.
		 */
		public static void SerializeToStream<T>( T in_obj, Stream in_stream ) {
			System.Runtime.Serialization.DataContractSerializer serializer =
				new System.Runtime.Serialization.DataContractSerializer( typeof( T ), null, int.MaxValue, false, false, null, new KnownTypesResolver() );
			XmlTextWriter writer = new XmlTextWriter( in_stream, Encoding.UTF8 ) {
				Formatting = Formatting.Indented
			};
			serializer.WriteObject( writer, in_obj );
			writer.Close();
		}

		public static T DeSerializeFromStream<T>( Stream in_stream ) {
			System.Runtime.Serialization.DataContractSerializer serializer =
				new System.Runtime.Serialization.DataContractSerializer( typeof( T ), null, int.MaxValue, false, false, null, new KnownTypesResolver() );
			return ( T )serializer.ReadObject( in_stream );
		}
		public static T DeSerializeFromDisk<T>( string in_filename ) {
			FileStream fs = new FileStream( in_filename, FileMode.Open, FileAccess.Read );
			return DeSerializeFromStream<T>( fs );
		}

		/**
		* Format an entity collection for tabular console output
		*/
		public static void PrintTabular( EntityCollection entitycollection ) {
			foreach( KeyValuePair<string, object> item in entitycollection.Entities.First().Attributes ) {
				Console.Write( "{0,10}", item.Key );
			}
			Console.WriteLine();
			foreach( Entity entity in entitycollection.Entities ) {
				PrintTabular( entity );
			}
		}
		public static void PrintTabular( Entity entity ) {
			foreach( KeyValuePair<string, object> item in entity.Attributes ) {
				Console.Write( "{0,10}", item.Value );
			}
			Console.WriteLine();
		}

		/**
		* Format an entity collection for console output as property list
		*/
		public static void PrintList( EntityCollection entitycollection ) {
			foreach( Entity entity in entitycollection.Entities ) {
				PrintList( entity );
			}
		}
		public static void PrintList( Entity entity ) {
			foreach( KeyValuePair<string, object> item in entity.Attributes ) {
				Console.WriteLine( "{0,15}: {1}", item.Key, item.Value );
			}
			Console.WriteLine();
		}

	}
}