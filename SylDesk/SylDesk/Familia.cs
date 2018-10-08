using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SylDesk
{
    public class Familia
    {
        private string id;
        private string familia;

        public Familia(string id, string familia)
        {
            this.id = id;
            this.familia = familia;
        }

        public string getId()
        {
            return id;
        }

        public string getFamilia()
        {
            return familia;
        }
    }
}
