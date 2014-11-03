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
    public partial class frmGestionProveedor : Form
    {
        private Proveedor proveedor;

        public frmGestionProveedor()
        {
            InitializeComponent();
        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            frmAgregarEditarProveedor faep = new frmAgregarEditarProveedor();
            faep.actualizarDataGridEvento += new frmAgregarEditarProveedor.actualizarDataGrid(llenarDataGrid);
            faep.MdiParent = this.MdiParent;
            faep.Show();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            try{

                int r = dataGridProveedor.CurrentCell.RowIndex;

                frmAgregarEditarProveedor faep = new frmAgregarEditarProveedor(Convert.ToInt32(dataGridProveedor.Rows[r].Cells["idproveedor"].Value));
                faep.actualizarDataGridEvento += new frmAgregarEditarProveedor.actualizarDataGrid(llenarDataGrid);
                faep.MdiParent = this.MdiParent;
                faep.Show();
            }
            catch{
                return;
            }
        }

        private void llenarDataGrid()
        {
            this.buttonEditar.Enabled = false;
            this.buttonEliminar.Enabled = false;

            ArrayList colProveedores = new ArrayList();

            proveedor.Filtro = textFiltro.Text;
            colProveedores = proveedor.coleccion();

            this.dataGridProveedor.Rows.Clear();

            for (int i = 0; i < colProveedores.Count; i++)
            {

                Proveedor objProveedorLocal = new Proveedor();
                objProveedorLocal.Repuestos = new ArrayList();

                objProveedorLocal = (Proveedor)colProveedores[i];

                this.dataGridProveedor.Rows.Add();
                this.dataGridProveedor.Rows[i].Cells["idproveedor"].Value = objProveedorLocal.Id.ToString();
                this.dataGridProveedor.Rows[i].Cells["nombreRazonSocial"].Value = objProveedorLocal.NombreRazonSocial;
                this.dataGridProveedor.Rows[i].Cells["email"].Value = objProveedorLocal.Email;
                this.dataGridProveedor.Rows[i].Cells["cuit"].Value = objProveedorLocal.Cuit;
                this.dataGridProveedor.Rows[i].Cells["telefono"].Value = objProveedorLocal.Telefono;
                this.dataGridProveedor.Rows[i].Cells["direccion"].Value = objProveedorLocal.Direccion;
                this.dataGridProveedor.Rows[i].Cells["cp"].Value = objProveedorLocal.Cp;
                this.dataGridProveedor.Rows[i].Cells["localidad"].Value = objProveedorLocal.Localidad;
                this.dataGridProveedor.Rows[i].Cells["provincia"].Value = objProveedorLocal.Provincia;
                this.dataGridProveedor.Rows[i].Cells["observaciones"].Value = objProveedorLocal.Observaciones;
                this.dataGridProveedor.Rows[i].Cells["paginaweb"].Value = objProveedorLocal.PaginaWeb;
                this.dataGridProveedor.Rows[i].Cells["banconombre"].Value = objProveedorLocal.BancoNombre;
                this.dataGridProveedor.Rows[i].Cells["titularcuenta"].Value = objProveedorLocal.TitularCuenta;
                this.dataGridProveedor.Rows[i].Cells["cuentatipo"].Value = objProveedorLocal.CuentaTipo;
                this.dataGridProveedor.Rows[i].Cells["numerocuenta"].Value = objProveedorLocal.CuentaNumero;

                this.dataGridProveedor.ClearSelection();
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Eliminar?", "Eliminacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int r = dataGridProveedor.CurrentCell.RowIndex;

                proveedor.Id = Convert.ToInt32(dataGridProveedor.Rows[r].Cells["idproveedor"].Value);
                proveedor.eliminar();
                llenarDataGrid();
            }
        }

        private void frmGestionProveedor_Load(object sender, EventArgs e)
        {
            proveedor = new Proveedor();
            proveedor.Repuestos = new ArrayList();

            llenarDataGrid();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.buttonEditar.Enabled = true;
            this.buttonEliminar.Enabled = true;
        }

        private void dataGridProveedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.buttonEditar.PerformClick();
        }

        private void textFiltro_TextChanged(object sender, EventArgs e)
        {
            llenarDataGrid();
        }

        private void frmGestionProveedor_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
