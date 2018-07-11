using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SylDesk
{
    public class IVI
    {
        private string nombrecientifico;
        private double frec_abs, frec_rel, den_abs, den_rel, dom_abs, dom_rel;
        public double ivi;

        public IVI(String nombrecientifico, double frec_abs, double frec_rel, double den_abs, double den_rel, double dom_abs, double dom_rel)
        {
            this.nombrecientifico = nombrecientifico;
            this.frec_abs = frec_abs;
            this.frec_rel = frec_rel;
            this.den_abs = den_abs;
            this.den_rel = den_rel;
            this.dom_abs = dom_abs;
            this.dom_rel = dom_rel;
            this.ivi = frec_rel + den_rel + dom_rel;
        }

        public String get_nombrecientifico()
        {
            return nombrecientifico;
        }

        public double get_frec_abs()
        {
            return frec_abs;
        }

        public double get_frec_rel()
        {
            return frec_rel;
        }

        public double get_den_abs()
        {
            return den_abs;
        }

        public double get_den_rel()
        {
            return den_rel;
        }

        public double get_dom_abs()
        {
            return dom_abs;
        }

        public double get_dom_rel()
        {
            return dom_rel;
        }

        public double get_ivi()
        {
            return ivi;
        }
    }
}
