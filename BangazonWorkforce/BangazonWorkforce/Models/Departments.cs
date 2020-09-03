using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BangazonWorkforce.Models
{
    public class Departments
    {
       public int Id { get; set; }

       public string Name { get; set; }

       public int Budget { get; set; }

        List<Employees> listOfEmployees { get; set; } = new List<Employees>();
    }
}
