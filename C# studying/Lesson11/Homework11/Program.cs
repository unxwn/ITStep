using System;
using System.IO;

class Moderator
{
    public void Moderate(string textFilePath, string wordsFilePath)
    {
        string[] moderationWords;
        using (StreamReader sr = new StreamReader(wordsFilePath))
        {
            string words = sr.ReadToEnd();
            moderationWords = words.Split(new char[] { ' ' }, StringSplitOptions.None);
        }

        string text;
        using (StreamReader sr = new StreamReader(textFilePath))
        {
            text = sr.ReadToEnd();
        }

        foreach (string word in moderationWords)
        {
            text = text.Replace(word, new string('*', word.Length));
        }

        using (StreamWriter sw = new StreamWriter(textFilePath))
        {
            sw.Write(text);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        string textFilePath = "text.txt", wordsFilePath = "words.txt";

        string[] moderationWords;
        using (StreamReader sr = new StreamReader(wordsFilePath))
        {
            string words = sr.ReadToEnd();
            moderationWords = words.Split(new char[] { ' ' }, StringSplitOptions.None);
        }

        string text;
        using (StreamReader sr = new StreamReader(textFilePath))
        {
            text = sr.ReadToEnd();
        }

        foreach (string word in moderationWords)
        {
            text = text.Replace(word, new string('*', word.Length));
        }

        Console.WriteLine(text);

        using (StreamWriter sw = new StreamWriter(textFilePath))
        {
            sw.Write(text);
        }
    }
}
