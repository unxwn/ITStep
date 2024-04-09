using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5
{
    public class Employee
    {
        public int Salary { get; }

        public Employee(int salary)
        {
            Salary = salary;
        }

        public static Employee operator +(Employee a, int premium)
        {
            return new Employee(a.Salary + premium);
        }

        public static Employee operator -(Employee a, int fine)
        {
            return new Employee(a.Salary - fine);
        }

        public static bool operator ==(Employee a, Employee b)
        {
            return a.Salary == b.Salary;
        }

        public static bool operator !=(Employee a, Employee b)
        {
            return a.Salary != b.Salary;
        }

        public static bool operator <(Employee a, Employee b)
        {
            return a.Salary < b.Salary;
        }

        public static bool operator >(Employee a, Employee b)
        {
            return a.Salary > b.Salary;
        }
    }

    public class Matrix
    {
        private int[,] matrixData;
        public int Rows { get; }
        public int Columns { get; }

        public int this[int row, int col]
        {
            get { return matrixData[row, col]; }
            set { matrixData[row, col] = value; }
        }

        public Matrix(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            matrixData = new int[rows, columns];
        }

        static void PrintMatrix(Matrix matrix)
        {
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Columns != b.Columns)
                throw new Exception("Matrix dimensions must be equal.");

            Matrix result = new Matrix(a.Rows, a.Columns);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Columns; j++)
                {
                    result[i, j] = a[i, j] + b[i, j];
                }
            }
            return result;
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Columns != b.Columns)
                throw new Exception("Matrix dimensions must be equal.");

            Matrix result = new Matrix(a.Rows, a.Columns);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Columns; j++)
                {
                    result[i, j] = a[i, j] - b[i, j];
                }
            }
            return result;
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.Columns != b.Rows)
                throw new Exception("Number of columns in first matrix must be equal to number of rows in second matrix.");

            Matrix result = new Matrix(a.Rows, b.Columns);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < b.Columns; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < a.Columns; k++)
                    {
                        sum += a[i, k] * b[k, j];
                    }
                    result[i, j] = sum;
                }
            }
            return result;
        }

        public static bool operator ==(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Columns != b.Columns)
                return false;

            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Columns; j++)
                {
                    if (a[i, j] != b[i, j])
                        return false;
                }
            }
            return true;
        }

        public static bool operator !=(Matrix a, Matrix b)
        {
            return !(a == b);
        }

        internal class Program
        {
            static void Main(string[] args)
            {
                // 1
                Employee employee1 = new Employee(1111);
                Employee employee2 = new Employee(2222);
                Console.WriteLine("Employee`s 1 salary before changes: " + employee1.Salary);
                employee1 = employee1 + 2000;
                employee1 = employee1 - 3000;
                Console.WriteLine("Employee`s 1 salary after changes: " + employee1.Salary);
                Console.WriteLine("Equality: " + (employee1.Salary == employee2.Salary));
                Console.WriteLine("Inequality: " + (employee1.Salary != employee2.Salary));
                Console.WriteLine("Less: " + (employee1.Salary < employee2.Salary));
                Console.WriteLine("More: " + (employee1.Salary > employee2.Salary));

                // matrix
                Matrix matrix1 = new Matrix(2, 2);
                matrix1[0, 0] = 1;
                matrix1[0, 1] = 2;
                matrix1[1, 0] = 3;
                matrix1[1, 1] = 4;
                Console.WriteLine("\n\nMatrix 1:");
                Matrix.PrintMatrix(matrix1);

                Matrix matrix2 = new Matrix(2, 2);
                matrix2[0, 0] = 5;
                matrix2[0, 1] = 6;
                matrix2[1, 0] = 7;
                matrix2[1, 1] = 8;
                Console.WriteLine("\nMatrix 2:");
                Matrix.PrintMatrix(matrix2);
                Console.WriteLine();

                Matrix sum = matrix1 + matrix2;
                Matrix difference = matrix1 - matrix2;
                Matrix product = matrix1 * matrix2;

                Console.WriteLine("Sum:");
                PrintMatrix(sum);
                Console.WriteLine("Difference:");
                PrintMatrix(difference);
                Console.WriteLine("Product:");
                PrintMatrix(product);

                Console.WriteLine("Equality: " + (matrix1 == matrix2));
                Console.WriteLine("Inequality: " + (matrix1 != matrix2));
            }
        }
    }
}
