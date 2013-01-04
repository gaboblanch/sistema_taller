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
    public partial class frmGestionTipoCuenta : Form
    {
        private TipoCuenta tipo;

        public frmGestionTipoCuenta()
        {
            InitializeComponent();
        }

        private void llenarDataGrid()
        {
            this.buttonEditar.Enabled = false;
            this.buttonEliminar.Enabled = false;

            ArrayList colTipos = new ArrayList();
            colTipos = tipo.coleccion();

            this.dataGridTipoCuenta.Rows.Clear();
            for (int i = 0; i < colTipos.Count; i++)
            {
                this.dataGridTipoCuenta.Rows.Add();
                this.dataGridTipoCuenta.Rows[i].Cells["idtipo"].Value = ((TipoCuenta)colTipos[i]).Idtipo;
                this.dataGridTipoCuenta.Rows[i].Cells["descripcion"].Value = ((TipoCuenta)colTipos[i]).DescripcionTipo;
            }

            this.dataGridTipoCuenta.ClearSelection();
        }

        private void frmGestionTipoCuenta_Load(object sender, EventArgs e)
        {
            tipo = new TipoCuenta();
            llenarDataGrid();
        }

        private void dataGridTipoCuenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.buttonEditar.Enabled = true;
            this.buttonEliminar.Enabled = true;
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarEditarTipoCuenta faetc = new frmAgregarEditarTipoCuenta();
            faetc.actualizarDataGridEvento += new frmAgregarEditarTipoCuenta.actualizarDataGrid(llenarDataGrid);
            faetc.MdiParent = this.MdiParent;
            faetc.Show();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            int r = this.dataGridTipoCuenta.CurrentCell.RowIndex;
            frmAgregarEditarTipoCuenta faetc = new frmAgregarEditarTipoCuenta(Convert.ToInt32(this.dataGridTipoCuenta.Rows[r].Cells["idtipo"].Value.ToString()));
            faetc.actualizarDataGridEvento += new frmAgregarEditarTipoCuenta.actualizarDataGrid(llenarDataGrid);
            faetc.MdiParent = this.MdiParent;
            faetc.Show();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Eliminar?", "Eliminacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int r = dataGridTipoCuenta.CurrentCell.RowIndex;
                tipo.Idtipo = Convert.ToInt32(dataGridTipoCuenta.Rows[r].Cells["idtipo"].Value);
                tipo.eliminar();
            }
            llenarDataGrid();
        }
    }
}
