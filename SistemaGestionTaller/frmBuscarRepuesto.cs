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
    public partial class frmBuscarRepuesto : Form
    {
        private RepuestoReparacion repuesto;
        private ArrayList colRepuestosDetalle;
        private static ArrayList colRepuestos;

        private DateTime lastLoading;
        private int firstVisibleRow;
        private bool flagDataGrid = false;

        //DELEGACION Y EVENTO PARA PASAR PARAMETROS DE UN FORM A OTRO
        public delegate void BuscarRepuestoHandler(object sender, BuscarRepuestoEventArgs e);
        public event BuscarRepuestoHandler RepuestoEncontrado;

        public frmBuscarRepuesto()
        {
            InitializeComponent();
            colRepuestosDetalle = new ArrayList();
            
        }

        //CODIGO DE PRUEBA
        private int GetDisplayedRowsCount()
        {
            int count = dataGridRepuesto.Rows[dataGridRepuesto.FirstDisplayedScrollingRowIndex].Height;
            count = dataGridRepuesto.Height / count;
            return count;
        }
        //TERMINA CODIGO DE PRUEBA


        /// <summary>
        /// Pasamos como parametro una lista de los repuestos ya utilizados en la reparacion
        /// </summary>
        /// <param name="colRepuestosDetalle_p"></param>
        public frmBuscarRepuesto(ArrayList colRepuestosDetalle_p)
        {
            InitializeComponent();
            colRepuestosDetalle = new ArrayList();
            colRepuestosDetalle = colRepuestosDetalle_p;
        }

        private void llenarListBox()
        {
            
            Repuesto objRepuestoLocal = new Repuesto();
            repuesto.Filtro = textFiltro.Text;

            if (this.comboBoxBuscar.SelectedIndex == 1 && this.textFiltro.Text != "")
            {
                //BUSCAR POR DESCRIPCION
                repuesto.MySQLLimit = 0;
                colRepuestos = repuesto.coleccionRepuestos();
                this.dataGridRepuesto.Rows.Clear();
                flagDataGrid = true;
            }
            else if (this.comboBoxBuscar.SelectedIndex == 0 && this.textFiltro.Text != "")
            {
                //BUSCAR POR CODIGO
                repuesto.MySQLLimit = 0;
                colRepuestos.AddRange(repuesto.coleccionCodigoRepuestos());
                this.dataGridRepuesto.Rows.Clear();
                flagDataGrid = true;
            }
            else
            {
                if (flagDataGrid)
                {
                    repuesto.Filtro = "";
                    this.dataGridRepuesto.Rows.Clear();
                    colRepuestos.Clear();
                    flagDataGrid = false;
                }
                //BUSCAR POR CODIGO
                colRepuestos.AddRange(repuesto.coleccionCodigoRepuestos());
            }

            for (int i = 0; i < colRepuestos.Count; i++)
            {
                if (i == 0)
                {
                    i = this.dataGridRepuesto.Rows.Count;
                }

                objRepuestoLocal = (Repuesto)colRepuestos[i];

                if (colRepuestosDetalle.IndexOf(objRepuestoLocal.IdRepuesto) < 0)
                {
                    this.dataGridRepuesto.Rows.Add();
                    this.dataGridRepuesto.Rows[i].Cells["idRepuesto"].Value = objRepuestoLocal.IdRepuesto;
                    this.dataGridRepuesto.Rows[i].Cells["idtipo"].Value = objRepuestoLocal.Idtipo;
                    this.dataGridRepuesto.Rows[i].Cells["descripciontipo"].Value = objRepuestoLocal.DescripcionTipo;
                    this.dataGridRepuesto.Rows[i].Cells["descripcionrepuesto"].Value = objRepuestoLocal.DescripcionRepuesto;
                    this.dataGridRepuesto.Rows[i].Cells["codigorepuesto"].Value = objRepuestoLocal.CodigoRepuesto;
                    this.dataGridRepuesto.Rows[i].Cells["marca"].Value = objRepuestoLocal.Marca;
                    this.dataGridRepuesto.Rows[i].Cells["modelo"].Value = objRepuestoLocal.Modelo;
                    this.dataGridRepuesto.Rows[i].Cells["costo"].Value = objRepuestoLocal.Costo;
                    this.dataGridRepuesto.Rows[i].Cells["precio"].Value = objRepuestoLocal.PrecioUnitario;
                    this.dataGridRepuesto.Rows[i].Cells["cantidad"].Value = objRepuestoLocal.CantidadStock;
                    this.dataGridRepuesto.Rows[i].Cells["minimo"].Value = objRepuestoLocal.MinimoStock;
                }
                else
                {
                    colRepuestos.RemoveAt(i);
                    i--;
                }
            }

            if (this.dataGridRepuesto.Rows.Count == 0)
            {
                this.dataGridRepuesto.Rows.Add();
                this.dataGridRepuesto.Rows[0].Cells["descripcionrepuesto"].Value = "No hay repuestos disponibles.";
                this.dataGridRepuesto.Enabled = false;
            }
            this.dataGridRepuesto.ClearSelection();
        }


        private void frmBuscarRepuesto_Load(object sender, EventArgs e)
        {
            repuesto = new RepuestoReparacion();
            repuesto.queryDataGridLimit(false);
            colRepuestos = new ArrayList();
            this.comboBoxBuscar.SelectedIndex = 1;
            llenarListBox();

        }

        private void textFiltro_TextChanged(object sender, EventArgs e)
        {
            llenarListBox();
        }

        private void dataGridRepuesto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            repuesto.IdRepuesto = Convert.ToInt32(this.dataGridRepuesto.Rows[e.RowIndex].Cells["idRepuesto"].Value);
            repuesto.Idtipo = Convert.ToInt32(this.dataGridRepuesto.Rows[e.RowIndex].Cells["idtipo"].Value);
            repuesto.DescripcionTipo = this.dataGridRepuesto.Rows[e.RowIndex].Cells["descripciontipo"].Value.ToString();
            repuesto.CodigoRepuesto = this.dataGridRepuesto.Rows[e.RowIndex].Cells["codigorepuesto"].Value.ToString();
            repuesto.Marca = this.dataGridRepuesto.Rows[e.RowIndex].Cells["marca"].Value.ToString();
            repuesto.DescripcionRepuesto= this.dataGridRepuesto.Rows[e.RowIndex].Cells["descripcionrepuesto"].Value.ToString();
            repuesto.Modelo = this.dataGridRepuesto.Rows[e.RowIndex].Cells["modelo"].Value.ToString();
            repuesto.Costo = Convert.ToDouble(this.dataGridRepuesto.Rows[e.RowIndex].Cells["costo"].Value);
            repuesto.PrecioUnitario = Convert.ToDouble(this.dataGridRepuesto.Rows[e.RowIndex].Cells["precio"].Value);
            repuesto.CantidadStock = Convert.ToDouble(this.dataGridRepuesto.Rows[e.RowIndex].Cells["cantidad"].Value);
            repuesto.MinimoStock = Convert.ToDouble(this.dataGridRepuesto.Rows[e.RowIndex].Cells["minimo"].Value);
            repuesto.Gas = 0;

            BuscarRepuestoEventArgs arg = new BuscarRepuestoEventArgs(repuesto);

            RepuestoEncontrado(this, arg);

            this.Close();
        }

        private void dataGridRepuesto_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.Type == ScrollEventType.SmallIncrement || e.Type == ScrollEventType.LargeIncrement)
            {
                if (e.NewValue >= dataGridRepuesto.Rows.Count - GetDisplayedRowsCount() && repuesto.DataGridLimit > dataGridRepuesto.Rows.Count)
                {
                    //prevent loading from autoscroll.
                    TimeSpan ts = DateTime.Now - lastLoading;
                    if (ts.TotalMilliseconds > 100)
                    {
                        firstVisibleRow = e.NewValue;
                        repuesto.MySQLLimit += 30;
                        llenarListBox();
                        dataGridRepuesto.FirstDisplayedScrollingRowIndex = e.OldValue;
                    }
                    else
                    {
                        dataGridRepuesto.FirstDisplayedScrollingRowIndex = e.OldValue;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.dataGridRepuesto.Rows[this.dataGridRepuesto.CurrentCell.RowIndex].Cells["idRepuesto"].Value != null)
            {
                frmAgregarEditarRepuestoUnico faer = new frmAgregarEditarRepuestoUnico(Convert.ToInt32(dataGridRepuesto.Rows[this.dataGridRepuesto.CurrentCell.RowIndex].Cells["idRepuesto"].Value));
                faer.actualizarDataGridEvento += new frmAgregarEditarRepuestoUnico.actualizarDataGrid(llenarListBox);
                faer.MdiParent = this.MdiParent;
                faer.Show();
                this.flagDataGrid = true;
            }
        }

        private void dataGridRepuesto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.buttonEditarRepuesto.Enabled = true;
        }

    }
}
