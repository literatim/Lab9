using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Lab9
{
    class Program
    {
        public class Student
        {
            public string Name { get; set; }
            public string FavoriteFood { get; set; }
            public string Hometown { get; set; }
            public string FavoriteColor { get; set; }
            public static Exception FormatException { get; set; }
            public static Exception IndexOutOfRangeException { get; set; }
            
        }

        static void Main(string[] args)
        {
            var studentList = new List<Student>
            {
                new Student() {Name = "Ben Jen", FavoriteFood = "Pizza", Hometown = "Toledo, OH", FavoriteColor = "Blue"},
                new Student() {Name = "Ben Wyatt", FavoriteFood = "Calzone", Hometown = "Eagleton, IN", FavoriteColor = "Purple"},
                new Student() {Name = "Leslie Knope", FavoriteFood = "Waffles", Hometown = "Partridge, MN", FavoriteColor = "Red"},
            };

            do
            {
                Console.Write("Welcome to our C# class. Which student would you like to learn more about? (Enter a number 1-3): ");
                var userInput = GetUserInput();

                while (userInput > studentList.Count())
                {
                    Console.Write($"That student does not exist. Please try again. (Enter a number 1-3): ");
                    try
                    {
                        userInput = GetUserInput();
                    }
                    catch (Exception)
                    {
                        throw Student.IndexOutOfRangeException;
                    }
                }

                Console.Write($"Student {userInput} is {studentList[userInput].Name}. What would you like to know about {studentList[userInput].Name}? Enter favorite food or hometown: ");


                try
                {
                    GetSecondaryInput(studentList, userInput);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    GetSecondaryInput(studentList, userInput);
                }

                Console.Write("Would you like to start again? (y/n): ");
            } while (Console.ReadLine().Equals("y", StringComparison.OrdinalIgnoreCase));


            Console.Write("Goodbye.");
            Console.ReadKey();

        }

        private static void GetSecondaryInput(List<Student> studentList, int userInput)
        {
            var secondaryInput = Console.ReadLine();

            if (secondaryInput == "favorite food")
            {
                Console.Write($"{studentList[userInput].Name}'s favorite food is {studentList[userInput].FavoriteFood}. Would you like to know something else? (yes/no): ");
                var userContinue = Console.ReadLine();
                if (userContinue == "yes")
                {
                    Console.WriteLine($"{studentList[userInput].Name}'s hometown is {studentList[userInput].Hometown}.");
                }
            }
            else if (secondaryInput == "hometown")
            {
                Console.Write($"{studentList[userInput].Name}'s hometown is {studentList[userInput].Hometown}. Would you like to know something else? (yes/no): ");
                var userContinue = Console.ReadLine();
                if (userContinue == "yes")
                {
                    Console.WriteLine($"{studentList[userInput].Name}'s favorite food is {studentList[userInput].FavoriteFood}.");
                }
            }
            else if (secondaryInput == "add student")
            {
                addStudent();
            }
            else
            {
                throw new FormatException("That data does not exist. Please try again. Enter favorite food or hometown: ");
            }
        }

        private static void addStudent()
        {
            
        }

        private static int GetUserInput()
        {
            int input;
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Please enter a valid numerical value!");
                Console.WriteLine("Please enter a number: ");
            }

            input -= 1;
            return input;
        }
    }
}
