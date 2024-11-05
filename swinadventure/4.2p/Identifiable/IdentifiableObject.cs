using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identifiable
{
    public class IdentifiableObject
    {
        private List<string> _identifiers = new List<string>();
        public string FirstId 
        { 
            get
            {
                if(_identifiers.Count > 0) return _identifiers[0];
                return ""; //if no elements, return "";
            }
        }

        public IdentifiableObject(string[] idents)
        {
            _identifiers.AddRange(idents);
        }

        public bool AreYou(string id)
        {
            List <string> _temporaryList = _identifiers.Select(s => s.ToLower()).ToList(); // make a fully lower case version of the list to remove case-sensitivity
            return _temporaryList.Contains(id.ToLower());
        }

        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLower()); 
        }

        public void PrivilegeEscalation(string pin)
        {
            if (pin == "STUDENT_ID")
            {
                List<string> _temporaryList = new List<string>();
                // get every string EXCEPT the first
                for (int i = 0; i < _identifiers.Count; i++)
                {
                    if(i == 0)
                    {
                        _temporaryList.Add("0007");
                    } else
                    {
                        _temporaryList.Add(_identifiers[i]);
                    }
                }
                _identifiers = _temporaryList;
            }
        }
    }
}
