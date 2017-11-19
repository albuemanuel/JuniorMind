using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RepairCenter
{
    [TestClass]
    public class RepairCenterTests
    {
        [TestMethod]
        public void CaseOrderdedByPriority()
        {
            Case[] cases = new Case[] { new Case("frigider", Priority.Low), new Case("masina", Priority.High), new Case("masina de spalat", Priority.Medium), new Case("tractor", Priority.High), new Case("buldozer", Priority.Low) };
            CollectionAssert.AreEqual(new int[] { 3, 1, 2, 0, 4 }, SortCases(cases));
        }

        [TestMethod]
        public void PlacementOfIntAtIndex()
        {
            CollectionAssert.AreEqual(new int[] { 2, 3, 10, 5, 4 }, PlaceIntAtIndex(new int[] { 2, 3, 5, 4 }, 10, 2));
            CollectionAssert.AreEqual(new int[] { 2, 3, 5, 10, 4 }, PlaceIntAtIndex(new int[] { 2, 3, 5, 4 }, 10, 3));
            CollectionAssert.AreEqual(new int[] { 2, 3, 5, 4, 10 }, PlaceIntAtIndex(new int[] { 2, 3, 5, 4 }, 10, 4));
        }

        [TestMethod]
        public void DescriptionsOfCasesOrderedByPriority()
        {
            Case[] cases = new Case[] { new Case("frigider", Priority.Low), new Case("masina", Priority.High), new Case("masina de spalat", Priority.Medium), new Case("tractor", Priority.High), new Case("buldozer", Priority.Low) };
            int[] indexes = SortCases(cases);
            
            Assert.AreEqual("tractor, masina, masina de spalat, frigider, buldozer", DisplayListOfCasesInGivenOrder(cases, indexes));
        }

        struct Case
        {
            public Priority priority;
            public string description;

            public Case(string description, Priority priority)
            {
                this.priority = priority;
                this.description = description;
            }

            public override string ToString()
            {
                return description;
            }
        }

        enum Priority
        {
            Low,
            Medium,
            High
        }

        int[] PlaceIntAtIndex(int[] arr, int value, int index)
        {
            if (arr == null)
                return new int[1] { value };

            int[] newArr = new int[arr.Length + 1];

            if (index == arr.Length)
            {
                Array.Copy(arr, newArr, arr.Length);
                newArr[index] = value;
                return newArr;
            }

            Array.Copy(arr, newArr, index);
            newArr[index] = value;
            Array.Copy(arr, index, newArr, index + 1, arr.Length - index);

            return newArr;
        }

        string DisplayListOfCasesInGivenOrder(Case[] cases, int[] indexes)
        {
            string casesDescriptions = "";
            for (int i = 0; i < indexes.Length - 1; i++)
                casesDescriptions += cases[indexes[i]] + ", ";
            casesDescriptions += cases[indexes[indexes.Length - 1]];

            return casesDescriptions;
        }

        int[] SortCases(Case[] cases)
        {
            int[] indexes = new int[0];
            int p = 0;

            for(int i = 0; i<cases.Length; i++)
            {
                if (cases[i].priority == Priority.Low)
                {
                    indexes = PlaceIntAtIndex(indexes, i, indexes.Length);
                }
                if (cases[i].priority == Priority.Medium)
                {
                    indexes = PlaceIntAtIndex(indexes, i, p);
                }
                if(cases[i].priority == Priority.High)
                {
                    indexes = PlaceIntAtIndex(indexes, i, 0);
                    p++;
                }
            }

            return indexes;
        }
    }
}
