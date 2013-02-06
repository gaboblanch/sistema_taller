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
    public partial class frmGestionTipoRepuesto : Form
    {
        private TipoRepuesto tipo;

        public frmGestionTipoRepuesto()
        {
            InitializeComponent();
        }

        private void llenarDataGrid()
        {
            this.buttonEditar.Enabled = false;
            this.buttonEliminar.Enabled = false;

            ArrayList colTipo = new ArrayList();
            colTipo = tipo.coleccion();

            this.dataGridTipoRepuesto.Rows.Clear();
            for (int i = 0; i < colTipo.Count; i++)
            {
                this.dataGridTipoRepuesto.Rows.Add();
                this.dataGridTipoRepuesto.Rows[i].Cells["idtipo"].Value = ((TipoRepuesto)colTipo[i]).Idtipo;
                this.dataGridTipoRepuesto.Rows[i].Cells["descripcion"].Value = ((TipoRepuesto)colTipo[i]).DescripcionTipo;
            }
            this.dataGridTipoRepuesto.ClearSelection();
        }

        private void frmGestionTipoRepuesto_Load(object sender, EventArgs e)
        {
            tipo = new TipoRepuesto();
            this.llenarDataGrid();
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarEditarTipoRepuesto faetr = new frmAgregarEditarTipoRepuesto();
            faetr.actualizarDataGridEvento += new frmAgregarEditarTipoRepuesto.actualizarDataGrid(llenarDataGrid);
            faetr.MdiParent = this.MdiParent;
            faetr.Show();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            int r = this.dataGridTipoRepuesto.CurrentCell.RowIndex;
            frmAgregarEditarTipoRepuesto faetr = new frmAgregarEditarTipoRepuesto(Convert.ToInt32(dataGridTipoRepuesto.Rows[r].Cells["idtipo"].Value));
            faetr.actualizarDataGridEvento += new frmAgregarEditarTipoRepuesto.actualizarDataGrid(llenarDataGrid);
            faetr.MdiParent = this.MdiParent;
            faetr.Show();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Eliminar?", "Eliminacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int r = this.dataGridTipoRepuesto.CurrentCell.RowIndex;
                tipo.Idtipo = Convert.ToInt32(dataGridTipoRepuesto.Rows[r].Cells["idtipo"].Value);
                tipo.eliminar();
            }
            this.llenarDataGrid();
        }

        private void dataGridTipoRepuesto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.buttonEliminar.Enabled = true;
            this.buttonEditar.Enabled = true;
        }
    }
}
