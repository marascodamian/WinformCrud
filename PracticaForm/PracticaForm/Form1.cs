using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service;

namespace PracticaForm
{
    public partial class Form1 : Form
    {
        S_Productos objectS = new S_Productos();
        private string idProducto = null;
        private bool edit = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowProducts();
        }

        private void ShowProducts()
        {
            S_Productos objecto = new S_Productos();
            dataGridView1.DataSource = objecto.ShowProducts(); 
        }       

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //INSERTAR
            if (edit == false)
            {
                try
                {
                    objectS.InsertProducts(txtNombre.Text, txtDescripcion.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text);
                    MessageBox.Show("Se agregó Producto ATI!");
                    ShowProducts();
                    CleanForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se agregó tonto! por: " + ex);
                }

            }
            //EDITAR
            if(edit == true)
            {
                try
                {
                    objectS.ModifyProducts(txtNombre.Text, txtDescripcion.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text, idProducto);
                    MessageBox.Show("Se modificó Producto ATI!");
                    ShowProducts();
                    CleanForm();
                    edit = false;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("No se Modificó tonto! por: " + ex);
                }
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                edit = true;
                txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                txtDescripcion.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                txtMarca.Text = dataGridView1.CurrentRow.Cells["Marca"].Value.ToString();
                txtPrecio.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
                txtStock.Text = dataGridView1.CurrentRow.Cells["Stock"].Value.ToString();
                idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Selecione la fila a Modificar");
            }
        }

        private void CleanForm()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtMarca.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            { 
                idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                objectS.DeleteProducts(idProducto);
                MessageBox.Show("YA NO TA PRODUCTO!!!!");
                ShowProducts();
            }
            else
            {
                MessageBox.Show("Selecione la fila a Eliminar");
            }
        }
    }
}
