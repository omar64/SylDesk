using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SylDesk
{
    public class Genero
    {
        private string id;
        private string familia_id;
        private string genero;

        public Genero(string id, string familia_id, string genero)
        {
            this.id = id;
            this.familia_id = familia_id;
            this.genero = genero;
        }

        public string getId()
        {
            return id;
        }

        public string getFamiliaId()
        {
            return familia_id;
        }

        public string getGenero()
        {
            return genero;
        }
    }
}
