using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intersection
{
    [TestClass]
    public class IntersectionTests
    {
        //[TestMethod]
        //public void FirstIntersectionPoint()
        //{
        //    Section section1 = new Section(new byte[] { 0, 0, 0, 1, 1, 1 });
        //    Section section2 = new Section(new byte[] { 1, 1, 1, 0, 0, 0 });
        //    Section[] sections = new Section[] { section1, section2 };

        //    Assert.AreEqual(new Point(3,3), DetermineFirstIntersectionPoint(new Map(sections)));
        //}

        [TestMethod]
        public void SectionInit()
        {
            Section section = new Section("rrruuu", new Point(0, 0));

            Assert.AreEqual("(0, 0), (1, 0), (2, 0), (3, 0), (3, 1), (3, 2), (3, 3)", section.ToString());
        }

        struct Section
        {
            Point[] sectionPoints;

            
            public Section(string section, Point startPos)
            {
                sectionPoints = new Point[section.Length + 1];
                sectionPoints[0] = startPos;

                for(int i=0; i<section.Length; i++)
                {
                    sectionPoints[i + 1] = TransformToPoint(sectionPoints[i], section[i]);

                }
            }

            Point TransformToPoint(Point a, char direction)
            {
                switch (direction)
                {
                    case 'l':
                        a.x--;
                        break;
                    case 'r':
                        a.x++;
                        break;
                    case 'd':
                        a.y--;
                        break;
                    case 'u':
                        a.y++;
                        break;
                }
                return a;
            }

            override public string ToString()
            {
                string sectionString = "";
                for(int i=0; i<sectionPoints.Length; i++)
                {
                    if (i == sectionPoints.Length - 1)
                        sectionString += "(" + sectionPoints[i].x + ", " + sectionPoints[i].y + ")";
                    else
                        sectionString += "(" + sectionPoints[i].x + ", " + sectionPoints[i].y + "), ";
                }
                return sectionString;
            }

        }

        struct Map
        {
            Section[] sections;
            
            public Map(Section[] sections)
            {
                this.sections = sections;
            }

            public Section[] Sections => sections;

        }

        struct Point
        {
            public int x;
            public int y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        //Point DetermineFirstIntersectionPoint(Section[] sections)
        //{
        //    return
        //}

        

    }
}
