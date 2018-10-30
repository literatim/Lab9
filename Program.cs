using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab9
{
    class Program
    {
        // James - I like that you are using a student class! I would put it in it's own file though.  also
        // I see you are putting the possible Exceptions on this class as properties.  I'll be honest I don't 
        // really have a strong opinion about doing this, but I will let you know, I haven't seen anyone doing this.
        // I think it is creative and for now it's fine.
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
            // James - List of students, good job.
            var studentList = new List<Student>
            {
                new Student() {Name = "Ben Jen", FavoriteFood = "Pizza", Hometown = "Toledo, OH", FavoriteColor = "Blue"},
                new Student() {Name = "Ben Wyatt", FavoriteFood = "Calzone", Hometown = "Eagleton, IN", FavoriteColor = "Purple"},
                new Student() {Name = "Leslie Knope", FavoriteFood = "Waffles", Hometown = "Partridge, MN", FavoriteColor = "Red"},
            };

            do
            {
                // James - Maybe try displaying the list of students first so the user has an idea what he/she is working with.
                Console.Write($"Welcome to our C# class. Which student would you like to learn more about? (Enter a number 1-{studentList.Count}): ");
                // James - seperation of concerns in practice, nice.
                var userInput = GetUserInput();

                while (userInput > studentList.Count())
                {
                    Console.Write($"That student does not exist. Please try again. (Enter a number 1-{studentList.Count}): ");

                    userInput = GetUserInput();
                }

                Console.Write($"Student {userInput} is {studentList[userInput - 1].Name}. You can find out more about {studentList[userInput - 1].Name}, or you can add a student. Enter favorite food, hometown, or favorite color, or add student: ");

                bool isSecondaryInputValid = false;
                while (!isSecondaryInputValid)
                {
                    try
                    {
                        GetSecondaryInput(studentList, userInput);
                        isSecondaryInputValid = true;
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                Console.Write("Would you like to start again? (y/n): ");
            } while (Console.ReadLine().Equals("y", StringComparison.OrdinalIgnoreCase));


            Console.Write("Goodbye.");
            Console.ReadKey();

        }

        private static void GetSecondaryInput(List<Student> studentList, int userInput)
        {
            var secondaryInput = Console.ReadLine();
            // James - I would consider making what the user has to input way more clear, for exmaple, reduce the words
            // the user needs to input to like "food" and you can wrap that around brackets, so like 
            // favorite [food].  then afterwords you can WRiteLine another message saying something like 
            // "please enter the word between the brackets.
            // that would make it very clear what the user has to enter.
            if (secondaryInput == "favorite food")
            {
                Console.Write($"{studentList[userInput - 1].Name}'s favorite food is {studentList[userInput - 1].FavoriteFood}. Would you like to know something else? (yes/no): ");
                var userContinue = Console.ReadLine();
                if (userContinue == "yes")
                {
                    Console.WriteLine($"{studentList[userInput - 1].Name}'s hometown is {studentList[userInput - 1].Hometown}, and favorite color is {studentList[userInput - 1].FavoriteColor}.");
                }
            }
            else if (secondaryInput == "hometown")
            {
                Console.Write($"{studentList[userInput - 1].Name}'s hometown is {studentList[userInput - 1].Hometown}. Would you like to know something else? (yes/no): ");
                var userContinue = Console.ReadLine();
                if (userContinue == "yes")
                {
                    Console.WriteLine($"{studentList[userInput - 1].Name}'s favorite food is {studentList[userInput - 1].FavoriteFood}, and favorite color is {studentList[userInput - 1].FavoriteColor}.");
                }
            }
            // James - I would consider making what the user has to input way more clear, for exmaple, reduce the words
            // the user needs to input to like "color" and you can wrap that around brackets, so like 
            // favorite [color].  then afterwords you can WRiteLine another message saying something like 
            // "please enter the word between the brackets.
            // that would make it very clear what the user has to enter.
            else if (secondaryInput == "favorite color")
            {
                Console.Write($"{studentList[userInput - 1].Name}'s favorite color is {studentList[userInput - 1].FavoriteColor}. Would you like to know something else? (yes/no): ");
                var userContinue = Console.ReadLine();
                if (userContinue == "yes")
                {
                    Console.WriteLine($"{studentList[userInput - 1].Name}'s favorite food is {studentList[userInput - 1].FavoriteFood}, and hometown is {studentList[userInput - 1].Hometown}.");
                }
            }
            // James - I would consider making what the user has to input way more clear, for exmaple, reduce the words
            // the user needs to input to like "student" and you can wrap that around brackets, so like 
            // add [student].  then afterwords you can WRiteLine another message saying something like 
            // "please enter the word between the brackets.
            // that would make it very clear what the user has to enter.
            else if (secondaryInput == "add student")
            {
                AddStudent(studentList);
            }
            else
            {
                throw new FormatException("That data does not exist. Please try again. Enter favorite food, hometown, favorite color, or add student: ");
            }
        }

        private static void AddStudent(List<Student> studentList)
        {
            Console.Write("Enter the student's name: ");
            string inputName = Console.ReadLine();
            while (string.IsNullOrEmpty(inputName))
            {
                Console.WriteLine("Name cannot be empty.");
                Console.Write("Enter the student's name: ");
                inputName = Console.ReadLine();
            }

            Console.Write("Enter the student's favorite food: ");
            string inputFavoriteFood = Console.ReadLine();
            while (string.IsNullOrEmpty(inputFavoriteFood))
            {
                Console.WriteLine("Favorite food cannot be empty.");
                Console.Write("Enter the student's favorite food: ");
                inputFavoriteFood = Console.ReadLine();
            }
            Console.Write("Enter the student's hometown: ");
            string inputHometown = Console.ReadLine();
            while (string.IsNullOrEmpty(inputHometown))
            {
                Console.WriteLine("Hometown cannot be empty.");
                Console.Write("Enter the student's hometown: ");
                inputHometown = Console.ReadLine();
            }
            Console.Write("Enter the student's favorite color: ");
            string inputFavoriteColor = Console.ReadLine();
            while (string.IsNullOrEmpty(inputFavoriteColor))
            {
                Console.WriteLine("Favorite color cannot be empty.");
                Console.Write("Enter the student's favorite color: ");
                inputFavoriteColor = Console.ReadLine();
            }

            studentList.Add(new Student() { Name = inputName, FavoriteFood = inputFavoriteFood, Hometown = inputHometown, FavoriteColor = inputFavoriteColor });
        }

        // James - I like that you are using this method in several spots in your code, really cool, this is what 
        // methods are all about! you are practicing modularity!
        private static int GetUserInput()
        {
            int input;
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Please enter a valid numerical value!");
                Console.WriteLine("Please enter a number: ");
            }

            return input;
        }
    }
}
