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
            Section section1 = new Section("rrruuu", new Point(0, 0));
            Section section2 = new Section("uurrr", new Point(0, 1));
            Section[] sections = new Section[] { section1, section2 };
            Point intPoint;

            Assert.IsTrue(DetermineFirstIntersectionPoint(sections, out intPoint));
            Assert.AreEqual(new Point(3, 3), intPoint);
        }

        [TestMethod]
        public void SectionInit()
        {
            Section section = new Section("rrruuu", new Point(0, 0));

            Assert.AreEqual("(0, 0), (1, 0), (2, 0), (3, 0), (3, 1), (3, 2), (3, 3)", section.ToString());
        }

        [TestMethod]
        public void PointIsPartOfSection()
        {
            Section section = new Section("rrruuu", new Point(0, 0));

            Assert.IsTrue(section.HasPoint(new Point(2, 0)));
            Assert.IsFalse(section.HasPoint(new Point(2, 1)));
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

            public Point[] SectionPoints => sectionPoints;

            public bool HasPoint(Point point)
            {
                for(int i=0; i<sectionPoints.Length; i++)
                {
                    if (point.Equals(sectionPoints[i]))
                        return true;
                }
                return false;
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

        bool DetermineFirstIntersectionPoint(Section[] sections, out Point intPoint)
        {
            Section firstSection = sections[0];

            for (int i = 0; i < firstSection.SectionPoints.Length; i++)
            {
                for (int j = 1; j < sections.Length; j++)
                {
                    if (!(sections[j].HasPoint(firstSection.SectionPoints[i])))
                        break;
                    intPoint = firstSection.SectionPoints[i];
                    return true;
                }
            }
            intPoint = new Point();
            return false;
        }



    }
}
