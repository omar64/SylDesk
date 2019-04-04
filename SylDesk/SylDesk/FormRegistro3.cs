using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SylDesk
{
    public partial class FormRegistro3 : UserControl
    {
        Form1 form1;

        public FormRegistro3()
        {
            InitializeComponent();            
        }

        public void setForm(Form1 form1)
        {
            this.form1 = form1;
        }

        public void Initialize()
        {
            Empty();
            dataGridView1_Populate("");
        }

        public void Empty()
        {
            textBoxBuscar.Text = "";
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }

        private void textBoxBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView1_Populate(textBoxBuscar.Text);
        }

        private void dataGridView1_Populate(string text)
        {
            dataGridView1.Rows.Clear();

            List<Proyecto> list_proyectos = SqlConnector.proyectosGet(
                "SELECT * FROM proyectos where nombre like \"%" + text + "%\" ORDER BY id DESC",
                new String[] { },
                new String[] { }
            );

            foreach(Proyecto proyecto in list_proyectos)
            {
                dataGridView1.Rows.Insert(0, new String[] { proyecto.getNombre(), proyecto.getSuperficie(), proyecto.getDescripcion() });
            }
        }


        private void FormRegistro3_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(TipBox, "Lorem ipsum dolor sit amet consectetur adipiscing\n elit ornare, accumsan nec auctor morbi eget diam cubilia curae,\n justo nisl fringilla natoque sodales dignissim tristique.\n Massa morbi fringilla taciti pulvinar vel nascetur risus luctus eros,\n aliquam orci accumsan quam convallis id sociis lectus egestas, dui mattis aptent leo conubia arcu mi consequat.\n Dictumst senectus litora suscipit proin pretium mattis facilisi, montes posuere ut felis convallis\n dignissim eleifend luctus, praesent urna nullam ridiculus vitae enim.");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Proyecto proyecto = SqlConnector.proyectoGet(
                    "SELECT * from proyectos where id = @id",
                    new String[] { "id" },
                    new String[] { dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() }
                );

                if (e.ColumnIndex == this.detalle.Index)
                {
                    
                    form1.formRegistro2ToFront(proyecto);
                }
                else if (e.ColumnIndex == this.editar.Index)
                {
                    form1.formEditarToFront(proyecto);
                }
            }
        }

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            dataGridView1_Populate(textBoxBuscar.Text);
        }
    }
}
