using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_4
{
    public class Person
    {
        public string FirstName { get; set; }
        private string LastName { get; set; }
        private DateTime DateOfBirth { get; set; }
        private string EyeColor { get; set; }
        private Gender Gender { get; set; }
        private Hair Hair { get; set; }



        public Person(string firstName, string lastName, DateTime dateOfBirth, string eyeColor, Gender gender, Hair hair)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            EyeColor = eyeColor;
            Gender = gender;
            Hair = hair;
        }

        public override string ToString()
        {
            return $"Information om {FirstName} {LastName}: " +
                $"\nFödelsedatum: {DateOfBirth.ToString("yy/MM/dd", CultureInfo.InvariantCulture)}" +
                $"\nÖgonfärg: {EyeColor}" +
                $"\nKön: {Gender}" +
                $"\nHårfärg: {Hair.HairColor}" +
                $"\nHårlängd: {Hair.HairLength} cm";
        }
    }
}
