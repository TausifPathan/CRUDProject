using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project.Models
{
    public class HR : Employee
    {
        public int HRId { get; set; }

        public string Email { get; set; }

        public DateTime DOJ { get; set; }

        public int MobileNo { get; set; }
    }
}