/* List of Months which Start with Sunday from 1900 to 2000 (January of 1900 Starts with Monday) */
/* To Check the Results from Calendar: https://www.timeanddate.com/calendar/?year=1900&country=1 */

using System;
using System.IO;
using System.Diagnostics;

namespace SundayMonths
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();      // Start Timer to Measure How Long the Process Will Take


            int first_year = 1900;  // The 1st Month of 1900 Starts with Monday
            int last_year = 2000;

            int totaldays = 0;
            int num_months = 0;
            int[] months = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };


            Console.WriteLine("MM.YYYY:\n");

            for (int i = first_year; i <= last_year; i++)
            {
                for (int j = 1; j <= 12; j++)
                {
                    if (j == 2 && ((i % 4 == 0 && i % 100 != 0) || i % 400 == 0))   // If It is February in A Leap Year
                    {
                        totaldays += (months[j - 1] + 1);                           // Add 1 to 28 = 29
                    }
                    else
                    {
                        totaldays += months[j - 1];                         // Add from the Months Array
                    }
                    if ((totaldays + 1) % 7 == 0)                           // After the Additions so Far, If It is Currently Saturday
                    {
                        if (j != 12)
                        {
                            Console.WriteLine($"{(j + 1):D2}." + i);        // The Next Month Will Start with Sunday
                            num_months++;
                        }
                        else if (i != last_year)                            // If the Month is December and It is Not the Last Year
                        {
                            Console.WriteLine($"{(1):D2}.{i + 1}");         // The Next Month Starting with Sunday will Be the 1st Month of the Next Year
                            num_months++;
                        }
                        else continue;
                    }
                }
            }
            stopwatch.Stop();                                               // Stop Timer

            Console.WriteLine("\n-----------------");
            Console.WriteLine("From " + first_year + " to " + last_year + ", There are " + num_months + " Months Starting with Sunday.");
            Console.WriteLine($"Process Finished in {stopwatch.ElapsedMilliseconds} ms.\n");
            Console.Write("Press any key to exit...");
            Console.ReadKey();
            return;
        }
    }
}