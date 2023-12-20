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
        public string FirstName { get; }
        private string LastName { get; }
        private DateTime DateOfBirth { get; }
        private string EyeColor { get; }
        private Gender Gender { get; }
        private Hair Hair { get; }



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
