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
    public partial class frmGestionTipoGas : Form
    {
        private TipoRepuesto tipo;
        /*private bool flagEditar;
        private int idTipoGas;

        //DELEGADO Y EVENTO PARA ACTUALIZAR GRILLA EN frmGestionTarea
        public delegate void actualizarDataGrid();
        public event actualizarDataGrid actualizarDataGridEvento;*/

        public frmGestionTipoGas()
        {
            InitializeComponent();
        }

        private void llenarDataGrid()
        {
            this.buttonEditar.Enabled = false;
            this.buttonEliminar.Enabled = false;

            ArrayList colTipos = new ArrayList();
            colTipos = tipo.coleccionGas();

            this.dataGridTipoGas.Rows.Clear();
            for (int i = 0; i < colTipos.Count; i++)
            {
                this.dataGridTipoGas.Rows.Add();
                this.dataGridTipoGas.Rows[i].Cells["idtipo"].Value = ((TipoRepuesto)colTipos[i]).Idtipo;
                this.dataGridTipoGas.Rows[i].Cells["descripcion"].Value = ((TipoRepuesto)colTipos[i]).DescripcionTipo;
            }

            this.dataGridTipoGas.ClearSelection();
        }

        private void frmGestionTipoGas_Load(object sender, EventArgs e)
        {
            tipo = new TipoRepuesto();
            llenarDataGrid();
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarEditarTipoGas faetg = new frmAgregarEditarTipoGas();
            faetg.actualizarDataGridEvento +=new frmAgregarEditarTipoGas.actualizarDataGrid(llenarDataGrid);
            faetg.MdiParent = this.MdiParent;
            faetg.Show();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            int r = this.dataGridTipoGas.CurrentCell.RowIndex;
            frmAgregarEditarTipoGas faetg = new frmAgregarEditarTipoGas(Convert.ToInt32(this.dataGridTipoGas.Rows[r].Cells["idtipo"].Value.ToString()));
            faetg.actualizarDataGridEvento += new frmAgregarEditarTipoGas.actualizarDataGrid(llenarDataGrid);
            faetg.MdiParent = this.MdiParent;
            faetg.Show();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Eliminar?", "Eliminacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int r = dataGridTipoGas.CurrentCell.RowIndex;
                tipo.Idtipo = Convert.ToInt32(dataGridTipoGas.Rows[r].Cells["idtipo"].Value);
                tipo.eliminar();
            }
            llenarDataGrid();
        }

        private void dataGridTipoGas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.buttonEditar.Enabled = true;
            this.buttonEliminar.Enabled = true;
        }
    }
}
