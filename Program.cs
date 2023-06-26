using System;
using System.Text.RegularExpressions;

namespace DiceRollingApp
{


    /*    **************SOLID Principles***************************
     Single Responsibility Principle (SRP): Each class (StandardDice, CheatDice, ConsoleOutputter, DiceRoller) has a single responsibility or reason to change.

     Open-Closed Principle (OCP): The DiceRoller class can work with any implementation of IDice and IOutputtable. It is open for extension (by implementing new classes) but closed for modification (existing code doesn't need to change).

     Liskov Substitution Principle (LSP): The StandardDice and CheatDice classes both implement the IDice interface, and the CheatDice class can be used interchangeably with the StandardDice class without affecting the behavior of the application.

     Interface Segregation Principle (ISP): The IDice interface and the IOutputtable interface are segregated to have specific responsibilities. The DiceRoller class depends only on the methods it needs from the IDice and IOutputtable interfaces.

     Dependency Inversion Principle (DIP): The DiceRoller class depends on abstractions (IDice and IOutputtable) rather than concrete implementations. The dependencies are injected via the constructor, allowing for flexibility, loose coupling, and easier testing.

     These principles help in creating more maintainable, extensible, and testable code by promoting separation of concerns, flexibility, and reducing dependencies between components.*/

    // Interface for a dice
    interface IDice
    {
        int Sides { get; } // Number of sides on the dice
        int Roll(); // Roll the dice and return the result
    }

    // Implementation of a standard six-sided dice
    class StandardDice : IDice
    {
        public int Sides => 6; // Six sides on the dice

        public int Roll()
        {
            Random random = new Random();
            return random.Next(1, Sides + 1); // Roll the dice and return a random number between 1 and 6
        }
    }

    // Implementation of a cheat dice that always rolls a six
    class CheatDice : IDice
    {
        public int Sides => 6; // Six sides on the dice

        public int Roll()
        {
            return 6; // Always returns 6
        }
    }

    // Interface for displaying output
    interface IOutputtable
    {
        void DisplayResult(int result); // Display the result
    }

    // Implementation of displaying output on the console
    class ConsoleOutputter : IOutputtable
    {
        public void DisplayResult(int result)
        {
            Console.WriteLine("You rolled: " + result); // Display the rolled dice result on the console
        }
    }

    // Class responsible for rolling the dice and displaying the result
    class DiceRoller
    {
        private readonly IDice _dice; // The dice to be rolled
        private readonly IOutputtable _outputter; // The outputter to display the result

        public DiceRoller(IDice dice, IOutputtable outputter)
        {
            _dice = dice; // Inject the dice dependency
            _outputter = outputter; // Inject the outputter dependency
        }

        public void RollDice()
        {
            int result = _dice.Roll(); // Roll the dice
            _outputter.DisplayResult(result); // Display the result
        }
    }

    // Main program entry point
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Dice Rolling Simulator!");
            Console.WriteLine("-------------------------------------");

            IDice dice = new StandardDice(); // Create a standard dice
            IOutputtable outputter = new ConsoleOutputter(); // Create a console outputter
            DiceRoller diceRoller = new DiceRoller(dice, outputter); // Create a dice roller

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Roll Dice");
                Console.WriteLine("2. Reverse a String");
                Console.WriteLine("3. Find Maximum Number in an Array");
                Console.WriteLine("4. Check if a String is a Palindrome");
                Console.WriteLine("5. Calculate the Factorial of a Number");
                Console.WriteLine("6. Quit");
                Console.WriteLine();

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        diceRoller.RollDice(); // Roll the dice
                        break;
                    case "2":
                        ReverseString(); // Reverse a string
                        break;
                    case "3":
                        FindMaximumNumber(); // Find the maximum number in an array
                        break;
                    case "4":
                        CheckPalindrome(); // Check if a string is a palindrome
                        break;
                    case "5":
                        CalculateFactorial(); // Calculate the factorial of a number
                        break;
                    case "6":
                        Console.WriteLine("Thank you for using the Dice Rolling Simulator!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        // Problem: Reverse a string
        static void ReverseString()
        {
            Console.Write("Enter a string to reverse: ");
            string input = Console.ReadLine();
            char[] charArray = input.ToCharArray(); // Convert the string to a character array
            Array.Reverse(charArray); // Reverse the character array
            string reversed = new string(charArray); // Convert the reversed character array back to a string
            Console.WriteLine("Reversed string: " + reversed); // Display the reversed string
        }

        // Problem: Find the maximum number in an array
        static void FindMaximumNumber()
        {
            Console.Write("Enter the number of elements: ");
            int n = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter number " + (i + 1) + ": ");
                numbers[i] = int.Parse(Console.ReadLine()); // Read input numbers into the array
            }

            int max = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                    max = numbers[i]; // Find the maximum number in the array
            }

            Console.WriteLine("Maximum number: " + max); // Display the maximum number
        }

        // Problem: Check if a string is a palindrome
        static void CheckPalindrome()
        {
            Console.Write("Enter a string: ");
            string input = Console.ReadLine();

            bool isPalindrome = true;
            for (int i = 0; i < input.Length / 2; i++)
            {
                if (input[i] != input[input.Length - i - 1])
                {
                    isPalindrome = false; // Check if the string is a palindrome
                    break;
                }
            }

            Console.WriteLine("Is Palindrome: " + isPalindrome); // Display whether the string is a palindrome or not
        }

        // Problem: Calculate the factorial of a number
        static void CalculateFactorial()
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            int factorial = 1;
            for (int i = 1; i <= number; i++)
            {
                factorial *= i; // Calculate the factorial of the number
            }

            Console.WriteLine("Factorial of " + number + ": " + factorial); // Display the factorial
        }

        //Problem: Check if a number is prime
        static bool IsPrime(int number)
        {
            if (number <= 1)
                return false;

            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }

        //Problem: Reverse the words in a string
        static string ReverseWords(string input)
        {
            string[] words = input.Split(' ');
            Array.Reverse(words);
            return string.Join(" ", words);
        }

        //Problem: Find the second largest number in an array
        static int FindSecondLargest(int[] numbers)
        {
            if (numbers.Length < 2)
                throw new ArgumentException("Array should contain at least two numbers.");

            int largest = int.MinValue;
            int secondLargest = int.MinValue;

            foreach (int num in numbers)
            {
                if (num > largest)
                {
                    secondLargest = largest;
                    largest = num;
                }
                else if (num > secondLargest && num < largest)
                {
                    secondLargest = num;
                }
            }

            return secondLargest;
        }

        //         Problem: Check if two strings are anagrams
        // Description: Write a method that takes two strings as input and determines whether they are anagrams (contain the same characters in a different order).
        static bool AreAnagrams(string str1, string str2)
        {
            if (str1.Length != str2.Length)
                return false;

            int[] charCounts = new int[26];

            for (int i = 0; i < str1.Length; i++)
            {
                charCounts[str1[i] - 'a']++;
                charCounts[str2[i] - 'a']--;
            }

            foreach (int count in charCounts)
            {
                if (count != 0)
                    return false;
            }

            return true;
        }

        //Problem: Calculate the sum of all elements in an array
        static int CalculateSum(int[] numbers)
        {
            int sum = 0;
            foreach (int num in numbers)
            {
                sum += num;
            }
            return sum;
        }

        //Problem: Remove duplicates from an array
        static int[] RemoveDuplicates(int[] numbers)
        {
            HashSet<int> set = new HashSet<int>(numbers);
            return set.ToArray();
        }

        //Problem: Find the missing number in an array of consecutive integers
        static int FindMissingNumber(int[] numbers)
        {
            int n = numbers.Length + 1; // Number of elements, including the missing number
            int expectedSum = (n * (n + 1)) / 2; // Expected sum of consecutive numbers
            int actualSum = numbers.Sum(); // Sum of the given array
            return expectedSum - actualSum;
        }

        //Problem: Calculate the Fibonacci sequence
        //Description: Write a method that takes an integer n as input and returns the nth number in the Fibonacci sequence.
        static int Fibonacci(int n)
        {
            if (n <= 1)
                return n;

            int previous = 0;
            int current = 1;

            for (int i = 2; i <= n; i++)
            {
                int next = previous + current;
                previous = current;
                current = next;
            }

            return current;
        }

        //Problem: Reverse a linked list
        class ListNode
        {
            public int Value { get; set; }
            public ListNode Next { get; set; }
        }

        static ListNode ReverseLinkedList(ListNode head)
        {
            ListNode previous = null;
            ListNode current = head;

            while (current != null)
            {
                ListNode next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }

            return previous;
        }

        //Problem: Find the common elements between two arrays
        static int[] FindCommonElements(int[] arr1, int[] arr2)
        {
            HashSet<int> set = new HashSet<int>(arr1);
            List<int> commonElements = new List<int>();

            foreach (int num in arr2)
            {
                if (set.Contains(num))
                {
                    commonElements.Add(num);
                }
            }

            return commonElements.ToArray();
        }

        //Problem: Determine if a string is a valid palindrome ignoring non-alphanumeric characters
        //Description: Write a method that takes a string as input and determines whether it is a valid palindrome, ignoring non-alphanumeric characters.
        static bool IsPalindrome(string input)
        {
            string cleanedInput = Regex.Replace(input, @"[^a-zA-Z0-9]", "").ToLower();

            int start = 0;
            int end = cleanedInput.Length - 1;

            while (start < end)
            {
                if (cleanedInput[start] != cleanedInput[end])
                {
                    return false;
                }

                start++;
                end--;
            }

            return true;
        }

        //Problem: Find the intersection of two linked lists
        //Description: Write a method that takes the heads of two linked lists and returns the node at which the two lists intersect, or null if they do not intersect
        class ListNode1
        {
            public int Value { get; set; }
            public ListNode1 Next { get; set; }
        }

        static ListNode1 FindIntersection(ListNode1 head1, ListNode1 head2)
        {
            ListNode1 p1 = head1;
            ListNode1 p2 = head2;

            while (p1 != p2)
            {
                p1 = p1 == null ? head2 : p1.Next;
                p2 = p2 == null ? head1 : p2.Next;
            }

            return p1;
        }

    }
}
