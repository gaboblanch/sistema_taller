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
    public partial class frmAgregarEditarVehiculo : Form
    {
        private int idCliente;
        private Vehiculo vehiculo;
        private string nombreCliente;
        //private string apellidoCliente;
        private TipoRepuesto tipogas;

        private bool flagReparacion;

        //DELEGADO Y EVENTO PARA ACTUALIZAR LISTBOX EN frmAgregarEditarCliente
        public delegate void actualizarDataGrid();
        public event actualizarDataGrid actualizarListBox;

        //DELEGACION Y EVENTO PARA PASAR PARAMETROS DE UN FORM A OTRO
        public delegate void BuscarVehiculoHandler(object sender, BuscarVehiculoEventArgs e);
        public event BuscarVehiculoHandler VehiculoEncontrado;

        /// <summary>
        /// Editar datos del vehiculo desde el form Buscar
        /// </summary>
        /// <param name="idcliente_p"></param>
        /// <param name="flagReparacion_p"></param>
        /// <param name="vehiculo_p"></param>
        public frmAgregarEditarVehiculo(int idcliente_p, bool flagReparacion_p, object vehiculo_p)
        {
            InitializeComponent();
            idCliente = idcliente_p;
            flagReparacion = flagReparacion_p;
            vehiculo = new Vehiculo();
            if (vehiculo_p != null)
            {
                vehiculo = (Vehiculo)vehiculo_p;
            }
        }

        /// <summary>
        /// Agregar o editar datos de un vehiculo
        /// </summary>
        /// <param name="idcliente_p">Id del cliente</param>
        /// <param name="flagReparacion_p">Bandera para indicar si venimos del form frmAgregarEditarReparacion</param>
        public frmAgregarEditarVehiculo(int idcliente_p, bool flagReparacion_p)
        {
            InitializeComponent();
            idCliente = idcliente_p;
            flagReparacion = flagReparacion_p;
            vehiculo = new Vehiculo();
        }

        /// <summary>
        /// Constructor usado desde frmGestionCliente
        /// </summary>
        /// <param name="idcliente_p">(int)ID cliente</param>
        /// <param name="nombreCliente_p">(string) Nombre cliente</param>
        /// <param name="apellidoCliente_p">(string) Apellido cliente</param>
        /// <param name="flagReparacion_p">(bool) Bandera para indicar si venimos del form frmAgregarEditarReparacion</param>
        /// <param name="vehiculo_p">(vehiculo) Objeto del tipo vehiculo</param>
        public frmAgregarEditarVehiculo(int idcliente_p, string nombreCliente_p, bool flagReparacion_p, object vehiculo_p)
        {
            InitializeComponent();
            idCliente = idcliente_p;
            flagReparacion = flagReparacion_p;
            nombreCliente = nombreCliente_p;
            //apellidoCliente = apellidoCliente_p;
            vehiculo = new Vehiculo();
            if (vehiculo_p != null)
            {
                vehiculo = (Vehiculo)vehiculo_p;
            }

        }

        private void frmAgregarEditarVehiculo_Load(object sender, EventArgs e)
        {
            tipogas = new TipoRepuesto();
            this.llenarCombo();

            //CARGA EN LOS TEXTBOX NOMBRE Y APELLIDO DEL FORMULARIO frmAgregarEditarCliente
            textNombre.Text = nombreCliente;
            //textApellido.Text = apellidoCliente;

            //CARGA EN LOS TEXTBOX DEL VEHICULO
            this.textDominio.Text = vehiculo.Dominio;
            this.textModelo.Text = vehiculo.Modelo;
            this.textAnio.Text = vehiculo.Anio;
            this.comboMarca.Text = vehiculo.Marca;
            this.comboBoxTipo.Text = vehiculo.TipoGas;
            this.textCapacidad.Text = vehiculo.CapacidadCarga.ToString();
            textObservaciones.Text = vehiculo.Observaciones;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            vehiculo.Dominio = textDominio.Text.ToUpper();
            vehiculo.Marca = comboMarca.Text.ToUpper();
            vehiculo.Anio = textAnio.Text;
            vehiculo.Modelo = textModelo.Text.ToUpper();
            vehiculo.CapacidadCarga = Convert.ToDouble(textCapacidad.Text);
            vehiculo.TipoGas = comboBoxTipo.Text.ToUpper();
            vehiculo.Observaciones = textObservaciones.Text;

            //idCliente ES EL ID DEL CLIENTE DEL FORMULARIO ANTERIOR
            //INTERPRETACION DEL IF COMPROBAMOS EXISTENCIA DEL VEHICULO Y LOS DUEÑOS
            if (vehiculo.existeVehiculo() && idCliente != vehiculo.IdCliente)
            {
                //EXISTE EL VEHICULO Y LOS DUEÑOS SON DISTINTOS -> CAMBIAMOS DE DUEÑO
                if (MessageBox.Show("El vehículo ya existe, ¿Desea cambiar el dueño del mismo?", "Adevertencia", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    vehiculo.IdCliente = idCliente;
                    vehiculo.cambiarDuenio();
                    this.actualizarListBox();
                }
            }
            else
            {
                if (vehiculo.existeVehiculo())
                {
                    //EXISTE EL VEHICULO Y EL DUEÑO ES EL MISMO -> ACTUALIZAMOS DATOS DEL VEHICULO
                    vehiculo.actualizar();
                }
                else
                {
                    //CLIENTE ES NUEVO Y EL VEHICULO NO EXISTE
                    vehiculo.IdCliente = idCliente;
                    vehiculo.agregar();
                    vehiculo.Id = Conector.getLastID();
                }
            }

            if (flagReparacion)
            {
                BuscarVehiculoEventArgs args = new BuscarVehiculoEventArgs(
                    vehiculo
                    );

                VehiculoEncontrado(this, args);
            }
            else
            {
                if(this.actualizarListBox != null)
                    this.actualizarListBox(); 
            }
            this.Close();

        }

        private void buttonBuscarCliente_Click(object sender, EventArgs e)
        {
            frmBuscarCliente fbc = new frmBuscarCliente();
            fbc.ClienteEncontrado += new frmBuscarCliente.BuscarClienteHandler(fbc_ClienteEncontrado);
            fbc.MdiParent = this.MdiParent;
            fbc.Show();
        }

        void fbc_ClienteEncontrado(object sender, BuscarClienteEventArgs e)
        {
            vehiculo.IdCliente = ((Cliente)e.Cliente).Id;
            idCliente = ((Cliente)e.Cliente).Id;

            //this.textApellido.Text = e.ApellidoCliente;
            this.textNombre.Text = ((Cliente)e.Cliente).NombreRazonSocial;
        }

        private void llenarCombo()
        {
            ArrayList colTipo = new ArrayList();
            colTipo = tipogas.coleccionGas();

            this.comboBoxTipo.Items.Clear();

            for (int i = 0; i < colTipo.Count; i++)
            {
                TipoRepuesto objTipoLocal = new TipoRepuesto();
                objTipoLocal = (TipoRepuesto)colTipo[i];

                this.comboBoxTipo.Items.Add(objTipoLocal);
            }
        }

    }
}
