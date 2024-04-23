using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    class Tasks // Завдання 1, 2, 3
    {
        static public void PrintSquare(char symb, int length)
        {
            for (int i = 1; i <= length; i++)
            {
                    
                for (int j = 1; j <= length; j++)
                {
                    if (i == 1 || i == length || j == 1 || j == length)
                    {
                        Console.Write($"{symb} ");
                    } else
                    {
                        Console.Write("  ");
                    }
                }
                Console.WriteLine();
            }
        }

        static public bool IsPalindrome(string str)
        {
            string reversedStr = String.Join("", str.Reverse()).ToLower();

            return String.Equals(str.ToLower(), reversedStr); ;
        }

        static public int[] Difference(int[] arr1, int[] arr2)
        {
            int[] differenceArr = new int[arr1.Length];
            int capacityCounter = 0;

            for (int i = 0; i < arr1.Length; i++)
            {
                bool isInArr2 = false;
                for (int j = 0; j < arr2.Length; j++)
                {
                    if (arr2[j] == arr1[i])
                    {
                        isInArr2 = true;
                        break;
                    }
                }

                if (!isInArr2)
                {
                    differenceArr[capacityCounter++] = arr1[i];
                }
            }

            int[] resultArr = new int[capacityCounter];

            Array.Copy(differenceArr, resultArr, capacityCounter);

            return resultArr;
        }
    }

    class Shop
    {
        public string ShopName { get; private set; }
        public string Address { get; private set; }
        public string ShopProfileDescription { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }

        public Shop(string shopName, string address, string shopProfileDescription, string phoneNumber, string email)
        {
            ShopName = shopName;
            Address = address;
            ShopProfileDescription = shopProfileDescription;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public Shop() : this(String.Empty, String.Empty, String.Empty, String.Empty, String.Empty) { }

        public Shop(string shopName) : this(shopName, String.Empty, String.Empty, String.Empty, String.Empty) { }

        public void PrintInfo()
        {
            string format = "|{0,-15}|{1,-20}|{2,-20}|{3,-20}|{4,-25}|";
            string header = String.Format(format, "Shop", "Address", "Description", "Phone number", "Email");
            string separator = new string('-', header.Length);

            Console.WriteLine(separator);
            Console.WriteLine(header);
            Console.WriteLine(separator);
            Console.WriteLine(String.Format(format, ShopName, Address, ShopProfileDescription, PhoneNumber, Email));
            Console.WriteLine(separator);
        }


        public void EditName(string newName)
        {
            ShopName = newName;
        }

        public void EditAddress(string newAddress)
        {
            Address = newAddress;
        }

        public void EditProfileDescription(string newDescription)
        {
            ShopProfileDescription = newDescription;
        }

        public void EditPhoneNumber(string newPhoneNumber)
        {
            PhoneNumber = newPhoneNumber;
        }

        public void EditEmail(string newEmail)
        {
            Email = newEmail;
        }

        public void ClearShopInfo()
        {
            ShopName = String.Empty;
            Address = String.Empty;
            ShopProfileDescription = String.Empty;
            PhoneNumber = String.Empty;
            Email = String.Empty;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Завдання 1
            Console.WriteLine("Task 1");
            Tasks.PrintSquare('+', 7);

            // Завдання 2
            // 1221
            Console.WriteLine($"\n\nTask 2\n{Tasks.IsPalindrome("Pylyp")}");

            // Завдання 3
            Console.WriteLine("\n\nTask 3");
            int[] arr1 = { 1, 2, 3, 4, 5, 88, -1, 0, 6 };
            int[] arr2 = { 1, 2, 6, 3 };

            int[] arr3;
            arr3 = Tasks.Difference(arr1, arr2);

            //foreach (int el in arr3)
            //{
            //    Console.Write($"{el} ");
            //}

            for (int i = 0; i < arr3.Length; i++)
            {
                Console.Write($"{arr3[i]} ");
            }

            // Завдання 6
            Console.WriteLine("\n\nTask 6");
            Shop shop1 = new Shop("GHH", "Main Street, 123", "Furniture shop", "+38-066-666-66-66", "bestShop@gmail.com");
            shop1.PrintInfo();

            Shop shop2 = new Shop();
            Console.WriteLine("\nInitial shop information:");
            shop2.PrintInfo();

            shop2.EditName("New Shop Name");
            shop2.EditAddress("New Address, 456");
            shop2.EditProfileDescription("New Description");
            shop2.EditPhoneNumber("+38-099-999-99-99");
            shop2.EditEmail("newShop@gmail.com");

            Console.WriteLine("\nUpdated shop information:");
            shop2.PrintInfo();

            Console.WriteLine("\nClearing shop information:");
            shop2.ClearShopInfo();
            shop2.PrintInfo();

        }
    }
}
