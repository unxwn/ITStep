using System;
using System.Collections.Generic;
using System.Linq;

namespace Practice13
{
    internal class Student
    {
        public string FirstName { get; }
        public string LastName { get; }
        public int Age { get; }
        public string University { get; }

        public Student(string firstName, string lastName, int age, string university)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            University = university;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}, {Age} yo, {University}";
        }
    }

    internal class Program
    {
        static void Main()
        {
            List<Student> students = new List<Student>
            {
            new Student("Boris", "Johnson", 18, "Harvard"),
            new Student("Joe", "Biden", 20, "MIT"),
            new Student("Anna", "Brown", 22, "Oxford"),
            new Student("John", "Smith", 21, "MIT"),
            new Student("Emma", "Brooks", 19, "Oxford"),
            new Student("Olivia", "Brown", 23, "Oxford"),
            new Student("Michael", "White", 25, "MIT")
            };

            //Отримати всіх студентів.
            List<Student> allStudents = students.ToList();
            Console.WriteLine("All students:");
            allStudents.ForEach(Console.WriteLine);
            Console.WriteLine();

            //Отримати список студентів з ім'ям Boris
            List<Student> borisStudents = students.Where(s => s.FirstName == "Boris").ToList();
            Console.WriteLine("Students named Boris:");
            borisStudents.ForEach(Console.WriteLine);
            Console.WriteLine();

            //Отримати список студентів з прізвищем, яке починається з Bro.
                        List<Student> broStudents = students.Where(s => s.LastName.StartsWith("Bro")).ToList();
            Console.WriteLine("Students with last names starting with 'Bro':");
            broStudents.ForEach(Console.WriteLine);
            Console.WriteLine();

            //Отримати список студентів, 18 і 20 років.
            List<Student> olderThan19Students = students.Where(s => s.Age == 20 || s.Age == 18).OrderByDescending(s => s.Age).ToList();
            Console.WriteLine("Students 18 and 20 yo (descending):");
            olderThan19Students.ForEach(Console.WriteLine);
            Console.WriteLine();

            //Отримати список студентів, старших 20 років і молодших 23 років.
            List<Student> between20And23Students = students.Where(s => s.Age > 20 && s.Age < 23).ToList();
            Console.WriteLine("Students older than 20 and younger than 23:");
            between20And23Students.ForEach(Console.WriteLine);
            Console.WriteLine();

            //Отримати список студентів, які навчаються в MIT
            List<Student> mitStudents = students.Where(s => s.University == "MIT").ToList();
            Console.WriteLine("Students studying at MIT:");
            mitStudents.ForEach(Console.WriteLine);
            Console.WriteLine();

            //Отримати список студентів, які навчаються в Oxford, і вік яких старше 18 років. Результат відсортуйте за віком, за спаданням.
            List<Student> oxfordOlderThan18Students = students.Where(s => s.University == "Oxford" && s.Age > 18)
                .OrderByDescending(s => s.Age)
                .ToList();
            Console.WriteLine("Students studying at Oxford and older than 18, ordered by age descending:");
            oxfordOlderThan18Students.ForEach(Console.WriteLine);
            Console.WriteLine();
        }
    }
}
