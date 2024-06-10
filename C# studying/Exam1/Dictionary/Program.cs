using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Exam1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Run();
        }
    }

    internal class Menu
    {
        private const string DICTIONARIES_FILE = "dictionaries.json";
        private List<string> dictionaryNames = new List<string>();
        private List<LangDictionary> dictionaries = new List<LangDictionary>();
        private Dictionary<string, bool> modifiedDictionaries = new Dictionary<string, bool>();

        private readonly string[] patternMenu1 = { new string('*', 8), "Menu", new string('*', 8) };

        public void Run()
        {
            LoadDictionaryNames();
            LoadDictionaries();

            while (true)
            {
                Console.WriteLine($"\n{patternMenu1[0]}{patternMenu1[1]}{patternMenu1[0]}");
                Console.WriteLine("1. Create dictionary");
                Console.WriteLine("2. View dictionaries");
                Console.WriteLine("3. Delete dictionary");
                Console.WriteLine("4. Exit");
                Console.WriteLine(new string('-', 20) + "\n");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        CreateDictionary();
                        break;
                    case "2":
                        ShowDictionaries();
                        break;
                    case "3":
                        DeleteDictionary();
                        break;
                    case "4":
                        PromptSaveModifiedDictionaries();
                        return;
                }
            }
        }

        private void LoadDictionaryNames()
        {
            if (File.Exists(DICTIONARIES_FILE))
            {
                using (StreamReader reader = new StreamReader(DICTIONARIES_FILE, System.Text.Encoding.UTF8))
                {
                    string json = reader.ReadToEnd();
                    dictionaryNames = JsonConvert.DeserializeObject<List<string>>(json);
                }
            }
        }

        private void LoadDictionaries()
        {
            foreach (var name in dictionaryNames)
            {
                LangDictionary dictionary = LoadDictionary(name);
                if (dictionary != null)
                {
                    dictionaries.Add(dictionary);
                }
            }
        }

        private LangDictionary LoadDictionary(string name)
        {
            string fileName = $"{name}.json";
            if (File.Exists(fileName))
            {   
                using (StreamReader reader = new StreamReader(fileName, System.Text.Encoding.UTF8))
                {
                    string json = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<LangDictionary>(json);
                }
            }
            return null;
        }

        private void SaveDictionaryNames()
        {
            string json = JsonConvert.SerializeObject(dictionaryNames, Formatting.Indented);
            using (StreamWriter writer = new StreamWriter(DICTIONARIES_FILE, false, System.Text.Encoding.UTF8))
            {
                writer.Write(json);
            }
        }

        private void PromptSaveModifiedDictionaries()
        {
            foreach (var dictName in modifiedDictionaries.Where(x => x.Value))
            {
                LangDictionary dictionary = dictionaries.FirstOrDefault(d => d.DictName == dictName.Key);
                if (dictionary != null)
                {
                    Console.WriteLine($"\nSave changes to dictionary {dictName.Key}? (y/n)");
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
            modifiedDictionaries[name] = true;
            Console.WriteLine("Dictionary successfully created.");
        }

        private void ShowDictionaries()
        {
            Console.WriteLine("\nList of dictionaries:");
            for (int i = 0; i < dictionaries.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {dictionaries[i].DictName}");
            }

            Console.WriteLine("Enter the number of the dictionary you want to open:");
            int choice = int.Parse(Console.ReadLine());
            LangDictionary dictionary = dictionaries[choice - 1];
            dictionary.Run(modifiedDictionaries);
        }

        private void DeleteDictionary()
        {
            Console.WriteLine("\nList of dictionaries:");
            for (int i = 0; i < dictionaries.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {dictionaries[i].DictName}");
            }

            Console.WriteLine("Enter the number of the dictionary you want to open:");
            int choice = int.Parse(Console.ReadLine());
            LangDictionary dictionary = dictionaries[choice - 1];

            string name = dictionary.DictName;
            dictionaries.Remove(dictionary);
            dictionaryNames.Remove(name);
            modifiedDictionaries.Remove(name);

            string fileName = $"{name}.json";
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            Console.WriteLine("Dictionary successfully deleted.");
        }
    }

    internal class LangDictionary
    {
        public string DictName { get; set; }
        public Dictionary<string, List<string>> Words { get; set; } = new Dictionary<string, List<string>>();
        public int WordsCount => Words.Count;

        private readonly string[] patternMenu2 = { new string('*', 17), "Menu", new string('*', 17) };

        public void Run(Dictionary<string, bool> modifiedDictionaries)
        {
            string choice;

            while (true)
            {
                Console.WriteLine($"\n{patternMenu2[0]}{patternMenu2[1]}{patternMenu2[0]}");
                Console.WriteLine("1. View words in dictionary");
                Console.WriteLine("2. Add word");
                Console.WriteLine("3. Edit word");
                Console.WriteLine("4. Delete word");
                Console.WriteLine("5. Search translation by original word");
                Console.WriteLine("6. Search original word by translation");
                Console.WriteLine("7. Save dictionary");
                Console.WriteLine("8. Return to main menu");
                Console.WriteLine(new string('_', 38) + "\n");

                Console.Write("Make your choice: ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowWords();
                        break;
                    case "2":
                        AddWord(modifiedDictionaries);
                        break;
                    case "3":
                        EditWord(modifiedDictionaries);
                        break;
                    case "4":
                        DeleteWord(modifiedDictionaries);
                        break;
                    case "5":
                        SearchTranslation();
                        break;
                    case "6":
                        SearchOriginal();
                        break;
                    case "7":
                        SaveDictionary();
                        modifiedDictionaries[DictName] = false;
                        break;
                    case "8":
                        return;
                }
            }
        }

        private void ShowWords()
        {
            Console.WriteLine("\nList of words:");
            foreach (var word in Words)
            {
                Console.WriteLine($"{word.Key}: {string.Join(", ", word.Value)}");
            }
        }

        private void AddWord(Dictionary<string, bool> modifiedDictionaries)
        {
            Console.WriteLine("\nEnter the word:");
            string original = Console.ReadLine();
            Console.WriteLine("Enter the translation:");
            string translation = Console.ReadLine();

            if (Words.ContainsKey(original))
            {
                Words[original].Add(translation);
            }
            else
            {
                Words[original] = new List<string> { translation };
            }

            modifiedDictionaries[DictName] = true;
            Console.WriteLine("Word successfully added.");
        }

        private void EditWord(Dictionary<string, bool> modifiedDictionaries)
        {
            Console.WriteLine("\nEnter the word you want to edit:");
            string original = Console.ReadLine();
            if (!Words.ContainsKey(original))
            {
                Console.WriteLine("Word not found.");
                return;
            }

            Console.WriteLine("Enter the new translation:");
            string translation = Console.ReadLine();
            Words[original].Add(translation);

            modifiedDictionaries[DictName] = true;
            Console.WriteLine("Word successfully edited.");
        }

        private void DeleteWord(Dictionary<string, bool> modifiedDictionaries)
        {
            Console.WriteLine("\nEnter the word you want to delete:");
            string original = Console.ReadLine();
            if (!Words.ContainsKey(original))
            {
                Console.WriteLine("Word not found.");
                return;
            }

            Words.Remove(original);
            modifiedDictionaries[DictName] = true;
            Console.WriteLine("Word successfully deleted.");
        }

        private void SearchTranslation()
        {
            Console.WriteLine("\nEnter the original word to search:");
            string original = Console.ReadLine();

            if (Words.ContainsKey(original))
            {
                Console.WriteLine($"Translations for {original}: {string.Join(", ", Words[original])}");
            }
            else
            {
                Console.WriteLine("Word not found.");
            }
        }

        private void SearchOriginal()
        {
            Console.WriteLine("\nEnter the translation to search:");
            string translation = Console.ReadLine();

            List<string> originals = Words.Where(pair => pair.Value.Contains(translation))
                                          .Select(pair => pair.Key)
                                          .ToList();

            if (originals.Count > 0)
            {
                Console.WriteLine($"Original words for {translation}: {string.Join(", ", originals)}");
            }
            else
            {
                Console.WriteLine("Translation not found.");
            }
        }

        public void SaveDictionary()
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            using (StreamWriter writer = new StreamWriter($"{DictName}.json", false, System.Text.Encoding.UTF8))
            {
                writer.Write(json);
            }
            Console.WriteLine("Dictionary successfully saved.");
        }
    }
}
