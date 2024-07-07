using System;

namespace DateCheck
{
    internal class Program
    {
        /*
         * What is the possible bug in the return of this method in this C# code,
         * knowing that the method should return the current date
         * if no close date is found? (C# code snippet provided): 
         */

        static void Main(string[] args)
        {
            bool isValid = true;

            int datetimeCount = 0;
            Console.WriteLine("How many random dates would you like to add?");
            var consoleDateTimeCount = Console.ReadLine();
            int.TryParse(consoleDateTimeCount, out datetimeCount);

            DateTime inputDateTime = DateTime.MinValue;
            Console.WriteLine("Provide a date");
            var consoleDateTime = Console.ReadLine();
            DateTime.TryParse(consoleDateTime, out inputDateTime);

            if (datetimeCount <= 0)
            {
                Console.WriteLine("Count of dates was incorrect");
                isValid = false;
            }

            if (isValid && inputDateTime == DateTime.MinValue)
            {
                Console.WriteLine("Input date was incorrect");
                isValid = false;
            }

            if (isValid)
            {
                Program p1 = new Program();
                DateTime[] dateTimes = p1.GenerateRandomDates(datetimeCount, inputDateTime);
                if (dateTimes != null && dateTimes.Length == datetimeCount)
                {
                    DateTime closestDate = inputDateTime.GetClosest(dateTimes);
                }
            }
        }

        public DateTime[] GenerateRandomDates(int datetimeCount, DateTime inputDateTime)
        {
            DateTime[] dateTimes = new DateTime[datetimeCount];

            DateTime startDate = inputDateTime;
            DateTime endDate = DateTime.Now;

            Random random = new Random();
            for (int i = 0; i < datetimeCount; i++)
            {
                dateTimes[i] = GenerateRandomDate(startDate, endDate, random);
            }

            return dateTimes;
        }

        public static DateTime GenerateRandomDate(DateTime startDate, DateTime endDate, Random random)
        {
            int range = (endDate - startDate).Days;
            return startDate.AddDays(random.Next(range)).AddHours(random.Next(0, 24)).AddMinutes(random.Next(0, 60)).AddSeconds(random.Next(0, 60));
        }
    }
}
