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
            Console.WriteLine("Which sales employee are you?");

            for (var i = 0; i < Company.SalesEmployees.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Company.SalesEmployees[i].Name}");
            }

            int employeeSelection = Convert.ToInt32(Console.ReadLine());
            var salesAgent = Company.SalesEmployees[employeeSelection - 1].Name;

            Console.WriteLine($"Hi, {salesAgent}.\n");

            Console.WriteLine("Enter a Sale\n");

            Console.WriteLine($"Sales Agent: {salesAgent}");
            Console.Write("Client: ");
            var client = Console.ReadLine();

            var random = new Random();
            var clientId = random.Next(1000, 9999);
            Console.WriteLine($"ClientID: {clientId}");
            Console.Write("Sale: $");
            var saleAmount = Convert.ToDouble(Console.ReadLine());
            Console.Write("Recurring (Monthly, Annually, or One-Time): ");
            var recurringInput = Console.ReadLine();

            if (recurringInput != "Monthly" && recurringInput != "Annually" && recurringInput != "One-Time")
            {
                Console.Write("Please enter a valid recurring value (Monthly, Annually, or One-Time): ");
                recurringInput = Console.ReadLine();
            }

            Recurring recurring = Recurring.OneTime;

            switch (recurringInput)
            {
                case "Monthly":
                    recurring = Recurring.Monthly;
                    break;
                case "Annually":
                    recurring = Recurring.Annually;
                    break;
                case "One-Time":
                    recurring = Recurring.OneTime;
                    break;
                default:
                    break;
            }

            Console.Write("Time Frame (in months): ");
            int timeFrame = Convert.ToInt32(Console.ReadLine());

            var sale = new Sale(salesAgent, client, clientId, saleAmount, recurring, timeFrame);

            var currentEmployee = Company.SalesEmployees.Find(employee => employee.Name == salesAgent);

            currentEmployee.AddSale(sale);

            foreach (var currentSale in currentEmployee.AllSales)
            {
                Console.WriteLine($"{currentSale.Client}");
            }

        }

    }
}
