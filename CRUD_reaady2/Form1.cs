using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_reaady2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cargarTabla(null);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string dato = txtCampo.Text;
            cargarTabla(dato);
        }

        private void cargarTabla(string dato)
        {
            List<Productos> lista = new List<Productos>();
            CtrlProductos ctrlProductos = new CtrlProductos();
            dataGridView1.DataSource = ctrlProductos.consulta(dato);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnGuarda_Click(object sender, EventArgs e)
        {
            bool bandera = false;

            Productos _producto = new Productos();
            _producto.Codigo = txtCodigo.Text;
            _producto.Nombre = txtNombre.Text;
            _producto.Descripcion = txtDescripcion.Text;
            _producto.Precio_publico = double.Parse(txtPrecioPublico.Text);
            _producto.Existencias = int.Parse(txtExistencias.Text);

            CtrlProductos ctrl = new CtrlProductos();

            if(txtId.Text != "")
            {
                _producto.Id = int.Parse(txtId.Text);
                bandera = ctrl.actualizar(_producto);
            } else
            {
                bandera = ctrl.insertar(_producto);
            }

            if(bandera)
            {
                MessageBox.Show("Registro Guardado");
                limpiar();
                cargarTabla(null);
            }

        }

        private void limpiar()
        {
            txtId.Text = "";
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecioPublico.Text = "";
            txtExistencias.Text = "";
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtCodigo.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtDescripcion.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtPrecioPublico.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtExistencias.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bool bandera = false;
            DialogResult resultado = MessageBox.Show("Seguro que desea eliminar el registro?", "Salir",MessageBoxButtons.YesNoCancel);
            if(resultado == DialogResult.Yes)
            {
                int id = int.Parse (dataGridView1.CurrentRow.Cells[0].Value.ToString());
                CtrlProductos _ctrl = new CtrlProductos();
                bandera = _ctrl.eliminar(id);

                if (bandera)
                {
                    MessageBox.Show("Registro Guardado");
                    limpiar();
                    cargarTabla(null);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}
