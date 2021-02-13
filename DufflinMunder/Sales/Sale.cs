using DufflinMunder.Employees;
using DufflinMunder.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DufflinMunder
{
    class Sale
    {
        public string SalesAgent { get; set; }
        public string Client { get; set; }
        public int ClientId { get; set; }
        public double SaleAmount { get; set; }
        public Recurring Recurring { get; set; }
        public int TimeFrameInMonths { get; set; }

        public Sale(string salesAgent, string client, int clientId, double saleAmount, Recurring recurring, int timeFrame)
        {
            SalesAgent = salesAgent;
            Client = client;
            ClientId = clientId;
            SaleAmount = saleAmount;
            Recurring = recurring;
            TimeFrameInMonths = timeFrame;
        }

        public static void EnterASale()
        {
            Console.Clear();
            // User entry for sales employee selection
            var salesAgent = "";
            int employeeSelection = 0;
            Console.WriteLine("Which sales employee are you?");

            for (var i = 0; i < Company.SalesEmployees.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Company.SalesEmployees[i].Name}");
            }
            var selection = Console.ReadLine();
            try
            {
                employeeSelection = Convert.ToInt32(selection);
                salesAgent = Company.SalesEmployees[employeeSelection - 1].Name;
            }
            catch (FormatException)
            {
                string employeeName = Convert.ToString(selection);
                foreach (var employee in Company.SalesEmployees)
                {
                    if (employee.Name.ToLower() == employeeName.ToLower())
                    {
                        salesAgent = employeeName;
                    }
                    else
                    {
                        Console.WriteLine($"Please enter a number 1-{Company.SalesEmployees.Count()} to select an employee. Please return to the main menu and try again.\n");
                        Program.BackToStart();
                    }
                }
            }

            Console.Clear();
            Console.WriteLine($"Hi, {salesAgent}.\n");

            // Enter a Sale method begins
            Console.WriteLine("Enter a Sale\n");

            // Sales agent is automatically generated from previous selection
            Console.WriteLine($"Sales Agent: {salesAgent}");

            // User entry for client name
            Console.Write("Client: ");
            var client = Console.ReadLine();
            var random = new Random();
            var clientId = random.Next(1000, 9999);

            foreach (var employee in Company.SalesEmployees)
            {
                foreach (var completedSale in employee.AllSales)
                {
                    if (completedSale.Client.ToLower() == client.ToLower())
                    {
                        clientId = completedSale.ClientId;
                    }
                }
            }

            Console.WriteLine($"ClientID: {clientId}");

            // User entry for sale amount
            Console.Write("Sale: $");
            double saleAmount = 0.0;

            try
            {
                saleAmount = Convert.ToDouble(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine($"Please enter a number for the sale amount. Please return to the main menu and try again.\n");
                Program.BackToStart();
            }

            // User entry for recurring value
            Console.Write("Recurring (Monthly, Annually, or One-Time): ");
            var recurringInput = Console.ReadLine().ToLower();

            Recurring recurring = Recurring.OneTime;

            if (recurringInput != "monthly" && recurringInput != "annually" && recurringInput != "one-time")
            {
                Console.Write("Please enter a valid recurring value: ");
                recurringInput = Console.ReadLine().ToLower();
            }

            if (recurringInput == "monthly" || recurringInput == "annually" || recurringInput == "one-time")
            {
                switch (recurringInput)
                {
                    case "monthly":
                        recurring = Recurring.Monthly;
                        break;
                    case "annually":
                        recurring = Recurring.Annually;
                        break;
                    case "one-time":
                        recurring = Recurring.OneTime;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("You did not enter a valid value. Please return to the main menu and try again.\n");
                Program.BackToStart();
            }

            // User entry for time frame
            Console.Write("Time Frame (in months): ");
            int timeFrame = 0;

            try
            {
                timeFrame = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine($"Please enter a number of months for the time frame. Please return to the main menu and try again.\n");
                Program.BackToStart();
            }

            // Add the sale to that employee class and return to main menu
            var sale = new Sale(salesAgent, client, clientId, saleAmount, recurring, timeFrame);
            var currentEmployee = Company.SalesEmployees.Find(employee => employee.Name == salesAgent);
            currentEmployee.AddSale(sale);

            Console.WriteLine($"\nYour sale was added!\n");

            Program.BackToStart();

        }
        public static void FindASale()
        {
            Console.Clear();
            Console.Write("Would you like to search by client name or client ID? \n1. Client ID\n2. Client Name\n");

            var searchSelection = Console.ReadLine();
            var foundSales = new List<Sale>();
            switch (searchSelection)
            {
                case "1":
                    Console.Write("Please enter client ID: ");
                    var id = Convert.ToInt32(Console.ReadLine());
                    foreach (var employee in Company.SalesEmployees)
                    {
                        foreach (var sale in employee.AllSales)
                        {
                            if (sale.ClientId == id)
                            {
                                foundSales.Add(sale);
                            }
                        }
                    }
                    break;
                case "2":
                    Console.Write("Please enter client name: ");
                    var clientName = Console.ReadLine();
                    foreach (var employee in Company.SalesEmployees)
                    {
                        foreach (var sale in employee.AllSales)
                        {
                            if (sale.Client == clientName)
                            {
                                foundSales.Add(sale);
                            }
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Unavailable option, would you like to try again or go back to the main menu?: \n1.Try Again \n2.Main Menu");
                    var selection = Convert.ToInt32(Console.ReadLine());
                    if (selection == 1)
                    {
                        Console.Clear();
                        FindASale();
                    }
                    else
                    {
                        Program.BackToStart();
                    }
                    break;
            }


            foreach (var foundSale in foundSales)
            {
                Console.WriteLine($"{foundSale.SalesAgent} sold {foundSale.Client} ${foundSale.SaleAmount} of product on a {foundSale.Recurring} basis recurring for {foundSale.TimeFrameInMonths} months");
            }
            if (foundSales.Count == 0)
            {
                Console.WriteLine("\nNo sales found for that client");
            }
            Console.WriteLine();

            Program.BackToStart();
        }
    }
}

