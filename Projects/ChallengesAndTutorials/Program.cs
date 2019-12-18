using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Collections;
using System.Text;

namespace ChallengesAndTutorials {
    // Day 3: challenge at codewars.com

    /* Kata: Array.diff
     * 
     * Goal in this kata is to implement a difference function, which subtracts one list 
     * from another and returns the result. It should remove all values from list a, which 
     * are present in list b.
     */
    public static class Program {
        static void Main (string[] args) {
            InitializeVariables (out int[] a, out int[] b, out int[] input, out int[] solution);
            DisplayValues (input, "bevore");
            solution = Solution (a, b);
            DisplayValues (solution, "after");
            CloseApp ();
        }

        // Solution Method
        public static int[] Solution (int[] a, int[] b) {
            int[] result = a;

            // not finished jet!
            // TODO : find solution for the KATA from codewars (Array.Diff)

            return result;
        }

        #region methods for the tutorial or challenge
        private static void InitializeVariables (out int[] a, out int[] b, out int[] input, out int[] solution) {
            // variables for reproducing the kata from codewars
            a = new int[] { 1, 2 };
            b = new int[] { 2 };
            input = new int[] { 1, 2, 2, 2, 3 };
            int? arraySize = null;
            solution = new int[Convert.ToInt32 (arraySize)];
        }

        private static void DisplayValues (int[] input, string choice) {
            switch (choice) {
                case "bevore":
                    Console.WriteLine ("..........Values bevore the Test.............");
                    Console.WriteLine ();

                    foreach (var item in input) {
                        Console.Write (item + ", ");
                    }
                    Console.WriteLine ();
                    Console.WriteLine ();
                    Console.WriteLine ("..................................");
                    Console.WriteLine ();
                    break;

                case "after":
                    Console.WriteLine ("..........Values after the Test.............");
                    Console.WriteLine ();

                    foreach (var item in input) {
                        Console.Write (item + ", ");
                    }
                    Console.WriteLine ();
                    Console.WriteLine ();
                    Console.WriteLine ("..................................");
                    Console.WriteLine ();
                    break;
            }
        }

        private static void CloseApp () {
            Console.WriteLine ("press any Key to close the Console App..");
            Console.ReadLine ();
        }
        #endregion

        #region methods from older tutorials
        public static string HighAndLow (string numbers) {
            var parsed = numbers.Split().Select(int.Parse);
            return parsed.Max () + " " + parsed.Min ();
        }

        public static IEnumerable<int> GetIntegersFromList (List<object> listOfItems)
        => listOfItems.OfType<int> ();

        public static object[] RemoveDups (object[] str) => str.Distinct ().ToArray ();

        public static double[] FindMinMax (double[] values) => new[] { values.Min (), values.Max () };

        public static string TranslateWord (string word) {

            char[] phraseAsChars = word.ToCharArray();
            int animalIndex = word.IndexOf("fox");
            if (animalIndex != -1) {
                phraseAsChars[animalIndex++] = 'c';
                phraseAsChars[animalIndex++] = 'a';
                phraseAsChars[animalIndex] = 't';
            }

            string updatedPhrase = new string(phraseAsChars);
            return updatedPhrase;
        }

        public static bool PalindromeDescendant (int num) {
            string str = num.ToString();
            char[] ch = str.ToCharArray();
            Array.Reverse (ch);
            string rev = new string(ch);
            bool res = str.Equals(rev, StringComparison.OrdinalIgnoreCase);
            if (!res && str.Length > 2 && str.Length % 2 == 0) {
                ch = str.ToCharArray ();
                int childNum = 0;
                for (int i = 0 ; i < ch.Length ; i += 2)
                    childNum = childNum * 10 + ( ch[i] - '0' ) + ( ch[i + 1] - '0' );
                res = PalindromeDescendant (childNum);


            }
            return res;
        }

        private static bool isPalindrome (int num) {
            int n, r, sum = 0, temp;
            n = num;
            temp = n;
            while (n > 0) {
                r = n % 10;
                sum = ( sum * 10 ) + r;
                n = n / 10;
            }
            if (temp == sum) {
                return true;
            }
            else {
                return false;
            }
        }

        private static int childNumber (int n) {
            var n1 = GetIntArray(n);
            var n2 = new int[n1.Length];
            var n3 = new ArrayList();

            for (int i = 0 ; i < n1.Length ; i++) {
                n3.Add (n1[i] + n1[i + 1]);
                i++;
            }

            var str1 = new StringBuilder();
            foreach (int num in n3) {
                str1.Append (num);
            }

            string str2 = str1.ToString();
            int n4 = Int32.Parse(str2);

            return n4;

        }

        public static int[] GetIntArray (int num) {
            List<int> listOfInts = new List<int>();
            while (num > 0) {
                listOfInts.Add (num % 10);
                num = num / 10;
            }
            listOfInts.Reverse ();
            return listOfInts.ToArray ();
        }

        public static string RemoveFirstLast (string str) => str.Length > 2 ? str.Substring (1, str.Length - 2) : str;

        public static int NumberSyllables (string word) => word.ToCharArray ().Count (c => c == '-') + 1;

        // replace all "a"s with 4, "e"s with 3, "i"s with 1, "o"s with 0, and "s"s with 5.
        public static string HackerSpeak (string str) => str.
            Replace ("a", "4").
            Replace ("e", "3").
            Replace ("i", "1").
            Replace ("o", "0").
            Replace ("s", "5");

        public static int[] SortNumsAscending (int[] arr) => arr.OrderBy (n => n).ToArray ();

        public static string MonthName (int num) => DateTimeFormatInfo.CurrentInfo.GetMonthName (num);

        public static int FindIndex (string[] arr, string str) => Array.IndexOf (arr, str);

        public static int Factorial (int num) => ( num == 1 ) ? 1 : num * Factorial (num - 1);

        public static bool SameCase (string str) => str.All (x => char.IsUpper (x)) || str.All (x => char.IsLower (x));

        public static int GetAbsSum (int[] arr) => arr.Sum (Math.Abs);
        #endregion
    }
}
