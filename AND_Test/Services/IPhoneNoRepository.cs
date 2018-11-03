using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AND_Test.Models;

namespace AND_Test.Services
{
    public interface IPhoneNoRepository
    {
        IList<PhoneNumber> GetAll();
        IList<PhoneNumber> GetAllForCustomer(int cusID);

        bool MakeItActive(int PhoneNoID);
    }
}