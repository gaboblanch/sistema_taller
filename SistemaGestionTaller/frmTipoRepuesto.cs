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
    public partial class frmTipoRepuesto : Form
    {
        private TipoRepuesto tiporepuesto;
        private int idTipoRepuesto;
        private bool flagRepuesto;

        //DELEGADO Y EVENTO PARA ACTUALIZAR GRILLA EN frmGestionCliente
        public delegate void actualizarComboBox();
        public event actualizarComboBox actualizarComboBoxEvento;

        public frmTipoRepuesto(bool flagRepuesto_p)
        {
            InitializeComponent();
            this.flagRepuesto = flagRepuesto_p;
        }

        private void llenarComboTipo()
        {
            this.buttonEliminar.Enabled = false;
            this.buttonEditar.Enabled = false;

            ArrayList colTipo = new ArrayList();
            colTipo = tiporepuesto.coleccion();

            this.comboTipo.Items.Clear();            

            for (int i = 0; i < colTipo.Count; i++ )
            {
                TipoRepuesto objTipoLocal = new TipoRepuesto();
                objTipoLocal = (TipoRepuesto)colTipo[i];

                this.comboTipo.Items.Add(objTipoLocal);
            }
        }

        private void frmGestionTipoRepuesto_Load(object sender, EventArgs e)
        {
            tiporepuesto = new TipoRepuesto();

            buttonEditar.Enabled = false;
            buttonEliminar.Enabled = false;

            llenarComboTipo();
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            if (this.comboTipo.Text != "")
            {
                tiporepuesto.DescripcionTipo = this.comboTipo.Text.ToUpper();
                if (!tiporepuesto.existeTipoRepuesto())
                {
                    tiporepuesto.Gas = 0;
                    tiporepuesto.agregar();
                }
                else
                {
                    MessageBox.Show("El tipo ya existe.", "Información");
                }
            }
            else
            {
                MessageBox.Show("Debe completar alguna descripción para el Tipo de Repuesto.", "Error");
            }
            this.inicializarFormulario();
            llenarComboTipo();
            if (flagRepuesto)
                this.actualizarComboBoxEvento();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            tiporepuesto.Idtipo = idTipoRepuesto;
            tiporepuesto.DescripcionTipo = this.comboTipo.Text.ToUpper();

            if (this.comboTipo.Text != "")
            {
                tiporepuesto.Gas = 0;
                tiporepuesto.actualizar();
                this.inicializarFormulario();
            }
            else
            {
                MessageBox.Show("Debe completar alguna descripción para el Tipo de Repuesto.", "Error");
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Va a eliminar el tipo de repuesto seleccionado, ¿Desea Continuar?.", "Advertencia", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    tiporepuesto = (TipoRepuesto)this.comboTipo.SelectedItem;
                    tiporepuesto.eliminar();
                }
                catch
                {
                    if (MessageBox.Show("Existen repuestos asociado al Tipo seleccionado, para continuar debe cambiar el Tipo de los repuestos asociados. Si no cambia no se eliminara el Tipo.\n¿Desea Continuar?", "Advertencia", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        frmCambiarTipo fct = new frmCambiarTipo(((TipoRepuesto)this.comboTipo.SelectedItem).Idtipo);
                        fct.actualizarListBoxEvento += new frmCambiarTipo.actualizarListBox(llenarComboTipo);
                        fct.MdiParent = this.MdiParent;
                        fct.Show();
                    }
                }
                finally
                {
                    this.inicializarFormulario();
                }
            }
            
        }

        private void inicializarFormulario()
        {
            comboTipo.ResetText();
            llenarComboTipo();
        }

        private void comboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.buttonEliminar.Enabled = true;
            this.buttonEditar.Enabled = true;

            idTipoRepuesto = ((TipoRepuesto)this.comboTipo.SelectedItem).Idtipo;
        }

        private void comboTipo_TextChanged(object sender, EventArgs e)
        {
            if (this.comboTipo.Text == "")
            {
                this.buttonEditar.Enabled = false;
                this.buttonEliminar.Enabled = false;
            }
        }
    }
}
