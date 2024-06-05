using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

class Album
{
    public string Title { get; set; }
    public string Artist { get; set; }
    public int Year { get; set; }
    public string Duration { get; set; }
    public string RecordLabel { get; set; }

    public void InputAlbum()
    {
        Console.Write("Enter album title: ");
        Title = Console.ReadLine();

        Console.Write("Enter artist name: ");
        Artist = Console.ReadLine();

        Console.Write("Enter release year: ");
        Year = int.Parse(Console.ReadLine());

        Console.Write("Enter duration of the album (in format 'h:m:s'): ");
        Duration = Console.ReadLine();

        Console.Write("Enter record label: ");
        RecordLabel = Console.ReadLine();
    }

    public void DisplayAlbum()
    {
        Console.WriteLine($"Title: {Title}\nArtist: {Artist}\nYear: {Year}\nDuration: {Duration}\nRecord label: {RecordLabel}");
    }

    public void SaveSerializedAlbum(string filePath)
    {
        List<Album> list = LoadSerializedAlbums(filePath);
        list.Add(this);

        string json = JsonConvert.SerializeObject(list, Formatting.Indented);

        using (StreamWriter sw = new StreamWriter(filePath))
        {
            sw.Write(json);
        }
    }

    public static List<Album> LoadSerializedAlbums(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<Album>();
        }

        using (StreamReader sr = new StreamReader(filePath))
        {
            string json = sr.ReadToEnd();
            if (string.IsNullOrEmpty(json))
            {
                return new List<Album>();
            }

            try
            {
                return JsonConvert.DeserializeObject<List<Album>>(json);
            }
            catch (JsonException)
            {
                return new List<Album>();
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Album album1 = new Album();
        album1.InputAlbum();
        Console.WriteLine("\nAlbum Information:");
        album1.DisplayAlbum();

        album1.SaveSerializedAlbum("album.json");
        Console.WriteLine("Serialized album saved to 'album.json'");

        List<Album> loadedAlbum = Album.LoadSerializedAlbums("album.json");
        Console.WriteLine("\nLoaded Albums Information:");
        foreach (Album album in loadedAlbum)
        {
            album.DisplayAlbum();
            Console.WriteLine();
        }
    }
}
