using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BangazonWorkforce.Models;

namespace BangazonWorkforce.Models
{
    public class Employees
    {
       public int Id { get; set; }

       public string FirstName { get; set; }

       public string LastName { get; set; }

       public int DepartmentId { get; set; }

        Departments department { get; set; }

        bool isSupervisor { get; set; }

        Computers computer { get; set; }

    }
}
