using System;
using System.Globalization;

namespace Chain_of_Responsibility_First_Look.Business.Models
{
    public class User
    {
        public User(string name, string socialSecurityNumber, RegionInfo citizenshipRegion, DateTimeOffset birthDate)
        {
            Name = name;
            SocialSecurityNumber = socialSecurityNumber;
            CitizenshipRegion = citizenshipRegion;
            BirthDate = birthDate;
            Age = CalculateAge(BirthDate.Date);
        }

        public string Name { get; set; }
        public string SocialSecurityNumber { get; set; }
        public RegionInfo CitizenshipRegion { get; set; }
        public int Age { get; set; }
        public DateTimeOffset BirthDate { get; set; }

        private static int CalculateAge(DateTime birthdate) //08.08.1990
        {
            // Save today's date.
            var today = DateTime.Today; //20.01.2020

            // Calculate the age.
            var age = today.Year - birthdate.Year; //30

            // Go back to the year the person was born in case of a leap year
            if (birthdate.Date > today.AddYears(-age)) age--;

            return age;
        }
    }
}