using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using VIBlend.WinForms.Controls;
using System.Windows.Forms.Calendar;

namespace SistemaClinica
{
    public partial class frmTurno : Form
    {
        
        public frmTurno()
        {
            InitializeComponent();
            this.calendar1.TimeUnitsOffset = -16;
            Doctor objDoctor = new Doctor();
            ArrayList colDoctor = new ArrayList();

            colDoctor = objDoctor.coleccion();

            if (Usuario.getFlag())
            {
                // EL USUARIO ES SECRETARIA

                for (int i = 0; i < colDoctor.Count; i++)
                {
                    objDoctor = (Doctor)colDoctor[i];
                    vOutlookItem tab = new vOutlookItem();
                    tab.Text = objDoctor.getMatricula();
                    tab.HeaderText = objDoctor.getApellido();
                    tab.Click += new EventHandler(this.tab_Click);
                    this.vOutlookNavPane1.Items.Add(tab);
                }
            }
            else if (Usuario.getAdmin())
            {
                // EL USUARIO ES ADMINISTRADOR
                for (int i = 0; i < colDoctor.Count; i++)
                {
                    objDoctor = (Doctor)colDoctor[i];
                    vOutlookItem tab = new vOutlookItem();
                    tab.Text = objDoctor.getMatricula();
                    tab.HeaderText = objDoctor.getApellido();
                    tab.Click += new EventHandler(this.tab_Click);
                    this.vOutlookNavPane1.Items.Add(tab);
                }
            }
            else
            {
                // EL USUARIO ES DOCTOR

                for (int i = 0; i < colDoctor.Count; i++)
                {
                    objDoctor = (Doctor)colDoctor[i];
                    if (objDoctor.getMatricula() == Usuario.getMatricula())
                    {
                        vOutlookItem tab = new vOutlookItem();
                        tab.Text = objDoctor.getMatricula();
                        tab.HeaderText = objDoctor.getApellido();
                        tab.Click += new EventHandler(this.tab_Click);
                        this.vOutlookNavPane1.Items.Add(tab);
                        break;
                    }
                }

            }
            
        }
        private void tab_Click(object sender, EventArgs e)
        {
            llenarSelectivo();
        }

        private void llenarSelectivo() // FILTRA LOS TURNOS POR DOCTOR SELECCIONADO
        {
            Turno objTurno = new Turno();
            this.calendar1.Items.Clear();
            objTurno.setMatricula(this.vOutlookNavPane1.SelectedItem.Text);
            ArrayList col = new ArrayList();
            col = objTurno.TurnosDoctor();
            for (int i = 0; i < col.Count; i++)
            {
                objTurno = (Turno)col[i];
                CalendarItem objItems = new CalendarItem(this.calendar1, objTurno.getFecha(), objTurno.getDuracion(), objTurno.getApellido() + " " + objTurno.getNombre());
                objItems.Tag = objTurno.getDni();
                this.calendar1.Items.Add(objItems);
            }
        }

        private int comprobarIdObra()
        {
            ObraSocial objObra = new ObraSocial();
            ArrayList colObra = new ArrayList();
            colObra = objObra.coleccion();

            for (int i = 0; i < colObra.Count; i++)
            {
                if (this.comboObra.Text == ((ObraSocial)colObra[i]).getNombre())
                {
                    objObra = (ObraSocial)colObra[i];
                    return objObra.getId();
                }
            }
            return -1; // NO TIENE OBRA SOCIAL
        }

        private string comprobarDoctor()
        {
            Doctor objDoctor = new Doctor();
            ArrayList colDoctor = new ArrayList();
            colDoctor = objDoctor.coleccion();

            for (int i = 0; i < colDoctor.Count; i++)
            {
                if (this.comboDoctor.Text == ((Doctor)colDoctor[i]).getApellido())
                {
                    objDoctor = (Doctor)colDoctor[i];
                    break;
                }
            }
            return objDoctor.getMatricula();
        }

        private void limpiarCampos()
        {
            this.textApellido.ResetText();
            this.textDireccion.ResetText();
            this.textDni.ResetText();
            this.textNombre.ResetText();
            this.comboCiudad.ResetText();
            this.comboObra.ResetText();
            this.maskedCelular.ResetText();
            this.maskedNacimiento.ResetText();
        }

        private void llenarComboObra()
        {
            ArrayList colObra = new ArrayList();
            ObraSocial objObra = new ObraSocial();

            colObra = objObra.coleccion();
            this.comboObra.Items.Clear();

            for (int i = 0; i < colObra.Count; i++)
            {
                objObra = (ObraSocial)colObra[i];
                this.comboObra.Items.Add(objObra.getNombre());
            }
        }

        private void llenarComboDoctor()
        {
            ArrayList colDoctor = new ArrayList();
            Doctor objDoctor = objDoctor = new Doctor();

            colDoctor = objDoctor.coleccion();
            this.comboDoctor.Items.Clear();

            for (int i = 0; i < colDoctor.Count; i++)
            {
                objDoctor = (Doctor)colDoctor[i];
                this.comboDoctor.Items.Add(objDoctor.getApellido());
            }
        }

        private void frmTurno_Load(object sender, EventArgs e)
        {
            this.llenarComboDoctor();
            this.llenarComboObra();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Paciente objPaciente = new Paciente();

            objPaciente.setNombre(this.textNombre.Text);
            objPaciente.setApellido(this.textApellido.Text);
            objPaciente.setDni(this.textDni.Text);
            objPaciente.setIdObra(this.comprobarIdObra());
            objPaciente.setNacimiento(this.maskedNacimiento.Text);
            objPaciente.setCelular(this.maskedCelular.Text);
            objPaciente.setCiudad(this.comboCiudad.Text);
            objPaciente.setDireccion(this.textDireccion.Text);
            objPaciente.setMatricula(this.comprobarDoctor());
            
            if (objPaciente.existePaciente())
            {
                // EL PACIENTE EXISTE - SE VAN A ACTUALIZAR LOS DATOS PERSONALES
                objPaciente.ActualizarPaciente();
            }
            else
            {
                // EL PACIENTE NO EXISTE - SE CREA UNO NUEVO
                objPaciente.NuevoPaciente();
            }

            this.limpiarCampos();
        }

        private void monthView1_SelectionChanged(object sender, EventArgs e)
        {
            calendar1.SetViewRange(monthView1.SelectionStart, monthView1.SelectionEnd.AddDays(2));
            this.llenarSelectivo();
        }

        private void calendar1_ItemCreated(object sender, CalendarItemCancelEventArgs e)
        {
            Turno objTurno = new Turno();
            // SE CREA EL TURNO
            // NO HA SIDO AVISADO - NO HA ASISTIDO
            
            objTurno.setDni(e.Item.Text);
            objTurno.setFecha(e.Item.Date);
            objTurno.setDuracion(e.Item.Duration);
            objTurno.setMatricula(this.vOutlookNavPane1.SelectedItem.Text);
            objTurno.setAviso(0);
            objTurno.setAsistencia(0);

            if (objTurno.ExisteTurno())
            {
                // EL TURNO YA FUE DADO
                MessageBox.Show("El turno se dio a otro paciente.", "Advertencia");
                this.calendar1.Items.Remove(e.Item);
            }
            else
            {
                // EL TURNO ESTA LIBRE
                objTurno.NuevoTurno();
            }
            this.llenarSelectivo();
        }

        private void calendar1_ItemDeleted(object sender, CalendarItemEventArgs e)
        {
            Turno objTurno = new Turno();

            objTurno.setDni(e.Item.Tag.ToString());
            objTurno.setMatricula(this.vOutlookNavPane1.SelectedItem.Text);
            objTurno.setFecha(e.Item.Date);

            objTurno.EliminarTurno();
        }

        private string DniItem(string cadena)
        {
            string dni = null;
            dni = cadena.Substring(0, 8);
            return dni;
        }

        private void calendar1_ItemClick(object sender, CalendarItemEventArgs e)
        {
            // CONFIRMAR AVISO POR SMS
            Turno objTurno = new Turno();
            objTurno.setDni(e.Item.Tag.ToString());
            objTurno.setFecha(e.Item.Date);
            objTurno.DatosTurno();
            
            // CON ESTA CONDICION MUESTRO DIALOGO DE CONFIRMACION ASISTENCIA
            // O DIALOGO DE ENVIO DE SMS
            if(e.Item.Date.ToShortDateString() == DateTime.Now.ToShortDateString())
            {
                // EL DIA ACTUAL ES IGUAL AL TURNO
                if (MessageBox.Show("Confirma la asistencia del Paciente.", "Confirmar Asistencia", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    objTurno.ConfirmarAsistencia();
                }
            }
            else
            {
                //EL DIA ACTUAL NO ES LA FECHA DEL TURNO
                if (MessageBox.Show("Enviar SMS recordatorio al Paciente.", "Envio de SMS", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    objTurno.EnviarSMS();
                }
            }
        }
    }
}
