using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
//using kawaii_lolis = System.Windows.Forms.DataVisualization.Charting;
//using MySql.Data.MySqlClient;

namespace SylDesk
{
    public partial class CalculadoraEcu : UserControl
    {
        private Form1 form1;
        MySqlCommand cmd;
        private int status = 0;
        private int proyecto_id = -1;

        public CalculadoraEcu(Form1 form1)
        {
            this.form1 = form1;
            InitializeComponent();
        }

        

        public void Initialize(int status , int proyecto_id)
        {
            this.status = status;
            Empty();
            comboBox1_populate();
            comboBox2_populate();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

            listBoxEcuacion_Populate();
        }

        public void Empty()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            Ecuaciontext.Text = "";
            //listView2.Items.Clear();
        }

        private void num1_Click(object sender, EventArgs e)
        {
            setNewWord("1");
        }

        private void num2_Click(object sender, EventArgs e)
        {
            setNewWord("2");
        }

        private void num3_Click(object sender, EventArgs e)
        {
            setNewWord("3");
        }

        private void num4_Click(object sender, EventArgs e)
        {
            setNewWord("4");
        }

        private void num5_Click(object sender, EventArgs e)
        {
            setNewWord("5");
        }

        private void num6_Click(object sender, EventArgs e)
        {
            setNewWord("6");
        }

        private void num7_Click(object sender, EventArgs e)
        {
            setNewWord("7");
        }

        private void num8_Click(object sender, EventArgs e)
        {
            setNewWord("8");
        }

        private void num9_Click(object sender, EventArgs e)
        {
            setNewWord("9");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            setNewWord("0");
        }

        private void button25_Click(object sender, EventArgs e)
        {
            setNewWord("sqrt()");
        }

        

        private void button19_Click(object sender, EventArgs e)
        {
            DialogResult dr = SqlConnector.sendYNMessageBox("La mayoría de las ecuaciones biométricas utilizadas para cálculo de volumen utilizan logaritmo natural (LN) ¿está seguro de continuar utilizando la operación LOG?");
            if (dr == DialogResult.Yes)
            {
                setNewWord("()log()");
            }             
        }

        private void button18_Click(object sender, EventArgs e)
        {
            setNewWord("ln()");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            setNewWord("+");
        }

        private void button29_Click(object sender, EventArgs e)
        {
            setNewWord("-");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            setNewWord("exp()");
        }

        private void button30_Click(object sender, EventArgs e)
        {
            setNewWord("abs()");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            setNewWord("*");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            setNewWord("/");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            setNewWord("(");
        }

        private void button27_Click(object sender, EventArgs e)
        {
            setNewWord(")");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            setNewWord("^");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            setNewWord("pi");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            setNewWord(".");
        }

        private void CalculadoraEcu_Load(object sender, EventArgs e)
        {

        }

        private void diametrobutton_Click(object sender, EventArgs e)
        {
            setNewWord("DIAMETRO");
        }

        private void perimetrobutton_Click(object sender, EventArgs e)
        {
            setNewWord("PERIMETRO");
        }

        private void areabutton_Click(object sender, EventArgs e)
        {
            setNewWord("AREABASAL");
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
            textBox2.Text = s2;
            textBox3.Text = s1;

            cmd = SqlConnector.getConnection(cmd);

            string sqlQueryString = "SELECT inventario, ecuacion FROM `ecuaciones_volumen` where especie = @especie AND umafor = @umafor ";
            cmd.CommandText = sqlQueryString;
            cmd.Parameters.AddWithValue("@especie", textBox3.Text);
            cmd.Parameters.AddWithValue("@umafor", textBox2.Text);

            var results = cmd.ExecuteReader();

            if (results.Read())
            {
                textBox1.Text = results[0].ToString();
                Ecuaciontext.Text = results[1].ToString();
            }

            results.Close();
            results.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && Ecuaciontext.Text != "")
            {
                cmd = SqlConnector.getConnection(cmd);

                string sqlQueryString = "SELECT * FROM `ecuaciones_volumen` where inventario = @inventario AND umafor = @umafor AND especie = @especie";

                cmd.CommandText = sqlQueryString;
                cmd.Parameters.AddWithValue("@inventario", textBox1.Text);
                cmd.Parameters.AddWithValue("@umafor", textBox2.Text);
                cmd.Parameters.AddWithValue("@especie", textBox3.Text);

                var results = cmd.ExecuteReader();

                if (results.Read())
                {
                    results.Close();
                    results.Dispose();
                    if (SqlConnector.sendYNMessageBox("La ecuación ya existe para la UMAFOR/Región seleccionada. ¿Desea reemplazarla?") == DialogResult.Yes)

                    {
                        cmd = SqlConnector.getConnection(cmd);
                        cmd.CommandText = "UPDATE `ecuaciones_volumen` SET ecuacion = @ecuacion WHERE inventario = @inventario AND umafor = @umafor AND especie = @especie";
                        cmd.Parameters.AddWithValue("@inventario", textBox1.Text);
                        cmd.Parameters.AddWithValue("@umafor", textBox2.Text);
                        cmd.Parameters.AddWithValue("@especie", textBox3.Text);
                        cmd.Parameters.AddWithValue("@ecuacion", Ecuaciontext.Text);
                        cmd.ExecuteNonQuery();
                    }                    
                }
                else
                {
                    results.Close();
                    results.Dispose();

                    cmd = SqlConnector.getConnection(cmd);
                    cmd.CommandText = "Insert into ecuaciones_volumen(inventario, umafor, especie, ecuacion)Values(@inventario, @umafor, @especie, @ecuacion)";
                    cmd.Parameters.AddWithValue("@inventario", textBox1.Text);
                    cmd.Parameters.AddWithValue("@umafor", textBox2.Text);
                    cmd.Parameters.AddWithValue("@especie", textBox3.Text);
                    cmd.Parameters.AddWithValue("@ecuacion", Ecuaciontext.Text);
                    cmd.ExecuteNonQuery();

                    if (status == 1)
                    {
                        cmd = SqlConnector.getConnection(cmd);

                        sqlQueryString = "SELECT * FROM `proyecto_ecuaciones` where umafor_region = @umafor_region";

                        cmd.CommandText = sqlQueryString;
                        cmd.Parameters.AddWithValue("@umafor_region", textBox2.Text);

                        results = cmd.ExecuteReader();

                        if (results.Read())
                        {
                            results.Close();
                            results.Dispose();
                            if (SqlConnector.sendYNMessageBox("La UMAFOR/Región de la ecuación ingresada no se encuentra registrada como parte de los inventarios utilizados en el proyecto. ¿Desea agregarla?") == DialogResult.Yes)
                            {
                                cmd = SqlConnector.getConnection(cmd);
                                cmd.CommandText = "Insert into proyecto_ecuacion(proyecto_id, umafor_region)Values(@proyecto_id, @umafor_region)";
                                cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
                                cmd.Parameters.AddWithValue("@umafor_region", textBox2.Text);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            results.Close();
                            results.Dispose();
                            if (SqlConnector.sendYNMessageBox("La UMAFOR/Región de la ecuación ingresada no se encuentra registrada en la base de datos, se agregará a dicha base y como parte de los inventarios utilizados en el proyecto.") == DialogResult.Yes)
                            {
                                cmd = SqlConnector.getConnection(cmd);
                                cmd.CommandText = "Insert into proyecto_ecuacion(proyecto_id, umafor_region)Values(@proyecto_id, @umafor_region)";
                                cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
                                cmd.Parameters.AddWithValue("@umafor_region", textBox2.Text);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        form1.formRegistro2ToFront(proyecto_id);
                    }
                }

                listBoxEcuacion_Populate();
            }
            else
            {
                SqlConnector.sendMessageBox("faltan argumentos (inventario, umafor, especie o ecuacion).");
            }
        }

        private void listBoxEcuacion_Populate()
        {
            listView2.Items.Clear();
            cmd = SqlConnector.getConnection(cmd);

            string sqlQueryString = "";
            if (textBox1.Text == "TODOS")
            {
                if (textBox2.Text == "TODOS")
                {
                    sqlQueryString = "SELECT especie, umafor FROM `ecuaciones_volumen` Order By especie";
                }
                else
                {
                    sqlQueryString = "SELECT especie, umafor FROM `ecuaciones_volumen` where umafor = @umafor Order By especie";
                    cmd.Parameters.AddWithValue("@umafor", comboBox2.SelectedItem);
                }
            }
            else
            {
                if (textBox2.Text == "TODOS")
                {
                    sqlQueryString = "SELECT especie, umafor FROM `ecuaciones_volumen` where inventario = @inventario Order By especie";
                    cmd.Parameters.AddWithValue("@inventario", comboBox1.SelectedItem);
                }
                else
                {
                    sqlQueryString = "SELECT especie, umafor FROM `ecuaciones_volumen` where inventario = @inventario AND umafor = @umafor Order By especie";
                    cmd.Parameters.AddWithValue("@inventario", comboBox1.SelectedItem);
                    cmd.Parameters.AddWithValue("@umafor", comboBox2.SelectedItem);
                }
            }
            cmd.CommandText = sqlQueryString;

            var results = cmd.ExecuteReader();

            while (results.Read())
            {
                listView2.Items.Add(results[0].ToString() + " - " + results[1].ToString());
            }

            results.Close();
            results.Dispose();
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
            if(SqlConnector.sendYNMessageBox("¿Seguro que desea eliminar la ecuación? No habrá forma de deshacer esta acción posteriormente.") == DialogResult.Yes)
            {
                int i = listView2.SelectedIndices[0];
                string s = listView2.Items[i].Text;

                string s1 = s.Substring(0, s.IndexOf("-")).Trim();
                string s2 = s.Substring(s.IndexOf("-") + 1).Trim();

                cmd = SqlConnector.getConnection(cmd);
                cmd.CommandText = "DELETE FROM ecuaciones_volumen WHERE umafor = @umafor AND especie = @especie";
                cmd.Parameters.AddWithValue("@umafor", s1);
                cmd.Parameters.AddWithValue("@especie", s2);
                //cmd.Parameters.AddWithValue("@area", comboBoxAreas.SelectedItem);
                //cmd.Parameters.AddWithValue("@numero", dataGridViewIndividuos.Rows[row.Index].Cells["numero"].Value);
                cmd.ExecuteNonQuery();
                Empty();
                listBoxEcuacion_Populate();
            }           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.SelectedItem.ToString();
            comboBox2_populate();
            comboBox2.SelectedIndex = 0;
            listBoxEcuacion_Populate();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = comboBox2.SelectedItem.ToString();
            listBoxEcuacion_Populate();
        }

        private void comboBox1_populate()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("TODOS");
            cmd = SqlConnector.getConnection(cmd);
            String sqlQueryString = "SELECT inventario FROM `ecuaciones_volumen` Group By inventario Order By inventario";
            cmd.CommandText = sqlQueryString;

            var results = cmd.ExecuteReader();
            while (results.Read())
            {
                comboBox1.Items.Add(results[0]);
            }

            results.Close();
            results.Dispose();
        }

        private void comboBox2_populate()
        {
            comboBox2.Items.Clear();
            comboBox2.Items.Add("TODOS");
            if(textBox1.Text != "TODOS")
            {
                cmd = SqlConnector.getConnection(cmd);
                String sqlQueryString = "SELECT umafor FROM `ecuaciones_volumen` where inventario = @inventario Group By umafor Order By umafor";
                cmd.CommandText = sqlQueryString;
                cmd.Parameters.AddWithValue("@inventario", comboBox1.SelectedItem);

                var results = cmd.ExecuteReader();                
                while (results.Read())
                {
                    comboBox2.Items.Add(results[0]);
                }

                results.Close();
                results.Dispose();
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            comboBox2_populate();
            comboBox2.SelectedIndex = 0;
            listBoxEcuacion_Populate();
        }

        private void comboBox2_Leave(object sender, EventArgs e)
        {
            listBoxEcuacion_Populate();
        }
    }
}