using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SylDeskForm
{
    public class Especie
    {
        private string especie;
        private string nombrecientifico;
        private string nombrecomun;
        private string familia;

        public Especie(string especie, string nombrecientifico, string nombrecomun, string familia)
        {
            this.especie = especie;
            this.nombrecientifico = nombrecientifico;
            this.nombrecomun = nombrecomun;
            this.familia = familia;
        }

        public string getEspecie()
        {
            return especie;
        }

        public string getNombreCientifico()
        {
            return nombrecomun;
        }

        public string getNombreComun()
        {
            return nombrecomun;
        }

        public string getFamilia()
        {
            return familia;
        }
    }
}
