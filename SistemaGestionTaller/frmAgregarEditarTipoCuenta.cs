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
    public partial class frmAgregarEditarTipoCuenta : Form
    {
        private TipoCuenta tipocuenta;
        private bool flagEditar;
        private int idTipo;

        //DELEGADO Y EVENTO PARA ACTUALIZAR GRILLA EN frmGestionTarea
        public delegate void actualizarDataGrid();
        public event actualizarDataGrid actualizarDataGridEvento;

        public frmAgregarEditarTipoCuenta()
        {
            InitializeComponent();
        }

        public frmAgregarEditarTipoCuenta(int idTipo_p)
        {
            InitializeComponent();
            flagEditar = true;
            this.idTipo = idTipo_p;
        }

        private void frmGestionTipoCuenta_Load(object sender, EventArgs e)
        {
            tipocuenta = new TipoCuenta();
            tipocuenta.Idtipo = idTipo;

            if (flagEditar)
            {
                tipocuenta.getTipoCuenta();
                this.textBoxDescripcion.Text = tipocuenta.DescripcionTipo;
            }
        }


        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (this.textBoxDescripcion.Text == "")
            {
                MessageBox.Show("Debe completar el campo descripción.", "Error");
                return;
            }

            if (flagEditar)
            {
                tipocuenta.DescripcionTipo = this.textBoxDescripcion.Text.ToUpper();
                tipocuenta.actualizar();
            }
            else
            {
                tipocuenta.DescripcionTipo = this.textBoxDescripcion.Text.ToUpper(); ;
                tipocuenta.agregar();
            }

            this.actualizarDataGridEvento();
            MessageBox.Show("Datos ingresados correctamente.","Información");
            this.Close();
        }


    }
}
