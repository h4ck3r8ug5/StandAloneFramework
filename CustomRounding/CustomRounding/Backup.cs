using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Diagnostics;

namespace CustomRounding
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> charlesTestRuns = new List<double>(), netTestRuns = new List<double>(), faniesTestRuns = new List<double>();

            int max = 1000;

            var input = 2.1784;
            //var input = 3.1428571428571428571428571428571;
            var stopwatch = new Stopwatch();
            var result = Round(input, 2);

            for (int i = 0; i < max; i++)
            {
                stopwatch.Start();
                result = Round(input, 2);
                stopwatch.Stop();

                charlesTestRuns.Add(stopwatch.Elapsed.TotalMilliseconds * 1000000);
            }

            Console.WriteLine("Charles' Round - " + charlesTestRuns.Average());
            Console.WriteLine("Rounded Value: " + result);

            stopwatch.Start();

            result = Math.Round(input, 2);

            for (int i = 0; i < max; i++)
            {
                stopwatch.Start();
                result = Math.Round(input, 2);
                stopwatch.Stop();

                netTestRuns.Add(stopwatch.Elapsed.TotalMilliseconds * 1000000);
            }

            stopwatch.Stop();

            Console.WriteLine(".Net' Round - " + netTestRuns.Average());
            Console.WriteLine("Rounded Value: " + result);
            stopwatch.Start();

            for (int i = 0; i < max; i++)
            {
                stopwatch.Start();
                result = Math.Ceiling(input * Math.Pow(10, 2)) / Math.Pow(10, 2);
                stopwatch.Stop();

                faniesTestRuns.Add(stopwatch.Elapsed.TotalMilliseconds * 1000000);
            }

            stopwatch.Stop();

            Console.WriteLine("Fanie's Average Round - " + faniesTestRuns.Average());
            Console.WriteLine("Rounded Value: " + result);
            Console.Read();
        }

        private static double Round(double input, int places)
        {
            const double m = 0.01;

            var matissa = input.ToString().Substring(input.ToString().IndexOf(".") + 1, places);
            var integer = input.ToString().Substring(0, input.ToString().IndexOf("."));
            var x = String.Concat(integer, ".", matissa); //2.1784

            //Step 1 => y = x / m
            var y = input / m; // 217.84
            var q1 = y.ToString().Substring(0, y.ToString().IndexOf("."));
            var q2 = y.ToString().Substring(y.ToString().IndexOf(".") + 1);

            //Step 2 => check if the first digit in the matissa of q2 is >= 5
            int roundedDigit = 0;
            int lastQ1Digit = 0;
            int incrementedLastInt = 0;

            if (int.Parse(q2[0].ToString()) >= 5)
            {
                //++ the q2 first int and discard the rest
                roundedDigit = int.Parse(q2[0].ToString()) + 1;

                //Increment the last digit of q1 +=
                lastQ1Digit = int.Parse(q1[q1.Length - 1].ToString());
                incrementedLastInt = lastQ1Digit + 1;
            }
            else
            {
                lastQ1Digit = int.Parse(q1[q1.Length - 1].ToString());
                incrementedLastInt = lastQ1Digit;
            }

            var newStrValue = q1.Replace(q1[q1.Length - 1].ToString(), (incrementedLastInt).ToString());
            var q = string.Concat(newStrValue, ".", roundedDigit);

            //Step 3 => z = x * m
            var z = double.Parse(q) * m;

            var quotientInteger = z.ToString().Substring(0, z.ToString().IndexOf("."));
            var quotientMatissa = z.ToString().Substring(z.ToString().IndexOf(".")).Replace(".", "");
            return double.Parse(string.Concat(quotientInteger, ".", quotientMatissa.Substring(0, places)));
        }
    }
}
