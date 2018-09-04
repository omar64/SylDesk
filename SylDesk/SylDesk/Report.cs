using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kawaii_lolis = System.Windows.Forms.DataVisualization.Charting;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace SylDesk
{
    public partial class Report : UserControl
    {
        private Form1 form1;
        private MySqlCommand cmd;
        public Report(Form1 form1)
        {
            this.form1 = form1;
            InitializeComponent();
        }
    }
}
