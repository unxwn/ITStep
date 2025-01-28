// See https://aka.ms/new-console-template for more information
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.PortableExecutable;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
string connStr = "Server=(localdb)\\MSSQLLocalDb;Database=PV312LibraryDb;Trusted_Connection=True";
SqlConnection conn = new SqlConnection(connStr);

try
{
    conn.Open();
    Console.Write("Connected successfully to the database");
    Thread.Sleep(250);
    Console.Write(".");
    Thread.Sleep(250);
    Console.Write(".");
    Thread.Sleep(250);
    Console.Write(".");
    Thread.Sleep(250);
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
    conn.Close();
}

while (true)
{
    Console.Clear();
    Console.WriteLine("=== Student grades menu ===");
    Console.WriteLine("1. Display all records");
    Console.WriteLine("2. Display student names");
    Console.WriteLine("3. Display all average grades");
    Console.WriteLine("4. Display students with avg grade > specified");
    Console.WriteLine("5. Display min and max average grades");
    Console.WriteLine("6. Display student Count per group");
    Console.WriteLine("7. Display group average grades");
    Console.WriteLine("8. Show students with minimum average grade in physics");
    Console.WriteLine("9. Show students with maximum average grade in math");
    Console.WriteLine("0. Exit");
    Console.Write("Select an option: ");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            DisplayAllRecords(conn);
            break;
        case "2":
            DisplayStudentNames(conn);
            break;
        case "3":
            DisplayAllAverageGrades(conn);
            break;
        case "4":
            Console.Write("Enter minimum grade: ");
            float minGrade = float.TryParse(Console.ReadLine(), out minGrade) ? minGrade : -1;
            DisplayStudentsWithMinGrade(conn, minGrade);
            break;
        case "5":
            DisplayMinMaxGradesWithDetails(conn);
            break;
        case "6":
            DisplayStudentCountPerGroup(conn);
            break;
        case "7":
            DisplayGroupAverageGrades(conn);
            break;
        case "8":
            ShowStudentsWithMinMathGrade(conn);
            break;
        case "9":
            ShowStudentsWithMaxMathGrade(conn);
            break;
        case "0":
            break;
        default:
            Console.WriteLine("Invalid option. Try again.");
            break;
    }

    if (choice == "0") { conn.Close(); break; }

    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
}

static void DisplayAllRecords(SqlConnection conn)
{
    string query = "SELECT * FROM StudentGrades";
    SqlCommand cmd = new SqlCommand(query, conn);
    SqlDataReader reader = cmd.ExecuteReader();

    Console.WriteLine("Id\tFull_name\t\tGroup\t\tAvg_grade\tMin_subject\tMax_subject");
    while (reader.Read())
    {
        Console.WriteLine($"{reader.GetInt32("Id")}\t{reader.GetString("FullName")}\t{reader.GetString("GroupName")}\t{reader.GetDouble("AverageGrade")}\t{reader.GetString("SubjectMinGrade")}\t{reader.GetString("SubjectMaxGrade")}");
    }
    reader.Close();
}

static void DisplayStudentNames(SqlConnection conn)
{
    string query = "SELECT FullName FROM StudentGrades";
    SqlCommand cmd = new SqlCommand(query, conn);
    SqlDataReader reader = cmd.ExecuteReader();

    Console.WriteLine("Student names:");
    while (reader.Read())
    {
        Console.WriteLine(reader.GetString("FullName"));
    }
    reader.Close();
}

static void DisplayAllAverageGrades(SqlConnection conn)
{
    string query = "SELECT FullName, AverageGrade FROM StudentGrades";
    SqlCommand cmd = new SqlCommand(query, conn);
    SqlDataReader reader = cmd.ExecuteReader();

    Console.WriteLine("Full Name\t\tAverage Grade:");
    while (reader.Read())
    {
        Console.WriteLine($"{reader.GetString("FullName")}\t{reader.GetDouble("AverageGrade")}");
    }
    reader.Close();
}

static void DisplayStudentsWithMinGrade(SqlConnection conn, float minGrade)
{
    if (minGrade < 0)
    {
        Console.WriteLine("Enter correct grade!");
        return;
    }
    string query = $"SELECT FullName, AverageGrade FROM StudentGrades WHERE AverageGrade > {minGrade}";
    SqlCommand cmd = new SqlCommand(query, conn);

    SqlDataReader reader = cmd.ExecuteReader();
    Console.WriteLine($"Students with average grade > {minGrade}:");
    while (reader.Read())
    {
        Console.WriteLine($"{reader.GetString("FullName")} {reader.GetDouble("AverageGrade")}");
    }
    reader.Close();
}

static void DisplayMinMaxGradesWithDetails(SqlConnection conn)
{
    string minQuery = @"
        SELECT TOP 1 FullName, SubjectMinGrade, AverageGrade 
        FROM StudentGrades 
        WHERE AverageGrade = (SELECT MIN(AverageGrade) FROM StudentGrades)";

    string maxQuery = @"
        SELECT TOP 1 FullName, SubjectMaxGrade, AverageGrade 
        FROM StudentGrades 
        WHERE AverageGrade = (SELECT MAX(AverageGrade) FROM StudentGrades)";

    SqlCommand minCmd = new SqlCommand(minQuery, conn);
    SqlDataReader minReader = minCmd.ExecuteReader();

    Console.WriteLine("Details of the student with the minimum grade:");
    if (minReader.Read())
    {
        string fullName = minReader.GetString(0);
        string subject = minReader.GetString(1);
        double grade = minReader.GetDouble(2);
        Console.WriteLine($"Student: {fullName}, Subject: {subject}, Grade: {grade}");
    }
    minReader.Close();

    SqlCommand maxCmd = new SqlCommand(maxQuery, conn);
    SqlDataReader maxReader = maxCmd.ExecuteReader();

    Console.WriteLine("Details of the student with the maximum grade:");
    if (maxReader.Read())
    {
        string fullName = maxReader.GetString(0);
        string subject = maxReader.GetString(1);
        double grade = maxReader.GetDouble(2);
        Console.WriteLine($"Student: {fullName}, Subject: {subject}, Grade: {grade}");
    }
    maxReader.Close();
}


static void DisplayStudentCountPerGroup(SqlConnection conn)
{
    string query = "SELECT GroupName, COUNT(*) AS StudentCount FROM StudentGrades GROUP BY GroupName";
    SqlCommand cmd = new SqlCommand(query, conn);
    SqlDataReader reader = cmd.ExecuteReader();

    Console.WriteLine("Group\t\tStudent Count:");
    while (reader.Read())
    {
        Console.WriteLine($"{reader["GroupName"]}\t{reader["StudentCount"]}");
    }
    reader.Close();
}

static void DisplayGroupAverageGrades(SqlConnection conn)
{
    string query = "SELECT GroupName, AVG(AverageGrade) AS GroupAvg FROM StudentGrades GROUP BY GroupName";
    SqlCommand cmd = new SqlCommand(query, conn);
    SqlDataReader reader = cmd.ExecuteReader();

    Console.WriteLine("Group\t\tAverage Grade:");
    while (reader.Read())
    {
        Console.WriteLine($"{reader["GroupName"]}\t{reader["GroupAvg"]}");
    }
    reader.Close();
}

static void ShowStudentsWithMinMathGrade(SqlConnection conn)
{
    string query = "SELECT COUNT(*) FROM StudentGrades WHERE SubjectMinGrade = N'Фізика'";

    SqlCommand cmd = new SqlCommand(query, conn);
    int count = (int)cmd.ExecuteScalar();
    Console.WriteLine($"Students with the minimum average grade in math: {count}");
}


static void ShowStudentsWithMaxMathGrade(SqlConnection conn)
{
    string query = "SELECT COUNT(*) FROM StudentGrades WHERE SubjectMaxGrade = N'Математика'";

    SqlCommand cmd = new SqlCommand(query, conn);
    int count = (int)cmd.ExecuteScalar();
    Console.WriteLine($"Students with the minimum average grade in math: {count}");
}
