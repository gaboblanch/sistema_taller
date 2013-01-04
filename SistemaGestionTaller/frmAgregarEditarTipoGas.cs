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
    public partial class frmAgregarEditarTipoGas : Form
    {
        private TipoRepuesto tipogas;
        private int idTipo;
        private bool flagEditar;

        //DELEGADO Y EVENTO PARA ACTUALIZAR LISTBOX EN frmAgregarEditarCliente
        public delegate void actualizarDataGrid();
        public event actualizarDataGrid actualizarDataGridEvento;

        public frmAgregarEditarTipoGas()
        {
            InitializeComponent();
        }

        public frmAgregarEditarTipoGas(int idTipo_p)
        {
            InitializeComponent();
            this.flagEditar = true;
            this.idTipo = idTipo_p;
        }

        

        private void frmGestionTipoGas_Load(object sender, EventArgs e)
        {
            tipogas = new TipoRepuesto();
            
            if(flagEditar)
            {
                tipogas.Idtipo = idTipo;
                tipogas.getTipo();                
                this.textBoxDescripcion.Text = tipogas.DescripcionTipo;
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if(this.textBoxDescripcion.Text == "")
            {
                MessageBox.Show("Debe completar el campo descripción.","Error");
                return;
            }
            if(flagEditar)
            {
                tipogas.Gas = 1;
                tipogas.DescripcionTipo = this.textBoxDescripcion.Text.ToUpper();
                tipogas.actualizar();
            }
            else
            {
                tipogas.Gas = 1;
                tipogas.DescripcionTipo = this.textBoxDescripcion.Text.ToUpper();
                tipogas.agregar();
            }
            this.actualizarDataGridEvento();
            MessageBox.Show("Datos ingresados correctamente.", "Información");
            this.Close();
        }
    }
}
