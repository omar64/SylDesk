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
        private string bifurcado;
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
        private string cobertura;
        private string formafuste;
        private string estadocondicion;
        private string rad;
        private string atcategoria;
        private string dncategoria;
        private string ab;
        private string volumen;
        private string areabasal;

        public Individuo(string id, string proyecto_id, string sitio, string area, string cuadrante, 
            string numero, string numeroarbolensitio, string bifurcado, string nombrecientifico, string nombrecomun,
            string familia, string genero, string perimetro, string diametro, string alturafl, string alturatotal,
            string coberturalargo, string coberturaancho, string cobertura, string formafuste, string estadocondicion, string rad,
            string atcategoria, string dncategoria, string ab, string volumen, string areabasal)
        {
            this.id = id;
            this.proyecto_id = proyecto_id;
            this.sitio = sitio;
            this.area = area;
            this.cuadrante = cuadrante;
            this.numero = numero;
            this.numeroarbolensitio = numeroarbolensitio;
            this.bifurcado = bifurcado;
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
            this.cobertura = cobertura;
            this.formafuste = formafuste;
            this.estadocondicion = estadocondicion;
            this.rad = rad;
            this.atcategoria = atcategoria;
            this.dncategoria = dncategoria;
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

        public string getBifurcado()
        {
            return bifurcado;        
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

        public string getCobertura()
        {
            return cobertura;
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

        public string getAtCategoria()
        {
            return atcategoria;
        }

        public string getDnCategoria()
        {
            return dncategoria;
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
