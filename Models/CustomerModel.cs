using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoLoanWebAPI.Models
{
    public class CustomerModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public int FilmsLoaned { get; set; }
    }
}
