using System;

namespace DufflinMunder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Dufflin/Munder Cardboard Co. Sales Portal!\n" +
                "\n1. Enter Sales\n" +
                "2. Generate Report for Accountant\n" +
                "3. Add New Sales Employee\n" +
                "4. Find a Sale\n" +
                "5. Exit");

            int menuSelection = Convert.ToInt32(Console.ReadLine());

            switch (menuSelection)
            {
                case 1:
                    {
                        Console.WriteLine("You have selected 'enter a sale'");
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("You have selected 'generate a report'");
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("You have selected 'add an employee'");
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("You have selected 'find a sale'");
                        break;
                    }
                case 5:
                    {
                        Environment.Exit(0);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Please enter a number 1-5");
                    }
                    break;
            }

        }
    }
}
