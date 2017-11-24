using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace SylDeskForm
{
    public partial class FormRegistro2 : System.Windows.Forms.Form
    {
        public int proyecto_id;
        MySqlCommand cmd;

        public FormRegistro2(int proyecto_id)
        {
            this.proyecto_id = proyecto_id;
            InitializeComponent();

            comboBoxSitios_Populate();
            comboBoxSitios.SelectedIndex = 0;
            comboBoxAreas.SelectedIndex = 0;

            dataGridViewIndividuos_Populate();
            fillForm();
        }

        /*private void labelClose_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void labelMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void labelClose_MouseHover(object sender, EventArgs e)
        {
            this.labelClose.ForeColor = Color.Red;
        }

        private void labelClose_MouseLeave(object sender, EventArgs e)
        {
            this.labelClose.ForeColor = Color.Transparent;
        }

        private void labelMinimize_MouseHover(object sender, EventArgs e)
        {
            this.labelMinimize.ForeColor = Color.Gray;
        }

        private void labelMinimize_MouseLeave(object sender, EventArgs e)
        {
            this.labelMinimize.ForeColor = Color.Transparent;
        }*/


        private void dataGridViewIndividuos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridViewIndividuos.Rows[dataGridViewIndividuos.CurrentCell.RowIndex];
            cmd = SqlConnector.getConnection(cmd);

            string parameters1 = "";
            string parameters2 = "";

            if (dataGridViewIndividuos.CurrentCell.ColumnIndex == 7)
            {
                dataGridViewIndividuos.Rows[dataGridViewIndividuos.CurrentCell.RowIndex].Cells[6].Value = (Convert.ToDouble(dataGridViewIndividuos.CurrentCell.Value) * Math.PI).ToString("F4");
                parameters1 += "perimetro, dimaetro";
                parameters2 += "@perimetro, @dimaetro";
                cmd.Parameters.AddWithValue("@6", row.Cells[6].Value);
                cmd.Parameters.AddWithValue("@7", row.Cells[7].Value);
            }
            else if (dataGridViewIndividuos.CurrentCell.ColumnIndex == 6)
            {
                dataGridViewIndividuos.Rows[dataGridViewIndividuos.CurrentCell.RowIndex].Cells[7].Value = (Convert.ToDouble(dataGridViewIndividuos.CurrentCell.Value) / Math.PI).ToString("F4");
                parameters1 += "perimetro, dimaetro";
                parameters2 += "@perimetro, @dimaetro";
                cmd.Parameters.AddWithValue("@6", row.Cells[6].Value);
                cmd.Parameters.AddWithValue("@7", row.Cells[7].Value);
            }
            else
            {

            }
            try
            {               
                cmd.CommandText = "Insert into individuos(proyecto_id, sitio, area, numero)" +
                "Values(@proyecto_id, @sitio, @area, @numero)";
                cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
                cmd.Parameters.AddWithValue("@sitio", comboBoxSitios.SelectedItem);
                cmd.Parameters.AddWithValue("@area", comboBoxAreas.SelectedItem);
                cmd.Parameters.AddWithValue("@numero", row.Cells["Numero"].Value);
                cmd.ExecuteNonQuery();
            }
            catch
            {
            }
        }

        private void dataGridViewIndividuos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                dataGridViewIndividuos.Rows.Clear();
            }
        }
        
        private void basura()
        {   
            /*
            cmd = SqlConnector.getConnection(cmd);
            cmd.CommandText = "DELETE FROM individuos WHERE sitio = @sitio AND area = @area";
            cmd.Parameters.AddWithValue("@sitio", comboBoxSitios.SelectedItem);
            cmd.Parameters.AddWithValue("@area", comboBoxAreas.SelectedItem);
            cmd.ExecuteNonQuery();

            int index = 1;
            */
            
            
                /*
                string messageBoxText = "Faltan Elementos en la fila: " + index;
                string caption = "Error";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                System.Windows.MessageBox.Show(messageBoxText, caption, button, icon);
                */            
        }

        private void buttonAgregarSitio_Click(object sender, EventArgs e)
        {
            comboBoxSitios.Items.Add(comboBoxSitios.Items.Count + 1);
            cmd = SqlConnector.getConnection(cmd);
            cmd.CommandText = "Insert into sitios(proyecto_id, numero_sitio, numero_consecutivo)Values(@proyecto_id, @numero_sitio, @numero_consecutivo)";
            cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
            cmd.Parameters.AddWithValue("@numero_sitio", comboBoxSitios.Items.Count);
            cmd.Parameters.AddWithValue("@numero_consecutivo", 1);
            cmd.ExecuteNonQuery();
        }

        private void buttonBorrarSitio_Click(object sender, EventArgs e)
        {
            if (comboBoxSitios.Items.Count > 1)
            {
                cmd = SqlConnector.getConnection(cmd);
                cmd.CommandText = "DELETE FROM individuos WHERE proyecto_id = @proyecto_id AND sitio = @sitio";
                cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
                cmd.Parameters.AddWithValue("@sitio", comboBoxSitios.Items.Count);
                cmd.ExecuteNonQuery();

                cmd = SqlConnector.getConnection(cmd);
                cmd.CommandText = "DELETE FROM sitios WHERE proyecto_id = @proyecto_id AND numero_sitio = @numero_sitio";
                cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
                cmd.Parameters.AddWithValue("@numero_sitio", comboBoxSitios.Items.Count);
                cmd.ExecuteNonQuery();

                if (comboBoxSitios.Items.Count == comboBoxSitios.SelectedIndex + 1)
                {
                    comboBoxSitios.SelectedIndex -= 1;
                }
                comboBoxSitios.Items.Remove(comboBoxSitios.Items.Count);
            }
        }

        private void comboBoxSitios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSitios.SelectedItem != null)
            {
                fillForm();
                if (comboBoxAreas.SelectedItem != null)
                {
                    dataGridViewIndividuos_Populate();
                }
            }
        }

        private void comboBoxAreas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSitios.SelectedItem != null && comboBoxAreas.SelectedItem != null)
            {
                    dataGridViewIndividuos_Populate();
            }

            if (comboBoxAreas.SelectedIndex < 2)
            {
                dataGridViewIndividuos.Columns["perimetro"].Visible = true;
                dataGridViewIndividuos.Columns["diametro"].Visible = true;
                dataGridViewIndividuos.Columns["alturafl"].Visible = true;
                dataGridViewIndividuos.Columns["coberturalargo"].Visible = false;
                dataGridViewIndividuos.Columns["coberturaancho"].Visible = false;
                dataGridViewIndividuos.Columns["formadefuste"].Visible = true;
            }
            else
            {
                dataGridViewIndividuos.Columns["perimetro"].Visible = false;
                dataGridViewIndividuos.Columns["diametro"].Visible = false;
                dataGridViewIndividuos.Columns["alturafl"].Visible = false;
                dataGridViewIndividuos.Columns["coberturalargo"].Visible = true;
                dataGridViewIndividuos.Columns["coberturaancho"].Visible = true;
                dataGridViewIndividuos.Columns["formadefuste"].Visible = true;
            }
        }

        private void textBoxX_TextChanged(object sender, EventArgs e)
        {
            cmd = SqlConnector.getConnection(cmd);
            cmd.CommandText = "UPDATE sitios SET coordenada_x = @coordenada_x WHERE proyecto_id = @proyecto_id AND numero_sitio = @numero_sitio";
            cmd.Parameters.AddWithValue("@coordenada_x", textBoxX.Text);
            cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
            cmd.Parameters.AddWithValue("@numero_sitio", comboBoxSitios.SelectedItem);
            cmd.ExecuteNonQuery();
        }

        private void textBoxY_TextChanged(object sender, EventArgs e)
        {
            cmd = SqlConnector.getConnection(cmd);
            cmd.CommandText = "UPDATE sitios SET coordenada_y = @coordenada_y WHERE proyecto_id = @proyecto_id AND numero_sitio = @numero_sitio";
            cmd.Parameters.AddWithValue("@coordenada_y", textBoxY.Text);
            cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
            cmd.Parameters.AddWithValue("@numero_sitio", comboBoxSitios.SelectedItem);
            cmd.ExecuteNonQuery();
        }

        private void textBoxMunicipio_TextChanged(object sender, EventArgs e)
        {
            cmd = SqlConnector.getConnection(cmd);
            cmd.CommandText = "UPDATE sitios SET municipio = @municipio WHERE proyecto_id = @proyecto_id AND numero_sitio = @numero_sitio";
            cmd.Parameters.AddWithValue("@municipio", textBoxMunicipio.Text);
            cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
            cmd.Parameters.AddWithValue("@numero_sitio", comboBoxSitios.SelectedItem);
            cmd.ExecuteNonQuery();
        }

        private void textBoxEstadoSucesional_TextChanged(object sender, EventArgs e)
        {
            cmd = SqlConnector.getConnection(cmd);
            cmd.CommandText = "UPDATE sitios SET estado_sucesional = @estado_sucesional WHERE proyecto_id = @proyecto_id AND numero_sitio = @numero_sitio";
            cmd.Parameters.AddWithValue("@estado_sucesional", textBoxEstadoSucesional.Text);
            cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
            cmd.Parameters.AddWithValue("@numero_sitio", comboBoxSitios.SelectedItem);
            cmd.ExecuteNonQuery();
        }
        
    
        private void fillForm()
        {
            cmd = SqlConnector.getConnection(cmd);

            string sqlQueryString = "SELECT municipio, coordenada_x, coordenada_y, estado_sucesional FROM `sitios` where proyecto_id = @proyecto_id AND numero_sitio = @numero_sitio";
            cmd.CommandText = sqlQueryString;
            cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
            cmd.Parameters.AddWithValue("@numero_sitio", comboBoxSitios.SelectedItem);

            var results = cmd.ExecuteReader();

            results.Read();

            string textBoxMunicipioText = results[0].ToString();
            string textBoxXText = results[1].ToString();
            string textBoxYText = results[2].ToString();
            string textBoxEstadoSucesionalText = results[3].ToString();

            results.Close();
            results.Dispose();

            textBoxMunicipio.Text = textBoxMunicipioText;
            textBoxX.Text = textBoxXText;
            textBoxY.Text = textBoxYText;
            textBoxEstadoSucesional.Text = textBoxEstadoSucesionalText;


            cmd = SqlConnector.getConnection(cmd);

            sqlQueryString = "SELECT nombre, superficie, sector, descripcion FROM `proyectos` where id = @proyecto_id";
            cmd.CommandText = sqlQueryString;
            cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);

            results = cmd.ExecuteReader();

            results.Read();

            string labelNombreText = results[0].ToString();
            string labelSuperficieText = results[1].ToString();
            string labelSectorText = results[2].ToString();
            string labelDescripcionText = results[3].ToString();

            results.Close();
            results.Dispose();

            labelNombre.Text = labelNombreText;
            //labelSuperficie.Text = labelSuperficieText;
            //labelSector.Text = labelSectorText;
            //labelDescripcion.Text = labelDescripcionText;
        }

        private void comboBoxSitios_Populate()
        {
            cmd = SqlConnector.getConnection(cmd);

            string sqlQueryString = "SELECT numero_sitio FROM `sitios` where proyecto_id = @proyecto_id";
            cmd.CommandText = sqlQueryString;
            cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);

            var results = cmd.ExecuteReader();
            
            while(results.Read())
            {
                comboBoxSitios.Items.Add(results[0]);
            }

            results.Close();
            results.Dispose();            
        }

        private void dataGridViewIndividuos_Populate()
        {
            dataGridViewIndividuos.Rows.Clear();

            cmd = SqlConnector.getConnection(cmd);

            string sqlQueryString = "SELECT cuadrante, numero, arbolnumeroensitio, especie, nombrecientifico, " +
                "nombrecomun, familia, perimetro, diametro, alturafl, alturatotal, coberturalargo, coberturaancho, " +
                "formadefuste, estadocondicion " +
                " from `individuos` where proyecto_id = @proyecto_id AND sitio = @sitio AND area = @area";
            cmd.CommandText = sqlQueryString;
            cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
            cmd.Parameters.AddWithValue("@sitio", comboBoxSitios.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@area", comboBoxAreas.SelectedItem.ToString());

            var results = cmd.ExecuteReader();

            
            while (results.Read())
            {
                List<Object> lista_individuos = new List<Object>();
                lista_individuos.Add(results[0]);
                lista_individuos.Add(results[1]);
                lista_individuos.Add(results[2]);
                lista_individuos.Add(results[3]);
                lista_individuos.Add(results[4]);
                lista_individuos.Add(results[5]);
                lista_individuos.Add(results[6]);
                lista_individuos.Add(results[7]);
                lista_individuos.Add(results[8]);
                lista_individuos.Add(results[9]);
                lista_individuos.Add(results[10]);
                lista_individuos.Add(results[11]);
                lista_individuos.Add(results[12]);
                lista_individuos.Add(results[13]);
                lista_individuos.Add(results[14]);

                dataGridViewIndividuos.Rows.Insert(0, lista_individuos.ToArray());
            }

            results.Close();
            results.Dispose();
        }

        

        private void button12_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.Hide(); //esconde el form actual


            FormRegistro1 objeto = new FormRegistro1(); //objeto declarado para abrir el form2
            objeto.Show(); //abre el form declarado con el objeto
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            this.Hide(); //esconde el form actual


            FormRegistro3 objeto = new FormRegistro3(); //objeto declarado para abrir el form3
            objeto.Show(); //abre el form declarado con el objeto
        }

        private void buttonAgregarIndividuo_Click(object sender, EventArgs e)
        {
            cmd = SqlConnector.getConnection(cmd);

            string sqlQueryString = "SELECT numero_consecutivo FROM `sitios` where id = @proyecto_id AND numero_sitio = @numero_sitio";
            cmd.CommandText = sqlQueryString;
            cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
            cmd.Parameters.AddWithValue("@numero_sitio", comboBoxSitios.SelectedItem);

            var results = cmd.ExecuteReader();

            results.Read();

            int numero_consecutivo = (int)results[0];

            results.Close();
            results.Dispose();


            var newRow = dataGridViewIndividuos.Rows[dataGridViewIndividuos.Rows.Add()];
            newRow.Cells["numero"].Value = numero_consecutivo + 1;
            if (dataGridViewIndividuos.RowCount > 1)
            {
                newRow.Cells["arbolnumeroensitio"].Value = (int)dataGridViewIndividuos.Rows[dataGridViewIndividuos.RowCount - 2].Cells["arbolnumeroensitio"].Value + 1;
            }
            else
            {
                newRow.Cells["arbolnumeroensitio"].Value = 1;
            }
        }

        private void buttonAgregarBifurcacion_Click(object sender, EventArgs e)
        {

        }

        private void buttonEliminarIndividuo_Click(object sender, EventArgs e)
        {
            if (dataGridViewIndividuos.RowCount > 0)
            {
                if (dataGridViewIndividuos.SelectedRows.Count > 0)
                {
                    var row = dataGridViewIndividuos.SelectedRows[0];
                    dataGridViewIndividuos.Rows.RemoveAt(row.Index);
                }
            }
        }
    }
}
