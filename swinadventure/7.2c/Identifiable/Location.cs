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
        public Location(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();
        }
        public GameObject? Locate(string id)
        {
            return _inventory.Fetch(id);
        }
        public Inventory Inventory { get { return _inventory; } }
    }
}
