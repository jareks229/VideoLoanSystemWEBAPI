using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoLoanWebAPI.Models
{
    public class FilmModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public string Gendre { get; set; }
        public string Restrictions { get; set; }
        public bool Avalibility { get; set; }
        public bool Reserved { get; set; }
        public string DateAdded { get; set; }
        public DateTime DateReturn { get; set; }

        public CustomerModel CustomerModel { get; set; }

        public FilmModel()
        {
            Reserved = false;
            DateAdded = DateTime.Now.ToString("MM/dd/yyyy");
        }
    }
}
