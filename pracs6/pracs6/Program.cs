using System;
using System.IO;
using Newtonsoft.Json;
using System.Xml.Serialization;


namespace TextConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь к файлу:");
            string filePath = Console.ReadLine();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл не существует.");
                return;
            }

            string extension = Path.GetExtension(filePath);

            switch (extension)
            {
                case ".txt":
                    ReadTextFile(filePath);
                    break;
                case ".json":
                    ReadJsonFile(filePath);
                    break;
                case ".xml":
                    ReadXmlFile(filePath);
                    break;
                default:
                    Console.WriteLine("Формат файла не поддерживается.");
                    return;
            }

            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.F1)
                {
                    SaveFile(filePath);
                }
            } while (keyInfo.Key != ConsoleKey.Escape);
        }

        private static void ReadTextFile(string filePath)
        {
            Console.WriteLine("Чтение текстового файла...");
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }

        private static void ReadJsonFile(string filePath)
        {
            Console.WriteLine("Чтение файла JSON...");
            string json = File.ReadAllText(filePath);
            dynamic data = JsonConvert.DeserializeObject(json);
            foreach (var item in data)
            {
                Console.WriteLine(item.Name + ": " + item.Value);
            }
        }

        private static void ReadXmlFile(string filePath)
        {
            Console.WriteLine("Чтение XML-файла...");
            var serializer = new XmlSerializer(typeof(decimal));
            using (var reader = new StreamReader(filePath))
            {
                dynamic data = (dynamic)serializer.Deserialize(reader);
                foreach (var item in data)
                {
                    Console.WriteLine(item.Name + ": " + item.Value);
                }
            }
        }

        private static void SaveFile(string filePath)
        {
            Console.WriteLine("Сохранение файла...");
            string extension = Path.GetExtension(filePath);

            switch (extension)
            {
                case ".txt":
                    // logic for saving text file
                    break;
                case ".json":
                    // logic for saving json file
                    break;
                case ".xml":
                    // logic for saving xml file
                    break;
                default:
                    Console.WriteLine("Формат файла не поддерживается.");
                    return;
            }
        }
    }
}