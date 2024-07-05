using System;
using System.Linq;
using QuizApp.Data;
using QuizApp.Models;
using QuizApp.Managers;
using System.Collections.Generic;

namespace QuizApp
{
    internal class App
    {
        static void Main(string[] args)
        {
            using (QuizContext context = new QuizContext())
            {
                context.Database.Initialize(true);

                QuizManager quizManager = new QuizManager();
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("1. Log in");
                    Console.WriteLine("2. Create new user");
                    string choice = Console.ReadLine();

                    if (choice == "1")
                    {
                        Console.Write("Enter login: ");
                        string login = Console.ReadLine();
                        Console.Write("Enter password: ");
                        string password = Console.ReadLine();

                        User user = context.Users.SingleOrDefault(u => u.Login == login && u.Password == password);
                        if (user != null)
                        {
                            UserMenu(user, quizManager, context);
                        }
                        else
                        {
                            Console.WriteLine("Invalid login or password.");
                            Console.ReadKey();
                        }
                    }
                    else if (choice == "2")
                    {
                        string login;
                        while (true)
                        {
                            Console.Write("Enter login: ");
                            login = Console.ReadLine();
                            if (context.Users.Any(u => u.Login == login))
                            {
                                Console.WriteLine("User with this login already exists. Please choose another login.");
                            }
                            else
                            {
                                break;
                            }
                        }

                        string password;
                        while (true)
                        {
                            Console.Write("Enter password (4 or more characters): ");
                            password = Console.ReadLine();
                            if (password.Length < 4)
                            {
                                Console.WriteLine("Password must be 4 or more characters.");
                            }
                            else
                            {
                                break;
                            }
                        }

                        Console.Write("Enter birth date (yyyy-mm-dd): ");
                        DateTime birthDate;
                        while (!DateTime.TryParse(Console.ReadLine(), out birthDate))
                        {
                            Console.Write("Invalid date format. Enter birth date (yyyy-mm-dd): ");
                        }

                        User user = new User { Login = login, Password = password, BirthDate = birthDate };
                        context.Users.Add(user);
                        context.SaveChanges();
                        Console.WriteLine("User created successfully.");
                        Console.ReadKey();
                    }
                }
            }
        }

        private static void UserMenu(User user, QuizManager quizManager, QuizContext context)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Start new quiz");
                Console.WriteLine("2. Show results");
                Console.WriteLine("3. Change settings");
                Console.WriteLine("4. Show leaderboard");
                Console.WriteLine("5. Log out");
                if (user.Login == "admin") Console.WriteLine("66. Clear database");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    CreateNewQuiz(quizManager, context, user);
                }
                else if (choice == "2")
                {
                    ShowResults(context, user);
                }
                else if (choice == "3")
                {
                    ChangeSettings(context, user);
                }
                else if (choice == "4")
                {
                    ShowLeaderboard(quizManager, context);
                }
                else if (choice == "5")
                {
                    break;
                }
                else if (choice == "66")
                {
                    if (user.Login == "admin")
                    {
                        context.ClearData();
                        Console.WriteLine("Database cleared.");
                        Console.WriteLine("Bye-bye!");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You don't have permission!");
                    }
                    Console.ReadKey();
                }
            }
        }

        private static void CreateNewQuiz(QuizManager quizManager, QuizContext context, User user)
        {
            Console.Clear();
            Console.WriteLine("1. Create mixed quiz");
            for (int i = 0; i < quizManager.topics.Count; i++)
            {
                Console.WriteLine($"{i + 2}. {quizManager.topics[i].Name}");
            }
            int quizChoice;
            while (!int.TryParse(Console.ReadLine(), out quizChoice) || quizChoice < 1 || quizChoice > quizManager.topics.Count + 1)
            {
                Console.WriteLine("Invalid choice. Please select a valid option.");
            }

            List<KeyValuePair<string, List<string>>> questions;
            if (quizChoice == 1)
            {
                Console.Write("Enter the number of questions: ");
                int questionCount;
                while (!int.TryParse(Console.ReadLine(), out questionCount) || questionCount < 1)
                {
                    Console.WriteLine("Invalid number. Please enter a positive integer.");
                }
                questions = GetMixedQuestions(quizManager, questionCount);
            }
            else
            {
                Topic topic = quizManager.topics[quizChoice - 2];
                questions = topic.Questions.OrderBy(x => new Random().Next()).Take(topic.QuestionCount).ToList();
            }

            Random random = new Random();
            int score = 0;
            DateTime startTime = DateTime.Now;

            for (int i = 0; i < questions.Count; i++)
            {
                var question = questions[i];
                Console.WriteLine($"Question {i + 1}: {question.Key}");
                List<string> answers = question.Value.OrderBy(x => random.Next()).ToList();
                for (int j = 0; j < answers.Count; j++)
                {
                    Console.WriteLine($"{j + 1}. {answers[j]}");
                }
                int answerChoice;
                while (!int.TryParse(Console.ReadLine(), out answerChoice) || answerChoice < 1 || answerChoice > answers.Count)
                {
                    Console.WriteLine("Invalid choice. Please select a valid answer.");
                }
                if (answers[answerChoice - 1] == question.Value[0])
                {
                    score++;
                    Console.WriteLine("Correct!");
                }
                else
                {
                    Console.WriteLine("Incorrect.");
                }
            }

            DateTime endTime = DateTime.Now;
            var duration = endTime - startTime;

            QuizResult quizResult = new QuizResult
            {
                UserId = user.UserId,
                Topic = quizChoice == 1 ? "Mixed" : quizManager.topics[quizChoice - 2].Name,
                Score = $"{score}/{questions.Count}",
                DateTaken = DateTime.Now,
                Duration = duration
            };

            context.QuizResults.Add(quizResult);
            context.SaveChanges();

            List<QuizResult> allResults = context.QuizResults
                .Where(r => r.Topic == quizResult.Topic)
                .OrderByDescending(r => r.Score)
                .ThenBy(r => r.Duration)
                .Take(20).ToList();

            int userRank = allResults.FindIndex(r => r.QuizResultId == quizResult.QuizResultId) + 1;

            Console.WriteLine($"You scored {score} out of {questions.Count}. Time taken: {duration.TotalSeconds} seconds. Your rank: {userRank}");
            Console.ReadKey();
        }

        private static List<KeyValuePair<string, List<string>>> GetMixedQuestions(QuizManager quizManager, int questionCount)
        {
            List<KeyValuePair<string, List<string>>> allQuestions = new List<KeyValuePair<string, List<string>>>();
            foreach (Topic topic in quizManager.topics)
            {
                allQuestions.AddRange(topic.Questions);
            }
            Random random = new Random();
            return allQuestions.OrderBy(x => random.Next()).Take(questionCount).ToList();
        }

        private static void ShowResults(QuizContext context, User user)
        {
            List<QuizResult> results = context.QuizResults.Where(r => r.UserId == user.UserId).ToList();

            if (results.Any())
            {
                foreach (QuizResult result in results)
                {
                    Console.WriteLine($"{result.DateTaken} - {result.Topic} - {result.Score} - Time: {result.Duration.TotalSeconds} seconds");
                }
            }
            else
            {
                Console.WriteLine("There are no records. Let's do quiz!");
            }
            Console.ReadKey();
        }

        private static void ChangeSettings(QuizContext context, User user)
        {
            Console.WriteLine("1. Change password");
            Console.WriteLine("2. Change birth date");
            Console.WriteLine("3. Clear results");
            string settingChoice = Console.ReadLine();
            if (settingChoice == "1")
            {
                string newPassword;
                while (true)
                {
                    Console.Write("Enter new password (more than 4 characters): ");
                    newPassword = Console.ReadLine();
                    if (newPassword.Length <= 4)
                    {
                        Console.WriteLine("Password must be more than 4 characters.");
                    }
                    else
                    {
                        break;
                    }
                }
                user.Password = newPassword;
                context.SaveChanges();
                Console.WriteLine("Password changed successfully.");
            }
            else if (settingChoice == "2")
            {
                Console.Write("Enter new birth date (yyyy-mm-dd): ");
                DateTime birthDate;
                while (!DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    Console.Write("Invalid date format. Enter new birth date (yyyy-mm-dd): ");
                }
                user.BirthDate = birthDate;
                context.SaveChanges();
                Console.WriteLine("Birth date changed successfully.");
            }
            else if (settingChoice == "3")
            {
                var resultsToDelete = context.QuizResults.Where(r => r.UserId == user.UserId);
                context.QuizResults.RemoveRange(resultsToDelete);
                context.SaveChanges();
                Console.WriteLine("All quiz results have been cleared.");
            }
            Console.ReadKey();
        }

        private static void ShowLeaderboard(QuizManager quizManager, QuizContext context)
        {
            Console.WriteLine("Select a topic:");
            Console.WriteLine("1. Mixed quizzes");
            for (int i = 0; i < quizManager.topics.Count; i++)
            {
                Console.WriteLine($"{i + 2}. {quizManager.topics[i].Name}");
            }
            int topicChoice;
            while (!int.TryParse(Console.ReadLine(), out topicChoice) || topicChoice < 1 || topicChoice > quizManager.topics.Count + 1)
            {
                Console.WriteLine("Invalid choice. Please select a valid topic.");
            }
            
            List<QuizResult> topResults = new List<QuizResult>();

            if (topicChoice == 1)
            {
                topResults = context.QuizResults
                .Where(r => r.Topic == "Mixed")
                .OrderByDescending(r => r.Score)
                .ThenBy(r => r.Duration)
                .Take(20)
                .ToList();
            } else
            {
                Topic topic = quizManager.topics[topicChoice - 2];

                topResults = context.QuizResults
                    .Where(r => r.Topic == topic.Name)
                    .OrderByDescending(r => r.Score)
                    .ThenBy(r => r.Duration)
                    .Take(20)
                    .ToList();
            }

            if (topResults.Count != 0)
            {
                for (int i = 0; i < topResults.Count; i++)
                {
                    QuizResult result = topResults[i];
                    User userResult = context.Users.Find(result.UserId);
                    Console.WriteLine($"\t{i + 1}. {userResult.Login} - {result.Topic} - {result.Score} - Time: {result.Duration.TotalSeconds} seconds");
                }
            }
            else Console.WriteLine("There are no leaders ):");
            Console.ReadKey();
        }
    }
}
