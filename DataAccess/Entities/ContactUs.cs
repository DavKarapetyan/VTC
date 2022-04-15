using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTC.DataAccess.Entities
{
    public class ContactUs
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
