using System;
using System.Collections.Generic;
using System.Text;

namespace DufflinMunder.Employees
{
    class SalesEmployee : Employee
    {
        public List<Sale> AllSales { get; set; } = new List<Sale>();

        public SalesEmployee(string name, string department)
        {
            Name = name;
            Department = department;
        }

        public void AddSale(Sale currentSale)
        {
            AllSales.Add(currentSale);
        }

        public void PrintClients()
        {
            var clients = new HashSet<string>();
            var c = 1;
            AllSales.ForEach(sale =>
            {
                clients.Add(sale.Client);
            });
            foreach (var client in clients)
            {
                Console.Write($"\t\t{c}. {client}\n");
                c++;
            }
        }

        public double SumSales()
        {
            double sum = 0;
            AllSales.ForEach(sale => sum += sale.SaleAmount);
            return sum;
        }

    }
}
