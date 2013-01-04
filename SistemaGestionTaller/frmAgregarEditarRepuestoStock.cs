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
    public partial class frmAgregarEditarRepuestoStock : Form
    {
        private Repuesto repuesto;
        private TipoRepuesto tiporepuesto;
        private DateTime fechainicio;
        private bool flagEditar;
        private bool flagTipo;
        private int idRepuesto;
        private int idProveedor;

        //DELEGACION Y EVENTO PARA PASAR PARAMETROS DE UN FORM A OTRO
        public delegate void BuscarRepuestoHandler(object sender, BuscarRepuestoEventArgs e);
        public event BuscarRepuestoHandler RepuestoEncontrado;

        public frmAgregarEditarRepuestoStock(int idProveedor_p, DateTime fechainicio_p)
        {
            InitializeComponent();
            this.idProveedor = idProveedor_p;
            fechainicio = new DateTime();
            fechainicio = fechainicio_p;
        }

        /// <summary>
        /// Cuando se quiere editar un repuesto desde AgregarEditarStock
        /// </summary>
        /// <param name="idProveedor_p"></param>
        /// <param name="fechainicio_p"></param>
        public frmAgregarEditarRepuestoStock(int idProveedor_p, int idRepuesto_p)
        {
            InitializeComponent();
            this.idProveedor = idProveedor_p;
            this.idRepuesto = idRepuesto_p;
            this.flagEditar = true;
        }

        private void llenarComboTipo()
        {
            ArrayList colTipo = new ArrayList();
            colTipo = tiporepuesto.coleccionTodos();

            this.comboTipo.Items.Clear();

            for (int i = 0; i < colTipo.Count; i++)
            {
                TipoRepuesto objTipoLocal = new TipoRepuesto();
                objTipoLocal = (TipoRepuesto)colTipo[i];

                this.comboTipo.Items.Add(objTipoLocal);
            }
        }

        private void llenarComboMarca()
        {
            MarcaModelo objMarca = new MarcaModelo();
            ArrayList colMarca = new ArrayList();
            colMarca = objMarca.coleccionMarca();

            this.textMarca.Items.Clear();

            for (int i = 0; i < colMarca.Count; i++)
            {
                this.textMarca.Items.Add(((MarcaModelo)colMarca[i]).Marca);
            }
        }

        private void llenarComboModelo()
        {
            MarcaModelo objModelo = new MarcaModelo();
            ArrayList colModelo = new ArrayList();
            colModelo = objModelo.coleccionModelo();

            this.textModelo.Items.Clear();

            for (int i = 0; i < colModelo.Count; i++)
            {
                this.textModelo.Items.Add(((MarcaModelo)colModelo[i]).Modelo);
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (this.buttonGuardar.Text == "Terminar")
            {
                RepuestoReparacion objRepuesto = new RepuestoReparacion();
                objRepuesto.IdRepuesto = repuesto.IdRepuesto;
                objRepuesto.getDatosRepuesto();
                BuscarRepuestoEventArgs arg = new BuscarRepuestoEventArgs(objRepuesto);

                RepuestoEncontrado(this, arg);

                this.Close();
                return;
            }

            //REVISAMOS QUE ESTEN COMPLETOS TODOS LOS DATOS
            if(this.textCodigo.Text == "")
            {
                MessageBox.Show("Complete el campo Código para identificar el repuesto.", "Error");
                return;
            }
            else if (this.textMarca.Text == "")
            {
                MessageBox.Show("El campo Marca esta vacío.","Error");
                return;
            }
            else if (this.textModelo.Text == "")
            {
                MessageBox.Show("El campo Modelo esta vacío.","Error");
                return;
            }
            
            if (flagTipo)
            {
                repuesto.Idtipo = ((TipoRepuesto)this.comboTipo.SelectedItem).Idtipo;
                repuesto.Proveedor.Id = this.idProveedor;
                repuesto.CodigoRepuesto = this.textCodigo.Text.ToUpper();
                repuesto.DescripcionRepuesto = this.textDescripcion.Text.ToUpper();
                repuesto.Marca = textMarca.Text.ToUpper();
                repuesto.Modelo = textModelo.Text.ToUpper();
                repuesto.FechaInicio = fechainicio;
            }
            else
            {
                MessageBox.Show("Debe indicar un tipo para este repuesto.","Error");
                return;
            }

            if (!repuesto.repuestoDuplicado())
            {
                repuesto.agregar();
                repuesto.getDatosRepuesto();

                //CAMBIAMOS BOTON GUARDAR
                this.buttonGuardar.Text = "Terminar";
                this.buttonGuardar.TextAlign = ContentAlignment.MiddleCenter;
                this.buttonGuardar.Image = null;
                return;
            }
            else if (flagEditar)
            {
                repuesto.actualizarDatos();

                //CAMBIAMOS BOTON GUARDAR
                this.buttonGuardar.Text = "Terminar";
                this.buttonGuardar.TextAlign = ContentAlignment.MiddleCenter;
                this.buttonGuardar.Image = null;
            }
            else
            {
                MessageBox.Show("El repuesto ya existe.", "Advertencia");
                return;
            }
        }

        private void frmAgregarEditarRespuesto_Load(object sender, EventArgs e)
        {
            tiporepuesto = new TipoRepuesto();
            repuesto = new Repuesto();

            llenarComboTipo();
            llenarComboMarca();
            llenarComboModelo();

            if (flagEditar)
            {
                repuesto.IdRepuesto = this.idRepuesto;
                repuesto.Proveedor.Id = this.idProveedor;
                repuesto.getDatosRepuesto();

                this.textCodigo.Text = repuesto.CodigoRepuesto;
                this.textDescripcion.Text = repuesto.DescripcionRepuesto;
                this.comboTipo.Text = repuesto.DescripcionTipo;
                this.textMarca.Text = repuesto.Marca;
                this.textModelo.Text = repuesto.Modelo;
                this.fechainicio = repuesto.FechaInicio;
            }
            
        }

        private void comboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboTipo.Text != "")
            {
                flagTipo = true;
            }
            else
            {
                flagTipo = false;
            }
        }

        private void textMarca_TextChanged(object sender, EventArgs e)
        {
            //ASPECTO ORIGINAL DEL BOTON GUARDAR
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        }

        private void textModelo_TextChanged(object sender, EventArgs e)
        {
            //ASPECTO ORIGINAL DEL BOTON GUARDAR
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        }

        private void textDescripcion_TextChanged(object sender, EventArgs e)
        {
            //ASPECTO ORIGINAL DEL BOTON GUARDAR
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        }

        private void buttonTipo_Click(object sender, EventArgs e)
        {
            frmTipoRepuesto fgtr = new frmTipoRepuesto(true);
            fgtr.actualizarComboBoxEvento += new frmTipoRepuesto.actualizarComboBox(llenarComboTipo);
            fgtr.MdiParent = this.MdiParent;
            fgtr.Show();
        }



        //SOLO PERMITE EL INGRESO DE NUMEROS Y UNA COMA
        private void comprobarNumero(object sender, KeyPressEventArgs e, String cadena)
        {
            if (cadena.Contains('.'))
            {
                      if(!char.IsDigit(e.KeyChar))
                       {
                                e.Handled = true;
                        }

                       if (e.KeyChar == '\b')
                        {
                                 e.Handled = false;
                         }
            }
           else
            {
                          if(!char.IsDigit(e.KeyChar))
                           {
                                   e.Handled = true;
                            } 

                           if(e.KeyChar=='.' || e.KeyChar=='\b')
                           {
                                    e.Handled = false;
                           }
             }
        }
    }
}
