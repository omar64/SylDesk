using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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

            for (int i = 1; i <= 4; i++)
            {
                fill_area(i);
                Area_Checked(i);
            }
        }

        public void Empty()
        {
            textNombre.Text = "";
            textSuperficie.Text = "";
            textDescr.Text = "";
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
            Boolean error_flag = false;
            if (textNombre.Text != "" && textSuperficie.Text != "" && textDescr.Text != "")
            {
                if (!(Double.TryParse(textSuperficie.Text, out double aux2)))
                {
                    SqlConnector.sendMessage("Error", "Superficie debe ser numerico.", MessageBoxIcon.Error);
                    error_flag = true;
                }
                if (checkBoxA1.Checked)
                {
                    if (area_check(1))
                    {
                        error_flag = true;
                    }
                }
                if (checkBoxA2.Checked)
                {
                    if (area_check(2))
                    {
                        error_flag = true;
                    }
                }
                if (checkBoxA3.Checked)
                {
                    if (area_check(3))
                    {
                        error_flag = true;
                    }
                }
                if (checkBoxA4.Checked)
                {
                    if (area_check(4))
                    {
                        error_flag = true;
                    }
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
                    
                    if (checkBoxA1.Checked)
                    {
                        updateArea(1, checkBoxA1.Checked, SuperficieTxB1.Text, TagTxB1.Text, checkBoxVolumen1.Checked, DiametroTxB1.Text, AlturaTxB1.Text);
                    }
                    else
                    {
                        updateArea(1, checkBoxA1.Checked);
                    }
                    if (checkBoxA2.Checked)
                    {
                        updateArea(2, checkBoxA2.Checked, SuperficieTxB2.Text, TagTxB2.Text, checkBoxVolumen2.Checked, DiametroTxB2.Text, AlturaTxB2.Text);
                    }
                    else
                    {
                        updateArea(2, checkBoxA2.Checked);
                    }
                    if (checkBoxA3.Checked)
                    {
                        updateArea(3, checkBoxA3.Checked, SuperficieTxB3.Text, TagTxB3.Text, checkBoxVolumen3.Checked, DiametroTxB3.Text, AlturaTxB3.Text);
                    }
                    else
                    {
                        updateArea(3, checkBoxA3.Checked);
                    }
                    if (checkBoxA4.Checked)
                    {
                        updateArea(4, checkBoxA4.Checked, SuperficieTxB4.Text, TagTxB4.Text, checkBoxVolumen4.Checked, DiametroTxB4.Text, AlturaTxB4.Text);
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
                checkBoxVolumen1.Checked = Convert.ToBoolean(proyecto.getArea1VolCob());
                DiametroTxB1.Text = proyecto.getArea1DiaLar();
                AlturaTxB1.Text = proyecto.getArea1AltAnc();
            }
            else if (area_number == 2)
            {
                checkBoxA2.Checked = proyecto.getArea2Activo();
                SuperficieTxB2.Text = proyecto.getArea2Superficie();
                checkBoxVolumen2.Checked = Convert.ToBoolean(proyecto.getArea2VolCob());
                DiametroTxB2.Text = proyecto.getArea2DiaLar();
                AlturaTxB2.Text = proyecto.getArea2AltAnc();
            }
            else if (area_number == 3)
            {
                checkBoxA3.Checked = proyecto.getArea3Activo();
                SuperficieTxB3.Text = proyecto.getArea3Superficie();
                checkBoxVolumen3.Checked = Convert.ToBoolean(proyecto.getArea3VolCob());
                DiametroTxB3.Text = proyecto.getArea3DiaLar();
                AlturaTxB3.Text = proyecto.getArea3AltAnc();
            }
            else
            {
                checkBoxA4.Checked = proyecto.getArea4Activo();
                SuperficieTxB4.Text = proyecto.getArea4Superficie();
                checkBoxVolumen4.Checked = Convert.ToBoolean(proyecto.getArea4VolCob());
                DiametroTxB4.Text = proyecto.getArea4DiaLar();
                AlturaTxB4.Text = proyecto.getArea4AltAnc();
            }
        }

        private void updateArea(int area_number, Boolean bool_activo, string area_superficie, string area_tag, Boolean bool_area_vol_cob, string area_dia_lar, string area_alt_anc)
        {
            string activo = Convert.ToInt32(bool_activo).ToString();
            string area_vol_cob = Convert.ToInt32(bool_area_vol_cob).ToString();
            SqlConnector.postPutDeleteGenerico(
                "UPDATE `proyectos` SET  area" + area_number + "_activo = @area_activo, area" + area_number + "_superficie = @area_superficie, area" + area_number + "_tag = @area_tag, area" + area_number + "_vol_cob = @area_vol_cob, area" + area_number + "_dia_lar = @area_dia_lar, area" + area_number + "_alt_anc = @area_alt_anc WHERE id = @id",
                new String[] { "area_activo", "area_superficie", "area_tag", "area_vol_cob", "area_dia_lar", "area_alt_anc", "id" },
                new String[] { activo, area_superficie, area_tag, area_vol_cob, area_dia_lar, area_alt_anc, "" + proyecto.getId() }
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

        private Control getComponent(int type, int id)
        {
            //Type 0:Activado 1:Superficie, 2:Volumen, 3:Cobertura, 4:DiaLar, 5:AltAnc
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
            if (getComponent(1, number_area).Text == "" || getComponent(4, number_area).Text == "" || getComponent(5, number_area).Text == "")
            {
                SqlConnector.sendMessage("Error", "Faltan Datos del Area de muestreo " + number_area + ".", MessageBoxIcon.Error);
                error_flag = true;
            }
            if (getComponent(4, number_area).Text != "")
            {
                if (getComponent(4, number_area).Text.IndexOf("-") < 0)
                {
                    SqlConnector.sendMessage("Error", "En el campo de rangos de Diametro/Largo del Area" + number_area + " falta simbolo de separacion \"-\".", MessageBoxIcon.Error);
                    error_flag = true;
                }
                else
                {
                    if (Regex.Matches(getComponent(4, number_area).Text, "-").Count > 1)
                    {
                        SqlConnector.sendMessage("Error", "En el campo de rangos de Diametro/Largo del Area" + number_area + " hay mas de un simbolo de separacion \"-\".", MessageBoxIcon.Error);
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
                            SqlConnector.sendMessage("Error", "En el campo de rangos de Diametro/Largo del Area" + number_area + " el valor inferior debe ser numerico.", MessageBoxIcon.Error);
                            error_flag = true;
                        }
                        if (!flag2)
                        {
                            SqlConnector.sendMessage("Error", "En el campo de rangos de Diametro/Largo del Area" + number_area + " el valor superior debe ser numerico.", MessageBoxIcon.Error);
                            error_flag = true;
                        }
                        if (flag1 && flag2 && aux1 >= aux2)
                        {
                            SqlConnector.sendMessage("Error", "En el campo de rangos de Diametro/Largo del Area" + number_area + " el valor inferior no debe ser mayor o igual al superior.", MessageBoxIcon.Error);
                            error_flag = true;
                        }
                    }
                }
            }
            if (getComponent(5, number_area).Text != "")
            {
                if (getComponent(5, number_area).Text.IndexOf("-") < 0)
                {
                    SqlConnector.sendMessage("Error", "En el campo de rangos de Altura/Ancho del Area" + number_area + " falta simbolo de separacion \"-\".", MessageBoxIcon.Error);
                    error_flag = true;
                }
                else
                {
                    if (Regex.Matches(getComponent(5, number_area).Text, "-").Count > 1)
                    {
                        SqlConnector.sendMessage("Error", "En el campo de rangos de Altura/Ancho del Area" + number_area + " hay mas de un simbolo de separacion \"-\".", MessageBoxIcon.Error);
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
                            SqlConnector.sendMessage("Error", "En el campo de rangos de Altura/Ancho del Area" + number_area + " el valor inferior debe ser numerico.", MessageBoxIcon.Error);
                            error_flag = true;
                        }
                        if (!flag2)
                        {
                            SqlConnector.sendMessage("Error", "En el campo de rangos de Altura/Ancho del Area" + number_area + " el valor superior debe ser numerico.", MessageBoxIcon.Error);
                            error_flag = true;
                        }
                        if (flag1 && flag2 && aux1 >= aux2)
                        {
                            SqlConnector.sendMessage("Error", "En el campo de rangos de Altura/Ancho del Area" + number_area + " el valor inferior no debe ser mayor o igual al superior.", MessageBoxIcon.Error);
                            error_flag = true;
                        }
                    }
                }
            }
            if (!(Double.TryParse(getComponent(1, number_area).Text, out double aux3)))
            {
                SqlConnector.sendMessage("Error", "Superficie del Area" + number_area + " debe ser numerico.", MessageBoxIcon.Error);
                error_flag = true;
            }
            return error_flag;
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

        private void checkAreaRangeOverlap()
        {
            string[] rangos_dialar1_str;
            string[] rangos_dialar2_str;
            string[] rangos_dialar3_str;
            string[] rangos_dialar4_str;

            Double[] rangos_dialar1 = { 0, 0 };
            Double[] rangos_dialar2 = { 0, 0 };
            Double[] rangos_dialar3 = { 0, 0 };
            Double[] rangos_dialar4 = { 0, 0 };

            if (checkBoxA1.Checked)
            {
                rangos_dialar1_str = SqlConnector.getWordsDividedByMinus(getComponent(4, 1).Text);
                rangos_dialar1 = new Double[] { Convert.ToDouble(rangos_dialar1_str[0]), Convert.ToDouble(rangos_dialar1_str[1]) };
            }
            if (checkBoxA2.Checked)
            {
                rangos_dialar2_str = SqlConnector.getWordsDividedByMinus(getComponent(4, 2).Text);
                rangos_dialar2 = new Double[] { Convert.ToDouble(rangos_dialar2_str[0]), Convert.ToDouble(rangos_dialar2_str[1]) };
            }
            if (checkBoxA3.Checked)
            {
                rangos_dialar3_str = SqlConnector.getWordsDividedByMinus(getComponent(4, 3).Text);
                rangos_dialar3 = new Double[] { Convert.ToDouble(rangos_dialar3_str[0]), Convert.ToDouble(rangos_dialar3_str[1]) };
            }
            if (checkBoxA4.Checked)
            {
                rangos_dialar4_str = SqlConnector.getWordsDividedByMinus(getComponent(4, 4).Text);
                rangos_dialar4 = new Double[] { Convert.ToDouble(rangos_dialar4_str[0]), Convert.ToDouble(rangos_dialar4_str[1]) };
            }

            if (checkBoxA1.Checked)
            {

                if (checkBoxA2.Checked)
                {
                    if ((rangos_dialar1[0] >= rangos_dialar2[0] && rangos_dialar1[0] <= rangos_dialar2[1]) || (rangos_dialar1[1] >= rangos_dialar2[0] && rangos_dialar1[1] <= rangos_dialar2[1]) || (rangos_dialar2[0] >= rangos_dialar1[0] && rangos_dialar2[0] <= rangos_dialar1[1]) || (rangos_dialar2[1] >= rangos_dialar1[0] && rangos_dialar2[1] < rangos_dialar1[1]))
                    {
                        SqlConnector.sendMessage("Aviso!", "Los rangos del area 1 y 2 estan sobrepuestos", MessageBoxIcon.Exclamation);
                        //return true;
                    }
                }
                if (checkBoxA3.Checked)
                {
                    if ((rangos_dialar1[0] >= rangos_dialar3[0] && rangos_dialar1[0] <= rangos_dialar3[1]) || (rangos_dialar1[1] >= rangos_dialar3[0] && rangos_dialar3[1] <= rangos_dialar3[1]) || (rangos_dialar2[0] >= rangos_dialar1[0] && rangos_dialar3[0] <= rangos_dialar1[1]) || (rangos_dialar3[1] >= rangos_dialar1[0] && rangos_dialar3[1] < rangos_dialar1[1]))
                    {
                        SqlConnector.sendMessage("Aviso!", "Los rangos del area 1 y 3 estan sobrepuestos", MessageBoxIcon.Exclamation);
                        //return true;
                    }

                }
                if (checkBoxA4.Checked)
                {
                    if ((rangos_dialar1[0] >= rangos_dialar4[0] && rangos_dialar1[0] <= rangos_dialar4[1]) || (rangos_dialar1[1] >= rangos_dialar4[0] && rangos_dialar1[1] <= rangos_dialar4[1]) || (rangos_dialar4[0] >= rangos_dialar1[0] && rangos_dialar4[0] <= rangos_dialar1[1]) || (rangos_dialar4[1] >= rangos_dialar1[0] && rangos_dialar4[1] < rangos_dialar1[1]))
                    {
                        SqlConnector.sendMessage("Aviso!", "Los rangos del area 1 y 4 estan sobrepuestos", MessageBoxIcon.Exclamation);
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
                        SqlConnector.sendMessage("Aviso!", "Los rangos del area 2 y 3 estan sobrepuestos", MessageBoxIcon.Exclamation);
                        //return true;
                    }
                }
                if (checkBoxA4.Checked)
                {
                    if ((rangos_dialar2[0] >= rangos_dialar4[0] && rangos_dialar2[0] <= rangos_dialar4[1]) || (rangos_dialar2[1] >= rangos_dialar4[0] && rangos_dialar2[1] <= rangos_dialar4[1]) || (rangos_dialar4[0] >= rangos_dialar2[0] && rangos_dialar4[0] <= rangos_dialar2[1]) || (rangos_dialar4[1] >= rangos_dialar2[0] && rangos_dialar4[1] < rangos_dialar2[1]))
                    {
                        SqlConnector.sendMessage("Aviso!", "Los rangos del area 2 y 3 estan sobrepuestos", MessageBoxIcon.Exclamation);
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
                        SqlConnector.sendMessage("Aviso!", "Los rangos del area 3 y 4 estan sobrepuestos", MessageBoxIcon.Exclamation);
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
    }
}
