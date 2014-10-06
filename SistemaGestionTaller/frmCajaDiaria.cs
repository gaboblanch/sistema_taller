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
    public partial class frmCajaDiaria : Form
    {
        private Ingreso ingreso;
        private Egreso egreso;
        private bool flagControl;

        public frmCajaDiaria()
        {
            InitializeComponent();
        }

        private void calcularIngresos()
        {
            double importeFinal = 0;

            //DATAGRID TAREA
            foreach (DataGridViewRow row in this.dataGridIngreso.Rows)
            {
                if (row.Cells["importe"].Value != null)
                {
                    importeFinal += (double)row.Cells["importe"].Value;
                }
            }

            this.textBoxIngresos.Text = importeFinal.ToString().Insert(0, "$");
        }

        private void calcularEgresos()
        {
            double importeFinal = 0;

            //DATAGRID TAREA
            foreach (DataGridViewRow row in this.dataGridEgreso.Rows)
            {
                if (row.Cells["importeegreso"].Value != null)
                {
                    importeFinal += (double)row.Cells["importeegreso"].Value;
                }
            }

            this.textBoxEgresos.Text = importeFinal.ToString().Insert(0, "$");
        }

        private void frmCajaDiaria_Load(object sender, EventArgs e)
        {
            ingreso = new Ingreso();
            egreso = new Egreso();

            this.llenarDataGridIngresos();
            this.llenarDataGridEgresos();
        }

        private void llenarDataGridIngresos()
        {
            ArrayList colIngresos = new ArrayList();
            ingreso.DetalleCargas.Clear();
            ingreso.DetalleRepuestos.Clear();
            ingreso.DetalleTareas.Clear();
            ingreso.DetalleFacturas.Clear();
            this.dataGridIngreso.Rows.Clear();

            /*ingreso.coleccionRepuestoGenericos(
                                                String.Format("{0:yyyy/MM/dd}", this.dateTimePickerInicio.Value),
                                                String.Format("{0:yyyy/MM/dd}", this.dateTimePickerFin.Value));

            ingreso.coleccionRepuestoStock(
                                            String.Format("{0:yyyy/MM/dd}", this.dateTimePickerInicio.Value),
                                            String.Format("{0:yyyy/MM/dd}", this.dateTimePickerFin.Value));

            ingreso.coleccionTareas(
                                    String.Format("{0:yyyy/MM/dd}", this.dateTimePickerInicio.Value),
                                    String.Format("{0:yyyy/MM/dd}", this.dateTimePickerFin.Value));

            ingreso.coleccionTareasGenericas(
                                            String.Format("{0:yyyy/MM/dd}", this.dateTimePickerInicio.Value),
                                            String.Format("{0:yyyy/MM/dd}", this.dateTimePickerFin.Value));*/
            //INICIO CODIGO NUEVO
            ingreso.coleccionFacturas(
                                    String.Format("{0:yyyy/MM/dd}", this.dateTimePickerInicio.Value),
                                    String.Format("{0:yyyy/MM/dd}", this.dateTimePickerFin.Value));
            //INICIO CODIGO NUEVO

            colIngresos = ingreso.coleccion(
                                            String.Format("{0:yyyy/MM/dd}", this.dateTimePickerInicio.Value),
                                            String.Format("{0:yyyy/MM/dd}", this.dateTimePickerFin.Value));

            /*for (int i = 0; i < ingreso.DetalleRepuestos.Count; i++)
            {
                this.dataGridIngreso.Rows.Add();
                this.dataGridIngreso.Rows[i].Cells["tipo"].Value = ((RepuestoReparacion)ingreso.DetalleRepuestos[i]).DescripcionTipo;
                this.dataGridIngreso.Rows[i].Cells["descripcion"].Value = ((RepuestoReparacion)ingreso.DetalleRepuestos[i]).DescripcionRepuesto;
                this.dataGridIngreso.Rows[i].Cells["importe"].Value = ((RepuestoReparacion)ingreso.DetalleRepuestos[i]).PrecioTotal;
                this.dataGridIngreso.Rows[i].Cells["fechaingreso"].Value = ((RepuestoReparacion)ingreso.DetalleRepuestos[i]).FechaInicio;
            }

            for (int i = 0; i < ingreso.DetalleTareas.Count; i++)
            {
                this.dataGridIngreso.Rows.Add();
                this.dataGridIngreso.Rows[i + ingreso.DetalleRepuestos.Count].Cells["tipo"].Value = "TAREA";
                this.dataGridIngreso.Rows[i + ingreso.DetalleRepuestos.Count].Cells["descripcion"].Value = ((TareaReparacion)ingreso.DetalleTareas[i]).DescripcionTarea;
                this.dataGridIngreso.Rows[i + ingreso.DetalleRepuestos.Count].Cells["importe"].Value = ((TareaReparacion)ingreso.DetalleTareas[i]).CostoTotal;
                this.dataGridIngreso.Rows[i + ingreso.DetalleRepuestos.Count].Cells["fechaingreso"].Value = ((TareaReparacion)ingreso.DetalleTareas[i]).Fecha;
            }*/
            //INICIO CODIGO NUEVO
            for (int i = 0; i < ingreso.DetalleFacturas.Count; i++)
            {
                this.dataGridIngreso.Rows.Add();
                this.dataGridIngreso.Rows[i + ingreso.DetalleRepuestos.Count].Cells["tipo"].Value = "FACTURA " + ((Factura)ingreso.DetalleFacturas[i]).TipoFactura;
                this.dataGridIngreso.Rows[i + ingreso.DetalleRepuestos.Count].Cells["descripcion"].Value = "Factura Número: " + ((Factura)ingreso.DetalleFacturas[i]).NumeroFactura + " (Saldo: " + ((Factura)ingreso.DetalleFacturas[i]).Saldo + ")";
                this.dataGridIngreso.Rows[i + ingreso.DetalleRepuestos.Count].Cells["importe"].Value = ((Factura)ingreso.DetalleFacturas[i]).ImporteFactura;
                this.dataGridIngreso.Rows[i + ingreso.DetalleRepuestos.Count].Cells["fechaingreso"].Value = ((Factura)ingreso.DetalleFacturas[i]).FechaFactura;
            }
            //FIN CODIGO NUEVO

            for (int i = 0; i < colIngresos.Count; i++)
            {
                this.dataGridIngreso.Rows.Add();
                this.dataGridIngreso.Rows[i + (ingreso.DetalleRepuestos.Count + ingreso.DetalleTareas.Count)].Cells["tipo"].Value = "Varios";
                this.dataGridIngreso.Rows[i + (ingreso.DetalleRepuestos.Count + ingreso.DetalleTareas.Count)].Cells["descripcion"].Value = ((Ingreso)colIngresos[i]).Descripcion;
                this.dataGridIngreso.Rows[i + (ingreso.DetalleRepuestos.Count + ingreso.DetalleTareas.Count)].Cells["importe"].Value = ((Ingreso)colIngresos[i]).Importe;
                this.dataGridIngreso.Rows[i + (ingreso.DetalleRepuestos.Count + ingreso.DetalleTareas.Count)].Cells["fechaingreso"].Value = ((Ingreso)colIngresos[i]).Fecha;

            }

            this.dataGridIngreso.ClearSelection();
            this.calcularIngresos();
        }

        private void llenarDataGridEgresos()
        {
            ArrayList colEgresos = new ArrayList();
            egreso.DetalleRepuestos.Clear();
            this.dataGridEgreso.Rows.Clear();

            egreso.coleccionRepuestoStock(
                                            String.Format("{0:yyyy/MM/dd}", this.dateTimePickerInicio.Value),
                                            String.Format("{0:yyyy/MM/dd}", this.dateTimePickerFin.Value)); ;

            colEgresos = egreso.coleccion(
                                            String.Format("{0:yyyy/MM/dd}", this.dateTimePickerInicio.Value),
                                            String.Format("{0:yyyy/MM/dd}", this.dateTimePickerFin.Value));

            //INICIO CODIGO NUEVO PARA EGRESOS
            colEgresos.AddRange(egreso.coleccionReparaciones(
                                            String.Format("{0:yyyy/MM/dd}", this.dateTimePickerInicio.Value),
                                            String.Format("{0:yyyy/MM/dd}", this.dateTimePickerFin.Value)));
            //FIN CODIGO NUEVO PARA EGRESOS


            /*for (int i = 0; i < egreso.DetalleRepuestos.Count; i++)
            {
                this.dataGridEgreso.Rows.Add();
                this.dataGridEgreso.Rows[i].Cells["tipoegreso"].Value = ((RepuestoReparacion)egreso.DetalleRepuestos[i]).DescripcionTipo;
                this.dataGridEgreso.Rows[i].Cells["descripcionegreso"].Value = ((RepuestoReparacion)egreso.DetalleRepuestos[i]).DescripcionRepuesto;
                this.dataGridEgreso.Rows[i].Cells["importeegreso"].Value = ((RepuestoReparacion)egreso.DetalleRepuestos[i]).CostoTotal;
                this.dataGridEgreso.Rows[i].Cells["fechaegreso"].Value = ((RepuestoReparacion)egreso.DetalleRepuestos[i]).FechaInicio;
            }*/

            for (int i = 0; i < colEgresos.Count; i++)
            {
                this.dataGridEgreso.Rows.Add();
                this.dataGridEgreso.Rows[i].Cells["tipoegreso"].Value = "Varios";
                this.dataGridEgreso.Rows[i].Cells["descripcionegreso"].Value = ((Egreso)colEgresos[i]).Descripcion;
                this.dataGridEgreso.Rows[i].Cells["importeegreso"].Value = ((Egreso)colEgresos[i]).Importe;
                this.dataGridEgreso.Rows[i].Cells["fechaegreso"].Value = ((Egreso)colEgresos[i]).Fecha;
            }

            this.dataGridEgreso.ClearSelection();
            this.calcularEgresos();
        }

        private void dateTimePickerFin_ValueChanged(object sender, EventArgs e)
        {
            this.llenarDataGridEgresos();
            this.llenarDataGridIngresos();
        }

        private void dateTimePickerInicio_ValueChanged(object sender, EventArgs e)
        {
            this.llenarDataGridEgresos();
            this.llenarDataGridIngresos();
        }
    }
}
