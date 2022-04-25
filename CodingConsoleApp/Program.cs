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
                n = - n;
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
            if ((first == null)||(second == null))     return null;            

            int l1 = first.Length;
            int l2 = second.Length;   
            
            if ( (l1== 0 ) || (l2 == 0)) return new int[0];
            

            int[] a;
            if (l1 > l2)
                a = new int[l2];
            else
                a = new int[l1];

            int k = 0;

            for (int i = 0; i< l1; i++) {
                for (int j = 0; j < l2; j++) {
                      if(first[i]== second[j])
                            {
                                a[k] = first[i];
                                k++;
                            }
                }            
            }

            int[] retArr = new int[k];
            for(int i = 0; i< k; i++)
            {
                retArr[i] = a[i];
            }
            return retArr;
        }

        static int POE(int [] a)
        {
            if (a == null) { return -1; }
            if (a.Length < 3 ) { return -1; }
            int firstHalf = a[0];
            int total = a.Sum();

            for (int i = 1; i< a.Length -1; i++)
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
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                    return false;
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


        private static int isDigitIncreasingShibashis(int n)
        {
            int len = n.ToString().Length;
            int res = 0;
            int _return = 0;
            if (len == 1)
            {
                for (int i = 1; i <= 9; i++)
                {
                    res = i;
                    if (res == n)
                    {
                        _return = 1;
                        break;
                    }
                }
            }
            else if (len == 2)
            {
                for (int i = 1; i <= 9; i++)
                {
                    res = i + int.Parse(i.ToString() + i.ToString());
                    if (res == n)
                    {
                        _return = 1;
                        break;
                    }
                }

            }
            else if (len == 3)
            {
                for (int i = 1; i <= 9; i++)
                {
                    res = i + int.Parse(i.ToString() + i.ToString())
                    + int.Parse(i.ToString() + i.ToString() + i.ToString());
                    if (res == n)
                    {
                        _return = 1;
                        break;
                    }
                }
            }
            else if (len == 4)
            {
                for (int i = 1; i <= 9; i++)
                {
                    res = i + int.Parse(i.ToString() + i.ToString())
                    + int.Parse(i.ToString() + i.ToString() + i.ToString())
                    + int.Parse(i.ToString() + i.ToString() + i.ToString() + i.ToString());
                    if (res == n)
                    {
                        _return = 1;
                        break;
                    }
                }
            }
            else
            {
                _return = 0;
            }
            return _return;
        }

        static int hasNValue1(int[]a, int n)
        {
            int[] b = new int[n];
            b[0] = a[0];
            int k = 1;

            for (int i = 1; i< a.Length; i++)
            {
                bool found = false;

                for (int j = 0; j< k; j++)
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

            for (int i = 0; i< a.Length; i++)
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

            foreach(int k in myDic.Keys)
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
                    for(int j = 0; j< l2.Count - 1; j++)
                    {
                        if (l2[j] + 1 != l2[j+1])
                        {
                            return 0;
                        }
                    }
                }
                else if(k == 1)
                {
                    List<int> l1 = myDic[1];
                    if(l1.Count % 2 != 0)
                    {
                        return 0;
                    }
                    else
                    {
                        int fstHalf = l1.Count / 2;
                        if ((l1[fstHalf] - l1[fstHalf-1]) <= 1)
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

            if((a == null ) || (a.Length < 3))
            {
                return 0;
            }             

            for (int i = 0; i< a.Length - 2 ; i += 3)
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

        static int equivalantArray(int[]a1, int[] a2)
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
            for (int i = 0; i< count; i ++)
            {
                ret[i] = inter[i];
            }

            return ret;
        }

        public static int[] Intersect(int[] nums1, int[] nums2)
        {
            
           if(nums1.Length > nums2.Length)
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
            for (int i = 1; i<= n; i++)
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
                for (int s = 0; s< space; s++)
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
            int[,] a = new int[n,n];

            a[0 , 0] = 1;

            for (int i=1; i<n; i++)
            {
                a[i , 0] = 1;

                for (int j = 1; j<i; j++ )
                {
                    a[i,j] = a[i - 1 , j - 1] + a[i - 1 , j];
                }

                a[i,i] = 1;
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
            for (int i = 0; i< triangle.Count; i++)
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
            for (int i = l-1 ; i > 0; i--)
            {
                for (int j = 0; j < triangle[i].Length -1 ; j++)
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
            for (int i = 0; i<nums.Length; i++)
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
            for (int i = 0; i< nums.Length; i++)
            {
                if (nums[i] == one) {
                    nums[i] = int.MinValue;
                }
            }
            return (nums , one);
        }
        public static int ThirdMax(int[] nums)
        {
            int fstMax = ThirdMaxHelper(nums).Item2;
            int sndMax = ThirdMaxHelper(nums).Item2;
            int trdMax = ThirdMaxHelper(nums).Item2;

            if (nums.Length < 3)
                return fstMax;
            else
                return  trdMax >= int.MinValue ? trdMax : fstMax;
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
            for (int i =0; i<dp.Length; i++) {
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
            int i = nums.Length-1;
            for (int j = nums.Length - 1; j >= 0; j--) // 0,1,0,3,2
            {
                if ((nums[j] != 0) )
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
                if (previous == mid) {
                    if(target > nums[mid])
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

            for (int i = 1; i< nums.Length; i++) {

                cursum += nums[i];
                cursum = Math.Max(cursum, nums[i]);
                maxsum = Math.Max(maxsum,cursum);
            }
            return maxsum;
        }

        public static int[] PlusOne1(int[] digits)
        {
            string s = "";
            for (int i = 0; i< digits.Length; i++)
            {
                s += digits[i].ToString();
            }

            int d = Convert.ToInt32(s) + 1;
            s = d.ToString();
            int[] r = new int[s.Length];

            int k = r.Length - 1;

            while(d > 0)
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

                for (int j = 0; j < m ; j++)
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
                if ( d[k] > m)
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
            Dictionary<int,int> d = new Dictionary<int,int>();
            

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
            int k = col-1;

            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    if (r == c)
                    {
                        d1 += mat[r,c];
                    }
                }

                if (r != k)
                {
                    d2 += mat[r,k];
                }

                k--;
            }
            return d1 + d2;
        }

        public static int[,] Pascal(int n)
        {
            int[,] m = new int[n, n];
            for (int r= 0; r< n; r++) {
                m[r, 0] = 1;
                m[r, r] = 1;

                for (int c = 1; c< r ; c++) {
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
                if (h.Keys.Contains(k))
                {
                    return false;
                }
                if ( (d[k] != h[k]) )
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
            

            foreach (char c in s) {
                if (mapping.Keys.Contains(c)) {
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
                int mid = (l + h ) / 2;
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
                for(int j = 0; j< s.Length; j++)
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
            for (int l = 0; l<j; l++) {
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

            for (int k = i; k< arr1.Length; k++) {
                for (int l = k+1; l< arr1.Length; l++) {
                    if (arr1[l] < arr1[k]) {
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
                if (d.Keys.Contains(k+1)) {
                    res = Math.Max(res, d[k] + d[k+1]);
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

            for (int i = 0; i< s.Length; i++) {
                if (! d.Keys.Contains(s[i].ToString())) {
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
                    if (matrix[r][c] == 0) {
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
            Array.Copy( arr, temp,arr.Length);

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
            for (int i = 0; i < nums.Length-k+1; i++) {
                int a = 0;
                for (int j = i; j< i + k; j++) {
                    a += nums[j];
                }
                double d = (a * 1.0 )/ k;
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
                if (n >= max1) {
                    max3 = max2;
                    max2 = max1;
                    max1 = n;
                } else if (n >= max2) {
                    max3 = max2;
                    max2 = n;
                }else if (n >= max3)
                {
                    max3 = n;
                }


                if (n <= min1) {
                    min2 = min1;
                    min1 = n;
                } else if (n<=min2) {
                    min2 = n;
                }
            }
            return Math.Max(min1*min2*max1 , max3 * max2 * max1);
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
                    if (matrix[r][c] == minRow) {

                        int maxCol = int.MinValue;
                        for (int i = 0; i< row; i++) {
                            if (matrix[i][c] > maxCol) {
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
            int p =0;
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
            while(n > 2)
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

        public static void Floyed(int n) {
            int x = 1;
            for (int r = 0; r< n; r++) {
                for (int c = 0; c < r+1 ; c++)
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
                int[] a = new int[r+1];

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

        public static bool isValidSubsequence2(int[] array, int[] sequence) {
            int idxa = 0;
            int idxs = 0;
            while (idxa < array.Length && idxs <sequence.Length)
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

            while (i< words.Length)
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

            if(sList1.Length > sList2.Length)
                l = CommonDict(d1,d2);
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

       

        public static List<int> inorderTraversal(TreeNode root, List<int> res)
        {
            if (root != null)
            {
                inorderTraversal(root.left, res);
                res.Add(root.val);
                inorderTraversal(root.right, res);
            }
            return res;
        }

        private static Tuple<string[], string[], string[]> CellCalculation(int id)
        {
            string[] aToz = new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V" };
            string[] allCell;   
            string[] superCell;  
            string[] lockingCell;
            string[] superLockingCell;
            string[] stdCell2;
            string[] stdCell;
            string[] stdLockingCell;

            if (id == 3)// for max2 154/22/2
            {
                allCell = new string[aToz.Length * 8 + 2]; // 176 + 2 = 178
                superCell = new string[aToz.Length]; //22 
                lockingCell = new string[aToz.Length]; // 22

                int c = 0; int l = 0; int s = 0;
                foreach (var item in aToz)
                {
                    for (int i = 1; i < 10; i++)
                    {
                        if (i != 3)
                        {
                            allCell[c] = item + i.ToString();
                            c++;
                        }
                        if (i == 4)
                        {
                            superCell[s] = item + i.ToString();
                            s++;
                        }
                        if (i == 9)
                        {
                            lockingCell[l] = item + i.ToString();
                            l++;
                        }
                    }
                }
                allCell[176] = "Y";
                allCell[177] = "Z";

                stdCell = allCell.Except(superCell).Except(lockingCell).ToArray(); // 154 for max2 154/22/2
                return new Tuple<string[], string[], string[]>(superCell, lockingCell, stdCell);
            }
            else if (id == 1)// for max2 110/44/2  su
            {
                allCell = new string[aToz.Length * 7 + 2]; // 22 * 7 + 2 = 154 + 2 = 156
                superCell = new string[aToz.Length * 2]; //44 
                lockingCell = new string[aToz.Length]; // 22

                int c = 0; int l = 0; int s = 0;
                foreach (var item in aToz)
                {
                    for (int i = 1; i < 10; i++)
                    {
                        if ((i != 3) && (i != 5))
                        {
                            allCell[c] = item + i.ToString();
                            c++;
                        }

                        if ((i == 4) || (i == 6))
                        {
                            superCell[s] = item + i.ToString();
                            s++;
                        }

                        if (i == 9)
                        {
                            lockingCell[l] = item + i.ToString();
                            l++;
                        }
                    }
                }


                allCell[154] = "Y";
                allCell[155] = "Z";

                stdCell = allCell.Except(superCell).Except(lockingCell).ToArray(); // 154 for max2 154/22/2
                return new Tuple<string[], string[], string[]>(superCell, lockingCell, stdCell);
            }

            else if (id == 2)// for max2 132/33/2  
            {
                string[] aTok = new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K" };
                string[] lToV = new[] {  "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V" };

                allCell = new string[167]; // 176 - 11 = 165 + 2 = 167

                superCell = new string[33]; //33

                lockingCell = new string[22]; // 22

                // 167 - 33 - 22 = 112 std cell

                int c = 0; int l = 0; int s = 0;
                foreach (var item in aToz)
                {
                    for (int i = 1; i < 10; i++)
                    {

                        if (   (i != 3)   &&    (i != 5)  )  // 3 & 5 exclude
                        {
                            allCell[c] = item + i.ToString();
                            c++;
                        } 

                        if (i == 4)   
                        {
                            superCell[s] = item + i.ToString();
                            s++;
                        }

                        if ((i == 6) && (aTok.Contains(item)))   // 6A to K include
                        {
                            superCell[s] = item + i.ToString();
                            s++;
                        }

                        if (i == 9)
                        {
                            lockingCell[l] = item + i.ToString();
                            l++;
                        }
                    }
                }

                foreach (var item in lToV)
                {
                    for (int i = 1; i < 10; i++)
                    {
                        if ((i == 5) && (lToV.Contains(item)))   // 5 L to V include
                        {
                            allCell[c] = item + i.ToString();
                            c++;
                        }
                    }
                }             


                allCell[165] = "Y";
                allCell[166] = "Z";

               stdCell = allCell.Except(superCell).Except(lockingCell).ToArray(); // 154 for max2 154/22/2

               return new Tuple<string[], string[], string[]>(superCell, lockingCell, stdCell);
            }

            else if (id == 4)// for max2 154/22/2  Full Manifold Max 2​
            {
                allCell = new string[aToz.Length * 8 + 2]; // 176 + 2 = 178
                superCell = new string[aToz.Length]; //22 
                lockingCell = new string[aToz.Length]; // 22

                int c = 0; int l = 0; int s = 0;
                foreach (var item in aToz)
                {
                    for (int i = 1; i < 10; i++)
                    {
                        if (i != 2)
                        {
                            allCell[c] = item + i.ToString();
                            c++;
                        }
                        if (i == 1)
                        {
                            superCell[s] = item + i.ToString();
                            s++;
                        }
                        if (i == 9)
                        {
                            lockingCell[l] = item + i.ToString();
                            l++;
                        }
                    }
                }
                allCell[176] = "Y";
                allCell[177] = "Z";

               stdCell = allCell.Except(superCell).Except(lockingCell).ToArray(); // 154 for max2 154/22/2
               return new Tuple<string[], string[], string[]>(superCell, lockingCell, stdCell);
            }
            else if (id == 5)// for max2 110/44/2  Full Manifold Max 2
            {
                allCell = new string[aToz.Length * 7 + 2]; // 22 * 7 + 2 = 154 + 2 = 156
                superCell = new string[aToz.Length * 2]; //44 
                lockingCell = new string[aToz.Length]; // 22

                int c = 0; int l = 0; int s = 0;
                foreach (var item in aToz)
                {
                    for (int i = 1; i < 10; i++)
                    {
                        if ((i != 2) && (i != 4))
                        {
                            allCell[c] = item + i.ToString();
                            c++;
                        }

                        if ((i == 1) || (i == 3))
                        {
                            superCell[s] = item + i.ToString();
                            s++;
                        }

                        if (i == 9)
                        {
                            lockingCell[l] = item + i.ToString();
                            l++;
                        }
                    }
                }


                allCell[154] = "Y";
                allCell[155] = "Z";

                stdCell = allCell.Except(superCell).Except(lockingCell).ToArray(); // 154 for max2 154/22/2

                return new Tuple<string[], string[], string[]>(superCell, lockingCell, stdCell);
            }

            else if (id == 6)// for max2 132/33/2   Full Manifold Max 2
            {
                string[] aTok = new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K" };
                string[] lToV = new[] { "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V" };

                allCell = new string[167]; // 176 - 11 = 165 + 2 = 167

                superCell = new string[33]; //33

                lockingCell = new string[22]; // 22

                // 167 - 33 - 22 = 112 std cell

                int c = 0; int l = 0; int s = 0;
                foreach (var item in aToz)
                {
                    for (int i = 1; i < 10; i++)
                    {

                        if ((i != 2) && (i != 4))  //  2 & 4 exclude
                        {
                            allCell[c] = item + i.ToString();
                            c++;
                        }

                        if (i == 1)
                        {
                            superCell[s] = item + i.ToString();
                            s++;
                        }

                        if ((i == 3) && (aTok.Contains(item)))   // 3 A- K include
                        {
                            superCell[s] = item + i.ToString();
                            s++;
                        }

                        if (i == 9)
                        {
                            lockingCell[l] = item + i.ToString();
                            l++;
                        }
                    }
                }

                foreach (var item in lToV)
                {
                    for (int i = 1; i < 10; i++)
                    {
                        if ((i == 4) && (lToV.Contains(item)))   // 4 L to V include
                        {
                            allCell[c] = item + i.ToString();
                            c++;
                        }
                    }
                }


                allCell[165] = "Y";
                allCell[166] = "Z";

                stdCell = allCell.Except(superCell).Except(lockingCell).ToArray(); // 154 for max2 154/22/2
                return new Tuple<string[], string[], string[]>(superCell, lockingCell, stdCell);
            }


            else if (id == 7)// for max2 176/11/2   Full Manifold Max 2
            {
                string[] aTok = new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K" };
                string[] lToV = new[] { "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V" };

                allCell = new string[189]; // 

                superCell = new string[11]; //11

                lockingCell = new string[22]; // 22

                // 156 std cell 

                int c = 0; int l = 0; int s = 0;
                foreach (var item in aToz)
                {
                    for (int i = 1; i < 10; i++)
                    {

                        if ((i != 2) )  //  2  exclude
                        {
                            allCell[c] = item + i.ToString();
                            c++;
                        }                       

                        if ((i == 1) && (aTok.Contains(item)))   // 1 A- K include
                        {
                            superCell[s] = item + i.ToString();
                            s++;
                        }

                        if (i == 9)
                        {
                            lockingCell[l] = item + i.ToString();
                            l++;
                        }
                    }
                }

                foreach (var item in lToV)
                {
                    for (int i = 1; i < 10; i++)
                    {
                        if ((i == 2) && (lToV.Contains(item)))   // 2 L to V include
                        {
                            allCell[c] = item + i.ToString();
                            c++;
                        }
                    }
                }


                allCell[187] = "Y";
                allCell[188] = "Z";

                stdCell = allCell.Except(superCell).Except(lockingCell).ToArray(); // 154 for max2 154/22/2
                return new Tuple<string[], string[], string[]>(superCell, lockingCell, stdCell);
            }
            else if (id == 8)// for max2 198/0/2  Full Manifold Max 2​
            {
                allCell = new string[aToz.Length * 9 + 2]; // 176 + 2 = 178
                superCell = new string[0]; //22 
                lockingCell = new string[aToz.Length]; // 22

                int c = 0; int l = 0; int s = 0;
                foreach (var item in aToz)
                {
                    for (int i = 1; i < 10; i++)
                    {
                        allCell[c] = item + i.ToString();
                        c++;

                        if (i == 9)
                        {
                            lockingCell[l] = item + i.ToString();
                            l++;
                        }
                    }
                }
                allCell[198] = "Y";
                allCell[199] = "Z";

                stdCell = allCell.Except(superCell).Except(lockingCell).ToArray(); // 154 for max2 154/22/2
                return new Tuple<string[], string[], string[]>(superCell, lockingCell, stdCell);
            }
            else if (id == 9)// for max2 128/36   Full Manifold Max 2   128 stdLocking cell , 36 superLockingCell
            {
                string[] aToN = new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N" };
                string[] oToV = new[] {  "O", "P", "Q", "R", "S", "T", "U", "V" };

                allCell = new string[164]; 
                superLockingCell = new string[36];

                // 167 - 33 - 22 = 112 std cell

                int c = 0; int l = 0; int s = 0;
                foreach (var item in aToz)
                {
                    for (int i = 1; i < 10; i++)
                    {

                        if ((i != 2) && (i != 4))  //  2 & 4 exclude
                        {
                            allCell[c] = item + i.ToString();
                            c++;
                        }

                        if (i == 1)
                        {
                            superLockingCell[s] = item + i.ToString();
                            s++;
                        }

                        if ((i == 3) && (aToN.Contains(item)))   // 3 A- K include
                        {
                            superLockingCell[s] = item + i.ToString();
                            s++;
                        }
                        
                    }
                }

                foreach (var item in oToV)
                {
                    for (int i = 1; i < 10; i++)
                    {
                        if ((i == 4) && (oToV.Contains(item)))   // 4 O to V include
                        {
                            allCell[c] = item + i.ToString();
                            c++;
                        }
                    }
                }

                allCell[162] = "Y";
                allCell[163] = "Z";

                stdLockingCell = allCell.Except(superLockingCell).ToArray(); // 154 for max2 154/22/2

                return new Tuple<string[], string[], string[]>(superLockingCell, stdLockingCell, stdLockingCell);
            }
            else if (id == 10)// for max2 110/45  Max 2 – Kroger Std
            {
                allCell = new string[154]; // 110 + 45 =155
                
                superLockingCell = new string[aToz.Length * 2 + 1];

                int c = 0; int l = 0; int s = 0;
                foreach (var item in aToz)
                {
                    for (int i = 1; i < 10; i++)
                    {
                        if ((i != 2) && (i != 3))
                        {
                            allCell[c] = item + i.ToString();
                            c++;
                        }
                        if ((i == 1) || (i == 4))
                        {
                            superLockingCell[s] = item + i.ToString();
                            s++;
                        }                        
                    }
                }
                superLockingCell[44] = "Y";

                stdLockingCell = allCell.Except(superLockingCell).ToArray(); // 154 for max2 154/22/2

                return new Tuple<string[], string[], string[]>(superLockingCell, stdLockingCell, stdLockingCell);
            }
            else if (id == 11)// for 22 Std  & 88 Super Cells    Max 2 – Lite​
            {
                allCell = new string[aToz.Length * 5]; // 22 * 5 = 110
                stdCell2 = new string[aToz.Length]; //22 

                int c = 0; int s = 0;
                foreach (var item in aToz)
                {
                    for (int i = 1; i < 10; i++)
                    {
                        if ((i != 1) && (i != 3) && (i != 6) && (i != 8)) // 1
                        {
                            allCell[c] = item + i.ToString();
                            c++;
                        }
                        if (i == 5)
                        {
                            stdCell2[s] = item + i.ToString();
                            s++;
                        }                        
                    }
                }

                string[] superCell2 = allCell.Except(stdCell2).ToArray(); // 154 for max2 154/22/2

                return new Tuple<string[], string[], string[]>(superCell2, stdCell2, stdCell2);
            }
            else
            {
                superCell = new string[0];
                lockingCell = new string[0];
                stdCell = new string[0];
                return new Tuple<string[], string[], string[]>(superCell, lockingCell, stdCell);

            }


        }

        private static Tuple<string[], string[], string[] , string[]> CellCalculationCustom(int id, int customSuperQuantity, int customStandardQuantity, string config)
        {
            string[] aToz = new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V" };
            string[] allCell;
            string[] superCell;
            string[] lockingCell;
            string[] superLockingCell;
            string[] stdCell2;
            string[] stdCell;
            string[] stdLockingCell;

            if (id == 3)// for max2 154/22/2
            {
                allCell = new string[aToz.Length * 8 + 2]; // 176 + 2 = 178
                superCell = new string[aToz.Length]; //22 
                lockingCell = new string[aToz.Length]; // 22 

                string all = "";
                int c = 0; int l = 0; int s = 0; int sl = 0;

                foreach (var item in aToz)
                {
                    for (int i = 1; i < 10; i++)
                    {
                        if (i != 3)
                        {
                            allCell[c] = item + i.ToString();

                            all += allCell[c].ToString();
                            c++;                           
                        }
                        //if (i == 4)
                        //{
                        //    superCell[s] = item + i.ToString();
                        //    s++;
                        //}
                        if (i == 9)
                        {
                            lockingCell[l] = item + i.ToString();
                            l++;
                        }

                    }
                }
                allCell[176] = "Y";
                allCell[177] = "Z";
                all += allCell[176].ToString();
                all += allCell[177].ToString();

                if (customSuperQuantity > 0)
                {
                    superLockingCell = new string[customSuperQuantity];                   
                    superCell = new string[aToz.Length - customSuperQuantity];
                    string[] firstArray; string[] secondArray;

                    if (customSuperQuantity == 5)
                    {

                        firstArray = new[] { "A", "B", "C", "D", "E" };
                        secondArray = new[] { "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V" };                     

                    }
                    else if (customSuperQuantity == 10)
                    {

                        firstArray = new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
                        secondArray = new[] { "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V" }; 

                    }
                    else if (customSuperQuantity == 15)
                    {
                        firstArray = new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O" };
                        secondArray = new[] { "P", "Q", "R", "S", "T", "U", "V" };

                    }
                    else
                    {
                        firstArray = new string[0];
                        secondArray = new string[0];
                    }

                    SuperQuantityCellCalulation(firstArray, secondArray, superLockingCell, superCell);

                    stdCell = allCell.Except(superCell).Except(lockingCell).Except(superLockingCell).ToArray();

                    return new Tuple<string[], string[], string[], string[]>(superCell, lockingCell,  superLockingCell, stdCell);
                }

                if (customStandardQuantity > 0)
                {

                    lockingCell = new string[aToz.Length + customStandardQuantity]; // 22 + 15
                    superLockingCell = new string[customStandardQuantity]; // always null
                    string[] fstArray ;

                    if (customStandardQuantity == 5)
                    {
                        fstArray = new[] { "A", "B", "C", "D", "E" };                       
                    }
                    else if (customStandardQuantity == 10)
                    {
                        fstArray = new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };   

                    }
                    else if (customStandardQuantity == 15)
                    {
                        fstArray = new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O" };
                    }
                    else
                    {
                            fstArray = new string[0];
                    }

                    StandardQuantityCellCalulation(fstArray, aToz, lockingCell, superCell);
                    stdCell = allCell.Except(superCell).Except(lockingCell).ToArray();

                    return new Tuple<string[], string[], string[], string[]>(superCell, lockingCell, superLockingCell, stdCell); // superLockingCell  null here
                }



                superCell = new string[0];
                lockingCell = new string[0];
                stdCell = new string[0];
                superLockingCell = new string[0];
                return new Tuple<string[], string[], string[], string[]>(superCell, lockingCell, superLockingCell, stdCell);

            }
            else if (id == 1)// for max2 110/44/2  su
            {
                allCell = new string[aToz.Length * 7 + 2]; // 22 * 7 + 2 = 154 + 2 = 156
                if (customSuperQuantity  > 0)
                {
                    superLockingCell = new string[customSuperQuantity];
                    lockingCell = new string[aToz.Length]; // 22
                    superCell = new string[aToz.Length * 2 - customSuperQuantity]; // 44 - (5/10/15)                    
                }
                else //  if (customStandardQuantity > 0)
                {
                    superLockingCell = new string[0];
                    lockingCell = new string[aToz.Length + customStandardQuantity]; // 22 + (5/10/15)
                    superCell = new string[aToz.Length * 2]; //44 
                }


                int c = 0; int l = 0; int s = 0;
                foreach (var item in aToz)
                {
                    for (int i = 1; i < 10; i++)
                    {
                        if ((i != 3) && (i != 5))
                        {
                            allCell[c] = item + i.ToString();
                            c++;
                        }

                        //if ((i == 4) || (i == 6))   // 44
                        //{
                        //    superCell[s] = item + i.ToString();
                        //    s++;
                        //}

                        if (i == 9)
                        {
                            lockingCell[l] = item + i.ToString();
                            l++;
                        }
                    }
                }


                allCell[154] = "Y";
                allCell[155] = "Z";

                if (customSuperQuantity > 0)
                {
                    string[] firstArray; string[] secondArray;

                    if (customSuperQuantity == 5)
                    {

                        firstArray = new[] { "A", "B", "C", "D", "E" };
                        secondArray = new[] { "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V" };

                    }
                    else if (customSuperQuantity == 10)
                    {

                        firstArray = new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
                        secondArray = new[] { "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V" };

                    }
                    else if (customSuperQuantity == 15)
                    {
                        firstArray = new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O" };
                        secondArray = new[] { "P", "Q", "R", "S", "T", "U", "V" };

                    }
                    else
                    {
                        firstArray = new string[0];
                        secondArray = new string[0];
                    }

                    SuperQuantityCellCalulationForOne(firstArray, secondArray, superLockingCell, superCell);

                    stdCell = allCell.Except(superCell).Except(lockingCell).Except(superLockingCell).ToArray();

                    return new Tuple<string[], string[], string[], string[]>(superCell, lockingCell, superLockingCell, stdCell);
                }

                if (customStandardQuantity > 0)
                {                   
                    string[] fstArray;

                    if (customStandardQuantity == 5)
                    {
                        fstArray = new[] { "A", "B", "C", "D", "E" };
                    }
                    else if (customStandardQuantity == 10)
                    {
                        fstArray = new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };

                    }
                    else if (customStandardQuantity == 15)
                    {
                        fstArray = new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O" };
                    }
                    else
                    {
                        fstArray = new string[0];
                    }

                    StandardQuantityCellCalulationForOne(fstArray, aToz, lockingCell, superCell);
                    stdCell = allCell.Except(superCell).Except(lockingCell).ToArray();

                    return new Tuple<string[], string[], string[], string[]>(superCell, lockingCell, superLockingCell, stdCell); // superLockingCell  null here
                }



                superCell = new string[0];
                lockingCell = new string[0];
                stdCell = new string[0];
                superLockingCell = new string[0];
                return new Tuple<string[], string[], string[], string[]>(superCell, lockingCell, superLockingCell, stdCell);
            }
            else if (id == 2)// for max2 132/33/2  
            {
                allCell = new string[167]; //  167
                superCell = new string[33]; //33
                lockingCell = new string[22]; // 22

                // 167 - 33 - 22 = 112 std cells              

                if (customSuperQuantity > 0)
                {
                    superLockingCell = new string[customSuperQuantity];
                    superCell = new string[aToz.Length * 2 - customSuperQuantity];
                    string[] firstArray; string[] secondArray;

                    stdCell = new[] { "A1","B1","C1","D1","E1","F1","G1","H1","I1","J1","K1","L1","M1","N1","O1","P1","Q1","R1","S1",
                                            "T1","U1","V1","A2","B2","C2","D2","E2","F2","G2","H2","I2","J2","K2","L2","M2","N2","O2","P2",
                                            "Q2","R2","S2","T2","U2","V2",
                                            "L5","M5","N5","O5","P5","Q5","R5","S5","T5","U5","V5",
                                            "L6","M6", "N6","O6","P6","Q6","R6","S6","T6","U6","V6",
                                            "A7","B7","C7","D7","E7","F7","G7","H7","I7","J7",  "K7","L7","M7","N7","O7","P7","Q7","R7","S7","T7","U7","V7",
                                            "A8","B8","C8","D8","E8","F8","G8", "H8","I8","J8","K8","L8","M8","N8","O8","P8","Q8", "R8","S8","T8","U8","V8"
                                            };


                    lockingCell = new[] { "A9","B9","C9","D9","E9","F9","G9","H9","I9","J9",
                                                 "K9","L9","M9","N9","O9","P9","Q9","R9","S9","T9","U9","V9" };

                    if (customSuperQuantity == 5)
                    {

                        superCell = new[] { "A4","B4","C4", "D4","E4","F4", "G4","H4","I4", "J4","K4", "L4", "M4", "N4","O4","P4", "Q4","R4","S4",
                                            "T4","U4","V4","A6","B6","C6","D6","E6","F6" };  // same as Standard

                        superLockingCell = new[] { "G6", "H6", "I6", "J6", "K6" };


                    }
                    else if (customSuperQuantity == 10)
                    {

                        // firstArray = new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
                        //secondArray = new[] { "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V" };


                        superCell = new[] { "A4","B4","C4", "D4","E4","F4", "G4","H4","I4", "J4","K4", "L4", "M4", "N4","O4","P4", "Q4","R4","S4",
                                            "T4","U4","V4","A6" };  // same as Standard

                        superLockingCell = new[] { "B6", "C6", "D6", "E6", "F6", "G6", "H6", "I6", "J6", "K6" };

                    }
                    else if (customSuperQuantity == 15)
                    {


                        superCell = new[] { "A4", "B4", "C4", "D4", "E4", "F4", "G4", "H4", "I4", "J4", "K4", "L4", "M4", "N4", "O4", "P4", "Q4", "R4" };  // same as Standard

                        superLockingCell = new[] { "S4", "T4", "U4", "V4", "A6", "B6", "C6", "D6", "E6", "F6", "G6", "H6", "I6", "J6", "K6" };

                    }
                    else
                    {
                        firstArray = new string[0];
                        secondArray = new string[0];
                    }

                    // SuperQuantityCellCalulationForTwo(firstArray, secondArray, superLockingCell, superCell);
                    // stdCell = allCell.Except(superCell).Except(lockingCell).Except(superLockingCell).ToArray();

                    return new Tuple<string[], string[], string[], string[]>(superCell, lockingCell, superLockingCell, stdCell);
                }

                if (customStandardQuantity > 0)
                {
                    superLockingCell = new string[0];
                    lockingCell = new string[aToz.Length + customStandardQuantity]; // 22 + 15                  

                    if (customStandardQuantity == 5)
                    {

                        stdCell = new[] { "A1","B1","C1","D1","E1","F1","G1","H1","I1","J1","K1","L1","M1","N1","O1","P1","Q1","R1","S1",
                                            "T1","U1","V1","A2","B2","C2","D2","E2","F2","G2","H2","I2","J2","K2","L2","M2","N2","O2","P2",
                                            "Q2","R2","S2","T2","U2","V2","L5","M5","N5","O5","P5","Q5","R5","S5","T5","U5","V5","L6","M6",
                                            "N6","O6","P6","Q6","R6","S6","T6","U6","V6","A7","B7","C7","D7","E7","F7","G7","H7","I7","J7",
                                            "K7","L7","M7","N7","O7","P7","Q7","R7","S7","T7","U7","V7","A8","B8","C8","D8","E8","F8","G8",
                                            "H8","I8","J8","K8","L8","M8","N8","O8","P8","Q8"
                                         };

                        superCell = new[] { "A4","B4","C4", "D4","E4","F4", "G4","H4","I4", "J4","K4", "L4", "M4", "N4","O4","P4", "Q4","R4","S4",
                                            "T4","U4","V4","A6","B6","C6","D6","E6","F6","G6","H6","I6", "J6","K6" };  // same as Standard

                        lockingCell = new[] { "R8","S8","T8","U8","V8","A9","B9","C9","D9","E9","F9","G9","H9","I9","J9",
                                                 "K9","L9","M9","N9","O9","P9","Q9","R9","S9","T9","U9","V9" };

                    }
                    else if (customStandardQuantity == 10)
                    {

                        stdCell = new[] { "A1","B1","C1","D1","E1","F1","G1","H1","I1","J1","K1","L1","M1","N1","O1","P1","Q1","R1","S1",
                                            "T1","U1","V1","A2","B2","C2","D2","E2","F2","G2","H2","I2","J2","K2","L2","M2","N2","O2","P2",
                                            "Q2","R2","S2","T2","U2","V2","L5","M5","N5","O5","P5","Q5","R5","S5","T5","U5","V5","L6","M6",
                                            "N6","O6","P6","Q6","R6","S6","T6","U6","V6","A7","B7","C7","D7","E7","F7","G7","H7","I7","J7",
                                            "K7","L7","M7","N7","O7","P7","Q7","R7","S7","T7","U7","V7","A8","B8","C8","D8","E8","F8","G8",
                                            "H8","I8","J8","K8","L8"
                                         };

                        superCell = new[] { "A4","B4","C4", "D4","E4","F4", "G4","H4","I4", "J4","K4", "L4", "M4", "N4","O4","P4", "Q4","R4","S4",
                                            "T4","U4","V4","A6","B6","C6","D6","E6","F6","G6","H6","I6", "J6","K6" };  // same as Standard

                        lockingCell = new[] {"M8", "N8", "O8", "P8", "Q8",  "R8","S8","T8","U8","V8","A9","B9","C9","D9","E9","F9","G9","H9","I9","J9",
                                                 "K9","L9","M9","N9","O9","P9","Q9","R9","S9","T9","U9","V9" };


                    }
                    else if (customStandardQuantity == 15)
                    {
                        stdCell = new[] { "A1","B1","C1","D1","E1","F1","G1","H1","I1","J1","K1","L1","M1","N1","O1","P1","Q1","R1","S1",
                                            "T1","U1","V1","A2","B2","C2","D2","E2","F2","G2","H2","I2","J2","K2","L2","M2","N2","O2","P2",
                                            "Q2","R2","S2","T2","U2","V2","L5","M5","N5","O5","P5","Q5","R5","S5","T5","U5","V5","L6","M6",
                                            "N6","O6","P6","Q6","R6","S6","T6","U6","V6","A7","B7","C7","D7","E7","F7","G7","H7","I7","J7",
                                            "K7","L7","M7","N7","O7","P7","Q7","R7","S7","T7","U7","V7","A8","B8","C8","D8","E8","F8","G8"

                                         };

                        superCell = new[] { "A4","B4","C4", "D4","E4","F4", "G4","H4","I4", "J4","K4", "L4", "M4", "N4","O4","P4", "Q4","R4","S4",
                                            "T4","U4","V4","A6","B6","C6","D6","E6","F6","G6","H6","I6", "J6","K6" };  // same as Standard

                        lockingCell = new[] {"H8","I8","J8","K8","L8","M8", "N8", "O8", "P8", "Q8",  "R8","S8","T8","U8","V8","A9","B9","C9","D9","E9","F9","G9","H9","I9","J9",
                                                 "K9","L9","M9","N9","O9","P9","Q9","R9","S9","T9","U9","V9" };

                    }
                    else
                    {
                        stdCell = new string[0];
                    }

                    //StandardQuantityCellCalulationForOne(fstArray, aToz, lockingCell, superCell);
                    // stdCell = allCell.Except(superCell).Except(lockingCell).ToArray();

                    return new Tuple<string[], string[], string[], string[]>(superCell, lockingCell, superLockingCell, stdCell); // superLockingCell  null here
                }



                superCell = new string[0];
                lockingCell = new string[0];
                stdCell = new string[0];
                superLockingCell = new string[0];
                return new Tuple<string[], string[], string[], string[]>(superCell, lockingCell, superLockingCell, stdCell);
            }
            else if (id == 4)// for max2 132/33/2  
            {
                allCell = new string[aToz.Length * 8 + 2]; // 176 + 2 = 178
                superCell = new string[aToz.Length]; //22 
                lockingCell = new string[aToz.Length]; // 22                           

                if (customSuperQuantity > 0)
                {
                    superLockingCell = new string[customSuperQuantity];
                    superCell = new string[aToz.Length * 2 - customSuperQuantity];
                    string[] firstArray; string[] secondArray;

                    stdCell = new[] {      "A1","B1","C1","D1","E1","F1","G1","H1","I1","J1","K1","L1","M1","N1","O1","P1","Q1","R1","S1","T1","U1","V1",
                                           "A2","B2","C2","D2","E2","F2","G2","H2","I2","J2","K2","L2","M2","N2","O2","P2","Q2","R2","S2","T2","U2","V2",                                         
                                           "A7","B7","C7","D7","E7","F7","G7","H7","I7","J7",  "K7","L7","M7","N7","O7","P7","Q7","R7","S7","T7","U7","V7",
                                           "A8","B8","C8","D8","E8","F8","G8", "H8","I8","J8","K8","L8","M8","N8","O8","P8","Q8", "R8","S8","T8","U8","V8"
                                            };


                    lockingCell = new[] { "A9","B9","C9","D9","E9","F9","G9","H9","I9","J9","K9","L9","M9","N9","O9","P9","Q9","R9","S9","T9","U9","V9" };

                    if (customSuperQuantity == 5)
                    {

                        superCell = new[] { "A4","B4","C4", "D4","E4","F4", "G4","H4","I4", "J4","K4", "L4", "M4", "N4","O4","P4", "Q4",
                                            "A6","B6","C6","D6","E6","F6", "G6", "H6", "I6", "J6", "K6","L6", "M6", "N6","O6","P6", "Q6" };  // same as Standard

                        superLockingCell = new[] {"R4","S4", "T4","U4", "V4" };


                    }
                    else if (customSuperQuantity == 10)
                    {

                        superCell = new[] { "A4","B4","C4", "D4","E4","F4", "G4","H4","I4", "J4","K4", "L4", 
                                            "A6","B6","C6","D6","E6","F6", "G6", "H6", "I6", "J6", "K6","L6", "M6", "N6","O6","P6", "Q6" };  // same as Standard

                        superLockingCell = new[] { "M4", "N4", "O4", "P4", "Q4", "R4", "S4", "T4", "U4", "V4" };

                    }
                    else if (customSuperQuantity == 15)
                    {


                        superCell = new[] { "A4","B4","C4", "D4","E4","F4", "G4",
                                            "A6","B6","C6","D6","E6","F6", "G6", "H6", "I6", "J6", "K6","L6", "M6", "N6","O6","P6", "Q6" };  // same as Standard

                        superLockingCell = new[] { "H4", "I4", "J4", "K4", "L4", "M4", "N4", "O4", "P4", "Q4", "R4", "S4", "T4", "U4", "V4" };

                    }
                    else
                    {
                        firstArray = new string[0];
                        secondArray = new string[0];
                    }

                    // SuperQuantityCellCalulationForTwo(firstArray, secondArray, superLockingCell, superCell);
                    // stdCell = allCell.Except(superCell).Except(lockingCell).Except(superLockingCell).ToArray();

                    return new Tuple<string[], string[], string[], string[]>(superCell, lockingCell, superLockingCell, stdCell);
                }

                if (customStandardQuantity > 0)
                {
                    superLockingCell = new string[0];
                    lockingCell = new string[aToz.Length + customStandardQuantity]; // 22 + 15

                    superCell = new[] { "A4","B4","C4", "D4","E4","F4", "G4","H4","I4", "J4","K4", "L4", "M4", "N4","O4","P4", "Q4","R4","S4", "T4","U4","V4",
                                        "A6","B6","C6","D6","E6","F6","G6","H6","I6", "J6","K6" , "L6","M6","N6","O6","P6","Q6","R6","S6","T6","U6","V6",};  // same as Standard


                    if (customStandardQuantity == 5)
                    {

                        stdCell = new[] { "A1","B1","C1","D1","E1","F1","G1","H1","I1","J1","K1","L1","M1","N1","O1","P1","Q1","R1","S1","T1","U1","V1",
                                           "A2","B2","C2","D2","E2","F2","G2","H2","I2","J2","K2","L2","M2","N2","O2","P2","Q2","R2","S2","T2","U2","V2", 
                                            "A7","B7","C7","D7","E7","F7","G7","H7","I7","J7","K7","L7","M7","N7","O7","P7","Q7","R7","S7","T7","U7","V7",
                                            "A8","B8","C8","D8","E8","F8","G8","H8","I8","J8","K8","L8","M8","N8","O8","P8","Q8"
                                         };

                       
                        lockingCell = new[] { "R8","S8","T8","U8","V8","A9","B9","C9","D9","E9","F9","G9","H9","I9","J9",
                                                 "K9","L9","M9","N9","O9","P9","Q9","R9","S9","T9","U9","V9" };

                    }
                    else if (customStandardQuantity == 10)
                    {

                        stdCell = new[] { "A1","B1","C1","D1","E1","F1","G1","H1","I1","J1","K1","L1","M1","N1","O1","P1","Q1","R1","S1","T1","U1","V1",
                                           "A2","B2","C2","D2","E2","F2","G2","H2","I2","J2","K2","L2","M2","N2","O2","P2","Q2","R2","S2","T2","U2","V2",
                                            "A7","B7","C7","D7","E7","F7","G7","H7","I7","J7","K7","L7","M7","N7","O7","P7","Q7","R7","S7","T7","U7","V7",
                                            "A8","B8","C8","D8","E8","F8","G8","H8","I8","J8","K8","L8"
                                         };

                        
                        lockingCell = new[] { "M8","N8","O8","P8","Q8","R8","S8","T8","U8","V8","A9","B9","C9","D9","E9","F9","G9","H9","I9","J9",
                                                 "K9","L9","M9","N9","O9","P9","Q9","R9","S9","T9","U9","V9" };


                    }
                    else if (customStandardQuantity == 15)
                    {
                        stdCell = new[] { "A1","B1","C1","D1","E1","F1","G1","H1","I1","J1","K1","L1","M1","N1","O1","P1","Q1","R1","S1","T1","U1","V1",
                                           "A2","B2","C2","D2","E2","F2","G2","H2","I2","J2","K2","L2","M2","N2","O2","P2","Q2","R2","S2","T2","U2","V2",
                                            "A7","B7","C7","D7","E7","F7","G7","H7","I7","J7","K7","L7","M7","N7","O7","P7","Q7","R7","S7","T7","U7","V7",
                                            "A8","B8","C8","D8","E8","F8","G8"
                                         };

                       
                        lockingCell = new[] { "H8","I8","J8","K8","L8","M8","N8","O8","P8","Q8","R8","S8","T8","U8","V8","A9","B9","C9","D9","E9","F9","G9","H9","I9","J9",
                                                 "K9","L9","M9","N9","O9","P9","Q9","R9","S9","T9","U9","V9" };


                    }
                    else
                    {
                        stdCell = new string[0];
                    }

                    return new Tuple<string[], string[], string[], string[]>(superCell, lockingCell, superLockingCell, stdCell); // superLockingCell  null here
                }



                superCell = new string[0];
                lockingCell = new string[0];
                stdCell = new string[0];
                superLockingCell = new string[0];
                return new Tuple<string[], string[], string[], string[]>(superCell, lockingCell, superLockingCell, stdCell);
            }

            else
            {
                superCell = new string[0];
                lockingCell = new string[0];
                stdCell = new string[0];
                superLockingCell = new string[0];
                return new Tuple<string[], string[], string[], string[]>(superCell, lockingCell, superLockingCell, stdCell);

            }


        }

        private static void StandardQuantityCellCalulationForTwo(string[] firstArray, string[] secondArray, string[] lockingCell, string[] superCell)
        {
            int s = 0; int l = 0;

            foreach (var item in firstArray) // dynamic a to e
            {
                lockingCell[l] = item + "8";
                l++;
            }

            foreach (var item in secondArray) // a to z
            {
                superCell[s] = item + "4";  // item = F4 .... V4
                s++;

                superCell[s] = item + "6";  // item = F4 .... V4
                s++;

                lockingCell[l] = item + "9";
                l++;
            }
        }

        private static void SuperQuantityCellCalulationForTwo(string[] firstArray, string[] secondArray, string[] superLockingCell, string[] superCell)
        {
            int s = 0; int sl = 0;

            foreach (var item in firstArray)
            {
                superLockingCell[sl] = item + "4";
                sl++;

                superCell[s] = item + "6";  // item = F4 .... V4
                s++;
            }

            foreach (var item in secondArray)
            {
                superCell[s] = item + "4";  // item = F4 .... V4
                s++;

                superCell[s] = item + "6";  // item = F4 .... V4
                s++;
            }
        }


        private static void StandardQuantityCellCalulationForOne(string[] firstArray, string[] secondArray, string[] lockingCell, string[] superCell)
        {
            int s = 0; int l = 22;

            foreach (var item in firstArray) // dynamic a to e
            {
                lockingCell[l] = item + "8";
                l++;
            }

            foreach (var item in secondArray) // a to z
            {
                superCell[s] = item + "4";  // item = F4 .... V4
                s++;

                superCell[s] = item + "6";  // item = F4 .... V4
                s++;

                //lockingCell[l] = item + "9";
                //l++;
            }
        }

        private static void SuperQuantityCellCalulationForOne(string[] firstArray, string[] secondArray, string[] superLockingCell, string[] superCell)
        {
            int s = 0; int sl = 0;

            foreach (var item in firstArray)
            {
                superLockingCell[sl] = item + "4";
                sl++;

                superCell[s] = item + "6";  // item = F4 .... V4
                s++;
            }

            foreach (var item in secondArray)
            {
                superCell[s] = item + "4";  // item = F4 .... V4
                s++;

                superCell[s] = item + "6";  // item = F4 .... V4
                s++;
            }
        }

        private static void SuperQuantityCellCalulation(string[] firstArray, string[] secondArray, string[] superLockingCell, string[] superCell)
        {
            int s = 0; int sl = 0;

            foreach (var item in firstArray)
            {               
                superLockingCell[sl] = item + "4";
                sl++;                    
            }

            foreach (var item in secondArray)
            {
                superCell[s] = item + "4";  // item = F4 .... V4
                s++;
            }
        }

        private static void StandardQuantityCellCalulation(string[] firstArray, string[] secondArray, string[] lockingCell, string[] superCell)
        {
            int s = 0;  int l = 0;

            foreach (var item in firstArray) // dynamic a to e
            {
                lockingCell[l] = item + "8";
                l++;
            }

            foreach (var item in secondArray) // a to z
            {
                superCell[s] = item + "4";
                s++;

                lockingCell[l] = item + "9";
                l++;
            }          
        }


        /*
         
         * public class CustomerAndRecomemdedDrugInfo
    {
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CaseNumber { get; set; }
        public int SubDeviceTypeId { get; set; }
        public string SubDeviceName { get; set; }
        public string TargetInstallDate { get; set; }
        public string CreatedDate { get; set; }
        public int StatusId { get; set; }

        public List<RecomendedDrugDto> drugs = new List<RecomendedDrugDto>();  // analysis


        public List<RecomendedDrugDto> notOralDrugs = new List<RecomendedDrugDto>();  // 
        public List<RecomendedDrugDto> excludedDrugs = new List<RecomendedDrugDto>();
        public List<RecomendedDrugDto> notAvailableDrugs = new List<RecomendedDrugDto>();
    }



        [HttpGet("LoadDrugRecommendationScreen​")] // apply algorithm here
        public async Task<IActionResult> LoadDrugRecommendationScreen​([FromQuery] Guid customerId)
        {
            var msg = new MessageHelperDto();
            try
            {
                CustomerLog customer = await _repository.CustomerLog.GetCustomerIdAsync(customerId);

                CustomerAndRecomemdedDrugInfo customerAndRecomemdedDrugInfo = new CustomerAndRecomemdedDrugInfo();
                customerAndRecomemdedDrugInfo.CustomerId = customerId;
                customerAndRecomemdedDrugInfo.CustomerName = customer.CustomerName;
                customerAndRecomemdedDrugInfo.CaseNumber = customer.CaseNumber;
                customerAndRecomemdedDrugInfo.CreatedDate = customer.CreatedDate.ToString("dd-MMM-yyyy");
                customerAndRecomemdedDrugInfo.TargetInstallDate = customer.TargetInstallDate != null ? customer.TargetInstallDate.Value.ToString("dd-MMM-yyyy") : null;
                customerAndRecomemdedDrugInfo.StatusId = customer.StatusId;
                customerAndRecomemdedDrugInfo.SubDeviceTypeId = (int)customer.SubDeviceTypeId;
                if (customer.SubDeviceType != null)
                {
                    customerAndRecomemdedDrugInfo.SubDeviceName = customer.SubDeviceType.SubDeviceTypeName;
                }


                List<Canister> canisterList = await _repository.Canister.GetAllCanisterByCustomerId(customer.Id);
                var customSuperQuantity = canisterList.Where(s => s.Size == "Super").Select(s => s.Quantity).Sum();
                var customStandardQuantity = canisterList.Where(s => s.Size == "Standard").Select(s => s.Quantity).Sum();

                int superCellCount = 0;
                int lockingCellCount = 0;
                int regularCellCount = 0;
                double maxRatio = 0;
                var allCellTuple = CellCalculation((int)customer.SubDeviceTypeId, customSuperQuantity, customStandardQuantity);
                string[] superCell = allCellTuple.Item1;
                string[] lockingCell = allCellTuple.Item2;
                string[] regularCell = allCellTuple.Item3;

                List<RecomendedDrugDto> recomendedDrugList = new List<RecomendedDrugDto>();
                List<RecomendedDrugDto> finalRecomendedDrugList = new List<RecomendedDrugDto>();
                List<RecomendedDrugDto> notOralDrugList = new List<RecomendedDrugDto>();
                List<RecomendedDrugDto> excludedDrugList = new List<RecomendedDrugDto>();
                List<RecomendedDrugDto> notAvailableDrugList = new List<RecomendedDrugDto>();

                var fileDrugs = await _repository.FileUploadDrug.GetAllUploadedDrugByCustomerId(customerId);

                foreach (var fileDrug in fileDrugs)
                {
                    var drug = await _repository.Drug.GetInformationfromDrugTable(fileDrug.NDC);

                    RecomendedDrugDto recDrug = new RecomendedDrugDto();
                    recDrug.NDC = fileDrug.NDC;
                    recDrug.Name = fileDrug.DrugName;
                    recDrug.Strength = fileDrug.Strength;
                    recDrug.Usage = fileDrug.Usage;
                    recDrug.NoOfOrder = fileDrug.NoOfOrder == null ? 0 : (int)fileDrug.NoOfOrder;
                    recDrug.Otc = fileDrug.Otc;
                    recDrug.UnitQty = fileDrug.UnitQty == null ? 0 : (int)fileDrug.UnitQty;
                    recDrug.RxQty = fileDrug.RxQty == null ? 0 : (int)fileDrug.RxQty;

                    if (drug == null)
                    {
                        recDrug.Tab = "New Drug"; // 13668013611 for not available at DrugDB
                        recDrug.Automate = "Alt";
                        recDrug.Schedule = fileDrug.Schedule;
                        recomendedDrugList.Add(recDrug);
                        continue;
                    }
                    recDrug.PackageSize = (int)drug.PackageSize;
                    recDrug.RecSuperCell = "No";
                    recDrug.RecLockingCell = "No";
                    recDrug.DrugName = drug.DrugName;
                    recDrug.Strength = drug.Strength;
                    recDrug.Manufacturer = drug.Manufacturer;
                    recDrug.SCH = drug.Schedule;
                    recDrug.Tab = "Available";
                    recDrug.Automate = "Alt";

                    double packageSize = Convert.ToDouble(drug.PackageSize);
                    recDrug.Schedule = drug.Schedule;//schedule value "0" , "1"
                    recDrug.PackageSizefitstandardcell = true;

                    int thirtyDramCapacity = 0;
                    if (drug.ThirtyDramCapacity != null && drug.ThirtyDramCapacity != 0)
                    {
                        thirtyDramCapacity = Convert.ToInt32(drug.ThirtyDramCapacity);
                    }
                    else
                    {
                        recDrug.ThirtyDramCapacity = "DCR";
                        recomendedDrugList.Add(recDrug);
                        continue;
                    }
                    recDrug.ThirtyDramCapacity = thirtyDramCapacity.ToString();
                    recDrug.CellCapacity = thirtyDramCapacity * 4.5;
                    recDrug.SuperCellCapacity = thirtyDramCapacity * 15;

                    if (thirtyDramCapacity > 0)
                    {
                        recDrug.Ratio = Math.Round((double)fileDrug.Usage / thirtyDramCapacity, 2);
                        maxRatio = Math.Max(maxRatio, recDrug.Ratio);
                    }
                    recDrug.PackageSizefitstandardcell = packageSize > recDrug.CellCapacity ? false : true;



                    if (drug.RouteOfAdministration == "ORAL") // if not oral then ?????
                    {
                        recomendedDrugList.Add(recDrug);
                    }
                    //else if (drug.DNU_MAX = 1)
                    //{
                    //    excludedDrugList.Add(recDrug);
                    //}
                    else
                    {
                        notOralDrugList.Add(recDrug);
                    }
                }

                #region supercell Assign
                var packageSizefitstandardcellFalseDrugList = recomendedDrugList.OrderByDescending(o => o.Usage).Where(w => w.PackageSizefitstandardcell == false).ToList();
                foreach (var recDrug in packageSizefitstandardcellFalseDrugList)
                {
                    if (superCellCount < superCell.Length)
                    {
                        recDrug.RecSuperCell = "Yes";  //  true based on top usage and PackageSizefitstandardcell = False // suppose 10 is true
                        recDrug.CellLoc = superCell[superCellCount];
                        recDrug.CellType = "Super Cell";
                        recDrug.Tab = "Available";
                        recDrug.Automate = "Yes";
                        superCellCount++;

                        finalRecomendedDrugList.Add(recDrug); // still 10
                    }
                    else
                    {
                        break;
                    }
                }

                var topRatioDrugList = recomendedDrugList.OrderByDescending(o => o.Ratio).Where(w => w.PackageSizefitstandardcell == false).ToList();
                topRatioDrugList = topRatioDrugList.Except(finalRecomendedDrugList).ToList();

                foreach (var recDrug in topRatioDrugList)
                {
                    if (superCellCount < superCell.Length)
                    {
                        recDrug.RecSuperCell = "Yes"; // based on highest ratio and PackageSizefitstandardcell = False
                        recDrug.CellLoc = superCell[superCellCount];
                        recDrug.CellType = "Super Cell";
                        recDrug.Tab = "Available";
                        recDrug.Automate = "Yes";
                        superCellCount++;

                        finalRecomendedDrugList.Add(recDrug); // remaining drugs ...untill 22
                    }
                    else
                    {
                        break;
                    }
                }

                #endregion

                #region LockingCell Assign
                var notZeroScheduleDrugList = recomendedDrugList.OrderByDescending(o => o.Usage).Where(w => w.Schedule != "0").ToList(); // 
                notZeroScheduleDrugList = notZeroScheduleDrugList.Except(finalRecomendedDrugList).ToList();

                foreach (var recDrug in notZeroScheduleDrugList)
                {
                    if (lockingCellCount < lockingCell.Length)
                    {
                        if ((recDrug.Schedule != "0")) // C1 highest use , C2 highest use , C3 highest use, "4" and "5" ??? i.e  != 0
                        {
                            recDrug.RecLockingCell = "Yes"; // If C-II cannot fill all locking cells, then fill with highest use C-III and continue. 
                            recDrug.CellLoc = lockingCell[lockingCellCount];
                            recDrug.CellType = "Locking Cell";
                            recDrug.Tab = "Available";
                            recDrug.Automate = "Yes";
                            lockingCellCount++;
                            finalRecomendedDrugList.Add(recDrug);
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                #endregion

                #region RegularCell Assign
                var remainingDrugList = recomendedDrugList.OrderByDescending(o => o.Usage).Except(finalRecomendedDrugList).ToList(); // remaining drugs
                foreach (var recDrug in remainingDrugList)
                {
                    if (regularCellCount < regularCell.Length)
                    {
                        recDrug.CellLoc = regularCell[regularCellCount];
                        recDrug.CellType = "Regular Cell";
                        recDrug.Tab = "Available";
                        recDrug.Automate = "Yes";
                        regularCellCount++;
                        finalRecomendedDrugList.Add(recDrug);
                    }
                    else
                    {
                        break;
                    }
                }
                #endregion

                customerAndRecomemdedDrugInfo.drugs = finalRecomendedDrugList;
                var remainingDrugList2 = recomendedDrugList.Except(finalRecomendedDrugList).ToList();
                customerAndRecomemdedDrugInfo.drugs.AddRange(remainingDrugList2);

                customerAndRecomemdedDrugInfo.notOralDrugs = notOralDrugList;
                customerAndRecomemdedDrugInfo.excludedDrugs = excludedDrugList;
                customerAndRecomemdedDrugInfo.notAvailableDrugs = notAvailableDrugList;

                return Ok(customerAndRecomemdedDrugInfo);

            }
            catch (Exception ex)
            {
                msg.StatusCode = 400;
                msg.Message = ex.Message;
                return BadRequest(msg);
            }


        }

        */

        static void Main(string[] args)
        {
            //max2 154/22/2

           // CellCalculation(11);

            CellCalculationCustom(1, -5, 5, "C");

            /*
            TreeNode one = new TreeNode(1);
            TreeNode two = new TreeNode(2);
            TreeNode three = new TreeNode(3);
            TreeNode four = new TreeNode(4);
            TreeNode five = new TreeNode(5);

            one.left = two;
            one.right = three;

            two.left = four;
            two.right = five;

            List<int> res = new List<int>();
            inorderTraversal(one, res);

            foreach (var item in res)
            {
                Console.Write(item + " ");
            }

            */

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
            //Console.WriteLine(IsAnagram("amo", "ima"));
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
