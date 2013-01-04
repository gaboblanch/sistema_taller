using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace SistemaGestionTaller
{
    public partial class frmGestionCliente : Form
    {
        private Cliente cliente;

        public frmGestionCliente()
        {
            InitializeComponent();
        }

        private void llenarDataGrid()
        {
            this.buttonEditar.Enabled = false;
            this.buttonEliminar.Enabled = false;

            ArrayList colClientes = new ArrayList();

            cliente.Filtro = this.textFiltro.Text;

            if (this.comboBox1.SelectedIndex == 0)
            {
                //BUSQUEDA POR APELLIDO
                try
                {
                    colClientes = cliente.coleccion();
                }
                catch (MySql.Data.MySqlClient.MySqlException e)
                {
                    MessageBox.Show("Error: "+e,"ERROR");
                    this.Dispose();
                    return;
                }
            }
            else
            {
                //BUSQUEDA POR DOMINIO
                try
                {
                    colClientes = cliente.coleccionDominio();
                }
                catch (MySql.Data.MySqlClient.MySqlException e)
                {
                    MessageBox.Show("Error: " + e, "ERROR");
                    this.Dispose();
                    return;
                }
            }
            

            this.dataGridCliente.Rows.Clear();

            for (int i = 0; i < colClientes.Count; i++)
            {
                Cliente objClienteLocal = new Cliente();

                objClienteLocal = (Cliente)colClientes[i];
                objClienteLocal.getDeuda();
                this.dataGridCliente.Rows.Add();
                this.dataGridCliente.Rows[i].Cells["idcliente"].Value = objClienteLocal.Id.ToString();
                this.dataGridCliente.Rows[i].Cells["dni"].Value = objClienteLocal.Dni;
                this.dataGridCliente.Rows[i].Cells["nombreRazonSocial"].Value = objClienteLocal.NombreRazonSocial;
                this.dataGridCliente.Rows[i].Cells["email"].Value = objClienteLocal.Email;
                this.dataGridCliente.Rows[i].Cells["cuit"].Value = objClienteLocal.Cuit;
                this.dataGridCliente.Rows[i].Cells["telefono"].Value = objClienteLocal.Telefono;
                this.dataGridCliente.Rows[i].Cells["direccion"].Value = objClienteLocal.Direccion;
                this.dataGridCliente.Rows[i].Cells["cp"].Value = objClienteLocal.Cp;
                this.dataGridCliente.Rows[i].Cells["localidad"].Value = objClienteLocal.Localidad;
                this.dataGridCliente.Rows[i].Cells["provincia"].Value = objClienteLocal.Provincia;
                this.dataGridCliente.Rows[i].Cells["deuda"].Value = objClienteLocal.Deuda;
                this.dataGridCliente.Rows[i].Cells["observaciones"].Value = objClienteLocal.Observaciones;
                
                
                this.dataGridCliente.ClearSelection();
            }
        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            frmAgregarEditarCliente faec = new frmAgregarEditarCliente();
            faec.actualizarDataGridEvento += new frmAgregarEditarCliente.actualizarDataGrid(llenarDataGrid);
            faec.MdiParent = this.MdiParent;
            faec.Show();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            int r = dataGridCliente.CurrentCell.RowIndex;

            frmAgregarEditarCliente faec = new frmAgregarEditarCliente(Convert.ToInt32(dataGridCliente.Rows[r].Cells["idcliente"].Value));
            faec.actualizarDataGridEvento += new frmAgregarEditarCliente.actualizarDataGrid(llenarDataGrid);
            faec.MdiParent = this.MdiParent;
            faec.Show();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar el cliente seleccionado?", "Eliminacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                int r = dataGridCliente.CurrentCell.RowIndex;
                cliente.Id = Convert.ToInt32(dataGridCliente.Rows[r].Cells["idcliente"].Value);

                cliente.eliminar();
                this.llenarDataGrid();
            }
        }

        private void frmGestionCliente_Load(object sender, EventArgs e)
        {
            cliente = new Cliente();
            this.comboBox1.SelectedIndex = 0;
            llenarDataGrid();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.buttonEditar.Enabled = true;
            this.buttonEliminar.Enabled = true;
        }

        private void dataGridCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.buttonEditar.PerformClick();
        }

        private void textFiltro_TextChanged(object sender, EventArgs e)
        {
            llenarDataGrid();
        }

        private void frmGestionCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void dataGridCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == Convert.ToChar(46))
            {
                this.buttonEliminar.PerformClick();
            }
        }

        
    }
}
