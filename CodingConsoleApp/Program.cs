using Lucene.Net.Support;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingConsoleApp
{
    class Program
    {

        /// ////////////////////////////////////////// Ether //////////////////////////////////////////////////////////////

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




        /// ///////////////////////////////////////// MUKTA ///////////////////////////////////////////////////////////////
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


        public static bool IsAnagram(string s, string t)
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

        public static int largestAdjacentSum(int[] a)
        {
            int maxSum = Int32.MinValue;
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

        static int matchPattern(int[] a, int len, int[] pattern, int patternLen)
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


        static int isCubePowerful(int n)
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

        static int decodeArray(int[] a)
        {
            string n = "";
            for (int i = 1; i < a.Length; i++)
            {
                int val = Math.Abs(a[i - 1] - a[i]);
                n += val.ToString();
            }
            return Convert.ToInt32(n);
        }

        static int decodeArray1(int[] a)
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

        static int isZeroPlentiful(int[] a)
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

                if (count == 4)
                    ret++;

            }
            return ret;
        }
       static int[] encodeArray(int n)
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
        static int isSystematicallyIncreasing(int[] a)
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


        static int isFactorialPrime(int n)
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
        static int largestDifferenceOfEvens(int[] a)
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
                return 0;
            }

            return evenList.Max() - evenList.Min();
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
            if (CheckHodder(n)&& IsPrime(n))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        static int areAnagrams(char[] a1, char[] a2)
        {
            return 0;
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

                #region remainingCells

                remainingCells = Max2FullCellLocation().Except(superCell).ToList();

                List<string> exceptList = new List<string>();
                List<string> newAssignedSupperOrder = new List<string>();

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


        public static int[] computeHMS(int seconds)
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

        public static int isMartian(int[] a)
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

            for (int i = 0; i < a.Length; i = i + 2)
            {
                r[k] = a[i] + a[i + 1];
                k += 1;
            }

            return r;

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

        public static bool pSquare(int n)
        {
            if (n < 0) return false;
            for (int i = 0; i < n / 2; i++)
            {
                if (i * i == n) return true;
            }
            return false;
        }

        public static int loopSum(int[] a, int n)
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
                val += a[i] * pow(i, x);  // a[2] * x * x;
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
        public static int isLayered(int[] a)
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
                else if ((pCount > 0) && (fCount == 0) && (a[i] == 0)) zCount++;
                else if ((pCount > 0) && (zCount > 0) && (a[i] != 0)) fCount++;
                else return 0;
            }

            if ((pCount == fCount) && (zCount > 2)) return 1;
            else return 0;
        }

        public static int isConsectiveFactored(int n)
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

        static void Main(string[] args)
        {

            //Console.WriteLine(isConsectiveFactored(2));
            //Console.WriteLine(isHollow(new int[] {2,0,1,0,0,0,2,2,2 }));


            //Console.WriteLine(eval(2.0,new int[] { 4, 0, 9 }));
            //Console.WriteLine(loopSum(new int[] { 3 }, 10));

            //Console.WriteLine(pairwiseSum(new int[] { 2, 1, 18, -5, -5, -15, 0, 0, 1, -1 } ));
            //Console.WriteLine(pairwiseSum(new int[] { 2, 1, 18 } ));


            //Console.WriteLine(is121Array1(new int[] { 1, 1, 2, 2, 2, 1, 1 }));
            //Console.WriteLine(is121Array1(new int[] { 1, 1, 2, 2, 2, 1, 1, 1 }));
            //Console.WriteLine(is121Array1(new int[] { 1, 1, 1, 2, 2, 2, 1, 1 }));
            //Console.WriteLine(is121Array1(new int[] { 1, 1, 1, 2, 2, 2, 1, 1, 1, 3 }));
            //Console.WriteLine(is121Array1(new int[] { 1, 1, 1, 2, 2, 2, 1, 1, 1, 2, 2 }));
            //Console.WriteLine(is121Array1(new int[] { 1, 1, 1, 1, 1, 1 }));



            int[] nums1 = { 1, 2 };
            int[] a = { -18, 1, 2, 3, 4, 5 };
            int[] b = { 1, 2, 3, 4, 5 };
            //doIntegerBasedRounding(b, 3);
            int[] c = { -1, 0, 1,1 };

            //int r = decodeArray1(c);


            //computeHMS(3735);
            int[] d = {1, 2, 1, 2, 1, 2, 1, 2,1};
            //Console.WriteLine(isMartian(d));

            int[] e = {  };
            //Console.WriteLine(isPairedN(e,0));
            int[] f = { 2 };
            //Console.WriteLine(isNPrimeable(f, 1));


            //  S, SL, L



            // Max2CellCalculationNew(1, 27, 27, 146, 1);  // custom ok

            //Max2CellCalculationNew(1, 27, 0, 0, 3); // full locking



            // Max2CellCalculationNew(1, 23, 0, 0, 1);  // standard


            Max2CellCalculationNew(1, 44, 0, 0, 1); // 66 , 22

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

            //Console.WriteLine(BalancedStringSplit(""));

            // Console.WriteLine(MaxNumberOfBalloons(""));

            int[] n = { 1, 1, 10, 4, 4, 3 };
            int[] p = { 1, 4, 3 };

           // Console.WriteLine(matchPattern(n, 5, p, 2));

            //Console.WriteLine(isSequencedArray(new int[] { 1, 2, 3, 4, 5 }, 1, 5));
            //Console.WriteLine(isSequencedArray(new int[] { 1, 3, 4, 2, 5 }, 1, 5));
            //Console.WriteLine(isSequencedArray(new int[] { -5, -5, -4, -4, -4, -3, -3, -2, -2, -2 }, -5, -2));
            //Console.WriteLine(isSequencedArray(new int[] { 0, 1, 2, 3, 4, 5 }, 1, 5));
            //Console.WriteLine(isSequencedArray(new int[] { 1, 2, 3, 4 }, 1, 5));
            //Console.WriteLine(isSequencedArray(new int[] { 5, 4, 3, 2, 1 }, 1, 5));

            //Console.WriteLine(checkConcatenatedSum(2997, 3));
            //Console.WriteLine(FindMedianSortedArrays(nums1, nums2));
            //CellCalculation(11,0,0);
            // CellCalculationCustom(6, -10, 15, "C");
            //NewCellCalculation(2,0,0);
            //Max2CellCalculationNew(1, 12, 5, 12); // 200 - 


            #region Linked List

            //ListNode one = new ListNode(1);
            //ListNode two = new ListNode(2);
            //ListNode three = new ListNode(3);
            //one.next = two;
            //two.next = three;
            //ReverseList(one);


            ListNode one = new ListNode(1);
            ListNode two = new ListNode(2);
            ListNode three = new ListNode(3);
            ListNode four = new ListNode(4);
            one.next = two;
            two.next = three;
            three.next = four;
            //four.next = one;
           // Console.WriteLine(HasCycle(one));
           

             //DeleteMiddle(one);
             //ReorderList(one);

            #endregion


             //........................Tree...................

             //#region Tree
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

             //#endregion
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
        public static ListNode RemoveElements(ListNode head, int val)
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

        public static ListNode ReverseList(ListNode head)
        {
            ListNode Prev = null;
            ListNode curr = head;
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
