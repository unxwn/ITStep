using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam1
{
    internal class LangDictionary
    {
        public string DictName { get; set; }
        public Dictionary<string, List<string>> Words { get; set; } = new Dictionary<string, List<string>>();
        public int WordsCount => Words.Count;

        private readonly string[] patternMenu2 = { new string('*', 17), "Menu", new string('*', 17) };

        public void Run(List<string> modifiedDictionaries)
        {
            int choice = -1;

            while (choice != 8)
            {
                Console.Clear();
                Console.WriteLine($"\n{patternMenu2[0]}{patternMenu2[1]}{patternMenu2[0]}");
                Console.WriteLine($"Dictionary: {DictName}");
                Console.WriteLine("1. View words in dictionary");
                Console.WriteLine("2. Add word");
                Console.WriteLine("3. Add new translation");
                Console.WriteLine("4. Delete word");
                Console.WriteLine("5. Delete translation");
                Console.WriteLine("6. Search translation by original word");
                Console.WriteLine("7. Search original word by translation");
                Console.WriteLine("8. Return to main menu");
                Console.WriteLine(new string('-', 38) + "\n");

                Console.Write("Make your choice: ");
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
                        ShowWords();
                        break;
                    case 2:
                        AddWord(modifiedDictionaries);
                        break;
                    case 3:
                        AddTranslation(modifiedDictionaries);
                        break;
                    case 4:
                        DeleteWord(modifiedDictionaries);
                        break;
                    case 5:
                        DeleteTranslation(modifiedDictionaries);
                        break;
                    case 6:
                        SearchTranslation();
                        break;
                    case 7:
                        SearchOriginal();
                        break;
                }

                if (choice != 8)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey(true);
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

        private void AddWord(List<string> modifiedDictionaries)
        {
            Console.WriteLine("\nEnter the word:");
            string input = Console.ReadLine();
            string original = char.ToUpper(input[0]) + input.Substring(1);
            Console.WriteLine("Enter the translation:");
            string translation = Console.ReadLine();

            if (Words.ContainsKey(original))
            {
                if (Words[original].Contains(translation))
                {
                    Console.WriteLine("This translation already exists for the original word.");
                    return;
                }
                Words[original].Add(translation);
            }
            else
            {
                Words[original] = new List<string> { translation };
            }

            if (!modifiedDictionaries.Contains(DictName)) modifiedDictionaries.Add(DictName);
            Console.WriteLine("Word successfully added.");
        }

        private void AddTranslation(List<string> modifiedDictionaries)
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

            if (!modifiedDictionaries.Contains(DictName)) modifiedDictionaries.Add(DictName);
            Console.WriteLine("Word successfully edited.");
        }

        private void DeleteWord(List<string> modifiedDictionaries)
        {
            bool contain = false;
            Console.WriteLine("\nEnter the word you want to delete:");
            string original = Console.ReadLine().ToUpper();
            foreach (var keyValuePair in Words)
            {
                if (keyValuePair.Key.ToUpper() == original)
                {
                    contain = true;
                    break;
                }
            }
            if (!contain)
            {
                Console.WriteLine("Word not found.");
                return;
            }

            Words.Remove(original[0] + original.Substring(1).ToLower());
            if (!modifiedDictionaries.Contains(DictName)) modifiedDictionaries.Add(DictName);
            Console.WriteLine("Word successfully deleted.");
        }

        public void DeleteTranslation(List<string> modifiedDictionaries)
        {
            bool contain = false;
            Console.WriteLine("\nEnter the original word:");
            string input = Console.ReadLine();
            string key = input.ToUpper();
            foreach (var keyValuePair in Words)
            {
                if (keyValuePair.Key.ToUpper() == key)
                {
                    contain = true;
                    break;
                }
            }
            if (!contain)
            {
                Console.WriteLine("Word not found.");
                return;
            }

            Console.WriteLine("Enter the translation to delete:");
            string translation = Console.ReadLine();

            bool attemp = Words[key[0] + key.Substring(1).ToLower()].Remove(translation);
            if (!attemp) attemp = Words[key[0] + key.Substring(1).ToLower()].Remove(translation.ToUpper());
            if (!attemp) attemp = Words[key[0] + key.Substring(1).ToLower()].Remove(translation.ToLower());

            if (attemp)
            {
                if (!modifiedDictionaries.Contains(DictName)) modifiedDictionaries.Add(DictName);
                Console.WriteLine("Translation successfully deleted.");
            }
            else { Console.WriteLine("Write correct translation word!"); }
        }

        private void SearchTranslation()
        {
            Console.WriteLine("\nEnter the original word to search:");
            string original = Console.ReadLine().ToLower();

            var match = Words.FirstOrDefault(pair => pair.Key.Equals(original, StringComparison.OrdinalIgnoreCase)).Key;

            if (match != null)
            {
                Console.WriteLine($"Translations for {original}: {String.Join(", ", Words[match])}");
            }
            else
            {
                Console.WriteLine("Word not found.");
            }
        }

        private void SearchOriginal()
        {
            Console.WriteLine("\nEnter the translation to search:");
            string translation = Console.ReadLine().ToLower();

            List<string> originals = Words.Where(pair => pair.Value.Any(t => t.Equals(translation, StringComparison.OrdinalIgnoreCase)))
                                          .Select(pair => pair.Key)
                                          .ToList();

            if (originals.Count > 0)
            {
                Console.WriteLine($"Original words for {translation}: {String.Join(", ", originals)}");
            }
            else
            {
                Console.WriteLine("Translation not found.");
            }
        }

        public void SaveDictionary()
        {
            string json = JsonUtils.Serialize(this);
            FileUtils.SaveJson(DictName, json);
            Console.WriteLine("\nDictionary successfully saved.");
        }
    }
}
