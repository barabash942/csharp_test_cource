using NUnit.Framework;

namespace addressbook_web_tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestSquare()
        {
            Square s1 = new Square(7);
            Square s2 = new Square(10);
            Square s3 = s1;

            Assert.AreEqual(s1.Size, 7);
            Assert.AreEqual(s2.Size, 10);
            Assert.AreEqual(s3.Size, 7);

            s3.Size = 15;
            Assert.AreEqual(s1.Size, 15);

            s2.Colored = true;
            Assert.IsTrue(s2.Colored);
        }

        [Test]
        public void TestCircle()
        {
            Circle s1 = new Circle(7);
            Circle s2 = new Circle(10);
            Circle s3 = s1;

            Assert.AreEqual(s1.Radius, 7);
            Assert.AreEqual(s2.Radius, 10);
            Assert.AreEqual(s3.Radius, 7);

            s3.Radius = 15;
            Assert.AreEqual(s1.Radius, 15);

            s2.Colored = false;
            Assert.IsFalse(s2.Colored);
        }
    }
}