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
    public partial class frmGestionGarantia : Form
    {
        private Garantia garantia;
        private bool flagControl;

        public frmGestionGarantia()
        {
            InitializeComponent();
        }

        private void llenarDataGrid()
        {
            this.buttonEditar.Enabled = false;
            this.buttonEliminar.Enabled = false;
            this.buttonImprimir.Enabled = false;

            ArrayList colGarantias = new ArrayList();
            garantia.Reparacion.Cliente.Filtro = this.textFiltro.Text;

            if (this.comboBoxBuscar.SelectedIndex == 0)
            {
                //Apellido
                colGarantias = garantia.coleccionRazonsocial(
                                                    String.Format("{0:yyyy/MM/dd}", dateTimePickerInicio.Value),
                                                    String.Format("{0:yyyy/MM/dd}", dateTimePickerFin.Value));
            }
            else if (this.comboBoxBuscar.SelectedIndex == 0)
            {
                //Dominio
                colGarantias = garantia.coleccionDominio(
                                                    String.Format("{0:yyyy/MM/dd}", dateTimePickerInicio.Value),
                                                    String.Format("{0:yyyy/MM/dd}", dateTimePickerFin.Value));
            }
            else
            {
                return;
            }

            this.dataGridReparacion.Rows.Clear();

            for (int i = 0; i < colGarantias.Count; i++)
            {
                this.dataGridReparacion.Rows.Add();
                this.dataGridReparacion.Rows[i].Cells["idgarantia"].Value = ((Garantia)colGarantias[i]).Id;
                this.dataGridReparacion.Rows[i].Cells["fecha"].Value = ((Garantia)colGarantias[i]).FechaGarantia.ToShortDateString();
                this.dataGridReparacion.Rows[i].Cells["codigoreparacion"].Value = ((Garantia)colGarantias[i]).Reparacion.CodigoReparacion;
                this.dataGridReparacion.Rows[i].Cells["nombreRazonsocial"].Value = ((Garantia)colGarantias[i]).Reparacion.Cliente.NombreRazonSocial;
                this.dataGridReparacion.Rows[i].Cells["descripcion"].Value = ((Garantia)colGarantias[i]).Descripcion;
                this.dataGridReparacion.Rows[i].Cells["costogarantia"].Value = ((Garantia)colGarantias[i]).Importe;
                this.dataGridReparacion.Rows[i].Cells["idvehiculo"].Value = ((Garantia)colGarantias[i]).Reparacion.Vehiculo.Id;
                this.dataGridReparacion.Rows[i].Cells["vehiculo"].Value = ((Garantia)colGarantias[i]).Reparacion.Vehiculo.ToString();
                this.dataGridReparacion.Rows[i].Cells["estadoreparacion"].Value = ((Garantia)colGarantias[i]).Reparacion.EstadoAnterior;
            }
            this.dataGridReparacion.ClearSelection();
            this.textBoxTotalOt.Text = this.dataGridReparacion.Rows.Count.ToString();
            this.calcular();
        }

        private void calcular()
        {
            double importeFinal = 0;
            //DATAGRID
            foreach (DataGridViewRow row in this.dataGridReparacion.Rows)
            {
                if (row.Cells["costogarantia"].Value != null)
                {
                    importeFinal += Convert.ToDouble(row.Cells["costogarantia"].Value);
                }
            }
            this.textBoxTotalImporte.Text = "$ " + importeFinal;
        }

        private void frmGestionGarantia_Load(object sender, EventArgs e)
        {
            garantia = new Garantia();

            this.comboBoxBuscar.SelectedIndex = 0;
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

        private void dataGridReparacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.buttonEditar.Enabled = true;
            this.buttonEliminar.Enabled = true;
            this.buttonImprimir.Enabled = true;
        }

        private void dateTimePickerInicio_ValueChanged(object sender, EventArgs e)
        {
            if (flagControl)
                this.llenarDataGrid();
        }

        private void dateTimePickerFin_ValueChanged(object sender, EventArgs e)
        {
            this.flagControl = true;

            this.llenarDataGrid();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            int r = this.dataGridReparacion.CurrentCell.RowIndex;

            frmAgregarEditarGarantia faeg = new frmAgregarEditarGarantia(true, Convert.ToInt32(this.dataGridReparacion.Rows[r].Cells["idgarantia"].Value.ToString()));
            faeg.actualizarDataGridEvento += new frmAgregarEditarGarantia.actualizarDataGrid(llenarDataGrid);
            faeg.MdiParent = this.MdiParent;
            faeg.Show();

        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Eliminar garantía?", "Eliminacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    int r = this.dataGridReparacion.CurrentCell.RowIndex;
                    garantia.Reparacion.Estado = Convert.ToInt32(dataGridReparacion.Rows[r].Cells["estadoreparacion"].Value);
                    garantia.Reparacion.actualizarEstado();
                    garantia.Id = Convert.ToInt32(dataGridReparacion.Rows[r].Cells["idgarantia"].Value);
                    garantia.eliminar();
                    this.llenarDataGrid();
                }
                catch(MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show("Error: "+ ex,"Error");
                    return;
                }
            }
        }

        private void dataGridReparacion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.buttonEditar.PerformClick();
        }
    }
}
