using System.IO;
using QuizApp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace QuizApp.Managers
{
    public class QuizManager
    {
        public List<Topic> topics { get; private set; }

        public QuizManager()
        {
            InitializeTopicsDirectory();
            LoadTopics();
        }

        private void InitializeTopicsDirectory()
        {
            string topicsDirectory = @".\Topics\";
            if (!Directory.Exists(topicsDirectory))
            {
                Directory.CreateDirectory(topicsDirectory);
                Topic defaultTopic = new Topic
                {
                    Name = "Default",
                    Questions = new Dictionary<string, List<string>>
                    {
                        { "Choose the biggest animal", new List<string> { "Elephant", "Hummingbird", "Cow" } },
                        { "Appear consequence difference in pressure - ?", new List<string> { "Wind", "Waves", "Rain", "Mirage" } }
                    },
                    QuestionCount = 2
                };
                SaveTopic(defaultTopic);
            }
        }

        private void LoadTopics()
        {
            topics = new List<Topic>();
            string topicsDirectory = @".\Topics\";

            if (Directory.Exists(topicsDirectory))
            {
                foreach (string file in Directory.GetFiles(topicsDirectory, "*.json"))
                {
                    using (StreamReader sr = new StreamReader(file))
                    {
                        string json = sr.ReadToEnd();
                        Topic topic = JsonConvert.DeserializeObject<Topic>(json);
                        topics.Add(topic);
                    }
                }
            }
        }

        public void SaveTopic(Topic topic)
        {
            string topicsDirectory = @".\Topics\";
            string filePath = Path.Combine(topicsDirectory, $"{topic.Name}.json");
            string json = JsonConvert.SerializeObject(topic, Formatting.Indented);
            using (StreamWriter sw = new StreamWriter(filePath)) sw.Write(json);
        }
    }
}
