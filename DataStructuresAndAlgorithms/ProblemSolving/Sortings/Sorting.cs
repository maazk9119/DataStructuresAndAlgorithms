﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolving.Sortings
{
    internal sealed class Sorting
    {
        /// <summary>
        ///     Main 
        /// </summary>
        internal static void Main()
        {
            Sorting sorting = new Sorting();
            Console.WriteLine(sorting.SortSentence());
            Console.WriteLine(sorting.method());
        }

        /// <summary>
        /// Problem Statement: 
        ///     Given an array nums of size n, return the majority element.
        ///     The majority element is the element that appears more than ⌊n / 2⌋ times.
        ///     You may assume that the majority element always exists in the array.
        /// Input: 
        ///     nums = [3,2,3]
        /// Output: 
        ///     3
        /// Constraints:
        ///     n == nums.length
        ///     1 <= n <= 5 * 10^4
        ///     -10^9 <= nums[i] <= 10^9
        /// Follow-up: 
        ///     Could you solve the problem in linear time and in O(1) space?
        /// </summary>
        /// <param name="nums">default input parm</param>
        /// <returns></returns>
        internal int MajorityElements(int[] nums)
        {
            nums = new int[] { 2, 2, 1, 1, 1, 2, 2 };

            int maxIndex = 0;
            int maxCount = 1;

            if (nums.Length == 1)
            {
                return nums[0];
            }

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[maxIndex] == nums[i])
                {
                    maxCount++;
                }
                else
                {
                    maxCount--;
                }

                if (maxCount == 0)
                {
                    maxCount = 1;
                    maxIndex = i;
                }
            }

            return nums[maxIndex];
        }


        /// <summary>
        /// Problem Statement: 
        ///     A sentence is a list of words that are separated by a single space with no leading or trailing spaces. 
        ///     Each word consists of lowercase and uppercase English letters.
        ///     A sentence can be shuffled by appending the 1-indexed word position to each word then rearranging the words in the sentence.
        /// Input: 
        ///     s = "is2 sentence4 This1 a3"
        /// Output: 
        ///     "This is a sentence"
        /// Explanation: 
        ///     Sort the words in s to their original positions 
        ///     "This1 is2 a3 sentence4", then remove the numbers.
        /// Constraints:
        ///     2 <= s.length <= 200
        ///     s consists of lowercase and uppercase English letters, spaces, and digits from 1 to 9.
        ///     The number of words in s is between 1 and 9.
        ///     The words in s are separated by a single space.
        ///     s contains no leading or trailing spaces.
        /// </summary>
        /// <param name="s">default param as input</param>
        /// <returns></returns>
        internal string SortSentence(string s = "is2 sentence4 This1 a3")
        {
            string result = "";
            string delimitor = " ";
            var    arrange   = new Dictionary<int, string>();
            
            string[] words = s.Split(delimitor);

            foreach(string word in words)
            {
                int tempLen = word.Length;
                
                //get number from string
                int tempValue    = (int)char.GetNumericValue(Convert.ToChar(word.Substring(tempLen-1)));
;               //get string without number
                string tempWord  = word.Substring(0, tempLen-1);
               
                arrange.Add(tempValue, tempWord);
            }

            //sort arrange to arr
            var arr = from x in arrange
                        orderby x.Key ascending
                            select x;

            //save into result
            foreach(var word in arr)
            {
                if(result == "")
                {
                    result = word.Value;
                }
                else
                {
                    result += " " + word.Value;
                }
            }

            return result;
        }


        /// <summary>
        /// Problem Statement:
        ///     You are given two strings s and t. 
        ///     String t is generated by random shuffling string s and then add one more letter at a random position.
        ///     Return the letter that was added to t.
        /// Input: 
        ///     s = "abcd", t = "abcde"
        /// Output: 
        ///     "e"
        /// Explanation: 
        ///     'e' is the letter that was added.
        ///     
        /// Constraints:
        ///     0 <= s.length <= 1000
        ///     t.length == s.length + 1
        ///     s and t consist of lowercase English letters.
        /// </summary>
        /// <param name="s">default parm as input</param>
        /// <param name="t">default parm as input</param>
        /// <returns></returns>
        internal char FindTheDifference(string s="abcd", string t="abcde")
        {
            int sT = 0, tT = 0;
            
            foreach (var i in s)
            {
                sT += i;
            }
            
            foreach (var i in t)
            {
                tT += i;
            }

            return (char) (tT - sT);
        }
    }
}
