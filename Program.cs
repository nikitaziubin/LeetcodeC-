using System.Linq;
using System.Numerics;
using System.Text;
using static Solution;

internal class Program
{

	private static void Main(string[] args)
	{
		//Console.WriteLine("Hello, World!");
		Solution solution = new Solution();
		ListNode list1 = new ListNode(1);
		list1.next = new ListNode(2);
		list1.next.next = new ListNode(4);
		list1.next.next.next = new ListNode(3);
		list1.next.next.next.next = new ListNode(4);

		//a.MergeTwoLists(list1, list2);
		int[] nums = { 1,1, 2, 3 };

		//TreeNode root;
		//root = new TreeNode(1);
		//root.left = new TreeNode(2);
		//root.left.left = new TreeNode(4);
		//root.left.right = new TreeNode(5);

		//root.left.right.left = new TreeNode(6);
		//root.left.right.right = new TreeNode(7);

		//root.right = new TreeNode(3);
		//root.right.right = new TreeNode(8);
		//root.right.right.left = new TreeNode(9);
		//solution.PostorderTraversal(root);

		int e = solution.solution(nums);
	}
}
public class Solution
{
	public int solution(int[] A)
	{
		HashSet<int> positives = new HashSet<int>(A.Where(x => x > 0));
		int smallestMissing = 1;

		while (positives.Contains(smallestMissing))
		{
			smallestMissing++;
		}

		return smallestMissing;
		//Array.Sort(A);
		//int[] AwithoutNegativeNumbers = A.Where(x => x >= 0).ToArray();
		//int[] AWithOutDuplicats = AwithoutNegativeNumbers.Distinct().ToArray();
		//if (AWithOutDuplicats.Length == 0)
		//{
		//	return 1;
		//}
		//for (int i = 0; i < AWithOutDuplicats.Length - 1; ++i)
		//{
		//	if (AWithOutDuplicats[i] + 1 != AWithOutDuplicats[i + 1])
		//	{
		//		return AWithOutDuplicats[i] + 1;
		//	}
		//}

		//return AWithOutDuplicats[AWithOutDuplicats.Length - 1] + 1;

	}




	List<int> result = new List<int>();
	Stack<TreeNode> stack = new Stack<TreeNode>();
	public IList<int> PostorderTraversal(TreeNode root)
	{
		if (root == null) return result;
		PostorderTraversallRecursive(root);
		//result.Add(root.val);
		PostorderTraversallRecursive(root.right);
		//PreorderTraversalRecursive(root.right);
		return result;
	}

	private TreeNode PostorderTraversallRecursive(TreeNode node)
	{
		if (node == null)
		{
			return null;
		}
		if (node.left != null && node.right != null)
		{
			stack.Push(node.right);
			stack.Push(node.left);
			node = PostorderTraversallRecursive(node.left);
			result.Add(node.val);
			if (node.left != null && node.right != null)
			{
				node = PostorderTraversallRecursive(node);
			}
			if (node.left != null)
			{
				stack.Push(node.left);
				node = PostorderTraversallRecursive(node.left);
				result.Add(node.val);
				//node = stack.Pop();
			}
			if (node.right != null)
			{
				stack.Push(node.right);
				node = PostorderTraversallRecursive(node.right);
				result.Add(node.val);
				//node = stack.Pop();
			}
		}
		if (stack.Count > 0)
		{
			//result.Add(node.val);
			return stack.Pop();
		}
		return null;
	}

	public IList<int> PreorderTraversal(TreeNode root)
	{
		if (root == null) return result;
		result.Add(root.val);
		PreorderTraversalRecursive(root.left);
		PreorderTraversalRecursive(root.right);
		return result;
	}
	private TreeNode PreorderTraversalRecursive(TreeNode node)
	{
		if (node == null)
		{
			return null;
		}
		result.Add(node.val);

		if (node.left != null)
		{
			stack.Push(node);
			node = PreorderTraversalRecursive(node.left);
		}
		if (node.right != null)
		{
			stack.Push(node);
			node = PreorderTraversalRecursive(node.right);
		}
		if (stack.Count > 0)
		{
			return stack.Pop();
		}
		return null;
	}



	public int MaxProfit(int[] prices)
	{
		int min = prices.Min();
		int indexMin = Array.IndexOf(prices, min);
		if (indexMin == prices.Length - 1)
		{
			int a = prices[indexMin];
			Array.Resize(ref prices, prices.Length - 1);
			min = prices.Min();
			Array.Resize(ref prices, prices.Length + 1);
			prices[prices.Length - 1] = a;
			indexMin = Array.IndexOf(prices, min);
		}
		int differ = 0;// Math.Abs(min - prices[indexMin + 1]);
		for (int i = indexMin + 2; i < prices.Length; i++)
		{
			if (Math.Abs(min - prices[i]) > differ)
			{
				differ = Math.Abs(min - prices[i]);
			}
		}
		return differ;
	}
	public bool IsPalindrome(string s)
	{
		if (s.Length == 1) return true;
		var onlyLetters = new String(s.Where(c => Char.IsLetter(c) || Char.IsNumber(c)).ToArray());
		char[] chars = onlyLetters.ToCharArray();
		if (chars.Length == 1 || chars.Length == 0) { return true; }
		int count = onlyLetters.Length / 2 + 1;
		for (int i = 0; i < count; i++)
		{
			if (Char.ToLower(chars[i]) == Char.ToLower(chars[chars.Length - i - 1]))
			{
				continue;
			}
			else
			{
				return false;
			}
		}
		return true;
	}
	public class TreeNode
	{
		public int val;
		public TreeNode left;
		public TreeNode right;
		public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
		{
			this.val = val;
			this.left = left;
			this.right = right;
		}
	}
	public bool IsValid(string s)
	{
		char[] chars = s.ToCharArray();
		if (chars[0] == '}' || chars[0] == ')' || chars[0] == ']')
		{
			return false;
		}
		if (chars[chars.Length - 1] == '{' || chars[chars.Length - 1] == '(' || chars[chars.Length - 1] == '[')
		{
			return false;
		}
		if (chars.Length % 2 != 0)
		{
			return false;
		}
		Stack<char> stack = new Stack<char>();
		for (int i = 0; i < s.Length; i++)
		{
			if (chars[i] == '{' || chars[i] == '(' || chars[i] == '[')
			{
				stack.Push(chars[i]);
				continue;
			}
			if (stack.Count == 0)
			{
				return false;
			}
			char charFromStack = stack.Pop();
			if (chars[i] == '}' || chars[i] == ')' || chars[i] == ']')
			{
				if (charFromStack == '{' && chars[i] == '}')
				{
					continue;
				}
				else if (charFromStack == '(' && chars[i] == ')')
				{
					continue;
				}
				else if (charFromStack == '[' && chars[i] == ']')
				{
					continue;
				}
				else
				{
					stack.Push(charFromStack);
					stack.Push(chars[i]);
				}
			}
		}
		if (stack.Count == 0)
		{
			return true;
		}
		return false;
	}
	public int[] PlusOne(int[] digits)
	{
		int firstdigit = digits[0];
		int currNotChanged = digits[digits.Length - 1] + 1;
		if (digits.Length == 1 && digits[0] == 9)
		{

			return new int[] { 1, 0 };
		}
		if (digits.Length == 1)
		{
			digits[0]++;
			return digits;
		}
		for (int i = digits.Length - 1; i >= 0; i--)
		{
			if (currNotChanged < 9 && i != 0 || digits[i] == 8)
			{
				if (digits[i] != 9 && i != digits.Length - 1)
				{
					if (digits[i + 1] != 0)
						digits[i]++;
				}
				else if (i == digits.Length - 1)
				{
					digits[i]++;
				}
				break;
			}
			if (i == 0 && firstdigit == 9)
			{
				Array.Resize(ref digits, digits.Length + 1);
				digits[1] = 0;
				digits[i] = 1;
				break;
			}
			else if (i != 0)
			{
				digits[i] = 0;
				currNotChanged = digits[i - 1];
				digits[i - 1] = digits[i - 1] + 1;
			}
		}
		return digits;
	}

	public ListNode MergeTwoLists(ListNode list1, ListNode list2)
	{
		if (list1 != null && list2 == null)
		{
			return list1;
		}
		else if (list1 == null && list2 != null) { return list2; }
		if (list1 == null && list2 == null) { return null; }
		ListNode result = new ListNode();
		ListNode currNode = result;
		while (list1 != null && list2 != null)
		{
			if (list1.val <= list2.val)
			{
				currNode.next = list1;
				currNode = currNode.next;
				list1 = list1.next;
			}
			else
			{
				currNode.next = list2;
				currNode = currNode.next;
				list2 = list2.next;
			}
		}
		if (list1 != null && list2 == null)
		{
			while (list1 != null)
			{
				currNode.next = list1;
				currNode = currNode.next;
				list1 = list1.next;
			}
		}
		if (list1 == null && list2 != null)
		{
			while (list2 != null)
			{
				currNode.next = list2;
				currNode = currNode.next;
				list2 = list2.next;
			}
		}
		result = result.next;

		return result;
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
	public String longestCommonPrefix(String[] strs)
	{
		if (strs == null || strs.Length == 0) return "";
		string prefix = strs[0];
		for (int i = 1; i < strs.Length; i++)
		{
			while (strs[i].IndexOf(prefix) != 0)
			{
				prefix = prefix.Substring(0, prefix.Length - 1);
				if (prefix == "") return "";
			}
		}

		return prefix;
	}
	public bool EqualFrequency(string word)
	{
		char[] chars = word.ToCharArray();
		bool result = false;
		for (int i = 0; i < chars.Length; ++i)
		{
			for (int j = i + 1; j < chars.Length; ++j)
			{
				if (chars[i] == chars[j])
				{
					if (result == false)
					{
						result = true;
					}
					else
					{
						return false;
					}
				}
			}
		}
		return true;
	}
}