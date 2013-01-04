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
    public partial class frmGestionTarea : Form
    {
        private Tarea tarea;
        private bool flagOT;

        //DELEGACION Y EVENTO PARA PASAR PARAMETROS DE UN FORM A OTRO
        public delegate void BuscarTareaHandler(object sender, BuscarTareaEventArgs e);
        public event BuscarTareaHandler TareaEncontrada;

        public frmGestionTarea(bool flagOT_p)
        {
            InitializeComponent();
            this.flagOT = flagOT_p;
        }

        private void llenarDataGrid()
        {
            this.buttonEditar.Enabled = false;
            this.buttonEliminar.Enabled = false;

            ArrayList colTarea = new ArrayList();
            colTarea = tarea.coleccion();

            this.dataGridTarea.Rows.Clear();

            for (int i = 0; i < colTarea.Count; i++)
            {
                Tarea objTareaLocal = new Tarea();

                objTareaLocal = (Tarea)colTarea[i];

                this.dataGridTarea.Rows.Add();
                this.dataGridTarea.Rows[i].Cells["idtarea"].Value = objTareaLocal.IdTarea;
                this.dataGridTarea.Rows[i].Cells["descripciontarea"].Value = objTareaLocal.DescripcionTarea;
                this.dataGridTarea.Rows[i].Cells["costo"].Value = objTareaLocal.Costo;
                this.dataGridTarea.Rows[i].Cells["duracion"].Value = objTareaLocal.Duracion.ToString(@"hh\:mm");
            }

            this.dataGridTarea.ClearSelection();
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarEditarTarea faet = new frmAgregarEditarTarea();
            faet.actualizarDataGridEvento += new frmAgregarEditarTarea.actualizarDataGrid(llenarDataGrid);
            faet.MdiParent = this.MdiParent;
            faet.Show();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            int r = dataGridTarea.CurrentCell.RowIndex;
            frmAgregarEditarTarea faet = new frmAgregarEditarTarea(Convert.ToInt32(dataGridTarea.Rows[r].Cells["idtarea"].Value));
            faet.actualizarDataGridEvento += new frmAgregarEditarTarea.actualizarDataGrid(llenarDataGrid);
            faet.MdiParent = this.MdiParent;
            faet.Show();

        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Eliminar?", "Eliminacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int r = dataGridTarea.CurrentCell.RowIndex;
                tarea.IdTarea = Convert.ToInt32(dataGridTarea.Rows[r].Cells["idtarea"].Value);
                try
                {
                    tarea.eliminar();
                }
                catch (Exception ex)
                {
                    if (ex.ToString().Contains("Cannot delete or update a parent row"))
                        MessageBox.Show("Imposible eliminar porque la tarea es utilizada en Presupuestos/OT", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            llenarDataGrid();
        }

        private void frmGestionTarea_Load(object sender, EventArgs e)
        {
            tarea = new Tarea();
            llenarDataGrid();
        }

        private void dataGridTarea_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (flagOT)
            {
                this.buttonEliminar.Enabled = false;
                this.buttonEditar.Enabled = false;
            }
            else
            {
                this.buttonEliminar.Enabled = true;
                this.buttonEditar.Enabled = true;
            }
        }

        private void dataGridTarea_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (flagOT)
            {
                //PASE EL OBJETO TAREA A LA OT
                TareaReparacion objTareaLocal = new TareaReparacion();
                objTareaLocal.IdTarea = Convert.ToInt32(this.dataGridTarea.Rows[e.RowIndex].Cells["idtarea"].Value);
                objTareaLocal.DescripcionTarea = this.dataGridTarea.Rows[e.RowIndex].Cells["descripciontarea"].Value.ToString();
                objTareaLocal.Costo = Convert.ToDouble(this.dataGridTarea.Rows[e.RowIndex].Cells["costo"].Value);
                objTareaLocal.Duracion = TimeSpan.Parse(this.dataGridTarea.Rows[e.RowIndex].Cells["duracion"].Value.ToString());

                BuscarTareaEventArgs arg = new BuscarTareaEventArgs(objTareaLocal);

                TareaEncontrada(this, arg);

                this.Close();
            }
            else
                this.buttonEditar.PerformClick();
        }
    }
}
