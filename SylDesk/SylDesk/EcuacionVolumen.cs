using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SylDesk
{
    public class EcuacionVolumen
    {
        private string id;
        private string inventario;
        private string umafor;
        private string especie;
        private string ecuacion;

        public EcuacionVolumen(string id, string inventario, string umafor, string especie, string ecuacion)
        {
            this.id = id;
            this.inventario = inventario;
            this.umafor = umafor;
            this.especie = especie;
            this.ecuacion = ecuacion;
        }

        public string getId()
        {
            return id;
        }
        
        public string getInventario()
        {
            return inventario;
        }

        public string getUmafor()
        {
            return umafor;
        }

        public string getEspecie()
        {
            return especie;
        }

        public string getEcuacion()
        {
            return ecuacion;
        }
    }
}
