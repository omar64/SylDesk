using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraMap;
using MySql.Data.MySqlClient;
using System.Windows;

namespace SylDeskForm
{
    public partial class FormKml : Form
    {
        MySqlCommand cmd;
        String kml_url = "";
        String id = "";
        /*const string filePath = "../../kmlFile.kml";*/
        //const string filePath = @"C:\Users\omarc\Desktop\ejemplo.kml";

        VectorItemsLayer KmlLayer { get { return (VectorItemsLayer)mapControl1.Layers["KmlLayer"]; } }

        public FormKml(String id)
        {
            InitializeComponent();
            this.id = id;
            this.mapControl1.CenterPoint = new DevExpress.XtraMap.GeoPoint(21.1588, -86.8999);
            this.mapControl1.ZoomLevel = 10D;

            cmd = SqlConnector.getConnection(cmd);

            string sqlQueryString = "SELECT kml_url from proyectos where id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandText = sqlQueryString;

            var results = cmd.ExecuteReader();


            if (results.Read())
            {
                kml_url = results[0].ToString();
                abrirKml(kml_url);
            }

            results.Close();
            results.Dispose();

            //#region #KmlFileDataAdapter
            // Create a KML file data adapter.

            /*Uri baseUri = new Uri(System.Reflection.Assembly.GetEntryAssembly().Location);
            KmlLayer.Data = new KmlFileDataAdapter()
            {
                FileUri = new Uri(baseUri, filePath)
            };*/

            //VectorItemsLayer layer = this.mapControl1.Layers["KmlLayer"] as VectorItemsLayer;
            //IMapDataAdapter stg = (IMapDataAdapter)KmlLayer.Data;
            //stg.GetItem(0).Visible = false;
            //stg.Items[0].Visible = false;
            //stg.Items.RemoveAt(0);
            //stg.Items.Add(new MapDot() { Location = new GeoPoint(0, 0) });


            //#endregion #KmlFileDataAdapter
        }

        private void FormKml_Load(object sender, EventArgs e)
        {

        }

        private void abrirKml(String url)
        {
            #region #KmlFileDataAdapter
            try
            {
                Uri baseUri = new Uri(System.Reflection.Assembly.GetEntryAssembly().Location);
                KmlLayer.Data = new KmlFileDataAdapter()
                {
                    FileUri = new Uri(baseUri, kml_url)
                };
            }
            catch(Exception e)
            {
                sendMessageBox("La ubicacion del archivo ha cambiado: " + kml_url);
            }
            

            #endregion #KmlFileDataAdapter
        }

        private void AbrirKml_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                kml_url = openFileDialog1.FileName;

                cmd = SqlConnector.getConnection(cmd);
                cmd.CommandText = "UPDATE proyectos SET kml_url = @kml_url WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@kml_url", kml_url);
                cmd.ExecuteNonQuery();
            }
            abrirKml(kml_url);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide(); //esconde el form actual


            //FormKml objeto = new FormKml(); //objeto declarado para abrir el form3
            //objeto.Show(); //abre el form declarado con el objeto
        }

        private void button10_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            this.Hide(); //esconde el form actual


            FormRegistro3 objeto = new FormRegistro3(); //objeto declarado para abrir el form3
            objeto.Show(); //abre el form declarado con el objeto
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide(); //esconde el form actual


            FormRegistroEspecie objeto = new FormRegistroEspecie(); //objeto declarado para abrir el form3
            objeto.Show(); //abre el form declarado con el objeto
        }

        private void sendMessageBox(string message)
        {
            string messageBoxText = message;
            string caption = "Error";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Error;
            System.Windows.MessageBox.Show(messageBoxText, caption, button, icon);
        }
    }
}
