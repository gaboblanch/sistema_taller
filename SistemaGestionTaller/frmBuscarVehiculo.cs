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
    public partial class frmBuscarVehiculo : Form
    {
        private Vehiculo vehiculo;
        private int idCliente;

        //DELEGACION Y EVENTO PARA PASAR PARAMETROS DE UN FORM A OTRO
        public delegate void BuscarVehiculoHandler(object sender, BuscarVehiculoEventArgs e);
        public event BuscarVehiculoHandler VehiculoEncontrado;
        

        public frmBuscarVehiculo(int idCliente_p)
        {
            InitializeComponent();
            idCliente = idCliente_p;
        }

        private void llenarListBox()
        {
            ArrayList colVehiculos = new ArrayList();
            vehiculo.IdCliente = idCliente;

            colVehiculos = vehiculo.vehiculosCliente();

            this.listBoxVehiculos.Items.Clear();

            foreach (object o in colVehiculos)
                this.listBoxVehiculos.Items.Add(
                    ((Vehiculo)o));
        }

        private void frmBuscarVehiculo_Load(object sender, EventArgs e)
        {
            vehiculo = new Vehiculo();
            this.buttonEditar.Enabled = false;
            llenarListBox();
        }

        private void listBoxVehiculos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            vehiculo = (Vehiculo)this.listBoxVehiculos.SelectedItem;

            BuscarVehiculoEventArgs args = new BuscarVehiculoEventArgs(
                vehiculo
                );

            VehiculoEncontrado(this, args);

            this.Close();
        }

        private void listBoxVehiculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.buttonEditar.Enabled = true;
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            vehiculo = (Vehiculo)this.listBoxVehiculos.SelectedItem;
            frmAgregarEditarVehiculo faev = new frmAgregarEditarVehiculo(idCliente, false, vehiculo);
            faev.MdiParent = this.MdiParent;
            faev.Show();
        }
    }
}
