using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Message
    {
        private string _text;
        public Message(string text)
        {
            _text = text; 
        }
        public void Print()
        { Console.WriteLine(_text); }
    }

    internal class Welcome
    {
        public void Print(char type, string name)
        {
            if (type == 'A')
            {
                Console.WriteLine("Hi " +name + ", how are you?");
            } else if (type == 'B')
            {
                Console.WriteLine("Welcome Admin.");
            } else
            {
                Console.WriteLine("Welcome, nice to meet you.");
            }
        }
    }
}
