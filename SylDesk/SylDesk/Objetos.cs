using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SylDesk
{
    ///
    ///Objetos de Base de datos
    ///
    public class Especie2
    {
        public int id { get; set; }
        public string nombrecientifico { get; set; }
        public string nombrecomun { get; set; }
        public string familia { get; set; }
        public string formadevida { get; set; }
        public string genero { get; set; }
        public string categoriadenorma { get; set; }
    }

    /// 
    ///  DASOMETRICOS
    /// 
    public class Cat
    {
        public double cat { get; set; }
        public int no_individuos { get; set; }
    }

    public class Cad
    {
        public double cad { get; set; }
        public int no_individuos { get; set; }
    }

    public class No_Individuos
    {
        public string especie { get; set; }
        public int no_individuos { get; set; }
        public double indidviduos_ha { get; set; }
        public double individuos_scustf { get; set; }
    }

    public class Area_Basal
    {
        public string especie { get; set; }
        public double suma_ab { get; set; }
        public double ab_ha { get; set; }
        public double ab_ha2 { get; set; }
    }

    public class Volumen
    {
        public string especie { get; set; }
        public double suma_volumen { get; set; }
        public double volumen_ha { get; set; }
        public double volumen_ha2 { get; set; }
    }
    ///
    /// IVI
    ///
    public class IVI2
    {
        public string nombrecientifico { get; set; }
        public double frec_abs { get; set; }
        public double frec_rel { get; set; }
        public double den_abs { get; set; }
        public double den_rel { get; set; }
        public double dom_abs { get; set; }
        public double dom_rel { get; set; }
        public double ivi { get; set; }
    }
    ///
    /// Diversidad y Riqueza
    ///
    public class IDR
    {
        public string especie { get; set; }
        public double ni { get; set; }
        public double pi { get; set; }
        public double ln_pi { get; set; }
        public double shannon { get; set; }
        public double simpson { get; set; }
    }

    

}
