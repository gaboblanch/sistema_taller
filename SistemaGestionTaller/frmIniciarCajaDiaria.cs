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
    public partial class frmIniciarCajaDiaria : Form
    {
        private GlobalIngreso caja;
        private GlobalIngreso banco;
        private GlobalIngreso cheque;
        private GlobalIngreso global;
        private GlobalIngreso tarjeta;

        //DELEGADO Y EVENTO PARA ACTUALIZAR GRILLA EN frmGestionCliente
        public delegate void actualizarDataGrid();
        public event actualizarDataGrid actualizarDataGridEvento;

        public frmIniciarCajaDiaria()
        {
            InitializeComponent();
        }
        
        private void frmIniciarCajaDiaria_Load(object sender, EventArgs e)
        {
            this.dateTimePickerFecha.Value = DateTime.Now.AddDays(-1);

            caja = new GlobalIngreso();
            banco = new GlobalIngreso();
            cheque = new GlobalIngreso();
            global = new GlobalIngreso();
            tarjeta = new GlobalIngreso();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (this.buttonGuardar.Text == "Terminar")
            {
                if (this.actualizarDataGridEvento != null)
                {
                    this.actualizarDataGridEvento();
                }
                this.Dispose();
                return;
            }

            caja.Fecha = this.dateTimePickerFecha.Value;
            banco.Fecha = this.dateTimePickerFecha.Value;
            cheque.Fecha = this.dateTimePickerFecha.Value;
            global.Fecha = this.dateTimePickerFecha.Value;
            tarjeta.Fecha = this.dateTimePickerFecha.Value;

            caja.Descripcion = "Inicialización";
            banco.Descripcion = "Inicialización";
            cheque.Descripcion = "Inicialización";
            global.Descripcion = "Inicialización";
            tarjeta.Descripcion = "Inicialización";

            caja.Importe = Convert.ToDouble(this.textBoxCaja.Text);
            banco.Importe = Convert.ToDouble(this.textBoxBanco.Text);
            cheque.Importe = Convert.ToDouble(this.textBoxCheques.Text);
            global.Importe = Convert.ToDouble(this.textBoxGlobal.Text);
            tarjeta.Importe = Convert.ToDouble(this.textBoxTarjetas.Text);

            caja.Tipo = "EFECTIVO";
            banco.Tipo = "BANCO";
            cheque.Tipo = "CHEQUE";
            global.Tipo = "GLOBAL";
            tarjeta.Tipo = "TARJETA";

            if (this.textBoxBanco.Text != "" && this.textBoxCaja.Text != "" && this.textBoxCheques.Text != "" && this.textBoxGlobal.Text != "" && this.textBoxTarjetas.Text != "")
            {
                try
                {
                    caja.agregar();
                    banco.agregar();
                    cheque.agregar();
                    global.agregar();
                    tarjeta.agregar();

                    MessageBox.Show("Caja iniciada con éxito.","Información");

                    this.buttonGuardar.Text = "Terminar";
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
    }
}
