using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Labb_4
{
    static class Check
    {
        #region variables and lists
        static string[] monthList = new string[] { "Januari", "Februari", "Mars", "April", "Maj", "Juni", "Juli", "Augusti", "September", "Oktober", "November", "December" };
        static int year;
        static int month;
        static int day;
        static string testString;
        static string strToInt;
        static int intFromStr;
        static char inputChar;
        static ConsoleKeyInfo input;
        static int hairLenght;
        static string genderString;
        static Gender gender;
        static int choice;
        #endregion

        public static string IfString()
        {
            while (true)
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
        public static int Input()
        {
            do
            {
                input = Console.ReadKey();
                inputChar = input.KeyChar;

                if (!char.IsDigit(inputChar))
                {
                    Console.Write("\nAnvänd siffror: ");
                }
                else
                {
                    choice = int.Parse(input.KeyChar.ToString());
                }

                if (choice < 0 || choice > 4)
                {

                    Console.Write("\n0 till 4 finns att välja på: ");
                    input = Console.ReadKey();
                }
            } while (choice < 0 || choice > 4 || !char.IsDigit(inputChar));

            return choice;
        }
        public static int Year()
        {
            do
            {
                year = IfInt();
                if (year.ToString().Length != 4)
                {
                    Console.Write("Endast fyrsiffriga tal: ");
                }
                else
                {
                    break;
                }
            }
            while (true);
            return year;
        }
        public static int Month()
        {
            do
            {
                month = IfInt();
                if (month < 1 || month > 12)
                {
                    Console.Write("1 till 12 fanns att välja på: ");
                }
                else
                {
                    break;
                }
            }
            while (true);
            return month;
        }
        public static int Day()
        {
            do
            {
                day = IfInt();
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
                            if (!LeapYear(year))
                            {
                                Console.Write($"{year} var inte ett skottår så några 29 dagar fanns det inte i februari då, försök igen: ");
                            }
                            else
                            {
                                break;
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
            } while (true);
            return day;
        }
        public static Gender Gender()
        {
            genderString = Console.ReadLine();
            while (!Enum.TryParse(genderString, true, out gender))
            {
                Console.Write("Man, Kvinna eller Annat: ");
                genderString = Console.ReadLine();
            }
            return gender;
            /*Det här är den andra delen i programmet som jag inte skrivit själv. Kopierad rakt av från chatGPT. Hade jag inte förstått vad koden gör hade jag inte använt den.
            Dock ska sägas att förslaget jag fick var while (!Enum.TryParse(Console.ReadLine(), true, out gender) || !Enum.IsDefined(typeof(Gender), gender)) men när jag dök djupare i vad delarna gjorde insåg jag att jag kunde ta bort IsDefined.
            Att jag kör IsStringAString beror på att annars hade 0, 1 och 2 varit acceptabla värden för !Enum.TryParse som matchas mot index i enum istället för sjävla ordet. 
            Jag tror även att alla tal hade fungerat genom input % antal i enum. Ex 5 % 3 = 3 / 3 med resten 2 som hade gett oss Gender.Annat.
            Jag skrev en egen lösning där jag först testade en if-sats med if (int.TryParse) else if (input == "Man" || input == "Kvinna osv)  {gender = Gender.input}. Men det gick ju inte. 
            Så då gjorde jag en else if för varje kön: else if (input == "Man" || input == "man") {gender = Gender.Man} osv. 
            Aldrig arbetat med en enum innan så började från scratch.
            Det här var innan jag skapat metoden CheckIfString som senare hade fått tagit över för Try.Parse om jag hade använt den koden
            Mycket kod för något simpelt så jag ville lära mig hur man gjorde det effektivare och ser ingen mening med att skriva om koden från chatGPT i det här fallet mer än att ta bort det som var överflödigt.*/
        }
        public static int Hair()
        {
            while (!int.TryParse(Console.ReadLine(), out hairLenght))
            {
                Console.Write("Längden anger vi med siffror: ");
            }
            return hairLenght;
        }
        static int IfInt()
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
        static bool LeapYear(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
            /*Det här är den första av två delar i programmet jag inte skrivit själv. Hämtad från chatGPT rakt av. 
            Matematiken för att räkna ut om ett år är skottår eller inte har jag inte i huvudet :)*/
        }
    }
}
