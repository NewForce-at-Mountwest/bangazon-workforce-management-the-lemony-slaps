using System;

namespace BangazonWorkforce.Models
{
    public class ComputerEmployee
    {
        public int Id { get; set; }

        public int ComputerId { get; set; }

        public Computers computer { get; set; }

        public int EmployeeId { get; set; }

        public Employees employee { get; set; }

        public DateTime AssignDate { get; set; }

        public DateTime UnassignDate { get; set; }

    }
}
