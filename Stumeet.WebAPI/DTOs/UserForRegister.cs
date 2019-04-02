using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stumeet.WebAPI.DTOs
{
    public class UserForRegister
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int UniversityID { get; set; }
    }
}
