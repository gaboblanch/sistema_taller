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
        private DateTime lastLoading;
        private int firstVisibleRow;
        private bool flagDataGrid = false;
        ArrayList colClientes;

        public frmGestionCliente()
        {
            InitializeComponent();
        }

        private void llenarDataGrid()
        {
            this.buttonEditar.Enabled = false;
            this.buttonEliminar.Enabled = false;

            if (this.textNombre.Text != "")
            {
                //BUSQUEDA POR APELLIDO
                this.dataGridCliente.Rows.Clear();
                try
                {
                    cliente.Filtro = this.textNombre.Text;
                    colClientes.Clear();
                    colClientes = cliente.coleccion();
                    flagDataGrid = true;
                }
                catch (MySql.Data.MySqlClient.MySqlException e)
                {
                    MessageBox.Show("Error: "+e,"ERROR");
                    this.Dispose();
                    return;
                }
            }
            else if (this.textDominio.Text != "")
            {
                //BUSQUEDA POR DOMINIO
                this.dataGridCliente.Rows.Clear();
                try
                {
                    cliente.Filtro = this.textDominio.Text;
                    colClientes.Clear();
                    colClientes = cliente.coleccionDominio();
                    flagDataGrid = true;
                }
                catch (MySql.Data.MySqlClient.MySqlException e)
                {
                    MessageBox.Show("Error: " + e, "ERROR");
                    this.Dispose();
                    return;
                }
            }
            else
            {
                try
                {
                    if (flagDataGrid)
                    {
                        cliente.Filtro = "";
                        this.dataGridCliente.Rows.Clear();
                        colClientes.Clear();
                        flagDataGrid = false;
                    }
                    colClientes.AddRange(cliente.coleccion());
                }
                catch (MySql.Data.MySqlClient.MySqlException e)
                {
                    MessageBox.Show("Error: " + e, "ERROR");
                    this.Dispose();
                    return;
                }
            }
            

            //this.dataGridCliente.Rows.Clear();

            for (int i = 0; i < colClientes.Count; i++)
            {
                if (i == 0)
                {
                    i = this.dataGridCliente.Rows.Count;
                }

                if (i == colClientes.Count)
                {
                    return;
                }

                this.dataGridCliente.Rows.Add();
                this.dataGridCliente.Rows[i].Cells["idcliente"].Value = ((Cliente)colClientes[i]).Id.ToString();
                this.dataGridCliente.Rows[i].Cells["dni"].Value = ((Cliente)colClientes[i]).Dni;
                this.dataGridCliente.Rows[i].Cells["nombreRazonSocial"].Value = ((Cliente)colClientes[i]).NombreRazonSocial;
                this.dataGridCliente.Rows[i].Cells["email"].Value = ((Cliente)colClientes[i]).Email;
                this.dataGridCliente.Rows[i].Cells["cuit"].Value = ((Cliente)colClientes[i]).Cuit;
                this.dataGridCliente.Rows[i].Cells["telefono"].Value = ((Cliente)colClientes[i]).Telefono;
                this.dataGridCliente.Rows[i].Cells["direccion"].Value = ((Cliente)colClientes[i]).Direccion;
                this.dataGridCliente.Rows[i].Cells["cp"].Value = ((Cliente)colClientes[i]).Cp;
                this.dataGridCliente.Rows[i].Cells["localidad"].Value = ((Cliente)colClientes[i]).Localidad;
                this.dataGridCliente.Rows[i].Cells["provincia"].Value = ((Cliente)colClientes[i]).Provincia;
                this.dataGridCliente.Rows[i].Cells["deuda"].Value = ((Cliente)colClientes[i]).Deuda;
                this.dataGridCliente.Rows[i].Cells["observaciones"].Value = ((Cliente)colClientes[i]).Observaciones;
                
                
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
            cliente.queryDataGridLimit();
            colClientes = new ArrayList();
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
        
        //CODIGO DE PRUEBA
        private int GetDisplayedRowsCount()
        {
            int count = dataGridCliente.Rows[dataGridCliente.FirstDisplayedScrollingRowIndex].Height;
            count = dataGridCliente.Height / count;
            return count;
        }
        //TERMINA CODIGO DE PRUEBA
        private void dataGridCliente_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.Type == ScrollEventType.SmallIncrement || e.Type == ScrollEventType.LargeIncrement)
            {
                if (e.NewValue >= dataGridCliente.Rows.Count - GetDisplayedRowsCount() && cliente.DataGridLimit > dataGridCliente.Rows.Count)
                {
                    //prevent loading from autoscroll.
                    TimeSpan ts = DateTime.Now - lastLoading;
                    if (ts.TotalMilliseconds > 200)
                    {
                        firstVisibleRow = e.NewValue;
                        cliente.MySQLLimit += 30;
                        llenarDataGrid();
                        dataGridCliente.FirstDisplayedScrollingRowIndex = e.OldValue;
                    }
                    else
                    {
                        dataGridCliente.FirstDisplayedScrollingRowIndex = e.OldValue;
                    }
                }
            }
        }

        private void textNombre_TextChanged(object sender, EventArgs e)
        {
            this.llenarDataGrid();
        }

        
    }
}
