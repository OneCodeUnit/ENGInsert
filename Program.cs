using System;
using System.IO;
using System.Xml;

namespace ENGInsert
{
    internal class Program
    {
        internal static int Main()
        {
            string[] allFiles = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.xml", SearchOption.AllDirectories);
            foreach (string tempFile in allFiles)
            {
                if (tempFile.EndsWith("loadfolders.xml", StringComparison.InvariantCultureIgnoreCase) || tempFile.EndsWith("about.xml", StringComparison.InvariantCultureIgnoreCase) || tempFile.EndsWith("patch.xml", StringComparison.InvariantCultureIgnoreCase) || tempFile.EndsWith("temp.xml"))
                {
                    Console.WriteLine(tempFile);
                    Console.WriteLine("Wrong File");
                }
                else
                {
                    Console.WriteLine(tempFile);
                    XMLProcessing(tempFile);
                }
                Console.WriteLine("Next");

            }
            Console.WriteLine("End of Files");
            return 0;
        }
        internal static void XMLProcessing(string currentFile)
        {
            XmlReaderSettings readerSettings = new();
            readerSettings.ConformanceLevel = ConformanceLevel.Fragment;
            readerSettings.IgnoreWhitespace = true;
            readerSettings.IgnoreComments = true;

            XmlReader xDoc = XmlReader.Create(currentFile, readerSettings);
            xDoc.MoveToContent();

            XmlWriterSettings writerSettings = new();
            writerSettings.Encoding.GetPreamble();
            writerSettings.Indent = true;
            writerSettings.NewLineOnAttributes = true;

            XmlWriter xNewDoc = XmlWriter.Create("temp.xml", writerSettings);
            xNewDoc.WriteStartElement("LanguageData");

            xDoc.Read();
            while (true)
            {
                if (xDoc.NodeType == XmlNodeType.Element)
                {
                    string content = xDoc.ReadInnerXml();

                    string name = xDoc.Name;
                    if (name == "LanguageData")
                    {
                        Console.WriteLine("End of text");
                        break;
                    }
                    xNewDoc.WriteString("\n");
                    xNewDoc.WriteString("  ");
                    xNewDoc.WriteComment(" EN: " + content + " ");
                    xNewDoc.WriteString("\n");
                    xNewDoc.WriteString("  ");
                    xNewDoc.WriteElementString(name, content);

                }
                else
                {
                    xNewDoc.WriteString("\n");
                }

            }
            xDoc.Dispose();
            xDoc.Close();
            xNewDoc.WriteString("\n");
            xNewDoc.WriteEndElement();
            xNewDoc.Flush();
            xNewDoc.Close();
            File.Delete(currentFile);
            File.Move("temp.xml", currentFile);
        }
    }
}