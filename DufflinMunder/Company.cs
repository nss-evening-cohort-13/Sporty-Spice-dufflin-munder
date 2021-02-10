using DufflinMunder.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace DufflinMunder
{
    class Company
    {
        public static List<Employee> SalesEmployees { get; set; } = new List<Employee>();

        public static void addNewEmployee()
        {
            Console.Clear();
            Console.Write("Enter Employee Name: ");
            var employeeName = Console.ReadLine();
            var employee = new SalesEmployee() { Name = employeeName, Department = "Sales" };
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
