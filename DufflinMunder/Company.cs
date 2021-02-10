using DufflinMunder.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace DufflinMunder
{
    class Company
    {
        public static List<SalesEmployee> SalesEmployees { get; set; } = new List<SalesEmployee>() { new SalesEmployee("Dwight", "Sales"), new SalesEmployee("Jim", "Sales")};

        public static void addNewEmployee()
        {
            Console.Clear();
            Console.Write("Enter Employee Name: ");
            var employeeName = Console.ReadLine();
            var employee = new SalesEmployee(employeeName, "Sales");
            SalesEmployees.Add(employee);
            Console.WriteLine($"\nWelcome to Dufflin Munder, {employeeName}!\n");
            Console.WriteLine("Current Employee Roster:\n");
            foreach (var salesEmployee in SalesEmployees)
            {
                Console.WriteLine($"{salesEmployee.Name}, {salesEmployee.Department}");
            }
        }

    }
}
