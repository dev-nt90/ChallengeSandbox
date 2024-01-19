using ChallengeSandbox.AuxillaryModels.Leetcode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeSandbox
{
	public class LeetcodeChallenges
	{
		/*
		 * Problem 1: TwoSum
		 
		
		Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.

		You may assume that each input would have exactly one solution, and you may not use the same element twice.

		You can return the answer in any order.

 

		Example 1:

		Input: nums = [2,7,11,15], target = 9
		Output: [0,1]
		Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].

		Example 2:

		Input: nums = [3,2,4], target = 6
		Output: [1,2]

		Example 3:

		Input: nums = [3,3], target = 6
		Output: [0,1]

 

		Constraints:

			2 <= nums.length <= 104
			-109 <= nums[i] <= 109
			-109 <= target <= 109
			Only one valid answer exists.
		 
		Follow-up: Can you come up with an algorithm that is less than O(n2) time complexity?

		 */
		public int[] TwoSum(int[] nums, int target)
		{
			var sumIndicies = new int[2];
			for(int i = 0; i < nums.Length; i++)
			{
				for(int j = i+1; j < nums.Length; j++)
				{
					if (nums[i] + nums[j] == target)
					{
						sumIndicies[0] = i;
						sumIndicies[1] = j;
						return sumIndicies;
					}
				}
			}

			return null;
		}

		/*
		 * Problem 9 
		 * Given an integer x, return true if x is a
			palindrome
			, and false otherwise.

 

			Example 1:

			Input: x = 121
			Output: true
			Explanation: 121 reads as 121 from left to right and from right to left.

			Example 2:

			Input: x = -121
			Output: false
			Explanation: From left to right, it reads -121. From right to left, it becomes 121-. Therefore it is not a palindrome.

			Example 3:

			Input: x = 10
			Output: false
			Explanation: Reads 01 from right to left. Therefore it is not a palindrome.

 

			Constraints:

				-231 <= x <= 231 - 1

 
			Follow up: Could you solve it without converting the integer to a string?
		 */
		public bool IsPalindrome(int x)
		{
			if (x < 0) 
			{
				return false;
			}

			// get the reversed number without converting it to a string
			var reversed = 0;
			var temp = x;

			while (temp != 0)
			{
				// get the last digit
				var digit = temp % 10;
                
				// tack on a zero, then add the new digit
                reversed = reversed * 10 + digit;

				// then reduce our working variable such that next place is up for evaluation
				temp /= 10;
			}


			return reversed == x;
		}

		/*
		 * Problem 13
		 * Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.

			Symbol       Value
			I             1
			V             5
			X             10
			L             50
			C             100
			D             500
			M             1000

			For example, 2 is written as II in Roman numeral, just two ones added together. 12 is written as XII, which is simply X + II. The number 27 is written as XXVII, which is XX + V + II.

			Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII. Instead, the number four is written as IV. Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as IX. There are six instances where subtraction is used:

				I can be placed before V (5) and X (10) to make 4 and 9. 
				X can be placed before L (50) and C (100) to make 40 and 90. 
				C can be placed before D (500) and M (1000) to make 400 and 900.

			Given a roman numeral, convert it to an integer.

			Example 1:

			Input: s = "III"
			Output: 3
			Explanation: III = 3.

			Example 2:

			Input: s = "LVIII"
			Output: 58
			Explanation: L = 50, V= 5, III = 3.

			Example 3:

			Input: s = "MCMXCIV"
			Output: 1994
			Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.

			Constraints:

			1 <= s.length <= 15
			s contains only the characters ('I', 'V', 'X', 'L', 'C', 'D', 'M').
			It is guaranteed that s is a valid roman numeral in the range [1, 3999].
		 */
		public int RomanToInt(string s)
		{
			var numeralDictionary = new Dictionary<char, int>() 
			{ 
				{ 'M', 1000 },
				{ 'D', 500 },
				{ 'C', 100 },
				{ 'L', 50 },
				{ 'X', 10 },
				{ 'V', 5 },
				{ 'I', 1 }
			};

			var total = 0;
			for(int i = s.Length - 1; i >= 0; i--)
			{
				// pull our current char out early so we access this array element once
				// TODO: the "subtraction" logic is always triggered when a preceeding character is smaller than the current, AND
				// we're always subtracting by exactly the smaller amount corresponding to that character...
				// which means we can generalize this check and stop comparing magic chars
				var currentChar = s[i];
				if(i < s.Length - 1 && currentChar == 'I' && (s[i+1] == 'V' || s[i+1] == 'X'))
				{
					total -= 1;
				}

				else if(i < s.Length - 1 && currentChar == 'X' && (s[i + 1] == 'L' || s[i + 1] == 'C'))
				{
					total -= 10;
				}

				else if(i < s.Length - 1 && currentChar == 'C' && (s[i + 1] == 'D' || s[i + 1] == 'M'))
				{
					total -= 100;
				}
				else
				{
					total += numeralDictionary[currentChar];
				}
			}

			return total;
		}

		/*
		 * Problem 14
		 * 
		 * Write a function to find the longest common prefix string amongst an array of strings.

		If there is no common prefix, return an empty string "".

		Example 1:

		Input: strs = ["flower","flow","flight"]
		Output: "fl"

		Example 2:

		Input: strs = ["dog","racecar","car"]
		Output: ""
		Explanation: There is no common prefix among the input strings.

		Constraints:

			1 <= strs.length <= 200
			0 <= strs[i].length <= 200
			strs[i] consists of only lowercase English letters.
		 */
		public string LongestCommonPrefix(string[] strs)
		{
			var first = strs[0]; // the first was arbitrarily picked, but it could've been any element of the array
			if (strs.Length == 1)
			{
				return first;
			}

			var longestPrefix = ""; // HACK: this
			var stringBuilder = new StringBuilder();

			for(int i = 1; i < strs.Length; i++)
			{
				// evaluate each word char-by-char until we miss
				var currentWord = strs[i];
				var j = 0;
				
				while (j < currentWord.Length && j < first.Length)
				{
					
					if (currentWord[j] != first[j])
					{
						break;
					}
					stringBuilder.Append(currentWord[j]);
					j++;
				}

				var result = stringBuilder.ToString();

				// on the first instance of a failed match, we can return early
				if (String.IsNullOrWhiteSpace(result))
				{
					return String.Empty;
				}

				if(result.Length < longestPrefix.Length || longestPrefix.Length == 0)
				{
					longestPrefix = result;
				}

				stringBuilder.Clear();
			}

			return longestPrefix;
		}

		/*
		 * Problem 20
		 * 
		 * Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

		An input string is valid if:

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


		 */
		public Boolean IsValidParentheses(string s)
		{
			var bracketStack = new Stack<char>();
			var bracketDictionary = new Dictionary<char, char>()
			{
				{ ')', '(' },
				{ ']', '[' },
				{ '}', '{' }
			};

			for(int i = 0; i < s.Length; i++)
			{
				// limit char array access
				var currentChar = s[i];

				// check if this is an opening bracket
				if (bracketDictionary.Values.Any(v => v.Equals(currentChar)))
				{
					bracketStack.Push(currentChar);
				}

				// must be a closing bracket
				else
				{
					// not an opening brace, and there's no active bracket in the stack, so this cannot be valid
					if(bracketStack.Count == 0)
					{
						return false;
					}

					// check if the closing bracket matches the opening bracket currently on the stack
					if (bracketDictionary[currentChar] != bracketStack.Peek())
					{
						return false;
					}

					bracketStack.Pop();
				}
			}

			return !bracketStack.Any();
		}

		/*
		 * Problem 21
		 * NOTE: This one is not great because in order to test you have to build auxillary list traversal code.
		 * Additionally, these requirements are poor for the second example.
		 * The signature explicitly states we return a custom type, and the output of these example 2 expects an empty array.
		 * This is problematic, as an empty list is just null for a custom type like this. This could be improved if the documentation reflected the null value
		 * or if the signature was updated to include a nullable type. 
		 * 
		 * For now, _assume_ a nullable object is what's expected, and hope the website agrees.
		 * 
		  You are given the heads of two sorted linked lists list1 and list2.

			Merge the two lists into one sorted list. The list should be made by splicing together the nodes of the first two lists.

			Return the head of the merged linked list.

		Example 1:

		Input: list1 = [1,2,4], list2 = [1,3,4]
		Output: [1,1,2,3,4,4]

		Example 2:

		Input: list1 = [], list2 = []
		Output: []

		Example 3:

		Input: list1 = [], list2 = [0]
		Output: [0]

		 */
		public ListNode MergeTwoLists(ListNode list1, ListNode list2)
		{
			// handle edge cases when one or both lists are empty
			if(list1 is null && list2 is null)
			{
				return null;
			}
			else if(list1 is null && list2 is not null)
			{
				return list2;
			}
			else if(list1 is not null && list2 is null)
			{
				return list1;
			}

			// primary loop
			var merged = new List<int>();
			do // TODO: the "do" adds no value and can be removed
			{
				if(list1.val <= list2.val)
				{
					merged.Add(list1.val);
					list1 = list1.next;
				}
				else
				{
					merged.Add(list2.val);
					list2 = list2.next;
				}
			}
			while (list1 is not null && list2 is not null);

			// dump remaining list contents if any remain in list1
			while (list1 is not null)
			{
				merged.Add(list1.val);
				list1 = list1.next;
			}

			// dump remaining list contents if any remain in list2
			while (list2 is not null)
			{
				merged.Add(list2.val);
				list2 = list2.next;
			}

			return this.BuildSinglyLinkedList(merged!.ToArray());
		}

		private ListNode? BuildSinglyLinkedList(int[] data)
		{
			if (data.Length == 0)
			{
				return null;
			}

			ListNode? node = null;
			ListNode? previous = null;

			for (int i = data.Length - 1; i >= 0; i--)
			{
				if (i == data.Length - 1)
				{
					node = new ListNode(data[i], null);
				}
				else
				{
					node = new ListNode(data[i], previous);
				}
				previous = node;
			}

			return node;
		}

		/// <summary>
		/// Problem 26: Remove Duplicates from a sorted array
		/// 
		/// This poorly named problem has a poor description, so I'm not including it here.
		/// 
		/// What this method is _supposed_ to do, is return the number of unique elements, AND update the array in place.
		/// In particular, the ask is to remove the elements which are not part of the unique set of integers.
		/// This is impossible in C#. But the test case accepted zeroes for the "removed" elements, so I'm calling it good enough and will
		/// not be supporting with a companion test case.
		/// </summary>
		/// <param name="nums"></param>
		/// <returns></returns>
		public int RemoveDuplicatesFromASortedArray(int[] nums)
		{
			var foundNums = new HashSet<int>();

			for(int i = 0; i < nums.Length; i++)
			{
				if (!foundNums.Contains(nums[i]))
				{
					foundNums.Add(nums[i]);
				}
			}
			for(int i = 0; i < nums.Length; i++)
			{
				if(i < foundNums.Count)
				{
					nums[i] = foundNums.ElementAt(i);
				}
				else
				{
					nums[i] = 0;
				}
			}

			return foundNums.Count;
		}

		/// <summary>
		/// Problem 27: Remove Element
		/// This is another poorly named challenge and description. Once again, the task is to update the array in place 
		/// to remove elements (and count the number of remaining elements). Once again, this is not possible in C#.
		/// 
		/// This will not be supported with a companion test.
		/// 
		/// The silly name is to avoid future collision.
		/// 
		/// The test cases are actually broken on LeetCode
		/// </summary>
		/// <param name="nums"></param>
		/// <param name="val"></param>
		/// <returns></returns>
		public int RemoveElementProblem27(int[] nums, int val)
		{
			for(int i = 0; i < nums.Length;i++)
			{
				if (nums[i] == val)
				{
					nums[i] = Int32.MaxValue;
				}
			}

			return nums.Count(n => n != Int32.MaxValue);
		}

		/*
		 * Problem 28: Find the index of the first occurrence in a string
		 * 
		 * Given two strings needle and haystack, return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.

			Example 1:

			Input: haystack = "sadbutsad", needle = "sad"
			Output: 0
			Explanation: "sad" occurs at index 0 and 6.
			The first occurrence is at index 0, so we return 0.

			Example 2:

			Input: haystack = "leetcode", needle = "leeto"
			Output: -1
			Explanation: "leeto" did not occur in "leetcode", so we return -1.

			Constraints:

				1 <= haystack.length, needle.length <= 104
				haystack and needle consist of only lowercase English characters.
		 */
		public int FindIndexOfFirstOccurrenceInString(string haystack, string needle)
		{
			if(needle.Length > haystack.Length || String.IsNullOrWhiteSpace(needle) || String.IsNullOrWhiteSpace(haystack))
			{
				return -1;
			}

			var subStrLen = needle.Length;

			for(int i = 0; i < haystack.Length - subStrLen; i++)
			{
				if(haystack.Substring(i, subStrLen).Equals(needle, StringComparison.InvariantCultureIgnoreCase))
				{
					return i;
				}
			}

			return -1;
		}

		/*
		 * Problem 35: Search Insert Position
		 * 
		 * Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.

			You must write an algorithm with O(log n) runtime complexity.

			Example 1:

			Input: nums = [1,3,5,6], target = 5
			Output: 2

			Example 2:

			Input: nums = [1,3,5,6], target = 2
			Output: 1

			Example 3:

			Input: nums = [1,3,5,6], target = 7
			Output: 4
			Constraints:

				1 <= nums.length <= 104
				-104 <= nums[i] <= 104
				nums contains distinct values sorted in ascending order.
				-104 <= target <= 104
		 */
		public int SearchInsertPosition(int[] nums, int target)
		{
			// given that we have a sorted input and we have a requirement to solve in O(log n) time,
			// it's plainly obvious we're being asked to implement a binary search
			var left = 0;
			var right = nums.Length-1;
			var middle = 0;
			while(left <= right)
			{
				middle = left + (right - left)/2;
				if (nums[middle] == target)
				{
					return middle;
				}

				if (nums[middle] < target)
				{
					left = middle + 1;
				}
				else
				{
					right = middle - 1;
				}
			}
			if (nums[middle] < target)
			{
				return middle + 1;
			}
			else if(middle == 0)
			{
				return 0;
			}
			else
			{
				return middle; // not we're not returning -1 because in this hypothetical the right side of the array would have been shifted over by 1
			}
		}
	}
}
