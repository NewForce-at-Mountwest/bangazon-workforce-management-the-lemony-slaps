using System;

namespace BangazonWorkforce.Models
{
    public class TrainingPrograms
    {
        int Id { get; set; }

        string Name { get; set; }

        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }

        int MaxAttendees { get; set; }
    }
}
