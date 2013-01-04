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
    public partial class frmAgregarEditarVentaRepuesto : Form
    {
        private VentaRepuesto ventarepuesto;
        private RepuestoReparacion repuesto;
        private double importeFinal;
        private bool flagEditar;
        private bool flagGestor;
        private int idVentaRepuesto;
        private ArrayList colIdRepuestos;

        //DELEGADO Y EVENTO PARA ACTUALIZAR GRILLA EN frmGestionReparacion
        public delegate void actualizarDataGrid();
        public event actualizarDataGrid actualizarDataGridEvento;

        //EDITAR REPUESTO
        public frmAgregarEditarVentaRepuesto(int idVentaRepuesto_p)
        {
            InitializeComponent();
            idVentaRepuesto = idVentaRepuesto_p;
            flagEditar = true;
        }

        public frmAgregarEditarVentaRepuesto(bool flagGestor_p)
        {
            InitializeComponent();
            this.flagGestor = flagGestor_p;
        }

        //LLENAR DATAGRID REPUESTOS
        private void llenarDataGridRepuesto()
        {
            this.buttonEliminarRepuesto.Enabled = false;
            this.buttonAgregarRepuesto.Enabled = false;

            this.dataGridRepuesto.Rows.Clear();
            colIdRepuestos.RemoveRange(0, colIdRepuestos.Count);

            for (int i = 0; i < ventarepuesto.DetalleRepuestos.Count; i++)
            {
                this.dataGridRepuesto.Rows.Add();
                colIdRepuestos.Add(((RepuestoReparacion)ventarepuesto.DetalleRepuestos[i]).IdRepuesto);
                this.dataGridRepuesto.Rows[i].Cells["idrepuesto"].Value = ((RepuestoReparacion)ventarepuesto.DetalleRepuestos[i]).IdRepuesto;
                this.dataGridRepuesto.Rows[i].Cells["marca"].Value = ((RepuestoReparacion)ventarepuesto.DetalleRepuestos[i]).Marca;
                this.dataGridRepuesto.Rows[i].Cells["modelo"].Value = ((RepuestoReparacion)ventarepuesto.DetalleRepuestos[i]).Modelo;
                this.dataGridRepuesto.Rows[i].Cells["descripcionrepuesto"].Value = ((RepuestoReparacion)ventarepuesto.DetalleRepuestos[i]).DescripcionRepuesto;
                this.dataGridRepuesto.Rows[i].Cells["cantidadrepuesto"].Value = ((RepuestoReparacion)ventarepuesto.DetalleRepuestos[i]).CantidadRequerida;
                this.dataGridRepuesto.Rows[i].Cells["preciorepuesto"].Value = ((RepuestoReparacion)ventarepuesto.DetalleRepuestos[i]).PrecioTotal;

                this.dataGridRepuesto.ClearSelection();
            }
            this.inicializarCamposRepuesto();

            this.calcular();
        }

        private void inicializarCamposRepuesto()
        {
            this.textCantidadRepuesto.ResetText(); this.textRepuesto.ResetText();
        }

        private void calcular()
        {
            importeFinal = 0;

            //DATAGRID REPUESTO
            foreach (DataGridViewRow row in this.dataGridRepuesto.Rows)
            {
                importeFinal += (double)row.Cells["preciorepuesto"].Value;
            }

            this.textTotal.Text = importeFinal.ToString("0.00");
        }


        private void buttonBuscarCliente_Click(object sender, EventArgs e)
        {
            frmBuscarCliente fbc = new frmBuscarCliente();
            fbc.ClienteEncontrado += new frmBuscarCliente.BuscarClienteHandler(fbc_ClienteEncontrado);
            fbc.MdiParent = this.MdiParent;
            fbc.Show();
        }

        private void buttonNuevoCliente_Click(object sender, EventArgs e)
        {
            frmAgregarEditarCliente faec = new frmAgregarEditarCliente(true);
            faec.ClienteEncontrado += new frmAgregarEditarCliente.BuscarClienteHandler(fbc_ClienteEncontrado);
            faec.MdiParent = this.MdiParent;
            faec.Show();
        }

        void fbc_ClienteEncontrado(object sender, BuscarClienteEventArgs e)
        {
            ventarepuesto.Cliente.Id = ((Cliente)e.Cliente).Id;
            ventarepuesto.Cliente.NombreRazonSocial = ((Cliente)e.Cliente).NombreRazonSocial;

            this.textNombre.Text = ((Cliente)e.Cliente).NombreRazonSocial; ;
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
            if (repuesto.CantidadStock >= Convert.ToDouble(this.textCantidadRepuesto.Text))
            {
                //AGREGACION NORMAL DE UN REPUESTO
                repuesto.CantidadRequerida = Convert.ToDouble(this.textCantidadRepuesto.Text);
                ventarepuesto.DetalleRepuestos.Add(repuesto);

                //BUSCAMOS EN LOS REPUESTOS ELIMINADOS EL REPUESTO A AGREGAR
                for (int i = 0; i < ventarepuesto.DetalleRepuestosEliminados.Count; i++)
                {
                    if (repuesto.IdRepuesto == ((RepuestoReparacion)ventarepuesto.DetalleRepuestosEliminados[i]).IdRepuesto)
                    {
                        ventarepuesto.DetalleRepuestosEliminados.RemoveAt(i);
                    }
                }

                //MOSTRAMOS EN PANTALLA LOS REPUESTOS DE LA REPARACION
                this.llenarDataGridRepuesto();
            }
            else
            {
                MessageBox.Show("La cantidad requerida supera la cantidad en el depósito.\nCANTIDAD DISPONIBLE: " + repuesto.CantidadStock + ".", "Advertencia");
            }
        }

        private void buttonEliminarRepuesto_Click(object sender, EventArgs e)
        {
            RepuestoReparacion objRepuestoLocal = new RepuestoReparacion();
            objRepuestoLocal.IdRepuesto = Convert.ToInt32(this.dataGridRepuesto.Rows[this.dataGridRepuesto.CurrentCell.RowIndex].Cells["idrepuesto"].Value);
            for (int i = 0; i < ventarepuesto.DetalleRepuestos.Count; i++)
            {
                if (objRepuestoLocal.IdRepuesto == ((RepuestoReparacion)ventarepuesto.DetalleRepuestos[i]).IdRepuesto)
                {
                    ventarepuesto.DetalleRepuestosEliminados.Add(((RepuestoReparacion)ventarepuesto.DetalleRepuestos[i]));
                    ventarepuesto.DetalleRepuestos.RemoveAt(i);
                    i = 0;
                }
            }

            this.llenarDataGridRepuesto();
            this.buttonEliminarRepuesto.Enabled = false;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (this.buttonGuardar.Text == "Terminar")
            {
                this.Close();
                return;
            }

            //COMPROBAMOS QUE HAY UNA TAREA O REPUESTO, SE HA ASIGNADO UN CLIENTE Y UN VEHICULO
            if (ventarepuesto.Cliente.Id != 0 && ventarepuesto.DetalleRepuestos.Count != 0)
            {

                //1ro GUARDAMOS LA REPARACION
                ventarepuesto.FechaSistema = DateTime.Now;
                ventarepuesto.Fecha = this.dateTimePicker1.Value;
                ventarepuesto.Descripcion = this.textDescripcion.Text;
                ventarepuesto.ImporteTotal = Convert.ToDouble(this.textTotal.Text);

                try
                {
                    if (flagEditar)
                    {
                        ventarepuesto.actualizar();
                        MessageBox.Show("Venta de Repuestos actualizada con éxito.", "Información");
                        this.actualizarDataGridEvento();

                        //CAMBIAMOS ASPECTO DE BOTON GUARDAR
                        this.buttonGuardar.Text = "Terminar";
                        this.buttonGuardar.TextAlign = ContentAlignment.MiddleCenter;
                        this.buttonGuardar.Image = null;
                    }
                    else
                    {
                        ventarepuesto.agregar();
                        if (this.actualizarDataGridEvento!=null)
                            this.actualizarDataGridEvento();
                        MessageBox.Show("Venta de Repuestos guardada con éxito.", "Información");

                        //CAMBIAMOS ASPECTO DE BOTON GUARDAR
                        this.buttonGuardar.Text = "Terminar";
                        this.buttonGuardar.TextAlign = ContentAlignment.MiddleCenter;
                        this.buttonGuardar.Image = null;
                    }
                }
                catch
                {
                    if (!flagEditar)
                    {
                        ventarepuesto.eliminarError();
                    }
                    MessageBox.Show("Hubo un problema al guardar la Venta de Repuestos.", "Error");
                }
            }
            else
            {
                MessageBox.Show("Verifique que los datos de la Venta de Repuestos están completos.", "Error");
                return;
            }
        }

        private void frmAgregarEditarVentaRepuesto_Load(object sender, EventArgs e)
        {
            ventarepuesto = new VentaRepuesto();
            colIdRepuestos = new ArrayList();

            this.FormLoad();
            
        }

        private void FormLoad()
        {
            this.buttonEliminarRepuesto.Enabled = false;
            this.buttonAgregarRepuesto.Enabled = false;

            if (flagEditar)
            {
                ventarepuesto.IdVentaRepuesto = this.idVentaRepuesto;
                ventarepuesto.getVentaRepuesto();

                this.textNombre.Text = ventarepuesto.Cliente.NombreRazonSocial;
                this.textDescripcion.Text = ventarepuesto.Descripcion;

                this.dateTimePicker1.Value = ventarepuesto.Fecha;

                this.llenarDataGridRepuesto();

                //CAMBIAMOS ASPECTO DE BOTON GUARDAR
                this.buttonGuardar.Text = "Terminar";
                this.buttonGuardar.TextAlign = ContentAlignment.MiddleCenter;
                this.buttonGuardar.Image = null;
            }
        }

        private void textCantidadRepuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.comprobarNumero(this, e, this.textCantidadRepuesto.Text);
            if (e.KeyChar == (char)13)
            {
                this.buttonAgregarRepuesto.PerformClick();
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

        private void dataGridRepuesto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.buttonEliminarRepuesto.Enabled = true;
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

        private void dataGridRepuesto_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < ventarepuesto.DetalleRepuestos.Count; i++)
            {
                if (((RepuestoReparacion)ventarepuesto.DetalleRepuestos[i]).IdRepuesto == (int)this.dataGridRepuesto.Rows[e.RowIndex].Cells["idrepuesto"].Value)
                {
                    if (((RepuestoReparacion)ventarepuesto.DetalleRepuestos[i]).CantidadStock >= Convert.ToDouble(this.dataGridRepuesto.Rows[e.RowIndex].Cells["cantidadrepuesto"].Value))
                    {
                        ((RepuestoReparacion)ventarepuesto.DetalleRepuestos[i]).CantidadRequeridaAnterior = ((RepuestoReparacion)ventarepuesto.DetalleRepuestos[i]).CantidadRequerida;
                        ((RepuestoReparacion)ventarepuesto.DetalleRepuestos[i]).CantidadRequerida = Convert.ToDouble(this.dataGridRepuesto.Rows[e.RowIndex].Cells["cantidadrepuesto"].Value);
                        this.llenarDataGridRepuesto();
                    }
                    else
                    {
                        MessageBox.Show("La cantidad requerida supera la cantidad en el depósito.\nCANTIDAD DISPONIBLE: " + ((RepuestoReparacion)ventarepuesto.DetalleRepuestos[i]).CantidadStock + ".", "Advertencia");
                        this.dataGridRepuesto.Rows[e.RowIndex].Cells["cantidadrepuesto"].Value = ((RepuestoReparacion)ventarepuesto.DetalleRepuestos[i]).CantidadRequerida;
                    }
                }
            }
            this.calcular();
        }

        private void buttonDeshacer_Click(object sender, EventArgs e)
        {
            this.FormLoad();
        }
    }
}
