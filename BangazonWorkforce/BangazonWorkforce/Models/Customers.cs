using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonWorkforce.Models
{
    public class Customers
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AccountCreated { get; set; }

        public string LastActive { get; set; }

        public List<PaymentTypes> listOfPaymentTypes { get; set; } = new List<PaymentTypes>();

        public List<Products> listOfProducts { get; set; } = new List<Products>();

    }
}
