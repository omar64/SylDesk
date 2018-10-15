using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SylDesk
{
    public class Proyecto
    {
        private string id;
        private string nombre;
        private string superficie;
        private string descripcion;
        private string kml;
        private string kml_url;

        public Proyecto(string id, string nombre, string superficie, string descripcion, string kml, string kml_url)
        {
            this.id = id;
            this.nombre = nombre;
            this.superficie = superficie;
            this.descripcion = descripcion;
            this.kml = "";
            this.kml_url = kml_url;
        }

        public string getId()
        {
            return id;
        }

        public string getNombre()
        {
            return nombre;
        }

        public string getSuperficie()
        {
            return superficie;
        }

        public string getDescripcion()
        {
            return descripcion;
        }

        public string getKml()
        {
            return kml;
        }

        public string getKmlUrl()
        {
            return kml_url;
        }
    }
}
