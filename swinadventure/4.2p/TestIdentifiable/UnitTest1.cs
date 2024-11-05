using Identifiable;

namespace TestIdentifiable
{
    public class Tests
    {

        Item _item = new Item(["sword"], "a sword", "description");
        Inventory _inventory = new Inventory();
        Player _player = new Player("player", "this is the player");
        [Test]
        public void ItemAreYou()
        {
            Assert.That(_item.AreYou("sword"));
        }
        [Test]
        public void ItemShortDescription()
        {
            Assert.That(_item.ShortDescription == "a sword (sword)");
        }
        [Test]
        public void ItemFullDescription()
        {
            Assert.That(_item.FullDescription == "description");
        }

        [Test]
        public void InventoryFindItem()
        {
            _inventory = new Inventory();
            _inventory.Put(_item);
            Assert.That(_inventory.HasItem(_item.FirstId));
        }
        [Test]
        public void InventoryNoItemFind()
        {
            _inventory = new Inventory();
            Assert.That(!_inventory.HasItem(_item.FirstId));
        }
        [Test]
        public void InventoryFetchItem()
        {
            _inventory = new Inventory();
            _inventory.Put(_item);
            Assert.That(_inventory.Fetch(_item.FirstId) == _item);
        }
        [Test]
        public void InventoryTakeItem()
        {
            _inventory = new Inventory();
            _inventory.Put(_item);
            _inventory.Take(_item.FirstId);
            Assert.That(!_inventory.HasItem(_item.FirstId));
        }
        [Test]
        public void InventoryItemList()
        {
            _inventory = new Inventory();
            _inventory.Put(_item);
            _inventory.Put(_item);
            _inventory.Put(_item);
                Assert.That(_inventory.ItemList.Contains(_item.ShortDescription));
        }
        [Test]
        public void PlayerIdentifiable()
        {
            Assert.That(_player.AreYou("me"));
            Assert.That(_player.AreYou("inventory"));
        }
        [Test]
        public void PlayerLocateItems()
        {
            Item _itemBow = new Item(["bow"], "a bow", "description");
            _player.Inventory.Put(_itemBow);
            Assert.That(_player.Locate(_itemBow.FirstId).FirstId == _itemBow.FirstId);
        }
        [Test]
        public void PlayerLocateSelf()
        {
            Assert.That(_player.Locate("me") == _player);
            Assert.That(_player.Locate("inventory") == _player);
        }
        [Test]
        public void PlayerLocateNothing()
        {
            Assert.That(_player.Locate("notreal") == null);
        }
        [Test]
        public void PlayerDescription()
        {
            Item _itemBow = new Item(["bow"], "a bow", "description");
            _player.Inventory.Put(_itemBow);
            Assert.That(_player.FullDescription.Contains("You are"));
            Assert.That(_player.FullDescription.Contains("You are carrying"));
            Assert.That(_player.FullDescription.Contains("a bow"));
        }

    }
}