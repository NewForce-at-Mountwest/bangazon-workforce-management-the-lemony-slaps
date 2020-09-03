using System.Collections.Generic;

<<<<<<< HEAD

=======
>>>>>>> master
namespace BangazonWorkforce.Models
{
    public class Departments
    {
<<<<<<< HEAD
       public int Id { get; set; }

       public string Name { get; set; }

       public int Budget { get; set; }
=======
        public int Id { get; set; }

        public string Name { get; set; }

        public int Budget { get; set; }
>>>>>>> master

        public int NumofEmployees { get; set; }

        public List<Employees> listOfEmployees { get; set; } = new List<Employees>();
    }
}
