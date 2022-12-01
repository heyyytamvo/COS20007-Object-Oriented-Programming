using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Iteration
{
    public class Identifiable_Object
    {
        private List<string> Identifiers{ get; set; }

        public Identifiable_Object(string[] idents)
        {
            Identifiers = new List<string>();
            foreach (string element in idents)
            {
                Identifiers.Add(element.ToLower());
            }
        }


        public bool AreYou(string id)
        { 
            return Identifiers.Contains(id.ToLower());
        }

        public string FirstId
        {
            get
            {
                if (Identifiers.Count == 0)
                {
                    return "";
                }

                return Identifiers[0];
            }
        }

        public void Add_Identifier(string id)
        {
            Identifiers.Add(id.ToLower());
        }

        
    }
}