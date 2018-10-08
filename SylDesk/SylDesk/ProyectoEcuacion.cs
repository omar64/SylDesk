using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SylDesk
{
    public class ProyectoEcuacion
    {
        private string id;
        private string proyecto_id;
        private string umafor_region;

        public ProyectoEcuacion(string id, string proyecto_id, string umafor_region)
        {
            this.id = id;
            this.proyecto_id = proyecto_id;
            this.umafor_region = umafor_region;
        }

        public string getId()
        {
            return id;
        }

        public string getProyectoId()
        {
            return proyecto_id;
        }

        public string getUmaforRegion()
        {
            return umafor_region;
        }
    }
}
