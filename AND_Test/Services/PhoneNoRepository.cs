using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AND_Test.Models;

namespace AND_Test.Services
{
    public class PhoneNoRepository:IPhoneNoRepository
    {
        private   IList<PhoneNumber> phoneNumbers;

        public PhoneNoRepository()
        {
            phoneNumbers = Global.PhoneNumbersList;
        }
        public PhoneNoRepository(IEnumerable<PhoneNumber> phoneNumbersList)
        {
                phoneNumbers = new List<PhoneNumber>();
                phoneNumbers = phoneNumbersList.ToList<PhoneNumber>();

        }

        public bool MakeItActive(int PhoneNoID)
        {
            try
            {
                phoneNumbers.FirstOrDefault(x => x.ID == PhoneNoID).IsActive = true;
                
                return true;
            }
            catch { return false; }
        }

        public IList<PhoneNumber> GetAll()
        {
            return phoneNumbers;
        }

        public IList<PhoneNumber> GetAllForCustomer(int cusID)
        {
            try
            {
                return phoneNumbers.Where(x => x.CustID == cusID).ToList<PhoneNumber>();
            }
            catch { return null; }
        }

       
  
    }
}