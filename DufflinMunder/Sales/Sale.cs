using DufflinMunder.Sales;
using System;
using System.Collections.Generic;
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


        public static void EnterASale()
        {
            Console.WriteLine("Which sales employee are you?");

            for (var i = 0; i < Company.SalesEmployees.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Company.SalesEmployees[i].Name}");
            }

            int employeeSelection = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Hi, {Company.SalesEmployees[employeeSelection - 1].Name}");
        }

    }
}
