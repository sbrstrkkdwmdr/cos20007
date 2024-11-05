namespace Identifiable
{
    internal class Program
    {
        private static Processor _processor;
        private static Player _player;
        static void Main(string[] args)
        {
            _processor = new Processor();
            Location destination = new Location(["roomSecond"], "Another room", "hello", []);
            Path path = new Path("south", "this is a path", "description", destination);
            List<Path> paths = new List<Path>() { path };
            Location location = new Location(["room"], "A room", "This is a room!", paths);

            Console.WriteLine("Hello!");
            Console.WriteLine("Please enter your name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Please enter a description: ");
            var desc = Console.ReadLine();
            _player = new Player(name!, desc!, location);

            Console.WriteLine("");
            Item item1 = new Item(["item_first"], "first item", "This is the first test item!");
            Item item2 = new Item(["item_second"], "second item", "This is the second test item!");
            _player.Inventory.Put(item1);
            _player.Inventory.Put(item2);
            Bag _bag = new Bag(["bag"], "main bag", "This is the main bag");
            _player.Inventory.Put(_bag);
            Item _item3 = new Item(["bagitem"], "test item", "this is an item inside a bag!");
            _bag.Inventory.Put(_item3);
            while (true)
            {
                Console.WriteLine("---------\nPlease input your command: ");
                string input = Console.ReadLine()!;
                try
                {
                    string output = _processor.Execute(input.Split(' '), _player);
                    Console.WriteLine($"->\n{output}\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
