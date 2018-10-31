using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SylDesk
{
    public partial class FormRegistro1 : UserControl
    {
        private Form1 form1;

        public FormRegistro1()
        {
            InitializeComponent();
        }

        public void setForm(Form1 form1)
        {
            this.form1 = form1;
        }

        public void Empty()
        {
            textBoxNombre.Text = "";
            textBoxSuperficie.Text = "";
            richTextBoxDescripcion.Text = "";
        }

        private void buttonRegistrar_Click(object sender, EventArgs e)
        {
            if(textBoxNombre.Text == "" || textBoxSuperficie.Text == "" || richTextBoxDescripcion.Text == "")
            {
                SqlConnector.sendMessage("Error", "Faltan Datos.", MessageBoxIcon.Error);            
            }
            else if(!(Double.TryParse(textBoxSuperficie.Text, out double aux2)))
            {
                SqlConnector.sendMessage("Error", "Superficie debe ser numerico.", MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    SqlConnector.postPutDeleteGenerico(
                        "Insert into proyectos(nombre, superficie, descripcion)Values(@nombre, @superficie, @descripcion)",
                        new String[] { "nombre", "superficie", "descripcion" },
                        new String[] { textBoxNombre.Text, textBoxSuperficie.Text, richTextBoxDescripcion.Text }
                    );

                    Proyecto proyecto = SqlConnector.proyectoGet(
                        "SELECT * from proyectos where nombre = @nombre",
                        new String[] { "nombre" } , 
                        new String[] { textBoxNombre.Text}
                    );

                    SqlConnector.postPutDeleteGenerico(
                        "Insert into sitios(proyecto_id, numero_sitio)Values(@proyecto_id, @numero_sitio)",
                        new String[] { "proyecto_id", "numero_sitio" },
                        new String[] { proyecto.getId(), "1" }
                    );
                    SqlConnector.sendMessage("Aviso", "Proyecto Guardado.", MessageBoxIcon.Information);

                    form1.formRegistro2ToFront(Convert.ToInt32(proyecto.getId()));
                }
                catch (Exception)
                {

                }
            }
        }

        private void FormRegistro1_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(TipBox, "Lorem ipsum dolor sit amet consectetur adipiscing\n elit ornare, accumsan nec auctor morbi eget diam cubilia curae,\n justo nisl fringilla natoque sodales dignissim tristique.\n Massa morbi fringilla taciti pulvinar vel nascetur risus luctus eros,\n aliquam orci accumsan quam convallis id sociis lectus egestas, dui mattis aptent leo conubia arcu mi consequat.\n Dictumst senectus litora suscipit proin pretium mattis facilisi, montes posuere ut felis convallis\n dignissim eleifend luctus, praesent urna nullam ridiculus vitae enim.");
        }

        private void TipBox_Click(object sender, EventArgs e)
        {

        }
    }
}
