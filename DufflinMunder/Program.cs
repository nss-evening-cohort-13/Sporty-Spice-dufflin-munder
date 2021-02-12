using System;
using DufflinMunder.Employees;

namespace DufflinMunder
{
    class Program
    {
        static void Main(string[] args)
        {
            var dufflinMunder = new Company();
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
                        Sale.EnterASale();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("You have selected 'generate a report'");
                        break;
                    }
                case 3:
                    {
                        Company.addNewEmployee();
                        break;
                    }
                case 4:
                    {
                        Console.Write("To find a sale, please enter the unique client id: ");
                        var id = Console.ReadLine();
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
