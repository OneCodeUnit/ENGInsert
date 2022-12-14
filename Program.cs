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
            //Получение списка всех файлов в текущей директории и во всех вложенных подпапках за счёт SearchOption
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
            //Позволяет избежать падения при загрузке сломанного .xml файла
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
            //Позволяет избежать обработки пустого или не содержащего нужных тегов файла
            if (xDoc.Element("LanguageData") is null)
            {
                Console.WriteLine(CurrentFile);
                Console.WriteLine("Could not find LanguageData\n");
                ProcessedCount--;
                SkipCount++;
                return;
            }
            //Перевод контекста в содержимое тега LanguageData
            XElement root = xDoc.Element("LanguageData");

            foreach (XElement node in root.Elements())
            {
                //Получение содержимого текущего тега
                string content = node.Value;
                //Создание комментария с ним
                XRaw comment = new("<!-- EN: " + content + " -->\n  ");
                //Добавление этого комментария перед текущим тегом
                node.AddBeforeSelf(comment);
            }
            //Перенос строки перед закрывающим тегом LanguageData
            root.LastNode?.AddAfterSelf("\n");

            xDoc.Save(CurrentFile);
        }
    }
}