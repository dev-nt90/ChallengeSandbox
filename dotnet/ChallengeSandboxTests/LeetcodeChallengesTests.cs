using ChallengeSandbox;
using ChallengeSandbox.AuxillaryModels.Leetcode;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeSandboxTests
{
	[TestFixture]
	public class LeetcodeChallengesTests
	{
		LeetcodeChallenges leetcodeChallenges = new LeetcodeChallenges();

		[Test]
		public void TwoSumTest()
		{
			var input1 = new int[] { 2, 7, 11, 1 };
			var target1 = 9;
			var output1 = new int[] { 0, 1 };
			Assert.That(output1, Is.EqualTo(leetcodeChallenges.TwoSum(input1, target1)), "Example 1 failed");

			var input2 = new int[] { 3, 2, 4 };
			var target2 = 6;
			var output2 = new int[] { 1, 2 };
			Assert.That(output2, Is.EqualTo(leetcodeChallenges.TwoSum(input2, target2)), "Example 2 failed");

			var input3 = new int[] { 3, 3 };
			var target3 = 6;
			var output3 = new int[] { 0,1 };
			Assert.That(output3, Is.EqualTo(leetcodeChallenges.TwoSum(input3, target3)), "Example 3 failed");
		}

		[Test]
		public void PalindromeNumberTest()
		{
			Assert.That(leetcodeChallenges.IsPalindrome(101), Is.True);
			Assert.That(leetcodeChallenges.IsPalindrome(11), Is.True);
			Assert.That(leetcodeChallenges.IsPalindrome(1), Is.True);
			Assert.That(leetcodeChallenges.IsPalindrome(0), Is.True);
			Assert.That(leetcodeChallenges.IsPalindrome(10), Is.False);
			Assert.That(leetcodeChallenges.IsPalindrome(-121), Is.False);
		}

		[Test]
		public void RomanToIntTest()
		{
			var input1 = "III";
			var output1 = 3;
			Assert.That(leetcodeChallenges.RomanToInt(input1), Is.EqualTo(output1));

			var input2 = "LVIII";
			var output2 = 58;
			Assert.That(leetcodeChallenges.RomanToInt(input2), Is.EqualTo(output2));

			var input3 = "MCMXCIV";
			var output3 = 1994;
			Assert.That(leetcodeChallenges.RomanToInt(input3), Is.EqualTo(output3));
		}

		[Test]
		public void LongestCommonPrefixTest()
		{
			var input1 = new string[] { "flower", "flow", "flight" };
			var output1 = "fl";
			Assert.That(leetcodeChallenges.LongestCommonPrefix(input1), Is.EqualTo(output1));

			var input2 = new string[] { "dog", "racecar", "car" };
			var output2 = "";
			Assert.That(leetcodeChallenges.LongestCommonPrefix(input2), Is.EqualTo(output2));
		}

		[Test]
		public void IsValidParenthesesTest()
		{
			var input1 = "()";
			var output1 = true;
			Assert.That(leetcodeChallenges.IsValidParentheses(input1), Is.EqualTo(output1));

			var input2 = "()[]{}";
			var output2 = true;
			Assert.That(leetcodeChallenges.IsValidParentheses(input2), Is.EqualTo(output2));

			var input3 = "(]";
			var output3 = false;
			Assert.That(leetcodeChallenges.IsValidParentheses(input3), Is.EqualTo(output3));

			var input4 = "((";
			var output4 = false;
			Assert.That(leetcodeChallenges.IsValidParentheses(input4), Is.EqualTo(output4));
		}

		[Test]
		public void MergeTwoListsTest()
		{
			// common case
			var ex1_list1 = new int[] { 1, 2, 4 };
			var ex1_list1_asListNode = BuildSinglyLinkedList(ex1_list1);
			var ex1_list2 = new int[] { 1, 3, 4 };
			var ex1_list2_asListNode = BuildSinglyLinkedList(ex1_list2);
			var ex1_output = new int[] { 1, 1, 2, 3, 4, 4 };
			var ex1_output_asListNode = BuildSinglyLinkedList(ex1_output);

			Assert.That(
				this.CompareListNode(
					leetcodeChallenges.MergeTwoLists(ex1_list1_asListNode, ex1_list2_asListNode), 
					ex1_output_asListNode),
				Is.True);


			var ex2_list1 = new int[0];
			var ex2_list1_asListNode = BuildSinglyLinkedList(ex2_list1);
			var ex2_list2 = new int[0];
			var ex2_list2_asListNode = BuildSinglyLinkedList(ex2_list2);
			var ex2_output = new int[0];
			var ex2_output_asListNode = BuildSinglyLinkedList(ex2_output);

			Assert.That(
				this.CompareListNode(
					leetcodeChallenges.MergeTwoLists(ex2_list1_asListNode, ex2_list2_asListNode),
					ex2_output_asListNode),
				Is.True);

			var ex3_list1 = new int[0];
			var ex3_list1_asListNode = BuildSinglyLinkedList(ex3_list1);
			var ex3_list2 = new int[] { 0 };
			var ex3_list2_asListNode = BuildSinglyLinkedList(ex3_list2);
			var ex3_output = new int[] { 0 };
			var ex3_output_asListNode = BuildSinglyLinkedList(ex3_output);

			Assert.That(
				this.CompareListNode(
					leetcodeChallenges.MergeTwoLists(ex3_list1_asListNode, ex3_list2_asListNode),
					ex3_output_asListNode),
				Is.True);
		}

		/// <summary>
		/// This is a silly thing, a test for the test code
		/// </summary>
		[Test]
		public void AssertCanBuildSinglyLinkedList()
		{
			var list1 = new int[] { 1, 2, 4 };
			var list1_asListNode = BuildSinglyLinkedList(list1);
			Assert.That(list1_asListNode!.val, Is.EqualTo(1));

			Assert.That(list1_asListNode.next, Is.Not.Null);
			Assert.That(list1_asListNode.next.val, Is.EqualTo(2));

			Assert.That(list1_asListNode.next.next, Is.Not.Null);
			Assert.That(list1_asListNode.next.next.val, Is.EqualTo(4));
		}

		/// <summary>
		/// The silliness continues
		/// </summary>
		[Test]
		public void AssertCanCompareSinglyLinkedList()
		{
			var list1 = new int[] { 1, 2, 4 };
			var list1_asListNode = BuildSinglyLinkedList(list1);

			var list2 = new int[] { 1, 2, 4 };
			var list2_asListNode = BuildSinglyLinkedList(list1);

			Assert.That(this.CompareListNode(list1_asListNode, list2_asListNode), Is.True);

			var list3 = new int[] { 1, 2, 4 };
			var list3_asListNode = BuildSinglyLinkedList(list3);

			var list4 = new int[] { 1, 2 };
			var list4_asListNode = BuildSinglyLinkedList(list4);

			Assert.That(this.CompareListNode(list3_asListNode, list4_asListNode), Is.False);

			var list5 = new int[0];
			var list5_asListNode = BuildSinglyLinkedList(list5);

			var list6 = new int[0];
			var list6_asListNode = BuildSinglyLinkedList(list6);

			Assert.That(this.CompareListNode(list5_asListNode, list6_asListNode), Is.True);

			var list7 = new int[0];
			var list7_asListNode = BuildSinglyLinkedList(list7);

			var list8 = new int[] { 1, 2 };
			var list8_asListNode = BuildSinglyLinkedList(list8);

			Assert.That(this.CompareListNode(list7_asListNode, list8_asListNode), Is.False);
		}

		private ListNode? BuildSinglyLinkedList(int[] data) // HACK: this impl exists in both test and impl code - maybe make SUT static?
		{
			if(data.Length == 0)
			{
				return null;
			}

			ListNode? node = null;
			ListNode? previous = null;
			
			for (int i = data.Length - 1; i >= 0; i--)
			{
				if(i == data.Length - 1)
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

		private Boolean CompareListNode(ListNode? listNode1,  ListNode? listNode2)
		{
			// empty input case
			if(listNode1 is null && listNode2 is null)
			{
				return true;
			}

			// end of list case
			if (listNode1?.next is null && listNode2?.next is null)
			{
				return true;
			}

			// values matches and more data exists, continue traversal
			if(listNode1?.next is not null && listNode2?.next is not null && listNode1.val == listNode2.val)
			{
				return CompareListNode(listNode1.next, listNode2.next);
			}

			// mismatch, do exit
			else
			{
				return false;
			}
		}

		[Test]
		public void FindIndexOfFirstOccurrenceInStringTest()
		{
			var haystack1 = "sadbutsad";
			var needle1 = "sad";
			var output1 = 0;
			Assert.That(leetcodeChallenges.FindIndexOfFirstOccurrenceInString(haystack1, needle1), Is.EqualTo(output1));

			var haystack2 = "leetcode";
			var needle2 = "leeto";
			var output2 = -1;
			Assert.That(leetcodeChallenges.FindIndexOfFirstOccurrenceInString(haystack2, needle2), Is.EqualTo(output2));
		}

		[Test]
		public void SearchInsertPositionTest()
		{
			var input1 = new int[] { 1, 3, 5, 6 };
			var target1 = 5;
			var output1 = 2;
			Assert.That(leetcodeChallenges.SearchInsertPosition(input1, target1), Is.EqualTo(output1));

			var input2 = new int[] { 1, 3, 5, 6 };
			var target2 = 2;
			var output2 = 1;
			Assert.That(leetcodeChallenges.SearchInsertPosition(input2, target2), Is.EqualTo(output2));

			var input3 = new int[] { 1, 3, 5, 6 };
			var target3 = 7;
			var output3 = 4;
			Assert.That(leetcodeChallenges.SearchInsertPosition(input3, target3), Is.EqualTo(output3));

			var input4 = new int[] { 2, 3, 4 };
			var target4 = 1;
			var output4 = 0;
			Assert.That(leetcodeChallenges.SearchInsertPosition(input4, target4), Is.EqualTo(output4));

			var input5 = new int[] { 1, 3 };
			var target5 = 2;
			var output5 = 1;
			Assert.That(leetcodeChallenges.SearchInsertPosition(input5, target5), Is.EqualTo(output5));
		}
	}
}
