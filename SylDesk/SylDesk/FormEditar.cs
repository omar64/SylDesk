using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SylDesk
{
    public partial class FormEditar : UserControl
    {
        private Form1 form1;
        private int proyecto_id;
        public FormEditar()
        {
            InitializeComponent();
        }

        public void setForm(Form1 form1)
        {
            this.form1 = form1;
        }

        public void Initialize(int proyecto_id)
        {            
            this.proyecto_id = proyecto_id;

            Proyecto proyecto = SqlConnector.proyectoGet(
                "SELECT * FROM `proyectos` where id = @proyecto_id",
                new String[] { "proyecto_id" },
                new String[] { "" + proyecto_id }
            );
            if (proyecto != null)
            {
                textNombre.Text = proyecto.getNombre();
                textSuperficie.Text = proyecto.getSuperficie();
                textDescr.Text = proyecto.getDescripcion();
            }

            listview1_Populate();
            comboBox1_Populate();
        }

        public void Empty()
        {

        }

        public void listview1_Populate()
        {
            listView1.Items.Clear();
            List<ProyectoEcuacion> list_proyecto_ecuaciones = SqlConnector.proyectoEcuacionesGet(
                "SELECT * FROM `proyecto_ecuaciones` Where proyecto_id = @proyecto_id",
                new String[] { "proyecto_id" },
                new String[] { "" + proyecto_id }
            );
            foreach (ProyectoEcuacion proyecto_ecuacion in list_proyecto_ecuaciones)
            {
                listView1.Items.Add(proyecto_ecuacion.getUmaforRegion());
            }

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (textNombre.Text != "" && textSuperficie.Text != "" && textDescr.Text != "")
            {
                SqlConnector.postPutDeleteGenerico(
                    "UPDATE `proyectos` SET nombre = @nombre, superficie = @superficie, descripcion = @descripcion WHERE id = @id",
                    new String[] { "nombre", "superficie", "descripcion", "id" },
                    new String[] { textNombre.Text, textSuperficie.Text, textDescr.Text, "" + proyecto_id }
                );
                SqlConnector.sendMessageBox("Se han guardado los cambios");
                form1.formRegistro3ToFront();
            }
            else
            {
                SqlConnector.sendMessageBox("Faltan Datos");
            }
        }

        private void comboBox1_Populate()
        {
            comboBox1.Items.Clear();

            String sqlQueryString = "SELECT * FROM `ecuaciones_volumen` Group By umafor";
            String[] var_names = new String[] { };
            String[] var_values = new String[] { };
            
            List<EcuacionVolumen> list_ecuaciones_volumen = SqlConnector.ecuacionesVolumenGet(
                sqlQueryString,
                var_names,
                var_values
            );

            foreach (EcuacionVolumen ecuacion_volumen in list_ecuaciones_volumen)
            {
                comboBox1.Items.Add(ecuacion_volumen.getUmafor());
            }
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProyectoEcuacion proyecto_ecuacion = SqlConnector.proyectoEcuacionGet(
                                    "SELECT * FROM `proyecto_ecuaciones` where umafor_region = @umafor_region and proyecto_id = @proyecto_id",
                                    new String[] { "umafor_region", "proyecto_id" },
                                    new String[] { comboBox1.Text, "" + proyecto_id }
                                );

            if (proyecto_ecuacion == null)
            {
                SqlConnector.postPutDeleteGenerico(
                    "Insert into proyecto_ecuaciones(proyecto_id, umafor_region)Values(@proyecto_id, @umafor_region)",
                    new String[] { "proyecto_id", "umafor_region" },
                    new String[] { "" + proyecto_id, comboBox1.Text }
                );
                listview1_Populate();
            }
            else
            {
                SqlConnector.sendMessageBox("La UMAFOR/Región ya se encuentra registrada como parte de los inventarios utilizados en el proyecto.");
            }
        }
    }
}
