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
            string searchName;
            int counter;
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
                Console.Write("Och så månadens siffa: ");
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
                            Console.Write($"{monthList[month - 1]} hade 31 dagar senaste jag kollade.Försök igen: ");
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
                                /*Det här är den första av två delar i programmet jag inte skrivit själv. Hämtad från chatGPT rakt av. 
                                Det är if-villkoret som jag hämtat, att ha en matematiskt formel i huvdet för att räkna ut vad som är ett skottår är väl inte rimligt tycker jag.
                                Jag förstår vad den gör. Kollar så att året inte är delbart med 4 eller om det är delbart med 100 och att det inte är delbart med 400 */
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
                while (!Enum.TryParse(Console.ReadLine(), true, out gender))
                {
                    Console.Write("Man, Kvinna eller Annat: ");
                }

                /*Det här är den andra delen i programmet som jag inte skrivit själv. Kopierad rakt av från chatGPT. Hade jag inte förstått vad koden gör hade jag inte använt den.
                Dock ska sägas att förslaget jag fick var while (!Enum.TryParse(Console.ReadLine(), true, out gender) || !Enum.IsDefined(typeof(Gender), gender)) men när jag dök djupare i vad delarna gjorde insåg jag att jag kunde ta bort IsDefined.
                Att jag kör IsStringAString beror på att annars hade 0, 1 och 2 varit acceptabla värden för !Enum.TryParse som matchas mot index i enum istället för sjävla ordet. 
                Jag tror även att alla tal hade fungerat genom input % antal i enum. Ex 5 % 3 = 3 / 3 med resten 2 som hade gett oss Gender.Annat.
                Jag skrev en egen lösning där jag först testade en if-sats med if (int.TryParse) else if (input == "Man" || input == "Kvinna osv)  {gender = Gender.input}. Men det gick ju inte. 
                Så då gjorde jag en else if för varje kön: else if (input == "Man" || input == "man") {gender = Gender.Man} osv. 
                Aldrig arbetat med en enum innan så började från scratch.
                Det här var innan jag skapat metoden IsStringAString som senare hade fått tagit över för Try.Parse om jag hade använt den koden
                Mycket kod för något simpelt så jag ville lära mig hur man gjorde det effektivare och ser ingen mening med att skriva om koden från chatGPT i det här fallet mer än att ta bort det som var överflödigt.*/
            }
            void CheckHair()
            {
                while (!int.TryParse(Console.ReadLine(), out hairLenght))
                {
                    Console.Write("Längden anger vi med siffror: ");
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
                    searchName = IsStringAString();
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
                    searchName = IsStringAString();
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
                        
                    }
                    else if (testString.All(char.IsLetter))
                    {
                        return testString;
                    }
                    else
                    {
                        Console.Write("Inga sifror här. Försök igen: ");
                        
                    }
                }
            }
        }
    }
}
