using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identifiable
{
    public class LookCommand : Command
    {
        public LookCommand() : base([""])
        {
        }

        public override string Execute(Player p, string[] text)
        {
            string _containerId;
            string _itemId;
            if (text.Length == 3 || text.Length == 5)
            {
                if (text[0] == "look")
                {
                    if (text[1] == "at")
                    {
                        _itemId = text[2];
                        if (text.Length > 3)
                        {
                            if (text[3] == "in")
                            {
                                _containerId = text[4];
                            }
                            else
                            {
                                return "What do you want to look in?";
                            }
                        }
                        else
                        {
                            _containerId = p.FirstId;
                        }
                    }
                    else
                    {
                        return "What do you want to look at?";
                    }
                }
                else
                {
                    return "Error in look input";
                }
            }
            else if (text.Length == 1)
            {
                return "";
            }
            else
            {
                return "I don\'t know how to look like that";
            }
            IHaveInventory _container = FetchContainer(p, _containerId);
            if (_container != null)
            {
                string _temp = LookAtIn(_itemId, _container);
                return _temp;
            }
            return $"I cannot find {_containerId}";

        }

        public IHaveInventory? FetchContainer(IHaveInventory p, string containerId)
        {
            GameObject _container = p.Locate(containerId);
            return _container as IHaveInventory;
        }
        public string LookAtIn(string thingId, IHaveInventory container)
        {
            GameObject? _item = container.Locate(thingId);
            return _item?.FullDescription ?? $"I can't find the {thingId}";
        }
    }
}
