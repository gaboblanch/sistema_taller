using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaGestionTaller
{
    public partial class frmLibroAnual : Form
    {
        private Ingreso ingreso;
        private Egreso egreso;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private double totalingreso;
        private double totalegreso;

        public frmLibroAnual()
        {
            InitializeComponent();
        }

        private void llenarDataGrid()
        {
            this.dataGridViewMes.Rows.Clear();
            for (int i = 0; i < 12; i++)
            {
                fechaInicio = new DateTime(Convert.ToInt32(this.numericAnio.Value), (i+1), 1);
                fechaFin = fechaInicio.AddMonths(1);
                fechaFin = fechaFin.AddDays(-1);

                ingreso.ingresoMensual(
                                        String.Format("{0:yyyy/MM/dd}", fechaInicio),
                                        String.Format("{0:yyyy/MM/dd}", fechaFin));

                egreso.egresoMensual(
                                     String.Format("{0:yyyy/MM/dd}", fechaInicio),
                                     String.Format("{0:yyyy/MM/dd}", fechaFin));

                this.dataGridViewMes.Rows.Add();
                this.dataGridViewMes.Rows[i].Cells["idmes"].Value = i;
                this.dataGridViewMes.Rows[i].Cells["mes"].Value = String.Format("{0:MMMMMMMMM}", fechaInicio).ToUpper();
                this.dataGridViewMes.Rows[i].Cells["ingresototal"].Value = ingreso.Importe;
                this.dataGridViewMes.Rows[i].Cells["egresototal"].Value = egreso.Importe;
                this.dataGridViewMes.Rows[i].Cells["ganancias"].Value = (ingreso.Importe - egreso.Importe);
            }
            this.dataGridViewMes.ClearSelection();

            this.calcular();
        }

        private void calcular()
        {
            totalegreso = 0;
            totalingreso = 0;

            //SUMATORIA DE INGRESOS
            foreach (DataGridViewRow row in this.dataGridViewMes.Rows)
            {
                if (row.Cells["ingresototal"].Value != null)
                {
                    totalingreso += (double)row.Cells["ingresototal"].Value;
                }
            }

            //SUMATORIAS DE EGRESOS
            foreach (DataGridViewRow row in this.dataGridViewMes.Rows)
            {
                if (row.Cells["egresototal"].Value != null)
                {
                    totalegreso += (double)row.Cells["egresototal"].Value;
                }
            }

            this.textBoxEgreso.Text = totalegreso.ToString("0.00").Insert(0,"$ ");
            this.textBoxIngreso.Text = totalingreso.ToString("0.00").Insert(0, "$ ");
            this.textGanancias.Text = (totalingreso -totalegreso).ToString("0.00").Insert(0, "$ ");
        }

        private void frmLibroAnual_Load(object sender, EventArgs e)
        {
            ingreso = new Ingreso();
            egreso = new Egreso();

            this.numericAnio.Value = DateTime.Now.Year;
            this.llenarDataGrid();
        }

        private void numericAnio_ValueChanged(object sender, EventArgs e)
        {
            this.llenarDataGrid();
        }

        private void dataGridViewMes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = this.dataGridViewMes.CurrentCell.RowIndex;
            frmLibroContable flc = new frmLibroContable(Convert.ToInt32(this.dataGridViewMes.Rows[r].Cells["idmes"].Value));
            flc.MdiParent = this.MdiParent;
            flc.Show();
            this.dataGridViewMes.ClearSelection();
        }
    }
}
