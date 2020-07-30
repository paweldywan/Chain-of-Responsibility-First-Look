using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chain_of_Responsibility_First_Look.Business.Exceptions
{
    public class UserValidationException : SystemException
    {
        public UserValidationException(string message) : base(message)
        {
        }
    }
}
