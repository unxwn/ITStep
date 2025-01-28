// See https://aka.ms/new-console-template for more information
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("Hello, World!");

string connStr = "Server=(localdb)\\MSSQLLocalDb;Database=PV312LibraryDb;Trusted_Connection=True";

SqlConnection conn = new SqlConnection(connStr);
try
{
    conn.Open();
    // Example 1
    //Console.WriteLine($"Server: {conn.ServerVersion}");
    //Console.WriteLine($"Database name: {conn.Database}");
    //Console.WriteLine($"Connection status: {conn.State}");
    //Console.WriteLine($"Workstation id: {conn.WorkstationId}");

    // Example 2
    //string query = "INSERT INTO Authors(FirstName, Surname, YearOfBirth) VALUES(N'Іван', N'Багряний', 1906);";
    //SqlCommand sqlCommand = new SqlCommand(query, conn);
    //int rowsCount = sqlCommand.ExecuteNonQuery();
    //Console.WriteLine($"Was inserted {rowsCount} rows!");

    // Example 3
    //string query = "SELECT MAX(YearOfBirth) FROM Authors";
    //SqlCommand cmd = conn.CreateCommand();
    //cmd.CommandText = query;
    //var maxYear = cmd.ExecuteScalar();
    //Console.WriteLine("The youngest author was born in " + maxYear);

    // Example 3
    string query = "SELECT * FROM Authors";
    SqlCommand sqlCommand = conn.CreateCommand();
    sqlCommand.CommandText = query;
    SqlDataReader reader = sqlCommand.ExecuteReader();
    for (int i = 0; i < reader.FieldCount; i++)
    {
        Console.Write($"{reader.GetName(i)}\t");
    }
    while (reader.Read())
    {
        int id = reader.GetInt32("id");
        string firstName = reader.GetString("FirstName");
        string surname = reader.GetString("Surname");
        int year = reader.GetInt32("Yearofbirth");
        Console.WriteLine($"{id}. {firstName} {surname}. {year}");
    }

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    conn?.Close();
}