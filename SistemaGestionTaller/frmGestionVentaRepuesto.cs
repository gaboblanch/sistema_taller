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
    public partial class frmGestionVentaRepuesto : Form
    {
        private VentaRepuesto ventarepuesto;
        private bool flagControl;

        public frmGestionVentaRepuesto()
        {
            InitializeComponent();
        }

        private void llenarDataGrid()
        {
            this.buttonEditar.Enabled = false;
            this.buttonEliminar.Enabled = false;

            ArrayList colVentaRepuesto = new ArrayList();
            ventarepuesto.Cliente.Filtro = this.textFiltro.Text;
            colVentaRepuesto = ventarepuesto.coleccion(
                                                String.Format("{0:yyyy/MM/dd}", dateTimePickerInicio.Value),
                                                String.Format("{0:yyyy/MM/dd}", dateTimePickerFin.Value));

            this.dataGridReparacion.Rows.Clear();

            for (int i = 0; i < colVentaRepuesto.Count; i++)
            {
                VentaRepuesto objReparacionLocal = new VentaRepuesto();

                objReparacionLocal = (VentaRepuesto)colVentaRepuesto[i];

                this.dataGridReparacion.Rows.Add();
                if (objReparacionLocal.EstadoVenta==0)
                    this.dataGridReparacion.Rows[i].DefaultCellStyle.BackColor = Color.YellowGreen;
                else if (objReparacionLocal.EstadoVenta == 1)
                    this.dataGridReparacion.Rows[i].DefaultCellStyle.BackColor = Color.White;
                this.dataGridReparacion.Rows[i].Cells["idventarepuesto"].Value = objReparacionLocal.IdVentaRepuesto;
                this.dataGridReparacion.Rows[i].Cells["fecha"].Value = objReparacionLocal.Fecha.ToShortDateString();
                this.dataGridReparacion.Rows[i].Cells["nombreRazonsocial"].Value = objReparacionLocal.Cliente.NombreRazonSocial;
                this.dataGridReparacion.Rows[i].Cells["descripcion"].Value = objReparacionLocal.Descripcion;
                this.dataGridReparacion.Rows[i].Cells["importe"].Value = objReparacionLocal.ImporteTotal;
                this.dataGridReparacion.Rows[i].Cells["estadoventa"].Value = objReparacionLocal.EstadoVenta;
                if (objReparacionLocal.EstadoVenta == 1)
                    this.dataGridReparacion.Rows[i].Cells["pagar"].Value = "FACTURAR";
                else if (objReparacionLocal.EstadoVenta == 1)
                    this.dataGridReparacion.Rows[i].Cells["pagar"].Value = "AGREGAR PAGOS";                
            }
            this.dataGridReparacion.ClearSelection();
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarEditarVentaRepuesto faevr = new frmAgregarEditarVentaRepuesto(true);
            faevr.actualizarDataGridEvento += new frmAgregarEditarVentaRepuesto.actualizarDataGrid(llenarDataGrid);
            faevr.MdiParent = this.MdiParent;
            faevr.Show();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            int r = this.dataGridReparacion.CurrentCell.RowIndex;
            frmAgregarEditarVentaRepuesto faevr = new frmAgregarEditarVentaRepuesto(Convert.ToInt32(dataGridReparacion.Rows[r].Cells["idventarepuesto"].Value));
            faevr.actualizarDataGridEvento += new frmAgregarEditarVentaRepuesto.actualizarDataGrid(llenarDataGrid);
            faevr.MdiParent = this.MdiParent;
            faevr.Show();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {            
            if (MessageBox.Show("¿Eliminar venta de repuestos?", "Eliminacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int r = this.dataGridReparacion.CurrentCell.RowIndex;
                ventarepuesto.IdVentaRepuesto = Convert.ToInt32(dataGridReparacion.Rows[r].Cells["idventarepuesto"].Value);
                ventarepuesto.eliminar();
                this.llenarDataGrid();
            }
        }

        private void frmGestionVentaRepuesto_Load(object sender, EventArgs e)
        {
            ventarepuesto = new VentaRepuesto();

            //INICIALIZAMOS LOS CONTROLES DATETIMEPICKER
            //Seleccionamos el 1er dia del mes
            this.dateTimePickerInicio.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            //Seleccionamos el ultimo dia del mes
            DateTime fechaFin = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1);
            this.dateTimePickerFin.Value = fechaFin.AddDays(-1);

        }

        private void dataGridReparacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                this.buttonEditar.Enabled = false;
                this.buttonEliminar.Enabled = false;

                frmFactura ff = new frmFactura(Convert.ToInt32(this.dataGridReparacion.Rows[e.RowIndex].Cells["idventarepuesto"].Value), true);
                ff.actualizarDataGridEvento += new frmFactura.actualizarDataGrid(llenarDataGrid);
                ff.MdiParent = this.MdiParent;
                ff.Show();
            }
            else
            {
                this.buttonEditar.Enabled = true;
                this.buttonEliminar.Enabled = true;
            }
        }

        private void dataGridReparacion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.buttonEditar.PerformClick();
        }

        private void dateTimePickerInicio_ValueChanged(object sender, EventArgs e)
        {
            if (flagControl)
            {
                llenarDataGrid();
            }
        }

        private void dateTimePickerFin_ValueChanged(object sender, EventArgs e)
        {
            llenarDataGrid();
            if (!flagControl)
            {
                flagControl = true;
            }
        }
    }
}
