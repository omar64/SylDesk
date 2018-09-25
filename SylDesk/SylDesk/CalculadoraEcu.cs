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
        public CalculadoraEcu(Form1 form1)
        {
            this.form1 = form1;
            InitializeComponent();
        }

        

        public void Initialize()
        {
            Empty();
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
            if (Ecuaciontext.Text == "0" && Ecuaciontext.Text != null)
            {
                Ecuaciontext.Text = "1";
            }
            else
            {
                Ecuaciontext.Text = Ecuaciontext.Text + "1";
            }
        }

        private void num2_Click(object sender, EventArgs e)
        {
            if (Ecuaciontext.Text == "0" && Ecuaciontext.Text != null)
            {
                Ecuaciontext.Text = "2";
            }
            else
            {
                Ecuaciontext.Text = Ecuaciontext.Text + "2";
            }
        }

        private void num3_Click(object sender, EventArgs e)
        {
            if (Ecuaciontext.Text == "0" && Ecuaciontext.Text != null)
            {
                Ecuaciontext.Text = "3";
            }
            else
            {
                Ecuaciontext.Text = Ecuaciontext.Text + "3";
            }
        }

        private void num4_Click(object sender, EventArgs e)
        {
            if (Ecuaciontext.Text == "0" && Ecuaciontext.Text != null)
            {
                Ecuaciontext.Text = "4";
            }
            else
            {
                Ecuaciontext.Text = Ecuaciontext.Text + "4";
            }
        }

        private void num5_Click(object sender, EventArgs e)
        {
            if (Ecuaciontext.Text == "0" && Ecuaciontext.Text != null)
            {
                Ecuaciontext.Text = "5";
            }
            else
            {
                Ecuaciontext.Text = Ecuaciontext.Text + "5";
            }
        }

        private void num6_Click(object sender, EventArgs e)
        {
            if (Ecuaciontext.Text == "0" && Ecuaciontext.Text != null)
            {
                Ecuaciontext.Text = "6";
            }
            else
            {
                Ecuaciontext.Text = Ecuaciontext.Text + "6";
            }
        }

        private void num7_Click(object sender, EventArgs e)
        {
            if (Ecuaciontext.Text == "0" && Ecuaciontext.Text != null)
            {
                Ecuaciontext.Text = "7";
            }
            else
            {
                Ecuaciontext.Text = Ecuaciontext.Text + "7";
            }
        }

        private void num8_Click(object sender, EventArgs e)
        {
            if (Ecuaciontext.Text == "0" && Ecuaciontext.Text != null)
            {
                Ecuaciontext.Text = "8";
            }
            else
            {
                Ecuaciontext.Text = Ecuaciontext.Text + "8";
            }
        }

        private void num9_Click(object sender, EventArgs e)
        {
            if (Ecuaciontext.Text == "0" && Ecuaciontext.Text != null)
            {
                Ecuaciontext.Text = "9";
            }
            else
            {
                Ecuaciontext.Text = Ecuaciontext.Text + "9";
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (Ecuaciontext.Text == "0" && Ecuaciontext.Text != null)
            {
                Ecuaciontext.Text = "0";
            }
            else
            {
                Ecuaciontext.Text = Ecuaciontext.Text + "0";
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (Ecuaciontext.Text == "0" && Ecuaciontext.Text != null)
            {
                Ecuaciontext.Text = "sqrt()";
            }
            else
            {
                Ecuaciontext.Text = Ecuaciontext.Text + "sqrt()";
            }
        }

        

        private void button19_Click(object sender, EventArgs e)
        {
            if (Ecuaciontext.Text == "0" && Ecuaciontext.Text != null)
            {
                Ecuaciontext.Text = "log()";
            }
            else
            {
                Ecuaciontext.Text = Ecuaciontext.Text + "log()";
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (Ecuaciontext.Text == "0" && Ecuaciontext.Text != null)
            {
                Ecuaciontext.Text = "ln()";
            }
            else
            {
                Ecuaciontext.Text = Ecuaciontext.Text + "ln()";
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (Ecuaciontext.Text == "0" && Ecuaciontext.Text != null)
            {
                Ecuaciontext.Text = "+";
            }
            else
            {
                Ecuaciontext.Text = Ecuaciontext.Text + "+";
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (Ecuaciontext.Text == "0" && Ecuaciontext.Text != null)
            {
                Ecuaciontext.Text = "-";
            }
            else
            {
                Ecuaciontext.Text = Ecuaciontext.Text + "-";
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (Ecuaciontext.Text == "0" && Ecuaciontext.Text != null)
            {
                Ecuaciontext.Text = "exp()";
            }
            else
            {
                Ecuaciontext.Text = Ecuaciontext.Text + "exp()";
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            if (Ecuaciontext.Text == "0" && Ecuaciontext.Text != null)
            {
                Ecuaciontext.Text = "abs()";
            }
            else
            {
                Ecuaciontext.Text = Ecuaciontext.Text + "abs()";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Ecuaciontext.Text == "0" && Ecuaciontext.Text != null)
            {
                Ecuaciontext.Text = "*";
            }
            else
            {
                Ecuaciontext.Text = Ecuaciontext.Text + "*";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Ecuaciontext.Text == "0" && Ecuaciontext.Text != null)
            {
                Ecuaciontext.Text = "/";
            }
            else
            {
                Ecuaciontext.Text = Ecuaciontext.Text + "/";
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (Ecuaciontext.Text == "0" && Ecuaciontext.Text != null)
            {
                Ecuaciontext.Text = "(";
            }
            else
            {
                Ecuaciontext.Text = Ecuaciontext.Text + "(";
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (Ecuaciontext.Text == "0" && Ecuaciontext.Text != null)
            {
                Ecuaciontext.Text = ")";
            }
            else
            {
                Ecuaciontext.Text = Ecuaciontext.Text + ")";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Ecuaciontext.Text == "0" && Ecuaciontext.Text != null)
            {
                Ecuaciontext.Text = "^";
            }
            else
            {
                Ecuaciontext.Text = Ecuaciontext.Text + "^";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Ecuaciontext.Text == "0" && Ecuaciontext.Text != null)
            {
                Ecuaciontext.Text = "pi";
            }
            else
            {
                Ecuaciontext.Text = Ecuaciontext.Text + "pi";
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (Ecuaciontext.Text == "0" && Ecuaciontext.Text != null)
            {
                Ecuaciontext.Text = ".";
            }
            else
            {
                Ecuaciontext.Text = Ecuaciontext.Text + ".";
            }
        }

        private void CalculadoraEcu_Load(object sender, EventArgs e)
        {

        }

        private void diametrobutton_Click(object sender, EventArgs e)
        {
            if (Ecuaciontext.Text == "0" && Ecuaciontext.Text != null)
            {
                Ecuaciontext.Text = "DIAMETRO";
            }
            else
            {
                Ecuaciontext.Text = Ecuaciontext.Text + "DIAMETRO";
            }
        }

        private void perimetrobutton_Click(object sender, EventArgs e)
        {
            if (Ecuaciontext.Text == "0" && Ecuaciontext.Text != null)
            {
                Ecuaciontext.Text = "PERIMETRO";
            }
            else
            {
                Ecuaciontext.Text = Ecuaciontext.Text + "PERIMETRO";
            }
        }

        private void areabutton_Click(object sender, EventArgs e)
        {
            if (Ecuaciontext.Text == "0" && Ecuaciontext.Text != null)
            {
                Ecuaciontext.Text = "AREABASAL";
            }
            else
            {
                Ecuaciontext.Text = Ecuaciontext.Text + "AREABASAL";
            }
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            int i = listView1.SelectedIndices[0];
            string s = listView1.Items[i].Tag.ToString();
            if (Ecuaciontext.Text == "0" && Ecuaciontext.Text != null)
            {
                Ecuaciontext.Text = s;
            }
            else
            {
                Ecuaciontext.Text = Ecuaciontext.Text + s;
            }
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
                cmd.CommandText = "Insert into ecuaciones_volumen(inventario, umafor, especie, ecuacion)Values(@inventario, @umafor, @especie, @ecuacion)";
                cmd.Parameters.AddWithValue("@inventario", textBox1.Text);
                cmd.Parameters.AddWithValue("@umafor", textBox2.Text);
                cmd.Parameters.AddWithValue("@especie", textBox3.Text);
                cmd.Parameters.AddWithValue("@ecuacion", Ecuaciontext.Text);
                cmd.ExecuteNonQuery();

                Initialize();
            }
            else
            {
                sendMessageBox()
            }
        }

        private void listBoxEcuacion_Populate()
        {
            listView2.Items.Clear();
            cmd = SqlConnector.getConnection(cmd);

            string sqlQueryString = "SELECT especie, umafor FROM `ecuaciones_volumen` Order By especie";
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

        private void sendMessageBox(string message)
        {
            string messageBoxText = message;
            string caption = "Error";
            //MessageBoxButton button = MessageBoxButton.OK;
            //MessageBoxImage icon = MessageBoxImage.Error;
            MessageBox.Show(messageBoxText, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}