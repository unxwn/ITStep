using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Exam1
{
    internal class Menu
    {
        private const string DICTIONARIES_FILENAME = "dictionaries.json";
        private List<string> dictionaryNames = new List<string>();
        private List<LangDictionary> dictionaries = new List<LangDictionary>();
        private List<string> modifiedDictionaries = new List<string>();

        private readonly string[] patternMenu1 = { new string('*', 8), "Menu" };

        public Menu()
        {
            dictionaryNames = JsonConvert.DeserializeObject<List<string>>(FileUtils.LoadJson(DICTIONARIES_FILENAME));
            LoadDictionaries();
        }

        public void Run()
        {
            int choice = -1;

            while (choice != 4)
            {
                Console.Clear();
                Console.WriteLine($"\n{patternMenu1[0]}{patternMenu1[1]}{patternMenu1[0]}");
                Console.WriteLine("1. Create dictionary");
                Console.WriteLine("2. View dictionaries");
                Console.WriteLine("3. Delete dictionary");
                Console.WriteLine("4. Exit");
                Console.WriteLine(new string('-', 20) + "\n");

                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nWrite a number!");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        CreateDictionary();
                        break;
                    case 2:
                        ShowDictionaries();
                        break;
                    case 3:
                        DeleteDictionary();
                        break;
                    case 4:
                        PromptSaveModifiedDictionaries();
                        return;
                }

                if (choice != 4)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey(true);
                }
            }
        }

        private void LoadDictionaries()
        {
            foreach (string name in dictionaryNames)
            {
                try
                {
                    LangDictionary dictionary = JsonConvert.DeserializeObject<LangDictionary>(FileUtils.LoadJson(name));
                    if (dictionary != null)
                    {
                        dictionaries.Add(dictionary);
                    }
                    else { throw new NullReferenceException(); }
                }
                catch (FileNotFoundException ex) { Console.WriteLine($"Error: file {ex.FileName} not found."); }
                catch (NullReferenceException) { Console.WriteLine($"Dictionary \"{name}.json\" is empty."); }
            }
        }

        private void SaveDictionaryNames()
        {
            string json = JsonUtils.Serialize(dictionaryNames);
            FileUtils.SaveJson(DICTIONARIES_FILENAME, json);
        }

        private void PromptSaveModifiedDictionaries()
        {
            foreach (string dictName in modifiedDictionaries)
            {
                LangDictionary dictionary = dictionaries.FirstOrDefault(d => d.DictName == dictName);
                if (dictionary != null)
                {
                    Console.WriteLine($"\nSave changes to dictionary \"{dictName}\"? (y/n)");
                    string choice = Console.ReadLine();
                    if (choice.ToLower() == "y")
                    {
                        dictionary.SaveDictionary();
                    }
                }
            }
            SaveDictionaryNames();
        }

        private void CreateDictionary()
        {
            Console.WriteLine("\nEnter the name of the dictionary (e.g., Ukrainian-English):");
            string name = Console.ReadLine();

            if (dictionaries.Any(d => d.DictName == name))
            {
                Console.WriteLine("A dictionary with this name already exists.");
                return;
            }

            LangDictionary dictionary = new LangDictionary { DictName = name };
            dictionaries.Add(dictionary);
            dictionaryNames.Add(name);
            if (!modifiedDictionaries.Contains(name)) modifiedDictionaries.Add(name);
            Console.WriteLine("Dictionary successfully created.");
        }

        private void ShowDictionaries()
        {
            Console.WriteLine("\nList of dictionaries:");
            for (int i = 0; i < dictionaries.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {dictionaries[i].DictName}");
            }

            Console.WriteLine("Enter the number (0 to return):");
            int choice = 0;

            try
            {
                choice = int.Parse(Console.ReadLine());
                if (choice > 0 && choice <= dictionaries.Count)
                {
                    LangDictionary dictionary = dictionaries[choice - 1];
                    dictionary.Run(modifiedDictionaries);
                }
                else if (choice != 0)
                {
                    Console.WriteLine("\nWrite the correct number!");
                    ShowDictionaries();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\nWrite a number!");
                ShowDictionaries();
            }
        }

        private void DeleteDictionary()
        {
            Console.WriteLine("\nList of dictionaries:");
            for (int i = 0; i < dictionaries.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {dictionaries[i].DictName}");
            }

            Console.WriteLine("Enter the number of the dictionary you want to delete (0 to return):");
            int choice = int.Parse(Console.ReadLine());

            if (choice != 0)
            {
                LangDictionary dictionary = dictionaries[choice - 1];

                dictionaries.Remove(dictionary);
                dictionaryNames.Remove(dictionary.DictName);
                modifiedDictionaries.Remove(dictionary.DictName);

                string fileName = $"{dictionary.DictName}.json";
                FileUtils.Delete(fileName);

                Console.WriteLine("Dictionary successfully deleted.");
            }
        }
    }
}
