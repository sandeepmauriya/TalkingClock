using System;

namespace TalkingClock
{
    class Program
    {
        static void Main(string[] args)
        {
            GetCurrentTime();
            Console.WriteLine();
            Console.WriteLine("Enter any other Time to get talking clock time");
            string strTime = Console.ReadLine();
            CheckvalidTime(strTime);
        }

        static void GetCurrentTime()
        {
            string time = DateTime.Now.ToString("h:mm");
            Console.WriteLine("The Current Time is :-");
            Console.WriteLine();
            TalkingClock(time);

        }
        static void CheckvalidTime(string strTime)
        {
            int value;
            value = IsTimeValid(strTime);
            if (value == 1)
            {

                TalkingClock(strTime);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("this is not a valid time");
                Console.WriteLine();
                Console.WriteLine("Please Enter another time");
                string anotherTime = Console.ReadLine();
                CheckvalidTime(anotherTime);

            }
        }
        static void TalkingClock(string strTime)
        {
            int h;
            int m;

            string[] splitTime = strTime.Split(":");
            h = Convert.ToInt32(splitTime[0]);
            m = Convert.ToInt32(splitTime[1]);

            if (m == 0)
                Console.WriteLine(GetTwelveHourFormat(h) + " o' clock ");

            else if (m == 1)
                Console.WriteLine("one minute past " + GetTwelveHourFormat(h));

            else if (m == 59)
                Console.WriteLine("one minute to " +
                                    NumberToText((Convert.ToInt32(ConvertToTwelve(h)) % 12) + 1));

            else if (m == 15)
                Console.WriteLine("quarter past " + GetTwelveHourFormat(h));

            else if (m == 30)
                Console.WriteLine("half past " + GetTwelveHourFormat(h));

            else if (m == 45)
                Console.WriteLine("quarter to " +
                                    NumberToText((Convert.ToInt32(ConvertToTwelve(h)) % 12) + 1));

            else if (m <= 30)
                Console.WriteLine(NumberToText(m) + " minutes past " +
                                                        GetTwelveHourFormat(h));

            else if (m > 30)
                Console.WriteLine(NumberToText(60 - m) + " minutes to " +
                                                NumberToText((Convert.ToInt32(ConvertToTwelve(h)) % 12) + 1));
        }

        static string NumberToText(int number)
        {

            string[] nums = { "zero", "one", "two", "three", "four",
                            "five", "six", "seven", "eight", "nine",
                            "ten", "eleven", "twelve", "thirteen",
                            "fourteen", "fifteen", "sixteen", "seventeen",
                            "eighteen", "nineteen", "twenty", "twenty one",
                            "twenty two", "twenty three", "twenty four",
                            "twenty five", "twenty six", "twenty seven",
                            "twenty eight", "twenty nine",
                        };
            return nums[number];
        }
        static string GetTwelveHourFormat(int number)
        {

            string[] nums = { "zero", "one", "two", "three", "four",
                            "five", "six", "seven", "eight", "nine",
                            "ten", "eleven", "twelve", "one",
                            "two", "three", "four", "five",
                            "six", "seven", "eight", "nine",
                            "ten", "eleven", "twelve",
                        };
            return nums[number];
        }

        static string ConvertToTwelve(int number)
        {

            string[] nums = { "0", "1", "2", "3", "4",
                            "5", "6", "7", "8", "9",
                            "10", "11", "12", "1",
                            "2", "3", "4", "5",
                            "6", "7", "8", "9",
                            "10", "11", "12",
                        };
            return nums[number];
        }
        

        static int IsTimeValid(String n)
        {

            int val = 0;
            int val1, val2, val3, len;
            char[] charattay = n.ToCharArray();
            val1 = (int)charattay[0];
            val2 = (int)charattay[1];
            val3 = (int)charattay[3];

            len = n.Length;
            if ((len > 2) && (val1 >= 48 && val1 <= 57) && (val2 >= 48 && val2 <= 57) &&
            (charattay[2] == ':') && (val3 >= 48 && val3 <= 53))
            {
                string[] splitTime = n.Split(":");
                if (Convert.ToInt32(splitTime[0]) < 25 && Convert.ToInt32(splitTime[1]) < 60)
                {
                    val = 1;
                }
                else
                {
                    val = -1;
                }

            }
            else
            {
                val = -1;
            }
            return val;
        }
      
    }
}
