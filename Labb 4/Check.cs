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
        #region variables and stuff
        static readonly string[] monthList = new string[] { "Januari", "Februari", "Mars", "April", "Maj", "Juni", "Juli", "Augusti", "September", "Oktober", "November", "December" };
        static int year;
        static int month;
        static int day;
        static string testString = "";
        static string strToInt = "";
        static int intFromStr;
        static char inputChar;
        static ConsoleKeyInfo input;
        static int hairLenght;
        static string genderString = "";
        static Gender gender;
        static int choice;
        #endregion

        public static string IfString()
        {
            while (true)
            {
                testString = Console.ReadLine()!;

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
            genderString = IfString();

            while (!Enum.TryParse(genderString, true, out gender))
            {
                Console.Write("Man, Kvinna eller Annat: ");
                genderString = Console.ReadLine()!;
            }
            return gender;
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
                strToInt = Console.ReadLine()!;

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
        static bool LeapYear(int yearCheck)
        {
            return (yearCheck % 4 == 0 && yearCheck % 100 != 0) || (yearCheck % 400 == 0);
            /*Det här är den enda koden jag inte skrivit själv. Hämtad från chatGPT rakt av. 
            Matematiken för att räkna ut om ett år är skottår eller inte har jag inte i huvudet :)*/
        }
    }
}
