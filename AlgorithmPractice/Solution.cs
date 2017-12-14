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
    }
}
