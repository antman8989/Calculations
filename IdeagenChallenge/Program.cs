using System;
using System.Data;
using System.Text.RegularExpressions;

namespace IdeagenChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            #region comment code
            //Console.WriteLine(10.5 - (2 + 3 * (7 - 5)));
            //CalculateBreakDown("10.5 - ( 2 + 3 * ( 7 - 5 ) )");
            #endregion

            string equation = "";

            Console.WriteLine("Please Key in the equation: ");
            equation = Console.ReadLine();
            Console.WriteLine("Calculate: " + Calculate(equation));
        }

        #region comment Codes
        static int countChar(string str, char x)
        {
            int count = 0;
            int n = 10;
            for (int i = 0; i < str.Length; i++)
                if (str[i] == x)
                    count++;

            // atleast k repetition are required 
            int repititions = n / str.Length;
            count = count * repititions;

            // if n is not the multiple of the  
            // string size check for the remaining  
            // repeating character. 
            for (int i = 0;
                     i < n % str.Length; i++)
            {
                if (str[i] == x)
                    count++;
            }

            return count;
        }

        public static double CaluculationOptions(string cal)
        {
            double ans = 0.0;



            if (cal.Contains("*"))
            {
                int index = cal.IndexOf("*");

                int indexPlusMinus = 0;

                if (cal.Contains("+"))
                {
                    indexPlusMinus = cal.IndexOf("+");
                }
                else if (cal.Contains("-"))
                {
                    indexPlusMinus= cal.IndexOf("-");
                }

                Console.WriteLine(indexPlusMinus);

                string t1 = cal.Substring(0, index);

                double a1 = Convert.ToInt64(cal.Substring(0, index));
                double a2 = Convert.ToInt64(cal.Substring(index + 1));

                Console.WriteLine(a1);
                Console.WriteLine(a2);

                ans = a1 * a2;

                Console.WriteLine(ans);
            }
            if (cal.Contains("+"))
            {
                int index = cal.IndexOf("+");

                //float tsetA = 2 + 3 * 2;
                //float test = float.Parse(cal);


                string[] numbers = Regex.Split(cal, @"\D+");
                foreach (string value in numbers)
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        int i = int.Parse(value);
                        Console.WriteLine("Number: {0}", i);

                        if(cal.Contains("*"))
                        {
                            int indexT = cal.IndexOf("*");
                            Console.WriteLine(indexT);
                        }
                    }
                }

                double a1 = Convert.ToInt64(cal.Substring(0, index));
                double a2 = Convert.ToInt64(cal.Substring(index + 1));

                Console.WriteLine(a1);
                //Console.WriteLine(a2);

                ans = a1 + a2;

                //cal.Remove(0, index);

                Console.WriteLine(ans);
            }
            if (cal.Contains("-"))
            {
                int index = cal.IndexOf("-");
                double a1 = Convert.ToInt64(cal.Substring(0, index));
                double a2 = Convert.ToInt64(cal.Substring(index + 1));

                Console.WriteLine(a1);
                Console.WriteLine(a2);

                ans = a1 - a2;

                Console.WriteLine(ans);
            }
            
            if (cal.Contains("/"))
            {
                int index = cal.IndexOf("/");
                double a1 = Convert.ToInt64(cal.Substring(0, index));
                double a2 = Convert.ToInt64(cal.Substring(index + 1));

                Console.WriteLine(a1);
                Console.WriteLine(a2);

                ans = a1 / a2;

                Console.WriteLine(ans);
            }

            return ans;
        }

        public static void CalculateBreakDown(string sum)
        {
            sum = sum.Replace(" ", "");

            string backupSum = sum;
            double ans = 0.0;

            int NumOfOpenBrac = countChar(sum, '(') + 1;
            Console.WriteLine("NumOfOpenBrac: " + NumOfOpenBrac + "\n");

            int i = 0;
            while (i < NumOfOpenBrac)
            {
                Console.WriteLine("count: " + i);
                int Startindex = sum.IndexOf("(");
                Console.WriteLine("sum: " + sum);

                Console.WriteLine("StartIndex: " + Startindex);

                string newString = sum.Substring(Startindex + 1);
                Console.WriteLine(newString + "\n");

                sum = newString;

                if (sum.Contains(')'))
                {
                    int EndBracket = sum.IndexOf(')');

                    sum = sum.Remove(EndBracket);

                    //sum = sum.Replace(")", "");
                }

                if (i == NumOfOpenBrac - 1)
                {
                    ans = CaluculationOptions(sum);

                    int startBracket = backupSum.IndexOf(sum) - 1;
                    backupSum = backupSum.Remove(startBracket, 1);

                    //int endBracket = backupSum.IndexOf(sum)+1; 
                    //backupSum = backupSum.Remove(endBracket,1);

                    Console.WriteLine(sum);
                    int endBracket = backupSum.IndexOf(sum);
                    backupSum = backupSum.Replace(sum, ans.ToString());

                    backupSum = backupSum.Remove(endBracket+1, 1);

                    Console.WriteLine("formula= " + backupSum);

                    CalculateBreakDown(backupSum);
                }

                i++;
            }

            foreach (var a in sum)
            {
                //Console.WriteLine(a);



                //ans += ans;
            }
        }
        #endregion

        public static double Calculate(string sum)
        {
            sum = sum.Replace(" ", "");
            try
            {
                var result = new DataTable().Compute(sum, null);
                return Convert.ToDouble(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return 0.0;
        }
    }
}
