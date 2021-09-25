using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Samples.Models
{
    class Employee
    {
        public int EmployeeID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        
        public string Country { get; set; }
        public int ReportsTo { get; set; }
        public string Extension { get; set; }
    }
}
