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
    public partial class frmGestionDeudasOT : Form
    {
        private Reparacion reparacion;

        public frmGestionDeudasOT()
        {
            InitializeComponent();
        }

        private void llenarDataGrid()
        {
            ArrayList colReparacion = new ArrayList();
            reparacion.Cliente.Filtro = this.textFiltro.Text;
            reparacion.Estado = 0;

            colReparacion = reparacion.coleccionDeudas();

            this.dataGridReparacion.Rows.Clear();

            for (int i = 0; i < colReparacion.Count; i++)
            {
                Reparacion objReparacionLocal = new Reparacion();

                objReparacionLocal = (Reparacion)colReparacion[i];
                objReparacionLocal.getReparacionSaldo();

                this.dataGridReparacion.Rows.Add();

                if (objReparacionLocal.Estado == 1)
                {
                    //ES UNA ORDEN DE TRABAJO
                    this.dataGridReparacion.Rows[i].Cells["accion"].Value = "FACTURAR";
                    this.dataGridReparacion.Rows[i].Cells["estadovisual"].Value = "ORDEN DE TRABAJO";
                }
                else if (objReparacionLocal.Estado == 2)
                {
                    //ORDEN FACTURADA
                    this.dataGridReparacion.Rows[i].Cells["accion"].Value = "AGREGAR PAGOS";
                    this.dataGridReparacion.Rows[i].Cells["estadovisual"].Value = "FACTURADA";
                }
                
                this.dataGridReparacion.Rows[i].Cells["idreparacion"].Value = objReparacionLocal.IdReparacion;
                this.dataGridReparacion.Rows[i].Cells["fecha"].Value = objReparacionLocal.Fecha.ToShortDateString();
                this.dataGridReparacion.Rows[i].Cells["codigoreparacion"].Value = objReparacionLocal.CodigoReparacion;
                this.dataGridReparacion.Rows[i].Cells["nombreRazonsocial"].Value = objReparacionLocal.Cliente.NombreRazonSocial;
                this.dataGridReparacion.Rows[i].Cells["descripcion"].Value = objReparacionLocal.Descripcion;
                this.dataGridReparacion.Rows[i].Cells["importe"].Value = objReparacionLocal.ImporteTotal;
                this.dataGridReparacion.Rows[i].Cells["idvehiculo"].Value = objReparacionLocal.Vehiculo.Id;
                this.dataGridReparacion.Rows[i].Cells["vehiculo"].Value = objReparacionLocal.Vehiculo.ToString();
                this.dataGridReparacion.Rows[i].Cells["estado"].Value = objReparacionLocal.Estado;
                this.dataGridReparacion.Rows[i].Cells["saldo"].Value = objReparacionLocal.Cliente.Deuda;

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
                if (row.Cells["saldo"].Value != null)
                {
                    importeFinal += Convert.ToDouble(row.Cells["saldo"].Value);
                }
            }
            this.textBoxTotalImporte.Text = "$ " + importeFinal;
        }

        private void frmGestionDeudasOT_Load(object sender, EventArgs e)
        {
            reparacion = new Reparacion();
            this.llenarDataGrid();
        }

        private void textFiltro_TextChanged(object sender, EventArgs e)
        {
            this.llenarDataGrid();
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            this.llenarDataGrid();
        }

        private void dataGridReparacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //HACE CLIC EN LA COLUMNA DEL BOTON Y EL ESTADO DE LA ORDEN ES UNO (OT) DEBE PAGARLA
            if (e.ColumnIndex == 10 && Convert.ToInt32(this.dataGridReparacion.Rows[e.RowIndex].Cells["estado"].Value) == 1)
            {
                frmFactura ff = new frmFactura(Convert.ToInt32(this.dataGridReparacion.Rows[e.RowIndex].Cells["idreparacion"].Value), false);
                ff.actualizarDataGridEvento += new frmFactura.actualizarDataGrid(llenarDataGrid);
                ff.MdiParent = this.MdiParent;
                ff.Show();
            }
            else if (e.ColumnIndex == 10 && Convert.ToInt32(this.dataGridReparacion.Rows[e.RowIndex].Cells["estado"].Value) == 2)
            {
                //FACTURAMOS LA OT
                frmFactura ff = new frmFactura(Convert.ToInt32(this.dataGridReparacion.Rows[e.RowIndex].Cells["idreparacion"].Value), false);
                ff.actualizarDataGridEvento += new frmFactura.actualizarDataGrid(llenarDataGrid);
                ff.MdiParent = this.MdiParent;
                ff.Show();
            }
        }

        private void frmGestionDeudasOT_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
