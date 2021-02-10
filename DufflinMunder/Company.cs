using DufflinMunder.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace DufflinMunder
{
    class Company
    {
        public static List<SalesEmployee> SalesEmployees { get; set; } = new List<SalesEmployee>() { new SalesEmployee("Dwight", "Sales"), new SalesEmployee("Jim", "Sales")};

        public static void AddEmployee(SalesEmployee salesEmployee)
        {
            SalesEmployees.Add(salesEmployee);
        }

    }
}
