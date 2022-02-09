﻿using System;
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
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1 - Open file");
            Console.WriteLine("2 - Edit file");
            Console.WriteLine("0 - Exit");

            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 1: Open();break;
                case 2: Edit();break;
                case 0: System.Environment.Exit(0);break;
                default: Menu(); break;

            }
        }

        static void Open() 
        {
            Console.Clear();
            Console.WriteLine("What's the file path?");
            string path = Console.ReadLine();

            using(var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }
            Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }

        static void Edit() 
        {
            Console.Clear();
            Console.WriteLine("Digit your text (Enter ESC for exit)");
            Console.WriteLine("--------------------------");
            string text = "";

            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

            Save(text);
        }

        static void Save(string text) 
        {
            Console.Clear();
            Console.WriteLine("which path to save?");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }

            Console.WriteLine($"File {path} has been saved");
            Console.ReadLine();
            Menu();
        }
    }
}
