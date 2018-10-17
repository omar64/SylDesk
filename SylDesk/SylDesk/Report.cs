using System.Windows.Forms;

namespace SylDesk
{
    public partial class Report : UserControl
    {
        private Form1 form1;
        
        public Report()
        {
            InitializeComponent();
        }

        public void setForm(Form1 form1)
        {
            this.form1 = form1;
        }
    }
}
