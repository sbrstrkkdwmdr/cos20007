namespace ConsoleApp1
{
    internal class Program
    {
        static void Main()
        {
            Message myMessage = new Message("Hello, World! Greetings from Message Object");
            myMessage.Print();
            NameChecker([ "FIRSTNAME", "among us", "minecaft", "test" ]);
        }
        static void NameChecker(string[] names)
        { 
            Console.WriteLine("Please enter a name:");
            string name = Console.ReadLine();
            int pos = Array.IndexOf(names, name.ToLower()); // find name by position in array
            if (name.ToLower() == "exit")
            {
                Environment.Exit(0);
            }
            else if (pos == 0)
            {
                Console.WriteLine("Welcome Admin.");
            }
            else if (pos > 0)
            {
                Console.WriteLine("Hi " + name + ", how are you?");
            }
            else
            {
                Console.WriteLine("Welcome, nice to meet you.");
            }
            NameChecker(names);
        }
    }
}
