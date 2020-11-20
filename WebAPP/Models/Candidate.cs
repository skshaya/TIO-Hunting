﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPP.Models
{
    public class Candidate
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
    }
}
