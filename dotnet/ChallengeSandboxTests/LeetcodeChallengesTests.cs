using ChallengeSandbox;

using System;
using System.Collections.Generic;
using System.Linq;
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
	}
}
