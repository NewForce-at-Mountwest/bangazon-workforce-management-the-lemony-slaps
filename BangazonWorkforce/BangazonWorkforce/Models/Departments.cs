using System.Collections.Generic;

namespace BangazonWorkforce.Models
{
    public class Departments
    {

       public int Id { get; set; }

       public string Name { get; set; }

       public int Budget { get; set; }



        public int NumofEmployees { get; set; }

        public List<Employees> listOfEmployees { get; set; } = new List<Employees>();
    }
}
