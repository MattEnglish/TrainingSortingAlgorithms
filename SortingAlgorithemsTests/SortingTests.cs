using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingAlgorithems;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithems.Tests
{
    [TestClass()]
    public class SortingTests
    {

        private bool IsListInOrder(List<int> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i] < list[i - 1])
                {
                    return false;
                }
            }
            return true;
        }

        [TestMethod()]
        public void SelectionSortTest()
        {
            var list = Sorting.GenerateRandomList();
            Sorting.SelectionSort(list);
            Assert.IsTrue(IsListInOrder(list));
        }

        [TestMethod()]
        public void InsertionSortTest()
        {
            var list = Sorting.GenerateRandomList();
            Sorting.InsertionSort(list);
            Assert.IsTrue(IsListInOrder(list));
        }

        [TestMethod()]
        public void MergeSortTest()
        {
            var list = Sorting.GenerateRandomList();
            list = Sorting.MergeSort(list);
            Assert.IsTrue(IsListInOrder(list));
        }
    }
}