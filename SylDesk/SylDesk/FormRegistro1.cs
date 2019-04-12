using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;


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
            checkBoxVolumen1.Select();
            checkBoxVolumen2.Select();
            checkBoxVolumen3.Select();
            checkBoxVolumen4.Select();
            DiametroTxB1.Text = "";
            DiametroTxB2.Text = "";
            DiametroTxB3.Text = "";
            DiametroTxB4.Text = "";
            AlturaTxB1.Text = "";
            AlturaTxB2.Text = "";
            AlturaTxB3.Text = "";
            AlturaTxB4.Text = "";
            umaforBox_Populate();
            listUmafor.Clear();
        }

        private void buttonRegistrar_Click(object sender, EventArgs e)
        {
            Boolean error_flag = false;

            if (textBoxNombre.Text == "" || textBoxSuperficie.Text == "" || richTextBoxDescripcion.Text == "")
            {
                SqlConnector.sendMessage("Error", "Faltan Datos del proyecto.", MessageBoxIcon.Error);
                error_flag = true;
            }



            if (checkBoxA1.Checked)
            {
                error_flag = area_check(1);
            }
            if (checkBoxA2.Checked)
            {
                error_flag = area_check(2);
            }
            if (checkBoxA3.Checked)
            {
                error_flag = area_check(3);
            }
            if (checkBoxA4.Checked)
            {
                error_flag = area_check(4);
            }

            if (checkBoxA1.Checked || checkBoxA2.Checked || checkBoxA3.Checked || checkBoxA4.Checked)
            {
                if (checkBoxA1.Checked && checkBoxA2.Checked && SuperficieTxB1.Text == SuperficieTxB2.Text)
                {
                    SqlConnector.sendMessage("Error", "Area muestreada 1 y 2 tienen la misma superficie.", MessageBoxIcon.Error);
                    error_flag = true;
                }
                else if (checkBoxA1.Checked && checkBoxA3.Checked && SuperficieTxB1.Text == SuperficieTxB3.Text)
                {
                    SqlConnector.sendMessage("Error", "Area muestreada 1 y 3 tienen la misma superficie.", MessageBoxIcon.Error);
                    error_flag = true;
                }
                else if (checkBoxA1.Checked && checkBoxA4.Checked && SuperficieTxB1.Text == SuperficieTxB4.Text)
                {
                    SqlConnector.sendMessage("Error", "Area muestreada 1 y 4 tienen la misma superficie.", MessageBoxIcon.Error);
                    error_flag = true;
                }
                else if (checkBoxA2.Checked && checkBoxA3.Checked && SuperficieTxB2.Text == SuperficieTxB3.Text)
                {
                    SqlConnector.sendMessage("Error", "Area muestreada 2 y 3 tienen la misma superficie.", MessageBoxIcon.Error);
                    error_flag = true;
                }
                else if (checkBoxA2.Checked && checkBoxA4.Checked && SuperficieTxB2.Text == SuperficieTxB4.Text)
                {
                    SqlConnector.sendMessage("Error", "Area muestreada 2 y 4 tienen la misma superficie.", MessageBoxIcon.Error);
                    error_flag = true;
                }
                else if (checkBoxA3.Checked && checkBoxA4.Checked && SuperficieTxB3.Text == SuperficieTxB4.Text)
                {
                    SqlConnector.sendMessage("Error", "Area muestreada 3 y 4 tienen la misma superficie.", MessageBoxIcon.Error);
                    error_flag = true;
                }
            }
            else
            {
                SqlConnector.sendMessage("Error", "Almenos un area debe de estar activada.", MessageBoxIcon.Error);
                error_flag = true;
            }

            checkAreaRangeOverlap();

            if (!error_flag)
            {                
                try
                {
                    string sql_text1 = "Insert into proyectos( nombre, superficie, descripcion";
                    string sql_text2 = ")Values(@nombre, @superficie, @descripcion";
                    string sql_text3 = ")";

                    string sql_variable_text1 = "";
                    string sql_variable_text2 = "";

                    List<String> var_names = new List<String>();
                    var_names.AddRange(new String[] { "nombre", "superficie", "descripcion" });

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

                    if (checkBoxA1.Checked)
                    {
                        area1_var_names = new String[] { "area1_activo", "area1_superficie", "area1_tag", "area1_vol_cob", "area1_dia_lar", "area1_alt_anc" };
                        area1_var_values = new String[] { Convert.ToInt32(checkBoxA1.Checked).ToString(), SuperficieTxB1.Text, TagTxB1.Text, Convert.ToInt32(checkBoxVolumen1.Checked).ToString(), DiametroTxB1.Text, AlturaTxB1.Text };

                        sql_variable_text1 += ",area1_activo, area1_superficie, area1_tag, area1_vol_cob, area1_dia_lar, area1_alt_anc";
                        sql_variable_text2 += ",@area1_activo, @area1_superficie, @area1_tag, @area1_vol_cob, @area1_dia_lar, @area1_alt_anc";
                        var_names.AddRange(area1_var_names);
                        var_values.AddRange(area1_var_values);
                    }
                    if (checkBoxA2.Checked)
                    {
                        area2_var_names = new String[] { "area2_activo", "area2_superficie", "area2_tag", "area2_vol_cob", "area2_dia_lar", "area2_alt_anc" };
                        area2_var_values = new String[] { Convert.ToInt32(checkBoxA2.Checked).ToString(), SuperficieTxB2.Text, TagTxB2.Text, Convert.ToInt32(checkBoxVolumen2.Checked).ToString(), DiametroTxB2.Text, AlturaTxB2.Text };

                        sql_variable_text1 += ",area2_activo, area2_superficie, area2_tag, area2_vol_cob, area2_dia_lar, area2_alt_anc";
                        sql_variable_text2 += ",@area2_activo, @area2_superficie, @area2_tag, @area2_vol_cob, @area2_dia_lar, @area2_alt_anc";
                        var_names.AddRange(area2_var_names);
                        var_values.AddRange(area2_var_values);
                    }
                    if (checkBoxA3.Checked)
                    {
                        area3_var_names = new String[] { "area3_activo", "area3_superficie", "area3_tag", "area3_vol_cob", "area3_dia_lar", "area3_alt_anc" };
                        area3_var_values = new String[] { Convert.ToInt32(checkBoxA3.Checked).ToString(), SuperficieTxB3.Text, TagTxB3.Text, Convert.ToInt32(checkBoxVolumen3.Checked).ToString(), DiametroTxB3.Text, AlturaTxB3.Text };

                        sql_variable_text1 += ",area3_activo, area3_superficie, area3_tag, area3_vol_cob, area3_dia_lar, area3_alt_anc";
                        sql_variable_text2 += ",@area3_activo, @area3_superficie, @area3_tag, @area3_vol_cob, @area3_dia_lar, @area3_alt_anc";
                        var_names.AddRange(area3_var_names);
                        var_values.AddRange(area3_var_values);
                    }
                    if (checkBoxA4.Checked)
                    {
                        area4_var_names = new String[] { "area4_activo", "area4_superficie", "area4_tag", "area4_vol_cob", "area4_dia_lar", "area4_alt_anc" };
                        area4_var_values = new String[] { Convert.ToInt32(checkBoxA4.Checked).ToString(), SuperficieTxB4.Text, TagTxB4.Text, Convert.ToInt32(checkBoxVolumen4.Checked).ToString(), DiametroTxB4.Text, AlturaTxB4.Text };

                        sql_variable_text1 += ",area4_activo, area4_superficie, area4_tag, area4_vol_cob, area4_dia_lar, area4_alt_anc";
                        sql_variable_text2 += ",@area4_activo, @area4_superficie, @area4_tag, @area4_vol_cob, @area4_dia_lar, @area4_alt_anc";
                        var_names.AddRange(area4_var_names);
                        var_values.AddRange(area4_var_values);
                    }

                    SqlConnector.postPutDeleteGenerico(
                        sql_text1 +
                        sql_variable_text1 +
                        sql_text2 +
                        sql_variable_text2 +
                        sql_text3,
                        var_names.ToArray(),
                        var_values.ToArray()
                    );

                    Proyecto proyecto = SqlConnector.proyectoGet(
                        "SELECT * from proyectos where nombre = @nombre",
                        new String[] { "nombre" },
                        new String[] { textBoxNombre.Text }
                    );

                    SqlConnector.postPutDeleteGenerico(
                        "Insert into sitios(proyecto_id, numero_sitio)Values(@proyecto_id, @numero_sitio)",
                        new String[] { "proyecto_id", "numero_sitio" },
                        new String[] { proyecto.getId(), "1" }
                    );

                    List<string> list = listUmafor.Items.Cast<ListViewItem>()
                                 .Select(item => item.Text)
                                 .ToList();

                    foreach (string umafor in list)
                    {
                        SqlConnector.postPutDeleteGenerico(
                            "Insert into proyecto_ecuaciones(proyecto_id, umafor_region)Values(@proyecto_id, @umafor_region)",
                            new String[] { "proyecto_id", "umafor_region" },
                            new String[] { "" + proyecto.getId(), umafor }
                        );
                    }

                    SqlConnector.sendMessage("Aviso", "Proyecto Guardado.", MessageBoxIcon.Information);

                    form1.formRegistro2ToFront(proyecto);
                }
                catch (Exception)
                {

                }                
            }
        }

        private Control getComponent(int type, int id)
        {
            //Type 0:1:Superficie, 2:Volumen, 3:Cobertura, 4:DiaLar, 5:AltAnc
            if (type == 0)
            {
                if (id == 1)
                {
                    return checkBoxA1;
                }
                else if (id == 2)
                {
                    return checkBoxA2;
                }
                else if (id == 3)
                {
                    return checkBoxA3;
                }
                else
                {
                    return checkBoxA4;
                }
            }
            else if (type == 1)
            {
                if (id == 1)
                {
                    return SuperficieTxB1;
                }
                else if (id == 2)
                {
                    return SuperficieTxB2;
                }
                else if (id == 3)
                {
                    return SuperficieTxB3;
                }
                else
                {
                    return SuperficieTxB4;
                }
            }
            else if (type == 2)
            {
                if (id == 1)
                {
                    return checkBoxVolumen1;
                }
                else if (id == 2)
                {
                    return checkBoxVolumen2;
                }
                else if (id == 3)
                {
                    return checkBoxVolumen3;
                }
                else
                {
                    return checkBoxVolumen4;
                }
            }
            else if (type == 3)
            {
                if (id == 1)
                {
                    return TagTxB1;
                }
                else if (id == 2)
                {
                    return TagTxB2;
                }
                else if (id == 3)
                {
                    return TagTxB3;
                }
                else
                {
                    return TagTxB4;
                }
            }

            else if (type == 4)
            {
                if (id == 1)
                {
                    return DiametroTxB1;
                }
                else if (id == 2)
                {
                    return DiametroTxB2;
                }
                else if (id == 3)
                {
                    return DiametroTxB3;
                }
                else
                {
                    return DiametroTxB4;
                }
            }
            else
            {
                if (id == 1)
                {
                    return AlturaTxB1;
                }
                else if (id == 2)
                {
                    return AlturaTxB2;
                }
                else if (id == 3)
                {
                    return AlturaTxB3;
                }
                else
                {
                    return AlturaTxB4;
                }
            }
        }
        private Boolean area_check(int number_area)
        {
            Boolean error_flag = false;
            if (getComponent(1, number_area).Text == "" || getComponent(3, number_area).Text == "" || getComponent(4, number_area).Text == "" || getComponent(5, number_area).Text == "")
            {
                SqlConnector.sendMessage("Error", "Faltan Datos del Area de muestreo " + number_area + ".", MessageBoxIcon.Error);
                error_flag = true;
            }
            if (getComponent(4, number_area).Text != "")
            {
                if (getComponent(4, number_area).Text.IndexOf("-") < 0)
                {
                    SqlConnector.sendMessage("Error", "En el campo de rangos de Diametro/Largo del Area " + number_area + " falta simbolo de separacion \"-\".", MessageBoxIcon.Error);
                    error_flag = true;
                }
                else
                {
                    if (Regex.Matches(getComponent(4, number_area).Text, "-").Count > 1)
                    {
                        SqlConnector.sendMessage("Error", "En el campo de rangos de Diametro/Largo del Area " + number_area + " hay mas de un simbolo de separacion \"-\".", MessageBoxIcon.Error);
                        error_flag = true;
                    }
                    else
                    {
                        string[] rangos_dialar = SqlConnector.getWordsDividedByMinus(getComponent(4, number_area).Text);
                        double aux1, aux2;
                        bool flag1 = Double.TryParse(rangos_dialar[0], out aux1);
                        bool flag2 = Double.TryParse(rangos_dialar[1], out aux2);
                        if (!flag1)
                        {
                            SqlConnector.sendMessage("Error", "En el campo de rangos de Diametro/Largo del Area " + number_area + " el valor inferior debe ser numerico.", MessageBoxIcon.Error);
                            error_flag = true;
                        }
                        if (!flag2)
                        {
                            SqlConnector.sendMessage("Error", "En el campo de rangos de Diametro/Largo del Area " + number_area + " el valor superior debe ser numerico.", MessageBoxIcon.Error);
                            error_flag = true;
                        }
                        if (flag1 && flag2 && aux1 >= aux2)
                        {
                            SqlConnector.sendMessage("Error", "En el campo de rangos de Diametro/Largo del Area " + number_area + " el valor inferior no debe ser mayor o igual al superior.", MessageBoxIcon.Error);
                            error_flag = true;
                        }
                    }
                }
            }
            if (getComponent(5, number_area).Text != "")
            {
                if (getComponent(5, number_area).Text.IndexOf("-") < 0)
                {
                    SqlConnector.sendMessage("Error", "En el campo de rangos de Altura/Ancho del Area " + number_area + " falta simbolo de separacion \"-\".", MessageBoxIcon.Error);
                    error_flag = true;
                }
                else
                {
                    if (Regex.Matches(getComponent(5, number_area).Text, "-").Count > 1)
                    {
                        SqlConnector.sendMessage("Error", "En el campo de rangos de Altura/Ancho del Area " + number_area + " hay mas de un simbolo de separacion \"-\".", MessageBoxIcon.Error);
                        error_flag = true;
                    }
                    else
                    {
                        string[] rangos_altanc = SqlConnector.getWordsDividedByMinus(getComponent(5, number_area).Text);
                        double aux1, aux2;
                        bool flag1 = Double.TryParse(rangos_altanc[0], out aux1);
                        bool flag2 = Double.TryParse(rangos_altanc[1], out aux2);
                        if (!flag1)
                        {
                            SqlConnector.sendMessage("Error", "En el campo de rangos de Altura/Ancho del Area " + number_area + " el valor inferior debe ser numerico.", MessageBoxIcon.Error);
                            error_flag = true;
                        }
                        if (!flag2)
                        {
                            SqlConnector.sendMessage("Error", "En el campo de rangos de Altura/Ancho del Area " + number_area + " el valor superior debe ser numerico.", MessageBoxIcon.Error);
                            error_flag = true;
                        }
                        if (flag1 && flag2 && aux1 >= aux2)
                        {
                            SqlConnector.sendMessage("Error", "En el campo de rangos de Altura/Ancho del Area " + number_area + " el valor inferior no debe ser mayor o igual al superior.", MessageBoxIcon.Error);
                            error_flag = true;
                        }
                    }
                }
            }
            if (!(Double.TryParse(getComponent(1, number_area).Text, out double aux3)))
            {
                SqlConnector.sendMessage("Error", "Superficie del Area " + number_area + " debe ser numerico.", MessageBoxIcon.Error);
                error_flag = true;
            }
            return error_flag;
        }

        private void FormRegistro1_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(TipBox, "Lorem ipsum dolor sit amet consectetur adipiscing\n elit ornare, accumsan nec auctor morbi eget diam cubilia curae,\n justo nisl fringilla natoque sodales dignissim tristique.\n Massa morbi fringilla taciti pulvinar vel nascetur risus luctus eros,\n aliquam orci accumsan quam convallis id sociis lectus egestas, dui mattis aptent leo conubia arcu mi consequat.\n Dictumst senectus litora suscipit proin pretium mattis facilisi, montes posuere ut felis convallis\n dignissim eleifend luctus, praesent urna nullam ridiculus vitae enim.");
        }

        private void checkAreaRangeOverlap()
        {
            string[] rangos_dialar1_str;
            string[] rangos_dialar2_str;
            string[] rangos_dialar3_str;
            string[] rangos_dialar4_str;

            Double[] rangos_dialar1 = { 0 , 0};
            Double[] rangos_dialar2 = { 0, 0 };
            Double[] rangos_dialar3 = { 0, 0 };
            Double[] rangos_dialar4 = { 0, 0 };

            if (checkBoxA1.Checked)
            {
                rangos_dialar1_str = SqlConnector.getWordsDividedByMinus(getComponent(4, 1).Text);
                if (rangos_dialar1_str != null)
                {
                    rangos_dialar1 = new Double[] { Convert.ToDouble(rangos_dialar1_str[0]), Convert.ToDouble(rangos_dialar1_str[1]) };
                }
            }
            if (checkBoxA2.Checked)
            {
                rangos_dialar2_str = SqlConnector.getWordsDividedByMinus(getComponent(4, 2).Text);
                if (rangos_dialar2_str != null)
                {
                    rangos_dialar2 = new Double[] { Convert.ToDouble(rangos_dialar2_str[0]), Convert.ToDouble(rangos_dialar2_str[1]) };
                }
            }
            if (checkBoxA3.Checked)
            {
                rangos_dialar3_str = SqlConnector.getWordsDividedByMinus(getComponent(4, 3).Text);
                if (rangos_dialar3_str != null)
                {
                    rangos_dialar3 = new Double[] { Convert.ToDouble(rangos_dialar3_str[0]), Convert.ToDouble(rangos_dialar3_str[1]) };
                }
            }
            if (checkBoxA4.Checked)
            {
                rangos_dialar4_str = SqlConnector.getWordsDividedByMinus(getComponent(4, 4).Text);
                if (rangos_dialar4_str != null)
                {
                    rangos_dialar4 = new Double[] { Convert.ToDouble(rangos_dialar4_str[0]), Convert.ToDouble(rangos_dialar4_str[1]) };
                }
            }

            if (checkBoxA1.Checked)
            {
                if (checkBoxA2.Checked)
                {
                    if ((rangos_dialar1[0] >= rangos_dialar2[0] && rangos_dialar1[0] <= rangos_dialar2[1]) || (rangos_dialar1[1] >= rangos_dialar2[0] && rangos_dialar1[1] <= rangos_dialar2[1]) || (rangos_dialar2[0] >= rangos_dialar1[0] && rangos_dialar2[0] <= rangos_dialar1[1]) || (rangos_dialar2[1] >= rangos_dialar1[0] && rangos_dialar2[1] < rangos_dialar1[1]))
                    {
                        SqlConnector.sendMessage("Aviso!", "Los rangos de \"Diametro\" del area 1 y 2 estan sobrepuestos", MessageBoxIcon.Exclamation);
                        //return true;
                    }
                }
                if (checkBoxA3.Checked)
                {
                    if ((rangos_dialar1[0] >= rangos_dialar3[0] && rangos_dialar1[0] <= rangos_dialar3[1]) || (rangos_dialar1[1] >= rangos_dialar3[0] && rangos_dialar3[1] <= rangos_dialar3[1]) || (rangos_dialar2[0] >= rangos_dialar1[0] && rangos_dialar3[0] <= rangos_dialar1[1]) || (rangos_dialar3[1] >= rangos_dialar1[0] && rangos_dialar3[1] < rangos_dialar1[1]))
                    {
                        SqlConnector.sendMessage("Aviso!", "Los rangos de \"Diametro\" del area 1 y 3 estan sobrepuestos", MessageBoxIcon.Exclamation);
                        //return true;
                    }
                }
                if (checkBoxA4.Checked)
                {
                    if ((rangos_dialar1[0] >= rangos_dialar4[0] && rangos_dialar1[0] <= rangos_dialar4[1]) || (rangos_dialar1[1] >= rangos_dialar4[0] && rangos_dialar1[1] <= rangos_dialar4[1]) || (rangos_dialar4[0] >= rangos_dialar1[0] && rangos_dialar4[0] <= rangos_dialar1[1]) || (rangos_dialar4[1] >= rangos_dialar1[0] && rangos_dialar4[1] < rangos_dialar1[1]))
                    {
                        SqlConnector.sendMessage("Aviso!", "Los rangos de \"Diametro\" del area 1 y 4 estan sobrepuestos", MessageBoxIcon.Exclamation);
                        //return true;
                    }
                }
            }
            if (checkBoxA2.Checked)
            {
                if (checkBoxA3.Checked)
                {
                    if ((rangos_dialar2[0] >= rangos_dialar3[0] && rangos_dialar2[0] <= rangos_dialar3[1]) || (rangos_dialar2[1] >= rangos_dialar3[0] && rangos_dialar2[1] <= rangos_dialar3[1]) || (rangos_dialar3[0] >= rangos_dialar2[0] && rangos_dialar3[0] <= rangos_dialar2[1]) || (rangos_dialar3[1] >= rangos_dialar2[0] && rangos_dialar3[1] < rangos_dialar2[1]))
                    {
                        SqlConnector.sendMessage("Aviso!", "Los rangos de \"Diametro\" del area 2 y 3 estan sobrepuestos", MessageBoxIcon.Exclamation);
                        //return true;
                    }
                }
                if (checkBoxA4.Checked)
                {
                    if ((rangos_dialar2[0] >= rangos_dialar4[0] && rangos_dialar2[0] <= rangos_dialar4[1]) || (rangos_dialar2[1] >= rangos_dialar4[0] && rangos_dialar2[1] <= rangos_dialar4[1]) || (rangos_dialar4[0] >= rangos_dialar2[0] && rangos_dialar4[0] <= rangos_dialar2[1]) || (rangos_dialar4[1] >= rangos_dialar2[0] && rangos_dialar4[1] < rangos_dialar2[1]))
                    {
                        SqlConnector.sendMessage("Aviso!", "Los rangos de \"Diametro\" del area 2 y 3 estan sobrepuestos", MessageBoxIcon.Exclamation);
                        //return true;
                    }
                }
            }
            if (checkBoxA3.Checked)
            {
                if (checkBoxA4.Checked)
                {
                    if ((rangos_dialar3[0] >= rangos_dialar4[0] && rangos_dialar3[0] <= rangos_dialar4[1]) || (rangos_dialar3[1] >= rangos_dialar4[0] && rangos_dialar3[1] <= rangos_dialar4[1]) || (rangos_dialar4[0] >= rangos_dialar3[0] && rangos_dialar4[0] <= rangos_dialar3[1]) || (rangos_dialar4[1] >= rangos_dialar3[0] && rangos_dialar4[1] < rangos_dialar3[1]))
                    {
                        SqlConnector.sendMessage("Aviso!", "Los rangos de \"Diametro\" del area 3 y 4 estan sobrepuestos", MessageBoxIcon.Exclamation);
                        //return true;
                    }
                }
            }
            //return false;
        }

        private void checkBoxA1_CheckedChanged(object sender, EventArgs e)
        {
            Area_Checked(1);
        }

        private void checkBoxA2_CheckedChanged(object sender, EventArgs e)
        {
            Area_Checked(2);
        }

        private void checkBoxA3_CheckedChanged(object sender, EventArgs e)
        {
            Area_Checked(3);
        }

        private void checkBoxA4_CheckedChanged(object sender, EventArgs e)
        {
            Area_Checked(4);
        }
               
        private void Area_Checked(int number_area)
        {
            CheckBox checkbox = (CheckBox)getComponent(0, number_area);
            getComponent(1, number_area).Enabled = checkbox.Checked;
            getComponent(2, number_area).Enabled = checkbox.Checked;
            getComponent(3, number_area).Enabled = checkbox.Checked;
            getComponent(4, number_area).Enabled = checkbox.Checked;
            getComponent(5, number_area).Enabled = checkbox.Checked;
        }

        private void umaforBox_Populate()
        {
            umaforBox.Items.Clear();

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
                umaforBox.Items.Add(ecuacion_volumen.getUmafor());
            }
            //umaforBox.SelectedIndex = 0;
        }

        private void AgregarUmafor_Click(object sender, EventArgs e)
        {
            if (listUmafor.SelectedIndices.Count > 0)
            {
                int i = listUmafor.SelectedIndices[0];
                DialogResult dr = SqlConnector.sendOptionsMessage("Decision", "¿Seguro que desea eliminar el umafor?.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    string s = listUmafor.Items[i].Text;
                    listUmafor.Items.RemoveAt(i);

                }
            }
            else
            {
                SqlConnector.sendMessage("Alert", "Para Eliminar Debe Seleccionar El Umafor", MessageBoxIcon.Exclamation);
            }
        }

        private void DiametroTxB1_Enter(object sender, EventArgs e)
        {
            if (DiametroTxB1.Text == "     Num-Num")
            {
                DiametroTxB1.Text = "";
                DiametroTxB1.ForeColor = Color.Black;
            }
        }

        private void DiametroTxB1_Leave(object sender, EventArgs e)
        {
            if (DiametroTxB1.Text == "")
            {
                DiametroTxB1.Text = "     Num-Num";
                DiametroTxB1.ForeColor = Color.Gray;
            }
        }

        private void umaforBox_Click(object sender, EventArgs e)
        {
            
        }

        private void umaforBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> list = listUmafor.Items.Cast<ListViewItem>()
                                 .Select(item => item.Text)
                                 .ToList();

            if (list.Contains(umaforBox.SelectedItem.ToString()))
            {
                SqlConnector.sendMessage("Alerta", "Esa Umafor/Region ya esta registrado al proyecto", MessageBoxIcon.Asterisk);
            }
            else
            {
                listUmafor.Items.Add(umaforBox.SelectedItem.ToString());
            }
        }

        private void textBoxSuperficie_KeyPress(object sender, KeyPressEventArgs e)
        {
            //labelNombre.Text = "" + e.KeyChar;

            if (Regex.IsMatch(textBoxSuperficie.Text, "[^0-9]"))
            {
                MessageBox.Show("Solo Ingrese Numeros en este Campo..");
                textBoxSuperficie.Text = textBoxSuperficie.Text.Remove(textBoxSuperficie.Text.Length - 1);
            }
        }
    }
}
