using Labb_4;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Labb_4
{
    class Program
    {
        private static void Main(string[] args)
        {
            #region variables and list
            List<Person> personList = new List<Person>();
            int choice;
            bool switchLoop = true;
            string firstName;
            string lastName;
            int year;
            int month;
            int day = 0;
            string eyeColor;
            DateTime dateOfBirth;
            Gender gender;
            Hair hair;
            string hairColor;
            int hairLenght;
            #endregion

            while (switchLoop)
            {
                Console.WriteLine("Angelic Good Guys Machine 2000" +
                    "\nGör menyval" +
                    "\n1) Lägga till person till listan" +
                    "\n2) Skriv ut listan i sin helhet" +
                    "\n3) Sök person i listan" +
                    "\n4) Radera person från listan" +
                    "\n0) Avsluta programmet");
                CheckInput();
                switch (choice)
                {
                    case 1:
                        AddPerson();
                        break;
                    case 2:
                        ListPersons();
                        break;
                    case 3:
                        SearchPerson();
                        break;
                    case 4:
                        break;
                    case 0:
                        switchLoop = false;
                        break;
                }
            }
            Console.ReadLine();
            void CheckInput()
            {
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 4)
                {

                    Console.Write("1 till 4 finns att välja på: ");
                    continue;
                }
            }
            void AddPerson()
            {
                Console.Write("Förnamn: ");
                firstName = Console.ReadLine();
                Console.Write("Efternamn: ");
                lastName = Console.ReadLine();
                Console.Write("Födelseår: ");
                CheckYear();
                Console.Write("Och så månad:" +
                    "\n1) Januari" +
                    "\n2) Februari" +
                    "\n3) Mars" +
                    "\n4) April" +
                    "\n5) Maj" +
                    "\n6) Juni" +
                    "\n7) Juli" +
                    "\n8) Augusti" +
                    "\n9) September" +
                    "\n10) Oktober" +
                    "\n11) November" +
                    "\n12) December" +
                    "\nsvara med siffan :");
                CheckMonth();
                Console.Write("Datum: ");
                CheckDay();
                Console.Write("Och så har vi ögonfärg: ");
                eyeColor = Console.ReadLine();
                Console.Write("Kön: ");
                CheckGender();
                Console.Write("Hårfärg: ");
                hairColor = Console.ReadLine();
                Console.Write("Längd på håret: ");
                CheckHair();
                CreateInstance();

            }
            void CheckYear()
            {
                while (!int.TryParse(Console.ReadLine(), out year) || year.ToString().Length != 4)
                {
                    Console.Write("Endast fyrsiffriga tal: ");
                    continue;
                }
            }
            void CheckMonth()
            {
                while (!int.TryParse(Console.ReadLine(), out month) || month < 1 || month > 12)
                {
                    Console.Write("1 till 12 fanns att välja på: ");
                    continue;
                }
            }
            void CheckDay()
            {
                if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
                {
                    while (!int.TryParse(Console.ReadLine(), out day))
                    {
                        if (day < 1)
                        {
                            Console.Write("Tror nog månaden har minst en dag, försök igen: ");
                            continue;
                        }
                        else if (day > 31)
                        {
                            Console.Write("Riktigt så många dagar tror jag inte månaden har försök igen: ");
                            continue;
                        }
                    }
                }
                else if (month == 4 || month == 6 || month == 9 || month == 11)
                {
                    while (!int.TryParse(Console.ReadLine(), out day))
                    {
                        if (day < 1)
                        {
                            Console.Write("Tror nog månaden har minst en dag, försök igen: ");
                            continue;
                        }
                        else if (day > 31)
                        {
                            Console.Write("Riktigt så många dagar tror jag inte månaden har försök igen: ");
                            continue;
                        }
                    }
                }
                else
                {
                    while (!int.TryParse(Console.ReadLine(), out day))
                    {
                        if (day < 1)
                        {
                            Console.Write("Tror nog månaden har minst en dag, försök igen: ");
                            continue;
                        }
                        else if (day > 28)
                        {
                            if (day == 29)
                            {
                                if ((year % 4 != 0 || year % 100 == 0) && year % 400 != 0)
                                {
                                    Console.Write($"{year} var inte ett skottår så några 29 dagar fanns det inte i februari då, försök igen: ");
                                    continue;
                                }
                            }
                        }
                    }
                }
            }
            void CheckGender()
            {
                while (!Enum.TryParse(Console.ReadLine(), true, out gender) || !Enum.IsDefined(typeof(Gender), gender))
                {
                    Console.Write("Man, Kvinna eller Annat: ");
                    continue;
                }
            }
            void CheckHair()
            {
                while (!int.TryParse(Console.ReadLine(), out hairLenght))
                {
                    Console.Write("Längden anger vi med siffror: ");
                    continue;
                }
            }
            void CreateInstance()
            {
                dateOfBirth = new DateTime(year, month, day);
                hair = new Hair
                {
                    HairColor = hairColor,
                    HairLength = hairLenght
                };
                Person person = new Person(firstName, lastName, dateOfBirth, eyeColor, gender, hair);
                personList.Add(person);
            }
            void ListPersons()
            {
                foreach (Person person in personList)
                {
                    Console.WriteLine(person);
                }
            }
            void SearchPerson()
            {

            }


        }

    }

}
