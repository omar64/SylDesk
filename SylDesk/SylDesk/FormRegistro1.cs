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
            textBoxSector.Text = "";
            textBoxSuperficie.Text = "";
            richTextBoxDescripcion.Text = "";
        }

        private void buttonRegistrar_Click(object sender, EventArgs e)
        {
            if(textBoxNombre.Text == "" || textBoxSector.Text == "" || textBoxSuperficie.Text == "" || richTextBoxDescripcion.Text == "")
            {
                SqlConnector.sendMessageBox("Faltan Datos.");
            }
            else if(!(Double.TryParse(textBoxSuperficie.Text, out double aux2)))
            {
                SqlConnector.sendMessageBox("Superficie debe ser numerico.");
            }
            else
            {
                try
                {
                    SqlConnector.postPutDeleteGenerico(
                        "Insert into proyectos(nombre, superficie, sector, descripcion)Values(@nombre,@superficie,@sector,@descripcion)",
                        new String[] { "nombre", "superficie", "sector", "descripcion" },
                        new String[] { textBoxNombre.Text, textBoxSuperficie.Text, textBoxSector.Text, richTextBoxDescripcion.Text }
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

                    form1.formRegistro2ToFront(Convert.ToInt32(proyecto.getId()));
                }
                catch (Exception)
                {

                }
            }
        }
    }
}
