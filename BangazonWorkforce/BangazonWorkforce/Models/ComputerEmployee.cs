using System;

namespace BangazonWorkforce.Models
{
    public class ComputerEmployee
    {
        int Id { get; set; }

        int ComputerId { get; set; }

        Computers computer { get; set; }

        int EmployeeId { get; set; }

        Employees employee { get; set; }

        DateTime AssignDate { get; set; }

        DateTime UnassignDate { get; set; }

    }
}
