namespace Identifiable
{
    internal class Program
    {
        private static Command _command = new LookCommand();
        private static Player _player;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");
            Console.WriteLine("Please enter your name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Please enter a description: ");
            var desc = Console.ReadLine();
            var location = new Location(["entrance"], "A room", "This is a large room with very little lighting, making it hard to see.");
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
            argLoop();
        }
        static void argLoop()
        {
            Console.WriteLine("---------");
            Console.WriteLine("Please input your command: ");
            string input = Console.ReadLine()!;
            string[] exitKeys = ["exit", "q", "end"];
            if (exitKeys.Any(input.Equals))
            {
                Console.WriteLine("Closing program...");
                Environment.Exit(0);
            }
            string[] inputSplit = input.Split(' ');
            string output = _command.Execute(_player, inputSplit);
            Console.WriteLine("->");
            Console.WriteLine(output);
            Console.WriteLine("");
            argLoop();
        }
    }
}
