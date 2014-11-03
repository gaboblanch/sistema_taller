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
    public partial class frmAgregarEditarCliente : Form
    {
        private Cliente cliente;
        private Vehiculo vehiculo;
        private int idCliente;
        private bool flagEditar;
        private bool flagReparacion;

        //DELEGADO Y EVENTO PARA ACTUALIZAR GRILLA EN frmGestionCliente
        public delegate void actualizarDataGrid();
        public event actualizarDataGrid actualizarDataGridEvento;

        //DELEGACION Y EVENTO PARA PASAR PARAMETROS DE UN FORM A OTRO
        public delegate void BuscarClienteHandler(object sender, BuscarClienteEventArgs e);
        public event BuscarClienteHandler ClienteEncontrado;


        /// <summary>
        /// Constructor llamado desde Gestión de Cliente para crear un nuevo cliente
        /// </summary>
        public frmAgregarEditarCliente()
        {
            InitializeComponent();
            this.flagEditar = false;
        }

        /// <summary>
        /// Constructor para editar un cliente existente
        /// </summary>
        /// <param name="idcliente_p"></param>
        public frmAgregarEditarCliente(int idcliente_p)
        {
            InitializeComponent();
            flagEditar = true;
            idCliente = idcliente_p;
        }

        /// <summary>
        /// Constructor para agregar un nuevo cliente desde una reparación
        /// para evitar actualizardatagrid
        /// </summary>
        public frmAgregarEditarCliente(bool flagReparacion_p)
        {
            InitializeComponent();
            this.flagReparacion = flagReparacion_p;
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
            ArrayList colLocalidad= new ArrayList();
            colLocalidad = localidad.coleccion(((Provincia)this.comboBoxProvincia.SelectedItem).IdProvincia);

            this.comboBoxLocalidad.ResetText();
            this.comboBoxLocalidad.Items.Clear();
            for (int i = 0; i < colLocalidad.Count; i++)
            {
                this.comboBoxLocalidad.Items.Add(((Localidad)colLocalidad[i]));
            }
        }

        private void buttonAgregarVehiculos_Click(object sender, EventArgs e)
        {
            if (flagEditar)
            {
                cliente.Dni = textCuit.Text;
                cliente.NombreRazonSocial = textNombre.Text.ToUpper();
                cliente.Telefono = textTelefono.Text;
                cliente.Direccion = textDireccion.Text.ToUpper();
                cliente.Localidad = comboBoxLocalidad.Text.ToUpper();
                cliente.Provincia = comboBoxProvincia.Text;
                cliente.Observaciones = textObservaciones.Text;
                cliente.Cuit = textCuit.Text;
                cliente.Cp = textCp.Text;
                cliente.Email = textEmail.Text;

                cliente.actualizar();
            }

            if (idCliente != 0)
            {
                //EL CLIENTE ES NUEVO   
                frmAgregarEditarVehiculo faev = new frmAgregarEditarVehiculo(idCliente, textNombre.Text, false, null);
                faev.actualizarListBox += new frmAgregarEditarVehiculo.actualizarDataGrid(llenarListBox);
                faev.MdiParent = this.MdiParent;
                faev.Show();

                //CAMBIAMOS EL NOMBRE DEL BOTON GUARDAR PARA GUIAR AL USUARIO
                this.buttonGuardar.Text = "Terminar";
                this.buttonGuardar.TextAlign = ContentAlignment.MiddleCenter;
                this.buttonGuardar.Image = null;
            }
            else 
            {
                //SE EJECUTA CUANDO EL OPERARIO NO HACE CLIC EN GUARDAR
                if (idCliente == 0)
                {
                    cliente.Dni = textCuit.Text;
                    cliente.NombreRazonSocial = textNombre.Text.ToUpper();
                    cliente.Telefono = textTelefono.Text;
                    cliente.Direccion = textDireccion.Text.ToUpper();
                    cliente.Localidad = comboBoxLocalidad.Text.ToUpper();
                    cliente.Provincia = comboBoxProvincia.Text.ToUpper();
                    cliente.Observaciones = textObservaciones.Text;
                    cliente.Cuit = textCuit.Text;
                    cliente.Cp = textCp.Text;
                    cliente.Email = textEmail.Text.ToUpper();

                    cliente.agregar();
                    idCliente = Conector.getLastID();

                    //EL CLIENTE ES NUEVO   
                    frmAgregarEditarVehiculo faev = new frmAgregarEditarVehiculo(idCliente, textNombre.Text, false, null);
                    faev.actualizarListBox += new frmAgregarEditarVehiculo.actualizarDataGrid(llenarListBox);
                    faev.MdiParent = this.MdiParent;
                    faev.Show();

                    //CAMBIAMOS EL NOMBRE DEL BOTON GUARDAR PARA GUIAR AL USUARIO
                    this.buttonGuardar.Text = "Terminar";
                    this.buttonGuardar.TextAlign = ContentAlignment.MiddleCenter;
                    this.buttonGuardar.Image = null;
                }
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (this.buttonGuardar.Text == "Terminar")
            {
                flagEditar = true;
                if (this.actualizarDataGridEvento!=null)
                    this.actualizarDataGridEvento();

                //SE EJECUTA CUANDO VENIMOS DEL FORM frmAgregarEditarReparación
                if (this.actualizarDataGridEvento == null)
                {
                    BuscarClienteEventArgs args = new BuscarClienteEventArgs(cliente);

                    ClienteEncontrado(this, args);

                    this.Close();
                    return;
                }

                this.Close();
                return;
            }
            cliente.Dni = textCuit.Text;
            cliente.NombreRazonSocial = textNombre.Text.ToUpper();
            cliente.Telefono = textTelefono.Text;
            cliente.Direccion = textDireccion.Text.ToUpper();
            cliente.Localidad = comboBoxLocalidad.Text.ToUpper();
            cliente.Provincia = comboBoxProvincia.Text.ToUpper();
            cliente.Observaciones = textObservaciones.Text.ToUpper();
            cliente.Cuit = textCuit.Text;
            cliente.Cp = textCp.Text;
            cliente.Email = textEmail.Text;

            if (flagEditar)
            {
                cliente.actualizar();
                if (this.actualizarDataGridEvento != null)
                {
                    this.actualizarDataGridEvento();
                }
                else if (this.actualizarDataGridEvento == null)
                {
                    BuscarClienteEventArgs args = new BuscarClienteEventArgs(cliente);

                    ClienteEncontrado(this, args);
                }
                MessageBox.Show("Datos guardados correctamente.", "Información");
                this.Close();
                return;
            }
            else
            {
                cliente.agregar();
                idCliente = cliente.Id;

                //SE EJECUTA CUANDO VENIMOS DEL FORM frmAgregarEditarReparación
                if (this.actualizarDataGridEvento == null)
                {
                    BuscarClienteEventArgs args = new BuscarClienteEventArgs(cliente);

                    ClienteEncontrado(this, args);

                    MessageBox.Show("Datos guardados correctamente.", "Información");
                    this.Close();
                    return;
                }
            }               

            if(this.actualizarDataGridEvento!=null)
                this.actualizarDataGridEvento();
            MessageBox.Show("Datos guardados correctamente.", "Información");

            //CAMBIAMOS EL NOMBRE DEL BOTON GUARDAR PARA GUIAR AL USUARIO
            this.buttonGuardar.Text = "Terminar";
            this.buttonGuardar.TextAlign = ContentAlignment.MiddleCenter;
            this.buttonGuardar.Image = null;
            return;            
        }

        private void frmAgregarEditarCliente_Load(object sender, EventArgs e)
        {
            cliente = new Cliente();
            vehiculo = new Vehiculo();

            this.buttonEditar.Enabled = false;
            this.llenarComboProvincia();

            if (flagEditar)
            {
                cliente.Id = idCliente;

                //TRAEMOS LOS DATOS DEL CLIENTE A EDITAR
                cliente.getDatosPersonales();
                llenarListBox();

                //ENTERO INDICA LONGITUD DEL NOMBRE
                //int i = (cliente.NombreRazonSocial.Length - 1) - (cliente.NombreRazonSocial.IndexOf(",") + 1);

                //COLOCAMOS LOS DATOS EN LOS CAMPOS DEL FORMULARIO
                if (cliente.Cuit == "")
                {
                    textCuit.Text = cliente.Dni;
                }
                else
                {
                    textCuit.Text = cliente.Cuit;
                }
                
                textNombre.Text = cliente.NombreRazonSocial;
                //textNombre.Text = cliente.NombreRazonSocial.Substring((cliente.NombreRazonSocial.IndexOf(",") + 2), i);
                //textApellido.Text = cliente.NombreRazonSocial.Substring(0, cliente.NombreRazonSocial.IndexOf(","));
                textTelefono.Text = cliente.Telefono;
                textDireccion.Text = cliente.Direccion;
                comboBoxProvincia.Text = cliente.Provincia.ToUpper();
                comboBoxLocalidad.Text = cliente.Localidad.ToUpper();
                textObservaciones.Text = cliente.Observaciones.ToUpper();
                textEmail.Text = cliente.Email;
                textCp.Text = cliente.Cp;

                //CAMBIAMOS EL NOMBRE DEL BOTON GUARDAR PARA GUIAR AL USUARIO
                this.buttonGuardar.Text = "Terminar";
                this.buttonGuardar.TextAlign = ContentAlignment.MiddleCenter;
                this.buttonGuardar.Image = null;
            }
            else
            {
                
                this.buttonQuitarVehiculos.Enabled = false;
            }
        }

        private void llenarListBox()
        {
            this.buttonQuitarVehiculos.Enabled = false;
            this.buttonEditar.Enabled = false;

            //LISTAMOS VEHICULOS
            if (idCliente != 0)
            {
                //EL CLIENTE ES NUEVO
                vehiculo.IdCliente = idCliente;
            }
            else
            {
                //EL CLIENTE YA EXISTE
                vehiculo.IdCliente = cliente.Id;
            }

            cliente.Vehiculos = vehiculo.vehiculosCliente();

            this.listBoxVehiculos.Items.Clear();

            foreach (object o in cliente.Vehiculos)
                this.listBoxVehiculos.Items.Add((Vehiculo)o);
        }

        private void listBoxVehiculos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //EL CLIENTE YA EXISTE
            Vehiculo objVehiculoLocal = new Vehiculo();
            objVehiculoLocal = (Vehiculo)this.listBoxVehiculos.SelectedItem;

            frmAgregarEditarVehiculo faev = new frmAgregarEditarVehiculo(cliente.Id, textNombre.Text, false, objVehiculoLocal);
            faev.actualizarListBox += new frmAgregarEditarVehiculo.actualizarDataGrid(llenarListBox);
            faev.MdiParent = this.MdiParent;
            faev.Show();
        }

        private void buttonQuitarVehiculos_Click(object sender, EventArgs e)
        {
            Cliente objClienteNull = new Cliente();
            objClienteNull.Id = 0;
            if (objClienteNull.getDatosPersonales())
            {
                vehiculo = (Vehiculo)this.listBoxVehiculos.SelectedItem;
                vehiculo.quitarVehiculo();
                MessageBox.Show("Vehículo eliminado.", "Información");
                llenarListBox();
            }
            else
            {
                try
                {
                    objClienteNull.Id = 0;
                    objClienteNull.NombreRazonSocial = "---";
                    objClienteNull.Dni = "---";
                    objClienteNull.Observaciones = "---";
                    objClienteNull.agregarNull();
                    vehiculo = (Vehiculo)this.listBoxVehiculos.SelectedItem;
                    vehiculo.quitarVehiculo();
                    MessageBox.Show("Vehículo eliminado.", "Información");
                    llenarListBox();
                }
                catch
                {
                    MessageBox.Show("Ocurrió un error al eliminar el vehículo. Cierre la ventana e intentelo de nuevo."," Error",MessageBoxButtons.OK);
                    return;
                }
            }
        }

        private void listBoxVehiculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.buttonQuitarVehiculos.Enabled = true;
            this.buttonEditar.Enabled = true;
        }

        //LISTA DE EVENTOS QUE CAMBIA EL BOTON GUARDAR
        //CADA VEZ QUE SE HA GUARDADO Y DESPUES SE MODIFICA ALGUN CAMPO
        private void textDni_TextChanged(object sender, EventArgs e)
        {
            //CAMBIAMOS EL NOMBRE DEL BOTON GUARDAR PARA GUIAR AL USUARIO
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = ContentAlignment.MiddleRight;
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = ContentAlignment.MiddleLeft;

        }

        private void textNombre_TextChanged(object sender, EventArgs e)
        {
            //CAMBIAMOS EL NOMBRE DEL BOTON GUARDAR PARA GUIAR AL USUARIO
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = ContentAlignment.MiddleRight;
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = ContentAlignment.MiddleLeft;
        }

        private void textApellido_TextChanged(object sender, EventArgs e)
        {
            //CAMBIAMOS EL NOMBRE DEL BOTON GUARDAR PARA GUIAR AL USUARIO
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = ContentAlignment.MiddleRight;
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = ContentAlignment.MiddleLeft;

        }

        private void textEmail_TextChanged(object sender, EventArgs e)
        {
            //CAMBIAMOS EL NOMBRE DEL BOTON GUARDAR PARA GUIAR AL USUARIO
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = ContentAlignment.MiddleRight;
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = ContentAlignment.MiddleLeft;
            
        }

        private void textTelefono_TextChanged(object sender, EventArgs e)
        {
            //CAMBIAMOS EL NOMBRE DEL BOTON GUARDAR PARA GUIAR AL USUARIO
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = ContentAlignment.MiddleRight;
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = ContentAlignment.MiddleLeft;
        }

        private void textCuit_TextChanged(object sender, EventArgs e)
        {
            //CAMBIAMOS EL NOMBRE DEL BOTON GUARDAR PARA GUIAR AL USUARIO
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = ContentAlignment.MiddleRight;
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = ContentAlignment.MiddleLeft;
            
        }

        private void textCp_TextChanged(object sender, EventArgs e)
        {
            //CAMBIAMOS EL NOMBRE DEL BOTON GUARDAR PARA GUIAR AL USUARIO
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = ContentAlignment.MiddleRight;
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = ContentAlignment.MiddleLeft;
            
        }

        private void textDireccion_TextChanged(object sender, EventArgs e)
        {
            //CAMBIAMOS EL NOMBRE DEL BOTON GUARDAR PARA GUIAR AL USUARIO
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = ContentAlignment.MiddleRight;
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = ContentAlignment.MiddleLeft;
            
        }

        private void textLocalidad_TextChanged(object sender, EventArgs e)
        {
            //CAMBIAMOS EL NOMBRE DEL BOTON GUARDAR PARA GUIAR AL USUARIO
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = ContentAlignment.MiddleRight;
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = ContentAlignment.MiddleLeft;
            
        }

        private void comboBoxProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CAMBIAMOS EL NOMBRE DEL BOTON GUARDAR PARA GUIAR AL USUARIO
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = ContentAlignment.MiddleRight;
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = ContentAlignment.MiddleLeft;

            this.llenarComboLocalidad();
            
        }

        private void textObservaciones_TextChanged(object sender, EventArgs e)
        {
            //CAMBIAMOS EL NOMBRE DEL BOTON GUARDAR PARA GUIAR AL USUARIO
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = ContentAlignment.MiddleRight;
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = ContentAlignment.MiddleLeft;

        }
        //FIN DE FUNCIONES PARA CAMBIAR BOTON GUARDAR

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            //EL CLIENTE YA EXISTE
            Vehiculo objVehiculoLocal = new Vehiculo();
            objVehiculoLocal = (Vehiculo)this.listBoxVehiculos.SelectedItem;

            frmAgregarEditarVehiculo faev = new frmAgregarEditarVehiculo(cliente.Id, textNombre.Text, false, objVehiculoLocal);
            faev.actualizarListBox += new frmAgregarEditarVehiculo.actualizarDataGrid(llenarListBox);
            faev.MdiParent = this.MdiParent;
            faev.Show();
        }

        

    }
}
