using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmPractice;

namespace AlgorithmPracticeUnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod_MaxSubArray()
        {
            Console.WriteLine( Program.MaxSubArray(new int[] { -1,-3}));
        }

        [TestMethod]
        public void Test_DeleteDuplicateFromSortedList()
        {
            Solution solution = new Solution();
            var a1 = new ListNode(2);
            var a2 = new ListNode(2);            
            var a3= new ListNode(2);
            var a4 = new ListNode(2);
            var a5 = new ListNode(2);
            a1.next = a2;
            a2.next = a3;
            a3.next = a4;
            a4.next = a5;

            solution.DeleteDuplicates(new ListNode(6));
        }

        [TestMethod]
        public void Test_SquareRoot()
        {
            Console.WriteLine(Program.MySqrt(2147395599));
        }

        [TestMethod]
        public void Test_BuildTree()
        {
            Solution solution = new Solution();
            var root=solution.BuildTree(new int[] { 1, 2, 2, 3, 4, 4, 3,5});
            Console.WriteLine(solution.MaxDepth(root));
        }
    }
}
