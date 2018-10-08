using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SylDesk
{
    public class Especie
    {
        private string id;
        private string nombrecientifico;
        private string nombrecomun;
        private string familia;
        private string formadevida;
        private string genero;
        private string categoriadenorma;

        public Especie(string id, string nombrecientifico, string nombrecomun, string familia, string formadevida, string genero, string categoriadenorma)
        {
            this.id = id;
            this.nombrecientifico = nombrecomun;
            this.nombrecomun = nombrecientifico;
            this.familia = familia;
            this.formadevida = formadevida;
            this.genero = genero;
            this.categoriadenorma = categoriadenorma;
        }

        public string getId()
        {
            return id;
        }

        public string getNombreCientifico()
        {
            return nombrecientifico;
        }

        public string getNombreComun()
        {
            return nombrecomun;
        }

        public string getFamilia()
        {
            return familia;
        }

        public string getFormaDeVida()
        {
            return formadevida;
        }

        public string getGenero()
        {
            return genero;
        }

        public string getCategoriaDeNorma()
        {
            return categoriadenorma;
        }
    }
}
