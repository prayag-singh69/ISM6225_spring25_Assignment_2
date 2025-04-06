using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        // edge cases covered
        // Dupicate value in array (eg [1,1])
        // All numbers are present (eg [2,5,4,3,1])
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                int max_val = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] > max_val) max_val = nums[i];
                }

                bool[] look = new bool[max_val + 1];
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] > 0 && nums[i] <= max_val)
                        look[nums[i]] = true;
                }

                List<int> result = new List<int>();
                for (int i = 1; i <= max_val; i++)
                {
                    if (!look[i])
                        result.Add(i);
                }

                return result; // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        // edge cases :
        // 0 in array (eg [0,1,2])
        // array is already sorted 
        // all even or all odd array
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                int l = 0, r = nums.Length - 1;
                while (l < r)
                {
                    if (nums[l] % 2 > nums[r] % 2)
                    {
                        (nums[l], nums[r]) = (nums[r], nums[l]);
                    }
                    if (nums[l] % 2 == 0) l++;
                    if (nums[r] % 2 == 1) r--;
                }
                return nums; // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
        // edge cases handled:
        // if multiple pair return the first
        // no pair satisfying the case
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
  
                for (int i = 0; i < nums.Length - 1; i++)
                {
                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        if (nums[i] + nums[j] == target)
                        {
                            int[] result = new int[2];
                            result[0] = i;
                            result[1] = j;
                            return result;
                        }
                    }
                }
                return Array.Empty<int>(); // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        // edge cases covered:
        // negative numbers included
        // mix of large negative and positive values
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                for (int i = 0; i < nums.Length - 1; i++)
                {
                    for (int j = 0; j < nums.Length - i - 1; j++)
                    {
                        if (nums[j] > nums[j + 1])
                        {
                            (nums[j + 1], nums[j]) = (nums[j], nums[j + 1]);
                        }
                    }
                }

                int n = nums.Length;
                int pd1 = nums[n - 1] * nums[n - 2] * nums[n - 3];
                int pd2 = nums[0] * nums[1] * nums[n - 1];
                return pd1 > pd2 ? pd1 : pd2; 
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        // Edge cases covered:
        // input is 0
        // input is very large number
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                if (decimalNumber == 0) return "0";
                string binumber = "";
                while (decimalNumber > 0)
                {
                    binumber = (decimalNumber % 2) + binumber;
                    decimalNumber /= 2;
                }
                return binumber;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        // Edge cases covered:
        // array is not rotated
        // any number of rotation
        // array of length 1
        public static int FindMin(int[] nums)
        {
            try
            {
                int left = 0, right = nums.Length - 1;
                while (left < right)
                {
                    int middle = (left + right) / 2;
                    if (nums[middle] > nums[right])
                        left = middle + 1;
                    else
                        right = middle;
                }
                return nums[left];
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        // Edge cases covered:
        // negative number input
        // single digit numbers
        public static bool IsPalindrome(int x)
        {
            try
            {
                if (x < 0) return false;
                int num = x;
                int num_rev = 0;
                while (x > 0)
                {
                    int k = x % 10;
                    num_rev = num_rev * 10 + k;
                    x /= 10;
                }
                return num == num_rev;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        // Edge cases covered:
        // if n = 0 or n = 1
        public static int Fibonacci(int n)
        {
            try
            {
                if (n <= 1) return n;
                int x = 0, y = 1;
                for (int i = 2; i <= n; i++)
                {
                    int temp = x + y;
                    x = y;
                    y = temp;
                }
                return y;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
