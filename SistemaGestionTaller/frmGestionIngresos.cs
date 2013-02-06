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
    public partial class frmGestionIngresos : Form
    {
        private Ingreso ingreso;
        private bool flagControl;

        public frmGestionIngresos()
        {
            InitializeComponent();
        }

        private void llenarDataGrid()
        {
            this.dataGridIngreso.Rows.Clear();

            ArrayList colIngresos = new ArrayList();
            ingreso.Filtro = this.textBoxFiltro.Text;

            colIngresos = ingreso.coleccion(
                                            String.Format("{0:yyyy/MM/dd}", dateTimePickerInicio.Value),
                                            String.Format("{0:yyyy/MM/dd}", dateTimePickerFin.Value));

            for (int i = 0; i < colIngresos.Count; i++ )
            {
                this.dataGridIngreso.Rows.Add();
                this.dataGridIngreso.Rows[i].Cells["idingreso"].Value = ((Ingreso)colIngresos[i]).IdIngreso;
                this.dataGridIngreso.Rows[i].Cells["descripcioningreso"].Value = ((Ingreso)colIngresos[i]).Descripcion;
                this.dataGridIngreso.Rows[i].Cells["importeingreso"].Value = ((Ingreso)colIngresos[i]).Importe;
                this.dataGridIngreso.Rows[i].Cells["fechaingreso"].Value = ((Ingreso)colIngresos[i]).Fecha;
            }

            this.dataGridIngreso.ClearSelection();
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarEditarIngreso faei = new frmAgregarEditarIngreso();
            faei.actualizarDataGridEvento += new frmAgregarEditarIngreso.actualizarDataGrid(llenarDataGrid);
            faei.MdiParent = this.MdiParent;
            faei.Show();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            int r = this.dataGridIngreso.CurrentCell.RowIndex;

            frmAgregarEditarIngreso faei = new frmAgregarEditarIngreso(Convert.ToInt32(this.dataGridIngreso.Rows[r].Cells["idingreso"].Value.ToString()));
            faei.actualizarDataGridEvento += new frmAgregarEditarIngreso.actualizarDataGrid(llenarDataGrid);
            faei.MdiParent = this.MdiParent;
            faei.Show();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            int r = this.dataGridIngreso.CurrentCell.RowIndex;

            if (MessageBox.Show("¿Desea eliminar el ingreso seleccionado?", "Eliminacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ingreso.IdIngreso = Convert.ToInt32(this.dataGridIngreso.Rows[r].Cells["idingreso"].Value.ToString());
                ingreso.eliminar();
                
                this.llenarDataGrid();
            }
        }

        private void frmGestionIngresos_Load(object sender, EventArgs e)
        {
            ingreso = new Ingreso();

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
            if(flagControl)
            {
                this.llenarDataGrid();
            }
        }

        private void dateTimePickerFin_ValueChanged(object sender, EventArgs e)
        {
            this.llenarDataGrid();
            flagControl = true;
        }

        private void textBoxFiltro_TextChanged(object sender, EventArgs e)
        {
            this.llenarDataGrid();
        }


    }
}
