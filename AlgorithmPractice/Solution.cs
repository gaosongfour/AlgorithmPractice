using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmPractice
{
   
     //Definition for singly-linked list.
     public class ListNode
    {
         public int val;
         public ListNode next;
         public ListNode(int x) { val = x; }
     }
    // Definition for a binary tree node.
    public class TreeNode
    {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
    }

    public class Solution
    {
        public ListNode DeleteDuplicates(ListNode head)
        {
            ShowListNodes(head);
            if (head == null)
                return head;
            var previsous = head;
            var next = head.next;
            while(next!=null)
            {
                if(previsous.val==next.val)
                {
                    if (next.next == null)
                    {
                        previsous.next = null;
                        break;
                    }
                    else
                        next = next.next;
                }else
                {
                    previsous.next = next;
                    previsous = next;
                    next = next.next;
                }
            }
            ShowListNodes(head);
            return head;
        }

        private void ShowListNodes(ListNode head)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(head.val.ToString());
            var next = head.next;
            while(next!=null)
            {
                sb.Append("=>"+next.val);
                next = next.next;
            }

            Console.WriteLine(sb.ToString());
        }

        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
                return true;
            else if (p != null && q != null)
            {
                if (p.val == q.val)
                    return IsSameTree(p.left, q.left) && IsSameTree(p.right,q.right);
                else
                    return false;
            }
            else
                return false;
        }

        public bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;

            return IsSymmetricNode(root.left, root.right);
                
        }
        private bool IsSymmetricNode(TreeNode left, TreeNode right)
        {
            if (left == null && right == null) return true;
            if (left != null && right != null && left.val == right.val)
                return IsSameTreeNode(left.left, left.right) && IsSameTreeNode(right.left, right.right);
            return false;
        }

        public bool IsSymmetricByIteration(TreeNode root)
        {
            if (root == null) return true;

            List<TreeNode> parList = new List<TreeNode>();

            if(IsSameTreeNode(root.left, root.right))
            {
                if (root.left != null) parList.Add(root.left);
                if (root.right != null) parList.Add(root.right);
            }else
            return false;

            while(parList.Count>0)
            {
                if (parList.Count % 2 != 0)
                    return false;
                List<TreeNode> childNodeList = new List<TreeNode>();
                for(int i=0, j=parList.Count-1; i<j; i++,j--)
                {
                    var result=IsSameTreeNode(parList[i].left, parList[j].right)  && IsSameTreeNode(parList[i].right, parList[j].left);
                    if (result == false)
                        return false;
                }
                foreach(var parNode in parList)
                {
                    if (parNode.left != null) childNodeList.Add(parNode.left);
                    if (parNode.right != null) childNodeList.Add(parNode.right);
                }
                parList = childNodeList;
            }

            return true;

        }


        private bool IsSameTreeNode(TreeNode n1, TreeNode n2)
        {
            if (n1 == null && n2 == null) return true;
            if (n1 != null && n2 != null && n1.val == n2.val)
                return true;
            return false;
        }

        public TreeNode BuildTree(int[] nums)
        {
            if ( nums.Length == 0)
                return null;
            TreeNode root = new TreeNode(nums[0]);
            List<TreeNode> pNodeList = new List<TreeNode>() { root};           

            for(int i=1;i<nums.Length;i++)
            {               
                var pNode = pNodeList[0];
                //if (pNodeList[0] == null)
                //{
                //    pNodeList[0] = new TreeNode(nums[i]);
                //    continue;
                //}
                if (pNode.left == null)
                {
                    pNode.left = new TreeNode(nums[i]);
                    pNodeList.Add(pNode.left);
                    continue;
                }
                if (pNode.right == null)
                {
                    pNode.right = new TreeNode(nums[i]);
                    pNodeList.Add(pNode.right);
                    pNodeList.RemoveAt(0);
                }
                
            }

            return root;
        }

        public int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;
            int depthLeft = 1, depthRight = 1;
            if (root.left != null)
                depthLeft += MaxDepth(root.left);

            if (root.right != null)
                depthRight += MaxDepth(root.right);

            return depthLeft >= depthRight ? depthLeft : depthRight;
        }

        //leetcode 107
        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {           
            var result = new List<IList<int>>();
            if (root == null) return result;
            var currentLevelTreeNode = new List<TreeNode> { root };
            while(currentLevelTreeNode.Count>0)
            {
                IList<int> currentLevelValueList = new List<int>();
                List<TreeNode> nextLevelTreeNode = new List<TreeNode>();
                foreach(var node in currentLevelTreeNode)
                {
                    currentLevelValueList.Add(node.val);
                    if (node.left != null) nextLevelTreeNode.Add(node.left);
                    if (node.right != null) nextLevelTreeNode.Add(node.right);
                }
                result.Insert(0, currentLevelValueList);
                currentLevelTreeNode = nextLevelTreeNode;
            }

            return result;
        }

        //leetcode 108
        public TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums == null || nums.Length == 0) return null;
            int mid = nums.Length / 2;
            TreeNode node = new TreeNode(nums[mid]);
            var left = nums.Take(mid).ToArray();
            node.left= SortedArrayToBST(left);
            var right = nums.Skip(mid + 1).Take(nums.Length - mid - 1).ToArray();
            node.right=SortedArrayToBST(right);

            return node;
        }
        public void DispalyTreeNode(TreeNode root)
        {
            if (root == null)
                Console.WriteLine("Tree null");
            var current = new List<TreeNode>() { root };
            while(current.Count>0)
            {
                var next = new List<TreeNode>();
                string currentValue = null;
                foreach(var node in current)
                {
                    if (node.left != null) next.Add(node.left);
                    if (node.right != null) next.Add(node.right);
                    currentValue += node.val.ToString()+" ";
                }
                Console.WriteLine(currentValue);
                current = next;
            }
            
        }

        public int MinDepth(TreeNode root)
        {
            if (root == null) return 0;
            int min = 1;
            var current = new List<TreeNode>() { root };
            while(current.Count>0)
            {
                var next = new List<TreeNode>();
                foreach(var node in current)
                {
                    if(node.left==null && node.right==null)
                    {
                        return min;
                    }else
                    {
                        if (node.left != null) next.Add(node.left);
                        if (node.right != null) next.Add(node.right);
                    }
                }
                current = next;
                min++;
            }

            return min;
        }

        public bool IsBalanced(TreeNode root)
        {
            if (root == null) return true;
            var maxLeft = MaxDepthOfTree(root.left);
            var maxRight = MaxDepthOfTree(root.right);
            bool isThisNodeBalanced= (maxLeft - maxRight) * (maxLeft - maxRight) <= 1;
            return isThisNodeBalanced && IsBalanced(root.left) && IsBalanced(root.right);
        }

        private int MaxDepthOfTree(TreeNode node)
        {
            if (node == null) return 0;            
            var left=1 + MaxDepthOfTree(node.left);
            var right=1 + MaxDepthOfTree(node.right);
            return left >= right ? left : right;
        }

        //LeetCode 112
        public bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null) return false;
            if (root.left == null && root.right == null) return root.val == sum;
            //var result = new List<int>();
            //if (root.left != null)
            //    GetPathSum(root.left,  root.val, ref result);
            //if (root.right != null)
            //    GetPathSum(root.right,  root.val, ref result);

            //foreach (var pathSum in result)
            //    if (pathSum == sum)
            //        return true;

            //return false;
            return GetPathSum(root.left, root.val, sum) || GetPathSum(root.right, root.val, sum);

        }
        private void GetPathSum(TreeNode pNode, int pSum, ref List<int> result)
        {           
            if (pNode.left==null && pNode.right==null ) result.Add( pSum + pNode.val);
            if (pNode.left != null)          
                GetPathSum(pNode.left, pSum + pNode.val, ref result);          
            if (pNode.right != null)      
                GetPathSum(pNode.right, pSum + pNode.val, ref result);    
        }
        private bool GetPathSum(TreeNode pNode, int pSum, int sum)
        {
            if (pNode == null) return false;
            if (pNode.left == null && pNode.right == null) return (pSum + pNode.val)==sum;
           
           return  GetPathSum(pNode.left, pSum + pNode.val, sum) || GetPathSum(pNode.right, pSum + pNode.val, sum);          
              
        }
        //end 112

        //LeetCode 118
        public IList<IList<int>> Generate(int numRows)
        {            
            var result = new List<IList<int>>();
            if (numRows <= 0) return result;
            var row1 = new List<int>() { 1 };
            result.Add(row1);
            var preRow = row1;
            for(int count=2;count<=numRows;count++)
            {
                var currentRow = new List<int>();
                for(int i=0; i<count;i++)
                {
                    if (i < preRow.Count && i - 1 >= 0)
                        currentRow.Add(preRow[i] + preRow[i - 1]);
                    else
                        currentRow.Add(1);
                }
                result.Add(currentRow);
                preRow = currentRow;
            }
            return result;
        }

        //LeetCode 119
        public IList<int> GetRow(int rowIndex)
        {
            var result = new List<int>();
            if (rowIndex <= 0) return result;
            for(int count=1;count<=rowIndex; count++)
            {
                if (count == 1)
                    result.Add(1);
                else
                {                   
                    for(int i=result.Count-1; i>=1;i--)
                    {                        
                        result[i] += result[i-1];                        
                    }
                    result.Add(1);
                }
            }
            Console.WriteLine(string.Join(",", result));
            return result;
        }
    }
}

