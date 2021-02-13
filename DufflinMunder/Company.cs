using DufflinMunder.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DufflinMunder
{
    class Company
    {
        public static List<SalesEmployee> SalesEmployees { get; set; } = new List<SalesEmployee>() { new SalesEmployee("Dwight", "Sales"), new SalesEmployee("Jim", "Sales")};
        public static List<AccountantEmployee> AccountantEmployees { get; set; } = new List<AccountantEmployee>() { new AccountantEmployee("Angela", "Accounting"), new AccountantEmployee("Oscar", "Accounting")};

        public static void addNewEmployee()
        {
            Console.Clear();
            Console.Write("Enter Employee Name: ");
            var employeeName = Console.ReadLine();
            employeeName = char.ToUpper(employeeName[0]) + employeeName.Substring(1);
            var employee = new SalesEmployee(employeeName, "Sales");

            if (SalesEmployees.Any(element => element.Name == employeeName))
            {
                Console.WriteLine("This employee already exists. Please return to the main menu and try again.\n");
                Program.BackToStart();
            } 
            else
            {
                SalesEmployees.Add(employee);
                Console.WriteLine($"\nWelcome to Dufflin Munder, {employeeName}!\n");
                Console.WriteLine("Current Employee Roster:\n");
                foreach (var salesEmployee in SalesEmployees)
                {
                    Console.WriteLine($"{salesEmployee.Name}, {salesEmployee.Department}");
                }

                Console.WriteLine();
                Program.BackToStart();
            }

        }

    }
}
