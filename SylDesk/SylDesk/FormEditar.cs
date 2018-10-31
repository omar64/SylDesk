﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SylDesk
{
    public partial class FormEditar : UserControl
    {
        private Form1 form1;
        private Proyecto proyecto;
        public FormEditar()
        {
            InitializeComponent();
        }

        public void setForm(Form1 form1)
        {
            this.form1 = form1;
        }

        public void Initialize(Proyecto proyecto)
        {            
            this.proyecto = proyecto;

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
                new String[] { "" + proyecto.getId() }
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
                    new String[] { textNombre.Text, textSuperficie.Text, textDescr.Text, "" + proyecto.getId() }
                );

                SqlConnector.sendMessage("Aviso", "Se han guardado los cambios", MessageBoxIcon.Information);
                form1.formRegistro3ToFront();
            }
            else
            {
                SqlConnector.sendMessage("Error", "Faltan Datos", MessageBoxIcon.Error);
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
                                    new String[] { comboBox1.Text, "" + proyecto.getId() }
                                );

            if (proyecto_ecuacion == null)
            {
                SqlConnector.postPutDeleteGenerico(
                    "Insert into proyecto_ecuaciones(proyecto_id, umafor_region)Values(@proyecto_id, @umafor_region)",
                    new String[] { "proyecto_id", "umafor_region" },
                    new String[] { "" + proyecto.getId(), comboBox1.Text }
                );
                listview1_Populate();
            }
            else
            {
                SqlConnector.sendMessage("Error", "La UMAFOR/Región ya se encuentra registrada como parte de los inventarios utilizados en el proyecto.", MessageBoxIcon.Error);
            }
        }

        private void FormEditar_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(TipBox, "En este formulario se editaran los proyectos llenando \nlos campos requeridos para su registro.\nRevisa bien los datos antes de guardar te quiero bb.");
            
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            //form1.formRegistro2ToFront(proyecto_id);
            form1.formRegistro3ToFront();
        }
    }
}
