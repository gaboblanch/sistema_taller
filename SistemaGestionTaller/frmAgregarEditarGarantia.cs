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
    public partial class frmAgregarEditarGarantia : Form
    {
        private Garantia garantia;
        private TareaReparacion tarea;
        private RepuestoReparacion repuesto;
        private RepuestoReparacion repuestoGas;
        private double importeFinal;
        private bool flagEditar;
        private int idReparacion;
        private ArrayList colIdTareas;
        private ArrayList colIdRepuestos;
        private ArrayList colIdGas;
        private int contadorRepuestoManual;
        private int contadorTareaManual;

        //DELEGADO Y EVENTO PARA ACTUALIZAR GRILLA EN frmGestionCliente
        public delegate void actualizarDataGrid();
        public event actualizarDataGrid actualizarDataGridEvento;

        public frmAgregarEditarGarantia(bool flagEditar_p, int idReparacion_p)
        {
            InitializeComponent();
            this.flagEditar = flagEditar_p;
            this.idReparacion = idReparacion_p;
        }

        private void calcular()
        {
            importeFinal = 0;
            //DATAGRID TAREA
            foreach (DataGridViewRow row in this.dataGridDetalle.Rows)
            {
                if (row.Cells["preciotarea"].Value != null)
                {
                    importeFinal += (double)row.Cells["preciotarea"].Value;
                }
            }

            //DATAGRID REPUESTO
            foreach (DataGridViewRow row in this.dataGridRepuesto.Rows)
            {
                if (row.Cells["importerepuesto"].Value != null)
                {
                    importeFinal += Convert.ToDouble(row.Cells["importerepuesto"].Value);
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

            this.textTotal.Text = "$" + importeFinal.ToString("0.00");

            //ASPECTO ORIGINAL DEL BOTON GUARDAR
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        }

        private void llenarDataGridTarea()
        {
            this.buttonEliminarTarea.Enabled = false;
            this.buttonAgregarTarea.Enabled = false;
            try
            {
                this.dataGridDetalle.Rows.Clear();
                colIdTareas.RemoveRange(0, colIdTareas.Count);

                for (int i = 0; i < garantia.DetalleTareas.Count; i++)
                {
                    this.dataGridDetalle.Rows.Add();

                    //COMPROBAMOS SI ES TAREA MANUAL O DE LISTA
                    if (((TareaReparacion)garantia.DetalleTareas[i]).IdTareaManual != null)
                    {
                        //MANUAL
                        this.dataGridDetalle.Rows[i].Cells["idtarea"].Value = ((TareaReparacion)garantia.DetalleTareas[i]).IdTareaManual;
                    }
                    else
                    {
                        //LISTA
                        this.dataGridDetalle.Rows[i].Cells["idtarea"].Value = ((TareaReparacion)garantia.DetalleTareas[i]).IdTarea;
                        colIdTareas.Add(((TareaReparacion)garantia.DetalleTareas[i]).IdTarea);
                    }

                    this.dataGridDetalle.Rows[i].Cells["descripciontarea"].Value = ((TareaReparacion)garantia.DetalleTareas[i]).DescripcionTarea;
                    this.dataGridDetalle.Rows[i].Cells["preciotarea"].Value = ((TareaReparacion)garantia.DetalleTareas[i]).Costo;


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

        //LLENAR DATAGRID REPUESTOS
        private void llenarDataGridRepuesto()
        {
            this.buttonEliminarRepuesto.Enabled = false;
            this.buttonAgregarRepuesto.Enabled = false;

            try
            {
                this.dataGridRepuesto.Rows.Clear();
                colIdRepuestos.RemoveRange(0, colIdRepuestos.Count);

                for (int i = 0; i < garantia.DetalleRepuestos.Count; i++)
                {
                    this.dataGridRepuesto.Rows.Add();
                    colIdRepuestos.Add(((RepuestoReparacion)garantia.DetalleRepuestos[i]).IdRepuesto);
                    if (((RepuestoReparacion)garantia.DetalleRepuestos[i]).IdRepuestoManual == null)
                    {
                        this.dataGridRepuesto.Rows[i].Cells["idrepuesto"].Value = ((RepuestoReparacion)garantia.DetalleRepuestos[i]).IdRepuesto;
                    }
                    else
                    {
                        this.dataGridRepuesto.Rows[i].Cells["idrepuesto"].Value = ((RepuestoReparacion)garantia.DetalleRepuestos[i]).IdRepuestoManual;
                    }

                    this.dataGridRepuesto.Rows[i].Cells["marca"].Value = ((RepuestoReparacion)garantia.DetalleRepuestos[i]).Marca;
                    this.dataGridRepuesto.Rows[i].Cells["modelo"].Value = ((RepuestoReparacion)garantia.DetalleRepuestos[i]).Modelo;
                    this.dataGridRepuesto.Rows[i].Cells["codigorepuesto"].Value = ((RepuestoReparacion)garantia.DetalleRepuestos[i]).CodigoRepuesto;
                    this.dataGridRepuesto.Rows[i].Cells["descripcionrepuesto"].Value = ((RepuestoReparacion)garantia.DetalleRepuestos[i]).DescripcionRepuesto;
                    this.dataGridRepuesto.Rows[i].Cells["cantidadrepuesto"].Value = ((RepuestoReparacion)garantia.DetalleRepuestos[i]).CantidadRequerida;
                    this.dataGridRepuesto.Rows[i].Cells["importerepuesto"].Value = ((RepuestoReparacion)garantia.DetalleRepuestos[i]).CostoTotal;
                    this.dataGridRepuesto.Rows[i].Cells["preciorepuesto"].Value = ((RepuestoReparacion)garantia.DetalleRepuestos[i]).Costo;


                }
                this.dataGridRepuesto.ClearSelection();
                //this.inicializarCamposRepuesto();

                this.calcular();
            }
            catch
            {
                MessageBox.Show("Debe presionar enter para confirmar los cambios","Error");
            }
        }


        //LLENAR DATAGRID REPUESTOS
        private void llenarDataGridGas()
        {
            this.buttonEliminarGas.Enabled = false;
            this.buttonAgregarGas.Enabled = false;

            this.dataGridGas.Rows.Clear();
            colIdGas.RemoveRange(0, colIdGas.Count);

            for (int i = 0; i < garantia.DetalleCargas.Count; i++)
            {
                this.dataGridGas.Rows.Add();
                colIdGas.Add(((RepuestoReparacion)garantia.DetalleCargas[i]).IdRepuesto);
                /*if (((RepuestoReparacion)garantia.DetalleCargas[i]).IdRepuestoManual == null)
                {
                    this.dataGridGas.Rows[i].Cells["idrepuesto"].Value = ((RepuestoReparacion)garantia.DetalleCargas[i]).IdRepuesto;
                }
                else
                {
                    this.dataGridGas.Rows[i].Cells["idrepuesto"].Value = ((RepuestoReparacion)garantia.DetalleCargas[i]).IdRepuestoManual;
                }*/

                this.dataGridGas.Rows[i].Cells["idgas"].Value = ((RepuestoReparacion)garantia.DetalleCargas[i]).IdRepuesto;
                this.dataGridGas.Rows[i].Cells["marcagas"].Value = ((RepuestoReparacion)garantia.DetalleCargas[i]).Marca;
                this.dataGridGas.Rows[i].Cells["modelogas"].Value = ((RepuestoReparacion)garantia.DetalleCargas[i]).Modelo;
                this.dataGridGas.Rows[i].Cells["codigogas"].Value = ((RepuestoReparacion)garantia.DetalleCargas[i]).CodigoRepuesto;
                this.dataGridGas.Rows[i].Cells["descripciongas"].Value = ((RepuestoReparacion)garantia.DetalleCargas[i]).DescripcionRepuesto;
                this.dataGridGas.Rows[i].Cells["cantidadgas"].Value = ((RepuestoReparacion)garantia.DetalleCargas[i]).CantidadRequerida + " gr.";
                this.dataGridGas.Rows[i].Cells["preciogas"].Value = ((RepuestoReparacion)garantia.DetalleCargas[i]).Costo;
                this.dataGridGas.Rows[i].Cells["importegas"].Value = ((RepuestoReparacion)garantia.DetalleCargas[i]).CostoTotal;
            }
            this.dataGridGas.ClearSelection();
            //this.inicializarCamposGas();

            this.calcular();
        }

        private void buttonBuscarCliente_Click(object sender, EventArgs e)
        {
            this.textModelo.Text = "";
            this.textDominio.Text = "";
            garantia.Reparacion.Vehiculo.Id = 0;

            frmBuscarCliente fbc = new frmBuscarCliente();
            fbc.ClienteEncontrado += new frmBuscarCliente.BuscarClienteHandler(fbc_ClienteEncontrado);
            fbc.MdiParent = this.MdiParent;
            fbc.Show();
        }

        void fbc_ClienteEncontrado(object sender, BuscarClienteEventArgs e)
        {
            garantia.Reparacion.Cliente = (Cliente)e.Cliente;
            this.textNombre.Text = garantia.Reparacion.Cliente.NombreRazonSocial;
        }

        private void buttonNuevoCliente_Click(object sender, EventArgs e)
        {
            frmAgregarEditarCliente faec = new frmAgregarEditarCliente(true);
            faec.ClienteEncontrado += new frmAgregarEditarCliente.BuscarClienteHandler(fbc_ClienteEncontrado);
            faec.MdiParent = this.MdiParent;
            faec.Show();
        }

        private void formLoad()
        {
            garantia = new Garantia();
            colIdGas = new ArrayList();
            colIdRepuestos = new ArrayList();
            colIdTareas = new ArrayList();

            if (flagEditar)
            {
                garantia.Id = this.idReparacion;
                garantia.getGarantia();
                garantia.Reparacion.getReparacion();
                this.llenarDataGridGas();
                this.llenarDataGridRepuesto();
                this.llenarDataGridTarea();

                //CAMBIAMOS ASPECTO DE BOTON GUARDAR
                this.buttonGuardar.Text = "Terminar";
                this.buttonGuardar.TextAlign = ContentAlignment.MiddleCenter;
                this.buttonGuardar.Image = null;
            }
            else
            {
                garantia.getGarantia();
                garantia.Reparacion.IdReparacion = this.idReparacion;
                garantia.Reparacion.getReparacion();
            }


            //Cliente
            this.textNombre.Text = garantia.Reparacion.Cliente.NombreRazonSocial;

            //Vehiculo
            this.textModelo.Text = garantia.Reparacion.Vehiculo.Modelo;
            this.textDominio.Text = garantia.Reparacion.Vehiculo.Dominio;
            this.textBoxCapacidad.Text = garantia.Reparacion.Vehiculo.CapacidadCarga.ToString().Insert(garantia.Reparacion.Vehiculo.CapacidadCarga.ToString().Length, " gr.");
        }

        private void frmAgregarEditarGarantia_Load(object sender, EventArgs e)
        {
            this.formLoad();
        }

        private void buttonBuscarVehiculo_Click(object sender, EventArgs e)
        {
            if (garantia.Reparacion.Cliente.Id != 0)
            {
                frmBuscarVehiculo fbv = new frmBuscarVehiculo(garantia.Reparacion.Cliente.Id);
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
            garantia.Reparacion.Vehiculo = (Vehiculo)e.Vehiculo;

            this.textDominio.Text = garantia.Reparacion.Vehiculo.Dominio;
            this.textModelo.Text = garantia.Reparacion.Vehiculo.Marca + " / " + garantia.Reparacion.Vehiculo.Modelo;

            this.textBoxCapacidad.Text = garantia.Reparacion.Vehiculo.CapacidadCarga.ToString().Insert(garantia.Reparacion.Vehiculo.CapacidadCarga.ToString().Length, " gr.");
        }

        private void buttonBuscarTarea_Click(object sender, EventArgs e)
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

        private void buttonNuevaTarea_Click(object sender, EventArgs e)
        {
            frmGestionTarea fgt = new frmGestionTarea(true);
            fgt.MdiParent = this.MdiParent;
            fgt.TareaEncontrada += new frmGestionTarea.BuscarTareaHandler(fbt_TareaEncontrada);
            fgt.Show();
        }

        private void buttonAgregarTarea_Click(object sender, EventArgs e)
        {
            tarea.Costo = Convert.ToDouble(this.textCostoTarea.Text);

            garantia.DetalleTareas.Add(tarea);

            //BUSCAMOS EN LAS TAREAS ELIMINADAS LA TAREA A AGREGAR
            for (int i = 0; i < garantia.DetalleTareasEliminadas.Count; i++)
            {
                if (tarea.IdTarea == ((TareaReparacion)garantia.DetalleTareasEliminadas[i]).IdTarea)
                {
                    garantia.DetalleTareasEliminadas.RemoveAt(i);
                }
            }

            this.llenarDataGridTarea();

            //ASPECTO ORIGINAL DEL BOTON GUARDAR
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        }

        private void buttonEliminarTarea_Click(object sender, EventArgs e)
        {
            TareaReparacion objTareaLocal = new TareaReparacion();
            objTareaLocal.IdTarea = Convert.ToInt32(this.dataGridDetalle.Rows[this.dataGridDetalle.CurrentCell.RowIndex].Cells["idtarea"].Value);
            for (int i = 0; i < garantia.DetalleTareas.Count; i++)
            {
                if (objTareaLocal.IdTarea == ((TareaReparacion)garantia.DetalleTareas[i]).IdTarea)
                {
                    //TAREAS A ELIMINAR DE LA REPARACION
                    garantia.DetalleTareasEliminadas.Add(((TareaReparacion)garantia.DetalleTareas[i]));// COLECCION USADA CUANDO EDITAMOS
                    garantia.DetalleTareas.RemoveAt(i);
                    i = 0;
                }
            }

            this.llenarDataGridTarea();
            this.buttonEliminarTarea.Enabled = false;

            //ASPECTO ORIGINAL DEL BOTON GUARDAR
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        }

        private void buttonAgregarRepuesto_Click(object sender, EventArgs e)
        {
            if (repuesto.CantidadStock >= Convert.ToDouble(this.textCantidadRepuesto.Text))
            {
                //AGREGACION NORMAL DE UN REPUESTO
                repuesto.CantidadRequerida = Convert.ToDouble(this.textCantidadRepuesto.Text);
                garantia.DetalleRepuestos.Add(repuesto);

                //BUSCAMOS EN LOS REPUESTOS ELIMINADOS EL REPUESTO A AGREGAR
                for (int i = 0; i < garantia.DetalleRepuestosEliminados.Count; i++)
                {
                    if (repuesto.IdRepuesto == ((RepuestoReparacion)garantia.DetalleRepuestosEliminados[i]).IdRepuesto)
                    {
                        garantia.DetalleRepuestosEliminados.RemoveAt(i);
                    }
                }

                //MOSTRAMOS EN PANTALLA LOS REPUESTOS DE LA REPARACION
                this.llenarDataGridRepuesto();
                this.inicializarCamposRepuesto();

                //ASPECTO ORIGINAL DEL BOTON GUARDAR
                this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
                this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.buttonGuardar.Text = "Guardar";
                this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            }
            else
            {
                MessageBox.Show("La cantidad requerida supera la cantidad en el depósito.\nCANTIDAD DISPONIBLE: " + repuesto.CantidadStock + ".", "Advertencia");
                return;
            }
        }

        private void buttonEliminarRepuesto_Click(object sender, EventArgs e)
        {
            if (this.dataGridRepuesto.Rows[this.dataGridRepuesto.CurrentCell.RowIndex].Cells["idrepuesto"].Value != null)
            {
                RepuestoReparacion objRepuestoLocal = new RepuestoReparacion();
                objRepuestoLocal.IdRepuesto = Convert.ToInt32(this.dataGridRepuesto.Rows[this.dataGridRepuesto.CurrentCell.RowIndex].Cells["idrepuesto"].Value);

                if (this.dataGridRepuesto.Rows[this.dataGridRepuesto.CurrentCell.RowIndex].Cells["codigorepuesto"].Value.ToString() == "")
                {
                    objRepuestoLocal.FlagRepuestoManual = true;
                }

                for (int i = 0; i < garantia.DetalleRepuestos.Count; i++)
                {
                    if (objRepuestoLocal.IdRepuesto == ((RepuestoReparacion)garantia.DetalleRepuestos[i]).IdRepuesto)
                    {
                        if (objRepuestoLocal.FlagRepuestoManual == ((RepuestoReparacion)garantia.DetalleRepuestos[i]).FlagRepuestoManual)
                        {
                            garantia.DetalleRepuestosEliminados.Add(((RepuestoReparacion)garantia.DetalleRepuestos[i]));
                            garantia.DetalleRepuestos.RemoveAt(i);
                            i = 0;
                        }
                    }
                }

                this.llenarDataGridRepuesto();
                this.buttonEliminarRepuesto.Enabled = false;

                //ASPECTO ORIGINAL DEL BOTON GUARDAR
                this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
                this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.buttonGuardar.Text = "Guardar";
                this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            }
            else
            {
                return;
            }
        }

        private void buttonAgregarGas_Click(object sender, EventArgs e)
        {
            //REPUESTO QUE ESTA ALMACENADO
            if (repuestoGas.CantidadStock >= Convert.ToDouble(this.textBoxCantidadGas.Text))
            {
                //AGREGACION NORMAL DE UN REPUESTO
                repuestoGas.CantidadRequerida = Convert.ToDouble(this.textBoxCantidadGas.Text);
                garantia.DetalleCargas.Add(repuestoGas);

                //BUSCAMOS EN LOS REPUESTOS ELIMINADOS EL REPUESTO A AGREGAR
                for (int i = 0; i < garantia.DetalleCargasEliminadas.Count; i++)
                {
                    if (repuestoGas.IdRepuesto == ((RepuestoReparacion)garantia.DetalleCargasEliminadas[i]).IdRepuesto)
                    {
                        garantia.DetalleCargasEliminadas.RemoveAt(i);
                    }
                }

                //MOSTRAMOS EN PANTALLA LOS REPUESTOS DE LA REPARACION
                this.llenarDataGridGas();
                this.inicializarCamposGas();

                //ASPECTO ORIGINAL DEL BOTON GUARDAR
                this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
                this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.buttonGuardar.Text = "Guardar";
                this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            }
            else
            {
                MessageBox.Show("La cantidad requerida supera la cantidad en el depósito.\nCANTIDAD DISPONIBLE: " + repuestoGas.CantidadStock + ".", "Advertencia");
                return;
            }
        }

        private void buttonEliminarGas_Click(object sender, EventArgs e)
        {
            if (this.dataGridGas.Rows[this.dataGridGas.CurrentCell.RowIndex].Cells["idgas"].Value != null)
            {
                RepuestoReparacion objGasLocal = new RepuestoReparacion();
                objGasLocal.IdRepuesto = Convert.ToInt32(this.dataGridGas.Rows[this.dataGridGas.CurrentCell.RowIndex].Cells["idgas"].Value);
                for (int i = 0; i < garantia.DetalleCargas.Count; i++)
                {
                    if (objGasLocal.IdRepuesto == ((RepuestoReparacion)garantia.DetalleCargas[i]).IdRepuesto)
                    {
                        garantia.DetalleCargasEliminadas.Add(((RepuestoReparacion)garantia.DetalleCargas[i]));
                        garantia.DetalleCargas.RemoveAt(i);
                        i = 0;
                    }
                }

                this.llenarDataGridGas();
                this.buttonEliminarRepuesto.Enabled = false;

                //ASPECTO ORIGINAL DEL BOTON GUARDAR
                this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
                this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.buttonGuardar.Text = "Guardar";
                this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            }
            else
            {
                return;
            }
        }

        private void dataGridRepuesto_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int idrepuesto;

            if (this.dataGridRepuesto.Rows[e.RowIndex].Cells["preciorepuesto"].Value == null)
            {
                return;
            }
            else if (this.dataGridRepuesto.Rows[e.RowIndex].Cells["idrepuesto"].Value == null)
            {
                this.dataGridRepuesto.Rows[e.RowIndex].Cells["idrepuesto"].Value = "A" + this.contadorRepuestoManual;
                //this.dataGridRepuesto.Rows[e.RowIndex].Cells["idrepuesto"].Value = 0;
                this.contadorRepuestoManual++;
            }

            for (int i = 0; i < garantia.DetalleRepuestos.Count; i++)
            {
                //VERIFICO SI ES NUMERO O CADENA EL idrepuesto
                if (!int.TryParse(this.dataGridRepuesto.Rows[e.RowIndex].Cells["idrepuesto"].Value.ToString(), out idrepuesto))
                {
                    //VERIFICO SI EL ID ES DE UN RESPUESTO MANUAL CONTIENE LA LETRA A
                    if (((String)this.dataGridRepuesto.Rows[e.RowIndex].Cells["idrepuesto"].Value).Contains('A'))
                    {
                        //BUSCO EN LA COLECCION EL REPUESTO 
                        if (((RepuestoReparacion)garantia.DetalleRepuestos[i]).IdRepuestoManual == this.dataGridRepuesto.Rows[e.RowIndex].Cells["idrepuesto"].Value.ToString())
                        {
                            ((RepuestoReparacion)garantia.DetalleRepuestos[i]).CantidadRequeridaAnterior = ((RepuestoReparacion)garantia.DetalleRepuestos[i]).CantidadRequerida;
                            ((RepuestoReparacion)garantia.DetalleRepuestos[i]).CantidadRequerida = Convert.ToDouble(this.dataGridRepuesto.Rows[e.RowIndex].Cells["cantidadrepuesto"].Value);

                        }
                    }
                }
                //BUSCO EN LA COLECCION EL REPUESTO
                else if (((RepuestoReparacion)garantia.DetalleRepuestos[i]).IdRepuesto == Convert.ToInt32(this.dataGridRepuesto.Rows[e.RowIndex].Cells["idrepuesto"].Value))
                {
                    //ES UN REPUESTO GENERICO
                    if (((RepuestoReparacion)garantia.DetalleRepuestos[i]).FlagRepuestoManual)
                    {
                        ((RepuestoReparacion)garantia.DetalleRepuestos[i]).CantidadRequerida = Convert.ToDouble(this.dataGridRepuesto.Rows[e.RowIndex].Cells["cantidadrepuesto"].Value);
                    }
                    else if (((RepuestoReparacion)garantia.DetalleRepuestos[i]).CantidadStock >= Convert.ToDouble(this.dataGridRepuesto.Rows[e.RowIndex].Cells["cantidadrepuesto"].Value))
                    {
                        ((RepuestoReparacion)garantia.DetalleRepuestos[i]).CantidadRequeridaAnterior = ((RepuestoReparacion)garantia.DetalleRepuestos[i]).CantidadRequerida;
                        ((RepuestoReparacion)garantia.DetalleRepuestos[i]).CantidadRequerida = Convert.ToDouble(this.dataGridRepuesto.Rows[e.RowIndex].Cells["cantidadrepuesto"].Value);
                    }
                    else
                    {
                        MessageBox.Show("La cantidad requerida supera la cantidad en el depósito.\nCANTIDAD DISPONIBLE: " + ((RepuestoReparacion)garantia.DetalleRepuestos[i]).CantidadStock + ".", "Advertencia");
                        this.dataGridRepuesto.Rows[e.RowIndex].Cells["cantidadrepuesto"].Value = ((RepuestoReparacion)garantia.DetalleRepuestos[i]).CantidadRequerida;
                    }
                }
            }

            if (!int.TryParse(this.dataGridRepuesto.Rows[e.RowIndex].Cells["idrepuesto"].Value.ToString(), out idrepuesto))
            {
                //ES REPUESTO INGRESADO A MANO
                if (((String)this.dataGridRepuesto.Rows[e.RowIndex].Cells["idrepuesto"].Value).Contains('A'))
                {
                    //SE ENCUENTRA EN LA COLECCION??
                    for (int i = 0; i < garantia.DetalleRepuestos.Count; i++)
                    {
                        if (((RepuestoReparacion)garantia.DetalleRepuestos[i]).IdRepuestoManual == this.dataGridRepuesto.Rows[e.RowIndex].Cells["idrepuesto"].Value.ToString())
                        {
                            //this.llenarDataGridRepuesto();
                            return;
                        }
                    }

                    RepuestoReparacion objRepuestoLocal = new RepuestoReparacion();

                    objRepuestoLocal.IdRepuestoManual = this.dataGridRepuesto.Rows[e.RowIndex].Cells["idrepuesto"].Value.ToString().ToUpper();
                    /*objRepuestoLocal.Marca = this.dataGridRepuesto.Rows[e.RowIndex].Cells["marca"].Value.ToString().ToUpper();
                    objRepuestoLocal.Modelo = this.dataGridRepuesto.Rows[e.RowIndex].Cells["modelo"].Value.ToString().ToUpper();*/
                    if (this.dataGridRepuesto.Rows[e.RowIndex].Cells["codigorepuesto"].Value == null)
                        objRepuestoLocal.CodigoRepuesto = "";
                    else
                        objRepuestoLocal.CodigoRepuesto = this.dataGridRepuesto.Rows[e.RowIndex].Cells["codigorepuesto"].Value.ToString().ToUpper();
                    objRepuestoLocal.Marca = "";
                    objRepuestoLocal.Modelo = "";
                    objRepuestoLocal.DescripcionRepuesto = this.dataGridRepuesto.Rows[e.RowIndex].Cells["descripcionrepuesto"].Value.ToString().ToUpper();
                    objRepuestoLocal.CantidadRequerida = Convert.ToDouble(this.dataGridRepuesto.Rows[e.RowIndex].Cells["cantidadrepuesto"].Value.ToString());
                    objRepuestoLocal.Costo = Convert.ToDouble(this.dataGridRepuesto.Rows[e.RowIndex].Cells["preciorepuesto"].Value.ToString());
                    objRepuestoLocal.FlagRepuestoManual = true;

                    garantia.DetalleRepuestos.Add(objRepuestoLocal);
                }
            }
            this.llenarDataGridRepuesto();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (this.buttonGuardar.Text == "Terminar")
            {
                this.Close();
                return;
            }

            garantia.Descripcion = this.textDescripcion.Text;
            garantia.FechaSistema = DateTime.Now;
            garantia.FechaGarantia = this.dateTimePicker1.Value;
            garantia.Importe = Convert.ToDouble(this.textTotal.Text.Replace("$", ""));

            if(flagEditar)
            {
                if (garantia.DetalleTareas.Count != 0 || garantia.DetalleRepuestos.Count != 0 || garantia.DetalleCargas.Count != 0)
                {
                    try
                    {
                        garantia.actualizar();
                        if (this.actualizarDataGridEvento != null)
                            this.actualizarDataGridEvento();

                        //CAMBIAMOS ASPECTO DE BOTON GUARDAR
                        this.buttonGuardar.Text = "Terminar";
                        this.buttonGuardar.TextAlign = ContentAlignment.MiddleCenter;
                        this.buttonGuardar.Image = null;
                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    {
                        MessageBox.Show("Error: " + ex, "Error");
                    }
                }
                else
                {
                    MessageBox.Show("No se pueden guardar garantias en blanco.", "Error");
                    return;
                }
            }
            else
            {
                if (garantia.DetalleTareas.Count != 0 || garantia.DetalleRepuestos.Count != 0 || garantia.DetalleCargas.Count != 0)
                {
                    try
                    {
                        garantia.agregar();
                        if (this.actualizarDataGridEvento != null)
                            this.actualizarDataGridEvento();

                        //CAMBIAMOS ASPECTO DE BOTON GUARDAR
                        this.buttonGuardar.Text = "Terminar";
                        this.buttonGuardar.TextAlign = ContentAlignment.MiddleCenter;
                        this.buttonGuardar.Image = null;
                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    {
                        MessageBox.Show("Error: " + ex, "Error");
                    }
                }
                else
                {
                    MessageBox.Show("No se pueden guardar garantias en blanco.", "Error");
                    return;
                }
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

        private void textCostoTarea_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.comprobarNumero(this, e, textCostoTarea.Text);
            if (e.KeyChar == (char)13)
            {
                this.buttonAgregarTarea.PerformClick();
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

            for (int i = 0; i < garantia.DetalleTareas.Count; i++)
            {
                if (((TareaReparacion)garantia.DetalleTareas[i]).IdTareaManual == this.dataGridDetalle.Rows[e.RowIndex].Cells["idtarea"].Value.ToString())
                {
                    ((TareaReparacion)garantia.DetalleTareas[i]).Costo = Convert.ToDouble(this.dataGridDetalle.Rows[e.RowIndex].Cells["preciotarea"].Value.ToString());
                    this.llenarDataGridTarea();
                    return;
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
                garantia.DetalleTareas.Add(objTareaLocal);
                this.llenarDataGridTarea();
            }
            else
            {
                return;
            }
        }

        private void inicializarCamposRepuesto()
        {
            this.textCantidadRepuesto.ResetText(); this.textRepuesto.ResetText(); this.buttonAgregarRepuesto.Enabled = false;
        }

        private void inicializarCamposGas()
        {
            this.textBoxCantidadGas.ResetText(); this.textBoxTipoGas.ResetText(); this.buttonAgregarRepuesto.Enabled = false;
        }

        private void inicializarCamposTarea()
        {
            this.textCostoTarea.ResetText(); this.textTarea.ResetText(); this.buttonAgregarTarea.Enabled = false;

        }

        private void textDescripcion_TextChanged(object sender, EventArgs e)
        {
            //ASPECTO ORIGINAL DEL BOTON GUARDAR
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        }

        private void buttonDeshacer_Click(object sender, EventArgs e)
        {
            this.formLoad();
        }

        private void frmAgregarEditarGarantia_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void frmAgregarEditarGarantia_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.buttonGuardar.Text != "Terminar")
            {
                if (MessageBox.Show("Si cierra esta ventana va a perder todos los cambios. ¿Desea continuar?", "Advertencia", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void textCostoTarea_TextChanged(object sender, EventArgs e)
        {
            if (this.textCostoTarea.Text != "")
                this.buttonAgregarTarea.Enabled = true;
            else
                this.buttonAgregarTarea.Enabled = false;
        }

        private void textCantidadRepuesto_TextChanged(object sender, EventArgs e)
        {
            if (this.textCantidadRepuesto.Text != "")
                this.buttonAgregarRepuesto.Enabled = true;
            else
                this.buttonAgregarRepuesto.Enabled = false;
        }

        private void textBoxCantidadGas_TextChanged(object sender, EventArgs e)
        {
            if (this.textBoxCantidadGas.Text != "")
                this.buttonAgregarGas.Enabled = true;
            else
                this.buttonAgregarGas.Enabled = false;
        }

        private void dataGridDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.buttonEliminarTarea.Enabled = true;
        }

        private void dataGridRepuesto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.buttonEliminarRepuesto.Enabled = true;
        }

        private void dataGridGas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.buttonEliminarGas.Enabled = true;
        }

        private void dataGridRepuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*this.comprobarNumero(this, e, this.textBoxCantidadGas.Text);

            if (e.KeyChar == (char)13)
            {
                this.buttonAgregarGas.PerformClick();
            }*/
        }
    }
}
