using DufflinMunder.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace DufflinMunder
{
    class Company
    {
        public static List<SalesEmployee> SalesEmployees { get; set; } = new List<SalesEmployee>() { new SalesEmployee("Dwight", "Sales"), new SalesEmployee("Jim", "Sales")};
        public static List<AccountantEmployee> AccountantEmployees { get; set; } = new List<AccountantEmployee>() { new AccountantEmployee("Angela", "Accounting"), new AccountantEmployee("Oscar", "Accounting")};

        public static void AddEmployee(SalesEmployee salesEmployee)
        {
            SalesEmployees.Add(salesEmployee);
        }

    }
}
