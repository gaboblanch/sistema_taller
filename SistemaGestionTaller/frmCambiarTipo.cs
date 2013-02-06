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
    public partial class frmCambiarTipo : Form
    {
        //DELEGADO Y EVENTO PARA ACTUALIZAR LISTBOX
        public delegate void actualizarListBox();
        public event actualizarListBox actualizarListBoxEvento;

        private Repuesto repuesto;
        private TipoRepuesto tiporepuesto;
        private int idTipoActual;

        /// <summary>
        /// Constructor, pasamos el Id Tipo Actual
        /// </summary>
        /// <param name="idtipo_p"></param>
        public frmCambiarTipo(int idtipo_p)
        {
            InitializeComponent();
            idTipoActual = idtipo_p;
        }

        private void llenarComboTipo()
        {
            ArrayList colTipo = new ArrayList();
            colTipo = tiporepuesto.coleccion();

            this.comboTipo.Items.Clear();

            for (int i = 0; i < colTipo.Count; i++)
            {
                TipoRepuesto objTipoLocal = new TipoRepuesto();
                objTipoLocal = (TipoRepuesto)colTipo[i];
                if (objTipoLocal.Idtipo != idTipoActual)
                    this.comboTipo.Items.Add(objTipoLocal);
            }
        }

        private void frmCambiarTipo_Load(object sender, EventArgs e)
        {
            repuesto = new Repuesto();
            tiporepuesto = new TipoRepuesto();

            llenarComboTipo();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCambiar_Click(object sender, EventArgs e)
        {
            try
            {
                repuesto.Idtipo = idTipoActual;
                repuesto.cambiarTipoRepuesto(((TipoRepuesto)this.comboTipo.SelectedItem).Idtipo);
                tiporepuesto.Idtipo = idTipoActual;
                tiporepuesto.eliminar();
            }
            catch
            {

            }
            finally
            {
                this.actualizarListBoxEvento();
                this.Close();
            }
        }


    }
}
