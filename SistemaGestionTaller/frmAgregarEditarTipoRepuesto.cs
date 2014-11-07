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
    public partial class frmAgregarEditarTipoRepuesto : Form
    {
        private TipoRepuesto tipo;
        private bool flagEditar;
        private int idTipo;

        //DELEGADO Y EVENTO PARA ACTUALIZAR GRILLA EN frmGestionTarea
        public delegate void actualizarDataGrid();
        public event actualizarDataGrid actualizarDataGridEvento;

        public frmAgregarEditarTipoRepuesto()
        {
            InitializeComponent();
        }

        public frmAgregarEditarTipoRepuesto(int id_p)
        {
            InitializeComponent();
            this.flagEditar = true;
            this.idTipo = id_p;
        }

        private void frmAgregarEditarTipoRepuesto_Load(object sender, EventArgs e)
        {
            tipo = new TipoRepuesto();
            if(flagEditar)
            {
                tipo.Idtipo = this.idTipo;
                tipo.getTipo();
                this.txtDescripcion.Text = tipo.DescripcionTipo;
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (flagEditar)
            {
                tipo.DescripcionTipo = this.txtDescripcion.Text;
                tipo.actualizar();
            }
            else
            {
                tipo.DescripcionTipo = this.txtDescripcion.Text;
                tipo.agregar();
            }

            if (this.actualizarDataGridEvento != null)
                this.actualizarDataGridEvento();
            this.Close();
        }

        private void frmAgregarEditarTipoRepuesto_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                this.buttonGuardar.PerformClick();
            }
        }
    }
}
