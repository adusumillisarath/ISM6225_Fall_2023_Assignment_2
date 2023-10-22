/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System;
using System.Text;

namespace ISM6225_Fall_2023_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 3, 50, 75 };
            int upper = 99, lower = 0;
            IList<IList<int>> missingRanges = FindMissingRanges(nums1, lower, upper);
            string result = ConvertIListToNestedList(missingRanges);
            Console.WriteLine(result);
            Console.WriteLine();
            Console.WriteLine();

            //Question2:
            Console.WriteLine("Question 2");
            string parenthesis = "()[]{}";
            bool isValidParentheses = IsValid(parenthesis);
            Console.WriteLine(isValidParentheses);
            Console.WriteLine();
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] prices_array = { 7, 1, 5, 3, 6, 4 };
            int max_profit = MaxProfit(prices_array);
            Console.WriteLine(max_profit);
            Console.WriteLine();
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string s1 = "69";
            bool IsStrobogrammaticNumber = IsStrobogrammatic(s1);
            Console.WriteLine(IsStrobogrammaticNumber);
            Console.WriteLine();
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Question 5");
            int[] numbers = { 1, 2, 3, 1, 1, 3 };
            int noOfPairs = NumIdenticalPairs(numbers);
            Console.WriteLine(noOfPairs);
            Console.WriteLine();
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] maximum_numbers = { 3, 2, 1 };
            int third_maximum_number = ThirdMax(maximum_numbers);
            Console.WriteLine(third_maximum_number);
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string currentState = "++++";
            IList<string> combinations = GeneratePossibleNextMoves(currentState);
            string combinationsString = ConvertIListToArray(combinations);
            Console.WriteLine(combinationsString);
            Console.WriteLine();
            Console.WriteLine();

            //Question 8:
            Console.WriteLine("Question 8:");
            string longString = "leetcodeisacommunityforcoders";
            string longStringAfterVowels = RemoveVowels(longString);
            Console.WriteLine(longStringAfterVowels);
            Console.WriteLine();
            Console.WriteLine();
        }

        /*
        
        Question 1:
        You are given an inclusive range [lower, upper] and a sorted unique integer array nums, where all elements are within the inclusive range. A number x is considered missing if x is in the range [lower, upper] and x is not in nums. Return the shortest sorted list of ranges that exactly covers all the missing numbers. That is, no element of nums is included in any of the ranges, and each missing number is covered by one of the ranges.
        Example 1:
        Input: nums = [0,1,3,50,75], lower = 0, upper = 99
        Output: [[2,2],[4,49],[51,74],[76,99]]  
        Explanation: The ranges are:
        [2,2]
        [4,49]
        [51,74]
        [76,99]
        Example 2:
        Input: nums = [-1], lower = -1, upper = -1
        Output: []
        Explanation: There are no missing ranges since there are no missing numbers.

        Constraints:
        -109 <= lower <= upper <= 109
        0 <= nums.length <= 100
        lower <= nums[i] <= upper
        All the values of nums are unique.

        Time complexity: O(n), space complexity:O(1)
        */

        public static IList<IList<int>> FindMissingRanges(int[] nums, int lower, int upper)
        {
            // Initialize the result list to store missing ranges
            IList<IList<int>> result = new List<IList<int>>();


            // Initialize a 'prev' variable to keep track of the previous number
            int prev = lower - 1;


            try
            {
                for (int i = 0; i <= nums.Length; i++)
                {
                   
                    // Find the current number, then on the last iteration, set it to "upper + 1"
                    int current = (i < nums.Length) ? nums[i] : upper + 1;

                    // The distance between "current" and "prev" should be at least two.
                    if (current - prev >= 2)
                    {
                       
                        // 'prev + 1' to 'current - 1' are ranges that should be added to the result
                        result.Add(new List<int> { prev + 1, current - 1 });
                    
                    }

                    // For the next iteration, change 'prev' to the current value.
                    prev = current;
                }


            }
            catch (Exception)
            {
                throw; // Handle exceptions 
            }

            return result;
        }
        



        /*
         
        Question 2

        Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.An input string is valid if:
        Open brackets must be closed by the same type of brackets.
        Open brackets must be closed in the correct order.
        Every close bracket has a corresponding open bracket of the same type.
 
        Example 1:

        Input: s = "()"
        Output: true
        Example 2:

        Input: s = "()[]{}"
        Output: true
        Example 3:

        Input: s = "(]"
        Output: false

        Constraints:

        1 <= s.length <= 104
        s consists of parentheses only '()[]{}'.

        Time complexity:O(n^2), space complexity:O(1)
        */

        public static bool IsValid(string s)
        {
            // Initialize a stack to track open brackets
            Stack<char> stack = new Stack<char>();

            try
            {
                // The input string should be iterated over each character
                foreach (char c in s)
                {

                    // The character should be pushed into the stack if it is an open bracket
                    if (c == '(' || c == '{' || c == '[')
                    {
                       
                        stack.Push(c);

                    }
                    else
                    {
                       
                        // If the character is a closing bracket, lets check if stack is empty or not
                        if (stack.Count == 0)
                        {
                            return false; // If there is no open bracket to match with
                        }

                        // Lets check if the final open bracket in the stack matches the current closed bracket by popping it out
                        char openBracket = stack.Pop();
                       
                        if (!AreBracketsMatching(openBracket, c))
                       
                        {
                            return false; // Brackets didnt match
                        }
                    }
                }

                // If all of the brackets match, the stack should be empty. Then we may display the results based on that.
                return stack.Count == 0;
            }
            
            catch (Exception)
            {
                throw;
            }
        }
       
        // To determine whether the open and close brackets match, use this method.
       
        private static bool AreBracketsMatching(char open, char close)
        {
            return (open == '(' && close == ')') || (open == '{' && close == '}') || (open == '[' && close == ']');
        }


        /*

        Question 3:
        You are given an array prices where prices[i] is the price of a given stock on the ith day.You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.
        Example 1:
        Input: prices = [7,1,5,3,6,4]
        Output: 5
        Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.

        Example 2:
        Input: prices = [7,6,4,3,1]
        Output: 0
        Explanation: In this case, no transactions are done and the max profit = 0.
 
        Constraints:
        1 <= prices.length <= 105
        0 <= prices[i] <= 104

        Time complexity: O(n), space complexity:O(1)
        */

        public static int MaxProfit(int[] prices)
        {
            try
            {
                // Initializing min_Price to a high value using int.MaxValue
                int min_Price = int.MaxValue; 
                int maximumProfit = 0;

                foreach (int price in prices)
                {
                  
                    // comparing the current value of min_Price with the current price and updating min_Price to the smaller of the two values
                    min_Price = Math.Min(min_Price, price);
                  
                    // Update maximumProfit with the maximum of the current maximumProfit and the profit obtained by selling at the current price
                    maximumProfit = Math.Max(maximumProfit, price - min_Price);
               
                }

                return maximumProfit;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        
        Question 4:
        Given a string num which represents an integer, return true if num is a strobogrammatic number.A strobogrammatic number is a number that looks the same when rotated 180 degrees (looked at upside down).
        Example 1:

        Input: num = "69"
        Output: true
        Example 2:

        Input: num = "88"
        Output: true
        Example 3:

        Input: num = "962"
        Output: false

        Constraints:
        1 <= num.length <= 50
        num consists of only digits.
        num does not contain any leading zeros except for zero itself.

        Time complexity:O(n), space complexity:O(1)
        */

        public static bool IsStrobogrammatic(string s)
        {
            try
            {
               
                int left = 0;
                int right = s.Length - 1;
               
                string correctData = "01689";
                string correctPairs = "00 11 88 696";

                while (left <= right)
                {
                   
                    // Verify the validity of the characters in the left and right places.
                  
                    if (!correctData.Contains(s[left]) || !correctData.Contains(s[right]))
                    
                    {
                        return false; // If invalid characters
                    }

                    // Verify that the characters in the left and right places form a pair that is a strobogrammatic pair
                    if (!correctPairs.Contains(s[left].ToString() + s[right]))
                    
                    {
                        return false; // Not a valid strobogrammatic pair
                    }

                    left++;
                    right--;
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 5:
        Given an array of integers nums, return the number of good pairs.A pair (i, j) is called good if nums[i] == nums[j] and i < j. 

        Example 1:

        Input: nums = [1,2,3,1,1,3]
        Output: 4
        Explanation: There are 4 good pairs (0,3), (0,4), (3,4), (2,5) 0-indexed.
        Example 2:

        Input: nums = [1,1,1,1]
        Output: 6
        Explanation: Each pair in the array are good.
        Example 3:

        Input: nums = [1,2,3]
        Output: 0

        Constraints:

        1 <= nums.length <= 100
        1 <= nums[i] <= 100

        Time complexity:O(n), space complexity:O(n)

        */

        public static int NumIdenticalPairs(int[] nums)
        {
            try
            {
                // creating dictionary to record each number's occurrence
                Dictionary<int, int> occurrence = new Dictionary<int, int>();
                int count = 0;

                foreach (int num in nums)
                
                {
                    // Increase the count and update the frequency if the number is already in the dictionary
                    if (occurrence.ContainsKey(num))
                   
                    {
                        count += occurrence[num];
                       
                        occurrence[num]++;
                    }
                    else
                    
                    {
                        // If the number appears for the first time, lets add it to the dictionary with a frequency of 1.
                        occurrence[num] = 1;
                    }
                }

                return count;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Question 6

        Given an integer array nums, return the third distinct maximum number in this array. If the third maximum does not exist, return the maximum number.

        Example 1:

        Input: nums = [3,2,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2.
        The third distinct maximum is 1.
        Example 2:

        Input: nums = [1,2]
        Output: 2
        Explanation:
        The first distinct maximum is 2.
        The second distinct maximum is 1.
        The third distinct maximum does not exist, so the maximum (2) is returned instead.
        Example 3:

        Input: nums = [2,2,3,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2 (both 2's are counted together since they have the same value).
        The third distinct maximum is 1.
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1

        Time complexity:O(nlogn), space complexity:O(n)
        */

        public static int ThirdMax(int[] nums)
        {
            try
            {
                // Using a HashSet to store unique numbers.
                HashSet<int> hs = new HashSet<int>();

                // Iterate through the input array.
                foreach (int num in nums)
               
                {
                    hs.Add(num);  
                   
                    if (hs.Count > 3)
                    
                    {
                        // This is very important step, where we are removing the smallest number if there are more than 3 unique numbers.
                        hs.Remove(hs.Min());  
                    }
                }

                if (hs.Count < 3)
                
                {
                    //Return the maximum if there are less than three unique numbers.
                    return hs.Max();  
                }

                // This will return the third distinct maximum.
                return hs.Min();  
            }
            catch (Exception)
            
            {
                // Handle the exception.
                throw;
            }
        }

        /*
        
        Question 7:

        You are playing a Flip Game with your friend. You are given a string currentState that contains only '+' and '-'. You and your friend take turns to flip two consecutive "++" into "--". The game ends when a person can no longer make a move, and therefore the other person will be the winner.Return all possible states of the string currentState after one valid move. You may return the answer in any order. If there is no valid move, return an empty list [].
        Example 1:
        Input: currentState = "++++"
        Output: ["--++","+--+","++--"]
        Example 2:

        Input: currentState = "+"
        Output: []
 
        Constraints:
        1 <= currentState.length <= 500
        currentState[i] is either '+' or '-'.

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static IList<string> GeneratePossibleNextMoves(string currentState)
        {
            List<string> validMovesList = new List<string>();

            try
            {
               
                // iterate through the characters in the input string
                for (int i = 0; i < currentState.Length - 1; i++)
               
                {
                   
                    // Check if the current and next characters are both '+'
                    if (currentState[i] == '+' && currentState[i + 1] == '+')
                   
                    {
                        // Create a new character array to represent the updated state
                        char[] newState = currentState.ToCharArray();

                        // Replace the consecutive "++" with "--" to make a valid move
                        newState[i] = '-';
                        newState[i + 1] = '-';

                        // Add the updated state as a possible move
                        validMovesList.Add(new string(newState));
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return validMovesList;
        }

        /*

        Question 8:

        Given a string s, remove the vowels 'a', 'e', 'i', 'o', and 'u' from it, and return the new string.
        Example 1:

        Input: s = "leetcodeisacommunityforcoders"
        Output: "ltcdscmmntyfrcdrs"

        Example 2:

        Input: s = "aeiou"
        Output: ""

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static string RemoveVowels(string s)
        {
            try
            {
                // lets define a string with all the vowels as below
                string vowels = "aeiou";

                // Creating below character array to store the result
                char[] result = new char[s.Length];
                int index = 0;

                // Using foreach to Iterate through the characters in the input string
                foreach (char c in s)
                
                {
                   
                    // lets check if the current character is not a vowel
                    if (!vowels.Contains(c))
                   
                    {
                        // If its not vowel lets add the character to the result array and increase the index value
                        result[index] = c;
                        index++;
                    }
                }

                // Let's make a new string with the characters in the result array, up to the index value
                return new string(result, 0, index);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<string> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "\"" + input[i] + "\""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}
