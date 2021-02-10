using System;
using System.Collections.Generic;
using System.Text;

namespace DufflinMunder.Employees
{
    class AccountantEmployee : Employee
    {
        public AccountantEmployee(string name, string department)
        {
            Name = name;
            Department = department;
        }
    }
}
