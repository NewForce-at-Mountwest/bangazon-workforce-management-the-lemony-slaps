using System;
using System.Collections.Generic;

namespace BangazonWorkforce.Models
{
    public class TrainingPrograms
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int MaxAttendees { get; set; }

        public List<Employees> AttendingEmployees = new List<Employees>();
    }
}
