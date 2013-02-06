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
    public partial class frmAgregarEditarProveedor : Form
    {
        private Proveedor proveedor;
        private TipoCuenta tipocuenta;
        private bool flagEditar;
        private int idProveedor;

        //DELEGADO Y EVENTO PARA ACTUALIZAR GRILLA EN frmGestionCliente
        public delegate void actualizarDataGrid();
        public event actualizarDataGrid actualizarDataGridEvento;

        public frmAgregarEditarProveedor()
        {
            InitializeComponent();
        }

        public frmAgregarEditarProveedor(int idProveedor_p)
        {
            InitializeComponent();
            idProveedor = idProveedor_p;
            flagEditar = true;
        }

        private void llenarComboCuenta()
        {
            ArrayList colTipo = new ArrayList();
            colTipo = tipocuenta.coleccion();

            this.comboTipo.Items.Clear();

            for (int i = 0; i < colTipo.Count; i++)
            {
                TipoCuenta objTipoLocal = new TipoCuenta();
                objTipoLocal = (TipoCuenta)colTipo[i];

                this.comboTipo.Items.Add(objTipoLocal);
            }
        }

        private void llenarComboProvincia()
        {
            Provincia provincia = new Provincia();
            ArrayList colProvincia = new ArrayList();
            colProvincia = provincia.coleccion();

            this.comboBoxProvincia.Items.Clear();
            this.comboBoxLocalidad.ResetText();
            for (int i = 0; i < colProvincia.Count; i++)
            {
                this.comboBoxProvincia.Items.Add(((Provincia)colProvincia[i]));
            }
        }

        private void llenarComboLocalidad()
        {
            Localidad localidad = new Localidad();
            ArrayList colLocalidad = new ArrayList();
            colLocalidad = localidad.coleccion(((Provincia)this.comboBoxProvincia.SelectedItem).IdProvincia);

            this.comboBoxLocalidad.ResetText();
            this.comboBoxLocalidad.Items.Clear();
            for (int i = 0; i < colLocalidad.Count; i++)
            {
                this.comboBoxLocalidad.Items.Add(((Localidad)colLocalidad[i]));
            }
        }

        private void frmAgregarEditarProveedor_Load(object sender, EventArgs e)
        {
            proveedor = new Proveedor();
            tipocuenta = new TipoCuenta();

            this.llenarComboCuenta();
            this.llenarComboProvincia();
            
            if(flagEditar)
            {
                //OBTENEMOS DATOS DE LA BD
                proveedor.Id = idProveedor;
                proveedor.getDatosProveedor();

                //LLENAMOS FORMULARIO
                textCuit.Text = proveedor.Cuit;
                textApellido.Text = proveedor.NombreRazonSocial.ToUpper();
                textTelefono.Text = proveedor.Telefono;
                textEmail.Text = proveedor.Email;
                textCp.Text = proveedor.Cp;
                textDireccion.Text = proveedor.Direccion.ToUpper();
                comboBoxProvincia.Text = proveedor.Provincia.ToUpper();
                comboBoxLocalidad.Text = proveedor.Localidad.ToUpper();
                textObservaciones.Text = proveedor.Observaciones.ToUpper();
                textPagina.Text = proveedor.PaginaWeb;
                textBanco.Text = proveedor.BancoNombre.ToUpper();
                textTitular.Text = proveedor.TitularCuenta.ToUpper();
                textNumero.Text = proveedor.CuentaNumero.ToUpper();
                comboTipo.Text = proveedor.CuentaTipo.ToUpper();
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if(this.buttonGuardar.Text == "Terminar")
            {
                this.actualizarDataGridEvento();
                this.Close();
                return;
            }
            proveedor.Cuit = textCuit.Text;
            proveedor.NombreRazonSocial = textApellido.Text.ToUpper();
            proveedor.Telefono = textTelefono.Text;
            proveedor.Email = textEmail.Text;
            proveedor.Cp = textCp.Text;
            proveedor.Direccion = textDireccion.Text.ToUpper();
            proveedor.Localidad = comboBoxLocalidad.Text.ToUpper();
            proveedor.Provincia = comboBoxProvincia.Text.ToUpper();
            proveedor.Observaciones = textObservaciones.Text.ToUpper();
            proveedor.BancoNombre = textBanco.Text.ToUpper();
            proveedor.TitularCuenta = textTitular.Text.ToUpper();
            proveedor.CuentaTipo = comboTipo.Text.ToUpper();
            proveedor.CuentaNumero = textNumero.Text.ToUpper();
            proveedor.PaginaWeb = textPagina.Text;

            //COMPROBAMOS SI EL PROVEEDOR EXISTE
            if (flagEditar)
            {
                //EXISTE
                proveedor.actualizar();
                MessageBox.Show("Datos actualizados con éxito.","Información");

                //CAMBIAMOS ASPECTO DEL BOTON GUARDAR
                this.buttonGuardar.Text = "Terminar";
                this.buttonGuardar.TextAlign = ContentAlignment.MiddleCenter;
                this.buttonGuardar.Image = null;
            }
            else
            {
                //NUEVO
                proveedor.agregar();
                this.actualizarDataGridEvento();
                MessageBox.Show("Datos guardado con éxito.", "Información");

                //CAMBIAMOS ASPECTO DEL BOTON GUARDAR
                this.buttonGuardar.Text = "Terminar";
                this.buttonGuardar.TextAlign = ContentAlignment.MiddleCenter;
                this.buttonGuardar.Image = null;
            }
            
            //this.Close();
        }

        private void limpiarFormulario()
        {
            textCuit.ResetText(); textApellido.ResetText();
            textEmail.ResetText(); textTelefono.ResetText(); textCp.ResetText();
            textDireccion.ResetText(); comboBoxLocalidad.ResetText(); comboBoxProvincia.ResetText();
            textObservaciones.ResetText(); textNumero.ResetText(); textBanco.ResetText();
            comboTipo.ResetText(); textTitular.ResetText(); textPagina.ResetText();
        }

        //INICIO LISTA FUNCIONES QUE CAMBIA EL BOTON GUARDAR
        private void textCuit_TextChanged(object sender, EventArgs e)
        {
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        }

        private void textNombre_TextChanged(object sender, EventArgs e)
        {
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        }

        private void textApellido_TextChanged(object sender, EventArgs e)
        {
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        }

        private void textEmail_TextChanged(object sender, EventArgs e)
        {
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        }

        private void textTelefono_TextChanged(object sender, EventArgs e)
        {
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        }

        private void textCp_TextChanged(object sender, EventArgs e)
        {
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        }

        private void textDireccion_TextChanged(object sender, EventArgs e)
        {
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        }

        private void textLocalidad_TextChanged(object sender, EventArgs e)
        {
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        }

        private void comboBoxProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.llenarComboLocalidad();
        }

        private void textObservaciones_TextChanged(object sender, EventArgs e)
        {
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        }

        private void textBanco_TextChanged(object sender, EventArgs e)
        {
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        }

        private void textTitular_TextChanged(object sender, EventArgs e)
        {
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        }

        private void textNumero_TextChanged(object sender, EventArgs e)
        {
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        }

        private void comboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        }

        //FIN LISTA FUNCIONES QUE CAMBIA EL BOTON GUARDAR
    }
}
