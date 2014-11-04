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

            var input = 2.144555;
            //var input = 3.1428571428571428571428571428571;
            var stopwatch = new Stopwatch();
            var result = RoundWithTieBreaker(input, 0);

            Console.WriteLine(result);

            //for (int i = 0; i < max; i++)
            //{
            //    stopwatch.Start();
            //    result = Round(input, 4);
            //    stopwatch.Stop();

            //    charlesTestRuns.Add(stopwatch.Elapsed.TotalMilliseconds * 1000000);
            //}

            //Console.WriteLine("Charles' Round - " + charlesTestRuns.Average());
            //Console.WriteLine("Rounded Value: " + result);

            //stopwatch.Start();

            ////result = Math.Round(input, 4);

            //for (int i = 0; i < max; i++)
            //{
            //    stopwatch.Start();
            //    result = Math.Round(input, 4);
            //    stopwatch.Stop();

            //    netTestRuns.Add(stopwatch.Elapsed.TotalMilliseconds * 1000000);
            //}

            //stopwatch.Stop();

            //Console.WriteLine(".Net' Round - " + netTestRuns.Average());
            //Console.WriteLine("Rounded Value: " + result);
            //stopwatch.Start();           

            //Console.WriteLine("\n--------------------------------------------------------");
            //Console.WriteLine("Summary Results");
            //Console.WriteLine("\n--------------------------------------------------------");
           
            Console.Read();
        }

        private static double Round(double input, int places)
        {
            var inputSplitResult = input.ToString().Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries);

            var x = int.Parse(inputSplitResult[0]);
            var yMantissa = inputSplitResult[1].Substring(0, places);

            var lastMatissaDigit = yMantissa[yMantissa.Length - 1];
            int incrementedLastMantissaDigit = 0;
            if (int.Parse(lastMatissaDigit.ToString()) > 5)
            {
                incrementedLastMantissaDigit = int.Parse(lastMatissaDigit.ToString()) + 1;
            }
            else
            {
                incrementedLastMantissaDigit = int.Parse(lastMatissaDigit.ToString());
            }

            var replacementMantissa = yMantissa.Replace(yMantissa[yMantissa.Length - 1].ToString(), incrementedLastMantissaDigit.ToString());
            incrementedLastMantissaDigit = 0;

            var result = string.Concat(x, ".", replacementMantissa, incrementedLastMantissaDigit);

            return double.Parse(result);
        }

        private static double RoundWithTieBreaker(double input, int places)
        {
            var inputSplitResult = input.ToString().Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries);

            var x = int.Parse(inputSplitResult[0]);
            places = places > inputSplitResult[1].Length ? 0 : places;

            var yMantissa = inputSplitResult[1].Substring(0, places);
            var numArray = new List<int>();

            yMantissa.ToList().ForEach(mantissaDigit =>
            {
                numArray.Add(int.Parse(mantissaDigit.ToString()));
            });

            for (int i = yMantissa.Length - 1; i >= 0; i--)
            {
                var zBDigit = numArray[i];

                if (zBDigit < 5)
                {
                    break;
                }
                else
                {
                    var roundedValue = 0;
                    var testDigit = TestDigitValue(zBDigit, yMantissa, i - 1, out roundedValue);
                    var testIndex = (i - 1 < 0) ? 0 : (i - 1);
                    if (testDigit != -1)
                    {
                        numArray[i] = roundedValue;
                        numArray[testIndex] = testDigit;
                    }

                }
            }

            var mantissaResult = 0.0;

            var str = "";

            for (int i = 0; i < numArray.Count; i++)
            {
                str += numArray[i].ToString();
            }

            mantissaResult = double.Parse(str);

            return double.Parse(string.Concat(x.ToString(), ".", mantissaResult.ToString()));
        }
        
        static string result = "";

        static int TestDigitValue(int value, string mantissa, int subStringAmount, out int roundedValue)
        {
            if (value >= 5)
            {
                var subDigitIndex = mantissa[subStringAmount];

                roundedValue = 0;
                return int.Parse(subDigitIndex.ToString()) + 1;
            }
            roundedValue = -1;
            return value;
        }
    }
}
