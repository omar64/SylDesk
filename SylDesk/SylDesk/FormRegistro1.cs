using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Generic;

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
            checkBoxA1.Checked = true;
            checkBoxA2.Checked = true;
            checkBoxA3.Checked = true;
            checkBoxA4.Checked = true;
            SuperficieTxB1.Text = "";
            SuperficieTxB2.Text = "";
            SuperficieTxB3.Text = "";
            SuperficieTxB4.Text = "";
            radioVolumen1.Select();
            radioVolumen2.Select();
            radioVolumen3.Select();
            radioVolumen4.Select();
            DiametroTxB1.Text = "";
            DiametroTxB2.Text = "";
            DiametroTxB3.Text = "";
            DiametroTxB4.Text = "";
            AlturaTxB1.Text = "";
            AlturaTxB2.Text = "";
            AlturaTxB3.Text = "";
            AlturaTxB4.Text = "";
        }

        private void buttonRegistrar_Click(object sender, EventArgs e)
        {
            Boolean error_flag = false;

            if(textBoxNombre.Text == "" || textBoxSuperficie.Text == "" || richTextBoxDescripcion.Text == "")
            {
                SqlConnector.sendMessage("Error", "Faltan Datos del proyecto.", MessageBoxIcon.Error);
                error_flag = true;
            }
            if(checkBoxA1.Checked)
            {
                if (SuperficieTxB1.Text == "" || DiametroTxB1.Text == "" || AlturaTxB1.Text == "")
                {
                    SqlConnector.sendMessage("Error", "Faltan Datos del Area de muestreo 1.", MessageBoxIcon.Error);
                    error_flag = true;
                }
                if (DiametroTxB1.Text.IndexOf("-") < 0)
                {
                    SqlConnector.sendMessage("Error", "En el campo de rangos de Diametro/Largo del Area1 falta simbolo de separacion \"-\".", MessageBoxIcon.Error);
                    error_flag = true;
                }
                if (AlturaTxB1.Text.IndexOf("-") < 0)
                {
                    SqlConnector.sendMessage("Error", "En el campo de rangos de Altura/Ancho del Area1 falta simbolo de separacion \"-\".", MessageBoxIcon.Error);
                    error_flag = true;
                }
                if (!(Double.TryParse(SuperficieTxB1.Text, out double aux3)))
                {
                    SqlConnector.sendMessage("Error", "Superficie del Area1 debe ser numerico.", MessageBoxIcon.Error);
                    error_flag = true;
                }
            }
            if (checkBoxA2.Checked)
            {
                if (SuperficieTxB2.Text == "" || DiametroTxB2.Text == "" || AlturaTxB2.Text == "")
                {
                    SqlConnector.sendMessage("Error", "Faltan Datos del Area de muestreo 2.", MessageBoxIcon.Error);
                    error_flag = true;
                }
                if (DiametroTxB2.Text.IndexOf("-") < 0)
                {
                    SqlConnector.sendMessage("Error", "En el campo de rangos de Diametro/Largo del Area2 falta simbolo de separacion \"-\".", MessageBoxIcon.Error);
                    error_flag = true;
                }
                if (AlturaTxB2.Text.IndexOf("-") < 0)
                {
                    SqlConnector.sendMessage("Error", "En el campo de rangos de Altura/Ancho del Area2 falta simbolo de separacion \"-\".", MessageBoxIcon.Error);
                    error_flag = true;
                }
                if (!(Double.TryParse(SuperficieTxB2.Text, out double aux3)))
                {
                    SqlConnector.sendMessage("Error", "Superficie del Area2 debe ser numerico.", MessageBoxIcon.Error);
                    error_flag = true;
                }
            }
            if (checkBoxA3.Checked)
            {
                if (SuperficieTxB3.Text == "" || DiametroTxB3.Text == "" || AlturaTxB3.Text == "")
                {
                    SqlConnector.sendMessage("Error", "Faltan Datos del Area de muestreo 3.", MessageBoxIcon.Error);
                    error_flag = true;
                }
                if (DiametroTxB3.Text.IndexOf("-") < 0)
                {
                    SqlConnector.sendMessage("Error", "En el campo de rangos de Diametro/Largo del Area3 falta simbolo de separacion \"-\".", MessageBoxIcon.Error);
                    error_flag = true;
                }
                if (AlturaTxB3.Text.IndexOf("-") < 0)
                {
                    SqlConnector.sendMessage("Error", "En el campo de rangos de Altura/Ancho del Area3 falta simbolo de separacion \"-\".", MessageBoxIcon.Error);
                    error_flag = true;
                }
                if (!(Double.TryParse(SuperficieTxB3.Text, out double aux3)))
                {
                    SqlConnector.sendMessage("Error", "Superficie del Area3 debe ser numerico.", MessageBoxIcon.Error);
                    error_flag = true;
                }
            }
            if (checkBoxA4.Checked)
            {
                if (SuperficieTxB4.Text == "" || DiametroTxB4.Text == "" || AlturaTxB4.Text == "")
                {
                    SqlConnector.sendMessage("Error", "Faltan Datos del Area de muestreo 4.", MessageBoxIcon.Error);
                    error_flag = true;
                }
                if (DiametroTxB4.Text.IndexOf("-") < 0)
                {
                    SqlConnector.sendMessage("Error", "En el campo de rangos de Diametro/Largo del Area4 falta simbolo de separacion \"-\".", MessageBoxIcon.Error);
                    error_flag = true;
                }
                if (AlturaTxB4.Text.IndexOf("-") < 0)
                {
                    SqlConnector.sendMessage("Error", "En el campo de rangos de Altura/Ancho del Area4 falta simbolo de separacion \"-\".", MessageBoxIcon.Error);
                    error_flag = true;
                }
                if (!(Double.TryParse(SuperficieTxB4.Text, out double aux3)))
                {
                    SqlConnector.sendMessage("Error", "Superficie del Area4 debe ser numerico.", MessageBoxIcon.Error);
                    error_flag = true;
                }
            }
            if (!(Double.TryParse(textBoxSuperficie.Text, out double aux2)))
            {
                SqlConnector.sendMessage("Error", "Superficie debe ser numerico.", MessageBoxIcon.Error);
                error_flag = true;
            }
            if(!error_flag)
            {
                try
                {
                    //SqlConnector.sendMessage("debug", "1", MessageBoxIcon.Information);
                    string sql_text1 = "Insert into proyectos( nombre, superficie, descripcion";
                    string sql_text2 = ")Values(@nombre, @superficie, @descripcion";
                    string sql_text3 = ")";

                    string sql_variable_text1 = "";
                    string sql_variable_text2 = "";

                    string area1_text = "";
                    string area2_text = "";
                    string area3_text = "";
                    string area4_text = "";

                    List<String> var_names = new List<String>();
                    var_names.AddRange(new String[]{"nombre", "superficie", "descripcion"});

                    string[] area1_var_names = { };
                    string[] area2_var_names = { };
                    string[] area3_var_names = { };
                    string[] area4_var_names = { };

                    List<String> var_values = new List<String>();
                    var_values.AddRange(new String[] { textBoxNombre.Text, textBoxSuperficie.Text, richTextBoxDescripcion.Text });

                    string[] area1_var_values = { };
                    string[] area2_var_values = { };
                    string[] area3_var_values = { };
                    string[] area4_var_values = { };

                    //SqlConnector.sendMessage("debug", "2", MessageBoxIcon.Information);

                    if (checkBoxA1.Checked)
                    {
                        area1_text = ",area1_activo, area1_superficie, area1_vol_cob, area1_dia_lar, area1_alt_anc";
                        area1_var_names = new String[] { "area1_activo", "area1_superficie", "area1_vol_cob", "area1_dia_lar", "area1_alt_anc" };
                        area1_var_values = new String[] { Convert.ToInt32(checkBoxA1.Checked).ToString(), SuperficieTxB1.Text, Convert.ToInt32(radioVolumen1.Checked).ToString(), DiametroTxB1.Text, AlturaTxB1.Text };

                        sql_variable_text1 += ",area1_activo, area1_superficie, area1_vol_cob, area1_dia_lar, area1_alt_anc";
                        sql_variable_text2 += ",@area1_activo, @area1_superficie, @area1_vol_cob, @area1_dia_lar, @area1_alt_anc";
                        var_names.AddRange(area1_var_names);
                        var_values.AddRange(area1_var_values);
                    }
                    if (checkBoxA2.Checked)
                    {
                        area2_text = ",area2_activo, area2_superficie, area2_vol_cob, area2_dia_lar, area2_alt_anc";
                        area2_var_names = new String[] { "area2_activo", "area2_superficie", "area2_vol_cob", "area2_dia_lar", "area2_alt_anc" };
                        area2_var_values = new String[] { Convert.ToInt32(checkBoxA2.Checked).ToString(), SuperficieTxB2.Text, Convert.ToInt32(radioVolumen2.Checked).ToString(), DiametroTxB2.Text, AlturaTxB2.Text };

                        sql_variable_text1 += ",area2_activo, area2_superficie, area2_vol_cob, area2_dia_lar, area2_alt_anc";
                        sql_variable_text2 += ",@area2_activo, @area2_superficie, @area2_vol_cob, @area2_dia_lar, @area2_alt_anc";
                        var_names.AddRange(area2_var_names);
                        var_values.AddRange(area2_var_values);
                    }
                    if (checkBoxA3.Checked)
                    {
                        area3_text = ",area3_activo, area3_superficie, area3_vol_cob, area3_dia_lar, area3_alt_anc";
                        area3_var_names = new String[] { "area3_activo", "area3_superficie", "area3_vol_cob", "area3_dia_lar", "area3_alt_anc" };
                        area3_var_values = new String[] { Convert.ToInt32(checkBoxA3.Checked).ToString(), SuperficieTxB3.Text, Convert.ToInt32(radioVolumen3.Checked).ToString(), DiametroTxB3.Text, AlturaTxB3.Text };

                        sql_variable_text1 += ",area3_activo, area3_superficie, area3_vol_cob, area3_dia_lar, area3_alt_anc";
                        sql_variable_text2 += ",@area3_activo, @area3_superficie, @area3_vol_cob, @area3_dia_lar, @area3_alt_anc";
                        var_names.AddRange(area3_var_names);
                        var_values.AddRange(area3_var_values);
                    }
                    if (checkBoxA4.Checked)
                    {
                        area4_text = ",area4_activo, area4_superficie, area4_vol_cob, area4_dia_lar, area4_alt_anc";
                        area4_var_names = new String[] { "area4_activo", "area4_superficie", "area4_vol_cob", "area4_dia_lar", "area4_alt_anc" };
                        area4_var_values = new String[] { Convert.ToInt32(checkBoxA4.Checked).ToString(), SuperficieTxB4.Text, Convert.ToInt32(radioVolumen4.Checked).ToString(), DiametroTxB4.Text, AlturaTxB4.Text };

                        sql_variable_text1 += ",area4_activo, area4_superficie, area4_vol_cob, area4_dia_lar, area4_alt_anc";
                        sql_variable_text2 += ",@area4_activo, @area4_superficie, @area4_vol_cob, @area4_dia_lar, @area4_alt_anc";
                        var_names.AddRange(area4_var_names);
                        var_values.AddRange(area4_var_values);
                    }

                    
                    //SqlConnector.sendMessage("debug", "3", MessageBoxIcon.Information);

                    /*
                    SqlConnector.sendMessage("debug", sql_text1 + sql_variable_text1 + sql_text2 + sql_variable_text2 + sql_text3, MessageBoxIcon.Information);
                    SqlConnector.sendMessage("debug", "tamaño de la lista: " + var_names.Count + ", tamaño de la lista2: " + var_values.Count, MessageBoxIcon.Information);
                    for (int i= 0; i < var_names.Count; i++)
                    {
                        SqlConnector.sendMessage("debug", var_names[i] + ": " + var_values[i], MessageBoxIcon.Information);
                    }
                    */

                    SqlConnector.postPutDeleteGenerico(
                        sql_text1 +
                        sql_variable_text1 +
                        sql_text2 +
                        sql_variable_text2 +
                        sql_text3,
                        var_names.ToArray(),
                        var_values.ToArray()
                        /*
                        new String[] {
                            "nombre", "superficie", "descripcion",
                            "area1_activo", "area1_superficie", "area1_vol_cob", "area1_dia_lar", "area1_alt_anc",
                            "area2_activo", "area2_superficie", "area2_vol_cob", "area2_dia_lar", "area2_alt_anc",
                            "area3_activo", "area3_superficie", "area3_vol_cob", "area3_dia_lar", "area3_alt_anc",
                            "area4_activo", "area4_superficie", "area4_vol_cob", "area4_dia_lar", "area4_alt_anc"
                        },
                        new String[] {
                            textBoxNombre.Text, textBoxSuperficie.Text, richTextBoxDescripcion.Text,
                            checkBoxA1.Checked.ToString(), SuperficieTxB1.Text,  radioVolumen1.Checked.ToString(), DiametroTxB1.Text, AlturaTxB1.Text,
                            checkBoxA2.Checked.ToString(), SuperficieTxB2.Text,  radioVolumen2.Checked.ToString(), DiametroTxB2.Text, AlturaTxB2.Text,
                            checkBoxA3.Checked.ToString(), SuperficieTxB3.Text,  radioVolumen3.Checked.ToString(), DiametroTxB3.Text, AlturaTxB3.Text,
                            checkBoxA4.Checked.ToString(), SuperficieTxB4.Text,  radioVolumen4.Checked.ToString(), DiametroTxB4.Text, AlturaTxB4.Text
                        }
                        */
                    );
                    SqlConnector.sendMessage("debug", "4", MessageBoxIcon.Information);


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

                    form1.formRegistro2ToFront(proyecto);
                }
                catch (Exception)
                {

                }
            }
        }
    }
}
