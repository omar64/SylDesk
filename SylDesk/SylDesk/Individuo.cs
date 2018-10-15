using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SylDesk
{
    public class Individuo
    {
        private string id;
        private string proyecto_id;
        private string sitio;
        private string area;
        private string cuadrante;
        private string numero;
        private string numeroarbolensitio;
        private string bifurcados;
        private string nombrecientifico;
        private string nombrecomun;
        private string familia;
        private string genero;
        private string perimetro;
        private string diametro;
        private string alturafl;
        private string alturatotal;
        private string coberturalargo;
        private string coberturaancho;
        private string formafuste;
        private string estadocondicion;
        private string rad;
        private string atcategorias;
        private string dncategorias;
        private string ab;
        private string volumen;
        private string areabasal;

        public Individuo(string id, string proyecto_id, string sitio, string area, string cuadrante, 
            string numero, string numeroarbolensitio, string bifurcados, string nombrecientifico, string nombrecomun,
            string familia, string genero, string perimetro, string diametro, string alturafl, string alturatotal,
            string coberturalargo, string coberturaancho, string formafuste, string estadocondicion, string rad,
            string atcategorias, string dncategorias, string ab, string volumen, string areabasal)
        {
            this.id = id;
            this.proyecto_id = proyecto_id;
            this.sitio = sitio;
            this.area = area;
            this.cuadrante = cuadrante;
            this.numero = numero;
            this.numeroarbolensitio = numeroarbolensitio;
            this.bifurcados = bifurcados;
            this.nombrecientifico = nombrecientifico;
            this.nombrecomun = nombrecomun;
            this.familia = familia;
            this.genero = genero;
            this.perimetro = perimetro;
            this.diametro = diametro;
            this.alturafl = alturafl;
            this.alturatotal = alturatotal;
            this.coberturalargo = coberturalargo;
            this.coberturaancho = coberturaancho;
            this.formafuste = formafuste;
            this.estadocondicion = estadocondicion;
            this.rad = rad;
            this.atcategorias = atcategorias;
            this.dncategorias = dncategorias;
            this.ab = ab;
            this.volumen = volumen;
            this.areabasal = areabasal;
    }

        public string getId()
        {
            return id;
        }

        public string getProyectoId()
        {
            return proyecto_id;
        }

        public string getSitio()
        {
            return sitio;
        }

        public string getArea()
        {
            return area;
        }

        public string getCuadrante()
        {
            return cuadrante;
        }
        public string getNumero()
        {
            return numero;
        }

        public string getNumeroArbolEnSitio()
        {
            return numeroarbolensitio;
        }

        public string getBifurcados()
        {
            return bifurcados;        
        }

        public string getNombreCientifico()
        {
            return nombrecientifico;
        }

        public string getNombreComun()
        {
            return nombrecomun;
        }

        public string getFamilias()
        {
            return familia;
        }

        public string getGenero()
        {
            return genero;
        }

        public string getPerimetro()
        {
            return perimetro;
        }

        public string getDiametro()
        {
            return diametro;
        }

        public string getAlturaFl()
        {
            return alturafl;
        }

        public string getAlturaTotal()
        {
            return alturatotal;
        }

        public string getCoberturaLargo()
        {
            return coberturalargo;
        }

        public string getCoberturaAncho()
        {
            return coberturaancho;
        }

        public string getFormaFuste()
        {
            return formafuste;
        }

        public string getEstadoCondicion()
        {
            return estadocondicion;
        }

        public string getRad()
        {
            return rad;
        }

        public string getAtCategorias()
        {
            return atcategorias;
        }

        public string getDnCategorias()
        {
            return dncategorias;
        }

        public string getAb()
        {
            return ab;
        }

        public string getVolumen()
        {
            return volumen;
        }

        public string getAreaBasal()
        {
            return areabasal;
        }
    }
}
