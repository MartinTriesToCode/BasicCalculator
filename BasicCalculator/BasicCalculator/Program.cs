using System;
using static System.Console;

namespace BasicCalculator
{
    class MainClass
    {
       
       public static void Main(string[] args)
        {
            bool running = true;
            bool DivideByZero = false;
            bool invalid = false;
            int choice = 0;
            decimal[] userNumbers = new decimal[2];
            decimal result = 0;
            decimal nr1 = 0;
            decimal nr2 = 0;
            string op = "";

            ShowInformation();

            while (running)
            {
                invalid = false;
                choice = GetUserChoice();

                if (choice>0 && choice<5)
                    userNumbers = GetUserNumbers();

                nr1 = userNumbers[0];
                nr2 = userNumbers[1];
 
                switch (choice)
                {

                    case 0:   running = false;
                              break;
                    case 1:   result = Add(nr1, nr2);
                              op = "+";
                              break;
                    case 2:   result = Subtract(nr1, nr2);
                              op = "-";
                              break;
                    case 3:   result = Multiply(nr1, nr2);
                              op = "*";
                              break;
                    case 4:   result = Divide(nr1, nr2);
                        if (result == 0)
                            DivideByZero = true; 
                              op = "/";
                              break;
                    default:  WriteLine("Invalid option.");
                              invalid = true;
                              break;
                }

                if (choice != 0 && !DivideByZero && running && !invalid)
                    WriteLine($"{nr1} {op} {nr2} = {result}");
                else if (DivideByZero)
                {
                    WriteLine("Dividend must be larger than zero.");
                    DivideByZero = false;
                }
                else if (invalid)
                    WriteLine("Choose option between 0 and 4.");
                else
                {
                    WriteLine("Program has ended.");
                    Environment.Exit(0);
                }

            }



        }

        public static void ShowInformation()
        {
            WriteLine("Basic calculator. Available options:");
            WriteLine("1: Addition: . 2: Subtraction.");
            WriteLine("3: Multiplication. 4: Division.");
            WriteLine("0: Quit.\n");
        }

        public static int GetUserChoice()
        {
            bool succeded = false;
            int choice = 0;

            while (!succeded)
            {
                Write("Enter option: ");
                succeded = int.TryParse(ReadLine(), out choice);
            }

            return choice;
        }

        public static decimal[] GetUserNumbers()
        {
            bool NumberIsFine = false;
            decimal[] numbers = new decimal[2];

            while (!NumberIsFine)
            {
                Write("Enter number 1: ");
                NumberIsFine = decimal.TryParse(ReadLine(), out numbers[0]);

            }

            NumberIsFine = false;

            while (!NumberIsFine)
            {
                Write("Enter number 2: ");
                NumberIsFine = decimal.TryParse(ReadLine(), out numbers[1]);

            }

            return numbers;
        }

        public static decimal Add(decimal a, decimal b)
        {
            return a + b;
        }

        public static decimal Subtract(decimal a, decimal b)
        {
            return a - b;
        }

        public static decimal Multiply(decimal a, decimal b)
        {
            return a * b;
        }

        public static decimal Divide(decimal a, decimal b)
        {
            decimal result = 0;

            try
            {
                result = a / b;
            }
            catch (DivideByZeroException)
            {
                WriteLine("Division of {0} by zero.",a);
            }

            return result;
        }

    }
}
