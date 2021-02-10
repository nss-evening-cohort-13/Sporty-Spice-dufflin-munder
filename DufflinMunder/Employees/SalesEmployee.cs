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

    }
}
