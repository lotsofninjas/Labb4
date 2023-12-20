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
            #region variables and lists
            List<Person> personList = new List<Person>();
            int choice;
            bool switchLoop = true;
            string firstName;
            string lastName;
            int year;
            int month;
            int day;
            string eyeColor;
            DateTime dateOfBirth;
            Gender gender;
            Hair hair;
            Person person;
            string hairColor;
            int hairLenght;
            string searchName;
            int counter;
            #endregion

            while (switchLoop)
            {
                PrintMenu();

                choice = Check.Input();

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
                        DeletePerson();
                        break;
                    case 0:
                        switchLoop = false;
                        break;
                }
            }
            Console.ReadLine();

            void PrintMenu()
            {
                Console.WriteLine("Angelic Good Guys Machine 2000" +
                    "\nGör menyval" +
                    "\n1) Lägga till person till listan" +
                    "\n2) Skriv ut listan i sin helhet" +
                    "\n3) Sök person i listan" +
                    "\n4) Radera person från listan" +
                    "\n0) Avsluta programmet");
            }
            void AddPerson()
            {
                Console.Clear();
                Console.Write("Förnamn: ");
                firstName = Check.IfString();
                Console.Write("Efternamn: ");
                lastName = Check.IfString();
                Console.Write("Födelseår: ");
                year = Check.Year();
                Console.Write("Och så månadens siffa: ");
                month = Check.Month();
                Console.Write("Datum: ");
                day = Check.Day();
                Console.Write("Och så har vi ögonfärg: ");
                eyeColor = Check.IfString();
                Console.Write("Kön: ");
                gender = Check.Gender();
                Console.Write("Hårfärg: ");
                hairColor = Check.IfString();
                Console.Write("Hårlängd i cm: ");
                hairLenght = Check.Hair();
                CreateInstance();

            }
            void CreateInstance()
            {
                dateOfBirth = new DateTime(year, month, day);
                hair = new Hair
                {
                    HairColor = hairColor,
                    HairLength = hairLenght
                };
                person = new Person(firstName, lastName, dateOfBirth, eyeColor, gender, hair);
                personList.Add(person);
                Console.Clear();
                Console.WriteLine($"{firstName} är sparad i personlistan\n");
            }
            void ListPersons()
            {
                Console.Clear();
                if (personList.Count == 0)
                {
                    Console.WriteLine("Det finns inga personer i listan.");
                    Console.Write("\nEnter för att komma vidare.");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    foreach (Person person in personList)
                    {
                        Console.WriteLine(person);
                        Console.WriteLine();
                        Console.Write("Enter för att komma vidare.");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
                
            }
            void SearchPerson()
            {
                Console.Clear();
                counter = 0;
                if (personList.Count == 0)
                {
                    Console.WriteLine("Det finns inga personer i listan.");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.Write("Ange förnamn att söka efter: ");
                    searchName = Check.IfString();
                    Console.Clear();
                    foreach (Person person in personList)
                    {
                        if (person.FirstName == searchName)
                        {
                            Console.Write(person);
                            Console.WriteLine("\n\nEnter för att fortsätta.");
                            Console.ReadLine();
                            Console.Clear();
                            counter++;
                        }
                        else if (counter == 0)
                        {
                            Console.WriteLine($"{searchName} finns inte med i listan");
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }
                }

            }
            void DeletePerson()
            {
                Console.Clear();
                counter = 0;
                if (personList.Count == 0)
                {
                    Console.WriteLine("Det finns inga personer i listan.");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.Write("Ange förnamn att söka efter: ");
                    searchName = Check.IfString();
                    foreach (Person person in personList)
                    {
                        if (person.FirstName == searchName)
                        {
                            personList.Remove(person);
                            Console.WriteLine($"\n{searchName} är borttagen");
                            Console.ReadLine();
                            Console.Clear();
                            if (personList.Count == 0)
                            {
                                break;
                            }
                            counter++;
                        }
                        else if (counter == 0)
                        {
                            Console.WriteLine($"{searchName} finns inte med i listan");
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }
                }
            }
        }
    }
}
