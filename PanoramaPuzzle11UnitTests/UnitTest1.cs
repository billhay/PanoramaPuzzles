namespace PanoramaPuzzle11UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PanoramaPuzzle11;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPersonConstructor()
        {
            Person p1 = new Person(Name.David, Vegetable.Brocolli, Cheese.Brie, Meat.Chicken);
            Assert.AreEqual(Name.David, p1.Name);
            Assert.AreEqual(Vegetable.Brocolli, p1.Vegetable);
            Assert.AreEqual(Cheese.Brie, p1.Cheese);
            Assert.AreEqual(Meat.Chicken, p1.Meat);
            Assert.AreEqual(Gender.Male, p1.Gender);
            Assert.AreEqual(0x0001000100010001ul, p1.ThumbPrint);
        }

        [TestMethod]
        public void TestPersonDistinctSucceed()
        {
            Person p1 = new Person(Name.David, Vegetable.Brocolli, Cheese.Brie, Meat.Chicken);
            Person p2 = new Person(Name.John, Vegetable.Avocados, Cheese.Havarti, Meat.GroundBeef);
            Assert.IsTrue(Person.Distinct(p1, p2));
        }

        [TestMethod]
        public void TestPersonDistinctFailed()
        {
            Person p1 = new Person(Name.David, Vegetable.Brocolli, Cheese.Brie, Meat.Chicken);
            Person p2 = new Person(Name.John, Vegetable.Avocados, Cheese.Brie, Meat.GroundBeef);
            Assert.IsFalse(Person.Distinct(p1, p2));
        }
    }
}