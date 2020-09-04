using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonWorkforce.Models.ViewModels
{
    public class EmployeeEditViewModel
    {
        public Employees employee { get; set; }
        public Computers computer { get; set; }
        public int currentCompId { get; set; }


        // This will be our dropdown
        public List<SelectListItem> departments { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> computers { get; set; } = new List<SelectListItem>();
    }
}
