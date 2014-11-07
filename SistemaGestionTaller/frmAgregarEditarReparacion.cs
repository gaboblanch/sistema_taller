using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing.Imaging;
using System.Drawing.Printing;

namespace SistemaGestionTaller
{
    public partial class frmAgregarEditarReparacion : Form
    {
        private Reparacion reparacion;
        private TareaReparacion tarea;
        private RepuestoReparacion repuesto;
        private RepuestoReparacion repuestoGas;
        private double importeFinal;
        private bool flagEditar;
        private bool flagPresupuesto;
        private int idReparacion;
        private ArrayList colIdTareas;
        private ArrayList colIdRepuestos;
        private ArrayList colIdGas;
        private int contadorRepuestoManual;
        private int contadorTareaManual;
        private double totalTareas;
        private double totalRepuestos;

        //DELEGADO Y EVENTO PARA ACTUALIZAR GRILLA EN frmGestionReparacion
        public delegate void actualizarDataGrid();
        public event actualizarDataGrid actualizarDataGridEvento;

        //CONSTRUCTOR ORDEN DE TRABAJO
        public frmAgregarEditarReparacion()
        {
            InitializeComponent();
        }

        //CONSTRUCTOR PRESUPUESTO
        public frmAgregarEditarReparacion(bool flagPresupuesto_p)
        {
            InitializeComponent();
            this.flagPresupuesto = flagPresupuesto_p;
        }

        //CONSTRUCTOR EDITAR
        public frmAgregarEditarReparacion(int idReparacion_p, bool flagPresupuesto_p)
        {
            InitializeComponent();
            idReparacion = idReparacion_p;
            flagPresupuesto = flagPresupuesto_p;
            flagEditar = true;
        }

        //CONSTRUCTOR SOLO LECTURA
        public frmAgregarEditarReparacion(int idReparacion_p)
        {
            InitializeComponent();
            idReparacion = idReparacion_p;
            flagPresupuesto = false;
            flagEditar = true;
            this.soloLectura();
        }

        private void soloLectura()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TabControl)
                {
                    control.Enabled = true;

                    if (control.HasChildren)
                    {
                        foreach (Control controlChild in control.Controls)
                        {
                            controlChild.Enabled = false;
                        }
                    }
                    
                }
                else if (control.HasChildren)
                {
                    foreach (Control controlChild in control.Controls)
                    {
                        controlChild.Enabled = false;
                    }
                }
                /*else if (control is Button && (control.Name == "buttonCopiar" || control.Text == "Guardar"))
                        control.Enabled = true;*/
                else
                    control.Enabled = false;
            }
        }

        private void calcular()
        {
            importeFinal = 0;
            totalRepuestos = 0;
            totalTareas = 0;
            //DATAGRID TAREA
            foreach (DataGridViewRow row in this.dataGridDetalle.Rows)
            {
                if (row.Cells["preciotarea"].Value != null)
                {
                    importeFinal += (double)row.Cells["preciotarea"].Value;
                    totalTareas += (double)row.Cells["preciotarea"].Value;
                }
            }

            //DATAGRID REPUESTO
            foreach (DataGridViewRow row in this.dataGridRepuesto.Rows)
            {
                if (row.Cells["importerepuesto"].Value != null)
                {
                    importeFinal += Convert.ToDouble(row.Cells["importerepuesto"].Value);
                    totalRepuestos += Convert.ToDouble(row.Cells["importerepuesto"].Value);
                }
            }

            //DATAGRID CARGA GAS
            foreach (DataGridViewRow row in this.dataGridGas.Rows)
            {
                if (row.Cells["importegas"].Value != null)
                {
                    importeFinal += Convert.ToDouble(row.Cells["importegas"].Value);
                }
            }

            this.textBoxTotalRepuestos.Text = "$ " + totalRepuestos.ToString("0.00");
            this.textBoxTotalTareas.Text = "$ " + totalTareas.ToString("0.00");
            this.textTotal.Text = "$ " + (importeFinal).ToString("0.00");
        }

        private void loadForm()
        {
            reparacion = new Reparacion();
            repuesto = new RepuestoReparacion();
            repuestoGas = new RepuestoReparacion();
            tarea = new TareaReparacion();
            colIdRepuestos = new ArrayList();
            colIdTareas = new ArrayList();
            colIdGas = new ArrayList();
            this.buttonAgregarTarea.Enabled = false;
            this.buttonAgregarRepuesto.Enabled = false;
            this.buttonAgregarGas.Enabled = false;
            this.buttonEliminarRepuesto.Enabled = false;
            this.buttonEliminarTarea.Enabled = false;
            this.buttonEliminarGas.Enabled = false;
            
            if (!flagEditar)
                this.checkBoxPresupuesto.Checked = flagPresupuesto;

            if (flagEditar)
            {
                reparacion.IdReparacion = idReparacion;
                reparacion.getReparacion();

                //CLIENTE
                this.textNombre.Text = reparacion.Cliente.NombreRazonSocial;

                //VEHICULO
                this.textDominio.Text = reparacion.Vehiculo.Dominio;
                this.textModelo.Text = reparacion.Vehiculo.Marca + " " + reparacion.Vehiculo.Modelo;
                this.textBoxCapacidad.Text = reparacion.Vehiculo.CapacidadCarga.ToString().Insert(reparacion.Vehiculo.CapacidadCarga.ToString().Length, " gr.");

                //REPARACION
                this.dateTimePicker1.Value = reparacion.Fecha;
                this.textDescripcion.Text = reparacion.Descripcion;
                this.labelCodigoReparacion.Text = reparacion.CodigoReparacion;

                if (reparacion.Estado == 0)
                {
                    this.checkBoxPresupuesto.Checked = true;
                }
                else if (reparacion.Estado == 1)
                {
                    this.checkBoxPresupuesto.Checked = false;
                }

                //LLENAMOS LOS DETALLES DE REPUESTOS Y TAREAS
                this.llenarDataGridRepuesto();
                this.llenarDataGridTarea();
                this.llenarDataGridGas();


                //CAMBIAMOS ASPECTO DE BOTON GUARDAR
                this.buttonGuardar.Text = "Terminar";
                this.buttonGuardar.TextAlign = ContentAlignment.MiddleCenter;
                this.buttonGuardar.Image = null;

                this.checkBoxPresupuesto.Checked = flagPresupuesto;
                if (this.checkBoxPresupuesto.Checked)
                    this.checkBoxPresupuesto.Text = "Presupuesto";
                else
                    this.checkBoxPresupuesto.Text = "Orden de Trabajo";
            }
            else
            {
                try
                {
                    
                    if (flagPresupuesto)
                    {
                        //incrementalCodigoReparacion = Convert.ToInt32(reparacion.getUltimoPresupuesto().Split('-')[2]) + 1;
                        //this.labelCodigoReparacion.Text = "PS-" + DateTime.Now.Year + String.Format("{0:MM}", DateTime.Now) + "-" + incrementalCodigoReparacion;
                    }
                    else
                    {
                        //incrementalCodigoReparacion = Convert.ToInt32(reparacion.getUltimaReparacion().Split('-')[2]) + 1;
                        //this.labelCodigoReparacion.Text = "OT-" + DateTime.Now.Year + String.Format("{0:MM}", DateTime.Now) + "-" + incrementalCodigoReparacion;
                    }
                }
                catch
                {
                    if (flagPresupuesto)
                    {
                        this.labelCodigoReparacion.Text = "PS-" + DateTime.Now.Year + String.Format("{0:MM}", DateTime.Now) + "-" + 1;
                    }
                    else
                    {
                        this.labelCodigoReparacion.Text = "OT-" + DateTime.Now.Year + String.Format("{0:MM}", DateTime.Now) + "-" + 1;
                    }
                }
            }
        }

        private void frmAgregarEditarReparacion_Load(object sender, EventArgs e)
        {
            this.loadForm();
        }

        private void buttonBuscarCliente_Click(object sender, EventArgs e)
        {
            this.textModelo.Text = "";
            this.textDominio.Text = "";
            reparacion.Vehiculo.Id = 0;

            frmBuscarCliente fbc = new frmBuscarCliente();
            fbc.ClienteEncontrado += new frmBuscarCliente.BuscarClienteHandler(fbc_ClienteEncontrado);
            fbc.MdiParent = this.MdiParent;
            fbc.Show();

        }

        void fbc_ClienteEncontrado(object sender, BuscarClienteEventArgs e)
        {
            try
            {
                reparacion.Cliente = (Cliente)e.Cliente;
                this.textNombre.Text = reparacion.Cliente.NombreRazonSocial;
            }
            catch
            {
                MessageBox.Show("Occurió un error inesperado, por favor intente de nuevo","Error");
                return;
            }
        }

        private void buttonNuevoCliente_Click(object sender, EventArgs e)
        {
            frmAgregarEditarCliente faec = new frmAgregarEditarCliente(true);
            faec.ClienteEncontrado += new frmAgregarEditarCliente.BuscarClienteHandler(fbc_ClienteEncontrado);
            faec.MdiParent = this.MdiParent;
            faec.Show();
        }

        private void buttonAgregarVehiculo_Click(object sender, EventArgs e)
        {
            frmAgregarEditarVehiculo faev = new frmAgregarEditarVehiculo(reparacion.Cliente.Id, textNombre.Text, true, null);
            faev.VehiculoEncontrado += new frmAgregarEditarVehiculo.BuscarVehiculoHandler(fbv_VehiculoEncontrado);
            faev.MdiParent = this.MdiParent;
            faev.Show();
        }

        private void buttonBuscarVehiculo_Click(object sender, EventArgs e)
        {
            if (reparacion.Cliente.Id != 0)
            {
                frmBuscarVehiculo fbv = new frmBuscarVehiculo(reparacion.Cliente.Id);
                fbv.VehiculoEncontrado += new frmBuscarVehiculo.BuscarVehiculoHandler(fbv_VehiculoEncontrado);
                fbv.MdiParent = this.MdiParent;
                fbv.Show();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un cliente.","Error");
                this.buttonBuscarCliente.PerformClick();
            }
        }

        void fbv_VehiculoEncontrado(object sender, BuscarVehiculoEventArgs e)
        {
            /*reparacion.Vehiculo.Id = e.IdVehiculo;
            reparacion.Vehiculo.Marca = e.Marca;
            reparacion.Vehiculo.Modelo = e.Modelo;*/

            reparacion.Vehiculo = (Vehiculo)e.Vehiculo;

            this.textDominio.Text = reparacion.Vehiculo.Dominio;
            this.textModelo.Text = reparacion.Vehiculo.Marca + " / " + reparacion.Vehiculo.Modelo;
            this.textBoxCapacidad.Text = reparacion.Vehiculo.CapacidadCarga.ToString().Insert(reparacion.Vehiculo.CapacidadCarga.ToString().Length, " gr.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmBuscarTarea fbt = new frmBuscarTarea(colIdTareas);
            fbt.TareaEncontrada += new frmBuscarTarea.BuscarTareaHandler(fbt_TareaEncontrada);
            fbt.MdiParent = this.MdiParent;
            fbt.Show();
        }

        void fbt_TareaEncontrada(object sender, BuscarTareaEventArgs e)
        {
            tarea = (TareaReparacion)e.Tarea;
            this.textTarea.Text = ((TareaReparacion)e.Tarea).ToString();
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            tarea.Costo = Convert.ToDouble(this.textCostoTarea.Text);

            reparacion.DetalleTarea.Add(tarea);

            //BUSCAMOS EN LAS TAREAS ELIMINADAS LA TAREA A AGREGAR
            for (int i = 0; i < reparacion.DetalleTareaEliminados.Count; i++)
            {
                if (tarea.IdTarea == ((TareaReparacion)reparacion.DetalleTareaEliminados[i]).IdTarea)
                {
                    reparacion.DetalleTareaEliminados.RemoveAt(i);
                }
            }

            this.llenarDataGridTarea();

        }

        private void llenarDataGridTarea()
        {
            try
            {
                this.dataGridDetalle.Rows.Clear();
                colIdTareas.RemoveRange(0, colIdTareas.Count);

                for (int i = 0; i < reparacion.DetalleTarea.Count; i++)
                {
                    this.dataGridDetalle.Rows.Add();

                    //COMPROBAMOS SI ES TAREA MANUAL O DE LISTA
                    if (((TareaReparacion)reparacion.DetalleTarea[i]).IdTareaManual != null)
                    {
                        //MANUAL
                        this.dataGridDetalle.Rows[i].Cells["idtarea"].Value = ((TareaReparacion)reparacion.DetalleTarea[i]).IdTareaManual;
                        this.dataGridDetalle.Rows[i].Cells["flagmanual"].Value = ((TareaReparacion)reparacion.DetalleTarea[i]).FlagTareaManual;
                    }
                    else
                    {
                        //LISTA
                        this.dataGridDetalle.Rows[i].Cells["idtarea"].Value = ((TareaReparacion)reparacion.DetalleTarea[i]).IdTarea;
                        this.dataGridDetalle.Rows[i].Cells["flagmanual"].Value = ((TareaReparacion)reparacion.DetalleTarea[i]).FlagTareaManual;
                        colIdTareas.Add(((TareaReparacion)reparacion.DetalleTarea[i]).IdTarea);
                    }

                    this.dataGridDetalle.Rows[i].Cells["descripciontarea"].Value = ((TareaReparacion)reparacion.DetalleTarea[i]).DescripcionTarea;
                    //this.dataGridDetalle.Rows[i].Cells["cantidad"].Value = ((TareaReparacion)reparacion.DetalleTarea[i]).Cantidad;
                    //this.dataGridDetalle.Rows[i].Cells["tiempo"].Value = ((TareaReparacion)reparacion.DetalleTarea[i]).Duracion.ToString(@"hh\:mm");
                    this.dataGridDetalle.Rows[i].Cells["preciotarea"].Value = ((TareaReparacion)reparacion.DetalleTarea[i]).Costo;


                }
                this.dataGridDetalle.ClearSelection();
                this.inicializarCamposTarea();
                this.calcular();
            }
            catch
            {
                MessageBox.Show("Debe presionar enter para confirmar los cambios", "Error");
            }
        }

        /// <summary>
        /// Anula y limpia los controles correspondientes 
        /// para que no se cometa un error al agregar una nueva tarea
        /// </summary>
        private void inicializarCamposTarea()
        {
            this.textCostoTarea.ResetText(); this.textTarea.ResetText(); this.buttonAgregarTarea.Enabled = false;
        }

        private void textCantidad_TextChanged(object sender, EventArgs e)
        {
            if (this.textCostoTarea.Text != "")
            {
                this.buttonAgregarTarea.Enabled = true;
            }
            else
            {
                this.buttonAgregarTarea.Enabled = false;
            }
        }

        private void limpiarCampos()
        {
            this.textTotal.ResetText(); this.textDominio.ResetText(); this.textModelo.ResetText();
            this.textNombre.ResetText(); /*this.textApellido.ResetText();*/ this.textDescripcion.ResetText();
            this.dataGridDetalle.Rows.Clear(); this.dataGridRepuesto.Rows.Clear();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if(this.buttonGuardar.Text == "Terminar")
            {
                this.Close();
                return;
            }           

            //COMPROBAMOS QUE HAY UNA TAREA O REPUESTO, SE HA ASIGNADO UN CLIENTE Y UN VEHICULO
            if (reparacion.Cliente.Id == 0 && reparacion.Vehiculo.Id == 0)
            {
                MessageBox.Show("Verifique que ha seleccionado un Cliente y un Vehículo para la reparación.", "Advertencia");
                return;
            }

            if (reparacion.DetalleTarea.Count != 0 || reparacion.DetalleRepuestos.Count != 0 || reparacion.DetalleCargas.Count != 0)
            {
                //1ro GUARDAMOS LA REPARACION
                reparacion.FechaSistema = DateTime.Now;
                reparacion.Fecha = this.dateTimePicker1.Value;
                reparacion.Descripcion = this.textDescripcion.Text.ToUpper();
                reparacion.ImporteTotal = Convert.ToDouble(this.textTotal.Text.Substring(1, this.textTotal.Text.Length-1));
                reparacion.CodigoReparacion = this.labelCodigoReparacion.Text;

                if (this.checkBoxPresupuesto.Checked)
                {
                    reparacion.Estado = 0; //Cero equivale a Estado de Presupuesto
                    flagPresupuesto = true;
                }
                else
                {
                    reparacion.Estado = 1; //Uno equivale a Estado de Orden de Trabajo
                    flagPresupuesto = false;
                }

                try
                {
                    if (flagPresupuesto)
                    {
                        //ES UN PRESUPUESTO
                        if (flagEditar)
                        {
                            if (reparacion.Estado == 0 && reparacion.EstadoAnterior == 1)
                            {
                                if (MessageBox.Show("Esta a punto de cambiar la Orden de Trabajo a Presupuesto ¿Está seguro?", "Advertencia", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    reparacion.actualizar(4);
                                }
                                else
                                    return;
                            }
                            else
                                reparacion.actualizar(0);

                            MessageBox.Show("Presupuesto actualizado con éxito.", "Información");
                            //True CUANDO ES UN PRESUPUESTO
                            if (this.actualizarDataGridEvento != null)
                            {
                                this.actualizarDataGridEvento();
                            }

                            //CAMBIAMOS ASPECTO DE BOTON GUARDAR
                            this.buttonGuardar.Text = "Terminar";
                            this.buttonGuardar.TextAlign = ContentAlignment.MiddleCenter;
                            this.buttonGuardar.Image = null;
                        }
                        else
                        {
                            reparacion.agregar();
                            //True CUANDO ES UN PRESUPUESTO
                            if (this.actualizarDataGridEvento != null)
                            {
                                this.actualizarDataGridEvento();
                            }
                            MessageBox.Show("Presupuesto guardado con éxito.", "Información");

                            //CAMBIAMOS ASPECTO DE BOTON GUARDAR
                            this.buttonGuardar.Text = "Terminar";
                            this.buttonGuardar.TextAlign = ContentAlignment.MiddleCenter;
                            this.buttonGuardar.Image = null;
                        }
                    }
                    else
                    {
                        //ORDEN DE TRABAJO
                        if (flagEditar)
                        {
                            //REPUESTOS
                            foreach (object o in reparacion.DetalleRepuestos)
                            {
                                if (((RepuestoReparacion)o).IdRepuesto == ((RepuestoReparacion)o).IdRepuestoReparacion)
                                {
                                    if (((RepuestoReparacion)o).FlagRepuestoManual)
                                    {
                                        ((RepuestoReparacion)o).CantidadStock = ((RepuestoReparacion)o).CantidadRequerida;
                                    }
                                    else
                                    {
                                        ((RepuestoReparacion)o).CantidadRequerida = ((RepuestoReparacion)o).CantidadStock;
                                    }
                                }

                                /*if (((RepuestoReparacion)o).CantidadRequerida >= ((RepuestoReparacion)o).CantidadStock)
                                {
                                    MessageBox.Show("Repuesto: " + (RepuestoReparacion)o + "\nStock: " + ((RepuestoReparacion)o).CantidadStock + "\nCantidad Requerida: " + ((RepuestoReparacion)o).CantidadRequerida + "", "Error");
                                    return;
                                }*/
                            }
                            //CARGAS DE GAS
                            foreach (object o in reparacion.DetalleCargas)
                            {
                                if (((RepuestoReparacion)o).IdRepuesto == ((RepuestoReparacion)o).IdRepuestoReparacion)
                                {
                                    ((RepuestoReparacion)o).CantidadRequerida = ((RepuestoReparacion)o).CantidadStock;
                                }

                                /*if (((RepuestoReparacion)o).CantidadRequerida > ((RepuestoReparacion)o).CantidadStock)
                                {
                                    MessageBox.Show("Gas: " + (RepuestoReparacion)o + "\nCantidad Disponible: " + ((RepuestoReparacion)o).CantidadStock + "\nCantidad Requerida: " + ((RepuestoReparacion)o).CantidadRequerida + "", "Error");
                                    return;
                                }*/
                            }

                            try
                            {
                                reparacion.actualizar(1);

                                MessageBox.Show("Reparacion actualizada con éxito.", "Información");
                            }
                            catch
                            {
                                MessageBox.Show("Ocurrió un error al intentar actualizar vuelva a cargar la OT para verificar cambios.", "Error");
                            }

                            if (this.actualizarDataGridEvento != null)
                            {
                                this.actualizarDataGridEvento();
                            }
                                
                            //CAMBIAMOS ASPECTO DE BOTON GUARDAR
                            this.buttonGuardar.Text = "Terminar";
                            this.buttonGuardar.TextAlign = ContentAlignment.MiddleCenter;
                            this.buttonGuardar.Image = null;
                        }
                        else
                        {
                            reparacion.agregar();

                            if (this.actualizarDataGridEvento != null)
                            {
                                this.actualizarDataGridEvento();
                            }
                                    
                            MessageBox.Show("Reparacion guardada con éxito.", "Información");

                            //CAMBIAMOS ASPECTO DE BOTON GUARDAR
                            this.buttonGuardar.Text = "Terminar";
                            this.buttonGuardar.TextAlign = ContentAlignment.MiddleCenter;
                            this.buttonGuardar.Image = null;
                        }
                    }
                }
                catch
                {
                    if (!flagEditar)
                    {
                        reparacion.eliminar();
                    }
                    MessageBox.Show("Hubo un problema al guardar la reparación.", "Información");
                    return;
                }
            }
            else
            {
                MessageBox.Show("No se pueden guardar reparaciones en blanco.", "Error");
                return;
            }
        }

        private void buttonBuscarRepuesto_Click(object sender, EventArgs e)
        {
            frmBuscarRepuesto fbr = new frmBuscarRepuesto(colIdRepuestos);
            fbr.RepuestoEncontrado += new frmBuscarRepuesto.BuscarRepuestoHandler(fbr_RepuestoEncontrado);
            fbr.MdiParent = this.MdiParent;
            fbr.Show();
        }

        void fbr_RepuestoEncontrado(object sender, BuscarRepuestoEventArgs e)
        {
            repuesto = (RepuestoReparacion)e.Repuesto;
            this.textRepuesto.Text = ((RepuestoReparacion)e.Repuesto).Marca + " " + ((RepuestoReparacion)e.Repuesto).Modelo + ", " + ((RepuestoReparacion)e.Repuesto).DescripcionRepuesto;
        }

        private void buttonAgregarRepuesto_Click(object sender, EventArgs e)
        {
            //REPARACION COMUN
            if (!flagPresupuesto)
            {
                //REPUESTO QUE ESTA ALMACENADO
                if (repuesto.CantidadStock >= Convert.ToDouble(this.textCantidadRepuesto.Text))
                {
                    //AGREGACION NORMAL DE UN REPUESTO
                    repuesto.CantidadRequerida = Convert.ToDouble(this.textCantidadRepuesto.Text);
                    reparacion.DetalleRepuestos.Add(repuesto);

                    //BUSCAMOS EN LOS REPUESTOS ELIMINADOS EL REPUESTO A AGREGAR
                    for (int i = 0; i < reparacion.DetalleRepuestosEliminados.Count; i++)
                    {
                        if (repuesto.IdRepuesto == ((RepuestoReparacion)reparacion.DetalleRepuestosEliminados[i]).IdRepuesto)
                        {
                            reparacion.DetalleRepuestosEliminados.RemoveAt(i);
                        }
                    }

                    //MOSTRAMOS EN PANTALLA LOS REPUESTOS DE LA REPARACION
                    this.llenarDataGridRepuesto();
                }
                else
                {
                    MessageBox.Show("La cantidad requerida supera la cantidad en el depósito.\nCANTIDAD DISPONIBLE: " + repuesto.CantidadStock + ".", "Advertencia");
                    return;
                }
            }
            else
            {
                //PRESUPUESTO
                //AGREGACION NORMAL DE UN REPUESTO
                repuesto.CantidadRequerida = Convert.ToDouble(this.textCantidadRepuesto.Text);
                reparacion.DetalleRepuestos.Add(repuesto);

                //BUSCAMOS EN LOS REPUESTOS ELIMINADOS EL REPUESTO A AGREGAR
                for (int i = 0; i < reparacion.DetalleRepuestosEliminados.Count; i++)
                {
                    if (repuesto.IdRepuesto == ((RepuestoReparacion)reparacion.DetalleRepuestosEliminados[i]).IdRepuesto)
                    {
                        reparacion.DetalleRepuestosEliminados.RemoveAt(i);
                    }
                }

                //MOSTRAMOS EN PANTALLA LOS REPUESTOS DE LA REPARACION
                this.llenarDataGridRepuesto();
            }
            
        }

        //LLENAR DATAGRID REPUESTOS
        private void llenarDataGridRepuesto()
        {
            try
            {
                this.dataGridRepuesto.Rows.Clear();

                colIdRepuestos.RemoveRange(0, colIdRepuestos.Count);

                for (int i = 0; i < reparacion.DetalleRepuestos.Count; i++)
                {
                    this.dataGridRepuesto.Rows.Add();
                    colIdRepuestos.Add(((RepuestoReparacion)reparacion.DetalleRepuestos[i]).IdRepuesto);
                    if (!((RepuestoReparacion)reparacion.DetalleRepuestos[i]).FlagRepuestoManual)
                    {
                        this.dataGridRepuesto.Rows[i].Cells["idrepuesto"].Value = ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).IdRepuesto;
                    }
                    else
                    {
                        if (((RepuestoReparacion)reparacion.DetalleRepuestos[i]).IdRepuestoManual == null)
                        {
                            this.dataGridRepuesto.Rows[i].Cells["idrepuesto"].Value = ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).IdRepuesto;
                        }
                        else
                        {
                            this.dataGridRepuesto.Rows[i].Cells["idrepuesto"].Value = ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).IdRepuestoManual;
                        }
                    }

                    this.dataGridRepuesto.Rows[i].Cells["marca"].Value = ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).Marca;
                    this.dataGridRepuesto.Rows[i].Cells["modelo"].Value = ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).Modelo;
                    this.dataGridRepuesto.Rows[i].Cells["codigorepuesto"].Value = ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).CodigoRepuesto;
                    this.dataGridRepuesto.Rows[i].Cells["descripcionrepuesto"].Value = ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).DescripcionRepuesto;
                    this.dataGridRepuesto.Rows[i].Cells["cantidadrepuesto"].Value = ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).CantidadRequerida;
                    this.dataGridRepuesto.Rows[i].Cells["flagGenerico"].Value = Convert.ToInt32(((RepuestoReparacion)reparacion.DetalleRepuestos[i]).FlagRepuestoManual);

                    if (flagEditar)
                    {
                        if (((RepuestoReparacion)reparacion.DetalleRepuestos[i]).FlagRepuestoManual)
                        {
                            this.dataGridRepuesto.Rows[i].Cells["importerepuesto"].Value = ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).PrecioTotal;
                            this.dataGridRepuesto.Rows[i].Cells["preciorepuesto"].Value = ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).PrecioUnitario;
                        }
                        else
                        {
                            if (((RepuestoReparacion)reparacion.DetalleRepuestos[i]).PrecioTotalFacturado == 0)
                            {
                                this.dataGridRepuesto.Rows[i].Cells["importerepuesto"].Value = ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).PrecioTotal;
                                this.dataGridRepuesto.Rows[i].Cells["preciorepuesto"].Value = ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).PrecioUnitario;
                            }
                            else
                            {
                                this.dataGridRepuesto.Rows[i].Cells["importerepuesto"].Value = ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).PrecioTotalFacturado;
                                this.dataGridRepuesto.Rows[i].Cells["preciorepuesto"].Value = ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).PrecioUnitarioFacturado;
                                //REVISAR EL ORDEN DE ESTA LINEA PUEDE QUE VAYA AL PRINCIPIO
                                ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).PrecioUnitario = ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).PrecioUnitarioFacturado;
                            }
                        }
                    }
                    else
                    {
                        this.dataGridRepuesto.Rows[i].Cells["importerepuesto"].Value = ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).PrecioTotal;
                        this.dataGridRepuesto.Rows[i].Cells["preciorepuesto"].Value = ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).PrecioUnitario;
                    }


                }
                this.dataGridRepuesto.ClearSelection();
                this.inicializarCamposRepuesto();

                this.calcular();

            }
            catch
            {
                MessageBox.Show("Debe presionar enter para confirmar los cambios", "Error");
            }
            
        }


        //LLENAR DATAGRID REPUESTOS
        private void llenarDataGridGas()
        {
            this.dataGridGas.Rows.Clear();
            colIdGas.RemoveRange(0, colIdGas.Count);

            for (int i = 0; i < reparacion.DetalleCargas.Count; i++)
            {
                this.dataGridGas.Rows.Add();
                colIdGas.Add(((RepuestoReparacion)reparacion.DetalleCargas[i]).IdRepuesto);
                /*if (((RepuestoReparacion)reparacion.DetalleCargas[i]).IdRepuestoManual == null)
                {
                    this.dataGridGas.Rows[i].Cells["idrepuesto"].Value = ((RepuestoReparacion)reparacion.DetalleCargas[i]).IdRepuesto;
                }
                else
                {
                    this.dataGridGas.Rows[i].Cells["idrepuesto"].Value = ((RepuestoReparacion)reparacion.DetalleCargas[i]).IdRepuestoManual;
                }*/

                this.dataGridGas.Rows[i].Cells["idgas"].Value = ((RepuestoReparacion)reparacion.DetalleCargas[i]).IdRepuesto;
                this.dataGridGas.Rows[i].Cells["marcagas"].Value = ((RepuestoReparacion)reparacion.DetalleCargas[i]).Marca;
                this.dataGridGas.Rows[i].Cells["modelogas"].Value = ((RepuestoReparacion)reparacion.DetalleCargas[i]).Modelo;
                this.dataGridGas.Rows[i].Cells["codigogas"].Value = ((RepuestoReparacion)reparacion.DetalleCargas[i]).CodigoRepuesto;
                this.dataGridGas.Rows[i].Cells["descripciongas"].Value = ((RepuestoReparacion)reparacion.DetalleCargas[i]).DescripcionRepuesto;
                this.dataGridGas.Rows[i].Cells["cantidadgas"].Value = ((RepuestoReparacion)reparacion.DetalleCargas[i]).CantidadRequerida + " gr.";
                this.dataGridGas.Rows[i].Cells["preciogas"].Value = ((RepuestoReparacion)reparacion.DetalleCargas[i]).PrecioUnitario;
                this.dataGridGas.Rows[i].Cells["importegas"].Value = ((RepuestoReparacion)reparacion.DetalleCargas[i]).PrecioTotal;
            }
            this.dataGridGas.ClearSelection();
            this.inicializarCamposGas();

            this.calcular();
        }

        /// <summary>
        /// Anula y limpia los controles correspondientes 
        /// para que no se cometa un error al agregar un nuevo repuesto
        /// </summary>
        private void inicializarCamposRepuesto()
        {
            this.textCantidadRepuesto.ResetText(); this.textRepuesto.ResetText(); this.buttonAgregarRepuesto.Enabled = false;            
        }

        private void inicializarCamposGas()
        {
            this.textBoxCantidadGas.ResetText(); this.textBoxTipoGas.ResetText(); this.buttonAgregarRepuesto.Enabled = false;
        }

        private void textCantidadRepuesto_TextChanged(object sender, EventArgs e)
        {
            if (this.textCantidadRepuesto.Text != "")
            {
                this.buttonAgregarRepuesto.Enabled = true;
            }
            else
            {
                this.buttonAgregarRepuesto.Enabled = false;
            }
        }

        //DATAGRID TAREA
        private void dataGridDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.buttonEliminarTarea.Enabled = true;
        }
        //DATAGRID REPUESTO
        private void dataGridRepuesto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.buttonEliminarRepuesto.Enabled = true;

            if (e.ColumnIndex == 6)
            {
                for (int i = 0; i < reparacion.DetalleRepuestos.Count; i++)
                {
                    try
                    {
                        if (Convert.ToInt32(this.dataGridRepuesto.Rows[e.RowIndex].Cells["idrepuesto"].Value) == ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).IdRepuesto && ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).FlagRepuestoManual)
                        {
                            this.dataGridRepuesto.Rows[e.RowIndex].Cells["preciorepuesto"].Value = "";
                            break;
                        }
                    }
                    catch
                    {
                        if (this.dataGridRepuesto.Rows[e.RowIndex].Cells["idrepuesto"].Value.ToString().Contains("A") && ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).FlagRepuestoManual)
                        {
                            this.dataGridRepuesto.Rows[e.RowIndex].Cells["preciorepuesto"].Value = "";
                            break;
                        }
                    }
                }
            }          

        }
        
        //ELIMINAR REPUESTO
        private void buttonEliminarRepuesto_Click(object sender, EventArgs e)
        {
            if (this.dataGridRepuesto.Rows[this.dataGridRepuesto.CurrentCell.RowIndex].Cells["idrepuesto"].Value != null)
            {
                RepuestoReparacion objRepuestoLocal = new RepuestoReparacion();
                try
                {
                    objRepuestoLocal.IdRepuesto = Convert.ToInt32(this.dataGridRepuesto.Rows[this.dataGridRepuesto.CurrentCell.RowIndex].Cells["idrepuesto"].Value);
                    objRepuestoLocal.FlagRepuestoManual = Convert.ToBoolean(this.dataGridRepuesto.Rows[this.dataGridRepuesto.CurrentCell.RowIndex].Cells["flagGenerico"].Value);

                    for (int i = 0; i < reparacion.DetalleRepuestos.Count; i++)
                    {
                        if (objRepuestoLocal.IdRepuesto == ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).IdRepuesto)
                        {
                            if (objRepuestoLocal.FlagRepuestoManual == ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).FlagRepuestoManual)
                            {
                                reparacion.DetalleRepuestosEliminados.Add(((RepuestoReparacion)reparacion.DetalleRepuestos[i]));
                                reparacion.DetalleRepuestos.RemoveAt(i);
                                i = 0;
                            }
                        }
                    }
                }
                catch
                {
                    for (int i = 0; i < reparacion.DetalleRepuestos.Count; i++)
                    {
                        if (this.dataGridRepuesto.Rows[this.dataGridRepuesto.CurrentCell.RowIndex].Cells["idrepuesto"].Value.ToString() == ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).IdRepuestoManual)
                        {
                            reparacion.DetalleRepuestos.RemoveAt(i);
                            break;
                        }
                    }
                }

                this.llenarDataGridRepuesto();
                this.buttonEliminarRepuesto.Enabled = false;
            }
            else
            {
                return;
            }
        }

        //ELIMINAR TAREA
        private void buttonEliminarTarea_Click(object sender, EventArgs e)
        {
            TareaReparacion objTareaLocal = new TareaReparacion();
            try
            {
                objTareaLocal.IdTarea = Convert.ToInt32(this.dataGridDetalle.Rows[this.dataGridDetalle.CurrentCell.RowIndex].Cells["idtarea"].Value);
                objTareaLocal.FlagTareaManual = Convert.ToBoolean(this.dataGridDetalle.Rows[this.dataGridDetalle.CurrentCell.RowIndex].Cells["flagmanual"].Value);

                //Se maneja al reves porque es una celda invisible y no se puede modificar su valor, 0 es manual y 1 es tarea predefinida
                /*if (Convert.ToInt32(this.dataGridDetalle.Rows[this.dataGridDetalle.CurrentCell.RowIndex].Cells["flagmanual"].Value) == 0)
                {
                    objTareaLocal.FlagTareaManual = true;
                }*/

                for (int i = 0; i < reparacion.DetalleTarea.Count; i++)
                {
                    if (objTareaLocal.IdTarea == ((TareaReparacion)reparacion.DetalleTarea[i]).IdTarea)
                    {
                        if (objTareaLocal.FlagTareaManual == ((TareaReparacion)reparacion.DetalleTarea[i]).FlagTareaManual)
                        {
                            //TAREAS A ELIMINAR DE LA REPARACION
                            reparacion.DetalleTareaEliminados.Add(((TareaReparacion)reparacion.DetalleTarea[i]));// COLECCION USADA CUANDO EDITAMOS
                            reparacion.DetalleTarea.RemoveAt(i);
                            i = 0;
                        }
                    }
                }
            }
            catch
            {
                for (int i = 0; i < reparacion.DetalleTarea.Count; i++)
                {
                    if (this.dataGridDetalle.Rows[this.dataGridDetalle.CurrentCell.RowIndex].Cells["idtarea"].Value.ToString() == ((TareaReparacion)reparacion.DetalleTarea[i]).IdTareaManual)
                    {
                        //TAREAS A ELIMINAR DE LA REPARACION
                        reparacion.DetalleTarea.RemoveAt(i);
                        break;
                    }
                }
            }
            this.llenarDataGridTarea();
            this.buttonEliminarTarea.Enabled = false;
        }

        private void textCantidadTarea_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.comprobarNumero(this, e, textCostoTarea.Text);
            if (e.KeyChar == (char)13)
            {
                this.buttonAgregarTarea.PerformClick();
            }
        }

        //SOLO PERMITE EL INGRESO DE NUMEROS Y UNA COMA
        private void comprobarNumero(object sender, KeyPressEventArgs e, String cadena)
        {
            if (cadena.Contains('.'))
            {
                if (!char.IsDigit(e.KeyChar))
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
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '.' || e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
        }

        private void textCantidadRepuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.comprobarNumero(this, e, textCantidadRepuesto.Text);

            if (e.KeyChar == (char)13)
            {
                this.buttonAgregarRepuesto.PerformClick();
            }
        }

        //AGREGAR TAREAS A MANO
        private void dataGridDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridDetalle.Rows[e.RowIndex].Cells["preciotarea"].Value == null)
            {
                return;
            }
            else if (this.dataGridDetalle.Rows[e.RowIndex].Cells["idtarea"].Value == null)
            {
                this.dataGridDetalle.Rows[e.RowIndex].Cells["idtarea"].Value = "B" + this.contadorTareaManual;
                this.contadorTareaManual++;
            }
            else if (this.dataGridDetalle.Rows[e.RowIndex].Cells["preciotarea"].Value != null)
            {
                if (!((String)this.dataGridDetalle.Rows[e.RowIndex].Cells["idtarea"].Value.ToString()).Contains('B'))
                {
                    //La tarea a modificar no tiene B en su ID es decir que esta almacenada
                    //Puede ser manual o predefinida
                    for (int i = 0; i < reparacion.DetalleTarea.Count; i++)
                    {
                        //La tarea esta almacenada pero puede ser de las agregadas manual o de las predefinidas
                        if (!((TareaReparacion)reparacion.DetalleTarea[i]).FlagTareaManual && ((TareaReparacion)reparacion.DetalleTarea[i]).IdTarea == Convert.ToInt32(this.dataGridDetalle.Rows[e.RowIndex].Cells["idtarea"].Value.ToString()))
                        {
                            //Es tarea predefinida
                            ((TareaReparacion)reparacion.DetalleTarea[i]).Costo = Convert.ToDouble(this.dataGridDetalle.Rows[e.RowIndex].Cells["preciotarea"].Value.ToString());
                            this.llenarDataGridTarea();
                            return;

                        }
                        else if (((TareaReparacion)reparacion.DetalleTarea[i]).FlagTareaManual && ((TareaReparacion)reparacion.DetalleTarea[i]).IdTarea == Convert.ToInt32(this.dataGridDetalle.Rows[e.RowIndex].Cells["idtarea"].Value.ToString()))
                        {
                            //Es una tarea agregada manual que esta guardada pero se esta modificando el precio
                            ((TareaReparacion)reparacion.DetalleTarea[i]).Costo = Convert.ToDouble(this.dataGridDetalle.Rows[e.RowIndex].Cells["preciotarea"].Value.ToString());
                            this.llenarDataGridTarea();
                            return;
                        }
                    }

                }
                else
                {
                    for (int i = 0; i < reparacion.DetalleTarea.Count; i++)
                    {
                        //La tarea a modificar ha sido agregada en el momento que se esta haciendo la OT
                        //No esta almacenada
                        if (((TareaReparacion)reparacion.DetalleTarea[i]).IdTareaManual == this.dataGridDetalle.Rows[e.RowIndex].Cells["idtarea"].Value.ToString())
                        {
                            ((TareaReparacion)reparacion.DetalleTarea[i]).Costo = Convert.ToDouble(this.dataGridDetalle.Rows[e.RowIndex].Cells["preciotarea"].Value.ToString());
                            this.llenarDataGridTarea();
                            return;
                        }
                    }
                }
            }
            
            //COMPRUEBO QUE ES UNA TAREA INGRESADA MANUALMENTE
            if (((String)this.dataGridDetalle.Rows[e.RowIndex].Cells["idtarea"].Value.ToString()).Contains('B'))
            {
                TareaReparacion objTareaLocal = new TareaReparacion();
                objTareaLocal.IdTareaManual = this.dataGridDetalle.Rows[e.RowIndex].Cells["idtarea"].Value.ToString();
                objTareaLocal.DescripcionTarea = this.dataGridDetalle.Rows[e.RowIndex].Cells["descripciontarea"].Value.ToString().ToUpper();
                objTareaLocal.Costo = Convert.ToDouble(this.dataGridDetalle.Rows[e.RowIndex].Cells["preciotarea"].Value.ToString());
                objTareaLocal.FlagTareaManual = true;
                reparacion.DetalleTarea.Add(objTareaLocal);
                this.llenarDataGridTarea();
            }
            else
            {
                return;
            }

        }

        //AGREGAR REPUESTOS A MANO
        private void dataGridRepuesto_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int idrepuesto;

            if (this.dataGridRepuesto.Rows[e.RowIndex].Cells["preciorepuesto"].Value == null)
            {
                return;
            }
            else if (this.dataGridRepuesto.Rows[e.RowIndex].Cells["idrepuesto"].Value == null)
            {
                this.dataGridRepuesto.Rows[e.RowIndex].Cells["idrepuesto"].Value = "A"+this.contadorRepuestoManual;
                //this.dataGridRepuesto.Rows[e.RowIndex].Cells["idrepuesto"].Value = 0;
                this.contadorRepuestoManual++;
            }
            else if (this.dataGridRepuesto.Rows[e.RowIndex].Cells["importerepuesto"].Value != null)
            {

                for (int i = 0; i < reparacion.DetalleRepuestos.Count; i++)
                {
                    //VERIFICO SI ES NUMERO O CADENA EL idrepuesto Para cuando traigo un repuesto generico de la tabla
                    if (!int.TryParse(this.dataGridRepuesto.Rows[e.RowIndex].Cells["idrepuesto"].Value.ToString(), out idrepuesto))
                    {
                        //VERIFICO SI EL ID ES DE UN RESPUESTO MANUAL CONTIENE LA LETRA A
                        if (((String)this.dataGridRepuesto.Rows[e.RowIndex].Cells["idrepuesto"].Value).Contains('A'))
                        {
                            //BUSCO EN LA COLECCION EL REPUESTO 
                            if (((RepuestoReparacion)reparacion.DetalleRepuestos[i]).IdRepuestoManual == this.dataGridRepuesto.Rows[e.RowIndex].Cells["idrepuesto"].Value.ToString())
                            {
                                ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).CantidadRequeridaAnterior = ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).CantidadRequerida;
                                ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).CantidadRequerida = Convert.ToDouble(this.dataGridRepuesto.Rows[e.RowIndex].Cells["cantidadrepuesto"].Value);
                            }
                        }
                    }
                    //BUSCO EN LA COLECCION EL REPUESTO
                    else if (((RepuestoReparacion)reparacion.DetalleRepuestos[i]).IdRepuesto == Convert.ToInt32(this.dataGridRepuesto.Rows[e.RowIndex].Cells["idrepuesto"].Value))
                    {
                        //ES UN REPUESTO GENERICO
                        if (((RepuestoReparacion)reparacion.DetalleRepuestos[i]).FlagRepuestoManual)
                        {
                            ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).CantidadRequerida = Convert.ToDouble(this.dataGridRepuesto.Rows[e.RowIndex].Cells["cantidadrepuesto"].Value);
                            ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).PrecioUnitario = Convert.ToDouble(this.dataGridRepuesto.Rows[e.RowIndex].Cells["preciorepuesto"].Value);
                            
                        }
                        else if (((RepuestoReparacion)reparacion.DetalleRepuestos[i]).CantidadStock >= Convert.ToDouble(this.dataGridRepuesto.Rows[e.RowIndex].Cells["cantidadrepuesto"].Value))
                        {
                            ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).CantidadRequeridaAnterior = ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).CantidadRequerida;
                            ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).CantidadRequerida = Convert.ToDouble(this.dataGridRepuesto.Rows[e.RowIndex].Cells["cantidadrepuesto"].Value);
                            
                        }
                        //ES UN PRESUPUESTO NO TENGO EN CUENTA EL STOCK
                        else if (flagPresupuesto)
                        {
                            ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).CantidadRequeridaAnterior = ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).CantidadRequerida;
                            ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).CantidadRequerida = Convert.ToDouble(this.dataGridRepuesto.Rows[e.RowIndex].Cells["cantidadrepuesto"].Value);
                        }
                        else
                        {
                            MessageBox.Show("La cantidad requerida supera la cantidad en el depósito.\nCANTIDAD DISPONIBLE: " + ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).CantidadStock + ".", "Advertencia");
                            this.dataGridRepuesto.Rows[e.RowIndex].Cells["cantidadrepuesto"].Value = ((RepuestoReparacion)reparacion.DetalleRepuestos[i]).CantidadRequerida;
                        }
                    }
                }
                llenarDataGridRepuesto();
                return;
            }

            if (!int.TryParse(this.dataGridRepuesto.Rows[e.RowIndex].Cells["idrepuesto"].Value.ToString(), out idrepuesto))
            {
                //ES REPUESTO INGRESADO A MANO
                if (((String)this.dataGridRepuesto.Rows[e.RowIndex].Cells["idrepuesto"].Value).Contains('A'))
                {
                    //SE ENCUENTRA EN LA COLECCION??
                    /*for (int i = 0; i < reparacion.DetalleRepuestos.Count; i++)
                    {
                        if (((RepuestoReparacion)reparacion.DetalleRepuestos[i]).IdRepuestoManual == this.dataGridRepuesto.Rows[e.RowIndex].Cells["idrepuesto"].Value.ToString())
                        {
                            //this.llenarDataGridRepuesto();
                            return;
                        }
                    }*/

                    RepuestoReparacion objRepuestoLocal = new RepuestoReparacion();

                    objRepuestoLocal.IdRepuestoManual = this.dataGridRepuesto.Rows[e.RowIndex].Cells["idrepuesto"].Value.ToString().ToUpper();
                    
                    if (this.dataGridRepuesto.Rows[e.RowIndex].Cells["codigorepuesto"].Value == null)
                        objRepuestoLocal.CodigoRepuesto = "";
                    else
                        objRepuestoLocal.CodigoRepuesto = this.dataGridRepuesto.Rows[e.RowIndex].Cells["codigorepuesto"].Value.ToString().ToUpper();
                    objRepuestoLocal.Marca = "";
                    objRepuestoLocal.Modelo = "";
                    objRepuestoLocal.DescripcionRepuesto = this.dataGridRepuesto.Rows[e.RowIndex].Cells["descripcionrepuesto"].Value.ToString().ToUpper();
                    objRepuestoLocal.CantidadRequerida = Convert.ToDouble(this.dataGridRepuesto.Rows[e.RowIndex].Cells["cantidadrepuesto"].Value.ToString());
                    objRepuestoLocal.PrecioUnitario = Convert.ToDouble(this.dataGridRepuesto.Rows[e.RowIndex].Cells["preciorepuesto"].Value.ToString());
                    objRepuestoLocal.FlagRepuestoManual = true;

                    reparacion.DetalleRepuestos.Add(objRepuestoLocal);
                    this.llenarDataGridRepuesto();                    
                    
                    return;
                }
            }
            
        }
               

        private void textTotal_TextChanged(object sender, EventArgs e)
        {
            //ASPECTO ORIGINAL DEL BOTON GUARDAR
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        }

        private void textNombre_TextChanged(object sender, EventArgs e)
        {
            //ASPECTO ORIGINAL DEL BOTON GUARDAR
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        }

        private void textDominio_TextChanged(object sender, EventArgs e)
        {
            //ASPECTO ORIGINAL DEL BOTON GUARDAR
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //ASPECTO ORIGINAL DEL BOTON GUARDAR
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        }

        private void checkBoxPresupuesto_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxPresupuesto.Checked == true)
            {
                this.checkBoxPresupuesto.Text = "Presupuesto";
            }
            else
            {
                this.checkBoxPresupuesto.Text = "Orden de Trabajo";
            }

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

        private void frmAgregarEditarReparacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.buttonGuardar.Text != "Terminar")
            {
                if (MessageBox.Show("Si cierra esta ventana va a perder todos los cambios. ¿Desea continuar?", "Advertencia", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void buttonBuscarGas_Click(object sender, EventArgs e)
        {
            frmBuscarGas fbr = new frmBuscarGas(colIdGas);
            fbr.RepuestoEncontrado += new frmBuscarGas.BuscarRepuestoHandler(fbr_GasEncontrado);
            fbr.MdiParent = this.MdiParent;
            fbr.Show();
        }

        public void fbr_GasEncontrado(object sender, BuscarRepuestoEventArgs e)
        {
            repuestoGas = (RepuestoReparacion)e.Repuesto;
            this.textBoxTipoGas.Text = ((RepuestoReparacion)e.Repuesto).Marca + " " + ((RepuestoReparacion)e.Repuesto).Modelo + ", " + ((RepuestoReparacion)e.Repuesto).DescripcionRepuesto;
        }

        private void buttonAgregarGas_Click(object sender, EventArgs e)
        {
            //REPARACION COMUN
            if (!flagPresupuesto)
            {
                //REPUESTO QUE ESTA ALMACENADO
                if (repuestoGas.CantidadStock >= Convert.ToDouble(this.textBoxCantidadGas.Text))
                {
                    //AGREGACION NORMAL DE UN REPUESTO
                    repuestoGas.CantidadRequerida = Convert.ToDouble(this.textBoxCantidadGas.Text);
                    reparacion.DetalleCargas.Add(repuestoGas);

                    //BUSCAMOS EN LOS REPUESTOS ELIMINADOS EL REPUESTO A AGREGAR
                    for (int i = 0; i < reparacion.DetalleCargaEliminados.Count; i++)
                    {
                        if (repuestoGas.IdRepuesto == ((RepuestoReparacion)reparacion.DetalleCargaEliminados[i]).IdRepuesto)
                        {
                            reparacion.DetalleCargaEliminados.RemoveAt(i);
                        }
                    }

                    //MOSTRAMOS EN PANTALLA LOS REPUESTOS DE LA REPARACION
                    this.llenarDataGridGas();
                }
                else
                {
                    MessageBox.Show("La cantidad requerida supera la cantidad en el depósito.\nCANTIDAD DISPONIBLE: " + repuestoGas.CantidadStock + ".", "Advertencia");
                    return;
                }
            }
            else
            {
                //PRESUPUESTO
                //AGREGACION NORMAL DE UN REPUESTO
                repuestoGas.CantidadRequerida = Convert.ToDouble(this.textBoxCantidadGas.Text);
                reparacion.DetalleCargas.Add(repuestoGas);

                //BUSCAMOS EN LOS REPUESTOS ELIMINADOS EL REPUESTO A AGREGAR
                for (int i = 0; i < reparacion.DetalleCargaEliminados.Count; i++)
                {
                    if (repuestoGas.IdRepuesto == ((RepuestoReparacion)reparacion.DetalleCargaEliminados[i]).IdRepuesto)
                    {
                        reparacion.DetalleCargaEliminados.RemoveAt(i);
                    }
                }

                //MOSTRAMOS EN PANTALLA LOS REPUESTOS DE LA REPARACION
                this.llenarDataGridGas();
            }
        }

        private void buttonEliminarGas_Click(object sender, EventArgs e)
        {
            if (this.dataGridGas.Rows[this.dataGridGas.CurrentCell.RowIndex].Cells["idgas"].Value != null)
            {
                RepuestoReparacion objGasLocal = new RepuestoReparacion();
                objGasLocal.IdRepuesto = Convert.ToInt32(this.dataGridGas.Rows[this.dataGridGas.CurrentCell.RowIndex].Cells["idgas"].Value);
                for (int i = 0; i < reparacion.DetalleCargas.Count; i++)
                {
                    if (objGasLocal.IdRepuesto == ((RepuestoReparacion)reparacion.DetalleCargas[i]).IdRepuesto)
                    {
                        reparacion.DetalleCargaEliminados.Add(((RepuestoReparacion)reparacion.DetalleCargas[i]));
                        reparacion.DetalleCargas.RemoveAt(i);
                        i = 0;
                    }
                }

                this.llenarDataGridGas();
                this.buttonEliminarRepuesto.Enabled = false;
            }
            else
            {
                return;
            }
        }

        private void textBoxCantidadGas_TextChanged(object sender, EventArgs e)
        {
            if (this.textBoxCantidadGas.Text != "")
            {
                this.buttonAgregarGas.Enabled = true;
            }
            else
            {
                this.buttonAgregarGas.Enabled = false;
            }
        }

        private void dataGridGas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.buttonEliminarGas.Enabled = true;
        }

        private void buttonDeshacer_Click(object sender, EventArgs e)
        {
            this.loadForm();
        }

        private void textBoxCantidadGas_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.comprobarNumero(this, e, this.textBoxCantidadGas.Text);

            if (e.KeyChar == (char)13)
            {
                this.buttonAgregarGas.PerformClick();
            }
        }

        private void buttonNuevaTarea_Click(object sender, EventArgs e)
        {
            frmGestionTarea fgt = new frmGestionTarea(true);
            fgt.MdiParent = this.MdiParent;
            fgt.TareaEncontrada += new frmGestionTarea.BuscarTareaHandler(fbt_TareaEncontrada);
            fgt.Show();
        }

        private void frmAgregarEditarReparacion_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void dataGridRepuesto_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (this.dataGridRepuesto.CurrentCell.ColumnIndex == 3)
            {
                TextBox txt = e.Control as TextBox;

                if (txt != null)
                {
                    //txt.KeyPress -= new KeyEventHandler(dataGridRepuesto_KeyPress s);
                    txt.KeyPress += new KeyPressEventHandler(txt_KeyPress);
                }

            }
            else
            {
                TextBox txt = e.Control as TextBox;

                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(txt_KeyPress);
                }
            }
        }

        void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == (Char)Keys.Back)
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void dataGridRepuesto_KeyPress(object sender, KeyPressEventArgs e)
        {

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea duplicar la Orden de Trabajo?", "Duplicar", MessageBoxButtons.YesNo) == DialogResult.Yes && (flagPresupuesto == false))
            {
                try
                {
                    reparacion.FechaSistema = DateTime.Now;
                    reparacion.Fecha = DateTime.Now;
                    reparacion.Descripcion = this.textDescripcion.Text.ToUpper();
                    reparacion.ImporteTotal = Convert.ToDouble(this.textTotal.Text.Substring(1, this.textTotal.Text.Length - 1));
                    reparacion.CodigoReparacion = this.labelCodigoReparacion.Text;

                    reparacion.Estado = 0;

                    //Las sgtes lineas comentadas me verifican el stock de los repuestos
                    //REPUESTOS
                    /*foreach (object o in reparacion.DetalleRepuestos)
                    {
                        if (((RepuestoReparacion)o).IdRepuesto == ((RepuestoReparacion)o).IdRepuestoReparacion)
                        {
                            if (((RepuestoReparacion)o).FlagRepuestoManual)
                            {
                                ((RepuestoReparacion)o).CantidadStock = ((RepuestoReparacion)o).CantidadRequerida;
                            }
                            else
                                ((RepuestoReparacion)o).CantidadRequerida = ((RepuestoReparacion)o).CantidadStock;
                        }

                        if (((RepuestoReparacion)o).CantidadRequerida > ((RepuestoReparacion)o).CantidadStock)
                        {
                            MessageBox.Show("Repuesto: " + (RepuestoReparacion)o + "\nStock: " + ((RepuestoReparacion)o).CantidadStock + "\nCantidad Requerida: " + ((RepuestoReparacion)o).CantidadRequerida + "", "Error");
                            return;
                        }
                    }
                    //CARGAS DE GAS
                    foreach (object o in reparacion.DetalleCargas)
                    {
                        if (((RepuestoReparacion)o).IdRepuesto == ((RepuestoReparacion)o).IdRepuestoReparacion)
                        {
                            ((RepuestoReparacion)o).CantidadRequerida = ((RepuestoReparacion)o).CantidadStock;
                        }

                        if (((RepuestoReparacion)o).CantidadRequerida > ((RepuestoReparacion)o).CantidadStock)
                        {
                            MessageBox.Show("Gas: " + (RepuestoReparacion)o + "\nCantidad Disponible: " + ((RepuestoReparacion)o).CantidadStock + "\nCantidad Requerida: " + ((RepuestoReparacion)o).CantidadRequerida + "", "Error");
                            return;
                        }
                    }*/

                    reparacion.agregar();

                    if (this.actualizarDataGridEvento != null)
                    {
                        this.actualizarDataGridEvento();
                    }

                    MessageBox.Show("Orden de Trabajo duplicada con éxito. Nuevo código: " + reparacion.CodigoReparacion, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show("Error: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (flagPresupuesto)
            {
                MessageBox.Show("No se puede duplicar un presupuesto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (reparacion.Vehiculo.Id != 0)
            {
                frmAgregarEditarVehiculo faev = new frmAgregarEditarVehiculo(reparacion.Cliente.Id, this.textNombre.Text, true, reparacion.Vehiculo);
                faev.VehiculoEncontrado += new frmAgregarEditarVehiculo.BuscarVehiculoHandler(fbv_VehiculoEncontrado);
                faev.MdiParent = this.MdiParent;
                faev.Show();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un vehículo a editar","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void buttonEditarCliente_Click(object sender, EventArgs e)
        {
            if (reparacion.Cliente.Id != 0)
            {
                frmAgregarEditarCliente faec = new frmAgregarEditarCliente(reparacion.Cliente.Id);
                faec.ClienteEncontrado += new frmAgregarEditarCliente.BuscarClienteHandler(fbc_ClienteEncontrado);
                faec.MdiParent = this.MdiParent;
                faec.Show();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un cliente a editar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void dataGridRepuesto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int column = dataGridRepuesto.CurrentCell.ColumnIndex;
                int row = dataGridRepuesto.CurrentCell.RowIndex;
                if (column < dataGridRepuesto.ColumnCount)
                {
                    switch (column)
                    {
                        case 3:
                            this.dataGridRepuesto.CurrentCell = this.dataGridRepuesto["preciorepuesto", row];
                            break;
                        default:
                            this.dataGridRepuesto.CurrentCell = this.dataGridRepuesto["cantidadrepuesto", row];
                            break;
                    }

                }

            }
        } 

    }
}
