//TODO: запитати про збереження кожного словника окремо перед виходом, список в якому буде зберігатись чи змінився словник чи ні, а ще заборонити створювати словники з однаковими іменами
// зберігати константні дані в константах
// добавити метод search перекладу по оригінальному слові
// метод search ориганільного слова по перекладу
// просто general search слова
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Dictionary
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var menu = new Menu();
            menu.Run();
        }
    }

    internal class Menu
    {
        private List<LangDictionary> dictionaries = new List<LangDictionary>();

        public void Run()
        {
            LoadDictionaries();

            while (true)
            {
                Console.WriteLine("1. Створити словник");
                Console.WriteLine("2. Подивитись словники");
                Console.WriteLine("3. Вийти");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        CreateDictionary();
                        break;
                    case "2":
                        ShowDictionaries();
                        break;
                    case "3":
                        SaveDictionaries();
                        return;
                }
            }
        }

        private void LoadDictionaries()
        {
            if (File.Exists("dictionaries.json"))
            {
                var json = File.ReadAllText("dictionaries.json");
                dictionaries = JsonConvert.DeserializeObject<List<LangDictionary>>(json);
            }
        }

        private void SaveDictionaries()
        {
            var json = JsonConvert.SerializeObject(dictionaries);
            File.WriteAllText("dictionaries.json", json);
        }

        private void CreateDictionary()
        {
            Console.WriteLine("Введіть назву словника (наприклад, Ukrainian-English):");
            var name = Console.ReadLine();
            var dictionary = new LangDictionary { DictName = name };
            dictionaries.Add(dictionary);
            Console.WriteLine("Словник успішно створено.");
        }

        private void ShowDictionaries()
        {
            Console.WriteLine("Список словників:");
            for (var i = 0; i < dictionaries.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {dictionaries[i].DictName}");
            }

            Console.WriteLine("Введіть номер словника, який хочете відкрити:");
            var choice = int.Parse(Console.ReadLine());
            var dictionary = dictionaries[choice - 1];
            dictionary.Run();
        }
    }

    internal class LangDictionary
    {
        public Dictionary<string, List<string>> Words { get; set; } = new Dictionary<string, List<string>>();
        public int WordsCount => Words.Count;
        public string DictName { get; set; }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("1. Подивитись слова в словнику");
                Console.WriteLine("2. Добавити слово");
                Console.WriteLine("3. Редагувати слово");
                Console.WriteLine("4. Видалити слово");
                Console.WriteLine("5. Зберегти словник");
                Console.WriteLine("6. Видалити словник");
                Console.WriteLine("7. Повернутись до головного меню");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ShowWords();
                        break;
                    case "2":
                        AddWord();
                        break;
                    case "3":
                        EditWord();
                        break;
                    case "4":
                        DeleteWord();
                        break;
                    case "5":
                        SaveDictionary();
                        break;
                    case "6":
                        DeleteDictionary();
                        break;
                    case "7":
                        return;
                }
            }
        }

        private void ShowWords()
        {
            Console.WriteLine("Список слів:");
            foreach (var word in Words)
            {
                Console.WriteLine($"{word.Key}: {string.Join(", ", word.Value)}");
            }
        }

        private void AddWord()
        {
            Console.WriteLine("Введіть слово:");
            var original = Console.ReadLine();
            Console.WriteLine("Введіть переклад:");
            var translation = Console.ReadLine();

            if (Words.ContainsKey(original))
            {
                Words[original].Add(translation);
            }
            else
            {
                Words[original] = new List<string> { translation };
            }

            Console.WriteLine("Слово успішно додано.");
        }

        private void EditWord()
        {
            Console.WriteLine("Введіть слово, яке хочете редагувати:");
            var original = Console.ReadLine();
            if (!Words.ContainsKey(original))
            {
                Console.WriteLine("Слово не знайдено.");
                return;
            }

            Console.WriteLine("Введіть новий переклад:");
            var translation = Console.ReadLine();
            Words[original].Add(translation);

            Console.WriteLine("Слово успішно змінено.");
        }

        private void DeleteWord()
        {
            Console.WriteLine("Введіть слово, яке хочете видалити:");
            var original = Console.ReadLine();
            if (!Words.ContainsKey(original))
            {
                Console.WriteLine("Слово не знайдено.");
                return;
            }

            Words.Remove(original);
            Console.WriteLine("Слово успішно видалено.");
        }

        private void SaveDictionary()
        {
            var json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText($"{DictName}.json", json);
            Console.WriteLine("Словник успішно збережено.");
        }

        private void DeleteDictionary()
        {
            if (File.Exists($"{DictName}.json"))
            {
                File.Delete($"{DictName}.json");
            }

            Console.WriteLine("Словник успішно видалено.");
        }
    }
}