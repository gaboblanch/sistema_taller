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
    public partial class frmLibroContable : Form
    {
        private Ingreso ingreso;
        private Egreso egreso;
        private DateTime Inicio;
        private DateTime Fin;
        private bool flagControl;
        private int numMes;

        public frmLibroContable()
        {
            InitializeComponent();
        }

        //Constructor que se ejecuta desde LibroContableAnual
        public frmLibroContable(int numMes_p)
        {
            InitializeComponent();
            flagControl = true;
            this.comboBoxMes.Enabled = false;
            numMes = numMes_p;
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

            this.textBoxEgresos.Text = importeFinal.ToString().Insert(0,"$");
        }

        private void crearFechas()
        {
            Fin = Inicio.AddMonths(1);
            Fin = Fin.AddDays(-1);

        }

        private void llenarDataGridIngresos()
        {
            ArrayList colIngresos = new ArrayList();
            ingreso.DetalleCargas.Clear();
            ingreso.DetalleRepuestos.Clear();
            ingreso.DetalleTareas.Clear();
            this.dataGridIngreso.Rows.Clear();

            /*ingreso.coleccionRepuestoGenericos(
                                                String.Format("{0:yyyy/MM/dd}", Inicio),
                                                String.Format("{0:yyyy/MM/dd}", Fin));

            ingreso.coleccionRepuestoStock(
                                            String.Format("{0:yyyy/MM/dd}", Inicio),
                                            String.Format("{0:yyyy/MM/dd}", Fin));

            ingreso.coleccionTareas(
                                    String.Format("{0:yyyy/MM/dd}", Inicio),
                                    String.Format("{0:yyyy/MM/dd}", Fin));

            ingreso.coleccionTareasGenericas(
                                            String.Format("{0:yyyy/MM/dd}", Inicio),
                                            String.Format("{0:yyyy/MM/dd}", Fin));*/

            colIngresos = ingreso.coleccion(
                                            String.Format("{0:yyyy/MM/dd}", Inicio),
                                            String.Format("{0:yyyy/MM/dd}", Fin));
            //INICIO CODIGO NUEVO
            ingreso.coleccionFacturas(
                                    String.Format("{0:yyyy/MM/dd}", Inicio),
                                    String.Format("{0:yyyy/MM/dd}", Fin));
            //FIN CODIGO NUEVO
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
                this.dataGridIngreso.Rows[i + (ingreso.DetalleRepuestos.Count+ingreso.DetalleTareas.Count)].Cells["tipo"].Value = "Varios";
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

            /*egreso.coleccionRepuestoStock(
                                            String.Format("{0:yyyy/MM/dd}", Inicio),
                                            String.Format("{0:yyyy/MM/dd}", Fin));*/
            colEgresos = egreso.coleccion(
                                            String.Format("{0:yyyy/MM/dd}", Inicio),
                                            String.Format("{0:yyyy/MM/dd}", Fin));
            //INICIO CODIGO NUEVO PARA EGRESOS
            colEgresos.AddRange(egreso.coleccionReparaciones(
                                            String.Format("{0:yyyy/MM/dd}", Inicio),
                                            String.Format("{0:yyyy/MM/dd}", Fin)));
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
                this.dataGridEgreso.Rows[i + egreso.DetalleRepuestos.Count].Cells["tipoegreso"].Value = "Varios";
                this.dataGridEgreso.Rows[i + egreso.DetalleRepuestos.Count].Cells["descripcionegreso"].Value = ((Egreso)colEgresos[i]).Descripcion;
                this.dataGridEgreso.Rows[i + egreso.DetalleRepuestos.Count].Cells["importeegreso"].Value = ((Egreso)colEgresos[i]).Importe;
                this.dataGridEgreso.Rows[i + egreso.DetalleRepuestos.Count].Cells["fechaegreso"].Value = ((Egreso)colEgresos[i]).Fecha;
            }

            this.dataGridEgreso.ClearSelection();
            this.calcularEgresos();
        }

        private void frmLibroContable_Load(object sender, EventArgs e)
        {
            ingreso = new Ingreso();
            egreso = new Egreso();
            
            if (flagControl)
                this.comboBoxMes.SelectedIndex = numMes;
            else
                this.comboBoxMes.SelectedIndex = DateTime.Now.Month - 1;
            
        }

        private void comboBoxMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Inicio = new DateTime(DateTime.Now.Year, (this.comboBoxMes.SelectedIndex + 1), 1);
            this.crearFechas();
            this.llenarDataGridIngresos();
            this.llenarDataGridEgresos();
        }
    }
}
