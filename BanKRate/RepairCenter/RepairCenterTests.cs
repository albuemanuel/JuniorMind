using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RepairCenter
{
    [TestClass]
    public class RepairCenterTests
    {
        [TestMethod]
        public void PlacementAtIndex()
        {
            Case[] cases = new Case[] { new Case("frigider", Priority.Low), new Case("masina", Priority.High), new Case("masina de spalat", Priority.Medium), new Case("tractor", Priority.High), new Case("buldozer", Priority.Low) };
            PlaceAtIndex(cases, 1, 0);
            Assert.AreEqual("masina, frigider, masina de spalat, tractor, buldozer", DisplayListOfCases(cases));
        }

        [TestMethod]
        public void DescriptionsOfCasesOrderedByPriority()
        {
            Case[] cases = new Case[] { new Case("frigider", Priority.Low), new Case("masina", Priority.High), new Case("masina de spalat", Priority.Medium), new Case("tractor", Priority.High), new Case("buldozer", Priority.Low) };
            //int[] indexes = SortCases(cases);

            Assert.AreEqual("tractor, masina, masina de spalat, frigider, buldozer", DisplayListOfCases(SortCases(cases)));
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

        void PlaceAtIndex(Case[] cases, int current, int index)
        {
            if (current == index)
                return;

            if(current < index)
            {
                for (int i = current; i < index; i++)
                    Swap(ref cases[i], ref cases[i + 1]);
            }

            if(current >index)
            {
                for (int i = current; i > index; i--)
                    Swap(ref cases[i], ref cases[i - 1]);
            }
        }

        string DisplayListOfCases(Case[] cases)
        {
            string casesDescriptions = "";

            for (int i = 0; i < cases.Length - 1; i++)
                casesDescriptions += cases[i] + ", ";
            casesDescriptions += cases[cases.Length - 1];

            return casesDescriptions;
        }

        void Swap(ref Case a, ref Case b)
        {
            Case temp = a;
            a = b;
            b = temp;
        }

        Case[] SortCases(Case[] cases)
        {
            int p = 0;

            for(int i = 0; i<cases.Length; i++)
            {
                if (cases[i].priority == Priority.Low)
                {
                    PlaceAtIndex(cases, i, cases.Length - 1);
                }
                if (cases[i].priority == Priority.Medium)
                {
                    PlaceAtIndex(cases, i, p);
                }
                if(cases[i].priority == Priority.High)
                {
                    PlaceAtIndex(cases, i, 0);
                    p++;
                }
            }

            return cases;
        }
    }
}
