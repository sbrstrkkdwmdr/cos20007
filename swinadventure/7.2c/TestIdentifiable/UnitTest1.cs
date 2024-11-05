using Identifiable;

namespace TestIdentifiable
{
    public class Tests
    {
        Location location = new Location(["room"], "A room", "This is a room!");
        [Test]
        public void IdentifySelf()
        {
            Assert.That(location.FirstId, Is.EqualTo("room"));
        }
        [Test]
        public void LocateItems()
        {
            Item sword = new Item(["sword"], "Big sword", "A massive sword!");
            location.Inventory.Put(sword);
            Assert.That(location.Locate("sword").FirstId, Is.EqualTo(sword.FirstId));
        }
        [Test]
        public void PlayerLocateItems()
        {
            Item sword = new Item(["sword"], "Big sword", "A massive sword!");
            location.Inventory.Put(sword);
            Player p = new Player("player", "The player", location);
            Assert.That(p.Locate("sword").FirstId, Is.EqualTo(sword.FirstId));
        }
    }
}