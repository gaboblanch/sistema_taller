using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using CrystalDecisions.CrystalReports.Engine;

namespace SistemaGestionTaller
{
    public partial class frmGestionPresupuesto : Form
    {
        private Reparacion reparacion;
        private bool flagControl; //Bandera para controlar que no se llene el datagrid cuando inicia el form
        private bool flagPresupuesto;

        public frmGestionPresupuesto()
        {
            InitializeComponent();
        }

        private void frmGestionPresupuesto_Load(object sender, EventArgs e)
        {
            reparacion = new Reparacion();

            this.comboBoxBuscar.SelectedIndex = 0;
            //INICIALIZAMOS LOS CONTROLES DATETIMEPICKER
            //Seleccionamos el 1er dia del mes
            this.dateTimePickerInicio.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            //Seleccionamos el ultimo dia del mes
            DateTime fechaFin = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1);
            this.dateTimePickerFin.Value = fechaFin.AddDays(-1);
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarEditarReparacion faer = new frmAgregarEditarReparacion(true);
            faer.actualizarDataGridEvento += new frmAgregarEditarReparacion.actualizarDataGrid(llenarDataGrid);
            faer.MdiParent = this.MdiParent;
            faer.Show();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            int r = this.dataGridReparacion.CurrentCell.RowIndex;

            if (Convert.ToInt32(dataGridReparacion.Rows[r].Cells["estado"].Value) == 0)
            {
                flagPresupuesto = true;
                frmAgregarEditarReparacion faer = new frmAgregarEditarReparacion(Convert.ToInt32(dataGridReparacion.Rows[r].Cells["idreparacion"].Value), flagPresupuesto);
                faer.actualizarDataGridEvento += new frmAgregarEditarReparacion.actualizarDataGrid(llenarDataGrid);
                faer.MdiParent = this.MdiParent;
                faer.Show();
            }
            else if (Convert.ToInt32(dataGridReparacion.Rows[r].Cells["estado"].Value) == 1)
            {
                flagPresupuesto = false;
                frmAgregarEditarReparacion faer = new frmAgregarEditarReparacion(Convert.ToInt32(dataGridReparacion.Rows[r].Cells["idreparacion"].Value), flagPresupuesto);
                faer.actualizarDataGridEvento += new frmAgregarEditarReparacion.actualizarDataGrid(llenarDataGrid);
                faer.MdiParent = this.MdiParent;
                faer.Show();
            }
            
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Eliminar reparación?", "Eliminacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int r = this.dataGridReparacion.CurrentCell.RowIndex;
                reparacion.IdReparacion = Convert.ToInt32(dataGridReparacion.Rows[r].Cells["idreparacion"].Value);
                reparacion.eliminar();
                this.llenarDataGrid();
            }
        }

        private void llenarDataGrid()
        {
            this.buttonEditar.Enabled = false;
            this.buttonEliminar.Enabled = false;

            ArrayList colReparacion = new ArrayList();
            reparacion.Cliente.Filtro = this.textFiltro.Text;
            reparacion.Estado = 0;

            if (this.comboBoxBuscar.SelectedIndex == 0)
            {
                colReparacion = reparacion.coleccionPresupuesto(
                                                    String.Format("{0:yyyy/MM/dd}", dateTimePickerInicio.Value),
                                                    String.Format("{0:yyyy/MM/dd}", dateTimePickerFin.Value));
            }
            else if (this.comboBoxBuscar.SelectedIndex == 1)
            {
                colReparacion = reparacion.coleccionDominioPresupuesto(
                                                    String.Format("{0:yyyy/MM/dd}", dateTimePickerInicio.Value),
                                                    String.Format("{0:yyyy/MM/dd}", dateTimePickerFin.Value));
            }

            this.dataGridReparacion.Rows.Clear();

            for (int i = 0; i < colReparacion.Count; i++)
            {
                Reparacion objReparacionLocal = new Reparacion();

                objReparacionLocal = (Reparacion)colReparacion[i];

                if (objReparacionLocal.Estado == 0)
                {
                    //ES UN PRESUPUESTO
                    this.dataGridReparacion.Rows.Add();
                    this.dataGridReparacion.Rows[i].DefaultCellStyle.BackColor = Color.Silver;
                    this.dataGridReparacion.Rows[i].Cells["accion"].Value = "CAMBIAR A OT";
                    this.dataGridReparacion.Rows[i].Cells["estadovisual"].Value = "PRESUPUESTO";
                    
                    this.dataGridReparacion.Rows[i].Cells["idreparacion"].Value = objReparacionLocal.IdReparacion;
                    this.dataGridReparacion.Rows[i].Cells["fecha"].Value = objReparacionLocal.Fecha.ToShortDateString();
                    this.dataGridReparacion.Rows[i].Cells["codigoreparacion"].Value = objReparacionLocal.CodigoReparacion;
                    this.dataGridReparacion.Rows[i].Cells["nombreRazonsocial"].Value = objReparacionLocal.Cliente.NombreRazonSocial;
                    this.dataGridReparacion.Rows[i].Cells["descripcion"].Value = objReparacionLocal.Descripcion;
                    this.dataGridReparacion.Rows[i].Cells["importe"].Value = objReparacionLocal.ImporteTotal;
                    this.dataGridReparacion.Rows[i].Cells["idvehiculo"].Value = objReparacionLocal.Vehiculo.Id;
                    this.dataGridReparacion.Rows[i].Cells["vehiculo"].Value = objReparacionLocal.Vehiculo.ToString();
                    this.dataGridReparacion.Rows[i].Cells["estado"].Value = objReparacionLocal.Estado;
                }
                
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
                if (row.Cells["importe"].Value != null)
                {
                    importeFinal += Convert.ToDouble(row.Cells["importe"].Value);
                }
            }
            this.textBoxTotalImporte.Text = "$ " + importeFinal;
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

        private void textFiltro_TextChanged(object sender, EventArgs e)
        {
            llenarDataGrid();
        }

        private void dataGridReparacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.buttonEditar.Enabled = true;
            this.buttonEliminar.Enabled = true;
            this.buttonImprimir.Enabled = true;

            if (e.ColumnIndex == 9 && Convert.ToInt32(this.dataGridReparacion.Rows[e.RowIndex].Cells["estado"].Value) == 0)
            {
                frmAgregarEditarReparacion faer = new frmAgregarEditarReparacion(Convert.ToInt32(dataGridReparacion.Rows[e.RowIndex].Cells["idreparacion"].Value), false);
                faer.actualizarDataGridEvento += new frmAgregarEditarReparacion.actualizarDataGrid(llenarDataGrid);
                faer.MdiParent = this.MdiParent;
                faer.Show();
            }
        }

        private void buttonImprimir_Click(object sender, EventArgs e)
        {
            int r = this.dataGridReparacion.CurrentCell.RowIndex;
            reparacion.IdReparacion = Convert.ToInt32(dataGridReparacion.Rows[r].Cells["idreparacion"].Value);
            reparacion.getReparacion();
            reparacion.Cliente.getDatosPersonales();

            if (reparacion.Estado == 0)
            {
                this.imprimirPresupuesto();
            }
            
        }

        private void imprimirPresupuesto()
        {
            dsReparacion ds = new dsReparacion();

            ds.TablaReparacion.Rows.Add(
                reparacion.Fecha.ToShortDateString(),
                reparacion.ImporteTotal.ToString().Insert(0, "$ "),
                reparacion.Cliente.NombreRazonSocial.ToString().ToUpper(),
                reparacion.Cliente.Cuit.ToString(),
                reparacion.Cliente.Direccion.ToString().ToUpper(),
                reparacion.Vehiculo.Dominio.ToString().ToUpper(),
                reparacion.Vehiculo.Marca.ToString().ToUpper(),
                reparacion.Vehiculo.Modelo.ToString().ToUpper(),
                "Presupuesto",
                reparacion.CodigoReparacion
                );

            if (reparacion.DetalleRepuestos.Count != 0)
            {
                for (int i = 0; i < reparacion.DetalleRepuestos.Count; i++)
                {
                    ds.TablaRepuestos.Rows.Add(
                        ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).CantidadRequerida.ToString(),
                        ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).CodigoRepuesto.ToString().ToUpper(),
                        ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).DescripcionRepuesto.ToString().ToUpper(),
                        ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).PrecioUnitario.ToString("0.00"),
                        ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).PrecioTotal.ToString("0.00"),
                        ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).PrecioTotal.ToString("0.00")
                        );
                }
            }

            if (reparacion.DetalleCargas.Count != 0)
            {
                for (int i = 0; i < reparacion.DetalleCargas.Count; i++)
                {
                    ds.TablaRepuestos.Rows.Add(
                        ((RepuestoReparacion)reparacion.DetalleCargas[i]).CantidadRequerida.ToString(),
                        ((RepuestoReparacion)reparacion.DetalleCargas[i]).CodigoRepuesto.ToString().ToUpper(),
                        ((RepuestoReparacion)reparacion.DetalleCargas[i]).DescripcionRepuesto.ToString().ToUpper(),
                        ((RepuestoReparacion)reparacion.DetalleCargas[i]).PrecioUnitario.ToString("0.00"),
                        ((RepuestoReparacion)reparacion.DetalleCargas[i]).PrecioTotal.ToString("0.00"),
                        ((RepuestoReparacion)reparacion.DetalleCargas[i]).PrecioTotal.ToString("0.00")
                        );
                }
            }

            if (reparacion.DetalleTarea.Count != 0)
            {
                for (int i = 0; i < reparacion.DetalleTarea.Count; i++)
                {
                    ds.TablaRepuestos.Rows.Add(
                        1,
                        "",
                        ((TareaReparacion)reparacion.DetalleTarea[i]).DescripcionTarea.ToString().ToUpper(),
                        ((TareaReparacion)reparacion.DetalleTarea[i]).CostoTotal.ToString("0.00"),
                        ((TareaReparacion)reparacion.DetalleTarea[i]).Costo.ToString("0.00"),
                        ((TareaReparacion)reparacion.DetalleTarea[i]).Costo.ToString("0.00")
                        );
                }
            }

            ReportDocument oRep = new ReportDocument();
            try
            {
                oRep.Load("E:/DOCUMENTOS GABRIEL/Documentos/Visual Studio 2010/Projects/SistemaGestionTaller/SistemaGestionTaller/crInformePresupuesto.rpt");
            }
            catch
            {
                oRep.Load("./Informes/crInformePresupuesto.rpt");
            }

            oRep.SetDataSource(ds);

            frmImprimirReporte fr = new frmImprimirReporte(oRep);
            fr.MdiParent = this.MdiParent;
            fr.Show();
        }

        private void dataGridReparacion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.buttonEditar.PerformClick();
        }

        private void frmGestionPresupuesto_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            this.llenarDataGrid();
        }


    }
}
