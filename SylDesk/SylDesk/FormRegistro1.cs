using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SylDesk
{
    public partial class FormRegistro1 : UserControl
    {
        private Form1 form1;

        public FormRegistro1(Form1 form1)
        {
            this.form1 = form1;
            InitializeComponent();
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
            else if(Regex.IsMatch(textBoxSuperficie.Text, @"^\d+$"))
            {
                SqlConnector.sendMessageBox("Superficie debe ser numerico con decimal.");
            }
            else
            {
                try
                {
                    SqlConnector.proyectoPost(
                        "Insert into proyectos(nombre, superficie, sector, descripcion)Values(@nombre,@superficie,@sector,@descripcion)",
                        new String[] { "nombre", "superficie", "sector", "descripcion" },
                        new String[] { textBoxNombre.Text, textBoxSuperficie.Text, textBoxSector.Text, richTextBoxDescripcion.Text }
                    );

                    Proyecto proyecto = SqlConnector.proyectoGet(
                        "SELECT * from proyectos where nombre = @nombre",
                        new String[] { "nombre" } , 
                        new String[] { textBoxNombre.Text}
                    );

                    SqlConnector.sitioPost(
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
