using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Djn.Testing;

namespace Djn.Framework
{
	class NullTests
	{
		static void Main(string[] args) {
			Fest.Run();
			Console.ReadLine();
		}

		private static T FirstOrNull<T>(IEnumerable collection) where T : class {
			IEnumerator en = collection.GetEnumerator();
			if (en.MoveNext()) {
				return en.Current as T;
			}
			else {
				return null;
			}
		}

		private static T FirstOrDefault<T>(IEnumerable collection) where T : struct {
			IEnumerator en = collection.GetEnumerator();
			en.MoveNext();
			try {
				return (T)en.Current;
			}
			catch {
				return default(T);
			}
		}
		private static T FirstOrWhatever<T>(IEnumerable collection) {
			IEnumerator en = collection.GetEnumerator();
			en.MoveNext();
			try {
				return (T)en.Current;
			}
			catch {
				return default(T);
			}
		}

		[FestTest]
		public void TestDefault() {
			List<int> list = new List<int>();
			list.Add(1);
			list.Add(2);
			int first = FirstOrDefault<int>(list);
			Fest.AssertEqual<int>(1, first);
		}

		[FestTest]
		public void TestNull() {
			List<string> list = new List<string>();
			list.Add("one");
			list.Add("two");
			string first = FirstOrNull<string>(list);
			Fest.AssertEqual<string>("one", first);
		}

		[FestTest]
		public void TestCast() {
			List<string> list = new List<string>();
			list.Add("one");
			int first = FirstOrDefault<int>(list);
			Fest.AssertTrue(0 == first, "assertion failed - first is not null");
		}

		[FestTest]
		public void TestNullEmpty() {
			List<string> list = new List<string>();
			string first = FirstOrNull<string>(list);
			Fest.AssertTrue(null == first, "assertion failed - first is not null" );
		}

		[FestTest]
		public void TestArray() {
			string[] list = new string[2];
			list[0] = "one";
			list[1] = "two";
			string first = FirstOrNull<string>(list);
			Fest.AssertEqual<string>("one", first);
		}


		[FestTest]
		public void TestWhatever() {
			string[] list = new string[2];
			string first = FirstOrWhatever<string>(list);
			Fest.AssertTrue( null == first, "assertion failed - first is not null");
		}

	}
}
