using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SylDesk
{
    public class Sitio
    {
        private string id;
        private string proyecto_id;
        private string numero_sitio;
        private string coordenada_x;
        private string coordenada_y;
        private string municipio;
        private string estado_sucesional;
        private string numero_consecutivo1;
        private string numero_consecutivo2;
        private string numero_consecutivo3;

        public Sitio(string id, string proyecto_id, string numero_sitio, string coordenada_x, string coordenada_y, string municipio, string estado_sucesional, string numero_consecutivo1, string numero_consecutivo2, string numero_consecutivo3)
        {
            this.id = id;
            this.proyecto_id = proyecto_id;
            this.numero_sitio = numero_sitio;
            this.coordenada_x = coordenada_x;
            this.coordenada_y = coordenada_y;
            this.municipio = municipio;
            this.estado_sucesional = estado_sucesional;
        }

        public string getId()
        {
            return id;
        }

        public string getProyectoId()
        {
            return proyecto_id;
        }

        public string getNumeroSitio()
        {
            return numero_sitio;
        }

        public string getCoordenadaX()
        {
            return coordenada_x;
        }

        public string getCoordenadaY()
        {
            return coordenada_y;
        }

        public string getMunicipio()
        {
            return municipio;
        }

        public string getEstadoSucesional()
        {
            return estado_sucesional;
        }

        public string getNumeroConsecutivo1()
        {
            return numero_consecutivo1;
        }

        public string getNumeroConsecutivo2()
        {
            return numero_consecutivo2;
        }

        public string getNumeroConsecutivo3()
        {
            return numero_consecutivo3;
        }
    }
}
