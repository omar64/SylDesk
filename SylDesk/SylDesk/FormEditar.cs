using System;
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

            fill_area(1);
            fill_area(2);
            fill_area(3);
            fill_area(4);
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
                if (!(Double.TryParse(textSuperficie.Text, out double aux2)))
                {
                    SqlConnector.sendMessage("Error", "Superficie debe ser numerico.", MessageBoxIcon.Error);
                }
                else
                {
                    if (checkBoxA1.Checked || checkBoxA2.Checked || checkBoxA3.Checked || checkBoxA4.Checked)
                    {
                        if (checkBoxA1.Checked)
                        {
                            if (SuperficieTxB1.Text == "" || DiametroTxB1.Text == "" || AlturaTxB1.Text == "")
                            {
                                SqlConnector.sendMessage("Error", "Faltan Datos del Area de muestreo 1.", MessageBoxIcon.Error);
                                return;
                            }
                            if (DiametroTxB1.Text.IndexOf("-") < 0)
                            {
                                SqlConnector.sendMessage("Error", "En el campo de rangos de Diametro/Largo del Area1 falta simbolo de separacion \"-\".", MessageBoxIcon.Error);
                                return;
                            }
                            if (AlturaTxB1.Text.IndexOf("-") < 0)
                            {
                                SqlConnector.sendMessage("Error", "En el campo de rangos de Altura/Ancho del Area1 falta simbolo de separacion \"-\".", MessageBoxIcon.Error);
                                return;
                            }
                            if (!(Double.TryParse(SuperficieTxB1.Text, out double aux3)))
                            {
                                SqlConnector.sendMessage("Error", "Superficie del Area1 debe ser numerico.", MessageBoxIcon.Error);
                                return;
                            }
                            updateArea(1, checkBoxA1.Checked, SuperficieTxB1.Text, radioVolumen1.Checked, DiametroTxB1.Text, AlturaTxB1.Text);
                        }
                        else
                        {
                            updateArea(1, checkBoxA1.Checked);
                        }
                        if (checkBoxA2.Checked)
                        {
                            if (SuperficieTxB2.Text == "" || DiametroTxB2.Text == "" || AlturaTxB2.Text == "")
                            {
                                SqlConnector.sendMessage("Error", "Faltan Datos del Area de muestreo 2.", MessageBoxIcon.Error);
                                return;
                            }
                            if (DiametroTxB2.Text.IndexOf("-") < 0)
                            {
                                SqlConnector.sendMessage("Error", "En el campo de rangos de Diametro/Largo del Area2 falta simbolo de separacion \"-\".", MessageBoxIcon.Error);
                                return;
                            }
                            if (AlturaTxB2.Text.IndexOf("-") < 0)
                            {
                                SqlConnector.sendMessage("Error", "En el campo de rangos de Altura/Ancho del Area2 falta simbolo de separacion \"-\".", MessageBoxIcon.Error);
                                return;
                            }
                            if (!(Double.TryParse(SuperficieTxB2.Text, out double aux3)))
                            {
                                SqlConnector.sendMessage("Error", "Superficie del Area2 debe ser numerico.", MessageBoxIcon.Error);
                                return;
                            }
                            updateArea(2, checkBoxA2.Checked, SuperficieTxB2.Text, radioVolumen2.Checked, DiametroTxB2.Text, AlturaTxB2.Text);
                        }
                        else
                        {
                            updateArea(2, checkBoxA2.Checked);
                        }
                        if (checkBoxA3.Checked)
                        {
                            if (SuperficieTxB3.Text == "" || DiametroTxB3.Text == "" || AlturaTxB3.Text == "")
                            {
                                SqlConnector.sendMessage("Error", "Faltan Datos del Area de muestreo 3.", MessageBoxIcon.Error);
                                return;
                            }
                            if (DiametroTxB3.Text.IndexOf("-") < 0)
                            {
                                SqlConnector.sendMessage("Error", "En el campo de rangos de Diametro/Largo del Area3 falta simbolo de separacion \"-\".", MessageBoxIcon.Error);
                                return;
                            }
                            if (AlturaTxB3.Text.IndexOf("-") < 0)
                            {
                                SqlConnector.sendMessage("Error", "En el campo de rangos de Altura/Ancho del Area3 falta simbolo de separacion \"-\".", MessageBoxIcon.Error);
                                return;
                            }
                            if (!(Double.TryParse(SuperficieTxB3.Text, out double aux3)))
                            {
                                SqlConnector.sendMessage("Error", "Superficie del Area3 debe ser numerico.", MessageBoxIcon.Error);
                                return;
                            }
                            updateArea(3, checkBoxA3.Checked, SuperficieTxB3.Text, radioVolumen3.Checked, DiametroTxB3.Text, AlturaTxB3.Text);
                        }
                        else
                        {
                            updateArea(3, checkBoxA3.Checked);
                        }
                        if (checkBoxA4.Checked)
                        {
                            if (SuperficieTxB4.Text == "" || DiametroTxB4.Text == "" || AlturaTxB4.Text == "")
                            {
                                SqlConnector.sendMessage("Error", "Faltan Datos del Area de muestreo 4.", MessageBoxIcon.Error);
                                return;
                            }
                            if (DiametroTxB4.Text.IndexOf("-") < 0)
                            {
                                SqlConnector.sendMessage("Error", "En el campo de rangos de Diametro/Largo del Area4 falta simbolo de separacion \"-\".", MessageBoxIcon.Error);
                                return;
                            }
                            if (AlturaTxB4.Text.IndexOf("-") < 0)
                            {
                                SqlConnector.sendMessage("Error", "En el campo de rangos de Altura/Ancho del Area4 falta simbolo de separacion \"-\".", MessageBoxIcon.Error);
                                return;
                            }
                            if (!(Double.TryParse(SuperficieTxB4.Text, out double aux3)))
                            {
                                SqlConnector.sendMessage("Error", "Superficie del Area4 debe ser numerico.", MessageBoxIcon.Error);
                                return;
                            }
                            updateArea(4, checkBoxA4.Checked, SuperficieTxB4.Text, radioVolumen4.Checked, DiametroTxB4.Text, AlturaTxB4.Text);
                        }
                        else
                        {
                            updateArea(4, checkBoxA4.Checked);
                        }

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
                        SqlConnector.sendMessage("Error", "Almenos un area debe de estar activada.", MessageBoxIcon.Error);
                    }
                }
            }                       
            else
            {
                SqlConnector.sendMessage("Error", "Faltan Datos", MessageBoxIcon.Error);
            }
        }

        private void fill_area(int area_number)
        {
            if (area_number == 1)
            {
                checkBoxA1.Checked = proyecto.getArea1Activo();
                SuperficieTxB1.Text = proyecto.getArea1Superficie();
                radioVolumen1.Checked = Convert.ToBoolean(proyecto.getArea1VolCob());
                radioCobertura1.Checked = !Convert.ToBoolean(proyecto.getArea1VolCob());
                DiametroTxB1.Text = proyecto.getArea1DiaLar();
                AlturaTxB1.Text = proyecto.getArea1AltAnc();
            }
            else if (area_number == 2)
            {
                checkBoxA2.Checked = proyecto.getArea2Activo();
                SuperficieTxB2.Text = proyecto.getArea2Superficie();
                radioVolumen2.Checked = Convert.ToBoolean(proyecto.getArea2VolCob());
                radioCobertura2.Checked = !Convert.ToBoolean(proyecto.getArea2VolCob());
                DiametroTxB2.Text = proyecto.getArea2DiaLar();
                AlturaTxB2.Text = proyecto.getArea2AltAnc();
            }
            else if (area_number == 3)
            {
                checkBoxA3.Checked = proyecto.getArea3Activo();
                SuperficieTxB3.Text = proyecto.getArea3Superficie();
                radioVolumen3.Checked = Convert.ToBoolean(proyecto.getArea3VolCob());
                radioCobertura3.Checked = !Convert.ToBoolean(proyecto.getArea3VolCob());
                DiametroTxB3.Text = proyecto.getArea3DiaLar();
                AlturaTxB3.Text = proyecto.getArea3AltAnc();
            }
            else
            {
                checkBoxA4.Checked = proyecto.getArea4Activo();
                SuperficieTxB4.Text = proyecto.getArea4Superficie();
                radioVolumen4.Checked = Convert.ToBoolean(proyecto.getArea4VolCob());
                radioCobertura4.Checked = !Convert.ToBoolean(proyecto.getArea4VolCob());
                DiametroTxB4.Text = proyecto.getArea4DiaLar();
                AlturaTxB4.Text = proyecto.getArea4AltAnc();
            }
        }

        private void updateArea(int area_number, Boolean bool_activo, string area_superficie, Boolean bool_area_vol_cob, string area_dia_lar, string area_alt_anc)
        {
            string activo = Convert.ToInt32(bool_activo).ToString();
            string area_vol_cob = Convert.ToInt32(bool_area_vol_cob).ToString();
            SqlConnector.postPutDeleteGenerico(
                "UPDATE `proyectos` SET  area" + area_number + "_activo = @area_activo, area" + area_number + "_superficie = @area_superficie, area" + area_number + "_vol_cob = @area_vol_cob, area" + area_number + "_dia_lar = @area_dia_lar, area" + area_number + "_alt_anc = @area_alt_anc WHERE id = @id",
                new String[] { "area_activo", "area_superficie", "area_vol_cob", "area_dia_lar", "area_alt_anc", "id" },
                new String[] { activo, area_superficie, area_vol_cob, area_dia_lar, area_alt_anc, "" + proyecto.getId() }
            );
        }

        private void updateArea(int area_number, Boolean bool_activo)
        {
            string activo = Convert.ToInt32(bool_activo).ToString();
            SqlConnector.postPutDeleteGenerico(
                "UPDATE `proyectos` SET  area" + area_number + "_activo = @area_activo WHERE id = @id",
                new String[] { "area_activo", "id" },
                new String[] { activo, "" + proyecto.getId() }
            );
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
            form1.formRegistro3ToFront();
        }
    }
}
