using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identifiable
{
    public interface IHaveInventory
    {
        public abstract GameObject? Locate(string id);
        public abstract string Name { get; }
    }
}
