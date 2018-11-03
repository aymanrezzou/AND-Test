using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AND_Test.Models
{
    public class PhoneNumber
    {
        public int ID { get; set; }
        public int CustID { get; set; }

        public string PhoneNo { get; set; }

        public bool IsActive { get; set; }
    }
}