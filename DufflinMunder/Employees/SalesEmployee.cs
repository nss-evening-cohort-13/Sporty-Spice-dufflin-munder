using System;
using System.Collections.Generic;
using System.Text;

namespace DufflinMunder.Employees
{
    class SalesEmployee : Employee
    {
        public List<Sale> AllSales { get; set; } = new List<Sale>();

    }
}
