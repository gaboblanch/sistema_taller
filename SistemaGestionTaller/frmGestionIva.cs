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
    public partial class frmGestionIva : Form
    {
        private Iva iva;
        public frmGestionIva()
        {
            InitializeComponent();
        }

        private void llenarDataGrid()
        {
            ArrayList colIva = new ArrayList();
            colIva = iva.coleccion();

            this.dataGridIva.Rows.Clear();
            for (int i = 0; i < colIva.Count; i++ )
            {
                this.dataGridIva.Rows.Add();
                this.dataGridIva.Rows[i].Cells["idiva"].Value = ((Iva)colIva[i]).Id;
                this.dataGridIva.Rows[i].Cells["nombreiva"].Value = ((Iva)colIva[i]).CondicionIva;
                this.dataGridIva.Rows[i].Cells["porcentaje"].Value = ((Iva)colIva[i]).PorcentajeIva+"%";

            }
            this.dataGridIva.ClearSelection();
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarEditarIva faeiva = new frmAgregarEditarIva();
            faeiva.actualizarDataGridEvento += new frmAgregarEditarIva.actualizarDataGrid(llenarDataGrid);
            faeiva.MdiParent = this.MdiParent;
            faeiva.Show();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Eliminar?", "Eliminacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int r = dataGridIva.CurrentCell.RowIndex;
                iva.Id = Convert.ToInt32(dataGridIva.Rows[r].Cells["idiva"].Value);
                try
                {
                    iva.eliminar();
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            llenarDataGrid();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            int r = this.dataGridIva.CurrentCell.RowIndex;
            frmAgregarEditarIva faeiva = new frmAgregarEditarIva(Convert.ToInt32(this.dataGridIva.Rows[r].Cells["idiva"].Value.ToString()));
            faeiva.actualizarDataGridEvento += new frmAgregarEditarIva.actualizarDataGrid(llenarDataGrid);
            faeiva.MdiParent = this.MdiParent;
            faeiva.Show();
        }

        private void frmGestionIva_Load(object sender, EventArgs e)
        {
            iva = new Iva();
            this.llenarDataGrid();
        }
    }
}
