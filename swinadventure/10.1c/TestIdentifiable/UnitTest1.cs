using Identifiable;

namespace TestIdentifiable
{
    public class Tests
    {
        [Test]
        public void LookCommand()
        {
            Location location = new Location(["room"], "A room", "This is a room!", []);
            Player _player = new Player("player", "description", location);
            Item item1 = new Item(["item_first"], "first item", "This is the first test item!");
            _player.Inventory.Put(item1);
            Bag _bag = new Bag(["bag"], "main bag", "This is the main bag");
            _player.Inventory.Put(_bag);
            Item _item3 = new Item(["gem"], "gem item", "this is an item inside a bag!");
            _bag.Inventory.Put(_item3);
            var processor = new Processor();
            var output = processor.Execute(["look", "at", "gem", "in", "bag"], _player);
            Assert.That(output, Is.EqualTo("this is an item inside a bag!"));
        }
        [Test]
        public void MoveCommand()
        {
            Location destination = new Location(["roomSecond"], "Another room", "hello", []);
            Identifiable.Path path = new Identifiable.Path("north", "this is a path", "this is a valid path", destination);
            List<Identifiable.Path> paths = new List<Identifiable.Path>() { path };
            Location location = new Location(["room"], "A room", "This is a room!", paths);
            Player _player = new Player("player", "description", location);
            var processor = new Processor();
            var output = processor.Execute(["move", "north"], _player);
            Assert.That(_player.Location, Is.EqualTo(destination));
        }
        [Test]
        public void InvalidCommand()
        {
            try
            {
                var processor = new Processor();
                Player _player = new Player("player", "description", null);
                var output = processor.Execute(["invalid command"], _player);
            }
            catch (Exception e)
            {
                Assert.That(e.Message.Contains("is not a valid command"));
            }
        }
    }
}