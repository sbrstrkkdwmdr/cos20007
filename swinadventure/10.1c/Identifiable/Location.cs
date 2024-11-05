using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identifiable
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private List<Path> _paths;
        public Location(string[] ids, string name, string desc, List<Path> paths) : base(ids, name, desc)
        {
            _inventory = new Inventory();
            _paths = paths;
        }
        public GameObject? Locate(string id)
        {
            foreach (var path in _paths)
            {
                if (path.AreYou(id))
                {
                    return path;
                }
            }
            return _inventory.Fetch(id);
        }
        public Inventory Inventory { get { return _inventory; } }
    }
}
