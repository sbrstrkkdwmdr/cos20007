using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identifiable
{
    public class Path : GameObject
    {
        private Location _destination;
        public Path(string direction, string name, string description, Location location) : base([direction], name, description)
        {
            _destination = location;
        }
        public void MovePlayer(Player player)
        {
            player.Location = _destination;
        }
    }
}
