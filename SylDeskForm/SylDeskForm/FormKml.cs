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

namespace SylDeskForm
{
    public partial class FormKml : Form
    {
        /*const string filePath = "../../kmlFile.kml";*/
        //const string filePath = @"C:\Users\omarc\Desktop\ejemplo.kml";

        VectorItemsLayer KmlLayer { get { return (VectorItemsLayer)mapControl1.Layers["KmlLayer"]; } }

        public FormKml()
        {
            InitializeComponent();
            this.mapControl1.CenterPoint = new DevExpress.XtraMap.GeoPoint(21.1588, -86.8999);
            this.mapControl1.ZoomLevel = 10D;

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

        private void AbrirKml_Click(object sender, EventArgs e)
        {
           #region #KmlFileDataAdapter

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            String kml = "";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                kml = openFileDialog1.FileName;

            }
            Uri baseUri = new Uri(System.Reflection.Assembly.GetEntryAssembly().Location);
            KmlLayer.Data = new KmlFileDataAdapter()
            {
                FileUri = new Uri(baseUri, kml)
            };


            #endregion #KmlFileDataAdapter
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide(); //esconde el form actual


            FormKml objeto = new FormKml(); //objeto declarado para abrir el form3
            objeto.Show(); //abre el form declarado con el objeto
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
    }
}
