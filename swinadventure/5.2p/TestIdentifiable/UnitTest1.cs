using Identifiable;

namespace TestIdentifiable
{
    public class Tests
    {
        [Test]
        public void BagLocatesItems()
        {
            Bag _bag = new Bag(["bag"], "a bag", "description");
            Item _itemBow = new Item(["bow"], "a bow", "description");
            Item _itemSword = new Item(["sword"], "a sword", "description");
            _bag.Inventory.Put(_itemSword);
            _bag.Inventory.Put(_itemBow);
            Assert.That(_bag.Locate("sword").Equals(_itemSword));
        }
        [Test]
        public void BagLocatesSelf()
        {
            Console.WriteLine("swprdddq");

            Bag _bag = new Bag(["bag"], "a bag", "description");
            Assert.That(_bag.Locate("bag").Equals(_bag));
        }
        [Test]
        public void BagLocatesNothing()
        {
            Bag _bag = new Bag(["bag"], "a bag", "description");
            Assert.That(_bag.Locate("non-existent item") == null);
        }
        [Test]
        public void BagDescription()
        {
            Bag _bag = new Bag(["bag"], "bagName", "description");
            Item _itemBow = new Item(["bow"], "a bow", "description");
            Item _itemSword = new Item(["sword"], "a sword", "description");
            _bag.Inventory.Put(_itemBow);
            _bag.Inventory.Put(_itemSword);
            Assert.That(_bag.FullDescription.Contains("In the bagName you can see:"));
            Assert.That(_bag.FullDescription.Contains("a sword"));
            Assert.That(_bag.FullDescription.Contains("a bow"));
        }
        [Test]
        public void BagInBag()
        {
            Bag _bag = new Bag(["b1"], "b1", "description");
            Item _itemBow = new Item(["bow"], "a bow", "description");
            Item _itemSword = new Item(["sword"], "a sword", "description");
            _bag.Inventory.Put(_itemBow);
            _bag.Inventory.Put(_itemSword);
            
            Bag _bag2 = new Bag(["b2"], "b2", "description");
            Item _itemStaff = new Item(["staff"], "a staff", "description");
            //_bag2.Inventory.Put(_itemStaff);
            _itemStaff.PrivilegeEscalation("STUDENT_ID");
            _bag2.Inventory.Put(_itemStaff);
            _bag.Inventory.Put(_bag2);

            Assert.That(_bag.Locate("b2").Equals(_bag2)); // locate bag 2
            Assert.That(_bag.Locate("sword").Equals(_itemSword)); // locate items in bag 1
            Assert.That(_bag.Locate("staff") == null); // items in bag 2 should not be found
            Assert.That(_bag.Locate("0007") == null); // items in bag 2 should not be found
        }
    }
}