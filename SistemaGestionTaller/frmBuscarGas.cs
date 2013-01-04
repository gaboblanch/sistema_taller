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
    public partial class frmBuscarGas : Form
    {
        private RepuestoReparacion repuesto;
        private ArrayList colRepuestosDetalle;

        //DELEGACION Y EVENTO PARA PASAR PARAMETROS DE UN FORM A OTRO
        public delegate void BuscarRepuestoHandler(object sender, BuscarRepuestoEventArgs e);
        public event BuscarRepuestoHandler RepuestoEncontrado;

        public frmBuscarGas(ArrayList colRepuestosDetalle_p)
        {
            InitializeComponent();
            colRepuestosDetalle = new ArrayList();
            colRepuestosDetalle = colRepuestosDetalle_p;
        }

        private void llenarListBox()
        {
            ArrayList colRepuestos = new ArrayList();
            Repuesto objRepuestoLocal = new Repuesto();
            repuesto.Filtro = textFiltro.Text;

            if (this.comboBoxBuscar.SelectedIndex == 1)
            {
                //BUSCAR POR DESCRIPCION
                colRepuestos = repuesto.coleccionRespuestoGas();
            }
            else
            {
                //BUSCAR POR CODIGO
                colRepuestos = repuesto.coleccionCodigoGas();
            }


            this.dataGridRepuesto.Rows.Clear();

            for (int i = 0; i < colRepuestos.Count; i++)
            {
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

        private void frmBuscarGas_Load(object sender, EventArgs e)
        {
            repuesto = new RepuestoReparacion();
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
            repuesto.DescripcionRepuesto = this.dataGridRepuesto.Rows[e.RowIndex].Cells["descripcionrepuesto"].Value.ToString();
            repuesto.Modelo = this.dataGridRepuesto.Rows[e.RowIndex].Cells["modelo"].Value.ToString();
            repuesto.Costo = Convert.ToDouble(this.dataGridRepuesto.Rows[e.RowIndex].Cells["costo"].Value);
            repuesto.PrecioUnitario = Convert.ToDouble(this.dataGridRepuesto.Rows[e.RowIndex].Cells["precio"].Value);
            repuesto.CantidadStock = Convert.ToDouble(this.dataGridRepuesto.Rows[e.RowIndex].Cells["cantidad"].Value);
            repuesto.MinimoStock = Convert.ToDouble(this.dataGridRepuesto.Rows[e.RowIndex].Cells["minimo"].Value);
            repuesto.Gas = 1;

            BuscarRepuestoEventArgs arg = new BuscarRepuestoEventArgs(repuesto);

            RepuestoEncontrado(this, arg);

            this.Close();
        }

    }
}
