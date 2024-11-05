using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identifiable
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Location _location;
        public Player(string name, string desc, Location location) : base(new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();
            _location = location;
        }
        public GameObject? Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            else
            {
                var item = _inventory.Fetch(id);
                if (item == null)
                {
                    return _location.Locate(id);
                }
                return item;
            }
        }
        public override string FullDescription { get
            {
                return $"You are {Name}.\n" +
                $"{ShortDescription}\n" +
                $"You are carrying\n{_inventory.ItemList}";
            } }
        public Inventory Inventory { get { return _inventory; } }
        public Location Location { get { return _location; } set { _location = value; } }
    }
}
