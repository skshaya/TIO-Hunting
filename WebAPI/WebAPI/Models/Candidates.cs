using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Candidates
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
        public string Experience { get; set; }
        public DateTime DOB { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsEnable { get; set; }

        public string Interviewer { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Comments { get; set; }
    }
}
