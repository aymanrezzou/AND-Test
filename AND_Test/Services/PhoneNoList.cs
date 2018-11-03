using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AND_Test.Models;

namespace AND_Test.Services
{
    public static class Global
    {
        private static IList<PhoneNumber> _phoneNumbersList;
    
        public static IList<PhoneNumber> PhoneNumbersList
        {
            get
            {
                if (_phoneNumbersList == null)
                {
                    _phoneNumbersList = new List<PhoneNumber>();
                    _phoneNumbersList.Add(new PhoneNumber { ID = 1, CustID = 1, IsActive = false, PhoneNo = "0724231231" });
                    _phoneNumbersList.Add(new PhoneNumber { ID = 2, CustID = 1, IsActive = true, PhoneNo = "0724231232" });
                    _phoneNumbersList.Add(new PhoneNumber { ID = 3, CustID = 1, IsActive = true, PhoneNo = "0724231233" });
                    _phoneNumbersList.Add(new PhoneNumber { ID = 4, CustID = 2, IsActive = true, PhoneNo = "0124587514" });
                    _phoneNumbersList.Add(new PhoneNumber { ID = 5, CustID = 2, IsActive = true, PhoneNo = "0124587515" });
                    _phoneNumbersList.Add(new PhoneNumber { ID = 6, CustID = 3, IsActive = true, PhoneNo = "1274575714" });
                    _phoneNumbersList.Add(new PhoneNumber { ID = 7, CustID = 4, IsActive = true, PhoneNo = "5424545455" });
                    _phoneNumbersList.Add(new PhoneNumber { ID = 8, CustID = 5, IsActive = true, PhoneNo = "1452454645" });
                    _phoneNumbersList.Add(new PhoneNumber { ID = 9, CustID = 4, IsActive = true, PhoneNo = "6624545455" });
                    _phoneNumbersList.Add(new PhoneNumber { ID = 10, CustID = 5, IsActive = true, PhoneNo = "3352454645" });


                }
                return _phoneNumbersList;
            }
        }
    }
}