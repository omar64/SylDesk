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
    public partial class FormInicial : UserControl
    {
        Form1 form1;

        public FormInicial(Form1 form1)
        {
            this.form1 = form1;
            InitializeComponent();
        }
    }
}
