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
    public partial class frmGestionReparacion : Form
    {
        private Reparacion reparacion;
        private Factura factura;
        private bool flagControl; //Bandera para controlar que no se llene el datagrid cuando inicia el form
        private bool flagPresupuesto;
        private string inicio;
        private string fin;

        public frmGestionReparacion()
        {
            InitializeComponent();
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarEditarReparacion faer = new frmAgregarEditarReparacion();
            faer.actualizarDataGridEvento += new frmAgregarEditarReparacion.actualizarDataGrid(llenarDataGrid);
            faer.MdiParent = this.MdiParent;
            faer.Show();
        }

        private void dataGridReparacion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            this.buttonEditar.PerformClick();
        }

        private void calcular()
        {
            double importeFinal=0;
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

        private void llenarDataGrid()
        {
            this.buttonEditar.Enabled = false;
            this.buttonEliminar.Enabled = false;
            this.buttonImprimir.Enabled = false;
            this.buttonGarantia.Enabled = false;

            ArrayList colReparacion = new ArrayList();
            reparacion.Cliente.Filtro = this.textFiltro.Text;
            reparacion.Estado = 0;

            if (this.checkBoxTodas.Checked)
            {
                inicio = "2000/01/01";
                fin = String.Format("{0:yyyy/MM/dd}", DateTime.Now);
            }
            else
            {
                inicio = String.Format("{0:yyyy/MM/dd}", dateTimePickerInicio.Value);
                fin = String.Format("{0:yyyy/MM/dd}", dateTimePickerFin.Value);
            }

            if (this.comboBoxBuscar.SelectedIndex == 0)
            {
                colReparacion = reparacion.coleccion(
                                                    inicio,
                                                    fin);
            }
            else if (this.comboBoxBuscar.SelectedIndex == 1)
            {
                colReparacion = reparacion.coleccionDominio(
                                                    inicio,
                                                    fin);
            }
            else if (this.comboBoxBuscar.SelectedIndex == 2)
            {
                colReparacion = reparacion.coleccionFactura(
                                                    inicio,
                                                    fin);
            }
            else if (this.comboBoxBuscar.SelectedIndex == 3)
            {
                colReparacion = reparacion.coleccionCodigoReparacion(
                                                    inicio,
                                                    fin);
            }
            else
            {
                return;
            }

            this.dataGridReparacion.Rows.Clear();

            for (int i = 0; i < colReparacion.Count; i++)
            {
                /*Reparacion objReparacionLocal = new Reparacion();
                //objReparacionLocal = (Reparacion)colReparacion[i];
                //objReparacionLocal.getReparacionSaldo();
                //objReparacionLocal.getIva();*/

                ((Reparacion)colReparacion[i]).getReparacionSaldo();
                ((Reparacion)colReparacion[i]).getIva();

                this.dataGridReparacion.Rows.Add();
                
                if (((Reparacion)colReparacion[i]).Estado == 1)
                {
                    //ES UNA ORDEN DE TRABAJO
                    this.dataGridReparacion.Rows[i].DefaultCellStyle.BackColor = Color.YellowGreen;
                    this.dataGridReparacion.Rows[i].Cells["accion"].Value = "FACTURAR";
                    this.dataGridReparacion.Rows[i].Cells["estadovisual"].Value = "ORDEN DE TRABAJO";
                }
                else if (((Reparacion)colReparacion[i]).Estado == 2)
                {
                    //ORDEN FACTURADA
                    this.dataGridReparacion.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    this.dataGridReparacion.Rows[i].Cells["accion"].Value = "AGREGAR PAGOS";
                    this.dataGridReparacion.Rows[i].Cells["estadovisual"].Value = "FACTURADA";
                }
                else if (((Reparacion)colReparacion[i]).Estado == 3)
                {
                    //ORDEN FACTURADA Y SALDADA
                    this.dataGridReparacion.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    this.dataGridReparacion.Rows[i].Cells["accion"].Value = "VER FACTURA";
                    this.dataGridReparacion.Rows[i].Cells["estadovisual"].Value = "SALDADA";
                }
                else if (((Reparacion)colReparacion[i]).Estado == 4)
                {
                    //ORDEN FACTURADA Y CON GARANTIA
                    this.dataGridReparacion.Rows[i].DefaultCellStyle.BackColor = Color.Salmon;
                    this.dataGridReparacion.Rows[i].Cells["accion"].Value = "AGREGAR PAGOS";
                    this.dataGridReparacion.Rows[i].Cells["estadovisual"].Value = "CON GARANTIA";
                }
                else if (((Reparacion)colReparacion[i]).Estado == 5)
                {
                    //ORDEN FACTURADA, CON GARANTIA Y SALDADA
                    this.dataGridReparacion.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    this.dataGridReparacion.Rows[i].Cells["accion"].Value = "VER FACTURA";
                    this.dataGridReparacion.Rows[i].Cells["estadovisual"].Value = "CON GARANTIA Y SALDADA";
                }
                else if (((Reparacion)colReparacion[i]).Estado == 6)
                {
                    //ORDEN FACTURADA, CON GARANTIA Y SALDADA
                    this.dataGridReparacion.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                    this.dataGridReparacion.Rows[i].DefaultCellStyle.ForeColor = Color.Gray;
                    this.dataGridReparacion.Rows[i].Cells["accion"].Value = "VER ORDEN";
                    this.dataGridReparacion.Rows[i].Cells["estadovisual"].Value = "ELIMINADA";
                }

                this.dataGridReparacion.Rows[i].Cells["idreparacion"].Value = ((Reparacion)colReparacion[i]).IdReparacion;
                this.dataGridReparacion.Rows[i].Cells["fecha"].Value = ((Reparacion)colReparacion[i]).Fecha.ToShortDateString();
                this.dataGridReparacion.Rows[i].Cells["codigoreparacion"].Value = ((Reparacion)colReparacion[i]).CodigoReparacion;
                this.dataGridReparacion.Rows[i].Cells["nombreRazonsocial"].Value = ((Reparacion)colReparacion[i]).Cliente.NombreRazonSocial;
                this.dataGridReparacion.Rows[i].Cells["descripcion"].Value = ((Reparacion)colReparacion[i]).Descripcion;
                this.dataGridReparacion.Rows[i].Cells["importe"].Value = ((Reparacion)colReparacion[i]).ImporteTotal;
                this.dataGridReparacion.Rows[i].Cells["idvehiculo"].Value = ((Reparacion)colReparacion[i]).Vehiculo.Id;
                this.dataGridReparacion.Rows[i].Cells["vehiculo"].Value = ((Reparacion)colReparacion[i]).Vehiculo.ToString();
                this.dataGridReparacion.Rows[i].Cells["estado"].Value = ((Reparacion)colReparacion[i]).Estado;
                this.dataGridReparacion.Rows[i].Cells["saldo"].Value = ((Reparacion)colReparacion[i]).Cliente.Deuda;
                
            }
            this.dataGridReparacion.ClearSelection();
            this.textBoxTotalOt.Text = this.dataGridReparacion.Rows.Count.ToString();
            this.calcular();
        }

        private void frmGestionReparacion_Load(object sender, EventArgs e)
        {
            reparacion = new Reparacion();
            factura = new Factura();

            this.comboBoxBuscar.SelectedIndex = 0;
            //INICIALIZAMOS LOS CONTROLES DATETIMEPICKER
            //Seleccionamos el 1er dia del mes
            this.dateTimePickerInicio.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            
            //Seleccionamos el ultimo dia del mes
            DateTime fechaaaaa = new DateTime(DateTime.Now.Year, DateTime.Now.Month+1 ,1);

            this.dateTimePickerFin.Value = fechaaaaa.AddDays(-1);
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            int r = this.dataGridReparacion.CurrentCell.RowIndex;

            if (Convert.ToInt32(dataGridReparacion.Rows[r].Cells["estado"].Value) == 1)
            {
                flagPresupuesto = false;
                frmAgregarEditarReparacion faer = new frmAgregarEditarReparacion(Convert.ToInt32(dataGridReparacion.Rows[r].Cells["idreparacion"].Value), flagPresupuesto);
                faer.actualizarDataGridEvento += new frmAgregarEditarReparacion.actualizarDataGrid(llenarDataGrid);
                faer.MdiParent = this.MdiParent;
                faer.Show();
            }
            else if (Convert.ToInt32(dataGridReparacion.Rows[r].Cells["estado"].Value) == 2)
            {
                //SE EDITA LA FACTURA
                this.buttonEditar.Enabled = false;
                this.buttonEliminar.Enabled = false;

                frmFactura ff = new frmFactura(Convert.ToInt32(this.dataGridReparacion.Rows[r].Cells["idreparacion"].Value), false);
                ff.MdiParent = this.MdiParent;
                ff.Show();
            }
            else if (Convert.ToInt32(dataGridReparacion.Rows[r].Cells["estado"].Value) == 6)
            {
                flagPresupuesto = false;
                frmAgregarEditarReparacion faer = new frmAgregarEditarReparacion(Convert.ToInt32(dataGridReparacion.Rows[r].Cells["idreparacion"].Value));
                faer.actualizarDataGridEvento += new frmAgregarEditarReparacion.actualizarDataGrid(llenarDataGrid);
                faer.MdiParent = this.MdiParent;
                faer.Show();
            }
            
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            int r = this.dataGridReparacion.CurrentCell.RowIndex;
            if (Convert.ToInt32(dataGridReparacion.Rows[r].Cells["estado"].Value) == 1)
            {
                //es una OT sin facturar
                if (MessageBox.Show("¿Eliminar reparación?", "Eliminacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        reparacion.IdReparacion = Convert.ToInt32(dataGridReparacion.Rows[r].Cells["idreparacion"].Value);
                        reparacion.eliminarBeta();
                        this.llenarDataGrid();
                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    {
                        MessageBox.Show("Error MySQL: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (Convert.ToInt32(dataGridReparacion.Rows[r].Cells["estado"].Value) == 2)
            {
                //es una OT facturada sin saldar
                if (MessageBox.Show("La Orden de Trabajo ha sido facturada se eliminaran los pagos y la OT", "Eliminacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        reparacion.IdReparacion = Convert.ToInt32(dataGridReparacion.Rows[r].Cells["idreparacion"].Value);
                        factura.Reparacion.IdReparacion = reparacion.IdReparacion;
                        factura.existeFacturaReparacion();
                        factura.eliminarReparacion();

                        reparacion.eliminarBeta();
                        this.llenarDataGrid();
                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    {
                        MessageBox.Show("Error MySQL: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dataGridReparacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.buttonImprimir.Enabled = true;
            this.buttonGarantia.Enabled = true;

            try
            {
                //HACE CLIC EN CUALQUIER CELDA QUE NO ES EL BOTON
                if (e.ColumnIndex != 10 && Convert.ToInt32(this.dataGridReparacion.Rows[e.RowIndex].Cells["estado"].Value) <= 2)
                {
                    //es una OT habilito los botones editar y eliminar
                    this.buttonEditar.Enabled = true;
                    this.buttonEliminar.Enabled = true;
                    return;
                }
                else if (e.ColumnIndex != 10 && Convert.ToInt32(this.dataGridReparacion.Rows[e.RowIndex].Cells["estado"].Value) > 2)
                {
                    //es una OT que fue facturada entonces no se puede editar
                    this.buttonEditar.Enabled = false;
                    this.buttonEliminar.Enabled = false;
                    return;
                }

                //HACE CLIC EN LA COLUMNA DEL BOTON Y EL ESTADO DE LA ORDEN ES UNO (OT) DEBE PAGARLA
                else if (e.ColumnIndex == 10 && Convert.ToInt32(this.dataGridReparacion.Rows[e.RowIndex].Cells["estado"].Value) == 1)
                {
                    this.buttonEditar.Enabled = false;
                    this.buttonEliminar.Enabled = false;

                    frmFactura ff = new frmFactura(Convert.ToInt32(this.dataGridReparacion.Rows[e.RowIndex].Cells["idreparacion"].Value), false);
                    ff.actualizarDataGridEvento += new frmFactura.actualizarDataGrid(llenarDataGrid);
                    ff.MdiParent = this.MdiParent;
                    ff.Show();
                }
                else if (e.ColumnIndex == 10 && Convert.ToInt32(this.dataGridReparacion.Rows[e.RowIndex].Cells["estado"].Value) == 0)
                {
                    //HACE CLIC EN LA COLUMNA DEL BOTON Y CAMBIAMOS PRESUPUESTO A OT
                    frmAgregarEditarReparacion faer = new frmAgregarEditarReparacion(Convert.ToInt32(dataGridReparacion.Rows[e.RowIndex].Cells["idreparacion"].Value), false);
                    faer.actualizarDataGridEvento += new frmAgregarEditarReparacion.actualizarDataGrid(llenarDataGrid);
                    faer.MdiParent = this.MdiParent;
                    faer.Show();
                }
                else if (e.ColumnIndex == 10 && Convert.ToInt32(this.dataGridReparacion.Rows[e.RowIndex].Cells["estado"].Value) == 2)
                {
                    //FACTURAMOS LA OT
                    this.buttonEditar.Enabled = false;
                    this.buttonEliminar.Enabled = false;

                    frmFactura ff = new frmFactura(Convert.ToInt32(this.dataGridReparacion.Rows[e.RowIndex].Cells["idreparacion"].Value), false);
                    ff.actualizarDataGridEvento += new frmFactura.actualizarDataGrid(llenarDataGrid);
                    ff.MdiParent = this.MdiParent;
                    ff.Show();
                }
                else if (e.ColumnIndex == 10 && Convert.ToInt32(this.dataGridReparacion.Rows[e.RowIndex].Cells["estado"].Value) == 3)
                {
                    //MOSTRAMOS LA FACTURA PORQUE YA FUE SALDADA
                    this.buttonEditar.Enabled = false;
                    this.buttonEliminar.Enabled = false;

                    frmFactura ff = new frmFactura(Convert.ToInt32(this.dataGridReparacion.Rows[e.RowIndex].Cells["idreparacion"].Value), false);
                    ff.actualizarDataGridEvento += new frmFactura.actualizarDataGrid(llenarDataGrid);
                    ff.MdiParent = this.MdiParent;
                    ff.Show();
                }
                else if (e.ColumnIndex == 10 && Convert.ToInt32(this.dataGridReparacion.Rows[e.RowIndex].Cells["estado"].Value) == 4)
                {
                    //AGREGAMOS PAGOS PERO TIENE GARANTIA
                    this.buttonEditar.Enabled = false;
                    this.buttonEliminar.Enabled = false;

                    frmFactura ff = new frmFactura(Convert.ToInt32(this.dataGridReparacion.Rows[e.RowIndex].Cells["idreparacion"].Value), false);
                    ff.actualizarDataGridEvento += new frmFactura.actualizarDataGrid(llenarDataGrid);
                    ff.MdiParent = this.MdiParent;
                    ff.Show();
                }
                else if (e.ColumnIndex == 10 && Convert.ToInt32(this.dataGridReparacion.Rows[e.RowIndex].Cells["estado"].Value) == 5)
                {
                    //TIENE GARANTIA Y ESTA SALDADA MOSTRAMOS LA FACTURA
                    this.buttonEditar.Enabled = false;
                    this.buttonEliminar.Enabled = false;

                    frmFactura ff = new frmFactura(Convert.ToInt32(this.dataGridReparacion.Rows[e.RowIndex].Cells["idreparacion"].Value), false);
                    ff.actualizarDataGridEvento += new frmFactura.actualizarDataGrid(llenarDataGrid);
                    ff.MdiParent = this.MdiParent;
                    ff.Show();
                }
                else if (e.ColumnIndex == 10 && Convert.ToInt32(this.dataGridReparacion.Rows[e.RowIndex].Cells["estado"].Value) == 6)
                {
                    this.buttonEditar.Enabled = true;
                    this.buttonEditar.PerformClick();
                    this.buttonEditar.Enabled = false;
                }
                else if (Convert.ToInt32(this.dataGridReparacion.Rows[e.RowIndex].Cells["estado"].Value) == 6)
                {
                    this.buttonEliminar.Enabled = false;
                    this.buttonEditar.Enabled = false;
                    return;
                }
            }
            catch
            {
                if (e.ColumnIndex != 10)
                {
                    this.buttonEditar.Enabled = false;
                    this.buttonEliminar.Enabled = false;
                    return;
                }
            }
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
            if(!flagControl)
            {
                flagControl = true;
            }
        }

        private void textFiltro_TextChanged(object sender, EventArgs e)
        {
            this.llenarDataGrid();
        }

        private void buttonImprimir_Click(object sender, EventArgs e)
        {
            int r = this.dataGridReparacion.CurrentCell.RowIndex;
            reparacion.IdReparacion = Convert.ToInt32(dataGridReparacion.Rows[r].Cells["idreparacion"].Value);
            reparacion.getReparacion();
            reparacion.Cliente.getDatosPersonales();

            if (reparacion.Estado == 1)
            {
                this.imprimirReparacion();
            }
            /*else if (reparacion.Estado == 2)
            {
                this.imprimirFactura();
            }*/
        }

        private void imprimirReparacion()
        {
            dsReparacion ds = new dsReparacion();

            ds.TablaReparacion.Rows.Add(
                reparacion.Fecha.ToShortDateString(),
                reparacion.ImporteTotal.ToString("0.00").Insert(0,"$ "),
                reparacion.Cliente.NombreRazonSocial.ToString().ToUpper(),
                reparacion.Cliente.Cuit.ToString(),
                reparacion.Cliente.Direccion.ToString().ToUpper(),
                reparacion.Vehiculo.Dominio.ToString().ToUpper(),
                reparacion.Vehiculo.Marca.ToString().ToUpper(),
                reparacion.Vehiculo.Modelo.ToString().ToUpper(),
                "Orden de Trabajo",
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
                oRep.Load("E:\\DOCUMENTOS DE GABRIEL\\Documentos\\Visual Studio 2010\\Projects\\SistemaGestionTaller\\SistemaGestionTaller\\crInformeReparacion.rpt");
            }
            catch
            {
                oRep.Load("./Informes/crInformeReparacion.rpt");
            }

            oRep.SetDataSource(ds);

            frmImprimirReporte fr = new frmImprimirReporte(oRep);
            fr.MdiParent = this.MdiParent;
            fr.Show();
        }

        

        private void checkBoxFiltroOT_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxFiltroOT.Checked)
            {
                for (int i = 0; i < this.dataGridReparacion.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dataGridReparacion.Rows[i].Cells["estado"].Value) == 1)
                    {
                        dataGridReparacion.Rows.Remove(dataGridReparacion.Rows[i]);
                        i = 0;
                    }
                }
            }
            else
            {
                llenarDataGrid();
            }
        }

        private void frmGestionReparacion_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void buttonGarantia_Click(object sender, EventArgs e)
        {
            int r = this.dataGridReparacion.CurrentCell.RowIndex;

            if (Convert.ToInt32(this.dataGridReparacion.Rows[r].Cells["estado"].Value) == 2 || Convert.ToInt32(this.dataGridReparacion.Rows[r].Cells["estado"].Value) == 3)
            {
                frmAgregarEditarGarantia faeg = new frmAgregarEditarGarantia(false, Convert.ToInt32(this.dataGridReparacion.Rows[r].Cells["idreparacion"].Value));
                faeg.MdiParent = this.MdiParent;
                faeg.Show();
            }
            else if (Convert.ToInt32(this.dataGridReparacion.Rows[r].Cells["estado"].Value) == 4 || Convert.ToInt32(this.dataGridReparacion.Rows[r].Cells["estado"].Value) == 5)
            {
                MessageBox.Show("Esta reparación ya tiene garantía.", "Información");
                return;
            }
            else
            {
                MessageBox.Show("Para aplicar una garantía la OT debe estar facturada.","Información");
                return;
            }
        }

        private void comboBoxBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textFiltro.ResetText();

            if (flagControl)
                llenarDataGrid();
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            this.llenarDataGrid();
        }

    }
}
