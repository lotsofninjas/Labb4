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
            string[] monthList = new string[] { "Januari", "Februari", "Mars", "April", "Maj", "Juni", "Juli", "Augusti", "September", "Oktober", "November", "December" };
            ConsoleKeyInfo input;
            char inputChar;
            int choice = 0;
            bool switchLoop = true;
            string firstName;
            string lastName;
            int year;
            int month;
            string strToInt;
            int intFromStr;
            int day = 0;
            string testString;
            string eyeColor;
            DateTime dateOfBirth;
            Gender gender;
            Hair hair;
            string hairColor = "";
            int hairLenght;
            #endregion

            while (switchLoop)
            {
                PrintMenu();

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
                Console.Write("Angelic Good Guys Machine 2000" +
                    "\nGör menyval" +
                    "\n1) Lägga till person till listan" +
                    "\n2) Skriv ut listan i sin helhet" +
                    "\n3) Sök person i listan" +
                    "\n4) Radera person från listan" +
                    "\n0) Avsluta programmet" +
                    "\nVal: ");
            }
            void CheckInput()
            {
                do
                {
                    input = Console.ReadKey();
                    inputChar = input.KeyChar;
                    if (!char.IsDigit(inputChar))
                    {
                        Console.Write("Använd siffror: ");

                    }
                    else
                    {
                        choice = int.Parse(inputChar.ToString());
                        Console.WriteLine();
                    }

                    if (choice < 0 || choice > 4)
                    {

                        Console.Write("1 till 4 finns att välja på: ");
                        input = Console.ReadKey();
                        continue;
                    }
                } while (choice < 0 || choice > 4);


            }
            void AddPerson()
            {
                Console.Clear();
                Console.Write("Förnamn: ");
                firstName = IsStringAString();
                Console.Write("Efternamn: ");
                lastName = IsStringAString();
                Console.Write("Födelseår: ");
                CheckYear();
                Console.WriteLine("Och så månad:");
                for (int i = 0; i < monthList.Length; i++)
                {
                    Console.WriteLine($"{i + 1}) {monthList[i]}");
                }
                Console.Write("svara med siffan: ");
                CheckMonth();
                Console.Write("Datum: ");
                CheckDay();
                Console.Write("Och så har vi ögonfärg: ");
                eyeColor = IsStringAString();
                Console.Write("Kön: ");
                CheckGender();
                Console.Write("Hårfärg: ");
                hairColor = IsStringAString();
                Console.Write("Hårlängd i cm: ");
                CheckHair();
                CreateInstance();

            }
            void CheckYear()
            {
                do
                {
                    year = CheckIfInt();
                    if (year.ToString().Length != 4)
                    {
                        Console.Write("Endast fyrsiffriga tal: ");
                    }
                    else
                    {
                        break;
                    }
                    continue;
                }
                while (true) ;
            }
            void CheckMonth()
            {
                do
                {
                    month = CheckIfInt();
                    if (month < 1 || month > 12)
                    {
                        Console.Write("1 till 12 fanns att välja på: ");
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                while (true);
            }
            void CheckDay()
            {
                do
                {
                    day = CheckIfInt();
                    if (day < 1)
                    {
                        Console.Write($"Tror nog {monthList[month - 1]} har minst en dag, försök igen: ");
                    }
                    else if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
                    {
                        if (day <= 31)
                        {
                            break;
                        }
                        else
                        {
                            Console.Write($"{monthList[month - 1]} hade 30 dagar senaste jag kollade.Försök igen: ");
                        }
                    }
                    else if (month == 4 || month == 6 || month == 9 || month == 11)
                    {
                        if (day <= 30)
                        {
                            break;
                        }
                        else
                        {
                            Console.Write($"{monthList[month - 1]} hade 30 dagar senaste jag kollade.Försök igen: ");
                        }    
                    }
                    else if (month == 2)
                    {
                        if (day > 28)
                        {
                            if (day == 29)
                            {
                                if ((year % 4 != 0 || year % 100 == 0) && year % 400 != 0)
                                {
                                    Console.Write($"{year} var inte ett skottår så några 29 dagar fanns det inte i februari då, försök igen: ");
                                }
                            }
                            else
                            {
                                Console.Write("Nja inte har väl februari någonsin mer än 29 dagar. Försök igen: ");
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }while (true);
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
                Console.Clear();
                Console.WriteLine($"{firstName} är sparad i personlistan\n");
            }
            void ListPersons()
            {
                Console.Clear();
                foreach (Person person in personList)
                {
                    Console.WriteLine(person);
                    Console.WriteLine();
                }
                Console.Write("Enter för att komma vidare.");
                Console.ReadLine();
                Console.Clear();
            }
            void SearchPerson()
            {

            }
            void DeletePerson()
            {

            }
            int CheckIfInt()
            {
                while (true)
                {
                    strToInt = Console.ReadLine();
                    if (int.TryParse(strToInt, out intFromStr))
                    {
                        return intFromStr;
                    }
                    else
                    {
                        Console.Write("Siffror min vän. Försök igen: ");
                    }
                }
            }
            string IsStringAString()
            {
                while(true) 
                {
                    testString = Console.ReadLine();
                    if (string.IsNullOrEmpty(testString))
                    {
                        Console.Write("Något behöver du allt skriva: ");
                        continue;
                    }
                    else if (testString.All(char.IsLetter))
                    {
                        return testString;
                    }
                    else
                    {
                        Console.Write("Inga sifror här. Försök igen: ");
                        continue;
                    }
                }
            }
        }

    }

}
