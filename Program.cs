using System;
using System.IO;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        {
            Console.Clear();

            Console.WriteLine("What do you want to do? ");
            Console.WriteLine("1 - Open Archive ");
            Console.WriteLine("2 - Create new archive ");
            Console.WriteLine("0 - Exit ");
            Console.WriteLine("--------------------------");
            Console.WriteLine("Select a option: ");
            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: Open(); break;
                case 2: Edit(); break;
                default: Menu(); break;
            }
        }
        static void Open()
        {
            Console.Clear();
            Console.WriteLine("Type the file path: ");
            string path = Console.ReadLine();

            using(var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine(text);
            }
            Console.WriteLine("");
            Console.WriteLine("-------------------------------------------------");

            Console.WriteLine("Press 'Enter' for back to menu.");
            Console.ReadLine();
            Menu();

        }
        static void Edit()
        {
            Console.Clear();

            Console.WriteLine("Type your text");
            Console.WriteLine("Press 'ESC' for stop.");
            Console.WriteLine("------------------");
            string text = "";

            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
            {
                Console.Write(text);
            }

            Save(text);
        }
        static void Save(string text)
        {
            Console.Clear();

            Console.WriteLine("Type the file path: ");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }

            Console.Clear();

            Console.WriteLine($"File {path} saved!");
            Console.WriteLine("Press 'Enter' for back to menu.");
            Console.ReadLine();
            Menu();
        }
    }
}