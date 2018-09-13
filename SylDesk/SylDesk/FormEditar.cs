using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SylDesk
{
    public partial class FormEditar : UserControl
    {
        private Form1 form1;
        private int proyecto_id;
        MySqlCommand cmd;
        public FormEditar(Form1 form1)
        {
            this.form1 = form1;
            InitializeComponent();
        }

        public void Initialize(int proyecto_id)
        {
            
            this.proyecto_id = proyecto_id;
        }

    }
}
