using System;
using System.IO;
using System.Xml.Linq;

namespace ENGInsert
{
    internal class Program
    {
        static int ProcessedCount = 0;
        static int SkipCount = 0;

        internal static void Main()
        {
            string[] AllFiles = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.xml", SearchOption.AllDirectories);
            
            foreach (string TempFile in AllFiles)
            {
                XMLProcessing(TempFile);
                ProcessedCount++;
            }

            Console.WriteLine("Work is completed");
            Console.WriteLine("Processed " + ProcessedCount + ". Skipped " + SkipCount);
            Console.ReadKey();
        }

        internal static void XMLProcessing(string CurrentFile)
        {
            try
            {
                XDocument.Load(CurrentFile, LoadOptions.PreserveWhitespace);
            }
            catch
            {
                Console.WriteLine(CurrentFile);
                Console.WriteLine("Could not load this file\n");
                ProcessedCount--;
                SkipCount++;
                return;
            }

            XDocument xDoc = XDocument.Load(CurrentFile, LoadOptions.PreserveWhitespace);
            if (xDoc.Element("LanguageData") is null)
            {
                Console.WriteLine(CurrentFile);
                Console.WriteLine("Could not find LanguageData\n");
                ProcessedCount--;
                SkipCount++;
                return;
            }
            XElement root = xDoc.Element("LanguageData");

            foreach (XElement node in root.Elements())
            {
                string content = node.Value;
                XRaw comment = new("<!-- EN: " + content + " -->\n  ");
                node.AddBeforeSelf(comment);
            }
            root.LastNode?.AddAfterSelf("\n");

            xDoc.Save(CurrentFile);
        }
    }
}