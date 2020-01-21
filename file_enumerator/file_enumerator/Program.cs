using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Linq;
using System.Xml;

namespace file_enumerator {

	class File_Group_Ext {

		public string mEXT { get; set; }

		public long mSIZE { get; set; }

		public int mCOUNT { get; set; }

		public File_Group_Ext(string ext, long size, int count) {

			mEXT = ext;

			mSIZE = size;

			mCOUNT = count;
		}
	}

	class Create_XML_Report {

		private const string XML_PATH = "xml_content.xml";

		private const string XSL_PATH = "template.xsl";

		static readonly List<File_Group_Ext> fge_list = new List<File_Group_Ext>();

		static IEnumerable<string> EnumerateFilesRecursively(string path) {

			var queue = new Queue<string>();

			queue.Enqueue(path);

			while (queue.Count > 0) {

				path = queue.Dequeue();

				try {

					foreach (string sub in Directory.GetDirectories(path)) {
						
						queue.Enqueue(sub);
					}
				} catch (Exception e) {

					Console.Error.WriteLine(e);
				}

				string[] files = null;

				try {

					files = Directory.GetFiles(path);

				} catch (Exception e) {

					Console.Error.WriteLine(e);
				}

				if (files != null) {

					for (int i = 0; i < files.Length; i++) {

						yield return files[i];
					}
				}
			}
		}

		static string FormatByteSize(long byteSize) {

			string[] suffix = { "B", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB

			if (byteSize == 0)
				return "0" + suffix[0];

			var bytes = Math.Abs(byteSize);

			var place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));

			var num = Math.Round(bytes / Math.Pow(1024, place), 1);

			return (Math.Sign(byteSize) * num).ToString() + suffix[place];

		}

		static XDocument CreateReport(IEnumerable<string> files) {

			// creates fileGroups with the same extension 
			var group_by_ext = from f in files
									 group f by Path.GetExtension(f).ToLower() into fileGroup
									 orderby fileGroup.Key
									 select fileGroup;

			// for each fileGroup of extension
			foreach (var fileGroup in group_by_ext) {

				int current = 0;

				string ext_of_group = "";

				long total_size = 0;

				int total_count = 0;

				int loop_counter = 0;

				do {
					// inside each group of extensions, compute total documents, size of all data, 

					foreach (var f in fileGroup) {

						if (loop_counter == 0)
							ext_of_group = Path.GetExtension(f);

						long length = new System.IO.FileInfo(f).Length;

						total_size += length;

						total_count++;

						loop_counter++;

					}
					current++;

				} while (current < fileGroup.Count());

				var newFileGroup = new File_Group_Ext(ext_of_group, total_size, total_count);

				fge_list.Add(newFileGroup);

			}

			// add files to the xml
			var files_to_add = new XElement("files_directory",
													from f in fge_list
			                                orderby f.mSIZE descending
														select new XElement("files",
															new XElement("file_ext", f.mEXT),
															new XElement("count", f.mCOUNT),
															new XElement("total_size", FormatByteSize(f.mSIZE))));

			var doc = new XDocument();

			doc.Add(files_to_add);

			return doc;

		}

		static string TransformXMLtoHTML(string inputXml, string xsltString) {

			XslCompiledTransform transform = new XslCompiledTransform();

			using (XmlReader reader = XmlReader.Create(new StringReader(xsltString))) {

				transform.Load(reader);
			}

			StringWriter results = new StringWriter();

			using (XmlReader reader = XmlReader.Create(new StringReader(inputXml))) {

				transform.Transform(reader, null, results);
			}

			return results.ToString();
		}

		public static void Main(string[] args) {

			Console.WriteLine("Input the path to the input folder:");

			var input_path = Console.ReadLine();


			Console.WriteLine("Input the path AND the name of the html file (including '.html' at the end):");

			var html_path = Console.ReadLine();


			Console.WriteLine("Enumerating files...\n");

			var files = EnumerateFilesRecursively(input_path);


			Console.WriteLine("Creating XML report and saving to source folder...\n");

			var doc = CreateReport(files);

			doc.Save(XML_PATH);


			Console.WriteLine("Transforming XML into HTML...\n");

			var xslt = new XslCompiledTransform();

			xslt.Load(XSL_PATH);


			Console.WriteLine("Saving to path...\n");

			xslt.Transform(XML_PATH, html_path);


			Console.WriteLine("Complete. Press any key to stop...");

			Console.ReadKey();

		}

	}
}
