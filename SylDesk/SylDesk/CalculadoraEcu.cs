using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SylDesk
{
    public partial class CalculadoraEcu : UserControl
    {
        private Form1 form1;
        private int proyecto_id = -1;
        private int status = 0;
        private String especie = "";

        public CalculadoraEcu()
        {
            InitializeComponent();
        }

        public void setForm(Form1 form1)
        {
            this.form1 = form1;
        }

        public void Initialize(int proyecto_id, int status, String  especie)
        {
            this.proyecto_id = proyecto_id;
            this.status = status;
            this.especie = especie;
            Empty();
            comboBox1_populate();
            comboBox2_populate();

            listBoxEcuacion_Populate();
        }

        public void Empty()
        {
            comboBox1_populate();
            comboBox2_populate();
            textBox3.Text = especie;
            Ecuaciontext.Text = "";
        }

        private void genericOperatorVariableButtonEvent(object sender, EventArgs e)
        {
            Button generic_operator_variable_button = (Button)sender;
            setNewWord(generic_operator_variable_button.Tag.ToString());
        }
        
        private void logButtonEvent(object sender, EventArgs e)
        {
            DialogResult dr = SqlConnector.sendYNMessageBox("La mayoría de las ecuaciones biométricas utilizadas para cálculo de volumen utilizan logaritmo natural (LN) ¿está seguro de continuar utilizando la operación LOG?");
            if (dr == DialogResult.Yes)
            {
                setNewWord("()log()");
            }
        }

        private void CalculadoraEcu_Load(object sender, EventArgs e)
        {

        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            int i = listView1.SelectedIndices[0];
            string s = listView1.Items[i].Tag.ToString();
            setNewWord(s);
        }

        private void listView2_ItemActivate(object sender, EventArgs e)
        {
            int i = listView2.SelectedIndices[0];
            string s = listView2.Items[i].Text;
            string s1 = s.Substring(0, s.IndexOf("-")).Trim();
            string s2 = s.Substring(s.IndexOf("-") + 1).Trim();
            
            EcuacionVolumen ecuacion_volumen = SqlConnector.ecuacionVolumenGet(
                "SELECT * FROM `ecuaciones_volumen` where especie = @especie AND umafor = @umafor ",
                new String[] { "especie", "umafor" },
                new String[] { s1, s2 }
            );

            comboBox1.Text = ecuacion_volumen.getInventario();
            Ecuaciontext.Text = ecuacion_volumen.getEcuacion();
            comboBox2.Text = s2;
            textBox3.Text = s1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "TODOS" && comboBox2.Text != "TODOS" && textBox3.Text != "" && Ecuaciontext.Text != "")
            {
                EcuacionVolumen ecuacion_volumen = SqlConnector.ecuacionVolumenGet(
                    "SELECT * FROM `ecuaciones_volumen` where inventario = @inventario AND umafor = @umafor AND especie = @especie",
                    new String[] { "inventario", "umafor", "especie" },
                    new String[] { comboBox1.Text, comboBox2.Text, textBox3.Text }
                );

                EcuacionVolumen ecuacion_volumen2 = SqlConnector.ecuacionVolumenGet(
                    "SELECT * FROM `ecuaciones_volumen` where umafor = @umafor",
                    new String[] { "umafor" },
                    new String[] { comboBox2.Text }
                );

                if (ecuacion_volumen != null)
                {
                    if (SqlConnector.sendYNMessageBox("La ecuación ya existe para la UMAFOR/Región seleccionada. ¿Desea reemplazarla?") == DialogResult.Yes)
                    {
                        SqlConnector.postPutDeleteGenerico(
                            "UPDATE `ecuaciones_volumen` SET ecuacion = @ecuacion WHERE inventario = @inventario AND umafor = @umafor AND especie = @especie",
                            new String[] { "inventario", "umafor", "especie", "ecuacion" },
                            new String[] { comboBox1.Text, comboBox2.Text, textBox3.Text, Ecuaciontext.Text }
                        );

                        if (status == 1)
                        {
                            if (especie == textBox3.Text)
                            {
                                if (SqlConnector.sendYNMessageBox("La UMAFOR/Región de la ecuación ingresada no se encuentra registrada como parte de los inventarios utilizados en el proyecto. ¿Desea agregarla?") == DialogResult.Yes)
                                {
                                    SqlConnector.postPutDeleteGenerico(
                                        "Insert into proyecto_ecuaciones(proyecto_id, umafor_region)Values(@proyecto_id, @umafor_region)",
                                        new String[] { "proyecto_id", "umafor_region" },
                                        new String[] { "" + proyecto_id, comboBox2.Text }
                                    );
                                    form1.formRegistro2ToFront(proyecto_id);
                                }
                                else
                                {
                                    Empty();
                                    textBox3.Text = especie;
                                    SqlConnector.sendMessageBox("No ha hecho el cambio necesario...");
                                }
                            }
                            else
                            {
                                if (SqlConnector.sendYNMessageBox("La UMAFOR/Región de la ecuación ingresada no se encuentra registrada como parte de los inventarios utilizados en el proyecto, Sin embargo es de otra especie a la necesitada en el momento. ¿Desea agregarla?") == DialogResult.Yes)
                                {
                                    SqlConnector.postPutDeleteGenerico(
                                        "Insert into proyecto_ecuaciones(proyecto_id, umafor_region)Values(@proyecto_id, @umafor_region)",
                                        new String[] { "proyecto_id", "umafor_region" },
                                        new String[] { "" + proyecto_id, comboBox2.Text }
                                    );
                                    Empty();
                                    textBox3.Text = especie;
                                    SqlConnector.sendMessageBox("Puede ser que la Umafor/Región para la especie necesitada en el momento siga sin estar vinculada!");
                                }
                                else
                                {
                                    SqlConnector.sendMessageBox("No ha hecho el cambio necesario...");
                                }
                            }                            
                        }
                    }
                }
                else
                {
                    if (ecuacion_volumen2 != null)
                    {
                        if (ecuacion_volumen2.getInventario() != comboBox1.Text)
                        {
                            SqlConnector.sendMessageBox(""+ ecuacion_volumen2.getInventario() + " -  " +  comboBox1.Text);
                            SqlConnector.sendMessageBox("El nombre de Umafor/Region debe ser unico y este ya se encuentra en otro inventario.");
                        }
                        else
                        {
                            SqlConnector.postPutDeleteGenerico(
                                "Insert into ecuaciones_volumen(inventario, umafor, especie, ecuacion)Values(@inventario, @umafor, @especie, @ecuacion)",
                                new String[] { "inventario", "umafor", "especie", "ecuacion" },
                                new String[] { comboBox1.Text, comboBox2.Text, textBox3.Text, Ecuaciontext.Text }
                            );

                            comboBox1_populate();

                            if (status == 1)
                            {
                                ProyectoEcuacion proyecto_ecuacion = SqlConnector.proyectoEcuacionGet(
                                    "SELECT * FROM `proyecto_ecuaciones` where umafor_region = @umafor_region and proyecto_id = @proyecto_id",
                                    new String[] { "umafor_region", "proyecto_id" },
                                    new String[] { comboBox2.Text, "" + proyecto_id }
                                );

                                if (proyecto_ecuacion == null)
                                {
                                    if (especie == textBox3.Text)
                                    {
                                        if (SqlConnector.sendYNMessageBox("La UMAFOR/Región de la ecuación ingresada no se encuentra registrada como parte de los inventarios utilizados en el proyecto. ¿Desea agregarla?") == DialogResult.Yes)
                                        {
                                            SqlConnector.postPutDeleteGenerico(
                                                "Insert into proyecto_ecuaciones(proyecto_id, umafor_region)Values(@proyecto_id, @umafor_region)",
                                                new String[] { "proyecto_id", "umafor_region" },
                                                new String[] { "" + proyecto_id, comboBox2.Text }
                                            );
                                            form1.formRegistro2ToFront(proyecto_id);
                                        }
                                        else
                                        {
                                            SqlConnector.sendMessageBox("No ha hecho el cambio necesario...");
                                            Empty();
                                            textBox3.Text = especie;
                                        }
                                    }
                                    else
                                    {
                                        if (SqlConnector.sendYNMessageBox("La UMAFOR/Región de la ecuación ingresada no se encuentra registrada como parte de los inventarios utilizados en el proyecto, Sin embargo es de otra especie a la necesitada en el momento. ¿Desea agregarla?") == DialogResult.Yes)
                                        {
                                            SqlConnector.postPutDeleteGenerico(
                                                "Insert into proyecto_ecuaciones(proyecto_id, umafor_region)Values(@proyecto_id, @umafor_region)",
                                                new String[] { "proyecto_id", "umafor_region" },
                                                new String[] { "" + proyecto_id, comboBox2.Text }
                                            );
                                            Empty();
                                            textBox3.Text = especie;
                                            SqlConnector.sendMessageBox("Puede ser que la Umafor/Región para la especie necesitada en el momento siga sin estar vinculada!");
                                        }
                                        else
                                        {
                                            Empty();
                                            textBox3.Text = especie;
                                            SqlConnector.sendMessageBox("No ha hecho el cambio necesario...");
                                        }
                                    }
                                }
                                else
                                {
                                    if (especie == textBox3.Text)
                                    {
                                        SqlConnector.sendMessageBox("La UMAFOR/Región de la ecuación ingresada ya se encuentra registrada como parte de los inventarios utilizados en el proyecto.");
                                        form1.formRegistro2ToFront(proyecto_id);
                                    }
                                    else
                                    {
                                        if(SqlConnector.sendYNMessageBox("La UMAFOR/Región de la ecuación ingresada ya se encuentra registrada como parte de los inventarios utilizados en el proyecto, Sin embargo es de otra especie a la necesitada en el momento. ¿Desea regresar?") == DialogResult.Yes)
                                        {
                                            form1.formRegistro2ToFront(proyecto_id);
                                        }
                                        else
                                        {
                                            SqlConnector.sendMessageBox("Puede ser que la Umafor/Región para la especie necesitada en el momento siga sin estar vinculada!");
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        SqlConnector.postPutDeleteGenerico(
                            "Insert into ecuaciones_volumen(inventario, umafor, especie, ecuacion)Values(@inventario, @umafor, @especie, @ecuacion)",
                            new String[] { "inventario", "umafor", "especie", "ecuacion" },
                            new String[] { comboBox1.Text, comboBox2.Text, textBox3.Text, Ecuaciontext.Text }
                        );
                        if (status == 1)
                        {
                            SqlConnector.postPutDeleteGenerico(
                                "Insert into proyecto_ecuaciones(proyecto_id, umafor_region)Values(@proyecto_id, @umafor_region)",
                                new String[] { "proyecto_id", "umafor_region" },
                                new String[] { "" + proyecto_id, comboBox2.Text }
                            );
                            if (especie == textBox3.Text)
                            {
                                SqlConnector.sendMessageBox("La UMAFOR/Región de la ecuación ingresada no se encuentra registrada en la base de datos, se agregará a dicha base y como parte de los inventarios utilizados en el proyecto. ");
                                form1.formRegistro2ToFront(proyecto_id);
                            }
                            else
                            {
                                if (SqlConnector.sendYNMessageBox("La UMAFOR/Región de la ecuación ingresada no se encuentra registrada en la base de datos, se agregará a dicha base y como parte de los inventarios utilizados en el proyecto, Sin embargo no es la especie necesitada en el momento. ¿Desea regresar?") == DialogResult.Yes)
                                {
                                    form1.formRegistro2ToFront(proyecto_id);
                                }
                                else
                                {
                                    SqlConnector.sendMessageBox("Puede ser que la Umafor/Región para la especie necesitada en el momento siga sin estar vinculada!");
                                }
                            }
                            
                            
                        }
                    }
                }

                listBoxEcuacion_Populate();
            }
            else
            {
                SqlConnector.sendMessageBox("faltan argumentos (inventario, umafor, especie o ecuacion) o inventario y umafor/region no pueden ser \"TODOS\".");
            }
        }

        private void listBoxEcuacion_Populate()
        {
            listView2.Items.Clear();

            String sqlQueryString = "";
            String[] var_names = new String[] { };
            String[] var_values = new String[] { };
            if (comboBox1.Text == "TODOS")
            {
                sqlQueryString = "SELECT * FROM `ecuaciones_volumen` Order By especie";
            }
            else
            {
                if (comboBox2.Text == "TODOS")
                {
                    sqlQueryString = "SELECT * FROM `ecuaciones_volumen` where inventario = @inventario Order By especie";
                    var_names = new String[] { "inventario" };
                    var_values = new String[] { "" + comboBox1.Text };
                }
                else
                {
                    sqlQueryString = "SELECT * FROM `ecuaciones_volumen` where inventario = @inventario AND umafor = @umafor Order By especie";
                    var_names = new String[] { "inventario", "umafor" };
                    var_values = new String[] { "" + comboBox1.Text, "" + comboBox2.Text };
                }
            }
            List<EcuacionVolumen> list_ecuaciones_volumen = SqlConnector.ecuacionesVolumenGet(
                sqlQueryString,
                var_names,
                var_values
            );

            foreach (EcuacionVolumen ecuacion_volumen in list_ecuaciones_volumen)
            {
                listView2.Items.Add(ecuacion_volumen.getEspecie() + " - " + ecuacion_volumen.getUmafor());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Empty();
        }        

        private void setNewWord(string word)
        {
            if ((Ecuaciontext.Text == "0" || Ecuaciontext.Text == "") && Ecuaciontext.Text != null )
            {
                Ecuaciontext.Text = word;
                Ecuaciontext.SelectionStart = word.Length;
            }
            else
            {
                if (Ecuaciontext.SelectionStart != Ecuaciontext.Text.Length)
                {
                    int cursor_index = Ecuaciontext.SelectionStart + word.Length;
                    Ecuaciontext.Text = Ecuaciontext.Text.Substring(0, Ecuaciontext.SelectionStart).Trim() + word + Ecuaciontext.Text.Substring(Ecuaciontext.SelectionStart).Trim();
                    Ecuaciontext.SelectionStart = cursor_index;
                }
                else
                {
                    Ecuaciontext.Text = Ecuaciontext.Text.Substring(0, Ecuaciontext.SelectionStart).Trim() + word;
                    Ecuaciontext.SelectionStart = Ecuaciontext.Text.Length;
                }
            }
        }

        private void buttonBorrar_Click(object sender, EventArgs e)
        {
            int i = listView2.SelectedIndices[0];
            if (SqlConnector.sendYNMessageBox("¿Seguro que desea eliminar la ecuación? No habrá forma de deshacer esta acción posteriormente.") == DialogResult.Yes)
            {                
                string s = listView2.Items[i].Text;
                string s1 = s.Substring(0, s.IndexOf("-")).Trim();
                string s2 = s.Substring(s.IndexOf("-") + 1).Trim();

                SqlConnector.postPutDeleteGenerico(
                    "DELETE FROM ecuaciones_volumen WHERE umafor = @umafor AND especie = @especie",
                    new String[] { "umafor", "especie" },
                    new String[] { s2, s1 }
                );

                Empty();
                listBoxEcuacion_Populate();
            }           
        }

        private void comboBox1_populate()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("TODOS");
            comboBox1.SelectedIndex = 0;

            List<EcuacionVolumen> list_ecuaciones_volumen = SqlConnector.ecuacionesVolumenGet(
                "SELECT * FROM `ecuaciones_volumen` Group By inventario Order By inventario",
                new String[] { },
                new String[] { }
            );

            foreach (EcuacionVolumen ecuacion_volumen in list_ecuaciones_volumen)
            {
                comboBox1.Items.Add(ecuacion_volumen.getInventario().Trim());
            }
        }

        private void comboBox2_populate()
        {
            comboBox2.Items.Clear();
            comboBox2.Items.Add("TODOS");
            comboBox2.SelectedIndex = 0;

            if (comboBox1.Text != "TODOS")
            {
                List<EcuacionVolumen> list_ecuaciones_volumen = SqlConnector.ecuacionesVolumenGet(
                    "SELECT * FROM `ecuaciones_volumen` where inventario = @inventario Group By umafor Order By umafor",
                    new String[] { "inventario" },
                    new String[] { "" + comboBox1.SelectedItem }
                );

                foreach(EcuacionVolumen ecuacion_volumen in list_ecuaciones_volumen)
                {
                    comboBox2.Items.Add(ecuacion_volumen.getUmafor());
                }
            }
        }

        private void comboBox1_SomethingChanged(object sender, EventArgs e)
        {
            comboBox2_populate();
            listBoxEcuacion_Populate();
        }

        private void comboBox2_SomethingChanged(object sender, EventArgs e)
        {
            listBoxEcuacion_Populate();
        }
    }
}