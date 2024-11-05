using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identifiable
{
    public class MoveCommand : Command
    {
        private string[] _validKeys = ["move", "head", "go", "leave"];
        public MoveCommand() : base([""])
        {

        }
        public override string Execute(Player p, string[] text)
        {
            string direction;
            if (text.Length == 2)
            {
                if (_validKeys.Any(text[0].Equals))
                {
                    direction = text[1];
                }
                else
                {
                    return "Error in move input";
                }
            }
            else
            {
                return "Error in move input";
            }
            var path = p.Location.Locate(direction);
            if (path == null)
            {
                return $"I could not find the {direction} path";
            }
            ((Path)path).MovePlayer(p);
            return path.FullDescription;
        }
    }
}
