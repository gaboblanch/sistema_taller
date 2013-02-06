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
    public partial class frmGestionEgresos : Form
    {
        private Egreso egreso;
        private bool flagControl;

        public frmGestionEgresos()
        {
            InitializeComponent();
        }

        private void llenarDataGrid()
        {
            this.dataGridEgreso.Rows.Clear();

            ArrayList colEgresos = new ArrayList();

            egreso.Filtro = this.textBoxFiltro.Text;

            colEgresos = egreso.coleccion(
                                            String.Format("{0:yyyy/MM/dd}", dateTimePickerInicio.Value),
                                            String.Format("{0:yyyy/MM/dd}", dateTimePickerFin.Value));

            for (int i = 0; i < colEgresos.Count; i++)
            {
                this.dataGridEgreso.Rows.Add();
                this.dataGridEgreso.Rows[i].Cells["idegreso"].Value = ((Egreso)colEgresos[i]).IdEgreso;
                this.dataGridEgreso.Rows[i].Cells["descripcionegreso"].Value = ((Egreso)colEgresos[i]).Descripcion;
                this.dataGridEgreso.Rows[i].Cells["importeegreso"].Value = ((Egreso)colEgresos[i]).Importe;
                this.dataGridEgreso.Rows[i].Cells["fechaegreso"].Value = ((Egreso)colEgresos[i]).Fecha;
            }

            this.dataGridEgreso.ClearSelection();
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarEditarEgreso faee = new frmAgregarEditarEgreso();
            faee.actualizarDataGridEvento += new frmAgregarEditarEgreso.actualizarDataGrid(llenarDataGrid);
            faee.MdiParent = this.MdiParent;
            faee.Show();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            int r = this.dataGridEgreso.CurrentCell.RowIndex;

            frmAgregarEditarEgreso faee = new frmAgregarEditarEgreso(Convert.ToInt32(this.dataGridEgreso.Rows[r].Cells["idegreso"].Value.ToString()));
            faee.actualizarDataGridEvento += new frmAgregarEditarEgreso.actualizarDataGrid(llenarDataGrid);
            faee.MdiParent = this.MdiParent;
            faee.Show();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            int r = this.dataGridEgreso.CurrentCell.RowIndex;

            if (MessageBox.Show("¿Desea eliminar el egreso seleccionado?", "Eliminacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                egreso.IdEgreso = Convert.ToInt32(this.dataGridEgreso.Rows[r].Cells["idegreso"].Value.ToString());
                egreso.eliminar();

                this.llenarDataGrid();
            }
        }

        private void frmGestionEgresos_Load(object sender, EventArgs e)
        {
            egreso = new Egreso();

            //INICIALIZAMOS LOS CONTROLES DATETIMEPICKER
            //Seleccionamos el 1er dia del mes
            this.dateTimePickerInicio.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            //Seleccionamos el ultimo dia del mes
            //Este IF sirve para cuando estamos en el ultimo mes
            if (DateTime.Now.Month == 12)
            {
                DateTime fechaFin = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 31);
                this.dateTimePickerFin.Value = fechaFin;
            }
            else
            {
                DateTime fechaFin = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1);
                this.dateTimePickerFin.Value = fechaFin.AddDays(-1);
            }
        }

        private void dateTimePickerInicio_ValueChanged(object sender, EventArgs e)
        {
            if (flagControl)
            {
                this.llenarDataGrid();
            }
        }

        private void dateTimePickerFin_ValueChanged(object sender, EventArgs e)
        {
            this.llenarDataGrid();
            this.flagControl = true;
            
        }

        private void textBoxFiltro_TextChanged(object sender, EventArgs e)
        {
            this.llenarDataGrid();
        }
    }
}
