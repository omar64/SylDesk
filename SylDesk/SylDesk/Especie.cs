using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SylDesk
{
    public class Especie
    {
        private string nombrecientifico;
        private string familia;
        private string genero;

        public Especie(string nombrecientifico, string familia, string genero)
        {
            this.nombrecientifico = nombrecientifico;
            this.familia = familia;
            this.genero = genero;
        }

        public string getNombreCientifico()
        {
            return nombrecientifico;
        }

        public string getFamilia()
        {
            return familia;
        }

        public string getGenero()
        {
            return genero;
        }

    }
}
