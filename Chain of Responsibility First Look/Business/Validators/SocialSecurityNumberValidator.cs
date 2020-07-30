using System;
using System.Globalization;

namespace Chain_of_Responsibility_First_Look.Business.Validators
{
    public class SocialSecurityNumberValidator
    {
        public bool Validate(string socialSecurityNumber, RegionInfo citizenshipRegion)
        {
            _ = socialSecurityNumber;

            _ = citizenshipRegion;

            return true;
        }
    }
}