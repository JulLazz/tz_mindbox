using Microsoft.VisualStudio.TestTools.UnitTesting;
using tz_mindbox;

namespace FigureUnitTest
{
    [TestClass]
    public class FigureTests
    {
        [TestMethod]
        public void SquareCircle()
        {
            double expectedResult = 314;

            var circle = new Circle(10);
            var actualResult = circle.Square();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void SquareTriangle()
        {
            double expectedResult = 43.30127;

            var triangle = new Triangle(10, 10, 10);
            var actualResult = triangle.Square();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void RightTriangle()
        {
            var triangle = new Triangle(5, 4, 3 );

            var actualResult = triangle.IsRightTriangle();
            Assert.IsTrue(actualResult);
        }

        [TestMethod]
        public void NotRightTriangle() 
        {
            var triangle = new Triangle(5, 5, 5);

            var actualResult = triangle.IsRightTriangle();
            Assert.IsFalse(actualResult);
        }
    }
}