using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Windows.Forms.Calendar;

namespace SistemaGestionTaller
{
    public partial class frmAgregarEditarTurnos : Form
    {
        private Turnos turno;

        public frmAgregarEditarTurnos()
        {
            InitializeComponent();
        }

        private void limpiarCampos()
        {
            this.textApellido.ResetText(); this.textNombre.ResetText(); this.textModelo.ResetText(); this.textDominio.ResetText();
        }

        private void calendar1_ItemCreated(object sender, System.Windows.Forms.Calendar.CalendarItemCancelEventArgs e)
        {
            turno.agregar();
            turno.Cliente.Id = 0;
            turno.Vehiculo.Id = 0;
            this.limpiarCampos();
            this.llenarCalendario();
        }

        private void llenarCalendario() // FILTRA LOS TURNOS POR DOCTOR SELECCIONADO
        {
            Turnos objTurno = new Turnos();
            this.calendar1.Items.Clear();
            ArrayList col = new ArrayList();
            col = objTurno.coleccion(this.calendar1.ViewStart, this.calendar1.ViewEnd);

            for (int i = 0; i < col.Count; i++)
            {
                objTurno = (Turnos)col[i];
                System.Windows.Forms.Calendar.CalendarItem objItems = new System.Windows.Forms.Calendar.CalendarItem(this.calendar1, objTurno.Fecha, objTurno.Duracion, objTurno.Cliente.NombreRazonSocial);
                objItems.Tag = objTurno.Vehiculo.Dominio;
                this.calendar1.Items.Add(objItems);
            }
        }


        void fbc_ClienteEncontrado(object sender, BuscarClienteEventArgs e)
        {
            turno.Cliente.Id = ((Cliente)e.Cliente).Id;
            turno.Cliente.NombreRazonSocial = ((Cliente)e.Cliente).NombreRazonSocial;
            this.textNombre.Text = ((Cliente)e.Cliente).NombreRazonSocial;
            //this.textApellido.Text = e.ApellidoCliente;

        }

        private void frmAgregarEditarTurnos_Load(object sender, EventArgs e)
        {
            turno = new Turnos();
            this.calendar1.TimeUnitsOffset = -14;
            this.llenarCalendario();

        }


        private void calendar1_ItemCreating(object sender, System.Windows.Forms.Calendar.CalendarItemCancelEventArgs e)
        {
            if (turno.Cliente.Id != 0 && turno.Vehiculo.Id != 0)
            {
                turno.Fecha = e.Item.Date;
                turno.Duracion = e.Item.Duration;
                turno.Hora = e.Item.Date;
            }
            else
            {
                MessageBox.Show("Debe seleccionar un cliente y el vehículo.","ERROR");
                e.Cancel = true;
                return;
            }
        }

        private void calendar1_ItemDatesChanged(object sender, System.Windows.Forms.Calendar.CalendarItemEventArgs e)
        {
            turno.Fecha = e.Item.Date;
            turno.Duracion = e.Item.Duration;
            turno.Hora = e.Item.Date;
        }

        private void calendar1_ItemTextEdited(object sender, System.Windows.Forms.Calendar.CalendarItemCancelEventArgs e)
        {
            e.Item.Text = turno.Cliente.NombreRazonSocial;
        }

        private void buttonBuscarCliente_Click(object sender, EventArgs e)
        {
            this.textModelo.Text = "";
            this.textDominio.Text = "";
            turno.Vehiculo.Id = 0;

            frmBuscarCliente fbc = new frmBuscarCliente();
            fbc.ClienteEncontrado += new frmBuscarCliente.BuscarClienteHandler(fbc_ClienteEncontrado);
            fbc.MdiParent = this.MdiParent;            
            fbc.Show();
        }

        private void buttonBuscarVehiculo_Click(object sender, EventArgs e)
        {
            if (turno.Cliente.Id != 0)
            {
                frmBuscarVehiculo fbv = new frmBuscarVehiculo(turno.Cliente.Id);
                fbv.VehiculoEncontrado += new frmBuscarVehiculo.BuscarVehiculoHandler(fbv_VehiculoEncontrado);
                fbv.MdiParent = this.MdiParent;
                fbv.Show();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un cliente.", "Error");
                this.buttonBuscarCliente.PerformClick();
            }
        }

        void fbv_VehiculoEncontrado(object sender, BuscarVehiculoEventArgs e)
        {
            /*turno.Vehiculo.Id = e.IdVehiculo;
            turno.Vehiculo.Marca = e.Marca;
            turno.Vehiculo.Modelo = e.Modelo;

            this.textDominio.Text = e.Dominio;
            this.textModelo.Text = e.Marca + " / " + e.Modelo;*/
        }

        private void monthView1_SelectionChanged(object sender, EventArgs e)
        {
            calendar1.SetViewRange(monthView1.SelectionStart, monthView1.SelectionEnd.AddDays(2));
        }

        private void calendar1_ItemCreated_1(object sender, CalendarItemCancelEventArgs e)
        {
            MessageBox.Show(e.Item.Date +" "+ e.Item.Duration +" "+ e.Item.Text ,"Datos Turno Creado");
        }
    }
}
