using Newtonsoft.Json;
using System.IO;

namespace Exam1
{
    internal class FileUtils
    {
        static public string LoadJson(string name)
        {
            string fileName = name.EndsWith(".json") ? name : $"{name}.json";
            if (File.Exists(fileName))
            {
                using (StreamReader rd = new StreamReader(fileName))
                {
                    string json = rd.ReadToEnd();
                    return json;
                }
            }
            else { throw new FileNotFoundException("File not found", fileName); }
        }

        static public void SaveJson(string name, string json)
        {
            string fileName = name.EndsWith(".json") ? name : $"{name}.json";

            using (StreamWriter wr = new StreamWriter(fileName))
            {
                wr.Write(json);
            }
        }
    }
}
