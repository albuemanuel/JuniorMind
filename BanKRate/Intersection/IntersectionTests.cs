using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intersection
{
    [TestClass]
    public class IntersectionTests
    {
        [TestMethod]
        public void FirstIntersectionPoint()
        {
            Section section1 = new Section(new byte[] { 0, 0, 0, 1, 1, 1 });
            Section section2 = new Section(new byte[] { 1, 1, 1, 0, 0, 0 });
            Section[] sections = new Section[] { section1, section2 };

            Assert.AreEqual(new Point(3,3), DetermineFirstIntersectionPoint(new Map(sections)));
        }

        struct Section
        {
            byte[] section;


            public Section(byte[] section)
            {
                this.section = section;

            }
        }

        struct Map
        {
            Section[] sections;
            
            public Map(Section[] sections)
            {
                this.sections = sections;
            }
           
        }

        struct Point
        {
            byte x;
            byte y;

            public Point(byte x, byte y)
            {
                this.x = x;
                this.y = y;
            }
        }

        Point DetermineFirstIntersectionPoint(Map map)
        {
            return new Point(0, 0);
        }

    }
}
