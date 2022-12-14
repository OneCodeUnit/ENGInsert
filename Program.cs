using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace ENGInsert
{
    internal class Program
    {
        internal static void Main()
        {
            string[] AllFiles = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.xml", SearchOption.AllDirectories);
            StringComparison Comparison = StringComparison.InvariantCultureIgnoreCase;
            foreach (string TempFile in AllFiles)
            {
                if (TempFile.EndsWith("loadfolders.xml", Comparison) || TempFile.EndsWith("about.xml", Comparison) || TempFile.EndsWith("patch.xml", Comparison) || TempFile.EndsWith("temp.xml"))
                {
                    Console.WriteLine(TempFile);
                    Console.WriteLine("Will not be processed");
                }
                else
                {
                    //Console.WriteLine(TempFile);
                    XMLProcessing(TempFile);
                    //Console.WriteLine("OK");
                }

            }
            Console.WriteLine("Work is completed");
            Console.ReadKey();
        }

        internal static void XMLProcessing(string CurrentFile)
        {
            XDocument xDoc = XDocument.Load(CurrentFile);
            if (xDoc.Element("LanguageData") is null)
            {
                Console.WriteLine("Could not find LanguageData");
                return;
            }
            XElement? root = xDoc.Element("LanguageData");

            XElement? lastnode = null;
            foreach (XElement node in root.Elements())
            {
                string content = node.Value.ToString();
                XRaw comment = new("\n  <!-- EN: " + content + " -->\n  ");
                node.AddBeforeSelf(comment);
                lastnode = node;
            }
            lastnode.AddAfterSelf("\n");

            xDoc.Save(CurrentFile);
        }

        public class XRaw : XText
        {
            public XRaw(string text) : base(text) { }
            public XRaw(XText text) : base(text) { }

            public override void WriteTo(XmlWriter writer)
            {
                writer.WriteRaw(this.Value);
            }
        }
    }
}