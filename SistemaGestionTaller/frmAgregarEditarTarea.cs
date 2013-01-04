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
    public partial class frmAgregarEditarTarea : Form
    {
        private Tarea tarea;
        private bool flagEditar;
        private int idTarea;

        //DELEGADO Y EVENTO PARA ACTUALIZAR GRILLA EN frmGestionTarea
        public delegate void actualizarDataGrid();
        public event actualizarDataGrid actualizarDataGridEvento;

        public frmAgregarEditarTarea(int idTarea_p)
        {
            InitializeComponent();
            idTarea = idTarea_p;
            flagEditar = true;
        }

        public frmAgregarEditarTarea()
        {
            InitializeComponent();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if(this.txtDescripcion.Text == "")
            {
                MessageBox.Show("Debe completar el campo descripción.","Error");
                return;
            }

            tarea.DescripcionTarea = this.txtDescripcion.Text.ToUpper();
            //tarea.Costo = Convert.ToDouble(this.txtCosto.Text);
            //tarea.Duracion = TimeSpan.Parse(this.txtDuracion.Text);
            tarea.Costo = 0;
            tarea.Duracion = TimeSpan.Parse("1:00");
            
            if(flagEditar)
            {
                tarea.actualizar();
            }
            else
            {
                tarea.agregar();
                
            }
            this.actualizarDataGridEvento();
            this.Close();
            this.limpiarFormulario();
        }

        /// <summary>
        /// Resetea todos los campos del form
        /// </summary>
        private void limpiarFormulario()
        {
            this.txtDuracion.ResetText(); this.txtDescripcion.ResetText(); this.txtCosto.ResetText();
        }

        private void frmAgregarEditarTarea_Load(object sender, EventArgs e)
        {
            tarea = new Tarea();

            if(flagEditar)
            {
                tarea.IdTarea = idTarea;
                tarea.getDatos();

                this.txtDescripcion.Text = tarea.DescripcionTarea.ToUpper();
                this.txtCosto.Text = tarea.Costo.ToString();
                this.txtDuracion.Text = tarea.Duracion.ToString(@"hh\:mm");
            }
        }
    }
}
