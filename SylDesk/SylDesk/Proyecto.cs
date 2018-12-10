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

        private bool area1_activo;
        private string area1_superficie;
        private string area1_tag;
        private string area1_vol_cob;
        private string area1_dia_lar;
        private string area1_alt_anc;
        private bool area2_activo;
        private string area2_superficie;
        private string area2_tag;
        private string area2_vol_cob;
        private string area2_dia_lar;
        private string area2_alt_anc;
        private bool area3_activo;
        private string area3_superficie;
        private string area3_tag;
        private string area3_vol_cob;
        private string area3_dia_lar;
        private string area3_alt_anc;
        private bool area4_activo;
        private string area4_superficie;
        private string area4_tag;
        private string area4_vol_cob;
        private string area4_dia_lar;
        private string area4_alt_anc;

        private string kml;
        private string kml_url;

        public Proyecto(string id, string nombre, string superficie, string descripcion, 
            string area1_activo, string area1_superficie, string area1_tag, string area1_vol_cob, string area1_dia_lar, string area1_alt_anc, 
            string area2_activo, string area2_superficie, string area2_tag, string area2_vol_cob, string area2_dia_lar, string area2_alt_anc, 
            string area3_activo, string area3_superficie, string area3_tag, string area3_vol_cob, string area3_dia_lar, string area3_alt_anc,
            string area4_activo, string area4_superficie, string area4_tag, string area4_vol_cob, string area4_dia_lar, string area4_alt_anc, 
            string kml, string kml_url)
        {
            this.id = id;
            this.nombre = nombre;
            this.superficie = superficie;
            this.descripcion = descripcion;

            this.area1_activo = Convert.ToBoolean(area1_activo);
            this.area1_superficie = area1_superficie;
            this.area1_tag = area1_tag;
            this.area1_vol_cob = area1_vol_cob;
            this.area1_dia_lar = area1_dia_lar;
            this.area1_alt_anc = area1_alt_anc;
            this.area2_activo = Convert.ToBoolean(area2_activo);
            this.area2_superficie = area2_superficie;
            this.area2_tag = area2_tag;
            this.area2_vol_cob = area2_vol_cob;
            this.area2_dia_lar = area2_dia_lar;
            this.area2_alt_anc = area2_alt_anc;
            this.area3_activo = Convert.ToBoolean(area3_activo);
            this.area3_superficie = area3_superficie;
            this.area3_tag = area3_tag;
            this.area3_vol_cob = area3_vol_cob;
            this.area3_dia_lar = area3_dia_lar;
            this.area3_alt_anc = area3_alt_anc;
            this.area4_activo = Convert.ToBoolean(area4_activo);
            this.area4_superficie = area4_superficie;
            this.area4_tag = area4_tag;
            this.area4_vol_cob = area4_vol_cob;
            this.area4_dia_lar = area4_dia_lar;
            this.area4_alt_anc = area4_alt_anc;

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

        public bool getArea1Activo()
        {
            return area1_activo;
        }

        public string getArea1Superficie()
        {
            return area1_superficie;
        }

        public string getArea1Tag()
        {
            return area1_tag;
        }

        public string getArea1VolCob()
        {
            return area1_vol_cob;
        }

        public string getArea1DiaLar()
        {
            return area1_dia_lar;
        }

        public string getArea1AltAnc()
        {
            return area1_alt_anc;
        }

        public bool getArea2Activo()
        {
            return area2_activo;
        }

        public string getArea2Superficie()
        {
            return area2_superficie;
        }

        public string getArea2Tag()
        {
            return area2_tag;
        }

        public string getArea2VolCob()
        {
            return area2_vol_cob;
        }

        public string getArea2DiaLar()
        {
            return area2_dia_lar;
        }

        public string getArea2AltAnc()
        {
            return area2_alt_anc;
        }

        public bool getArea3Activo()
        {
            return area3_activo;
        }

        public string getArea3Superficie()
        {
            return area3_superficie;
        }

        public string getArea3Tag()
        {
            return area3_tag;
        }

        public string getArea3VolCob()
        {
            return area3_vol_cob;
        }

        public string getArea3DiaLar()
        {
            return area3_dia_lar;
        }

        public string getArea3AltAnc()
        {
            return area3_alt_anc;
        }

        public bool getArea4Activo()
        {
            return area4_activo;
        }

        public string getArea4Superficie()
        {
            return area4_superficie;
        }

        public string getArea4Tag()
        {
            return area4_tag;
        }

        public string getArea4VolCob()
        {
            return area4_vol_cob;
        }

        public string getArea4DiaLar()
        {
            return area4_dia_lar;
        }

        public string getArea4AltAnc()
        {
            return area4_alt_anc;
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
