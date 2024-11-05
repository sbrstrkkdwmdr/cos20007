using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identifiable
{
    public class Inventory
    {
        List<Item> _items;
        public Inventory()
        {
            _items = new List<Item>();

        }
        public bool HasItem(string id)
        {
            foreach (Item item in _items)
            {
                if (item.AreYou(id))
                {
                    return true;
                }
            }
            return false;
        }
        public void Put(Item itm)
        {
            _items.Add(itm);
        }
        public Item? Take(string id)
        {
            foreach (Item item in _items)
            {
                if (item.AreYou(id))
                {
                    _items.Remove(item);
                    return item;
                }
            }
            return null;
        }
        public Item? Fetch(string id)
        {
            foreach (Item item in _items)
            {
                if (item.AreYou(id)) {
                    return item;
                }
            }
            return null;
        }
        public string ItemList
        {
            get
            {
                List<string> _list = new List<string>();
                foreach (var item in _items)
                {
                    _list.Add(item.ShortDescription);
                }
                return string.Join("\n", _list); 
            }
        }
    }
}
