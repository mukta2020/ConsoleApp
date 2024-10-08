﻿using CsvHelper;
using Lucene.Net.Support;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CodingConsoleApp
{
    class Program
    {

        /// ////////////////////////////////////////// Ether //////////////////////////////////////////////////////////////

        #region Ether
        void convert2DArray(int[,] array)
        {
            int row = array.GetLength(0);
            int col = array.GetLength(1);

            int[] retArray = new int[row * col];

            int k = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    retArray[k] = array[i, j];
                    k++;
                }
            }
            for (int i = 0; i < row * col; i++)
            {
                Console.Write("{0}\t", retArray[i]);
            }
        }

        void charOccurance(string str)
        {
            Console.WriteLine("String: " + str);
            while (str.Length > 0)
            {
                if (str[0] == ' ')
                {
                    str = str.Replace(str[0].ToString(), string.Empty);
                }
                Console.Write(str[0] + " = ");
                int cal = 0;
                for (int j = 0; j < str.Length; j++)
                {
                    if (str[0] == str[j])
                    {
                        cal++;
                    }
                }
                Console.WriteLine(cal);
                str = str.Replace(str[0].ToString(), string.Empty);
            }
        }

        int findAngle(double h, double m)
        {
            if (h == 12) h = 0;
            else if (h > 12) h = h - 12;
            if (m == 60)
            {
                m = 0;
                h += 1;
                if (h > 12) h = h - 12;
            }
            int hour_angle = (int)((h * 60 + m) * 0.5);
            int minute_angle = (int)(6 * m);
            int angle = Math.Abs(hour_angle - minute_angle);
            angle = Math.Min(360 - angle, angle);
            return angle;
        }

        int[] insert(int x, int pos, int[] arr)
        {
            int n = arr.Length;
            int[] newarr = new int[n + 1];
            int i = 0;
            for (i = 0; i < n + 1; i++)
            {
                if (i < pos - 1)
                    newarr[i] = arr[i];
                else if (i == pos - 1)
                    newarr[i] = x;
                else
                    newarr[i] = arr[i - 1];
            }
            Console.WriteLine("...inserting....");
            for (i = 0; i < n + 1; i++)
                Console.Write(newarr[i] + " ");
            Console.WriteLine();
            return newarr;
        }

        int dblLinear(int n)
        {
            int[] u = new int[n + 4];
            u[0] = 1;
            int i = 0, k = 1;
            int count = 1;
            int x = 0, y = 0, z = 0;
            int last1 = 0, last2 = 0;
            bool isFirst = true;
            while (i <= u.Length)
            {
                if (count > n + 2)
                {
                    Console.WriteLine("....Final array...");
                    for (i = 0; i < n + 1; i++)
                    {
                        Console.Write(u[i] + " ");
                    }
                    Console.WriteLine(" Result is: ");
                    return u[n];
                }
                x = u[i];
                y = 2 * x + 1;
                z = 3 * x + 1;
                if (isFirst)
                {
                    u[k] = y; k++;
                    u[k] = z; k++;
                    count += 2;
                    i += 1;
                    isFirst = false;
                    continue;
                }
                last1 = u[k - 1];
                last2 = u[k - 2];

                if (last1 > y && last2 > y)
                {
                    u = insert(y, k - 1, u);
                }
                else if (last1 > y)
                {
                    u = insert(y, k, u);
                }
                else
                {
                    u[k] = y;
                }
                k++;

                last1 = u[k - 1];
                last2 = u[k - 2];
                if (last1 > z && last2 > z)
                {
                    u = insert(z, k - 1, u);
                }
                else if (last1 > z)
                {
                    u = insert(z, k, u);
                }
                else
                {
                    u[k] = z;
                }
                k++;
                count += 2;
                i += 1;
            }
            return 0;
        }

        #endregion


        /// ///////////////////////////////////////// MUKTA ///////////////////////////////////////////////////////////////

        #region Mukta
        static public Tuple<int, int> MaxMin(int[] a)
        {
            int maxV = int.MinValue;
            int minV = int.MaxValue;

            for (int i = 0; i < a.Length; i++)
            {

                if (a[i] > maxV)
                {
                    maxV = a[i];
                }

                if (a[i] < minV)
                {
                    minV = a[i];
                }
            }
            return new Tuple<int, int>(maxV, minV);
        }


        static public int Reverse(int a)
        {

            int r = 0;
            while (a > 0)
            {
                int rem = a % 10;
                a = a / 10;
                r = r * 10 + rem;
            }
            return r;
        }

        static public int reverseNumber(int n)
        {
            int reverse = 0;
            if (n == 0) return 0;
            int flag = 1;
            if (n < 0)
            {
                n = -n;
                flag = -1;
            }
            while (n != 0)
            {
                int mod = n % 10;
                n /= 10;
                reverse = reverse * 10 + mod;
            }

            return flag * reverse;

        }

        static int a4(int n)
        {
            int sign = 1;
            if (n == 0) return 0;
            if (n < 0)
            {
                sign = -1;
                n = -n;
            }
            int reverse = 0;
            while (n != 0)
            {
                reverse = (reverse * 10) + (n % 10);
                n /= 10;
            }
            return sign * reverse;
        }

        static int[] commonArray(int[] first, int[] second)
        {
            if ((first == null) || (second == null)) return null;

            int l1 = first.Length;
            int l2 = second.Length;

            if ((l1 == 0) || (l2 == 0)) return new int[0];


            int[] a;
            if (l1 > l2)
                a = new int[l2];
            else
                a = new int[l1];

            int k = 0;

            for (int i = 0; i < l1; i++)
            {
                for (int j = 0; j < l2; j++)
                {
                    if (first[i] == second[j])
                    {
                        a[k] = first[i];
                        k++;
                    }
                }
            }

            int[] retArr = new int[k];
            for (int i = 0; i < k; i++)
            {
                retArr[i] = a[i];
            }
            return retArr;
        }

        static int POE(int[] a)
        {
            if (a == null) { return -1; }
            if (a.Length < 3) { return -1; }
            int firstHalf = a[0];
            int total = a.Sum();

            for (int i = 1; i < a.Length - 1; i++)
            {
                if (firstHalf == total - firstHalf - a[i])
                {
                    return i;
                }
                firstHalf += a[i];
            }
            return -1;
        }

        public static int isSequentiallyBounded(int[] a)
        {
            if (a.Length == 0) return 1;
            int c = 0;
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] < 0) return 0;

                if (a[i - 1] > a[i]) return 0;
                else if (a[i - 1] == a[i]) c++;
                else if (a[i - 1] < a[i]) 
                {
                    if (a[i - 1] <= c) return 0;
                    else c = 1;
                }
            }

            if (c >= a[a.Length - 1]) return 0;
            else return 1;
        }


        public static int isMinMaxDisjoint(int[] a)
        {

            if (a.Length == 0) return 0;
            int min = a.Min();
            int max = a.Max();
            int minC = 0;
            int maxC = 0;
            bool mequal = false;
            bool mAdjacent = false;
            bool minOne = false;
            bool maxOne = false;

            if (min != max) mequal = true;
            if (max - min > 1) mAdjacent = true;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == min) minC++;
                if (a[i] == max) maxC++;
            }

            if (minC == 1) minOne = true;
            if (maxC == 1) maxOne = true;

            if (mequal && mAdjacent && minOne && maxOne)
                return 1;
            else return 0;            

            
        }

        static int isStepped(int[] a)
        {
            var hasset = new HashSet<int>(a);

            for (int i = 0; i < a.Length - 1; i++)
            {
                if (a[i + 1] < a[i])
                    return 0;
            }

            foreach (int d in hasset)
            {
                if (a.Count(c => c == d) < 3)
                    return 0;
            }

            return 1;
        }

        public static int countOnes(int n) 
        {
            int c = 0;
            while (n>0)
            {
                int q = n / 2;
                int r = n % 2;
                if (r == 1) c++;
                n = q;
            }
            return c;
        }

        static bool isPrime(int n)
        {
            if (n == 1) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;

            for (int i = 2; i <= n/2; i++)
            {
                if (n % i == 0)  return false;
            }
            return true;
        }

        public static bool isPrime2(int n)
        {
            if (n == 1) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;

            for (int i = 2; i <= n / 2; i++)
            {
                if (n % i == 0) return false;
            }

            return true;

        }


        static int isPrimeHappy(int n)
        {
            int primeSum = 0;
            for (int i = 2; i < n; i++)
            {
                if (isPrime(i))
                    primeSum += i;
            }

            if (primeSum % n != 0)
                return 0;

            return 1;
        }

        static int isDigitIncreasing(int n) 
        {
            int l = n.ToString().Length;
            string f = n.ToString()[0].ToString();
            for (int i = 1; i <= Convert.ToInt32(f); i++)
            {
                int sum = 0;
                string s = i.ToString();

                for (int j = 0; j < l; j++)
                {
                    sum = sum + Convert.ToInt32(s);
                    s = s + s;
                }
                if (sum == n) return 1;
            }
            return 0;
        }

        static int isDigitIncreasing1(int n)
        {
            for (int i = 1; i < 10; i++)
            {
                int a = i;
                int digitSum = a;

                while (digitSum < n)
                {
                    a = 10 * a + i;
                    digitSum += a;
                }

                if (digitSum == n)
                    return 1;
            }
            return 0;
        }

        static int isDigitIncreasingMukta(int n)
        {
            int total = 0;
            for (int i = 1; i < 10; i++)
            {
                int d = i;
                total = d;

                while (total < n)
                {
                    d = d * 10 + i;
                    total += d;
                }
                if (total == n)
                {
                    return 1;
                }
            }
            return 0;
        }


        static int hasNValue1(int[] a, int n)
        {
            int[] b = new int[n];
            b[0] = a[0];
            int k = 1;

            for (int i = 1; i < a.Length; i++)
            {
                bool found = false;

                for (int j = 0; j < k; j++)
                {
                    if (a[i] == b[j])
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    b[k] = a[i];
                    k++;
                }

            }

            if (k == n)
                return 1;
            else
                return 0;
        }

        static int hasNValue(int[] a, int n)
        {
            var hasset = new HashSet<int>(a);

            if (hasset.Count == n)
            {
                return 1;
            }
            else
                return 0;
        }
        public static int hasNValues(int[] a, int n)
        {
            var h = new HashSet<int>(a);
            if (h.Count == n) return 1;
            else return 0;
        }


        static int is121ArrayFst(int[] a)
        {
            if (a == null) return 0;
            if (a.Length < 3) return 0;

            bool one = false;
            bool two = false;
            int countOne = 0;
            int countOneLast = 0;

            if (a[0] == 1)
            {
                countOne = 1;
                one = true;
            }

            if ((a[0] != 1) || (a[a.Length - 1] != 1))
            {
                return 0;
            }

            for (int i = 1; i < a.Length; i++)
            {
                if ((two == false) && (a[i - 1] == a[i]) && (a[i] == 1))
                    countOne++;
                else if ((two == false) && (a[i] == 2))
                    two = true;
                else if ((two == true) && (a[i - 1] == a[i]) && (a[i] == 2))
                    continue;
                else if ((two == true) && (a[i] == 1))
                    countOneLast++;
                else
                    return 0;
            }

            if ((one && two) && (countOne == countOneLast))
            {
                return 1;
            }
            else
                return 0;
        }

        static int is121Array(int[] a)
        {
            if ((a[0] != 1) || (a[a.Length - 1]) != 1)
            {
                return 0;
            }
            bool one = false;
            bool two = false;

            int countOne = 0;
            int countOneLast = 0;

            int countTwo = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == 1)
                {
                    one = true;
                }
                else if (a[i] == 2)
                {
                    two = true;
                }
                else
                    return 0;



                if ((one == true) && (two == false) && (a[i] == 1))
                {
                    countOne++;
                }
                else if ((one == true) && (two == true) && (a[i] == 2) && (countOneLast == 0))
                {
                    countTwo++;
                }
                else if ((one == true) && (two == true) && (a[i] == 1))
                {
                    countOneLast++;
                }
                else
                    return 0;


            }

            if ((one && true) && (countOne == countOneLast))
            {
                return 1;
            }
            else
                return 0;

        }
        static int is121Array2(int[] a)
        {
            Dictionary<int, List<int>> myDic = new Dictionary<int, List<int>>();

            for (int i = 0; i < a.Length; i++)
            {
                if (!myDic.Keys.Contains(a[i]))
                {
                    List<int> l = new List<int>();
                    l.Add(i);
                    myDic.Add(a[i], l);
                }
                else
                {
                    myDic[a[i]].Add(i);
                }
            }

            bool one = false;
            bool two = false;

            foreach (int k in myDic.Keys)
            {
                if (k == 1)
                    one = true;
                else if (k == 2)
                    two = true;
                else
                    return 0;


                if (k == 2)
                {
                    List<int> l2 = myDic[2];
                    for (int j = 0; j < l2.Count - 1; j++)
                    {
                        if (l2[j] + 1 != l2[j + 1])
                        {
                            return 0;
                        }
                    }
                }
                else if (k == 1)
                {
                    List<int> l1 = myDic[1];
                    if (l1.Count % 2 != 0)
                    {
                        return 0;
                    }
                    else
                    {
                        int fstHalf = l1.Count / 2;
                        if ((l1[fstHalf] - l1[fstHalf - 1]) <= 1)
                        {
                            return 0;
                        }
                    }
                }

            }

            if (one || two)
            {
                return 1;
            }
            else
                return 0;
        }

        static int is123Array(int[] a)
        {

            if ((a == null) || (a.Length < 3))
            {
                return 0;
            }

            for (int i = 0; i < a.Length - 2; i += 3)
            {
                if ((a[i] == 1) && (a[i + 1] == 2) && (a[i + 2] == 3))
                    continue;
                else
                    return 0;
            }
            return 1;
        }

        static bool equivalCheck(int[] a1, int[] a2)
        {
            for (int i = 0; i < a1.Length; i++)
            {
                bool found = false;
                for (int j = 0; j < a2.Length; j++)
                {

                    if (a1[i] == a2[j])
                    {
                        found = true;
                        break;
                    }
                }

                if (found == false)
                    return false;
            }
            return true;
        }

        static int equivalantArray(int[] a1, int[] a2)
        {
            bool fstArrayEleFound = equivalCheck(a1, a2);
            bool sndArrayEleFound = equivalCheck(a2, a1);

            if ((fstArrayEleFound == true) && (sndArrayEleFound == true))
                return 1;
            else
                return 0;

        }

        static int reverse(int n)
        {

            int r = n % 10;
            n = n / 10;
            int number = r;

            while (n > 0)
            {

                r = n % 10;
                n = n / 10;

                number = number * 10 + r;

            }

            return number;

        }
        static int is235Array(int[] a)
        {
            int c2 = 0;
            int c3 = 0;
            int c5 = 0;
            int cnot235 = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] % 2 == 0)
                {
                    c2++;
                }

                if (a[i] % 3 == 0)
                {
                    c3++;
                }

                if (a[i] % 5 == 0)
                {
                    c5++;
                }

                if ((a[i] % 2 != 0) && (a[i] % 3 != 0) && (a[i] % 5 != 0))
                {
                    cnot235++;
                }
            }

            if ((c2 + c3 + c5 + cnot235) == a.Length)
                return 1;
            else
                return 0;

        }


        /// //////////////////////////////////////// LeetCode ////////////////////////////////////////////////////////////////

        static public IList<int> MajorityElement(int[] nums)
        {
            var hashSet = new HashSet<int>(nums);
            int size = nums.Length / 3;
            List<int> a = new List<int>();

            foreach (int ele in hashSet)
            {
                if (nums.Count(c => c == ele) > size)
                {
                    a.Add(ele);
                }
            }
            return a;
        }

        static public bool CanConstruct(string ransomNote, string magazine)
        {
            Dictionary<char, int> mapNote = new Dictionary<char, int>();
            Dictionary<char, int> mapMega = new Dictionary<char, int>();


            for (int i = 0; i < ransomNote.Length; i++)
            {
                if (!mapNote.Keys.Contains(ransomNote[i]))
                {
                    mapNote.Add(ransomNote[i], 1);
                }
                else
                {
                    mapNote[ransomNote[i]] += 1;
                }
            }

            for (int i = 0; i < magazine.Length; i++)
            {
                if (!mapMega.Keys.Contains(magazine[i]))
                {
                    mapMega.Add(magazine[i], 1);
                }
                else
                {
                    mapMega[magazine[i]] += 1;
                }
            }

            foreach (char k in mapNote.Keys)
            {
                if (!mapMega.Keys.Contains(k))
                    return false;
                if (mapNote[k] > mapMega[k])
                    return false;
            }

            return true;
        }

        static public int FirstUniqChar(string s)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!map.Keys.Contains(s[i]))
                    map.Add(s[i], 1);
                else
                    map[s[i]] += 1;
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (map[s[i]] == 1)
                    return i;
            }
            return -1;
        }

        static IList<int> FindDisappearedNumbers1(int[] nums)
        {
            int i = 0;
            while (i < nums.Length)
            {
                if (nums[i] == i + 1)
                {
                    i++;
                    continue;
                }

                if (nums[nums[i] - 1] == nums[i])
                {
                    i++;
                }
                else
                {
                    int j = nums[i];
                    int temp = nums[j - 1];
                    nums[j - 1] = nums[i];
                    nums[i] = temp;
                }
            }
            IList<int> list = new List<int>();
            for (i = 0; i < nums.Length; i++)
            {
                if (nums[i] != i + 1)
                {
                    list.Add(i + 1);
                }
            }
            return list;

        }

        static List<int> findDisappearedNumbers(int[] nums)
        {
            List<int> ans = new List<int>();

            int[] idx = new int[nums.Length + 1];

            foreach (int x in nums)
            {
                idx[x]++;
            }


            for (int i = 1; i < idx.Length; i++)
            {
                if (idx[i] == 0)
                {
                    ans.Add(i);
                }
            }

            return ans;
        }

        public static int[] IntersectHelper(int[] nums1, int[] nums2)
        {
            Dictionary<int, int> dic1 = new Dictionary<int, int>();
            Dictionary<int, int> dic2 = new Dictionary<int, int>();

            for (int i = 0; i < nums1.Length; i++)
            {
                if (!dic1.ContainsKey(nums1[i]))
                {
                    dic1.Add(nums1[i], 1);
                }
                else
                {
                    dic1[nums1[i]] += 1;
                }
            }
            for (int i = 0; i < nums2.Length; i++)
            {
                if (!dic2.ContainsKey(nums2[i]))
                {
                    dic2.Add(nums2[i], 1);
                }
                else
                {
                    dic2[nums2[i]] += 1;
                }
            }

            int[] inter = new int[nums2.Length];
            int count = 0;
            foreach (int k in dic1.Keys)
            {
                if (dic2.ContainsKey(k))
                {
                    int c = dic1[k] < dic2[k] ? dic1[k] : dic2[k];
                    for (int p = 0; p < c; p++)
                    {
                        inter[count] = k;
                        count++;
                    }
                }
            }

            int[] ret = new int[count];
            for (int i = 0; i < count; i++)
            {
                ret[i] = inter[i];
            }

            return ret;
        }

        public static int[] Intersect(int[] nums1, int[] nums2)
        {

            if (nums1.Length > nums2.Length)
            {
                return IntersectHelper(nums1, nums2);
            }
            else
            {
                return IntersectHelper(nums2, nums1);
            }

        }

        public static void piramid1(int n)
        {
            /*
            1
            2 2
            3 3 3
            
             */
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
        }

        public static void piramid2(int row)
        {
            /*
             1
             2 3
             4 5 6
             7 8 9 10
            
             */
            int c = 1;
            for (int i = 1; i <= row; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write(c++ + " ");
                }
                Console.WriteLine();
            }
        }

        public static void piramid3(int row)
        {
            /*
              1
             2 3
            4 5 6
           7 8 9 10
            
             */
            int space = row - 1;
            int c = 1;
            for (int i = 1; i <= row; i++)
            {
                for (int s = 0; s < space; s++)
                {
                    Console.Write(0 + " ");
                }
                space--;

                for (int j = 0; j < i; j++)
                {
                    Console.Write(c++ + " ");
                    Console.Write(0 + " ");
                }
                Console.WriteLine();
            }
        }

        public static void piramid4(int row)
        {
            /*
             1 2 3 4
               5 6 7
                 8 9  
                   10            
             */
            int c = 1;
            int r = row;
            int space = 0;

            for (int i = 1; i <= row; i++)
            {
                for (int s = 0; s < space; s++)
                {
                    Console.Write(0 + " ");
                }

                for (int j = 0; j < r; j++)
                {
                    Console.Write(c++ + " ");
                }
                r--;
                space++;
                Console.WriteLine();
            }
        }

        IList<int> GetRow1(int rowIndex)
        {
            List<int> a = new List<int>();
            IList<IList<int>> resultList = new List<IList<int>>();

            for (int i = 0; i <= rowIndex; i++)
            {
                a = new List<int>();
                a.Add(1);

                int j = 0;
                for (j = 1; j < i; j++)
                {
                    int k = resultList[i - 1][j - 1] + resultList[i - 1][j];
                    a.Add(k);
                }
                if (i == j)
                {
                    a.Add(1);
                }
                resultList.Add(a);
            }
            return a;
        }



        // pascal row column fixed size JAVA type

        public static int[,] pascal(int n)
        {
            int[,] a = new int[n, n];

            a[0, 0] = 1;

            for (int i = 1; i < n; i++)
            {
                a[i, 0] = 1;

                for (int j = 1; j < i; j++)
                {
                    a[i, j] = a[i - 1, j - 1] + a[i - 1, j];
                }

                a[i, i] = 1;
            }

            return a;
        }

        // pascal row fixed column dynamic

        public static int[][] Pascal2(int n)
        {
            int[][] m = new int[n][];

            for (int r = 0; r < n; r++)
            {
                int[] a = new int[r + 1];
                a[0] = 1;
                a[r] = 1;

                for (int c = 1; c < r; c++)
                {
                    a[c] = m[r - 1][c - 1] + m[r - 1][c];
                }
                m[r] = a;
            }
            return m;
        }

        // pascal row fixed column dynamic  IList<IList<int>> 

        List<List<int>> pascalList(int numRows)
        {
            List<List<int>> a = new List<List<int>>();

            for (int i = 0; i < numRows; i++)
            {
                int[] innerArray = new int[i + 1];
                innerArray[0] = 1;

                for (int j = 1; j < i; j++)
                {
                    innerArray[j] = a[i - 1][j - 1] + a[i - 1][j];
                }
                innerArray[i] = 1;
                a.Add(innerArray.ToList());
            }
            return a;
        }

        IList<IList<int>> pascalIList(int numRows)
        {
            IList<IList<int>> a = new List<IList<int>>();

            for (int i = 0; i < numRows; i++)
            {
                int[] innerArray = new int[i + 1];
                innerArray[0] = 1;

                for (int j = 1; j < i; j++)
                {
                    innerArray[j] = a[i - 1][j - 1] + a[i - 1][j];
                }
                innerArray[i] = 1;
                a.Add(innerArray);
            }
            return a;
        }

        // two D array IList<IList<int>>
        public static int MinimumTotal1(IList<IList<int>> triangle)
        {
            int minTotal = 0;
            for (int i = 0; i < triangle.Count; i++)
            {
                List<int> singleRow = triangle[i].ToList();
                minTotal += singleRow.Min();
            }
            return minTotal;
        }

        // two D array int[][]
        public static int MinimumTotal2(int[][] array)
        {
            int minTotal = 0;

            for (int i = 0; i < array.Length; i++)
            {
                int[] singleRow = array[i];
                minTotal += singleRow.Min();

            }
            return minTotal;
        }

        // two D array int[,] 
        public static int MinimumTotal3(int[,] array)
        {
            int minTotal = 0;

            int col = array.GetLength(1);
            int row = array.GetLength(0);

            for (int i = 0; i < row; i++)
            {
                int[] singleRow = new int[col];
                int k = 0;

                for (int j = 0; j < col; j++)
                {
                    singleRow[k++] = array[i, j];

                }
                minTotal += singleRow.Min();

            }

            return minTotal;
        }

        // leetcode 
        public static int MinimumTotal(int[][] triangle)
        {
            int l = triangle.Length;
            for (int i = l - 1; i > 0; i--)
            {
                for (int j = 0; j < triangle[i].Length - 1; j++)
                {
                    int m = triangle[i][j] < triangle[i][j + 1] ? triangle[i][j] : triangle[i][j + 1];
                    triangle[i - 1][j] += m;
                }
            }
            return triangle[0][0];
        }

        public static int MinimumTotal(IList<IList<int>> triangle)
        {
            int l = triangle.Count;
            for (int i = l - 1; i > 0; i--)
            {
                for (int j = 0; j < triangle[i].Count - 1; j++)
                {
                    int m = triangle[i][j] < triangle[i][j + 1] ? triangle[i][j] : triangle[i][j + 1];
                    triangle[i - 1][j] += m;
                }
            }
            return triangle[0][0];
        }

        public static int LongestConsecutive(int[] nums)
        {
            HashSet<int> h = new HashSet<int>(nums);

            int lc = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int ele = nums[i];
                if (!h.Contains(ele - 1))
                {
                    int c = 0;
                    while (h.Contains(ele))
                    {
                        c += 1;
                        ele += 1;
                    }
                    lc = Math.Max(lc, c);
                }

            }
            return lc;
        }

        public static int NthUglyNumber(int n)
        {
            int c = 1;
            int i = 2;
            while (c <= n)
            {
                if ((i % 2 == 0) || (i % 3 == 0) || (i % 5 == 0))
                {
                    c += 1;
                    if (c == n) return i;
                }
                i++;
            }
            return 1;

        }

        public static (int[], int) ThirdMaxHelper(int[] nums)
        {
            int one = nums.Max();
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == one)
                {
                    nums[i] = int.MinValue;
                }
            }
            return (nums, one);
        }
        public static int ThirdMax(int[] nums)
        {
            int fstMax = ThirdMaxHelper(nums).Item2;
            int sndMax = ThirdMaxHelper(nums).Item2;
            int trdMax = ThirdMaxHelper(nums).Item2;

            if (nums.Length < 3)
                return fstMax;
            else
                return trdMax >= int.MinValue ? trdMax : fstMax;
        }
        public static int ThirdMax2(int[] nums)
        {
            nums = nums.OrderBy(x => x).Distinct().ToArray();
            if (nums.Length < 3)
            {
                return nums.Max();
            }
            else
            {
                return nums[nums.Length - 3];
            }
        }


        public static int lengthOfLIS(int[] nums)
        {
            int[] dp = new int[nums.Length];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = 1;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j] && dp[i] < dp[j] + 1)
                    {
                        dp[i] = dp[j] + 1;
                    }
                }
            }
            int ans = -1;
            foreach (int nxt in dp)
            {
                ans = Math.Max(ans, nxt);
            }
            return ans;
        }


        public static int removeDuplicates1(int[] nums)
        {
            int i = 1;  // i for unique,  j  moving  {1,1,2,2,3,3}
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[j - 1] != nums[j])
                {
                    nums[i] = nums[j];
                    i++;
                }
            }
            return i;
        }

        //public static int removeDuplicates(int[] nums)
        //{
        //    //    HashSet<int> h = new HashSet<int>(nums);
        //    //    return h.Count;

        //    int i = 1; // unique
        //    int j = 1; // moving
        //    while (j < nums.Length)
        //    {
        //        if (nums[j - 1] != nums[j])
        //        {
        //            nums[i] = nums[j];
        //            i++;
        //        }
        //        j++;
        //    }
        //    return i;
        //}

        public static int RemoveElement(int[] nums, int val)
        {
            int i = 0;   // i for unique,  j  moving  {3,2,2,3} val = 3
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] != val)
                {
                    //int temp = nums[i];
                    //nums[i] = nums[j];
                    //nums[j] = temp;

                    int t = nums[j];
                    nums[j] = nums[i];
                    nums[i] = t;
                    i++;
                }
            }
            return i;
        }

        //public static void moveZeroes(int[] nums)
        //{
        //    int j = 0; // j for 0 tracing
        //    int i = 0; // i for non 0 tracing
        //    while (i < nums.Length)
        //    {
        //        if (nums[i] != 0)
        //        {
        //            int t = nums[i];
        //            nums[i] = nums[j];
        //            nums[j] = t;
        //            j++;
        //        }
        //        i++;
        //    }
        //}
        public static void MoveZeroes(int[] nums)
        {
            int i = 0;
            for (int j = 0; j < nums.Length; j++)  //0, 1, 0, 3, 12
            {
                if ((nums[j] != 0))
                {
                    int t = nums[j];
                    nums[j] = nums[i];
                    nums[i] = t;
                    i++;
                }
            }
        }
        public static void MoveZeroesToFirst(int[] nums)
        {
            int i = nums.Length - 1;
            for (int j = nums.Length - 1; j >= 0; j--) // 0,1,0,3,2
            {
                if ((nums[j] != 0))
                {
                    int t = nums[j];
                    nums[j] = nums[i];
                    nums[i] = t;
                    i--;
                }
            }
        }

        public static int SearchInsert(int[] nums, int target)
        {
            int low = 0;
            int high = nums.Length;

            int mid = (low + high) / 2;
            int previous = mid;
            while (nums[mid] != target)
            {
                previous = mid;
                if (target == nums[mid])
                    return mid;
                else if (target > nums[mid])
                    low = mid;
                else if (target < nums[mid])
                    high = mid;
                mid = (low + high) / 2;
                if (previous == mid)
                {
                    if (target > nums[mid])
                    {
                        mid = mid + 1;
                        break;
                    }
                }
            }

            return mid;
        }

        public static int MaxSubArray(int[] nums)
        {
            int cursum = nums[0];
            int maxsum = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {

                cursum += nums[i];
                cursum = Math.Max(cursum, nums[i]);
                maxsum = Math.Max(maxsum, cursum);
            }
            return maxsum;
        }

        public static int[] PlusOne1(int[] digits)
        {
            string s = "";
            for (int i = 0; i < digits.Length; i++)
            {
                s += digits[i].ToString();
            }

            int d = Convert.ToInt32(s) + 1;
            s = d.ToString();
            int[] r = new int[s.Length];

            int k = r.Length - 1;

            while (d > 0)
            {
                r[k] = d % 10;
                d = d / 10;
                k--;
            }


            return r;
        }

        public static int[] PlusOne(int[] digits)
        {
            int[] a = new int[digits.Length];
            int c = 0;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] + 1 + c > 9)
                {
                    a[i] = 0;
                    c = 1;
                }
                else
                {
                    a[i] = digits[i] + 1;
                    c = 0;
                }
            }

            if (c == 1)
            {
                int[] b = new int[a.Length + 1];
                b[0] = 1;
                a.CopyTo(b, 1);
                return b;
            }
            return a;

        }

        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {

            for (int i = 0; i < n; i++)
            {
                int ele = nums2[i];

                for (int j = 0; j < m; j++)
                {
                    if (nums1[j] > ele || nums1[j] == 0)
                    {
                        if (j == m - 1 && nums1[j] == 0) nums1[j] = ele;
                        else
                        {
                            nums1[j + 1] = nums1[j];
                            nums1[j] = ele;
                        }
                        break;
                    }

                }

            }

            Console.WriteLine(nums1);
        }

        public static int SingleNumber(int[] nums)
        {

            Dictionary<int, int> d = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {

                if (!d.Keys.Contains(nums[i]))
                {
                    d[nums[i]] = 1;
                }
                else
                {
                    d[nums[i]] += 1;
                }
            }

            foreach (int k in d.Keys)
            {
                if (d[k] == 1)
                {
                    return k;
                }
            }

            return 0;
        }

        public static int MajorityElement2(int[] nums)
        {
            Dictionary<int, int> d = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!d.Keys.Contains(nums[i]))
                {
                    d[nums[i]] = 1;
                }
                else
                {
                    d[nums[i]] += 1;
                }
            }
            int m = 0;
            int r = 0;
            foreach (int k in d.Keys)
            {
                if (d[k] > m)
                {
                    m = d[k];
                    r = k;
                }
            }

            return r;
        }

        public static int majorityElementBoyer(int[] nums)
        {
            int count = 0;
            int candidate = 0;

            foreach (int num in nums)
            {
                if (count == 0)
                {
                    candidate = num;
                }
                count += (num == candidate) ? 1 : -1;
            }

            Array.Sort(nums);
            return nums[nums.Length / 2];

            //return candidate;
        }

        public static bool ContainsDuplicate1(int[] nums)
        {
            HashSet<int> h = new HashSet<int>(nums); // O(1) 

            if (nums.Length == h.Count)
                return false;
            else
                return true;
        }


        public static bool ContainsDuplicate2(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {  // n2

                for (int j = 0; j < nums.Length; j++)
                {
                    if ((i != j) && (nums[i] == nums[j]))
                    {
                        return true;
                    }
                }

            }
            return false;
        }

        public static bool ContainsDuplicate(int[] nums)
        {
            Array.Sort(nums); // nlogn
            for (int i = 0; i < nums.Length; i++)
            {

                if (nums[i] == nums[i + 1])
                {
                    return true;
                }
            }

            return false;
        }

        public static int MissingNumber2(int[] nums)
        {
            int n = nums.Length;
            bool f = false;
            int r = 0;
            for (int i = 0; i < n; i++)
            {
                f = false;
                r = i;
                for (int j = 0; j < n; j++)
                {
                    if (nums[j] == i)
                    {
                        f = true;
                        break;
                    }
                }
                if (f == false)
                {
                    return r;
                }
            }
            return r;
        }

        public static int[] Intersection(int[] nums1, int[] nums2)
        {
            IEnumerable<int> both = nums1.Intersect(nums2);
            return both.ToArray();

        }

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            int c = 1;
            int m = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i - 1] == nums[i] && nums[i] == 1)
                {
                    c++;
                    m = Math.Max(m, c);
                }
                else
                {
                    c = 1;
                }
            }
            return m;
        }

        public static int SumOfUnique(int[] nums)
        {
            Dictionary<int, int> d = new Dictionary<int, int>();


            for (int i = 0; i < nums.Length; i++)
            {

                if (!d.Keys.Contains(nums[i]))
                {
                    d[nums[i]] = 1;
                }
                else
                {
                    d[nums[i]] += 1;
                }
            }
            int s = 0;
            foreach (int k in d.Keys)
            {
                if (d[k] == 1)
                {
                    s += k;
                }
            }
            return s;
        }
        // int[][]
        public static int DiagonalSum(int[][] mat)
        {
            int d1 = 0;
            int d2 = 0;
            int row = mat.Length;
            int k = mat[0].Length - 1;


            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < mat[r].Length; c++)
                {
                    if (r == c)
                    {
                        d1 += mat[r][c];
                    }
                }

                if (r != k)
                {
                    d2 += mat[r][k];
                }

                k--;
            }
            return d1 + d2;
        }

        // int[,]
        public static int DiagonalSum(int[,] mat)
        {
            int d1 = 0;
            int d2 = 0;
            int row = mat.GetLength(0);
            int col = mat.GetLength(1);
            int k = col - 1;

            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    if (r == c)
                    {
                        d1 += mat[r, c];
                    }
                }

                if (r != k)
                {
                    d2 += mat[r, k];
                }

                k--;
            }
            return d1 + d2;
        }

        public static int[,] Pascal(int n)
        {
            int[,] m = new int[n, n];
            for (int r = 0; r < n; r++)
            {
                m[r, 0] = 1;
                m[r, r] = 1;

                for (int c = 1; c < r; c++)
                {
                    m[r, c] = m[r - 1, c - 1] + m[r - 1, c];
                }
            }
            return m;
        }


        public static bool IsAnagram1(string s, string t)
        {
            Dictionary<char, int> d = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (!d.Keys.Contains(s[i]))
                {
                    d[s[i]] = 1;
                }
                else
                {
                    d[s[i]] += 1;
                }
            }

            Dictionary<char, int> h = new Dictionary<char, int>();

            for (int i = 0; i < t.Length; i++)
            {
                if (!h.Keys.Contains(t[i]))
                {
                    h[t[i]] = 1;
                }
                else
                {
                    h[t[i]] += 1;
                }
            }

            foreach (char k in d.Keys)
            {
                if (!h.Keys.Contains(k))
                {
                    return false;
                }
                if ((d[k] != h[k]))
                {
                    return false;
                }
            }
            return true;
        }

        public static int IsAnagram(char[] a1, char[] a2)
        {
            if (a1.Length != a2.Length) return 0;
            for (int i = 0; i < a1.Length; i++)
            {
                bool found = false;
                for (int j = 0; j < a2.Length; j++)
                {
                    if (a1[i] == a2[j])
                    {
                        a1[i] = '*';
                        a2[j] = '*'; found = true; break;
                    }
                }
                if (found == false) return 0;
            }
            if (a1.SequenceEqual(a2)) return 1;
            else return 0;           

        }


        static int areAnagrams(char[] a1, char[] a2)
        {

            if (a1.Length != a2.Length) return 0;

            for (int i = 0; i < a1.Length; i++)
            {
                bool found = false;
                for (int j = 0; j < a2.Length; j++)
                {
                    if (a1[i] == a2[j])
                    {
                        a1[i] = '*';
                        a2[j] = '*';
                        found = true; break;
                    }
                }
                if (found == false) return 0;
            }
            if (a1.SequenceEqual(a2)) return 1;
            else return 0;
        }


        public static bool IsPalindrome(int x)
        {
            string s = x.ToString();
            int l = s.Length - 1;  //3

            for (int i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[l])
                {
                    return false;
                }
                l--;
            }
            return true;
        }

        public static bool IsValid(string s)
        {
            Dictionary<char, char> mapping = new Dictionary<char, char>();
            mapping.Add(')', '(');
            mapping.Add('}', '{');
            mapping.Add(']', '[');

            List<char> stack = new List<char>();


            foreach (char c in s)
            {
                if (mapping.Keys.Contains(c))
                {
                    char top = '#';
                    if (stack.Count != 0)
                    {
                        top = stack[stack.Count - 1];
                        stack.Remove(top);
                    }
                    if (mapping[c] != top)
                        return false;
                }
                else
                {
                    stack.Add(c);
                }
            }
            if (stack.Count == 0) return true;
            else return false;

        }

        public static int MySqrt(int x)
        {
            int l = 0, h = x;
            while (l <= h)
            {
                int mid = (l + h) / 2;
                if ((mid == x / mid))
                    return mid;
                else if (mid < x / mid)
                    l = mid + 1;
                else
                    h = mid - 1;
            }
            return h;
        }
        public static int MySqrt2(int x)
        {
            int d = x / 2;
            while (d > 0)
            {
                if (d * d == x) return d;
                else
                    d = d / 2;
            }
            return d;

        }

        public static bool IsHappy2(int n)
        {
            int i = 0;
            while (i < 50 && n != 0)
            {
                if (n == 1) { return true; }
                string s = n.ToString();
                int sum = 0;
                for (int j = 0; j < s.Length; j++)
                {
                    int d = Convert.ToInt32(s[j].ToString());
                    sum += d * d;
                }
                n = sum;
                i++;
            }
            return false;

        }

        public static bool IsUgly(int n)
        {

            while (n > 0)
            {
                if (n == 1) return true;
                if (n % 2 == 0)
                    n = n / 2;
                else if (n % 3 == 0)
                    n = n / 3;
                else if (n % 5 == 0)
                    n = n / 5;
                else
                    return false;
            }
            return false;

        }
        public static int AddDigits(int num)
        {
            while (num > 9)
            {
                string s = num.ToString();
                int total = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    int d = Convert.ToInt32(s[i].ToString());
                    total += d;
                }
                num = total;
            }
            return num;

        }

        public static IList<int> FindDisappearedNumbers(int[] nums)
        {

            int l = nums.Length;
            Dictionary<int, int> d = new Dictionary<int, int>();

            for (int i = 0; i < l; i++)
            {
                if (!d.Keys.Contains(nums[i]))
                {

                    d[nums[i]] = 1;
                }
                else
                    d[nums[i]] += 1;
            }

            List<int> n = new List<int>();
            for (int i = 1; i <= l; i++)
            {
                if (!d.Keys.Contains(i))
                {
                    n.Add(i);
                }
            }

            return n;
        }

        public static IList<int> FindDuplicates(int[] nums)
        {
            int l = nums.Length;
            Dictionary<int, int> d = new Dictionary<int, int>();

            for (int i = 0; i < l; i++)
            {
                if (!d.Keys.Contains(nums[i]))
                {

                    d[nums[i]] = 1;
                }
                else
                    d[nums[i]] += 1;
            }

            List<int> n = new List<int>();
            foreach (int k in d.Keys)
            {
                if (d[k] == 2)
                {
                    n.Add(k);
                }
            }

            return n;
        }

        public static string[] UncommonFromSentences(string s1, string s2)
        {
            Dictionary<string, int> d = new Dictionary<string, int>();
            string[] strList = s1.Split(' ');
            foreach (string s in strList)
            {
                if (!d.Keys.Contains(s))
                {
                    d[s] = 1;
                }
                else
                    d[s] += 1;
            }
            string[] strList2 = s2.Split(' ');
            foreach (string s in strList2)
            {
                if (!d.Keys.Contains(s))
                {
                    d[s] = 1;
                }
                else
                    d[s] += 1;
            }

            int j = 0;
            string[] comStr = new string[strList.Length + strList2.Length];

            foreach (string k in d.Keys)
            {
                if (d[k] == 1)
                {
                    comStr[j] = k;
                    j++;
                }
            }

            string[] ret = new string[j];
            for (int l = 0; l < j; l++)
            {
                ret[l] = comStr[l];
            }

            return ret;
        }

        public static int[] RelativeSortArray(int[] arr1, int[] arr2)
        {
            int i = 0;
            foreach (int item in arr2)
            {
                for (int j = 0; j < arr1.Length; j++)
                {
                    if (arr1[j] == item)
                    {
                        int temp = arr1[i];
                        arr1[i] = arr1[j];
                        arr1[j] = temp;
                        i++;
                    }
                }
            }

            for (int k = i; k < arr1.Length; k++)
            {
                for (int l = k + 1; l < arr1.Length; l++)
                {
                    if (arr1[l] < arr1[k])
                    {
                        int t = arr1[l];
                        arr1[l] = arr1[k];
                        arr1[k] = t;
                    }
                }

            }

            return arr1;
        }


        public static bool UniqueOccurrences(int[] arr)
        {
            Dictionary<int, int> d = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {

                if (!d.Keys.Contains(arr[i]))
                {
                    d[arr[i]] = 1;
                }
                else
                    d[arr[i]] += 1;
            }
            List<int> v = new List<int>();
            foreach (int item in d.Values)
            {
                v.Add(item);
            }
            HashSet<int> h = new HashSet<int>(v);

            if (v.Count == h.Count)
                return true;
            else
                return false;
        }

        public static int FindLHS(int[] nums)
        {
            Dictionary<int, int> d = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!d.Keys.Contains(nums[i]))
                {
                    d[nums[i]] = 1;
                }
                else
                    d[nums[i]] += 1;
            }

            int res = 0;
            foreach (int k in d.Keys)
            {
                if (d.Keys.Contains(k + 1))
                {
                    res = Math.Max(res, d[k] + d[k + 1]);
                }
            }
            return res;
        }

        public static bool CheckIfPangram(string sentence)
        {
            Dictionary<string, int> d = new Dictionary<string, int>();
            for (int i = 0; i < sentence.Length; i++)
            {
                if (!d.Keys.Contains(sentence[i].ToString()))
                {
                    d[sentence[i].ToString()] = 1;
                }
                else
                    d[sentence[i].ToString()] += 1;
            }

            string s = "abcdefghijklmnopqrstuvwxyz";

            for (int i = 0; i < s.Length; i++)
            {
                if (!d.Keys.Contains(s[i].ToString()))
                {
                    return false;
                }
            }
            return true;

        }

        public IList<int> TwoOutOfThree(int[] nums1, int[] nums2, int[] nums3)
        {
            IList<int> result = new List<int>();

            for (int i = 0; i < nums1.Length; i++)
            {
                if (Array.IndexOf(nums2, nums1[i]) != -1 || Array.IndexOf(nums3, nums1[i]) != -1)
                {
                    if (!result.Contains(nums1[i]))
                    {
                        result.Add(nums1[i]);
                    }
                }
            }

            for (int i = 0; i < nums2.Length; i++)
            {
                if (Array.IndexOf(nums1, nums2[i]) != -1 || Array.IndexOf(nums3, nums2[i]) != -1)
                {
                    if (!result.Contains(nums2[i]))
                    {
                        result.Add(nums2[i]);
                    }
                }
            }

            for (int i = 0; i < nums3.Length; i++)
            {
                if (Array.IndexOf(nums1, nums3[i]) != -1 || Array.IndexOf(nums2, nums3[i]) != -1)
                {
                    if (!result.Contains(nums3[i]))
                    {
                        result.Add(nums3[i]);
                    }
                }
            }

            return result;
        }

        public static int CountWords(string[] w1, string[] w2)
        {
            int r = 0;

            Dictionary<string, int> d1 = new Dictionary<string, int>();
            Dictionary<string, int> d2 = new Dictionary<string, int>();
            foreach (string s in w1)
                if (!d1.ContainsKey(s))
                    d1.Add(s, 1);
                else
                    d1[s]++;

            foreach (string s in w2)
                if (!d2.ContainsKey(s))
                    d2.Add(s, 1);
                else
                    d2[s]++;

            foreach (KeyValuePair<string, int> e in d1)
            {
                if (e.Value > 1) continue;
                else if (d2.ContainsKey(e.Key) && d2[e.Key] == 1) r++;
            }

            return r;
        }

        public static int ArrayPairSum(int[] nums)
        {
            Array.Sort(nums);
            int m = 0;

            for (int i = 0; i < nums.Length - 1; i = i + 2)
            {
                m += Math.Min(nums[i], nums[i + 1]);
            }

            return m;
        }

        public static int[][] MatrixReshape(int[][] mat, int r, int c)
        {
            if (mat.Length * mat[0].Length != r * c) return mat;

            int[][] a = new int[r][];
            int[] b = new int[c];
            int k = 0;
            int r1 = 0;

            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[i].Length; j++)
                {
                    b[k] = mat[i][j];
                    k++;

                    if (k == c)
                    {
                        a[r1] = b;
                        b = new int[c];
                        k = 0;
                        r1++;
                    }
                }

            }

            return a;
        }


        public static int[][] Construct2DArray(int[] original, int m, int n)
        {
            int[][] a = new int[m][];
            int[] b = new int[n];
            int k = 0;
            int c = 0;

            if (m * n != original.Length) return new int[0][];

            for (int i = 0; i < original.Length; i++)
            {
                b[k] = original[i];
                k++;

                if (k == n)
                {
                    a[c] = b;
                    c++;
                    b = new int[n];
                    k = 0;
                }
            }
            return a;
        }
        public static void SetZeroes(int[][] matrix)
        {

            int row = matrix.Length;
            int col = matrix[0].Length;

            HashSet<int> rowHas = new HashSet<int>();
            HashSet<int> colHas = new HashSet<int>();


            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    if (matrix[r][c] == 0)
                    {
                        rowHas.Add(r);
                        colHas.Add(c);
                    }
                }
            }

            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    if (rowHas.Contains(r) || colHas.Contains(c))
                    {
                        matrix[r][c] = 0;
                    }
                }
            }

        }



        public static void setZeroes2(int[][] matrix)
        {
            Boolean isCol = false;
            int R = matrix.Length;
            int C = matrix[0].Length;

            for (int i = 0; i < R; i++)
            {
                if (matrix[i][0] == 0)
                {
                    isCol = true;
                }

                for (int j = 1; j < C; j++)
                {
                    // If an element is zero, we set the first element of the corresponding row and column to 0
                    if (matrix[i][j] == 0)
                    {
                        matrix[0][j] = 0;
                        matrix[i][0] = 0;
                    }
                }
            }

            // Iterate over the array once again and using the first row and first column, update the elements.
            for (int i = 1; i < R; i++)
            {
                for (int j = 1; j < C; j++)
                {
                    if (matrix[i][0] == 0 || matrix[0][j] == 0)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }

            // See if the first row needs to be set to zero as well
            if (matrix[0][0] == 0)
            {
                for (int j = 0; j < C; j++)
                {
                    matrix[0][j] = 0;
                }
            }

            // See if the first column needs to be set to zero as well
            if (isCol)
            {
                for (int i = 0; i < R; i++)
                {
                    matrix[i][0] = 0;
                }
            }
        }

        public int[] SearchRange(int[] nums, int target)
        {
            int i = 0, j = nums.Length - 1;
            while (i <= j)
            {
                int mid = i + (j - i) / 2;
                if (nums[mid] == target)
                {
                    int start = mid - 1, end = mid + 1;
                    while (start >= 0 && nums[start] == target) start--;
                    while (end < nums.Length && nums[end] == target) end++;
                    return new int[] { start + 1, end - 1 };
                }
                else if (nums[mid] > target)
                {
                    j = mid - 1;
                }
                else
                {
                    i = mid + 1;
                }
            }

            return new int[] { -1, -1 };
        }

        public IList<string> SummaryRanges(int[] nums)
        {
            if (nums.Length == 0)
                return new string[] { };
            if (nums.Length == 1)
                return new string[] { nums[0].ToString() };

            IList<string> res = new List<string>();

            int start = nums[0], end = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                if ((end + 1) < nums[i])
                {
                    res.Add(start == nums[i - 1] ? start.ToString() : (start.ToString() + "->" + end.ToString()));
                    start = nums[i];
                }
                end = nums[i];
            }
            res.Add(start == end ? start.ToString() : (start.ToString() + "->" + end.ToString()));
            return res;
        }

        public int FindLengthOfLCIS(int[] nums)
        {
            int count = 1;
            int maxCount = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[i - 1])
                {
                    count++;
                    maxCount = Math.Max(maxCount, count);
                }
                else
                {
                    count = 1;
                }
            }
            return maxCount;
        }

        public static int[] ArrayRankTransform(int[] arr)
        {
            int[] temp = new int[arr.Length];
            Array.Copy(arr, temp, arr.Length);

            Dictionary<int, int> map = new Dictionary<int, int>();

            Array.Sort(temp);
            for (int i = 0; i < temp.Length; i++)
            {
                if (!map.Keys.Contains(temp[i]))
                {
                    map.Add(temp[i], map.Count + 1);
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = map[arr[i]];
            }
            return arr;

        }

        public static double FindMaxAverage(int[] nums, int k)
        {
            double ma = int.MinValue;
            for (int i = 0; i < nums.Length - k + 1; i++)
            {
                int a = 0;
                for (int j = i; j < i + k; j++)
                {
                    a += nums[j];
                }
                double d = (a * 1.0) / k;
                ma = Math.Max(ma, d);
            }
            return ma;

        }
        public static int MaximumProduct(int[] nums)
        {
            int max1 = int.MinValue;
            int max2 = int.MinValue;
            int max3 = int.MinValue;

            int min1 = int.MaxValue;
            int min2 = int.MaxValue;

            foreach (int n in nums)
            {
                if (n >= max1)
                {
                    max3 = max2;
                    max2 = max1;
                    max1 = n;
                }
                else if (n >= max2)
                {
                    max3 = max2;
                    max2 = n;
                }
                else if (n >= max3)
                {
                    max3 = n;
                }


                if (n <= min1)
                {
                    min2 = min1;
                    min1 = n;
                }
                else if (n <= min2)
                {
                    min2 = n;
                }
            }
            return Math.Max(min1 * min2 * max1, max3 * max2 * max1);
        }

        public static int FindLucky(int[] arr)
        {

            Dictionary<int, int> d = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {

                if (!d.Keys.Contains(arr[i]))
                {

                    d.Add(arr[i], 1);
                }
                else
                    d[arr[i]] += 1;
            }

            int l = -1;
            foreach (int k in d.Keys)
            {

                if (k == d[k])
                {
                    l = Math.Max(l, k);
                }
            }
            return l;
        }
        public static IList<int> LuckyNumbers(int[][] matrix)
        {
            int row = matrix.Length;
            int col = matrix[0].Length;
            List<int> l = new List<int>();

            for (int r = 0; r < row; r++)
            {
                int minRow = int.MaxValue;
                int[] rr = matrix[r];
                minRow = rr.Min();

                for (int c = 0; c < col; c++)
                {
                    if (matrix[r][c] == minRow)
                    {

                        int maxCol = int.MinValue;
                        for (int i = 0; i < row; i++)
                        {
                            if (matrix[i][c] > maxCol)
                            {
                                maxCol = matrix[i][c];
                            }
                        }
                        if (maxCol == minRow) l.Add(maxCol);
                    }

                }
            }

            return l;
        }

        public static int[] FindDiagonalOrder(int[][] mat)
        {
            int row = mat.Length;
            int col = mat[0].Length;
            Dictionary<int, List<int>> d = new Dictionary<int, List<int>>();

            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    if (!d.Keys.Contains(r + c))
                    {
                        List<int> l = new List<int>();
                        l.Add(mat[r][c]);
                        d[r + c] = l;
                    }
                    else
                    {
                        d[r + c].Add(mat[r][c]);
                    }

                }
            }
            int[] ret = new int[row * col];
            int p = 0;
            foreach (int k in d.Keys)
            {
                List<int> l = d[k];
                if (k % 2 != 0)
                {
                    foreach (int item in l)
                    {
                        ret[p] = item;
                        p++;
                    }
                }
                else
                {
                    l.Reverse();
                    foreach (int item in l)
                    {
                        ret[p] = item;
                        p++;
                    }

                }
            }
            return ret;

        }

        public static int[][] Transpose(int[][] m)
        {
            int row = m.Length;
            int col = m[0].Length;
            int[][] ma = new int[col][];

            for (int c = 0; c < col; c++)
            {
                int[] a = new int[row];
                for (int r = 0; r < row; r++)
                {
                    a[r] = m[r][c];
                }
                ma[c] = a;
            }
            return ma;
        }

        public static int Fib1(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            return Fib(n - 1) + Fib(n - 2);

        }

        public static int Fib(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            int fst = 0;
            int snd = 1;
            int next = fst + snd;
            while (n > 2)
            {
                fst = snd;
                snd = next;
                next = fst + snd;
                n--;
            }
            return next;
        }
        public static int fib(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            int first = 0;
            int second = 1;
            int next = first + second;
            for (int i = 2; i < n; i++)
            {
                first = second;
                second = next;
                next = first + second;
            }
            return next;
        }

        public static int isfibo(int n)
        {
            if (n == 1) return 1;
            int first = 1;
            int second = 1;
            int next = first + second;
            while (second < n)
            {
                first = second;
                second = next;
                next = first + second;
            }
            if ((second == n) || (first == n) || (next == n)) return 1;
            else return 0;
        }

        public static int isFancey(int n)
        {
            if (n == 1) return 1;
            int first = 1;
            int second = 1;
            int next = 2*first + 3*second;
            while (second < n)
            {
                first = second;
                second = next;
                next = 2*first + 3*second;
            }
            if ((second == n) || (first == n) || (next == n)) return 1;
            else return 0;
        }

        public static int closestFibonacci1(int n) // was wrong 
        {
            int index = int.MaxValue;
            int[] a = new int[500];
            a[0] = 1;
            a[1] = 1;
            int result = 0;
            for (int i = 2; i < index; i++)
            {
                a[i] = a[i - 1] + a[i - 2];
                if (a[i] >= n)
                {
                    result = a[i - 2] + a[i - 3];
                    break;
                }
                
            }
            return result;
        }

        public static int closestFibonacci(int n) 
        {
            int n1 = 1;
            int n2 = 1;
            int next = n1 + n2;

            while (next < n)
            {
                n1 = n2;
                n2 = next;
                next = n1 + n2;
            }
            return n2;
        }


        public static bool CheckPerfectNumber(int num)
        {
            int s = 1;
            for (int i = 2; i <= num / 2; i++)
            {
                if (num % i == 0)
                {
                    s += num / i;
                }
            }

            if (num == s) return true;
            else return false;
        }

        public static void Floyed(int n)
        {
            int x = 1;
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < r + 1; c++)
                {
                    Console.Write(x + " ");
                    x++;
                }
                Console.WriteLine();
            }
        }

        public static int[][] Floyed1(int n)
        {
            int[][] m = new int[n][];
            int x = 1;
            for (int r = 0; r < n; r++)
            {
                int[] a = new int[r + 1];

                if (r % 2 == 0) x = 1;
                else x = 0;

                for (int c = 0; c < r + 1; c++)
                {
                    a[c] = x;
                    x = x == 1 ? 0 : 1;
                }
                m[r] = a;
            }

            return m;

        }

        /*
         
         def isValidSubsequence2(array, sequence):
   idxs = 0
   for a in array:
       if idxs == len(sequence):
           break
       if a == sequence[idxs]:
           idxs += 1
   return idxs == len(sequence)
         
         */

        public static bool isValidSubsequence2(int[] array, int[] sequence)
        {
            int idxa = 0;
            int idxs = 0;
            while (idxa < array.Length && idxs < sequence.Length)
            {
                if (array[idxa] == sequence[idxs])
                {
                    idxs += 1;
                }

                idxa += 1;
            }

            if (idxs == sequence.Length)
                return true;
            else
                return false;
        }



        public static bool isValidSubsequence(string array, string sequence)
        {
            int idxa = 0;
            int idxs = 0;
            while (idxa < array.Length && idxs < sequence.Length)
            {
                if (array[idxa] == sequence[idxs])
                {
                    idxs += 1;
                }
                idxa += 1;
            }
            if (idxs == sequence.Length)
                return true;
            else
                return false;
        }


        //public bool IsToeplitzMatrix(int[][] matrix)
        //{
        //    Dictionary<List<Tuple<int, int>>, int> d = new Dictionary<List<Tuple<int, int>>, int>();

        //    int row = matrix.Length;
        //    int col = matrix[0].Length;

        //    for (int r = 0; r < row; r++)
        //    {
        //        for (int c = 0; c < col; c++)
        //        {
        //            if (!d.Keys.Contains())
        //            {
        //                List<Tuple<int, int>> l = new List<Tuple<int, int>>();
        //                Tuple<int, int> t = new Tuple<int, int>(r, c);
        //                l.Add(t);

        //                d.Add(l, matrix[r][c]);
        //            }
        //            else
        //            {


        //            }

        //        }
        //    }
        // }

        public static bool IsToeplitzMatrix(int[][] matrix)
        {
            for (int r = 0; r < matrix.Length; r++)
                for (int c = 0; c < matrix[0].Length; c++)
                    if (r > 0 && c > 0 && matrix[r - 1][c - 1] != matrix[r][c])
                        return false;
            return true;
        }

        public static IList<string> CommonChars(string[] words)
        {
            IList<string> l = new List<string>();

            if (words.Length == 1)
            {
                foreach (var w in words[0])
                {
                    l.Add(w.ToString());
                }
                return l;
            }

            l = CommonCharsDictAndString(words[0], words[1]);
            int i = 2;

            while (i < words.Length)
            {
                string s = "";
                foreach (var item in l)
                {
                    s += item;
                }

                l = CommonCharsDictAndString(s, words[i]);
                i++;
            }

            return l;
        }

        public static IList<string> CommonCharsDictAndString(string sList1, string sList2)
        {
            List<string> l = new List<string>();

            Dictionary<char, int> d1 = new Dictionary<char, int>();

            foreach (char s in sList1)
                if (!d1.ContainsKey(s))
                    d1.Add(s, 1);
                else
                    d1[s]++;

            Dictionary<char, int> d2 = new Dictionary<char, int>();
            foreach (char s in sList2)
                if (!d2.ContainsKey(s))
                    d2.Add(s, 1);
                else
                    d2[s]++;

            if (sList1.Length > sList2.Length)
                l = CommonDict(d1, d2);
            else
                l = CommonDict(d2, d1);

            return l;

        }

        public static List<string> CommonDict(Dictionary<char, int> d1, Dictionary<char, int> d2)
        {
            List<string> l = new List<string>();
            foreach (KeyValuePair<char, int> e in d1) // "cool"  "cook"
            {
                if (d2.ContainsKey(e.Key))
                {
                    int m = Math.Min(d2[e.Key], d1[e.Key]);
                    for (int i = 0; i < m; i++)
                    {
                        l.Add(e.Key.ToString());
                    }
                }
            }
            return l;
        }

        public static bool WordBreak(string s, IList<string> wordDict)
        {
            int totalLength = 0;
            foreach (var word in wordDict)
            {
                totalLength += word.Length;
            }

            if (totalLength > s.Length)
            {
                return false;
            }

            // s = "applepenapple", wordDict = ["apple","pen"]   apple pen bd apple
            // s = "leetcode", wordDict = ["leet","code"]

            foreach (var word in wordDict)
            {
                if (!s.Contains(word))
                {
                    return false;
                }
                else
                {

                }
            }


            return false;
        }

        public bool WordBreak1(string s, IList<string> wordDict)
        {
            var res = new bool[s.Length + 1];
            res[s.Length] = true;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                foreach (var w in wordDict)
                {
                    if (i + w.Length <= s.Length && w == s.Substring(i, w.Length))
                    {
                        res[i] = res[i + w.Length];
                    }

                    if (res[i])
                    {
                        break;
                    }
                }
            }

            return res[0];
        } 


       

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int[] num = new int[nums1.Length + nums2.Length];
            nums1.CopyTo(num, 0);
            nums2.CopyTo(num, nums1.Length);
            Array.Sort(num);

            int mid = 0;
            if (num.Length % 2 == 0) // even 1 2 3 4
            {
                mid = num.Length / 2;
                return (num[mid - 1] + num[mid]) / 2.0;
            }
            else // odd 1 2 3
            {
                mid = num.Length / 2;
                return num[mid];
            }

        }

        public static bool HasCycle(ListNode head)
        {
            Dictionary<int, int> d = new Dictionary<int, int>();
            int res = -1;
            int c = 0;
            while (head != null)
            {
                if (!d.ContainsKey(head.val))
                {
                    d.Add(head.val, c);
                }
                else
                {
                    res = d[head.val] + 1;
                    break;
                }
                c++;
                head = head.next;
            }
            return res > 0;

        }

        public bool hasCycle(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return false; // No cycle if there are less than two nodes.
            }

            ListNode slow = head;
            ListNode fast = head;

            while (fast != null && fast.next != null)
            {
                slow = slow.next; // Move one step.
                fast = fast.next.next; // Move two steps.

                if (slow == fast)
                {
                    return true; // Cycle detected.
                }
            }

            return false; // No cycle found.
        }

        public static int largestAdjacentSum(int[] a)
        {
            int maxSum = int.MinValue;
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i-1] + a[i] > maxSum)
                {
                    maxSum = a[i - 1] + a[i];
                }
            }
            return maxSum;
        }

        public static int checkConcatenatedSum(int n, int catlen)
        {
            int sum = 0;
            string num = n.ToString();
            for (int i = 0; i < num.Length; i++)
            {
                string s = num[i].ToString();
                for (int j = 1; j < catlen; j++)
                {
                    s = s + num[i];
                }
                sum = sum + Convert.ToInt32(s);
            }
            if (n == sum) return 1;
            else return 0;         
        }

        public static int checkConcatenatedSum1(int n, int catlen)
        {

            int remainder = 0;
            int quotient = 0;
            int total = 0;
            int num = n;
            while (n>0)
            {
                remainder = n % 10;
                quotient = n / 10;
                n = quotient;

                int finalRemainder = remainder;
                for (int i = 1; i < catlen; i++)
                {
                    finalRemainder = finalRemainder * 10 + remainder;
                }

                total += finalRemainder;
            }

            return total == num ? 1 : 0;
        }


       

        public static int isSequencedArray(int[] a, int m, int n)
        {
            if (a[0] != m) return 0;
            else if (a[a.Length - 1] != n) return 0;
            else if (n - m + 1 != a.Length) return 0;

            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] >= a[i - 1]) continue;
                else return 0;
            }
            return 1;
        
        }
        public static int isSequencedArray1(int[] a, int m, int n)
        {
            // {-5, -5, -4, -4, -4, -3, -3, -2, -2, -2}
            int count = n - m + 1;
            if ((a[0] != m) || (a[a.Length-1] != n))
            {
                return 0;
            }
            for (int i = 1; i < a.Length; i++)
            {
                if ( (a[i-1] == a[i]) || (a[i - 1] + 1 == a[i]) )
                {
                    continue;
                }
                else
                {
                    return 0;
                }
            }            
            return 1;
        }

        public static int largestPrimeFactor1(int num)
        {
            if (num <= 1) return 0;
            int number = num;
            while (number > 1)
            {
                if (num % number == 0)
                {
                    bool isPrime = true;
                    for (int i = 2; i < number; i++)
                    {
                        if (number % i == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                    if (isPrime) return number;
                }
                number--;
            }
            return 0;
        }
        public static int largestPrimeFactor2(int n)  // most efficient function
        {
            if (n <= 1) return 0;
            List<int> primeFactors = new List<int>();

            for (int i = 2; i < n; i++)
            {
                while (n % i == 0)
                {
                    primeFactors.Add(i);
                    n = n / i;
                }
            }
            if (n > 1) primeFactors.Add(n);
            return primeFactors.Max();

        }
        public static int largestPrimeFactor(int num)
        {
            if (num <= 1) return 0;
            for (int i = num; i > 1; i--)
            {
                if (num % i == 0)
                {
                    if (IsPrime(i))
                    {
                        return i;
                    }
                }
               
            }
            return 0;
        
        } // backward way

        public static int largestPrimeFactor3(int n)  // written in copy
        {
            int l = 0;
            for (int i = 2; i <= n; i++)
            {
                if (n % i == 0)
                {
                    if (IsPrime(i))
                    {
                        l = Math.Max(l, i);
                    }

                }
            }
            return l;
        }
        public static bool IsPrime(int number) {

            bool isPrime = true;
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            return isPrime;
        }
        public static int[] encodeNumber(int n) 
        {
            if (n < 2) return null;
            List<int> l = new List<int>();
            for (int i = n; i > n; i--)
            {
                if (n % i == 0)
                {
                    if (IsPrime(i))
                        l.Add(i);
                }
            }

            int[] a = new int[l.Count]; 
            //for (int i = 0; i < l.Count - 1; i++)
            //{
            //    a[i] = l[i];
            //}

            //l.CopyTo(a);

            return l.ToArray();
        
        }

        public static int[] encodeNumber1(int n)
        {
            if (n <= 1) return null;
            List<int> primeFactors = new List<int>();

            for (int i = 2; i < n; i++)
            {
                while (n % i == 0)
                {
                    primeFactors.Add(i);
                    n = n / i;
                }
            }


            if (n > 1) primeFactors.Add(n);
            int[] arrayToReturn = new int[primeFactors.Count];

            primeFactors.CopyTo(arrayToReturn);

            //for (int i = 0; i < primeFactors.Count; i++)
            //{
            //    arrayToReturn[i] = primeFactors[i];
            //}


            return arrayToReturn;
        }

        static int matchPattern1(int[] a, int len, int[] pattern, int patternLen)
        {
            // { 1, 1, 2, 2, 2, 3 };
            // {1, 2 ,3};
            // {1, 1, 1, 2, 2, 1, 1, 3} array  {1, 2, 1, 3} pattern
            int p = pattern[0];
            int j = 0;
            int s = 1;

            while (j < pattern.Length-1)
            {
                for (int i = 1; i < a.Length; i++)
                {
                    if ((a[i] != p) && (a[i-1] != a[i]))
                    {
                        j++;
                        p = pattern[j];
                    }
                    if (p != a[i])
                    {
                        return 0;
                    }
                }                
            } 
            return 1;
        }

        static int matchPattern3(int[] a, int len, int[] pattern, int patternLen) // wrong
        {
            var h = new HashSet<int>(a);
            if (h.Count != pattern.Length) return 0;
            foreach (int i in h)
            {
                bool found = false;
                for (int j = 0; j < pattern.Length; j++)
                {
                    if (pattern[j] == i)
                    {
                        found = true;
                        break;
                    }
                }
                if (found == false) return 0;     
                
            }
            return 1;
        }

        static int matchPattern(int[] a, int len, int[] pattern, int patternLen)
        {
            var h = new HashSet<int>(a);
            if (h.Count != pattern.Length) return 0;

            int i = 0;
            foreach (int item in h)
            {
                if (item != pattern[i]) return 0;
                i++;
            }
            return 1;
        }



        static int matchPattern2(int[] a, int len, int[] pattern, int patternLen)
        {
            int i = 0; // index into a
            int k = 0; // index into pattern
            int matches = 0; 
            for (i = 0; i < len; i++)
            {
                if (a[i] == pattern[k])
                    matches++; 
                else if (matches == 0 || k == patternLen - 1)
                    return 0; 
                else  {
                    //!!You write this code!!
                      } // end of else
            } // end of for
            if (i==len && k==patternLen-1) 
                return 1; 
            else return 0;
        }


        static int isCubePowerful1(int n)
        {
            // 153
            if (n < 0)
            {
                return 0;
            }
            int sum = 0;
            int num = n;
            while (n>0)
            {
                int r = n % 10;
                int q = n / 10;
                n = q;
                sum += r * r * r;
            }
            if (num == sum)
                return 1;
            else
                return 0;
        }

        static int isCubePowerful(int n)
        {
            if (n < 1) return 0;
            int s = 0;
            while (n>0)
            {
                int r = n % 10;
                s = s + (r * r * r);
                n = n / 10;
            }
            if (s == n)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        static int decodeArray2(int[] a)
        {
            string n = "";
            for (int i = 1; i < a.Length; i++)
            {
                int val = Math.Abs(a[i - 1] - a[i]);
                n += val.ToString();
            }
            return Convert.ToInt32(n);
        }

        static int decodeArray(int[] a)  // wrong
        {
            //{0, 1, 1, 1, 1, 1, 0, 1}
            // {0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1}
            string s = "";

            int countZero = 0;
            if (a[0] == 0)
            {
                countZero = 1;
            }
            else if(a[0] == 1)
            {
                s = "1";
            }
            else if (a[0] < 0)
            {
                s = "-";
            }


            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] == 0 && a[i-1] == a[i])
                {
                    countZero++;
                }
                else if (a[i] == 0 && a[i - 1] == 1)
                {
                    countZero++;
                }
                else if(a[i] == 1 && countZero > 0)
                {
                    s += countZero.ToString();
                    countZero = 0;
                }
                else if (a[i] == 1 && countZero == 0)
                {
                    s += "1";
                    countZero = 0;
                }
            }

            return Convert.ToInt32(s);
        }

        static int decodeArray1(int[] a) 
        {
            string s = "";
            int zc = 0;
            if (a[0] == -1) s = "-";
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == 0) zc++;
                else if (a[i] == 1)
                {
                    s = s + zc.ToString();
                    zc = 0;
                }
            }
            return Convert.ToInt32(s);
        }

        static int isZeroPlentiful1(int[] a)
        {
            if (a.Length < 4) return 0;
            int c = 0; int zero = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if ((a[i] == 0) && (zero == 0))
                    zero = 1;
                else if ((zero > 0) && (a[i] == 0) && (a[i - 1]) == 0)
                    zero++;
                else if((a[i] != 0)&&(zero>0))
                {
                    if (zero >= 4) { c++; zero = 0; }
                    else { zero = 0; return 0; }
                }
            }
            if (zero > 0) c++;
            return c;
        }
       

       static int isZeroPlentiful(int[] a)  // wrong
        {
            int count = 0;
            int ret = 0;
            for (int i = 1; i < a.Length; i++)
            {
                if ((a[i - 1] == a[i]) && (a[i] == 0))
                {
                    count++;
                }
                else if (a[i] == 0)
                {
                    count++;
                }
                else
                {
                    count = 0;
                }

                if (count >= 4)
                    ret++;

            }
            return ret;
        }
       static int[] encodeArray1(int n)
        {
            List<int> a = new List<int>();
            int init = 0;
            if (n < 0)
            {
                a.Add(-1);
                init = 1;
            }
            string s = n.ToString(); // 1234
            for (int i = init; i < s.Length; i++)
            {
                int num = Convert.ToInt32(s[i].ToString());
                for (int j = 0; j < num; j++)
                {
                    a.Add(0);
                }
                a.Add(1);
            }

            int[] Arr = new int[a.Count];
            a.CopyTo(Arr);
            return Arr;

        }
        static int[] encodeArray(int n) 
        {
            string s = n.ToString();
            List<int> l = new List<int>();
            if (n < 0) l.Add(-1);

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].ToString() == "0")
                {
                    l.Add(1);
                }
                else
                {
                    int c = Convert.ToInt32(s[i].ToString());
                    for (int j = 0; j < c; j++)
                    {
                        l.Add(0);
                        l.Add(1);
                    }
                }
            }
            int[] a = new int[l.Count];
            l.CopyTo(a);
            return a;
        }


        static int isSystematicallyIncreasing1(int[] a)
        {
            //{1, 1, 2, 1, 2, 3}
            if (a[0] != 1)
                return 0;
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i - 1] + 1 != a[i])
                {
                    if (a[i] != 1)
                        return 0;
                }
            }
            return 1;
        }
        static int isSystematicallyIncreasing2(int[] a) 
        {
            if ((a.Length == 2) &&(a[0] != 1) ) return 0;
            if ( (a.Length == 3)&&(a[1] != 1)&&(a[2] != 2) ) return 0;
            int l = 1;
            for (int i = 3; i < a.Length; i++)
            {
                if (a[i] == 1)
                {
                    if (l + 1 == a[i - 1]) 
                        l = a[i - 1]; // l assignment
                    else return 0;
                }                
            }
            if (l+1 == a[a.Length-1]) return 1;
            else return 0;
        }



        public static int isSystematicallyIncreasing(int[] a)
        {
            int c = a.Length;
            List<int> l = new List<int>();
            int d = 1;

            while (l.Count < c)
            {
                LisCreate(l, d);
                d++;
            }

            if ((l.Count == a.Length) && l.SequenceEqual(a.ToArray()))
                return 1;
            else return 0;            
           
           
        }

        private static void LisCreate(List<int> l, int n)
        {
            for (int i = 1; i <= n ; i++)
            {
                l.Add(i);   
            }
        }

        static int isFactorialPrime(int n) 
        {
            if (isPrime(n))
            {
                for (int i = 1; i < n; i++)
                {
                    if (factorial(i) + 1 == n) return 1;
                    // return 0;
                }
                return 0;
            }
            else return 0;
        }

        public static int factorial(int n) {

            int f = 1;
            for (int i = 1; i <= n; i++)
            {
                f = f * i;
            }
            return f;
        }

        static int isFactorialPrime1(int n)
        {
            if (IsPrime(n) && CheckFactorial(n))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private static bool CheckFactorial(int n)
        {
            // 7
            int i = 2;
            int num = 1;
            while (num + 1 <= n)
            {
                if (num + 1 == n)
                {
                    return true;
                }
                num *= i;
                i++;
            }
            return false;
        }
        static int largestDifferenceOfEvens1(int[] a)
        {
            List<int> evenList = new List<int>();
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] % 2 == 0)
                {
                    evenList.Add(a[i]);
                }
            }
            if (evenList.Count < 2)
            {
                return -1;
            }

            return evenList.Max() - evenList.Min();
        }


        static int largestDifferenceOfEvens(int[] a) 
        {
            int min = Int32.MaxValue;
            int max = Int32.MinValue;

            int c = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] % 2 == 0)
                {
                    if (a[i] > max) max = a[i];
                    if (a[i] < min) min = a[i];
                    c++;
                }
            }
            if (c < 2) return -1;
            else return max - min;
        
        }


        private static bool CheckHodder(int n)
        {
            //2 * 2 * 2
            int i = 2;
            int num = 2;
            while (num - 1 <= n)
            {
                if (num - 1 == n)
                {
                    return true;
                }
                num *= i;
            }
            return false;
        }


        static int isHodder(int n)
        {
            if (pow(n)&& IsPrime(n))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }


        public static bool pow(int n)
        {
            n = n + 1;
            int j = 2;
            while (j<n)
            {
                j = j * 2;
            }
            if (j == n)
            {
                return true;
            }
            else
                return false;
        }
       

        static int MaxCoins(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;

            int n = nums.Length;
            int[][] coins = new int[n][];
            for (int i = 0; i < n; i++)
            {
                coins[i] = new int[n];
            }

            for (int gap = 0; gap < n; gap++)
            {
                for (int r = 0, c = gap; c < n; c++, r++)
                {
                    int max_coins = 0;
                    for (int k = r; k <= c; k++)
                    {
                        int left = (k == r) ? 0 : coins[r][k - 1];
                        int right = (k == c) ? 0 : coins[k + 1][c];

                        int leftNum = r == 0 ? 1 : nums[r - 1];
                        int rightNum = c == n - 1 ? 1 : nums[c + 1];

                        int curr_cost = leftNum * nums[k] * rightNum;

                        int cost = left + right + curr_cost;

                        max_coins = Math.Max(max_coins, cost);
                    }

                    coins[r][c] = max_coins;
                }
            }

            return coins[0][n - 1];
        }
        static int maxCoins2(int[] nums)
        {
            int n = nums.Length;
            int[][] dp = new int[n + 2][];
            for (int i = 0; i < n+2; i++)
            {
                dp[i] = new int[n+2];
            }


            int[] arr = new int[n + 2];
            for (int i = 1; i <= n; i++)
            {
                arr[i] = nums[i - 1];
            }
            arr[0] = 1;
            arr[n + 1] = 1;

            for (int i = n; i >= 1; i--)
            {
                for (int j = i; j <= n; j++)
                {
                    for (int k = i; k <= j; k++)
                    {
                        dp[i][j] = (int)Math.Max(dp[i][j], arr[i - 1] * arr[j + 1] * arr[k] + dp[i][k - 1] + dp[k + 1][j]);
                    }
                }
            }

            return dp[1][n];
        }


        static int MaxNumberOfBalloons(string text)
        {           

            int bCount = text.Count(c => c == 'b');  
            int aCount = text.Count(c => c == 'a');  
            int nCount = text.Count(c => c == 'n');  
            int oCount = text.Count(c => c == 'o');   
            int lCount = text.Count(c => c == 'l');

            var m = Math.Min( Math.Min(Math.Min( bCount,aCount),nCount) , Math.Min( lCount/2,oCount/2) );
            return m;

        }

        static int BalancedStringSplit(string s)
        {
            int rCount = 0;
            int lCount = 0;
            int b = 0;
            for (int c = 0; c < s.Length; c++)
            {               
                if (s[c].ToString() == "R")
                {
                    rCount += 1;
                }
                else if (s[c].ToString() == "L")
                {
                    lCount += 1;
                }
                if (rCount == lCount)
                {
                    b += 1;
                    rCount = 0;
                    lCount = 0;
                }
            }

            return b;
        }
        #region Dynamic cell calculation

        private static Tuple<List<string>, List<string>, List<string>, List<string>, List<string>, string> Max2CellCalculationNew(int? id, int superQt, int superLockQty, int lockingQty, int configurationType)
        {
            List<string> superCell = new List<string>();
            List<string> superLockingCell = new List<string>();
            List<string> regularCell = new List<string>();
            List<string> lockingCell = new List<string>();

            List<string> remainingCells = new List<string>();

            List<string> aToN = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N" };
            List<string> oToV = new List<string> { "O", "P", "Q", "R", "S", "T", "U", "V" };
            List<string> aTov = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V" };
            string msg = "";
            int superMax = 89; int superMin = 22;
            if (superQt > superMax)
            {
                msg = "Super Quantity exceed the superMax limit";
                return new Tuple<List<string>, List<string>, List<string>, List<string>, List<string>, string>(superCell, lockingCell, superLockingCell, regularCell, remainingCells, msg);
            }
            List<string> regularOrder = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9" }; // 3             
            List<string> supperOrder = new List<string> { "4", "7", "9", "2" };

            int regularQty = 0;

            if (id == 3) //for max2 128L/36S/  "Max 2 – CVS Full"
            {
                superQt = 0; superLockQty = 36; lockingQty = 128;
            }
            else if (id == 4)  // "Max 2 – Kroger Std"
            {
                superQt = 0; superLockQty = 45; lockingQty = 110;
            }
            else if (id == 5)  // "Max 2 – Lite"
            {
                superQt = 88; regularQty = 22; //superLockQty = 0; lockingQty = 0; ?? formula wise regularQty = 24
            }

            if (superQt == superMax)
            {
                regularQty = (200 - superQt * 2); // 22
            }
            else
            {
                regularQty = (200 - superQt * 2) - 2; // 22
            }


            if (configurationType == 3)
            {
                superLockQty = superQt;
                lockingQty = regularQty + 2;
            }



            if (id == 1 || id == 2) // std mainfold and full mainfold
            {
                List<string> assignedSupperOrder = new List<string>();
                List<string> assignedSupperFractionCell = new List<string>();
                string assignedSupperFractionCellNo ="";

                SuperCellCalculation(superCell, superQt, superMax, aTov, supperOrder, assignedSupperOrder, assignedSupperFractionCell, ref assignedSupperFractionCellNo);
               
                ReverseCellCalculation(ref remainingCells, superCell, assignedSupperFractionCell,assignedSupperOrder,aTov);

                List<string> assignedRegularOrder = new List<string>();
                List<string> assignedRegularFractionCell = new List<string>();
                List<string> assignedRegularFractionCellOrder = new List<string>();

                RegularCellCalculationBasedOnSuper(regularCell, regularQty, superQt, superMax, aTov, regularOrder, assignedSupperOrder, assignedSupperFractionCell, assignedRegularOrder, assignedRegularFractionCell, assignedRegularFractionCellOrder);


                remainingCells = remainingCells.Except(regularCell).ToList();


                var tupleResult = DynamicLockingAndSuperLocking(superLockQty, lockingQty, superMax, aTov, assignedSupperOrder,
                   assignedSupperFractionCell, assignedRegularOrder, superCell, superLockingCell, lockingCell, regularCell,
                   assignedRegularFractionCell, assignedRegularFractionCellOrder, superQt, assignedSupperFractionCellNo);

                superCell = tupleResult.Item1;
                lockingCell = tupleResult.Item2;
                superLockingCell = tupleResult.Item3;
                regularCell = tupleResult.Item4;


            }
            else if (id == 3)
            {
                superQt = 0;
                superLockQty = 36;
                lockingQty = 128;


                foreach (var item in aTov) // 22
                    superLockingCell.Add(item + "2");

                foreach (var item in aToN) // 14
                    superLockingCell.Add(item + "4");

                for (var i = 1; i < 10; i++)
                {
                    if (i == 5 || i == 6 || i == 7 || i == 8 || i == 9)
                        foreach (var item in aTov)
                            lockingCell.Add(item + i);
                    if (i == 3 || i == 4)
                        foreach (var item in oToV)
                            lockingCell.Add(item + i);
                }

                lockingCell.Add("6X");
                lockingCell.Add("7Y");
            }
            else if (id == 4)
            {
                superQt = 0;
                superLockQty = 45;
                lockingQty = 110;

                foreach (var item in aTov) superLockingCell.Add(item + "2");
                foreach (var item in aTov) superLockingCell.Add(item + "4");
                superLockingCell.Add("7Y");

                for (var i = 1; i < 10; i++)
                    if (i == 5 || i == 6 || i == 7 || i == 8 || i == 9)
                        foreach (var item in aTov)
                            lockingCell.Add(item + i);
            }
            else if (id == 5) // Max-Lite 2
            {
                superQt = 88;
                regularQty = 22;

                // Note: Standard superQt = 88 and regularQty = 22 fixed.  so custom can not greater then that. right???

                foreach (var item in aTov) // 22
                    regularCell.Add(item + "5");

                for (var i = 4; i < 10; i++) // { "4", "7", "9", "2" };
                    if (i == 4 || i == 7 || i == 9)
                        foreach (var item in aTov)
                            superCell.Add(item + i);

                foreach (var item in aTov) superCell.Add(item + "2");


                var assignedSupperOrder = new List<string> { "4", "7", "9", "2" };
                var assignedRegularOrder = new List<string> { "5" };
                var assignedSupperFractionCell = new List<string>();
                var assignedRegularFractionCell = new List<string>();
                var assignedRegularFractionCellOrder = new List<string>();
                string assignedSupperFractionCellNo = "";


                ReverseCellCalculation(ref remainingCells, superCell, assignedSupperFractionCell, assignedSupperOrder, aTov);


                if (superLockQty <= superQt && lockingQty <= regularQty)
                {
                    var tupleResult = DynamicLockingAndSuperLocking(superLockQty, lockingQty, superMax, aTov, assignedSupperOrder,
                   assignedSupperFractionCell, assignedRegularOrder, superCell, superLockingCell, lockingCell, regularCell,
                   assignedRegularFractionCell, assignedRegularFractionCellOrder, superQt, assignedSupperFractionCellNo);

                    superCell = tupleResult.Item1;
                    lockingCell = tupleResult.Item2;
                    superLockingCell = tupleResult.Item3;
                    regularCell = tupleResult.Item4;
                }
                else
                {
                    msg = "SuperLocking Quantity exceed the Super Quantity OR RegularLocking Quantity exceed the Regular Quantity";
                }

                

            }



            return new Tuple<List<string>, List<string>, List<string>, List<string>, List<string>, string>(superCell, lockingCell, superLockingCell, regularCell, remainingCells, msg);


        }

        public static Tuple<List<string>, List<string>, List<string>, List<string> > DynamicLockingAndSuperLocking(int superLockQty, int lockingQty, int superMax, List<string> aTov,
          List<string> assignedSupperOrder, List<string> assignedSupperFractionCell, List<string> assignedRegularOrder,
          List<string> superCell, List<string> superLockingCell, List<string> lockingCell, List<string> regularCell,
          List<string> assignedRegularFractionCell, List<string> assignedRegularFractionCellOrder, int superQt, string assignedSupperFractionCellNo)
        {
            if (superLockQty > 0 || lockingQty > 0)
            {
                if (assignedSupperOrder.Contains("2"))
                {
                    assignedSupperOrder.Remove("2");
                    assignedSupperOrder.Reverse();
                    assignedSupperOrder.Add("2");
                }
                else
                {
                    assignedSupperOrder.Reverse();
                }

                var supperLockingOrder = assignedSupperOrder;
                assignedSupperOrder = new List<string>();

                SuperLockingCellCalculation(superLockingCell, superLockQty, superMax, aTov, supperLockingOrder,
                    assignedSupperOrder, assignedSupperFractionCell, assignedSupperFractionCellNo);
                superCell = superCell.Except(superLockingCell).ToList();

                assignedRegularOrder.Reverse();

                bool isfullLocking = false;
                if (superQt == superLockQty)
                {
                    lockingQty = lockingQty - 2;
                    isfullLocking = true;
                }

                RegularCellCalculationBasedOnRegular(lockingCell, lockingQty, aTov, assignedRegularOrder,
                    assignedRegularFractionCell, assignedRegularFractionCellOrder, isfullLocking);

                regularCell = regularCell.Except(lockingCell).ToList();
            }


            return new Tuple<List<string>, List<string>, List<string>, List<string> >(superCell, lockingCell, superLockingCell, regularCell );


        }

        public static void ReverseCellCalculation(ref List<string> remainingCells, List<string> superCell, 
            List<string> assignedSupperFractionCell, List<string> assignedSupperOrder , List<string> aTov)
        {
            #region remainingCells

            remainingCells = Max2FullCellLocation().Except(superCell).ToList();

            List<string> exceptList = new List<string>();
            List<string> newAssignedSupperOrder = new List<string>();

            if (superCell.Count % 22 != 0)
            {
                int r = superCell.Count / 22;

                //assignedSupperFractionCell = superCell.Take(r).ToList();
            }

            if (assignedSupperFractionCell.Count > 0)
            {
                int last = Convert.ToInt32(assignedSupperOrder[assignedSupperOrder.Count - 1]) - 1;
                foreach (var item in assignedSupperFractionCell)
                {
                    exceptList.Add(item + last.ToString());
                }
                remainingCells = remainingCells.Except(exceptList).ToList();
                newAssignedSupperOrder.AddRange(assignedSupperOrder);
                newAssignedSupperOrder.RemoveAt(Convert.ToInt32(newAssignedSupperOrder.Count - 1));
            }
            else
            {
                newAssignedSupperOrder.AddRange(assignedSupperOrder);
            }

            exceptList.Clear();

            foreach (var singleSupperOrder in newAssignedSupperOrder)
            {
                string s = (Convert.ToInt32(singleSupperOrder) - 1).ToString();
                foreach (var item in aTov)
                {
                    exceptList.Add(item + s);
                }
            }
            remainingCells = remainingCells.Except(exceptList).ToList();
            #endregion


        }

        public static void RegularCellCalculationBasedOnSuper(List<string> regularCell, int regularQty, int superQt, int superMax, List<string> aTov, List<string> regularOrder, List<string> assignedSupperOrder, List<string> assignedSupperFractionCell, List<string> assignedRegularOrder, List<string> assignedRegularFractionCell, List<string> assignedRegularFractionCellOrder)
        {
            int stdCellOrderIndex = 0;
            while (regularCell.Count != regularQty)
            {
                string curr = regularOrder[stdCellOrderIndex];
                int currNo = Convert.ToInt32(curr);
                int nextNo = Convert.ToInt32(curr) + 1;
                string last = assignedSupperOrder.LastOrDefault();

                if ((last == currNo.ToString() || last == nextNo.ToString()) && assignedSupperFractionCell.Count != 0)
                {
                    List<string> newFractionList = aTov.Except(assignedSupperFractionCell).ToList();
                    if (assignedRegularFractionCell.Count == 0)
                    {
                        assignedRegularFractionCell.AddRange(newFractionList);
                    }
                    CellAssignment(newFractionList, regularCell, regularQty, regularOrder, stdCellOrderIndex);
                    assignedRegularOrder.Add(regularOrder[stdCellOrderIndex]);
                    assignedRegularFractionCellOrder.Add(regularOrder[stdCellOrderIndex]);
                }
                else if (!assignedSupperOrder.Contains(currNo.ToString()) && !assignedSupperOrder.Contains(nextNo.ToString()))
                {
                    CellAssignment(aTov, regularCell, regularQty, regularOrder, stdCellOrderIndex);
                    assignedRegularOrder.Add(regularOrder[stdCellOrderIndex]);
                }

                stdCellOrderIndex++;

            }

            if (superQt != superMax)
            {
                regularCell.Add("6X");
                regularCell.Add("7Y");
            }
        }


        public static void RegularCellCalculationBasedOnRegular(List<string> regularCell, int regularQty, List<string> aTov, List<string> assignedRegularOrder, List<string> assignedRegularFractionCell, List<string> assignedRegularFractionCellOrder, bool isfullLocking)
        {
            int stdCellOrderIndex = 0; int counter = 0;
            while (regularCell.Count != regularQty)
            {

                if (regularCell.Count == 0 && regularQty - counter < 22) // initial 0-200
                {
                    List<string> newList = aTov.Take(regularQty).ToList();
                    CellAssignment(newList, regularCell, regularQty, assignedRegularOrder, stdCellOrderIndex);
                    counter += newList.Count;
                }
                else if (stdCellOrderIndex < assignedRegularOrder.Count && assignedRegularFractionCellOrder.Contains(assignedRegularOrder[stdCellOrderIndex]))
                {
                    List<string> newFractionList = assignedRegularFractionCell;
                    if (newFractionList.Count == 0)
                    {
                        newFractionList = aTov.Take(regularQty - counter).ToList();
                    }
                    else if (regularQty - counter < newFractionList.Count)
                    {
                        newFractionList = newFractionList.Take(regularQty - counter).ToList();
                    }

                    CellAssignment(newFractionList, regularCell, regularQty, assignedRegularOrder, stdCellOrderIndex);
                    counter += newFractionList.Count;
                }
                else if (regularQty - counter > 22)
                {
                    CellAssignment(aTov, regularCell, regularQty, assignedRegularOrder, stdCellOrderIndex);
                    counter += 22;
                }
                else
                {
                    List<string> newList = aTov.Take(regularQty - counter).ToList();
                    CellAssignment(newList, regularCell, regularQty, assignedRegularOrder, stdCellOrderIndex);
                    counter += newList.Count;
                }
                stdCellOrderIndex++;
            }

            if (isfullLocking)
            {
                regularCell.Add("6X");
                regularCell.Add("7Y");
            }

        }


        public static void SuperCellCalculation(List<string> superCell, int superQt, int superMax, List<string> aTov, 
            List<string> supperOrder, List<string> assignedSupperOrder, List<string> assignedSupperFractionCell, 
            ref string assignedSupperFractionCellNo)
        {
            int supperOrderIndex = 0;

            while (superCell.Count < superQt)
            {
                if (superCell.Count == superMax - 1)
                {
                    superCell.Add("7Y");
                    break;
                }
                foreach (var item in aTov)
                {
                    if (superCell.Count < superQt && superCell.Count < superMax - 1)
                    {
                        superCell.Add(item + supperOrder[supperOrderIndex]); // 22
                        assignedSupperFractionCell.Add(item);
                    }
                    else
                    {
                        break;
                    }
                }
                if (assignedSupperFractionCell.Count == 22)
                {
                    assignedSupperFractionCell.Clear();
                }
                else
                {
                    assignedSupperFractionCellNo = supperOrder[supperOrderIndex];
                }
                assignedSupperOrder.Add(supperOrder[supperOrderIndex]);

                supperOrderIndex++;
            }
        }

        public static void SuperLockingCellCalculation(List<string> superCell, int superQt, int superMax, List<string> aTov, List<string> supperOrder, List<string> assignedSupperOrder, List<string> assignedSupperFractionCell, string assignedSupperFractionCellNo)
        {
            int supperOrderIndex = 0; int counter = 0;

            while (superCell.Count < superQt)
            {
                if (superCell.Count == superMax - 1)
                {
                    superCell.Add("7Y");
                    break;
                }

                if (assignedSupperFractionCellNo!= "" && supperOrder[supperOrderIndex].Contains(assignedSupperFractionCellNo))
                {
                    CellAssignmentForSuperAndSuperLocking(assignedSupperFractionCell, superCell, superQt, superMax, supperOrder, supperOrderIndex, assignedSupperFractionCell);
                    counter += assignedSupperFractionCell.Count;
                    assignedSupperFractionCell.Clear();
                }                
                else
                {
                    CellAssignmentForSuperAndSuperLocking(aTov, superCell, superQt, superMax, supperOrder, supperOrderIndex, assignedSupperFractionCell);
                    counter += 22;
                }

                if (assignedSupperFractionCell.Count == 22)
                {
                    assignedSupperFractionCell.Clear();
                }
                assignedSupperOrder.Add(supperOrder[supperOrderIndex]);

                supperOrderIndex++;
            }
        }

        public static void CellAssignmentForSuperAndSuperLocking(List<string> aTov, List<string> superCell, int superQt, int superMax, List<string> supperOrder, int supperOrderIndex, List<string> assignedSupperFractionCell)
        {
            foreach (var item in aTov)
            {
                if (superCell.Count < superQt && superCell.Count < superMax - 1)
                {
                    superCell.Add(item + supperOrder[supperOrderIndex]); // 22
                    //assignedSupperFractionCell.Add(item);
                }
                else
                {
                    break;
                }
            }

        }

        public static void CellAssignment(List<string> aTov, List<string> regularCell, int regularQty, List<string> regularOrder, int stdCellOrderIndex)
        {
            foreach (var item in aTov)
            {
                if (regularCell.Count < regularQty)
                {
                    regularCell.Add(item + regularOrder[stdCellOrderIndex]);
                }
                else
                {
                    break;
                }
            }
        }


        #region Full cell Loc

        public static List<string> Max2FullCellLocation()
        {
            var aTov = new List<string>
            {
                "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U",  "V"
            };

            List<string> allList = new List<string>();

            for (int i = 1; i <= 9; i++)
            {
                foreach (var item in aTov)
                {
                    allList.Add(item + i.ToString());
                }
            }

            allList.Add("6X");
            allList.Add("7Y");

            return allList;

        }

        #endregion



        static void  doIntegerBasedRounding(int[] a, int n)
        {
            //{-18, 1, 2, 3, 4, 5} 4

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > 0 && a[i] < n)
                {
                    int zer0Diff = a[i] - 0;
                    int nDiff = n - a[i];

                    if (zer0Diff == nDiff)
                    {
                        a[i] = n;
                    }
                    else if(zer0Diff < nDiff)
                    {
                        a[i] = 0; //
                    }
                    else if (nDiff < zer0Diff)
                    {
                        a[i] = n;
                    }
                }
                else if (a[i] > 0 && a[i] > n)
                {
                    int d = a[i] / n;

                    int zer0Diff = a[i] - d * n;
                    int nDiff = (d + 1) * n - a[i];

                    if (zer0Diff == nDiff)
                    {
                        a[i] = (d + 1) * n;
                    }
                    else if (zer0Diff < nDiff)
                    {
                        a[i] = d*n; //
                    }
                    else if (nDiff < zer0Diff)
                    {
                        a[i] = (d+1)*n;
                    }

                }
            }

            Console.WriteLine(".....");
        }

        #endregion

        static int isOnionArray(int[] a)
        {
            return 0;
        }

        public static int isOneBalanced(int[] a) 
        {
            int bOne = 0; int eOne = 0;
            int nonOne = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if ((a[i] == 1) && (nonOne == 0) && (eOne == 0))
                    bOne++;
                else if ((a[i] != 1) && (eOne == 0))
                    nonOne++;
                else if ((a[i] == 1) && (nonOne > 0))
                    eOne++;
                else if ((a[i] != 1) && (eOne > 0))
                    return 0;
            }

            if (bOne + eOne == nonOne) return 1;
            else return 0;
        }

        public static int[] computeHMS1(int seconds)
        {

            int h = 0;
            int m = 0;
            int s = 0;

            int[] a = new int[3];

            if (seconds >= 3600)
            {
                h = seconds / 3600;
                seconds = seconds % 3600;
            }

            if (seconds >= 60)
            {
                m = seconds / 60;
                seconds = seconds % 60;
            }

            s = seconds;

            a[0] = h;
            a[1] = m;
            a[2] = s;
            return a;

        }

        public static int[] computeHMS(int seconds) 
        {

            int[] a = new int[3];
            if (seconds>0)
            {
                a[0] = seconds/ 3600;
                a[1] = (seconds % 3600) / 60;
                a[2] = (seconds % 3600) % 60;
            }
            return a;
        }


        public static int isMercurial(int[] a)
        {
            int initOnePos = -1;
            int endOnePos = -1;
            int mid3Pos = -1;
            for (int i = 0; i < a.Length; i++)
             {
                if ((a[i] == 1) && (mid3Pos == -1) && (endOnePos == -1))
                    initOnePos = i;
                else if ((a[i] == 3) && (initOnePos > -1) && (endOnePos == -1))
                    mid3Pos = i;
                else if ((a[i] == 1) && (initOnePos > -1) && (mid3Pos > -1))
                    endOnePos = i;
            }
            if (initOnePos < mid3Pos && endOnePos > mid3Pos) return 0;
            else    return 1;
        }

        public static int isMartian(int[] a) 
        {
            int one = 0;
            int two = 0;
            bool aa = false;

            for (int i = 0; i < a.Length -1; i++)
            {
                if (a[i] == 1) one++;
                else if (a[i] == 2) two++;

                if (a[i] == a[i + 1]) aa = true;
            }
            if (a[a.Length - 1] == 1) 
                one++;
            if (a[a.Length - 1] == 2)
                two++;


            if ((one > two) && (aa == false)) return 1;
            else return 0;
        
        }
        public static int isMartian1(int[] a)
        {

            int oneC = 0;
            int twoC = 0;

            if (a[0] == 1)
                oneC += 1;
            else if (a[0] == 2)
                twoC += 1;

            for (int i = 1; i < a.Length; i++)
            {

                if (a[i - 1] == a[i])
                {
                    return 0;
                }

                if (a[i] == 1)
                    oneC += 1;
                else if (a[i] == 2)
                    twoC += 1;
            }

            if (oneC > twoC)
                return 1;
            else
                return 0;

        }

        public static int isPairedN(int[] a, int n)
        {
            if (a.Length - 1 + a.Length - 2 < n)
                return 0;

            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (i + j == n && a[i] + a[j] == n)
                        return 1;

                }
            }

            return 0;

        }

        public static int isNPrimeable1(int[] a, int n)
        {
            if (a.Length == 0)
            {
                return 1;
            }

            for (int i = 0; i < a.Length; i++)
            {
                int p = a[i] + n;
                if (p == 1) return 0;

                for (int j = 2; j <= p/2; j++)
                {
                    if (p % j == 0)
                        return 0;
                }

            }
            return 1;

        }

        public static int isNPrimeable(int[] a, int n)
        {

            if (a.Length == 0)
            {
                return 1;
            }

            for (int i = 0; i < a.Length; i++)
            {
                int p = a[i] + n;
                if (!isPrime(p)) return 0;
            }
            return 1;

        }

        public static int is121Array3(int[] a) 
        {
            int initOne = 0;
            int endOne = 0;
            bool two = false;
            if (a[0] != 1) return 0; else initOne = 1;

            for (int i = 1; i < a.Length; i++)
            {
                if ((endOne == 0) && (two == false) && (a[i] == 1))
                    initOne++;
                else if ((a[i] == 2) && (initOne > 0) && (endOne == 0))
                    two = true;
                else if ((a[i] == 1) && (two == true) && (initOne > 0))
                    endOne++;
                else
                    return 0;
            }

            if ((initOne == endOne)&& (two == true)) 
                return 1; 
            else return 0;
        }

        public static int is121Array1(int[] a)
        {

            if (a[0] != 1) return 0;
            if (a[a.Length - 1] != 1) return 0;
            int oneS = 1;
            int oneE = 0;
            int twoC = 0;

            bool foneFound = true;
            bool loneFound = false;
            bool twoFound = false;

            for (int i = 1; i < a.Length; i++)
            {
                if (foneFound && (a[i - 1] == a[i]) && (a[i] == 1)) { oneS += 1; }

                else if ((a[i - 1] == 1) && (a[i] == 2)) { twoC = 1; twoFound = true; foneFound = false; }
                else if (twoFound && (a[i - 1] == a[i]) && (a[i] == 2)) twoC += 1;

                else if ((a[i - 1] == 2) && (a[i] == 1)) { oneE = 1; loneFound = true; twoFound = false; }
                else if (loneFound && (a[i - 1] == a[i]) && (a[i] == 1)) oneE += 1;
                else return 0;

            }

            if (oneS == oneE) return 1;
            else return 0;

        }

        public static int[] pairwiseSum(int[] a)
        {
            if (a.Length % 2 != 0) return null;
            if (a.Length == 0) return null;

            int[] r = new int[a.Length / 2];
            int k = 0;

            //for (int i = 0; i < a.Length; i = i + 2)
            //{
            //    r[k] = a[i] + a[i + 1];
            //    k += 1;
            //}
            for (int i = 1; i < a.Length; i = i + 2)
            {
                r[k] = a[i-1] + a[i];
                k += 1;
            }
            return r;

        }

        public static int isVesuvian(int n)
        {
            int c = 0;
            if (isSquare(n - 1) == 1) c = 1;
            for (int i = 4; i < n; i++)
            {
                if ((isSquare(i) == 1) && (isSquare(n - i) == 1))
                    c++;
                if (c == 2) return 1;
            }
            if (c == 2) return 1;
            else return 0;
        }

        public static int isSquare(int n)
        {

            if (n < 0) return 0;

            for (int i = 0; i < n / 2; i++)
            {
                if (i * i == n) return 1;
            }

            return 0;

        }

        public static int isComplete(int[] a)
        {

            bool even = false;
            bool pSq = false;
            bool sum8 = false;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] % 2 == 0) even = true;
                if (!pSq) pSq = pSquare(a[i]);

                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[i] + a[j] == 8) { sum8 = true; break; }
                }

            }

            if (even && pSq && sum8) return 1;
            else return 0;
        }


        public static int isComplete2(int[] a)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] <= 0) return 0;

                if (a[i] % 2 == 0)
                    list.Add(a[i]);
            }

            int maxEven = list.Max();
            int even = 2;
            while (even < maxEven)
            {
                bool found = false;
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == even) 
                    {found = true; break;}
                }
                if (!found) return 0;
                even = even + 2;
            }

            return 1;        
        }

        public static int isSetEqualString(char[] a, char[] b)
        {
            if (a.Length >= b.Length)
                return isSetEqualHelperString(a, b);
            else
                return isSetEqualHelperString(b, a);
        }

        private static int isSetEqualHelperString(char[] a, char[] b)
        {

            // { 'a' , 'b' }   { 'a' , 'b' , 'c'}

            for (int i = 0; i < a.Length; i++)
            {
                bool found = false;
                for (int j = 0; j < b.Length; j++)
                {
                    if (a[i] == b[j])
                    { found = true; break; }
                }
                if (!found) return 0;
            }
            return 1;
        }

        public static int isSetEqual(int[] a, int[] b)
        {
            if (a.Length >= b.Length)
                return isSetEqualHelper(a, b);
            else
                return isSetEqualHelper(b, a);
        }

       public static int isSetEqualHelper(int[] a, int[] b)
        {

            for (int i = 0; i < a.Length; i++)
            {
                bool found = false;
                for (int j = 0; j < b.Length; j++)
                {
                    if (a[i] == b[j])
                    { found = true; break; }
                }
                if (!found) return 0;
            }
            return 1;
        }


        public static int isTwin(int[] arr)
        {
            Array.Sort(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                if (  isPrime(arr[i])  )
                {
                    if(isPrime(arr[i] + 2))
                    {
                        bool f = false;
                        for (int j = i + 1; j < arr.Length; j++)
                        {
                            if (arr[i] + 2 == arr[j])
                            { f = true; break; }
                        }
                        if (f == false) return 0;
                    }

                    if (isPrime(arr[i] - 2))
                    {
                        bool f = false;
                        for (int j = 0; j < arr.Length; j++)
                        {
                            if ( i != j && arr[i] - 2 == arr[j] )
                            { f = true; break; }
                        }
                        if (f == false) return 0;
                    }
                }
            }
            return 1;
        }


        public static int countDigit(int n, int digit)
        {
            int c = 0;
            while (n>0)
            {
                int q = n / 10;
                int r = n % 10;
                if (r == digit) c++;
                n = q;
            }
            return c;
        }

        public static bool pSquare(int n)
        {
            if (n < 0) return false;
            for (int i = 0; i < n / 2; i++)
            {
                if (i * i == n) return true;
            }
            return false;
        }

        public static int loopSum1(int[] a, int n)
        {

            int c = 0;
            int s = 0;

            while (c < n)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (c == n) return s;
                    s = s + a[i];
                    c += 1;
                }

            }
            return s;

        }
        public static int loopSum(int[] a, int n)
        {
           
            int s = 0;
            if(a.Length >= n) 
            {
                for (int i = 0; i < n; i++)
                {
                    s = s + a[i];
                }
            }
            else if(a.Length < n)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    s = s + a[i];
                }
                int r = n % a.Length;
                int q = n / a.Length;
                s = s * q;
                for (int i = 0; i < r; i++)
                {
                    s = s + a[i];
                }
            }

            return s;
            

        }


        public static int sameNumberOfFactors(int n1, int n2)
        {
            if (n1 == n2) return 1;
            if (n1 < 0 || n2 < 0) return -1;

            if (factor(n1) == factor(n2)) return 1;
            else return 0;

        }
        public static int factor(int n)
        {
            int c = 0;
            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0) c += 1;
            }
            return c;
        }

        public static double eval(double x, int[] a)
        {
            double val = 0;
            int l = a.Length;
            val = a[0] + a[1] * x;
            int i = 2;
            while (i < l)
            {
                //val += a[i] * pow(i, x);  // a[2] * x * x;
                val += a[i] * Math.Pow(i,x);  // a[2] * x * x;

                i++;
            }
            return val;
        }

        public static double pow(int i, double x)
        {
            double r = 1;
            for (int j = 0; j < i; j++) { r = r * x; }
            return r;
        }

        public static int isAllPossibilities(int[] a)
        {

            Array.Sort(a);

            for (int i = 0; i < a.Length; i++)
            {
                if (i != a[i])  return 0;
            }
            return 1;

        }
        public static int isLayered1(int[] a)
        {
            int count = 1;
            if (a.Length < 2) return 0;

            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] >= a[i - 1])
                {
                    if ((count == 1) && (a[i] > a[i - 1])) return 0;
                    if (a[i] > a[i - 1]) { count = 1; }
                    else count++;
                }
                else return 0;
            }

            int min = Int32.MinValue;
            int max = Int32.MaxValue;
            return 1;

        }
        public static int isLayered(int[] a) 
        {
            if (a.Length < 2) return 0;
            Dictionary<int, int> d = new Dictionary<int, int>();
            for (int i = 0; i < a.Length; i++)
            {
                if (i != 0 && a[i - 1] < a[i]) 
                    return 0;

                if (!d.Keys.Contains(a[i]))
                    d[a[i]] = 1;
                else
                    d[a[i]] += 1;
            }

            foreach (int k in d.Keys)
            {
                if (d[k] < 2) return 0;
            }

            return 1;
        
        }

        public static int isHollow(int[] a)
        {
            int pCount = 0;
            int zCount = 0;
            int fCount = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if ((zCount == 0) && (a[i] != 0)) pCount++;
                else if ( (fCount == 0) && (a[i] == 0)) zCount++;
                else if ( (zCount > 0) && (a[i] != 0)) fCount++;
                else return 0;
            }

            if ((pCount == fCount) && (zCount > 2)) return 1;
            else return 0;
        }

        public static int isMadhavArray1(int[] a) 
        {
            int l = a.Length;
            int c = 2;
            int lc = 0;

            while (lc+1 < l)
            {
                int sum = 0;
                int k;
                for (k = lc + 1; k <= lc + c; k++)
                {
                    sum = sum + a[k];
                }
                if (sum != a[0]) return 0;
                lc = k-1; c++;               
            }

            if (lc + 1 == l) return 1;
            else return 0;
        
        }

        public static bool haskSmallFactors(int k, int n) 
        {
            for (int i = 1; i < k; i++)
            {
                if(n%i==0 && n/i<k)
                    return true;    
            }
            return false;
        }

        public static int isMadhavArray(int[] a) 
        {
            int c = 2;
            int l = 0;
            int s = 0;
            for (int i = 1; i < a.Length; i++)
            {
                s = s + a[i];
                l++;
                if ((l == c) && (s == a[0])) { c++; s = 0;l = 0; }
                else if ((l == c) && (s != a[0])) return 0;
            }
            if (l > 0 && l != c) return 0;
            return 1;
        }

        public static int isInertial(int[] a) 
        {
            Array.Sort(a); int m = a.Max();

            if (a[a.Length - 1] % 2 != 0) return 0;
            List<int> evenList = new List<int>();
            List<int> oddList = new List<int>();

            for (int i = 0; i < a.Length - 1; i++)
            {
                if (a[i] % 2 == 0 && m != a[i])
                    evenList.Add(a[i]);
                else
                    oddList.Add(a[i]);
            }
            if (oddList.Count == 0) return 0;
            for (int i = 0; i < evenList.Count; i++)
            {
                if (evenList[i] > oddList[0])
                    return 0;
            }
            return 1;
        }


        public static int isBean(int[] a) 
        {
            for (int i = 0; i < a.Length; i++)
            {
                bool found = false;
                for (int j = 0; j < a.Length; j++)
                {
                    if (i == j) continue;
                    if ( (a[i] == a[j] + 1) || (a[i] == a[j] - 1) ) 
                    { found = true; break; }    
                }
                if(!found) return 0;
            }
            return 1;
        }

        public static int isMeera(int[] a)
        {
            bool prime = false;
            bool zero = false;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == 0) zero = true;
                if (prime == false &&  isPrime(a[i]) ) prime = true;
            }

            if (prime == true && zero == true) return 1;
            else if (prime == false && zero == false) return 1;
            else return 0;

        }

        public static int[] fill(int[] arr, int k , int n) 
        {
            if ((k < 1) || (n < 0)) return null;

            List<int> list = new List<int>();

            while (list.Count < n)
            {
                for (int i = 0; i < k; i++)
                {
                    if (list.Count < n)
                        list.Add(arr[i]);
                    else
                        break;
                }
            }
            return list.ToArray();
        }

        public static int isWave(int[] a) 
        {
            for (int i = 1; i < a.Length; i++)
            {
                if ((a[i - 1] % 2 == 0) && (a[i] % 2 == 0))
                    return 0;
                else if ((a[i - 1] % 2 != 0) && (a[i] % 2 != 0))
                    return 0;
            }

            return 1;

        }

        public static int minDistance(int n) 
        {
            List<int> l = new List<int>();

            for (int i = 1; i < n; i++)
            {
                if(n % i == 0)
                    l.Add(i);
            }

            int m = int.MaxValue;

            for (int i = 1; i < l.Count; i++)
            {
                if (l[i] - l[i - 1] < m)
                    m = l[i] - l[i - 1];
            }

            return m;
        
        }

        public static int isMeera(int n)
        {
            List<int> l = new List<int>();

            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                    l.Add(i);
            }

            int m = l.Count;

            for (int i = 0; i < l.Count; i++)
            {
                if (m == l[i]) return 1;
            }

            return 0;

        }

        public static int isNormal(int n)
        {

            for (int i = 2; i < n; i++)
            {
                if ((n % i == 0) && (i % 2 != 0))
                    return 0;
            }            

            return 1;

        }

        public static int isBalanced(int[] a)
        {

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] % 2 == 0)
                {
                    if(i % 2 != 0) return 0;
                }
                else if(a[i] % 2 != 0)
                {
                    if (i % 2 == 0) return 0;
                }

            }
            return 1;
        }

        public static int isPrimeProduct(int n)
        {

            int p = 2;
            while (p<n)
            {
                if(isPrime(p) && (n%p == 0) )
                {
                    if (isPrime(n / p))
                        return 1;
                }
                p++;
            }
            return 0;
        }

        public static int isDual(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                int c = 1;
                for (int j = 0; j < a.Length; j++)
                {
                    if (i == j) continue;

                    if (a[i] == a[j]) c++;
                }

                if (c > 2 || c < 2) return 0;

            }
            return 1;
        }

        public static int isDaphne(int[] a)
        {
            int b = 0;
            int e = 0;
            int odd = 0;
            if (a[0] % 2 == 0) b++;
            if (a[a.Length-1] % 2 == 0) e++; 

            for (int i = 1; i < a.Length; i++)
            {
                if ((a[i] % 2 == 0) && (a[i - 1] % 2 == 0) && odd == 0)
                    b++;
                else if (a[i] % 2 != 0) odd++;
            }

            if(odd == 0) return 0;
            for (int i = a.Length-1; i > 0; i--)
            {
                if ((a[i] % 2 == 0) && (a[i - 1] % 2 == 0))
                    e++;
                else break;
            }

            if (b == e && odd>0) return 1; 
            else  return 0;
        }

        public static int factorTwoCount(int n) 
        {
            int c = 0;
            while (n%2 == 0)
            {
                c++;
                n = n / 2;
            }
            return c;
        }

        public static int isCentered(int[] a)
        {
            if (a.Length % 2 == 0) return 0;
            int m = a[a.Length / 2];

            for (int i = 0; i < a.Length; i++)
            {
                if ((i != a.Length / 2) && (m >= a[i]))
                    return 0;
            }
            return 1;
        }




        public static int computeDepth1(int n)
        {
            //int[] a = new int[10]; int k = 0; 
            List<int> a = new List<int>();
            int i = 1;

            while (a.Count < 10)
            {
                int m = n * i;

                while (m!= 0)
                {
                    int r = m % 10 ;
                    int q = m / 10; m = q;

                    //bool found = false;
                    //for (int z = 0; z < k; z++)
                    //{
                    //    if (a[z]==r)
                    //    {
                    //        found = true; break;
                    //    }
                    //}
                    //if (found == false)
                    //{
                    //    a[k] = r; k++;
                    //}

                    if (!a.Contains(r))
                    {
                        a.Add(r);
                    }                   
                }
                i++;
            }
            return i-1;        
        }

        public static int computeDepth(int n)
        {
            List<int> a = new List<int>();
            int i = 1;

            while (a.Count < 10)
            {
                int m = n * i;
                while (m != 0)
                {
                    int r = m % 10;
                    m = m / 10; 
                    if (!a.Contains(r))
                    {
                        a.Add(r); // could be 10 after this line.....but i++-0
                    }
                }
                i++;
            }
            return i - 1;
        }

        public static int isLegalNumber(int[]a, int b) 
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] >= b)
                {
                    return 0;
                }
            }
            return 1;
        }

        public static int convertToBase10(int[]a, int b) 
        {
            if (isLegalNumber(a,b) == 0)
            {
                return 0;
            }

            a = a.Reverse().ToArray();
            int s = a[0];

            for (int i = 1; i < a.Length; i++)
            {
                int d = 1; int c = 1;
                while (c <= i)
                {
                    d = d * b; c++; // b for base
                }
                s = s + a[i] * d;
            }

            return s;
        }


        public static List<int> numberToArray(int n) {
            List<int> l = new List<int>();
            while (n>0)
            {
                l.Add(n % 10);
                n = n / 10;
            }
            return l;
        }

        public static int isVanilla(int[] a)
        {
            List<int> l = numberToArray(a[0]);
            var h = new HashSet<int>(l);

            for (int i = 1; i < a.Length; i++)
            {
                l = numberToArray(a[i]);
                var h1 = new HashSet<int>(l);

                if (h1.Count > 1) return 1;
                if (h1.FirstOrDefault() != h.FirstOrDefault()) return 0;                
               
            }
            return 1;
        }

        public static int countRepresentations1(int numRupees)
        {
            int count = 0;

            for (int rupee20 = 0; rupee20 <= (numRupees) / 20; rupee20++)
            {
                int rupe10Limit = (numRupees - (rupee20 * 20)) / 10;

                for (int rupee10 = 0; rupee10 <= rupe10Limit; rupee10++)
                {
                    int rupe5Limit = (numRupees - (rupee10 * 10 + rupee20 * 20)) / 5;

                    for (int rupee5 = 0; rupee5 <= rupe5Limit; rupee5++)
                    {
                        int rupee2Limit = (numRupees - (rupee5 * 5 + rupee10 * 10 + rupee20 * 20)) / 2;

                        for (int rupee2 = 0; rupee2 <=  rupee2Limit; rupee2++)
                        {
                            int rupee1Limit = (numRupees - (rupee2 * 2 + rupee5 * 5 + rupee10 * 10 + rupee20 * 20));

                            for (int rupee1 = 0; rupee1 <= rupee1Limit; rupee1++)
                            {

                                if (rupee1 + rupee2 * 2 + rupee5 * 5 + rupee10 * 10 + rupee20 * 20 == numRupees)
                                {
                                    count++;

                                }

                            }

                        }
                    }
                }

            }

            return count;
        }

        public static int countRepresentations(int numRupees)
        {
            int count = 0;

            for (int rupee20 = 0; rupee20 <= (numRupees) / 20; rupee20++)
            {
                for (int rupee10 = 0; rupee10 <= (numRupees - (rupee20 * 20)) / 10; rupee10++)
                {
                    for (int rupee5 = 0; rupee5 <= (numRupees - (rupee10 * 10 + rupee20 * 20)) / 5; rupee5++)
                    {
                        for (int rupee2 = 0; rupee2 <= (numRupees - (rupee5 * 5 + rupee10 * 10 + rupee20 * 20)) / 2; rupee2++)
                        {
                            for (int rupee1 = 0; rupee1 <= (numRupees - (rupee2 * 2 + rupee5 * 5 + rupee10 * 10 + rupee20 * 20)); rupee1++)
                            {
                                if (rupee1 + rupee2 * 2 + rupee5 * 5 + rupee10 * 10 + rupee20 * 20 == numRupees)
                                {
                                    count++;
                                }

                            }

                        }
                    }
                }

            }

            return count;
        }

        public static int[] filterArray1(int[] a, int n) 
        { 
            List<int> r = new List<int>();
            List<int> l = new List<int>();

            int p = 1;  l.Add(p);
            while (p<= n)
            {
                p = p * 2;
                if (p > n) break;
                l.Add(p);
            }

            int s = l[l.Count-1];
            for (int i = l.Count - 1; i >= 0; i-- )
            {
                if(s==n) { r.Add(i); break; }
                else if(s<n)
                {
                    n = n - s;
                    r.Add(i);
                }
                if(i>0) s = l[i-1];
            }
            r.Sort();

            for (int i = 0; i < r.Count; i++)
            {
                if(r[i] < a.Length)
                     r[i] = a[ r[i] ];
            }

            return r.ToArray();
        
        }

        public static int[] filterArray(int[] a, int n)
        {
            List<int> index = new List<int>();
            List<int> l = new List<int>();

            int p = 1; l.Add(p);
            while (p <= n)
            {
                p = p * 2;
                if (p > n) break;
                l.Add(p);
            }

            //int s = l[l.Count - 1];

            //a = a.OrderBy(x => x).ToArray();
            Array.Sort(a);
            l.Sort();

            Array.Reverse(a);
            //a = a.Reverse().ToArray();
            
            //Array.

            l.Reverse();


            double m = Math.Pow(2,3);

            for (int j = l.Count - 1; j >= 0; j--)
            {
                if (n >= l[j])
                {
                    index.Add(j);
                    n = n - l[j];
                }
                if (n == 0) break;

            }
            index.Sort();

            for (int i = 0; i < index.Count; i++)
            {
                if (index[i] < a.Length)
                    index[i] = a[index[i]];
            }

            return index.ToArray();

        }

        #region ATP ALgorithm


        public static Dictionary<string, int[]> Drawers(int deviceTypeId)
        {
            Dictionary<string, int[]> drawer = new Dictionary<string, int[]>();
            if (deviceTypeId == 9)//64
            {
                drawer = new Dictionary<string, int[]>()
                {
                    ["SmartDrawer"] = new int[] { 1, 2, 3, 4 },
                    ["HighCapDrawer"] = new int[] { },
                    ["RegularDrawer"] = new int[] { },
                };
            }
            else if (deviceTypeId == 10)//128
            {
                drawer = new Dictionary<string, int[]>()
                {
                    ["SmartDrawer"] = new int[] { 5, 8 },
                    ["HighCapDrawer"] = new int[] { 2, 3, 6, 7 },
                    ["RegularDrawer"] = new int[] { 1, 4 },
                };
            }
            else if (deviceTypeId == 11)//192
            {
                drawer = new Dictionary<string, int[]>()
                {
                    ["SmartDrawer"] = new int[] { 9, 10, 11, 12 },
                    ["HighCapDrawer"] = new int[] { 2, 3, 6, 7 },
                    ["RegularDrawer"] = new int[] { 1, 4, 5, 8 },
                };
            }
            else if (deviceTypeId == 12)//256
            {
                drawer = new Dictionary<string, int[]>()
                {
                    ["SmartDrawer"] = new int[] { 9, 12, 13, 16 },
                    ["HighCapDrawer"] = new int[] { 2, 3, 6, 7, 10, 14, 11, 15 },
                    ["RegularDrawer"] = new int[] { 1, 4, 5, 8 },
                };
            }
            else if (deviceTypeId == 13)//320
            {
                drawer = new Dictionary<string, int[]>()
                {
                    ["SmartDrawer"] = new int[] { 9, 12, 13, 16, 17, 18, 19, 20 },
                    ["HighCapDrawer"] = new int[] { 2, 3, 6, 7, 10, 14, 11, 15 },
                    ["RegularDrawer"] = new int[] { 1, 4, 5, 8 },
                };
            }
            else if (deviceTypeId == 14)//400
            {
                drawer = new Dictionary<string, int[]>()
                {
                    ["SmartDrawer"] = new int[] { 9, 12, 13, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 },
                    ["HighCapDrawer"] = new int[] { 2, 3, 6, 7, 10, 14, 11, 15 },
                    ["RegularDrawer"] = new int[] { 1, 4, 5, 8 },
                };
            }
            else if (deviceTypeId == 15)//480
            {
                drawer = new Dictionary<string, int[]>()
                {
                    ["SmartDrawer"] = new int[] { 9, 12, 13, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 },
                    ["HighCapDrawer"] = new int[] { 2, 3, 6, 7, 10, 14, 11, 15 },
                    ["RegularDrawer"] = new int[] { 1, 4, 5, 8 },
                };
            }

            return drawer;

        }
        public static Dictionary<string, List<int>> DrawerSelection(int deviceTypeId, int? customerSmartDrawer, int? customerHighCapDrawer)
        {

            deviceTypeId = 12;
            customerSmartDrawer = 3;
            customerHighCapDrawer = 3;

            var availableDrawers = Drawers(deviceTypeId);

            var smartDrawerItems = availableDrawers.ElementAt(0);
            var highCapDrawerItems = availableDrawers.ElementAt(1);
            var regularDrawerItems = availableDrawers.ElementAt(2);

            List<int> selectedSmartDrawers = new List<int>();
            List<int> selectedHighCapDrawers = new List<int>();
            List<int> selectedRegularDrawers = new List<int>();

            int startPosition = 0;

            #region device + Customer input wise High cap

            if (deviceTypeId == 9)
            {
                startPosition = 1;
            }
            else if (deviceTypeId == 10)
            {
                startPosition = 5;
                if (customerHighCapDrawer == 1)
                {
                    selectedHighCapDrawers.AddRange(new List<int>() { 2, 6 });
                }
                else if (customerHighCapDrawer == 2)
                {
                    selectedHighCapDrawers.AddRange(new List<int>() { 2, 3, 6, 7 });
                }

            }
            else if (deviceTypeId == 11)
            {
                startPosition = 9;
                if (customerHighCapDrawer == 1)
                {
                    selectedHighCapDrawers.AddRange(new List<int>() { 2, 6 });
                }
                else if (customerHighCapDrawer == 2)
                {
                    selectedHighCapDrawers.AddRange(new List<int>() { 2, 3, 6, 7 });
                }
            }
            else if (deviceTypeId == 12)
            {
                startPosition = 9;
                CommonHcAllocationAboveAtp192(customerHighCapDrawer, selectedHighCapDrawers);

            }
            else if (deviceTypeId == 13)
            {
                startPosition = 9;
                CommonHcAllocationAboveAtp192(customerHighCapDrawer, selectedHighCapDrawers);

            }
            else if (deviceTypeId == 14)
            {
                startPosition = 9;
                CommonHcAllocationAboveAtp192(customerHighCapDrawer, selectedHighCapDrawers);

            }
            else if (deviceTypeId == 15)
            {
                startPosition = 9;
                CommonHcAllocationAboveAtp192(customerHighCapDrawer, selectedHighCapDrawers);
            }
            #endregion
            var remainingHighCapDrawer = highCapDrawerItems.Value.Except(selectedHighCapDrawers).ToList();
            foreach (var item in remainingHighCapDrawer)
            {
                if (startPosition > item)
                {
                    selectedRegularDrawers.Add(item);
                }
                else if (startPosition < item)
                {
                    selectedSmartDrawers.Add(item);
                }
            }

            selectedSmartDrawers.AddRange(smartDrawerItems.Value);

            var customerBasedSelectedSd = selectedSmartDrawers.OrderBy(a => a).Take((int)customerSmartDrawer).ToList();

            selectedRegularDrawers.AddRange(regularDrawerItems.Value);
            selectedRegularDrawers.AddRange(selectedSmartDrawers.Except(customerBasedSelectedSd));
            selectedSmartDrawers = customerBasedSelectedSd;


            var s = selectedSmartDrawers.OrderBy(a => a).ToList();
            var hInts = selectedHighCapDrawers.OrderBy(a => a).ToList();
            var rs = selectedRegularDrawers.OrderBy(a => a).ToList();

            return new Dictionary<string, List<int>>()
            {
                ["SmartDrawer"] = selectedSmartDrawers.OrderBy(a => a).ToList(),
                ["HighCapDrawer"] = selectedHighCapDrawers.OrderBy(a => a).ToList(),
                ["RegularDrawer"] = selectedRegularDrawers.OrderBy(a => a).ToList(),
            };
        }
        private static void CommonHcAllocationAboveAtp192(int? customerHighCapDrawer, List<int> selectedHighCapDrawers)
        {
            if (customerHighCapDrawer == 1)
            {
                selectedHighCapDrawers.AddRange(new List<int>() { 2, 6 });
            }
            else if (customerHighCapDrawer == 2)
            {
                selectedHighCapDrawers.AddRange(new List<int>() { 2, 3, 6, 7 });
            }
            else if (customerHighCapDrawer == 3)
            {
                selectedHighCapDrawers.AddRange(new List<int>() { 2, 3, 6, 7, 10, 14 });
            }
            else if (customerHighCapDrawer == 4)
            {
                selectedHighCapDrawers.AddRange(new List<int>() { 2, 3, 6, 7, 10, 11, 14, 15 });
            }
        }

        #endregion

        public static int isConsectiveFactored1(int n)
        {
            List<int> f = new List<int>();
            while (n > 0)
            {

                int bn = n;
                for (int i = 2; i < n / 2; i++)
                {
                    if (n % i == 0) { n = n / i; f.Add(i); break; }
                }

                if (bn == n) { f.Add(n); break; }
            }

            f.Sort();
            for (int i = 1; i < f.Count; i++)
            {
                if (f[i - 1] + 1 == f[i]) return 1;
            }
            return 0;

        }

        public static int isConsectiveFactored(int n)
        {
            List<int> f = new List<int>();

            for (int i = 2; i <= n; i++)
            {
                if (n % i == 0)
                    f.Add(i);
            }

            f.Sort();
            for (int i = 1; i < f.Count; i++)
            {
                if (f[i - 1] + 1 == f[i]) return 1;
            }
            return 0;

        }


        public static List<string> ReverseSuperCellCalculation( List<string> superCell)
        {
            List<string> oppositeSuperCell = new List<string>();            

            //        oposite Super Cell order = {"3", "6", "8", "1"};
            var aTov = new List<string>
            {
                "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V"
            };

            foreach (var item in aTov) // 22
            {
                oppositeSuperCell.Add(item + "3");
                oppositeSuperCell.Add(item + "6");
                oppositeSuperCell.Add(item + "8");
                oppositeSuperCell.Add(item + "1");
            }

            return oppositeSuperCell;
        }

        public static void updateMileagecounter1(int[] a, int miles) {

            int total = a[0] + miles;
            int carry = 0;
            if (total > 9)
            {
                a[0] = total % 10;
                carry = total / 10;
            }
            else
            {
                a[0] = total;
            }

            for (int i = 1; i < a.Length; i++)
            {
                if (carry > 0)
                {
                    total = a[i] + carry;
                    a[i] = total % 10;
                    carry = total / 10;
                }
                else
                {
                    a[i] = total;
                }               
            }

        }
        public static void updateMileagecounter(int[] a, int miles)
        {

            int carry = 0;

            carry = (a[0] + miles) / 10;
            a[0] = (a[0] + miles) % 10;

            for (int i = 1; i < a.Length; i++)
            {
                int temp = (a[i] + carry);
                if (carry > 0)
                {
                    carry = temp / 10;
                    a[i] = temp % 10;
                }
                else
                    a[i] = temp;
                
            }

        }


        public static void updateMileagecounter3(int[] a, int miles)
        {
            string[] resArr = new string[a.Length];
            string digit = "";
            int cout = 0;
            for (int i = 0; i < a.Length; i++)
            {
                digit = digit + a[i].ToString();
                cout++;
            }
            string revNum = reverseNumber(Convert.ToInt32(digit), cout, miles);

            for (int j = resArr.Length - 1; j >= 0; j--)
            {
                resArr[j] = revNum[j].ToString();
            }

        }
        public static string reverseNumber(int n, int numOfdigit, int miles)
        {

            int sum = 0;
            while (n != 0)
            {
                int r = n % 10;
                sum = sum * 10 + r;
                n = n / 10;

            }
            sum = sum + miles;
            var newString = sum.ToString().PadLeft(numOfdigit, '0');
            return newString;
        }

        public static int isTwinPrime(int n)
        {
            if (! isPrime(n))
            {
                return 0;
            }

            if (isPrime(n) && isPrime(n+2))
            {
                return 1;
            }
            else if (isPrime(n) && isPrime(n - 2))
            {
                return 1;
            }
            else
            {
                return 0;
            }
            

        }
        public static int isZeroBalanced(int[] a)
        {
            if (a.Length == 0) return 0;
            if (a.Sum() != 0) return 0;
            if (a.Length % 2 != 0) return 0;
            Array.Sort(a);

            for (int i = 0; i < a.Length/2 ; i++)
            {
                bool found = false;
                for (int j = a.Length/2; j< a.Length ; j++)
                {
                    if (-a[i] == a[j])
                    {
                        found = true;
                        break;
                    }
                }
                if (found == false) return 0;
            }
            return 1;
                    
        }


        public static Tuple<List<int>, List<int>, List<int>> ATPDeviceConfiguration(int atp) 
        {
            List<int> SD = new List<int>();  
            List<int> HD = new List<int>(); 
            List<int> RD = new List<int>();

            if (atp == 64)
            {
                SD = new List<int>() { 1, 4 };
                HD = new List<int>();
                RD = new List<int>() { 2, 3 };
            }
            else if (atp == 128)
            {
                SD = new List<int>() { 5, 8 };
                HD = new List<int>() { 2, 3 };
                RD = new List<int>() { 1, 4 };
            }
            else if (atp >= 192)
            {
                SD = new List<int>() { 9, 12, 13, 16, 17, 18, 19, 20 };
                HD = new List<int>() { 2, 3, 10, 11 };
                RD = new List<int>() { 1, 4, 5, 8, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };
            }
            Tuple<List<int>, List<int>, List<int>> t = new Tuple<List<int>, List<int>, List<int>>(SD, HD, RD);
            return t;
        }

        public static Tuple<List<int>, List<int>, List<int>> ATPDeviceConfigurationByCustomerInput(int sdInput, int hdInput, int atp)
        {

            List<int> SD = new List<int>();
            List<int> HD = new List<int>();
            List<int> RD = new List<int>();

            List<int> SDNew = new List<int>();
            List<int> HDNew = new List<int>();
            List<int> RDNew = new List<int>();

            Tuple<List<int>, List<int>, List<int>> t = ATPDeviceConfiguration(atp);
            SD = t.Item1;
            HD = t.Item2;
            RD = t.Item3;

            if (sdInput <= SD.Count)
            {
                for (int i = 0; i < sdInput; i++)
                {
                    SDNew.Add(SD[i]);
                }
                RDNew.AddRange(SD.Except(SDNew) );
                SD = SDNew;
            }


            if (hdInput <= HD.Count)
            {
                for (int i = 0; i < hdInput; i++)
                {
                    HDNew.Add(HD[i]);
                }
                RDNew.AddRange(HD.Except(HDNew));
                HD = HDNew;
            }

            if (RDNew.Count>0)
            {
                RDNew.AddRange(RD);
                RD = RDNew;
            }

            t = new Tuple<List<int>, List<int>, List<int>>(SD, HD, RD);
            return t;
        }



        #endregion

        #region OOP Method

        class OOP
        {
            // method overloading example
            public int Add(int a, int b)
            {
                int sum = a + b;
                return sum;
            }

            // method overloading example
            public int Add(int a, int b, int c)
            {
                int sum = a + b + c;
                return sum;
            }

        }
        // method overridding example
        class baseClass
        {
            public virtual void show()
            {
                Console.WriteLine("Base class");
            }
        }

        class derived : baseClass
        {

            //'show()' is 'override' here
            public override void show()
            {
                Console.WriteLine("Derived class");
            }
        }

        // abstract class

        public abstract class GeeksForGeeks
        {
            public abstract void gfg();

        }

        public class Geek1 : GeeksForGeeks
        {
            // abstract method 'gfg()'        // declare here with        // 'override' keyword
            public override void gfg()
            {
                Console.WriteLine("class Geek1");
            }
        }

        // Interface

        interface Vehicle
        {

            // all are the abstract methods.
            void changeGear(int a);
            void speedUp(int a);
            void applyBrakes(int a);
        }

        // class implements interface
        class Bicycle : Vehicle
        {

            int speed;
            int gear;

            // to change gear
            public void changeGear(int newGear)
            {

                gear = newGear;
            }

            // to increase speed
            public void speedUp(int increment)
            {

                speed = speed + increment;
            }

            // to decrease speed
            public void applyBrakes(int decrement)
            {

                speed = speed - decrement;
            }

            public void printStates()
            {
                Console.WriteLine("speed: " + speed +
                                  " gear: " + gear);
            }
        }

        // class implements interface
        class Bike : Vehicle
        {

            int speed;
            int gear;

            // to change gear
            public void changeGear(int newGear)
            {

                gear = newGear;
            }

            // to increase speed
            public void speedUp(int increment)
            {

                speed = speed + increment;
            }

            // to decrease speed
            public void applyBrakes(int decrement)
            {

                speed = speed - decrement;
            }

            public void printStates()
            {
                Console.WriteLine("speed: " + speed +
                                  " gear: " + gear);
            }

        }


        #endregion

        #region Leetcode target 300

        static public bool HalvesAreAlike(string s)
        {
            int fc = 0;
            int lc = 0;
            string[] vow =  {"a", "e", "i", "o", "u", "A", "E", "I", "O", "U"};

            for (int i = 0; i < s.Length; i++)
            {
                if (vow.Contains(s[i].ToString()) )
                {
                    if (i < s.Length/2)
                    {
                        fc++;
                    }
                    else
                    {
                        lc++;
                    }
                }
            }
            return fc == lc ;
        }

        static public int[] TwoSum(int[] nums, int target)
        {

            for (int i = 0; i < nums.Length; i++)
            {
                int a = nums[i];
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (a + nums[j] == target) 
                        return new int[] { i, j };
                }
            }
            return null;
        }

        static public IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
        {
            //Input: nums1 = [1, 2, 3], nums2 = [2, 4, 6]
            //Output: [[1,3],[4,6]]
            List<int> a = new List<int>();
            List<int> b = new List<int>();            

            Dictionary<int, int> d1 = new Dictionary<int, int>();

            for (int i = 0; i < nums1.Length; i++)
            {
                if (!d1.Keys.Contains(nums1[i]))
                {
                    d1[nums1[i]] = 1;
                }
                else
                {
                    d1[nums1[i]] += 1;
                }
            }

            Dictionary<int, int> d2 = new Dictionary<int, int>();

            for (int i = 0; i < nums2.Length; i++)
            {
                if (!d2.Keys.Contains(nums2[i]))
                {
                    d2[nums2[i]] = 1;
                }
                else
                {
                    d2[nums2[i]] += 1;
                }
            }
            foreach (var key in d1.Keys)
            {
                if (!d2.Keys.Contains(key))
                {
                    a.Add(key);
                }
            }

            foreach (var key in d2.Keys)
            {
                if (!d1.Keys.Contains(key))
                {
                    b.Add(key);
                }
            }
            IList<IList<int>> c = new List<IList<int>>();
            c.Add(a);
            c.Add(b);
            return c;

        }

        static public IList<int> Intersection(int[][] nums)
        {
            List<int> a = nums[0].ToList();

            for (int i = 1; i < nums.Length; i++)
            {
                a = a.Intersect(nums[i]).ToList();
            }

            return a.OrderBy(o=>o).ToList();

        }

        static public int EqualPairs(int[][] grid)
        {
            int count = 0;

            IList<IList<int>> allCol = new List<IList<int>>();
            //row
            for (int i = 0; i < grid.Length; i++)
            {
                List<int> cols = new List<int>();
                //col
                for (int j = 0; j < grid[i].Length; j++)
                {
                    cols.Add(grid[j][i]);
                }
                allCol.Add(cols);                
            }

            for (int i = 0; i < grid.Length; i++)
            {
                List<int> rows = grid[i].ToList();
                foreach (var singleCol in allCol)
                {
                    if (rows.SequenceEqual(singleCol))
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        static public int DeleteGreatestValue(int[][] grid)
        {
            int maxSum = 0;
            int c = grid[0].Length;

            while(c != 0)
            {
                List<int> maxList = new List<int>();
                for (int i = 0; i < grid.Length; i++)
                {
                    List<int> rows = grid[i].ToList();
                    int max = rows.Max();
                    int j = rows.IndexOf(max);
                    maxList.Add(max);
                    grid[i][j] = 0;
                }
                maxSum += maxList.Max();
                c--;
            }           

            return maxSum;

        }


        static public int LargestAltitude(int[] gain)
        {
            int sum = 0;
            List<int> altList = new List<int>();
            altList.Add(0);
            for (int i = 0; i < gain.Length; i++)
            {
                sum += gain[i];
                altList.Add(sum);
            }
            return altList.Max();

        }
        static public int LargestAltitude1(int[] gain)
        {
            for (int i = 1; i < gain.Length; i++)
            {
                gain[i] = gain[i] + gain[i - 1];
            }

            int gMax = gain.Max();
            return gMax > 0 ? gMax : 0;
        }
        public int MinSubArrayLen1(int target, int[] nums)
        {
            int n = nums.Length;
            int ans = int.MaxValue;
            int left = 0;
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += nums[i];
                while (sum >= target)
                {                    
                    ans = ans < i + 1 - left ? ans : i + 1 - left;
                    sum -= nums[left++];
                }
            }
            return (ans != int.MaxValue) ? ans : 0;

        }
        static public int MinSubArrayLen(int target, int[] nums)
        {
            int start = 0;
            int end = 0;
            int w_sum = nums[0];
            int maxLen = int.MaxValue;
            while (end < nums.Length)
            {
                if (w_sum < target)
                {
                    end++;
                    if (end < nums.Length)
                        w_sum += nums[end];
                }
                else
                {
                    maxLen = Math.Min(maxLen, end - start + 1);
                    w_sum -= nums[start];
                    start++;
                }
            }
            return maxLen == int.MaxValue ? 0 : maxLen;
        }

        static public string MergeAlternately(string word1, string word2)
        {
            string s = "";
            int l = Math.Min(word1.Length, word2.Length);
            for (int i = 0; i < l; i++)
            {
                s += word1[i].ToString() + word2[i].ToString();
            }

            if (l == word1.Length)
            {
                s += word2.Substring(l);
            }
            else if (l == word2.Length)
            {
                s += word1.Substring(l);
            }

            return s;

        }

        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            if (flowerbed.Length == 1 && flowerbed[0] == 0 && n > 0)
            {
                n--;
            }
            else if (flowerbed.Length > 1 && flowerbed[0] == 0 && flowerbed[1] == 0 && n>0)
            {
                flowerbed[0] = 1;n--;
            }

           
            for (int i = 1; i < flowerbed.Length-1; i++)
            {
                if (n == 0)
                    break;
                
                if (flowerbed[i-1] == 0 && flowerbed[i+1] == 0 && flowerbed[i] == 0)
                {
                    flowerbed[i] = 1;
                    n--;
                }
            }

            int l = flowerbed.Length;
            if (flowerbed.Length > 1 && flowerbed[l-2] == 0 && flowerbed[l-1] == 0 && n>0)
            {
                flowerbed[l-1] = 1; n--;
            }

            if (n == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int[] AsteroidCollision(int[] asteroids)
        {
            List<int> result = new List<int>(asteroids);
            int i = 0;
            while (i < result.Count)
            {
                if (result[i] > 0 && i < result.Count - 1 && result[i + 1] < 0) //if collision
                {
                    int ast1 = Math.Abs(result[i]);
                    int ast2 = Math.Abs(result[i + 1]);
                    if (ast1 > ast2)
                    {
                        result.RemoveAt(i + 1);
                        continue;
                    }
                    else if (ast1 < ast2)
                    {
                        result.RemoveAt(i);
                    }
                    else
                    {
                        result.RemoveAt(i + 1);
                        result.RemoveAt(i);
                    }
                    i = i > 0 ? --i : i;
                    continue;
                }
                i++;
            }
            return result.ToArray();
        }

        static public string ReverseWords(string s)
        {
            s.Trim(' ');
            string str = "";
            var words = s.Split(' ');
            for (int i = words.Length-1; i >=0 ; i--)
            {
                if (words[i] == "")
                    continue;
                str += words[i] + " ";
            }
            return str.Trim();

        }

        static public int[] ProductExceptSelf1(int[] nums)
        {
            //Input: nums = [1, 2, 3, 4]
            //Output: [24,12,8,6]

            int p = 1;
            foreach (var num in nums)
            {
                if (num == 0)
                {
                    p = 0; break;
                }
                else
                {
                    p = p * num;
                }                
            }



            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[i] = p / nums[i];
                }
                else
                {
                        
                }
            }
            return nums;

        }

        static public int[] ProductExceptSelf(int[] nums)
        {
            int n = nums.Length;

            int[] pre = new int[n];
            int[] suff = new int[n];
            pre[0] = 1;
            suff[n - 1] = 1;

            for (int i = 1; i < n; i++)
            {
                pre[i] = pre[i - 1] * nums[i - 1];
            }
            for (int i = n - 2; i >= 0; i--)
            {
                suff[i] = suff[i + 1] * nums[i + 1];
            }

            int[] ans = new int[n];
            for (int i = 0; i < n; i++)
            {
                ans[i] = pre[i] * suff[i];
            }
            return ans;
        }

        static public int[] productExceptSelf(int[] nums)
        {
            int numsLength = nums.Length;
            int prefixProduct = 1;
            int suffixProduct = 1;
            int[] result = new int[numsLength];
            for (int i = 0; i < numsLength; i++)
            {
                result[i] = prefixProduct;
                prefixProduct *= nums[i];
            }
            for (int i = numsLength - 1; i >= 0; i--)
            {
                result[i] *= suffixProduct;
                suffixProduct *= nums[i];
            }
            return result;
        }

        static public bool IncreasingTriplet(int[] nums)
        {
            int max1 = int.MaxValue;
            int max2 = int.MaxValue;
            foreach (var n in nums)
            {
                if (n <= max1) max1 = n;
                else if (n <= max2) max2 = n;
                else return true;
            }            
            return false;
        }

        public int[] DecompressRLElist(int[] nums)
        {
            List<int> a = new List<int>();
            for (int i = 1; i < nums.Length; i++)
            {
                if (i%2 != 0) // value
                {
                    int c = nums[i - 1];
                    while (c >0)
                    {
                        a.Add(nums[i]);
                        c--;
                    }
                }
            }
            return a.ToArray();

        }

        static public int PivotIndex(int[] nums)
        {
            int sum = nums.Sum();
            int leftSum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if ((sum - nums[i]) % 2 == 0 &&
                    (sum - nums[i]) / 2 == leftSum)
                    return i;

                leftSum += nums[i];
            }

            return -1;
        }

        public int pivotIndex(int[] nums)
        {
            if (nums.Length == 0) return -1;
            int leftSum = 0, rightSum = nums.Sum(); 


            for (int i = 0; i < nums.Length; i++)
            {
                rightSum -= nums[i];
                if (rightSum == leftSum) return i;
                leftSum += nums[i];
            }
            return -1;
        }

        public int[] LeftRightDifference(int[] nums)
        {
            List<int> l = new List<int>();
            int leftSum = 0, rightSum = nums.Sum();


            for (int i = 0; i < nums.Length; i++)
            {
                rightSum -= nums[i];
                l.Add(Math.Abs(leftSum - rightSum));
                leftSum += nums[i];
            }
            return l.ToArray();

        }

        static public int[] DistinctDifferenceArray(int[] nums)
        {
            List<int> l = new List<int>();

            HashSet<int> h1 = new HashSet<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                h1.Add(nums[i]);
                HashSet<int> h2 = new HashSet<int>();

                for (int j = i+1; j < nums.Length; j++)
                {
                    h2.Add(nums[j]);
                }
                l.Add(h1.Count - h2.Count);
            }
            return l.ToArray();
        }

        public bool CanThreePartsEqualSum(int[] arr)
        {
            if (arr.Sum() % 3 != 0)
            {
                return false;
            }

            int sum = 0;
            int counter = 0;
            int average = arr.Sum() / 3;
            foreach (int number in arr)
            {
                sum += number;
                if (sum == average)
                {
                    counter++;
                    sum = 0;
                }
            }

            return counter >= 3;
        }

        public int findJudge(int n, int[][] trust)
        {
            int[] count = new int[n + 1];

            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < trust.Length; i++)
            {
                count[trust[i][1]]++;

                if (!map.ContainsKey(trust[i][0]))
                {
                    map.Add(trust[i][0], 1);
                }
            }
            for (int i = 1; i <= n; i++)
            {
                if (map.ContainsKey(i) == false)
                {
                    if (count[i] == (n - 1))
                        return i;
                }

            }
            return -1;

        }
        static public int TitleToNumber(string columnTitle)
        {
            int ans = 0;
            int doubler = 0;
            for (int i = columnTitle.Length - 1; i > -1; i--)
            {
                var c = columnTitle[i] - 'A' + 1;
                ans += (c) * (int)Math.Pow(26, doubler);
                doubler += 1;
            }
            return ans;
        }

        public int HammingWeight(int n)
        {
            int count = 0;
            while (n != 0)
            {
                n = n & (n - 1);
                count++;
            }
            return count;
        }
        static public uint reverseBits(uint n)
        {
            uint reversed = 0;
            for (int i = 0; i < 32; i++)
            {
                reversed = reversed << 1;
                if (n % 2 == 1)
                    reversed++;
                n = n >> 1;
            }
            return reversed;
        }

        static public int[] countBits(int n)
        {
            int[] R = new int[n + 1];
            if (n == 0) return R;

            for (int i = 1; i < n + 1; i++)
            {
                if (i % 2 == 0)
                { // number is even
                    R[i] = R[i / 2];
                }
                else
                { // is odd
                    R[i] = R[i - 1] + 1;
                }
            }
            return R;
        }

        public int hammingDistance(int x, int y)
        {
            int count = 0;
            while (x > 0 || y > 0)
            {
                if (x % 2 != y % 2) count++;
                x /= 2;
                y /= 2;
            }
            return count;
        }

        static public int TotalHammingDistance(int[] nums)
        {
            int total = 0; ;
            for (int i = 0; i <= nums.Length - 2; i++)
            {             
                
                for (int j = i + 1; j <= nums.Length - 1; j++)
                {
                    int x = nums[i];
                    int y = nums[j];
                    int count = 0;
                    while (x > 0 || y > 0)
                    {
                        if (x % 2 != y % 2) count++;
                        x /= 2;
                        y /= 2;
                    }
                    total += count;
                }
            }
            return total;
            
        }

        bool hasAlternatingBits2(int n)
        {
            /*
            n =         1 0 1 0 1 0 1 0
            n >> 1      0 1 0 1 0 1 0 1
            n ^ n>>1    1 1 1 1 1 1 1 1
            n           1 1 1 1 1 1 1 1
            n + 1     1 0 0 0 0 0 0 0 0
            n & (n+1)   0 0 0 0 0 0 0 0
            */

            n = n ^ (n >> 1);
            return (n & n + 1) == 0;
        }


        static public void rotate(int[] nums, int k)
        {
            k %= nums.Length;
            int n = nums.Length;
            reverseNum(nums, 0, n - 1);
            reverseNum(nums, 0, k - 1);
            reverseNum(nums, k, n - 1);
        }
        static public void reverseNum(int[] nums, int start, int end)
        {
            while (start < end)
            {
                int temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start++;
                end--;
            }
        }

        public int FindComplement(int num)
        {
            string r = "";
            while (num > 0)
            {
                r += (num % 2).ToString();
                num /= 2;
            }
            

            return 0;
        }

       static public int findComplement1(int num)
        {
            int dup = num, c = 1;
            while (dup != 0)
            {
                num = num ^ c; // XOR
                c = c << 1;
                dup = dup >> 1;
            }
            return num;
        }

        //100110, its complement is 011001, the sum is 111111.
        //So we only need get the min number large or equal to num,
        //then do substraction
        static public int findComplement(int num)
        {
            int ans = 1;
            while (num >= ans)
            {
                ans *= 2;
            }
            return ans - num - 1;
        }
       static public void duplicateZeros(int[] arr)
        {
            if (arr == null || arr.Length == 0) return;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                {
                    for (int j = arr.Length - 1; j > i; j--)
                    {
                        arr[j] = arr[j - 1];
                    }
                    i++; // we don't want to traverse over the duplicate zero
                }
            }
        }

        static public string MostCommonWord(string paragraph, string[] banned)
        {
            var allWords = paragraph.ToLower().Split(" !?',;.".ToCharArray(),  StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> d = new Dictionary<string, int>();

            foreach (var word in allWords)
            {
                string s = word.Trim().ToLower();

                if (!d.ContainsKey(s))
                {
                    d[s] = 1;
                }
                else
                {
                    d[s] += 1;
                }
            }
            int max = 0;
            string str = "";
            foreach (var key in d.Keys)
            {
                if (!banned.Contains(key) && d[key] > max)
                {
                    max = d[key];
                    str = key;
                }
            }

            return str;
        }

       static public bool DigitCount(string num)
        {
            Dictionary<int, int> d = new Dictionary<int, int>();
            for (int i = 0; i < num.Length; i++)
            {
                int t = Convert.ToInt32(num[i].ToString());
                if (!d.ContainsKey(t))
                {
                    d[t] = 1;
                }
                else
                {
                    d[t] += 1;
                }
            }

            for (int i = 0; i < num.Length; i++)
            {
                int c = Convert.ToInt32(num[i].ToString());
                if ( c > 0 && !d.ContainsKey(i))
                {
                    return false;
                }
                if (d.ContainsKey(i) && ( c != d[i]))
                {
                    return false;
                }
            }
            return true;

        }

        //We can turn similarity into equality: two words A and B are similar if f(A) equals to f(B)
        //where f takes distinct characters from the word and sorts them:
        //f(abracadabra) => abcdr
        //then we can group by similar words and perform a simple arithmetics
        // n (n-1) / 2
        public int SimilarPairs(string[] words) => words
       .GroupBy(word => string.Concat(word.Distinct().OrderBy(c => c)))
       .Sum(group => (group.Count() - 1) * group.Count() / 2);

       static public int SimilarPairs1(string[] words)
        {
            //foreach (var word in words)
            //{
            //    var dis = word.Distinct();
            //}
            var g = words.GroupBy(word => string.Concat(word.Distinct().OrderBy(c => c)));
            var s = g.Sum(group => (group.Count() - 1) * group.Count() / 2);

            return 0;
        }

        public int CountConsistentStrings(string allowed, string[] words)
        {

            int notAllowed = 0;
            foreach (string word in words)
            {
                foreach (char letter in word.ToCharArray())
                {
                    if (!allowed.Contains(letter + ""))
                    {
                        notAllowed++;
                        break;
                    }
                }
            }

            return words.Length - notAllowed;
        }


       static public int DistinctAverages(int[] nums)
        {
            HashSet<double> h = new HashSet<double>();            
            List<int> n = nums.ToList();

            while (n.Count>0)
            {
                int min = n.Min();
                int max = n.Max();

                n.Remove(min);
                n.Remove(max);

                double avg = (min + max) / 2.0;
                h.Add(avg);
            }
            return h.Count;
        }

        static public bool IsLongPressedName(string name, string typed)
        {
            int n = name.Length;
            int m = typed.Length;
            if (n > m) return false;
            if (name[0].ToString() != typed[0].ToString()) return false;
            int i = 0, j = 0;
            while (i < n && j < m)
            {
                if (name[i].ToString() == typed[i].ToString())
                {
                    i++;
                    j++;
                }
                else if (name[i - 1].ToString() == typed[j].ToString())
                {
                    j++;
                }
                else
                    return false;

            }
            while (j < m)
            {
                if (name[i - 1].ToString() == typed[j].ToString())
                    j++;
                else
                    return false;

            }
            if (i < n)
                return false;

            return true;
        }

        public int SubtractProductAndSum(int n)
        {
            int p = 1;
            int sum = 0;

            while (n>0)
            {
                int num = n % 10;
                n = n / 10;
                p *= num;
                sum += num;
            }
            return p - sum;
        }
        public int FindSpecialInteger1(int[] arr)
        {
            var count = arr.Length / 4;
            var current = arr[0];
            var currentCount = 1;

            for (var i = 1; i < arr.Length; i++)
            {
                if (arr[i] != current)
                {
                    current = arr[i];
                    currentCount = 1;
                }
                else
                {
                    currentCount++;
                    if (currentCount > count)
                    {
                        return current;
                    }
                }
            }

            return current;
        }

       static public int FindSpecialInteger(int[] arr)
        {

            int target = arr.Length/4;
            Dictionary<int, int> d = new Dictionary<int, int>();
            foreach (var item in arr)
            {
                if (!d.ContainsKey(item))
                {
                    d.Add(item, 1);
                }
                else
                {
                    d[item] += 1;
                }

                if (d[item] > target)
                {
                    return item;
                }
            }

            return -1;

        }

        #endregion

        #region LeetCode target 400
        static public int[] FindMissingAndRepeatedValues(int[][] grid)
        {
            List<int> list = new List<int>();
            Dictionary<int, int> d = new Dictionary<int, int>();

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (!d.ContainsKey(grid[i][j]))
                    {
                        d[grid[i][j]] = 1;
                    }
                    else
                    {
                        d[grid[i][j]] += 1;
                    }
                }
            }

            for (int i = 1; i <= grid.Length*grid.Length; i++)
            {
                if (d.ContainsKey(i) && d[i] > 1)
                {
                    list.Add(i);
                }
            }

            for (int i = 1; i <= grid.Length * grid.Length; i++)
            {
                if (!d.ContainsKey(i))
                {
                    list.Add(i);
                }
            }

            return list.ToArray();
        }

        static public bool IsFascinating(int n)
        {
            string s = (n.ToString() + (n * 2).ToString() + (n * 3).ToString());
            var charArray = s.ToArray().OrderBy(o=>o).ToArray();
            //char[] charArray = { '1', '2', '3', '4', '5' };
            int[] intArray = charArray.Select(c1 => (int)Char.GetNumericValue(c1)).ToArray();


            for (int i = 0; i < intArray.Length; i++)
            {
                if (intArray[i] != i+1)
                {
                    return false;
                }
            }
            return true;            
        }

        static public Boolean IsFascinating2(int n)
        {
            int a = 2 * n;
            int b = 3 * n;
            String s = "";
            s = s + a + b + n;
            int[] arr = new int[10];

            for (int i = 0; i < s.Length; i++)
            {
                int t = Convert.ToInt32(s[i].ToString());
                arr[t]++;
            }

            if (arr[0] >= 1)
            {
                return false;
            }
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] != 1)
                {
                    return false;
                }
            }
            return true;
            
        }

       static public string MaximumOddBinaryNumber(string s)
        {
            var count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '1') count++;
            }
            //var a = new string('1', count - 1);
            //var b = new string('0', s.Length - count);
            var rs = new string('1', count - 1) + new string('0', s.Length - count) + new string('1', 1);
            return rs;
        }


        #endregion

        static public async Task<string> StoreManufacturingCsv(string pathToStoreCSV)
        {
            pathToStoreCSV = @"D:\\";  //Projects\
            //string folderPath = @"\\fserver\shared\RPO\!Public\MaxMDL\";
            //S:\Manufacturing\Production\!Private
            //var msg = new MessageHelperDto();
            List<CellLocatorSheet> cellLocatorSheetList = new List<CellLocatorSheet>();
            if (true)
            {
                var cls = new CellLocatorSheet
                {
                    DrugName = "DULOXETINE HCL DR 20 MG CAP",
                    LabelName = "",
                    Baffle = 3,
                    Height = 1.5,
                    Width = "B.75",
                    Cell = "9V",
                    CellType = "",
                    MaxCapacity = 716,
                    SuperCellMaxCapacity = 1123,
                    NDC = "57237001760",
                    Pressure = 30,
                    ThirtyDramCapacity = 159
                };
                cellLocatorSheetList.Add(cls);
            }

            try
            {
                XmlWriterSettings settings = new XmlWriterSettings { Async = true };
                settings.Encoding = Encoding.UTF8;
                settings.Indent = true;
                settings.NewLineChars = "\n";
                settings.OmitXmlDeclaration = true;

                using (FileStream fileStream = new FileStream(pathToStoreCSV, FileMode.Create, FileAccess.Write, FileShare.None, 4096, FileOptions.Asynchronous | FileOptions.WriteThrough))
                {
                    using (var bufferedStream = new BufferedStream(fileStream, 65536))
                    {
                        using (StreamWriter writer = new StreamWriter(bufferedStream))
                        {
                            using (CsvWriter csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                            {
                                await csv.WriteRecordsAsync(cellLocatorSheetList);
                                await csv.FlushAsync();
                            }
                            writer.Close();
                        }
                    }
                    fileStream.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return "";

        }


        static void Main(string[] args)
        {

            //    var superLockingCell = new List<string> { "9A", "9B", "7A", "7B" };
            //    var superCell = new List<string> { "4A", "4B", "7C", "7D" };

            //    // Get the last elements
            //    var lastSuper = superCell.LastOrDefault();
            //    var lastSuperLocking = superLockingCell.LastOrDefault();

            //    // Extract integer parts from the last elements
            //    int lastSuperNum = lastSuper != null ? int.Parse(lastSuper.Substring(0, lastSuper.Length - 1)) : -1;
            //    int lastSuperLockingNum = lastSuperLocking != null ? int.Parse(lastSuperLocking.Substring(0, lastSuperLocking.Length - 1)) : -1;

            //    // Check if the integer parts match
            //    bool isMatch = lastSuperNum == lastSuperLockingNum;

            //    // Filter superCell based on the match condition
            //    var filteredSuperCell = isMatch
            //        ? superCell.Where(item => int.Parse(item.Substring(0, item.Length - 1)) == lastSuperNum).ToList()
            //        : superCell;


            //var superCell = new List<string> { "7C", "7D" };
            //var updatedSuperCell = new List<string>();

            //// Remove digits and keep only letters
            //foreach (var item in superCell)
            //{
            //    string newItem = new string(item.Where(cc => !char.IsDigit(cc)).ToArray());
            //    updatedSuperCell.Add(newItem);
            //}

            //// Add missing letters from 'A' to the last letter in the list
            //var lastLetter = updatedSuperCell.LastOrDefault();
            //var ca = Convert.ToChar(lastLetter);

            //for (char ch = 'A'; ch <= ca; ch++)
            //{
            //    if (!updatedSuperCell.Contains(ch.ToString()))
            //    {
            //        updatedSuperCell.Add(ch.ToString());
            //    }
            //}

            //// Sort the list alphabetically (optional)
            //updatedSuperCell.Sort();

            //var supper = new List<string> { "2A", "2B", "4B", "4C", "7C", "9D" };
            //var uniqueIntegers = new HashSet<string>();

            //foreach (var item in supper)
            //{
            //    // Extract the numeric part and convert it to an integer
            //    int number = int.Parse(new string(item.Where(char.IsDigit).ToArray()));

            //    // Add the number to the HashSet to ensure uniqueness
            //    uniqueIntegers.Add(number.ToString());
            //}

            //// Convert the HashSet to a List if needed
            //var uniqueIntegerList = uniqueIntegers.ToList();

            var supper = new List<string> { "2A", "2B", "4B", "4C", "7C", "9D" };

            var uniqueIntegers = new HashSet<int>();

            foreach (var item in supper)
            {
                int number = int.Parse(new string(item.Where(char.IsDigit).ToArray()));
                uniqueIntegers.Add(number);
            }
            var uniqueIntegerList = uniqueIntegers.ToList();
            uniqueIntegerList.Sort();

            // Step 2: Find the alphabetic letters associated with the last integer
            var lastInteger = uniqueIntegerList.Last();
            var alphabeticLetters = new HashSet<string>();

            foreach (var item in supper)
            {
                // Extract the numeric part and check if it matches the last integer
                int number = int.Parse(new string(item.Where(char.IsDigit).ToArray()));
                if (number == lastInteger)
                {
                    // Extract the alphabetic part and add it to the HashSet
                    string letter = new string(item.Where(char.IsLetter).ToArray());
                    alphabeticLetters.Add(letter);
                }
            }
            var alphabeticLetterList = alphabeticLetters.ToList();

            #region Leetcode 300 function call

            int[][] grid = new int[3][];
            grid[0] = new int[] { 9, 1, 7 };
            grid[1] = new int[] { 8, 9, 2 };
            grid[2] = new int[] { 3, 4, 6 };

            //await StoreManufacturingCsv("");

            //MaximumOddBinaryNumber("0101");
            // FindMissingAndRepeatedValues(grid);

            //IsFascinating(192);

            string[] words = { "aba", "aabb", "abcd", "bac", "aabc" };
            //HalvesAreAlike("book");

            //DigitCount("1");
            //string s = "Bob hit a ball, the hit BALL flew far after it was hit.";

            // MostCommonWord(s,str);

            //string s = "";
            //return s.ToLower();

            int[] nums = { 1, 2, 2, 6, 6, 6, 6, 7, 10 }; //{ -1, 1, 0, -3, 3 };

            //FindSpecialInteger(nums);

            //rotate(nums,2);

            //Console.WriteLine(reverseBits(0010100101000001111010011100));


            //int[] nums = { 2, 3, 1, 2, 4, 3 };
            //Console.WriteLine(MinSubArrayLen(7, nums));

            //int[] nums = { 1,2,3 };
            //int[] num2 = { 2, 4,6 };

            // Console.WriteLine(FindDifference(nums, num2));
            //int[][] a = new int[2][];
            //a[0] = new int[] { 7,13, 34, 45, 10, 12, 27, 13 };
            //a[1] = new int[] { 27, 21, 45, 10, 12, 13 };
            //a[2] = new int[] { 4, 3, 6, 5 };

            //Console.WriteLine(Intersection(a));


            //int[][] a = new int[4][];
            //a[0] = new int[] { 3,1,2,2 };
            //a[1] = new int[] { 1,4,4,5 };
            //a[2] = new int[] { 2,4,2 ,2};
            //a[3] = new int[] { 2, 4, 2,2 };

            //Console.WriteLine(EqualPairs(a));

            //int[][] a = new int[2][];
            //a[0] = new int[] { 1, 2, 4 };
            //a[1] = new int[] { 3,3,1 };

            //Console.WriteLine(DeleteGreatestValue(a));




            #endregion


            #region OOP

            // 'obj' is the object of  class 'baseClass'
            baseClass ob = new baseClass();

            // GeeksForGeeks' cannot  be instantiate
            GeeksForGeeks g;

            // instantiate class 'Geek1'
            //g = new Geek1();
           

            #endregion

            //DrawerSelection(0, 0, 0);

            int[] a1 = new int[] { 9, 9, 9 };

            #region FunctionCall
            int[] nums1 = { 1, 2 };
            int[] aa = { -18, 1, 2, 3, 4, 5 };
            int[] b = { 1, 2, 3, 4, 5 };
            //doIntegerBasedRounding(b, 3);
            int[] c = { -1, 0, 1, 1 };

            //int r = decodeArray1(c);
            //computeHMS(3735);

            int[] d = { 1, 2, 1, 2, 1, 2, 1, 2, 1 };
            //Console.WriteLine(isMartian(d));

            int[] e = { };
            //Console.WriteLine(isPairedN(e,0));
            int[] f = { 2 };
            //Console.WriteLine(isNPrimeable(f, 1));

            //Console.WriteLine(BalancedStringSplit(""));

            // Console.WriteLine(MaxNumberOfBalloons(""));

            int[] n = { 2,2,1,1 };
            int[] p = { 1,2};

            // Console.WriteLine(matchPattern3(n, 5, p, 2));

            //Console.WriteLine(isSequencedArray(new int[] { 1, 2, 3, 4, 5 }, 1, 5));
            //Console.WriteLine(isSequencedArray(new int[] { 1, 3, 4, 2, 5 }, 1, 5));
            //Console.WriteLine(isSequencedArray(new int[] { -5, -5, -4, -4, -4, -3, -3, -2, -2, -2 }, -5, -2));
            //Console.WriteLine(isSequencedArray(new int[] { 0, 1, 2, 3, 4, 5 }, 1, 5));
            //Console.WriteLine(isSequencedArray(new int[] { 1, 2, 3, 4 }, 1, 5));
            //Console.WriteLine(isSequencedArray(new int[] { 5, 4, 3, 2, 1 }, 1, 5));

            //Console.WriteLine(FindMedianSortedArrays(nums1, nums2));
            //CellCalculation(11,0,0);
            // CellCalculationCustom(6, -10, 15, "C");
            //NewCellCalculation(2,0,0);
            //Max2CellCalculationNew(1, 12, 5, 12); // 200 - 

            //ATPDeviceConfigurationByCustomerInput(2,2,192);
            //Console.WriteLine(isDigitIncreasing(36));
            // Console.WriteLine(checkConcatenatedSum(198, 3));

            //largestPrimeFactor(8);

            //Console.WriteLine(isZeroBalanced(new int[] { 1, 4, -3, -2 }));

            //Console.WriteLine(isConsectiveFactored(2));
            //Console.WriteLine(isHollow(new int[] {2,0,1,0,0,0,2,2,2 }));


            //Console.WriteLine(eval(2.0,new int[] { 4, 0, 9 }));
            //Console.WriteLine(loopSum(new int[] { 3 }, 10));


            //Console.WriteLine(is121Array1(new int[] { 1, 1, 2, 2, 2, 1, 1 }));
            //Console.WriteLine(is121Array1(new int[] { 1, 1, 2, 2, 2, 1, 1, 1 }));
            //Console.WriteLine(is121Array1(new int[] { 1, 1, 1, 2, 2, 2, 1, 1 }));
            //Console.WriteLine(is121Array1(new int[] { 1, 1, 1, 2, 2, 2, 1, 1, 1, 3 }));
            //Console.WriteLine(is121Array1(new int[] { 1, 1, 1, 2, 2, 2, 1, 1, 1, 2, 2 }));
            //Console.WriteLine(is121Array1(new int[] { 1, 1, 1, 1, 1, 1 }));


            //Console.WriteLine(isZeroPlentiful(new int[] { 0,0,0,0,0 }));
            //Console.WriteLine(isZeroPlentiful(new int[] { 1, 1, 0,0,0,0, 2, -2, 0,0,0,0,0,21, 1 }));
            //Console.WriteLine(isZeroPlentiful(new int[] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1 }));
            //Console.WriteLine(isZeroPlentiful(new int[] { 1, 1, 1, 2 }));
            //Console.WriteLine(isZeroPlentiful(new int[] { 1, 0, 0, 0, 1, 2, 0, 0, 0, 0 }));
            //Console.WriteLine(isZeroPlentiful(new int[] { 0 }));


            //Console.WriteLine(isSystematicallyIncreasing(new int[] { 1, 2, 1, 2, 3 }));
            //Console.WriteLine(isSystematicallyIncreasing(new int[] { 1, 1, 3 }));
            //Console.WriteLine(isSystematicallyIncreasing(new int[] { 1, 2, 1, 2, 1, 2 }));
            //Console.WriteLine(isSystematicallyIncreasing(new int[] { 1, 2, 3, 1, 2, 1 }));
            //Console.WriteLine(isSystematicallyIncreasing(new int[] { 1, 1, 2, 3 }));
            //Console.WriteLine(isSystematicallyIncreasing(new int[] { 1, 1, 2, 1, 2, 3 }));


            //Console.WriteLine(decodeArray(new int[] { 1 }));
            //Console.WriteLine(decodeArray(new int[] {0, 1 }));
            //Console.WriteLine(decodeArray(new int[] { -1, 0, 1 }));
            //Console.WriteLine(decodeArray(new int[] { 0, 1, 1, 1, 1, 1, 0, 1 }));
            //Console.WriteLine(decodeArray(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 }));


            //Console.WriteLine(encodeArray(0));
            //Console.WriteLine(encodeArray(1));
            //Console.WriteLine(encodeArray(-1));
            //Console.WriteLine(encodeArray(100001));
            //Console.WriteLine(encodeArray(999));


            //Console.WriteLine(areAnagrams(new char[] {'s','i','t' }, new char[] { 's', 't', 'i' }));
            // Console.WriteLine(areAnagrams(new char[] {'p','o','o' }, new char[] { 'o', 'p', 'o' }));

            //Console.WriteLine(closestFibonacci(13));
            //Console.WriteLine(isFactorialPrime(3));
            //Console.WriteLine(largestDifferenceOfEvens(new int[] { 1,2,4,6 }));
            // Console.WriteLine(isHodder(32));
            // Console.WriteLine(IsAnagram(32));
            // Console.WriteLine(isVesuvian(50));


            //Console.WriteLine(isOneBalanced(new int[] { 1,1,1,2,3,-18,45,1 }));
            //Console.WriteLine(isOneBalanced(new int[] { 1, 1, 1, 2, 3, -18, 45, 1,0 }));
            //Console.WriteLine(isOneBalanced(new int[] { 1, 1,  2, 3, 1, -18, 45, 1 }));
            //Console.WriteLine(isOneBalanced(new int[] {  }));
            //Console.WriteLine(isOneBalanced(new int[] { 2, 3, 1, 1 }));
            //Console.WriteLine(isOneBalanced(new int[] { 1, 1,  2, 3 }));
            //Console.WriteLine(isOneBalanced(new int[] { 3,3 }));
            //Console.WriteLine(isOneBalanced(new int[] { 1, 1, 1}));
            //Console.WriteLine(decodeArray(new int[] {0, 1 }));


            //Console.WriteLine(isMercurial(new int[] { 1,3,1 }));
            //Console.WriteLine(isMercurial(new int[] { 2, 3, -18, 45, 1 }));
            //Console.WriteLine(isMercurial(new int[] { 1, 2, 3 }));
            //Console.WriteLine(isMercurial(new int[] { 3, 1, 3, -18, 1, 3 }));
            //Console.WriteLine(isMercurial(new int[] { 2, 3, -18, 1, 1 }));
            //Console.WriteLine(isMercurial(new int[] { 1, 1, 3 }));
            //Console.WriteLine(isMercurial(new int[] { 3, 3 }));
            //Console.WriteLine(isMercurial(new int[] { 1 }));
            //Console.WriteLine(isMercurial(new int[] { }));


            //Console.WriteLine(computeHMS(3650));



            //Console.WriteLine(isMartian(new int[] { 1 ,3}));
            //Console.WriteLine(isMartian(new int[] { 1,2,1,2}));
            //Console.WriteLine(isMartian(new int[] { 1, 2, 3}));
            //Console.WriteLine(isMartian(new int[] { 1, 2, -18,-18,1, 2 }));
            //Console.WriteLine(isMartian(new int[] { }));
            //Console.WriteLine(isMartian(new int[] { 1 }));
            //Console.WriteLine(isMartian(new int[] { 2 }));


            //Console.WriteLine(is121Array3(new int[] { 1, 2,1 }));
            //Console.WriteLine(is121Array3(new int[] { 1,1, 2, 1,1 }));
            //Console.WriteLine(is121Array3(new int[] { 1, 1, 2, 1, 1 ,1}));
            //Console.WriteLine(is121Array3(new int[] { 1,1, 1, 2, 1, 1 }));
            //Console.WriteLine(is121Array3(new int[] { 1, 2, 1,3 }));
            //Console.WriteLine(is121Array3(new int[] { 1,  1 }));
            //Console.WriteLine(is121Array3(new int[] {  2, 1 }));
            //Console.WriteLine(is121Array3(new int[] { 1,2, 1 ,2}));
            //Console.WriteLine(is121Array3(new int[] { 2, 2}));


            //Console.WriteLine(pairwiseSum(new int[] { 2, 1, 18, -5 }));
            //Console.WriteLine(pairwiseSum(new int[] { 2, 1, 18, -5, -5, -15, 0, 0, 1, -1 }));


            // Console.WriteLine(loopSum1(new int[] { -1, 2, -1 }, 7));
            //.WriteLine(loopSum1(new int[] { 3}, 10));

            //Console.WriteLine(isLayered(new int[] { 2, 2, 3,3 }));

            //updateMileagecounter(new int[] { 9,9 ,9}, 13);

            //Console.WriteLine(isConsectiveFactored(-2));

            //Console.WriteLine(isHollow(new int[] {0,0,0 }));


            //Console.WriteLine(isInertial(new int[] {1 }));
            //Console.WriteLine(isInertial(new int[] { 2 }));
            // Console.WriteLine(isInertial(new int[] { 1, 2, 3, 4 }));
            // Console.WriteLine(isInertial(new int[] { 1 ,1,2}));

            // Console.WriteLine(isInertial(new int[] { 2,12,4,6,8,11 }));
            //Console.WriteLine(isInertial(new int[] { 2, 12,12, 4, 6, 8, 11 }));
            //Console.WriteLine(isInertial(new int[] { -2,-4,-6,-8,-11 }));
            //Console.WriteLine(isInertial(new int[] { 2,3,5,7 }));
            //Console.WriteLine(isInertial(new int[] { 2,4,6,8,10 }));


            //Console.WriteLine(isMadhavArray(new int[] {6,2,4,2,2,2,1,5,0,0 }));

            //Console.WriteLine(isMadhavArray(new int[] { 3,1,2,3,0 }));

            //Console.WriteLine(computeDepth(25));
            //Console.WriteLine(convertToBase10(new int[] { 3,2,5 }, 8));
            //Console.WriteLine(isVanilla(new int[] { 11, 22}));            

            // Console.WriteLine(isSequentiallyBounded(new int[] { 5,5,5,2,5 }));


            //Console.WriteLine(isMinMaxDisjoint(new int[] { 5, 4, 1,3, 2}));
            // Console.WriteLine(countRepresentations(12));
            //Console.WriteLine(filterArray(new int[] { 8,4,9,0,3,1,2 }, 88));
            //Console.WriteLine(isBean(new int[] { 9,10, 3,2}));
            //Console.WriteLine(isMeera(new int[] { 10,6,1}));
            //Console.WriteLine(isfibo(12));            
            //Console.WriteLine(fill(new int[] { 1,2,3,0,3,1,2 }, 3, 10));
            //Console.WriteLine(isWave(new int[] { 2,3,4,5}));
            //Console.WriteLine(minDistance(13013));
            //Console.WriteLine(isMeera(21));
            //Console.WriteLine(isNormal(3));
            //Console.WriteLine(isBalanced(new int[] { 2,3,5,7}));
            //Console.WriteLine(isDual(new int[] { 2, 2, 5, 5 }));
            //Console.WriteLine(isDaphne(new int[] { 2, 4, 6, 8, 6 }));
            //Console.WriteLine(isDaphne(new int[] { 4, 8, 6, 3, 2, 9, 8, 11, 8, 13, 12, 12, 6  }));
            //Console.WriteLine(factorTwoCount(27));
            //Console.WriteLine(isCentered(new int[] { 3, 2, 2, 4, 5 }));

            //Console.WriteLine(isFancey(17));
            //Console.WriteLine(isComplete2(new int[] { 2,3,4, 3, 6}));
            //Console.WriteLine(isSmart(16));

            //Console.WriteLine( isSetEqual(new int[] { 1,9,12 }, new int[] { 9,1,12,3 }));

            //Console.WriteLine(isSetEqualString(new char[] { 'a','b' }, new char[] { 'a','b','a' }));

            //Console.WriteLine(isTwin(new int[] { 5, 3, 14, 7, 18, 67 }));
            //Console.WriteLine(countDigit(331,3));
            //Console.WriteLine(haskSmallFactors(6, 14));

            //Console.WriteLine(isPrimeProduct(23));

            //Console.WriteLine(countOnes(15));
            

            #endregion





            //  S, SL, L , full locking option 3 for full
            // Max2CellCalculationNew(1, 27, 27, 146, 1);  // custom ok
            //Max2CellCalculationNew(1, 27, 0, 0, 3); // full locking
            // Max2CellCalculationNew(1, 23, 0, 0, 1);  // standard
            // Max2CellCalculationNew(5, 0, 22, 22, 1); // 66 , 22
            //Max2CellCalculationNew(1, 44, 0, 0, 3); // full locking
            // Max2CellCalculationNew(1, 23, 10, 5,1);  // case no 1.
            // Max2CellCalculationNew(1, 44, 34, 12,1);  // case no 2.
            // Max2CellCalculationNew(1, 88, 58 ,16,1);  // case no 3.
            //Max2CellCalculationNew(1, 89, 80, 20, 1); // case no 4.
            // Max2CellCalculationNew(1, 76, 27, 36, 1); // case no 5.
            // Max2CellCalculationNew(1, 60, 40, 24,1);  // case no 6. 
            // Max2CellCalculationNew(1, 25, 20, 20, 1);  // case no. 7. 
            //Max2CellCalculationNew(1, 25, 23, 22, 1);  // case no. 8 
            // Max2CellCalculationNew(1, 58, 57, 49,1);  // case no. 9 
            // Max2CellCalculationNew(1, 27, 0, 0, 1);  // case no. 9.1  standard
            // Max2CellCalculationNew(1, 27, 27, 146, 1);  // case no. 9.1  standard
            // Max2CellCalculationNew(1, 27, 27, 144, 1);  // case no. 9.1  standard
            // Max2CellCalculationNew(1, 44, 44, 112, 2); // custom
            // Max2CellCalculationNew(1, 44, 44, 24, 3);


            #region Linked List

            //ListNode one = new ListNode(1);
            //ListNode two = new ListNode(2);
            //ListNode three = new ListNode(3);
            //one.next = two;
            //two.next = three;
            //ReverseList(one);


            ListNode one = new ListNode(4);
            ListNode two = new ListNode(1);
            ListNode three = new ListNode(6);
            //ListNode four = new ListNode(2);
            
            one.next = two;
            two.next = three;
            //three.next = four;
            //four.next = one;
            //Console.WriteLine(RemoveNodes(one));


            //DeleteMiddle(one);
            //ReorderList(one);

            #endregion
            //........................Tree...................

            #region Tree
            //TreeNode one = new TreeNode(1);
            //TreeNode two = new TreeNode(2);

            //TreeNode three = new TreeNode(3);
            //TreeNode four = new TreeNode(4);
            //TreeNode five = new TreeNode(5);

            //one.left = two;

            ////one.right = three;
            ////two.left = four;
            ////two.right = five;

            //List<int> res = new List<int>();

            //TreeNode onee = new TreeNode(1);
            //TreeNode twoo = new TreeNode(2);
            //onee.right = twoo;

            ////postorderTraversal(one, res);

            //var found = IsSameTree(one, onee);

            //foreach (var item in res)
            //{
            //    Console.Write(item + " ");
            //}

            #endregion
            //.....................End Tree...............
            #region Array


            //string[] w = { "cool", "lock", "cook" };
            // Console.WriteLine(CommonChars(w));

            //int[][] a = new int[3][];
            //a[0] = new int[] { 1, 3, 4 };
            //a[1] = new int[] { 2, 1, 3 };
            //a[2] = new int[] { 5, 2, 1 };

            //Console.WriteLine(IsToeplitzMatrix(a));

            //int[] a = { 5, 1, 22, 25, 6, -1, 8, 10 };
            //int[] b = { 1, 6, -1, 10 };
            //isValidSubsequence2(a, b);
            // isValidSubsequence("ahbgdc", "abc");

            //Floyed1(5);

            //Console.WriteLine(MySqrt(65));
            // int[] a = { 1, 0, 0, 3, 2 };
            //MoveZeroesToFirst(a);
            //moveZeroesF(a);
            // int[] a = { 3, 2, 2, 3 };
            // Console.WriteLine(RemoveElement(a,3));

            //int[] a = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            //Console.WriteLine(removeDuplicates1(a));
            //Console.WriteLine(CheckPerfectNumber(8128));
            // Console.WriteLine(fib(0));


            //int[][] a = new int[1][];

            //a[0] = new int[] { 1, 2, 3 };
            //a[1] = new int[] { 4, 5, 6 };
            //a[2] = new int[] { 7, 8, 9 };

            //Console.WriteLine(Transpose(a));

            //int[][] a = new int[3][];

            //a[0] = new int[]{ 3,7,8};
            //a[1] = new int[]{ 9,11,13};
            //a[2] = new int[]{ 15,16,17};

            //Console.WriteLine(LuckyNumbers(a));

            //int[] a = { -100,-98,-1,2,3,4 };
            //Console.WriteLine(MaximumProduct(a));

            //int[] a = { 1, 2, 3, 4 };

            //Console.WriteLine(Construct2DArray(a, 2, 2));
            // int[][] a = new int[2][];
            //a[0] = new int[] { 1,2};
            // a[1] = new int[] { 3,4};
            // Console.WriteLine(MatrixReshape(a, 1, 4));

            //int[] a = { 6, 2, 6, 5, 1, 2 };
            // Console.WriteLine(ArrayPairSum(a));

            // string[] words1 = { "leetcode", "is", "amazing", "as", "is" };
            // string[] words2 = { "amazing", "leetcode", "is" };
            // Console.WriteLine(CountWords(words1, words2));


            //string s = "leetcode";
            //Console.WriteLine(CheckIfPangram(s));

            //int[] a = { 1, 3, 2, 2, 5, 2, 3, 7 };
            //Console.WriteLine(FindLHS(a));
            //int[] a = { 1, 2, 2,  1, 3 };
            //Console.WriteLine(UniqueOccurrences(a));

            //int[] a = { 28, 6, 22, 8, 44, 17 };
            //int[] b = { 22, 28, 8, 6 };
            //Console.WriteLine(RelativeSortArray(a,b));
            //string s1 = "gw pk xy";
            //string s2 = "gw aje zqd";
            //Console.WriteLine(UncommonFromSentences(s1,s2));


            //Console.WriteLine(IsHappy2(19));
            //int[] a = { 4, 3, 2, 7, 8, 2, 3, 1 };

            //Console.WriteLine(FindDuplicates(a));

            //Console.WriteLine(IsValid("()[]{}"));
            //Console.WriteLine(IsAnagram("ami", "ima"));
            /*
            int[] a =  { 1,2,3 };
            int[][] b = {    new int[] { 1,2,3},
                             new int[] { 4,5,6},
                             new int[] { 7,8,9}
                            };
            int[,] c = { { 1,2,3},
                         { 4,5,6},
                         {7,8,9 } };

            Console.WriteLine(DiagonalSum(c)); */



            //int[] id1 = { 1, 2, 2, 1 };
            //int[] id2 = { 2, 2 };

            //Console.WriteLine(Intersection(id1, id2));

            // int[] nums = { 0, 1, 0, 3, 12 };

            //MoveZeroes(nums);

            //int[] nums1 = { 1, 2, 3, 0, 0, 0 };
            //int m = nums1.Length;
            //int[] nums2 = { 2, 5, 6 };
            //int n = nums2.Length;

            //Merge(nums1, m, nums2, n);

            // int[] a = { 9,9,9 };
            // Console.WriteLine(PlusOne(a));

            //int[] a = { 100, 4, 200, 1, 3, 2 };
            // Console.WriteLine(LongestConsecutive(a));
            //int [,] d = pascal(5);


            /*
            IList<IList<int>> resultList = new List<IList<int>>();

            List<int> r1 = new List<int>() { 2 };
            List<int> r2 = new List<int>() { 3, 4 };
            List<int> r3 = new List<int>() { 6, 5, 7 };
            List<int> r4 = new List<int>() { 4, 1, 8, 3 };
            resultList.Add(r1);
            resultList.Add(r2);
            resultList.Add(r3);
            resultList.Add(r4);
            // Console.WriteLine(MinimumTotal1(resultList));

            // row column fixed size
            int[,] c = { { 2, 0, 0, 0 }, { 3, 4, 0, 0 }, { 6, 5, 7, 0 }, { 4, 1, 8, 3 } };
            // Console.WriteLine(MinimumTotal3(c));

            // Declare the array of two elements:
            int[][] arr = new int[4][];

            // Initialize the elements:
            arr[0] = new int[] { 2 };
            arr[1] = new int[] { 3, 4 };
            arr[2] = new int[] { 6, 5, 7 };
            arr[3] = new int[] { 4, 1, 8, 3 };

            // Another way of Declare and
            // Initialize of elements  Column not fixed
            int[][] arr1 = { new int[] { 2},
                             new int[] { 3,4 } ,
                             new int[] { 6, 5, 7  },
                             new int[] { 4, 1, 8, 3 }
                            };

            //Console.WriteLine(MinimumTotal2(arr));

            int[][] d = {   new int[] { -1 },
                            new int[] { 2, 3 },
                            new int[] { 1, -1, -3 } };

            IList<IList<int>> dList = new List<IList<int>>();
            dList.Add(new List<int>() { -1 } );
            dList.Add(new List<int>() { 2, 3 } );
            dList.Add(new List<int>() { 1, -1, -3 } );

            */

            //Console.WriteLine(MinimumTotal(dList));

            //reverse(12345);
            //piramid4(4);
            //int[] a = { 9,4,9,8,4};
            //int[] b = { 4,9,5};
            //Console.WriteLine(Intersect(a, b));

            //int[] a = {1,1,1};
            //Console.WriteLine(is121Array(a));

            //int[] a = { 4, 3, 2, 7, 8, 2, 3, 1 };
            //Console.WriteLine(FindDisappearedNumbers1(a));

            //int[] a = { 0, 2, 1, 2 };
            //int[] b = { 3, 1, 2, 0 };
            //Console.WriteLine(equivalantArray(a, b));


            // int[] a = { 1, 2,2,1};

            //Console.WriteLine(hasNValue(a, 2));

            // int[] a = { 1, 1, 1,  5, 5, 8, 8, 8 };
            //Console.WriteLine(isStepped(a));

            //Console.WriteLine(isPrimeHappy(8));
            //Console.WriteLine(isDigitIncreasingMukta(36));

            //int[] nums = { 1, 2};
            //Console.WriteLine(MajorityElement(nums));

            //Console.WriteLine(CanConstruct("aa", "aab"));
            //Console.WriteLine(FirstUniqChar("aabb"));

            //Console.WriteLine(reverseNumber(-1234));

            //int[] a = { 1, 8, 3, 2, 6 };
            //int[] b =  {1,4};
            //Console.WriteLine(commonArray(a, b));
            // int[] p = { 3, 4, 5, 10 };

            //Console.WriteLine(POE(p));

            #endregion

            // Creating Object
            //OOP ob = new OOP();

            //int sum1 = ob.Add(1, 2);
            //Console.WriteLine("sum of the two "  + "integer value : " + sum1);
            //int sum2 = ob.Add(1, 2, 3);
            //Console.WriteLine("sum of the three " + "integer value : " + sum2);



            Program obj = new Program();
            Console.WriteLine("The generation number of object obj is: "
                                          + GC.GetGeneration(obj));
            Console.WriteLine("Total Memory:" + GC.GetTotalMemory(false));

            Console.ReadKey();

            // Generate(5);
            //GetRow1(5);

            /* 
            int[,] arr = new int[2, 3] {
                                        {1, 2, 3} ,
                                        {4, 5, 6}
                                     };
            convert2DArray(arr);
            Console.WriteLine(" ");

            string str = "hello world";
            charOccurance(str);
            Console.WriteLine(" ");

            Console.WriteLine(findAngle(13, 30));
            Console.WriteLine(" ");

            Console.WriteLine(dblLinear(10));
            */


        }



        static public bool IsPalindrome(ListNode head)
        {            
            List<int> values = new List<int>();

            while (head != null)
            {
                values.Add(head.val);
                head = head.next;
            }

            int l = values.Count - 1;
            for (int i = 0; i < l; i++)
            {
                if (values[i] != values[l])
                {
                    return false;
                }
                l--;
            }
            return true;
        }


        public ListNode RemoveNodes(ListNode head)
        {
            if (head.next == null)
                return head;
            head.next = RemoveNodes(head.next);

            if (head.next.val > head.val)
                return head.next;

            return head;
        }

        static public ListNode ReverseList(ListNode head)
        {

            ListNode prev = null;
            ListNode cur = head;

            while (cur != null)
            {
                ListNode nextTemp = null;
                if (head.next != null)
                {
                    nextTemp = head.next;
                }

                cur.next = prev;

                prev = cur;
                cur = nextTemp;

            }

            return prev;
        }

        static public ListNode RemoveElements(ListNode head, int val)
        {
            // 6 -> 3 -> 6 -> 4 -> 6 remove 6
            if (head == null)
            {
                return null;
            }

            ListNode root = head;

            while (head != null)
            {
                if (head.val == val)
                {
                    head = head.next;
                    root = head;
                }
                else if ( head.next != null && head.next.val == val)
                {
                    if (head.next.next == null)
                    {
                        head.next = null;
                    }
                    else
                    {
                        head.next = head.next.next;
                    }
                }
                else
                {
                    head = head.next;
                }
            }
            return root;

        }

        public static ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null)
            {
                return null;
            }
            ListNode root = head;
            while (head.next != null)
            {
                if (head.val == head.next.val)
                {                    
                    head.next = head.next.next;
                }
                else
                {
                    head = head.next;
                }
            }
            return root;
        }

        private static int isSmart(int num)
        {
            int c = 1;
            int n = 1;
            while (n<num)
            {
                n = n + c;
                c++;
            }
            if (n == num) return 1;
            else return 0;
        }

        public static void ReorderList(ListNode head)
        {
            if (head == null) return;
            ListNode sp = head;
            ListNode fp = head.next;

            // find the middle
            while (fp != null && fp.next != null)
            {
                sp = sp.next;
                fp = fp.next.next;
            }

            // pointer to second half of linked list
            ListNode second = sp.next;

            // break the link from first and second half of linkedlist
            sp.next = null;

            // reverse the second half of linked list
            ListNode prev = null;

            while (second != null)
            {
                ListNode temp = second.next;
                second.next = prev;
                prev = second;
                second = temp;
            }


            ListNode first = head; // root of first half
            second = prev; // root of second half

            // start creating link - 1 from first half and another form second half
            while (second != null)
            {
                ListNode temp1 = first.next;
                ListNode temp2 = second.next;

                first.next = second;
                second.next = temp1;

                first = temp1;
                second = temp2;
            }
        }

        public static void ReorderListMy(ListNode head)
        {
            ListNode original = head;
            ListNode reformLink = original;
            ListNode reformLinkroot = reformLink;
            // var reverseNode = ReverseList(head);

            ListNode Prev = null;
            ListNode curr = reformLink;
            while (curr != null)
            {
                ListNode nextTemp = null;
                if (curr.next != null)
                {
                    nextTemp = curr.next;
                }
                curr.next = Prev;
                Prev = curr;
                curr = nextTemp;
            }

            var reverseNode = Prev;

            ListNode root = reverseNode;
            ListNode retRoot = root;
            ListNode retHeadRoot = retRoot;

            int c = 0;
            while (root != null)
            {
                c++;
                root = root.next;
            }
            
            int l = 0;
            while (l < c/2)
            {
                l++;
                ListNode fstTmp = retRoot.next;
                retRoot.next = reverseNode; // 1-5
                reverseNode.next = fstTmp; // 5-2

                reverseNode = reverseNode.next;
                retRoot = fstTmp;
            }
            
        }
        public static ListNode RemoveElements1(ListNode head, int val)
        {
            if (head == null)
            {
                return null;
            }
            ListNode reformLink = head;
            ListNode reformLinkroot = reformLink;

            while (head.next != null)
            {
                if (head.next.val != val)
                {
                    reformLink.next = head.next;
                    reformLink = reformLink.next;
                }
                head = head.next;
            }

            if (head.val == val)
            {
                reformLink.next = null;
            }

            if (reformLinkroot.val == val)
            {
               return reformLinkroot.next;
            }
            else
            {
                return reformLinkroot;
            }

        }

        public static ListNode DeleteMiddle(ListNode head)
        {
            ListNode root = head;
            ListNode reformLink = head;
            ListNode reformLinkroot = reformLink;

            int count = 0;
            List<int> values = new List<int>();
            while (head != null)
            {
                count++;
                values.Add(head.val);
                head = head.next;
            }
            if (count == 1)
            {
                return null;
            }
            int mid = count / 2;
            count = 1;
            while (root != null)
            {
                if (count != mid)
                {
                    reformLink.next = root.next;
                    reformLink = reformLink.next;
                }
                count++;
                root = root.next;
            }

            return reformLinkroot;
        }

        public static ListNode ReverseList2(ListNode head)
        {
            // 1 -> 2 -> 3
            ListNode Prev = null;
            ListNode curr = head;
            while (curr != null)
            {
                ListNode nextTemp = null;
                if (curr.next != null)
                {
                    nextTemp = curr.next; // 2 store at temp
                }
                curr.next = Prev; // 1 <- 2
                Prev = curr; // 1
                curr = nextTemp; // curr restore from temp 2 -> 3
            }
            return Prev;
        }


        public static ListNode ReverseList1(ListNode head)
        {
            List<int> fList = new List<int>();
            while (head != null)
            {
                fList.Add(head.val);
                head = head.next;
            }


            ListNode root = new ListNode(fList.LastOrDefault());
            head = root;

            for (int i = fList.Count-2; i >=0 ; i--)
            {
                ListNode l = new ListNode(fList[i]);
                head.next = l;
                head = l;
            }
            return root;
        }


    }

    public class CellLocatorSheet
    {
        public string DrugName { get; set; }
        public string LabelName { get; set; }
        public string NDC { get; set; }
        public double? Height { get; set; }
        public string Width { get; set; }
        public int? Baffle { get; set; }
        public int? Pressure { get; set; }
        public int? ThirtyDramCapacity { get; set; }
        public string Cell { get; set; }
        public string CellType { get; set; }
        public int? MaxCapacity { get; set; }
        public int? SuperCellMaxCapacity { get; set; }
        public bool S { get; set; } = false;
    }

    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
          this.val = val;
          this.left = left;
          this.right = right;
      }
 }       

    public class MyHashMap
    {

        List<MyNode>[] arr = null;
        int k = 9973;
        public MyHashMap()
        {
            arr = new List<MyNode>[k];
        }

        public void Put(int key, int value)
        {
            int index = key % k;

            if (arr[index] == null)
            {
                arr[index] = new List<MyNode>();
                arr[index].Add(new MyNode(key, value));
                return;
            }
            for (int i = 0; i < arr[index].Count; i++)
            {
                if (arr[index][i].key == key)
                {
                    arr[index][i].val = value;
                    return;
                }
            }
            arr[index].Add(new MyNode(key, value));
        }

        public int Get(int key)
        {
            int index = key % k;
            if (arr[index] == null) return -1;

            for (int i = 0; i < arr[index].Count; i++)
            {
                if (arr[index][i].key == key)
                {
                    return arr[index][i].val;
                }
            }
            return -1;
        }

        public void Remove(int key)
        {
            int index = key % k;
            if (arr[index] == null) return;

            for (int i = 0; i < arr[index].Count; i++)
            {
                if (arr[index][i].key == key)
                {
                    arr[index].RemoveAt(i);
                    return;
                }
            }

        }
    }

    public class MyNode
    {
        internal int key;
        internal int val;
        public MyNode(int k, int v)
        {
            key = k;
            val = v;
        }

    }



   
}
