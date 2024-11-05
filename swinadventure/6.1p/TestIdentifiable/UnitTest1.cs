using Identifiable;

namespace TestIdentifiable
{
    public class Tests
    {
        Command LookAt = new LookCommand();
        [Test]
        public void LookAtMe()
        {
            Player p = new Player("player", "The player");
            var x = LookAt.Execute(p, ["look", "at", "inventory"]);
            var y = p.FullDescription;
            Assert.That(x, Is.EqualTo(y));
        }
        [Test]
        public void LookAtGem()
        {
            Player p = new Player("player", "The player");
            Item _itemGem = new Item(["gem"], "a gem", "This is a gem!");
            p.Inventory.Put(_itemGem);
            var x = LookAt.Execute(p, ["look", "at", "gem"]);
            var y = _itemGem.FullDescription;
            Assert.That(x, Is.EqualTo(y));
        }
        [Test]
        public void LookAtUnk()
        {
            Player p = new Player("player", "The player");
            var x = LookAt.Execute(p, ["look", "at", "gem"]);
            Assert.That(x, Is.EqualTo("I can't find the gem"));
        }
        [Test]
        public void LookAtGemInMe()
        {
            Player p = new Player("player", "The player");
            Item _itemGem = new Item(["gem"], "a gem", "This is a gem!");
            p.Inventory.Put(_itemGem);
            var x = LookAt.Execute(p, ["look", "at", "gem", "in", "inventory"]);
            var y = _itemGem.FullDescription;
            Assert.That(x, Is.EqualTo(y));
        }
        [Test]
        public void LookAtGemInBag()
        {
            Player p = new Player("player", "The player");
            Item _itemGem = new Item(["gem"], "a gem", "This is a gem!");
            Bag _bag = new Bag(["bag"], "a bag", "This is a bag!");
            _bag.Inventory.Put(_itemGem);
            p.Inventory.Put(_bag);
            var x = LookAt.Execute(p, ["look", "at", "gem", "in", "bag"]);
            var y = _itemGem.FullDescription;
            Assert.That(x, Is.EqualTo(y));
        }
        [Test]
        public void LookAtGemInNoBag()
        {
            Player p = new Player("player", "The player");
            Item _itemGem = new Item(["gem"], "a gem", "This is a gem!");
            Bag _bag = new Bag(["bag"], "a bag", "This is a bag!");
            _bag.Inventory.Put(_itemGem);
            var x = LookAt.Execute(p, ["look", "at", "gem", "in", "bag"]);
            var y = "I cannot find bag";
            Assert.That(x, Is.EqualTo(y));
        }
        [Test]
        public void LookAtNoGemInBag()
        {
            Player p = new Player("player", "The player");
            Bag _bag = new Bag(["bag"], "a bag", "This is a bag!");
            p.Inventory.Put(_bag);
            var x = LookAt.Execute(p, ["look", "at", "gem", "in", "bag"]);
            var y = "I can't find the gem";
            Assert.That(x, Is.EqualTo(y));
        }
        [Test]
        public void InvalidLook()
        {
            Player p = new Player("player", "The player");
            var x = LookAt.Execute(p, ["look", "around"]);
            var y = LookAt.Execute(p, ["hello", "the", "me"]);
            var z = LookAt.Execute(p, ["look", "at", "me", "when", "the"]);
            Assert.That(x, Is.EqualTo("I don't know how to look like that"));
            Assert.That(y, Is.EqualTo("Error in look input"));
            Assert.That(z, Is.EqualTo("What do you want to look in?"));
            var a = LookAt.Execute(p, ["hello", "STUDENT_ID"]);
            var b = LookAt.Execute(p, ["look", "at", "FIRSTNAME",]);
            //using student ID and name
            Assert.That(a, Is.EqualTo("I don't know how to look like that"));
            Assert.That(b, Is.EqualTo("I can't find the FIRSTNAME"));
        }
    }
}