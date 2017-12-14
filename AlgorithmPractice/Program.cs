using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmPractice
{
    public class Program
    {

        private static int[] result;

        static void Main(string[] args)
        {
            //LogicTest1();
            //while(true)
            //{
            //    Console.WriteLine("input X");
            //    string num= Console.ReadLine();
            //    Console.WriteLine(IsPalindrome(Int32.Parse(num)));
            //}
            //IsMatch("aaa","ab*ac*a");
            MaxSubArray(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 });//, 
            //LongestCommonPrefix(new string[] { "aa", "ab"});
            //CSharpLearning learning = new CSharpLearning();
            //learning.Run();
            Console.WriteLine("end");
            Console.ReadLine();
        }

        public static void LogicTest1()
        {
            int[] box = new int[] { 0, 8, 6, 5, 7, 4, 2, 2, 11, 8, -2, 2, 1 };

            int step = 1;
            int step2Index1 = 1;
            int step2Index2 = 10;

        
            box[11] += 3;
        Step2:
            box[step2Index2] = box[step2Index1];

        //if(step2Index1/2==1)
        //{
        //    goto Step6;
        //}else
        //{

        //}

      
            box[11] += box[5];
            step2Index1++;
            step2Index2--;

            if (step2Index2 < box[1])
            {
                Console.WriteLine(box[8] + "---" + box[11]);
            }
            else
                goto Step2;

            

        }

        #region isMatch
        static void IsMatch(string text,string expression)
        {
            Console.WriteLine(string.Format("text: {0}  ; rex: {1}", text, expression));
            if(text==null || expression==null)
            {
                Console.WriteLine("param text or expression can not be null");
                return;
            }
            
            if(text==expression)
            {
                Console.WriteLine(bool.TrueString+":"+text);
                return;
            }   

            bool result = true;
            result = IsMatchCore(text, expression, 0, 0);
            Console.WriteLine(result);
        }

        static bool IsMatchCore(string text, string expression, int i, int j)
        {   

            char c = '\0';
            char e = '\0';

            if (j >= expression.Length)
            {
                if (i >= text.Length)
                    return true;
                else
                    return false;
            }
            else //j<expression.length
            {
                e = expression[j];
                if (i < text.Length)
                    c = text[i];
            }

             if (j + 1 < expression.Length && expression[j + 1] == '*') //a*  or .*
            {
                if (e == c || e == '.')
                    return IsMatchCore(text, expression, i, j + 2) || IsMatchCore(text, expression, i + 1, j + 2);
                else
                    return IsMatchCore(text, expression, i, j + 2);
            }
            else
            {
                if (e == c || e == '.')
                    return IsMatchCore(text, expression, i + 1, j + 1);
                else
                    return false;
            }
        }
        #endregion

        public static void test(int d)
        {
            int k = d;
            test(d >> 2);
        }

        public static int ClimbStairs(int n)
        {
            if (n == 1)
                return 1;
            if (n == 2)
                return 2;

            int n1 = 2;
            int n2 = 1;
            int result = 0;
            for(int i=3; i<=n; i++)
            {
                result = n1 + n2;
                n2 = n1;
                n1 = result;
                
            }
            return result;
        }

        #region sort
        static void BucketSort()
        {
            int[] nums = new int[] {7,5,9,2,2,10,6 };
            int[] array = new int[11];
            for (int i = 0; i < array.Length; i++)
                array[i] = 0;

            foreach (int num in nums)
                array[num]++;

            List<int> output = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0)
                {
                    for (int j = 1; j <= array[i]; j++)
                        output.Add(i);
                }
            }

            for (int i = array.Length-1; i >=0; i--)
            {
                if (array[i] > 0)
                {
                    for (int j = 1; j <= array[i]; j++)
                        output.Add(i);
                }
            }

            Console.WriteLine(string.Join(",", output));

        }

        static void BubbleSort()
        {
            Console.WriteLine("please enter several int seperated by , and then press ENTER");
            var input = Console.ReadLine();
            var inputArray = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            List<int> list = new List<int>();
            foreach(string num in inputArray)
            {
                int result;
                if (Int32.TryParse(num, out result))
                    list.Add(result);
                else
                    throw new InvalidCastException(num + " can not be casted to Int");
            }

            //for (int j = 1; j < list.Count - 1; j++)
            //{
            //    for (int i = 0; i < list.Count - 1; i++)
            //    {

            //        if (list[i] < list[i + 1])
            //        {
            //            int temp = list[i];
            //            list[i] = list[i + 1];
            //            list[i + 1] = temp;
            //        }

            //    }
            //}

            for (int j = 1; j < list.Count - 1; j++)
            {
                for (int i = 0; i < list.Count - j; i++)
                {

                    if (list[i] < list[i + 1])
                    {
                        int temp = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = temp;
                    }

                }
            }
            Console.WriteLine(string.Join(",", list));
        }

        static void QuickSort()
        {
            Console.WriteLine("please enter several int seperated by space , and then press ENTER");
            var input = Console.ReadLine();
            var inputArray = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<int> list = new List<int>();
            foreach (string num in inputArray)
            {
                int result;
                if (Int32.TryParse(num, out result))
                    list.Add(result);
                else
                    throw new InvalidCastException(num + " can not be casted to Int");
            }

            result = new int[inputArray.Length];
            QuickSort(list, 0);
            Console.WriteLine(string.Join(",", result));
        }

        static void QuickSort(List<int> nums, int startIndex)
        {
            if (nums.Count ==0)
                return;
            List<int> leftList = new List<int>();
            List<int> rightList = new List<int>();

            int baseNumber = nums[0];
            for (int i=1; i<nums.Count;i++)
            {
                if(nums[i]<baseNumber)
                {
                    leftList.Add(nums[i]);
                }else
                {
                    rightList.Add(nums[i]);
                }
            }
            result[leftList.Count+ startIndex] = baseNumber;
            QuickSort(leftList,startIndex);
            QuickSort(rightList, startIndex+leftList.Count+1);
        }
          #endregion

        static void GetQQNumber()
        {
            int[] nums = new[] { 6, 3, 1, 7, 5, 8, 9, 2, 4 };
            List<int> result = new List<int>();
            List<int> source = nums.ToList();
            int count = source.Count;
            for(int i=1; i<= count; i++)
            {
                result.Add(source[0]);
                source.RemoveAt(0);
                if(source.Count>=2)
                {
                    int temp = source[0];
                    source.RemoveAt(0);
                    source.Add(temp);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }

        #region invert interger
        static int Invert(int x)
        {
            Console.WriteLine(x);
            int negative = 1;
            if(x<0)
            {
                negative = -1;
                x = x * -1; 
            }

            while(x%10==0 && x!=0)
            {
                x = x / 10;
            }

            string stringX = x.ToString();
            Stack<char> nums = new Stack<char>();
            foreach(char c in stringX)
                nums.Push(c);

            StringBuilder newStringX = new StringBuilder();
            while (nums.Count > 0)
                newStringX.Append(nums.Pop());

            int output = 0;
            Int32.TryParse(newStringX.ToString(), out output);

            return negative*output;

        }

        static int Invert2(int x)
        {
            int result = 0;
            int lastnumber = 0; 

            while (x != 0)
            {
                lastnumber= x % 10;
                x = x / 10;
                             
                result = result * 10 + lastnumber;
            }
            return result;
        }
        #endregion

        static bool IsPalindrome(int x)
        {
         
            if(x>0)
            {               
                var stringX = x.ToString().ToCharArray();
                int length = stringX.Length;
                int mid = length % 2 == 0 ? mid = length / 2 : mid = (length - 1) / 2;
                for (int i= 0;i<mid; i++)
                {
                    if (stringX[i] != stringX[length - 1 - i])
                        return false;
                }

                return true;
            }
            return false;
          
        }

        public static string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0)
                return "";
            if (strs[0].Length == 0)
                return "";
            int minIndex = 0;
            int minSize = strs[0].Length;
            for(int i=0;i<strs.Length;i++)
            {
                if(strs[i].Length<minSize)
                {
                    minSize = strs[i].Length;
                    minIndex = i;
                }
            }
            string shortestString = strs[minIndex];
            
            for(int j=shortestString.Length;j>0; j--)
            {
                bool found = true;
                var testString=shortestString.Substring(0,j);
                foreach(string s in strs)
                {
                    if (!s.StartsWith(testString))
                    {
                        found = false;
                        break;
                    }
                }
                if(found==true)
                {
                    return testString;
                }

            }
            return "";
        }

        public static bool IsValid(string s)
        {
            if (string.IsNullOrEmpty(s))
                return false;

            if (s.Length % 2 != 0)
                return false;
            
            while (s.Length > 0)
            {
                bool isPaired = false;
                for (int i = 0; i <= s.Length - 2; i++)
                {
                    if ((s[i] == '{' && s[i + 1] == '}') || (s[i] == '[' && s[i + 1] == ']') || (s[i] == '(' && s[i + 1] == ')'))
                    {
                        s = s.Remove(i, 2);
                        isPaired = true;
                        break;
                    }
                }
                if(isPaired==false)
                        return false;              
            }

            return true;
        }

        public static int RemoveElement(int[] nums, int val)
        {
            int  j = nums.Length - 1;
            while(j>=0)
            {
                if (nums[j] == val)
                    j--;
                else
                    break;
            }

            for (int i = 0; i < j; i++)
            {
                if(nums[i]==val)
                {
                    nums[i] = nums[j];
                    nums[j] = val;
                    j--;
                    while (nums[j] == val)
                    { j--; }
                }
            }

            return j+1;
        }

        public static  int RemoveDuplicates(int[] nums)
        {
            int duplicate = 0;
            int i = 0;
            while(i<nums.Length)
            {
                int j = i + 1;
                while(j<nums.Length && nums[j] == nums[i])
                {                   
                    duplicate++;
                    j++;
                }
                i = j;
            }

            return nums.Length - duplicate;
        }

        public static int strStr(string haystack, string needle)
        {
            if (haystack == needle)
                return 0;

            if (needle == "")
                return 0;

            for(int i=0; i<=haystack.Length-needle.Length;i++)
            {
                if (haystack[i] == needle[0] && haystack.Substring(i, needle.Length) == needle)
                    return i;
            }
            return -1;
        }

        public static int SearchInsert(int[] nums, int target)
        {
            if (nums.Length == 0)
                return 0;
            if (nums[0] >= target)
                return 0;
            if (nums[nums.Length - 1] <= target)
                return nums.Length;

            for(int i=0; i+1<nums.Length;i++)
            {
                if (nums[i] <= target && target <= nums[i + 1])
                    return i + 1;
            }

            return 0;
        }

        public static string CountAndSay(int n)
        {           
           
            if (n == 1)
               return "1";

            if (n == 2)
                return "11";

            string preValue = "11"; //n==2
            for (int i=3;i<=n;i++)
            {
                char c=preValue[0];
                int j =1;
                int count = 1;
                string currentValue = null;
               while(j<preValue.Length)
                {
                    if(preValue[j]==c)
                    {
                        j++;count++;
                    }
                    else
                    {
                        currentValue += count.ToString() + c.ToString();
                        c = preValue[j];
                        j++; count = 1;                
                    }
                }
                currentValue += count.ToString() + c.ToString();
                preValue = currentValue;
            }

            return preValue;
        }

        public static int MaxSubArray(int[] nums)
        {
            if (nums.Length == 0)
                return 0;

            int max = nums[0];
            int minIndex = 0, maxIndex = 0;
            int i = 0;
            int j = 0;
            int previousValue = 0;

            //-2, 1, -3, 4, -1, 2, 1, -5, 4 
            for (j = 0; j < nums.Length; j++)
            {
                if (previousValue < 0)
                {
                    i = j;
                    previousValue = nums[j];
                }
                else
                {
                    previousValue += nums[j];
                }
                    if (previousValue > max)
                    {
                        max = previousValue;
                        minIndex = i;
                        maxIndex = j;
                    }

                
            }

            return max;

        }

        /*public static int[] GetNums(int[] nums)
        {
            if (nums.Length == 1)
                return nums;
            if (nums.Length == 2)
            {
                if (nums[0] >= 0 && nums[1] >= 0)
                    return nums;
                else if (nums[0] >= nums[1])
                    return new int[] { nums[0] };
                else
                    return new int[] { nums[1] };

            }

            if (nums.Length > 2)
            {
                int i = 0; j = nums.Length - 1;
                while(i+1>=j)
                {
                    if(nums[i]<0)
                    {
                        i++;
                    }
                    else
                    {
                        
                    }

                    if(nums[j]<0)
                    {
                        j--;
                    }


                }
            }

            return null;
            
        }*/

        public static  int LengthOfLastWord(string s)
        {         

            while (s.Length>0)
            {
                if (s[s.Length - 1] == ' ')
                    s = s.Remove(s.Length - 1, 1);
                else
                    break;
            }

            if (s.Length == 0)
                return 0;

            int i = 0;
            for( i = s.Length - 1; i>=0;i--)
            {
                if (s[i] == ' ')              
                    break;
            }
            return s.Length - 1 - i;
        }

        public static string AddBinary(string a, string b)
        {            
            Stack<char> result = new Stack<char>();
            Stack<char> aa = new Stack<char>();
            Stack<char> bb = new Stack<char>();

            int i = 0;
            while (i <a.Length)
            {
                aa.Push(a[i]);
                i++;
            }
            i = 0;
            while (i < b.Length)
            {
                bb.Push(b[i]);
                i++;
            }

            int k = 0;
            while(aa.Count>0 || bb.Count>0)
            {
                int aaa = 0;
                int bbb = 0;
                if (aa.Count > 0)
                    aaa = aa.Pop() == '0' ? 0:1 ;
                if (bb.Count > 0)
                    bbb = bb.Pop()=='0'?0:1;

                int add = aaa + bbb + k;
                if(add==0)
                { result.Push('0');k =0; }
                else if(add==1)
                { result.Push('1'); k = 0; }
                else if(add==2)
                { result.Push('0'); k = 1; }
                else { result.Push('1'); k = 1; }
            }
            if (k > 0)
                result.Push('1');

            string resultString = "";
            while (result.Count > 0)
                resultString += result.Pop();

            return resultString;
        }

        public static int MySqrt(int x)
        {          
            
            long min =0;
            long max = 65536;            
            
            while(min+1<max)
            {
                long k = (max + min) / 2;
                long sqrK = k * k;
                if (sqrK == x)
                    return (int)k;
                else if (sqrK > x)              
                    max = k;              
                else
                    min = k;                
            }    
            
            return  (int)min;

        }

        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {

        }
    }
}

