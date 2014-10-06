using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing.Printing;

namespace SistemaGestionTaller
{
    public partial class frmFactura : Form
    {
        private Factura factura;
        private Pago pago;
        private Iva iva;
        private int idReparacion;
        private int idVenta;
        private bool flagVenta;
        private bool flagControl;
        private bool flagImpreza;

        //DELEGADO Y EVENTO PARA ACTUALIZAR GRILLA
        public delegate void actualizarDataGrid();
        public event actualizarDataGrid actualizarDataGridEvento;

        public frmFactura(int idOrden_p, bool flagVenta_p)
        {
            InitializeComponent();
            factura = new Factura();
            pago = new Pago();
            iva = new Iva();

            this.flagVenta = flagVenta_p;
            if (flagVenta_p)
                this.idVenta = idOrden_p;
            else
                this.idReparacion = idOrden_p;

        }

        private void llenarComboIva()
        {
            ArrayList colIva = new ArrayList();
            colIva = iva.coleccion();

            this.comboBoxIva.Items.Clear();
            for (int i = 0; i < colIva.Count; i++ )
            {
                this.comboBoxIva.Items.Add((Iva)colIva[i]);
            }

            this.comboBoxIva.SelectedIndex = 0;
        }

        private void llenarDetalleFactura()
        {
            this.facturaDataGridView.Rows.Clear();
            
            if (flagVenta)
            {
                for (int i = 0; i < factura.VentaRepuesto.DetalleRepuestos.Count; i++)
                {
                    this.facturaDataGridView.Rows.Add();
                    this.facturaDataGridView.Rows[i].Cells["descripcion"].Value = ((RepuestoReparacion)factura.VentaRepuesto.DetalleRepuestos[i]).ToString();
                    this.facturaDataGridView.Rows[i].Cells["cantidad"].Value = ((RepuestoReparacion)factura.VentaRepuesto.DetalleRepuestos[i]).CantidadRequerida; ;
                    this.facturaDataGridView.Rows[i].Cells["preciounitario"].Value = ((RepuestoReparacion)factura.VentaRepuesto.DetalleRepuestos[i]).PrecioUnitario;
                    this.facturaDataGridView.Rows[i].Cells["importe"].Value = ((RepuestoReparacion)factura.VentaRepuesto.DetalleRepuestos[i]).PrecioTotal;
                }
                this.facturaDataGridView.ClearSelection();
            }
            else
            {
                ArrayList colDetalleFactura = new ArrayList();
                colDetalleFactura.AddRange(factura.Reparacion.DetalleRepuestos);
                colDetalleFactura.AddRange(factura.Reparacion.DetalleCargas);
                colDetalleFactura.AddRange(factura.Reparacion.DetalleTarea);
                
                //REPUESTOS
                for (int i = 0 ; i < factura.Reparacion.DetalleRepuestos.Count; i++)
                {
                    this.facturaDataGridView.Rows.Add();
                    this.facturaDataGridView.Rows[i].Cells["descripcion"].Value = ((RepuestoReparacion)colDetalleFactura[i]).ToString();
                    this.facturaDataGridView.Rows[i].Cells["cantidad"].Value = ((RepuestoReparacion)colDetalleFactura[i]).CantidadRequerida;
                    this.facturaDataGridView.Rows[i].Cells["preciounitario"].Value = ((RepuestoReparacion)colDetalleFactura[i]).PrecioUnitario;
                    if (this.comboBoxTipoFactura.Text != "B")
                    {
                        this.facturaDataGridView.Rows[i].Cells["importe"].Value = ((RepuestoReparacion)colDetalleFactura[i]).PrecioTotal;
                    }
                    else
                    {
                        double porcentajeivaLocal = ((Iva)this.comboBoxIva.SelectedItem).PorcentajeIva;
                        this.facturaDataGridView.Rows[i].Cells["importe"].Value = ((RepuestoReparacion)colDetalleFactura[i]).PrecioTotal * (1+(porcentajeivaLocal / 100));
                    }
                }

                //CARGAS
                for (int i = factura.Reparacion.DetalleRepuestos.Count; i < (factura.Reparacion.DetalleRepuestos.Count + factura.Reparacion.DetalleCargas.Count); i++)
                {
                    this.facturaDataGridView.Rows.Add();
                    this.facturaDataGridView.Rows[i].Cells["descripcion"].Value = ((RepuestoReparacion)colDetalleFactura[i]).ToString();
                    this.facturaDataGridView.Rows[i].Cells["cantidad"].Value = ((RepuestoReparacion)colDetalleFactura[i]).CantidadRequerida;
                    this.facturaDataGridView.Rows[i].Cells["preciounitario"].Value = ((RepuestoReparacion)colDetalleFactura[i]).PrecioUnitario;
                    if (this.comboBoxTipoFactura.Text != "B" || factura.TipoFactura != "B")
                    {
                        this.facturaDataGridView.Rows[i].Cells["importe"].Value = ((RepuestoReparacion)colDetalleFactura[i]).PrecioTotal;
                    }
                    else
                    {
                        double porcentajeivaLocal = ((Iva)this.comboBoxIva.SelectedItem).PorcentajeIva;
                        this.facturaDataGridView.Rows[i].Cells["importe"].Value = ((RepuestoReparacion)colDetalleFactura[i]).PrecioTotal * (1 + (porcentajeivaLocal / 100)); ;
                    }
                }

                //TAREAS
                for (int i = (factura.Reparacion.DetalleRepuestos.Count + factura.Reparacion.DetalleCargas.Count); i < colDetalleFactura.Count; i++)
                {
                    this.facturaDataGridView.Rows.Add();
                    this.facturaDataGridView.Rows[i].Cells["descripcion"].Value = ((TareaReparacion)colDetalleFactura[i]).ToString();
                    this.facturaDataGridView.Rows[i].Cells["cantidad"].Value = "1";
                    this.facturaDataGridView.Rows[i].Cells["preciounitario"].Value = ((TareaReparacion)colDetalleFactura[i]).Costo;
                    this.facturaDataGridView.Rows[i].Cells["importe"].Value = ((TareaReparacion)colDetalleFactura[i]).CostoTotal;
                }
            }
            this.facturaDataGridView.ClearSelection();
            this.calcular();
        }

        private void calcular()
        {
            double importeFinal = 0;
            
            if (this.textBoxBonificacion.Text == "")
                factura.Bonificacion = 0;
            else
                factura.Bonificacion = Convert.ToDouble(this.textBoxBonificacion.Text);

            //DATAGRID TAREA
            foreach (DataGridViewRow row in this.pagosDataGridView2.Rows)
            {
                if (row.Cells["importepago"].Value != null)
                {
                    importeFinal += (double)row.Cells["importepago"].Value;
                }
            }

            if (flagVenta)
            {
                if (((Iva)this.comboBoxIva.SelectedItem).CondicionIva.IndexOf("INCLUIDO") > 0 || factura.IvaFactura.CondicionIva.IndexOf("INCLUIDO") > 0)
                {
                    //CALCULO VIEJO DEL IVA
                    factura.ImporteFactura = factura.VentaRepuesto.ImporteTotal;
                    double ImporteIva = Convert.ToDouble((factura.VentaRepuesto.ImporteTotal * ((Iva)this.comboBoxIva.SelectedItem).PorcentajeIva / (((Iva)this.comboBoxIva.SelectedItem).PorcentajeIva+100)).ToString("0.00"));
                    double Subtotal = Convert.ToDouble((factura.VentaRepuesto.ImporteTotal - ImporteIva).ToString("0.00"));
                    factura.ImporteFactura -= factura.ImporteFactura * (factura.Bonificacion / 100);
                    this.facturaTextBoxTotal.Text = factura.ImporteFactura.ToString("0.00").Insert(0, "$");
                    this.textBoxIva.Text = ImporteIva.ToString("0.00").Insert(0, "$");
                    this.textBoxSubtotal.Text = Subtotal.ToString("0.00").Insert(0, "$");
                    //Calculamos el saldo de la factura
                    this.textBoxSaldo.Text = "$" + (factura.ImporteFactura - importeFinal).ToString("0.00");
                }
                else
                {
                    //this.comboBoxIva.Enabled = true;
                    double porcentajeivaLocal = ((Iva)this.comboBoxIva.SelectedItem).PorcentajeIva;
                    this.textBoxIva.Text = (factura.VentaRepuesto.ImporteTotal * (porcentajeivaLocal / 100)).ToString("0.00").Insert(0, "$");
                    this.textBoxSubtotal.Text = (factura.VentaRepuesto.ImporteTotal).ToString("0.00").Insert(0, "$");
                    factura.ImporteFactura = factura.VentaRepuesto.ImporteTotal * (1 + (porcentajeivaLocal / 100));
                    factura.ImporteFactura -= factura.ImporteFactura * (factura.Bonificacion / 100);
                    this.facturaTextBoxTotal.Text = factura.ImporteFactura.ToString("0.00").Insert(0, "$");
                    //Calculo del saldo
                    this.textBoxSaldo.Text = "$" + (factura.ImporteFactura - importeFinal);
                }
            }
            else
            {
                if (((Iva)this.comboBoxIva.SelectedItem).CondicionIva.IndexOf("INCLUIDO") > 0 || factura.IvaFactura.CondicionIva.IndexOf("INCLUIDO") > 0)
                {
                    //CALCULO IVA INCLUIDO
                    factura.ImporteFactura = factura.Reparacion.ImporteTotal;
                    double ImporteIva = Convert.ToDouble((factura.Reparacion.ImporteTotal * ((Iva)this.comboBoxIva.SelectedItem).PorcentajeIva / (((Iva)this.comboBoxIva.SelectedItem).PorcentajeIva + 100)).ToString("0.00"));
                    double Subtotal = Convert.ToDouble((factura.Reparacion.ImporteTotal - ImporteIva).ToString("0.00"));
                    factura.ImporteFactura -= factura.ImporteFactura * (factura.Bonificacion / 100);
                    if (this.comboBoxTipoFactura.Text != "B")
                    {
                        this.textBoxIva.Text = ImporteIva.ToString("0.00").Insert(0, "$");
                        this.textBoxSubtotal.Text = Subtotal.ToString("0.00").Insert(0, "$");
                    }
                    else
                    {
                        this.textBoxIva.Text = "";
                        this.textBoxSubtotal.Text = "";
                    }
                    this.facturaTextBoxTotal.Text = factura.ImporteFactura.ToString("0.00").Insert(0, "$");
                    //Calculamos el saldo de la factura
                    this.textBoxSaldo.Text = "$" + (factura.ImporteFactura - importeFinal).ToString("0.00");
                }
                else
                {
                    //CALCULO VIEJO DEL IVA
                    double porcentajeivaLocal = ((Iva)this.comboBoxIva.SelectedItem).PorcentajeIva;
                    factura.ImporteFactura = factura.Reparacion.ImporteTotal * (1 + (porcentajeivaLocal / 100));
                    factura.ImporteFactura -= factura.ImporteFactura * (factura.Bonificacion / 100);
                    if (this.comboBoxTipoFactura.Text != "B")
                    {
                        this.textBoxIva.Text = (factura.Reparacion.ImporteTotal * (porcentajeivaLocal / 100)).ToString("0.00").Insert(0, "$");
                        this.textBoxSubtotal.Text = (factura.Reparacion.ImporteTotal).ToString("0.00").Insert(0, "$");
                    }
                    else
                    {
                        this.textBoxIva.Text = "";
                        this.textBoxSubtotal.Text = "";
                    }
                    this.facturaTextBoxTotal.Text = factura.ImporteFactura.ToString("0.00").Insert(0, "$");
                    //Calculamos el saldo de la factura
                    this.textBoxSaldo.Text = "$" + (factura.ImporteFactura - importeFinal).ToString("0.00");
                }
                
            }

        }

        private void llenarPagos()
        {
            this.buttonEditar.Enabled = false;
            this.buttonEliminar.Enabled = false;

            if (flagVenta)
                factura.Pagos = pago.getPagosVenta(factura.IdFactura);
            else
                factura.Pagos = pago.getPagosReparacion(factura.IdFactura);

            this.pagosDataGridView2.Rows.Clear();

            for (int i = 0; i < factura.Pagos.Count; i++)
            {
                this.pagosDataGridView2.Rows.Add();
                this.pagosDataGridView2.Rows[i].Cells["idpago"].Value = ((Pago)factura.Pagos[i]).IdPago;
                this.pagosDataGridView2.Rows[i].Cells["numeropago"].Value = ((Pago)factura.Pagos[i]).NumeroPago;
                this.pagosDataGridView2.Rows[i].Cells["fechapago"].Value = ((Pago)factura.Pagos[i]).FechaPago.ToShortDateString();
                this.pagosDataGridView2.Rows[i].Cells["mediopago"].Value = ((Pago)factura.Pagos[i]).MedioPago;
                this.pagosDataGridView2.Rows[i].Cells["importepago"].Value = ((Pago)factura.Pagos[i]).ImportePago;
                this.pagosDataGridView2.Rows[i].Cells["observaciones"].Value = ((Pago)factura.Pagos[i]).ObservacionPago;
                this.pagosDataGridView2.Rows[i].Cells["banco"].Value = ((Pago)factura.Pagos[i]).BancoPago;
                this.pagosDataGridView2.Rows[i].Cells["numerocheque"].Value = ((Pago)factura.Pagos[i]).NumeroCheque;
                //this.pagosDataGridView2.Rows[i].Cells["sele"].Value = false;
            }

            this.calcular();
            this.pagosDataGridView2.ClearSelection();
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

        private void frmFactura_Load(object sender, EventArgs e)
        {
            this.comboBoxMedioPago.SelectedIndex = 0;
            this.llenarComboIva();

            this.buttonEditar.Enabled = false;
            this.buttonEliminar.Enabled = false;

            if (flagVenta)
            {
                //VENTA REPUESTO
                //1ra vez que se va a guardar la factura
                factura.VentaRepuesto.IdVentaRepuesto = this.idVenta;
                factura.VentaRepuesto.getVentaRepuesto();
                factura.VentaRepuesto.Cliente.getDatosPersonales();

                if (factura.existeFacturaVenta())
                {
                    this.dateTimePickerFactura.Value = factura.FechaFactura;
                    this.comboBoxIva.SelectedItem = factura.IvaFactura;
                    this.textBoxBonificacion.Text = factura.Bonificacion.ToString();

                    for (int i = 0; i < this.comboBoxIva.Items.Count; i++)
                    {
                        this.comboBoxIva.SelectedIndex = i;
                        if (this.comboBoxIva.SelectedItem.ToString().Equals(((factura.IvaFactura)).ToString()))
                            break;
                    }

                    //En caso de facturar a nombre de otro cliente esta linea no va.
                    factura.Cliente.getDatosPersonales();

                    this.facturaTextBoxCuit.Text = factura.Cliente.Cuit;
                    this.facturaTextBoxDireccion.Text = factura.Cliente.Direccion;
                    this.facturaTextBoxRazonSocial.Text = factura.Cliente.NombreRazonSocial;

                    this.textBoxBonificacion.Enabled = false;
                    this.comboBoxTipoFactura.Enabled = false;
                    this.dateTimePickerFactura.Enabled = false;
                    this.buttonBuscarCliente.Enabled = false;
                    this.buttonNuevoCliente.Enabled = false;
                    this.textBoxCodigoFactura.Enabled = false;
                    this.dateTimePickerFactura.Enabled = false;
                    this.comboBoxIva.Enabled = false;

                    this.flagImpreza = true;

                    this.textBoxCodigoFactura.Text = factura.NumeroFactura;
                    this.llenarPagos();

                    //CAMBIAMOS EL NOMBRE DEL BOTON GUARDAR PARA GUIAR AL USUARIO
                    this.buttonGuardar.Text = "Terminar";
                    this.buttonGuardar.TextAlign = ContentAlignment.MiddleCenter;
                    this.buttonGuardar.Image = null;

                }
                else
                {
                    //En caso de facturar a nombre de otro cliente esta linea no va.
                    factura.Cliente = factura.VentaRepuesto.Cliente;
                    factura.IvaFactura = (Iva)this.comboBoxIva.SelectedItem;
                    this.facturaTextBoxCuit.Text = factura.Cliente.Cuit;
                    this.facturaTextBoxDireccion.Text = factura.Cliente.Direccion;
                    this.facturaTextBoxRazonSocial.Text = factura.Cliente.NombreRazonSocial;

                }
                this.flagControl = true;
                this.llenarDetalleFactura();
            }
            else
            {
                //REPARACION
                //1ra vez que se va a guardar la factura
                factura.Reparacion.IdReparacion = this.idReparacion;
                factura.Reparacion.getReparacion();
                factura.Reparacion.Cliente.getDatosPersonales();

                if (factura.existeFacturaReparacion())
                {
                    this.dateTimePickerFactura.Value = factura.FechaFactura;
                    for (int i = 0; i < this.comboBoxIva.Items.Count; i++)
                    {
                        this.comboBoxIva.SelectedIndex = i;
                        if (this.comboBoxIva.SelectedItem.ToString().Equals(((factura.IvaFactura)).ToString()))
                            break;
                    }
                    this.textBoxBonificacion.Text = factura.Bonificacion.ToString();

                    //En caso de facturar a nombre de otro cliente esta linea no va.
                    factura.Cliente.getDatosPersonales();

                    this.facturaTextBoxCuit.Text = factura.Cliente.Cuit;
                    this.facturaTextBoxDireccion.Text = factura.Cliente.Direccion;
                    this.facturaTextBoxRazonSocial.Text = factura.Cliente.NombreRazonSocial;

                    this.textBoxBonificacion.Enabled = false;
                    this.comboBoxTipoFactura.Enabled = false;
                    this.dateTimePickerFactura.Enabled = false;
                    this.buttonBuscarCliente.Enabled = false;
                    this.buttonNuevoCliente.Enabled = false;
                    this.textBoxCodigoFactura.Enabled = false;
                    this.comboBoxIva.Enabled = false;
                    this.flagImpreza = true;

                    this.textBoxCodigoFactura.Text = factura.NumeroFactura;
                    this.llenarPagos();

                    //CAMBIAMOS EL NOMBRE DEL BOTON GUARDAR PARA GUIAR AL USUARIO
                    this.buttonGuardar.Text = "Terminar";
                    this.buttonGuardar.TextAlign = ContentAlignment.MiddleCenter;
                    this.buttonGuardar.Image = null;

                }
                else
                {
                    if (this.textBoxBonificacion.Text == "")
                        factura.Bonificacion = 0;

                    //En caso de facturar a nombre de otro cliente esta linea no va.
                    factura.Cliente = factura.Reparacion.Cliente;

                    factura.IvaFactura = (Iva)this.comboBoxIva.SelectedItem;

                    this.facturaTextBoxCuit.Text = factura.Cliente.Cuit;
                    this.facturaTextBoxDireccion.Text = factura.Cliente.Direccion;
                    this.facturaTextBoxRazonSocial.Text = factura.Cliente.NombreRazonSocial;

                }
                this.flagControl = true;
                
                if (factura.TipoFactura != null)
                {
                    this.comboBoxTipoFactura.Text = factura.TipoFactura;
                }
                else
                {
                    this.comboBoxTipoFactura.SelectedIndex = 0;
                }
                this.llenarDetalleFactura();
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (this.buttonGuardar.Text == "Terminar")
            {
                if(this.actualizarDataGridEvento!=null)
                    this.actualizarDataGridEvento();

                if (!flagImpreza)
                {
                    if (MessageBox.Show("¿Desea imprimir la factura?", "Imprimir", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            this.imprimirFactura();
                        }
                        catch (MySql.Data.MySqlClient.MySqlException ex)
                        {
                            MessageBox.Show("Error MySQL: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                

                this.Close();
                return;
            }

            if (flagVenta)
            {
                //VENTA DE REPUESTO
                if (factura.getFacturaVenta())
                {
                    //LA FACTURA YA EXISTE Y VAMOS A CARGAR NUEVOS PAGOS
       
                    factura.Saldo = Convert.ToDouble(this.textBoxSaldo.Text.Replace("$", ""));
                    factura.EstadoFactura = 0;
                    factura.actualizarVenta();

                    MessageBox.Show("Factura actualizada con éxito.", "Información");

                    //CAMBIAMOS EL NOMBRE DEL BOTON GUARDAR PARA GUIAR AL USUARIO
                    this.buttonGuardar.Text = "Terminar";
                    this.buttonGuardar.TextAlign = ContentAlignment.MiddleCenter;
                    this.buttonGuardar.Image = null;
                    //this.flagPestania = true;
                }
                else
                {
                    if (this.textBoxCodigoFactura.Text != "")
                    {
                        //CREAMOS POR 1RA VEZ LA FACTURA
                        factura.FechaFactura = this.dateTimePickerFactura.Value;
                        factura.Saldo = Convert.ToDouble(this.facturaTextBoxTotal.Text.Replace("$", ""));
                        factura.EstadoFactura = 0;
                                                
                        //nuevo codigo para tablas relacionadas
                        factura.IvaFactura = (Iva)this.comboBoxIva.SelectedItem;
                        factura.TipoFactura = this.comboBoxTipoFactura.Text;

                        factura.NumeroFactura = this.textBoxCodigoFactura.Text.ToUpper();
                        if (this.textBoxBonificacion.Text != "")
                            factura.Bonificacion = Convert.ToDouble(this.textBoxBonificacion.Text);
                        else
                            factura.Bonificacion = 0;

                        factura.agregarVenta();

                        if (factura.Saldo == 0)
                        {
                            factura.VentaRepuesto.EstadoVenta = 3;
                            factura.VentaRepuesto.actualizar();
                        }
                        else
                        {
                            //Indicamos que esa venta ya fue facturada
                            factura.VentaRepuesto.EstadoVenta = 2;
                            factura.VentaRepuesto.actualizar();
                        }

                        MessageBox.Show("Factura guardada con éxito.", "Información");

                        //CAMBIAMOS EL NOMBRE DEL BOTON GUARDAR PARA GUIAR AL USUARIO
                        this.buttonGuardar.Text = "Terminar";
                        this.buttonGuardar.TextAlign = ContentAlignment.MiddleCenter;
                        this.buttonGuardar.Image = null;
                        //this.flagPestania = true;
                    }
                    else
                    {
                        MessageBox.Show("Debe colocar el número de factura correspondiente.", "Información");
                        return;
                    }
                }
            }
            else
            {
                //REPARACION
                if (factura.getFacturaReparacion())
                {
                    //LA FACTURA YA EXISTE Y VAMOS A CARGAR NUEVOS PAGOS
                    factura.Saldo = Convert.ToDouble(this.textBoxSaldo.Text.Replace("$", ""));
                    factura.EstadoFactura = 0;
                    factura.actualizarReparacion();

                    MessageBox.Show("Factura actualizada con éxito.", "Información");

                    //CAMBIAMOS EL NOMBRE DEL BOTON GUARDAR PARA GUIAR AL USUARIO
                    this.buttonGuardar.Text = "Terminar";
                    this.buttonGuardar.TextAlign = ContentAlignment.MiddleCenter;
                    this.buttonGuardar.Image = null;
                    //this.flagPestania = true;
                }
                else
                {
                    if (this.textBoxCodigoFactura.Text != "")
                    {
                        //CREAMOS POR 1RA VEZ LA FACTURA
                        factura.FechaFactura = this.dateTimePickerFactura.Value;
                        factura.Saldo = Convert.ToDouble(this.facturaTextBoxTotal.Text.Replace("$", ""));
                        factura.EstadoFactura = 0;
                        
                        //nuevo codigo para tablas relacionadas
                        factura.IvaFactura = (Iva)this.comboBoxIva.SelectedItem;
                        factura.TipoFactura = this.comboBoxTipoFactura.Text;
                        
                        factura.NumeroFactura = this.textBoxCodigoFactura.Text.ToUpper();
                        if (this.textBoxBonificacion.Text != "")
                            factura.Bonificacion = Convert.ToDouble(this.textBoxBonificacion.Text);
                        else
                            factura.Bonificacion = 0;

                        factura.agregarReparacion();

                        if (factura.Saldo != 0 && factura.Reparacion.Estado == 1)
                        {
                            //Facturada
                            factura.Reparacion.Estado = 2;
                            factura.Reparacion.actualizarEstado();
                        }
                        else if (factura.Saldo == 0 && factura.Reparacion.Estado == 2)
                        {
                            //Saldada
                            factura.Reparacion.Estado = 3;
                            factura.Reparacion.actualizarEstado();
                        }
                        else if (factura.Saldo == 0 && factura.Reparacion.Estado == 4)
                        {
                            //Tiene garantia y fue saldada
                            factura.Reparacion.Estado = 5;
                            factura.Reparacion.actualizarEstado();
                        }

                        MessageBox.Show("Factura guardada con éxito.", "Información");

                        //CAMBIAMOS EL NOMBRE DEL BOTON GUARDAR PARA GUIAR AL USUARIO
                        this.buttonGuardar.Text = "Terminar";
                        this.buttonGuardar.TextAlign = ContentAlignment.MiddleCenter;
                        this.buttonGuardar.Image = null;
                        //this.flagPestania = true;
                    }
                    else
                    {
                        MessageBox.Show("Debe colocar el número de factura correspondiente.", "Información");
                        return;
                    }
                }
            }
        }

        public void limpiarCampos()
        {
            this.textBoxBanco.ResetText(); this.textBoxCheque.ResetText(); this.textBoxImportePago.ResetText();
            this.textBoxObservacion.ResetText(); this.comboBoxMedioPago.SelectedIndex = 0; this.dateTimePickerPago.ResetText();
            pago.IdPago = 0;
        }
        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            if(this.pago.IdPago != 0)
            {
                if (MessageBox.Show("Si continua va a modificar el pago seleccionado, Pago N°: " + pago.NumeroPago + ". ¿Desea Continuar?", "Advertencia", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    pago.IdPago = 0;
                }
            }

            if (Convert.ToDouble(this.textBoxImportePago.Text) > factura.Saldo && pago.IdPago == 0)
            {
                MessageBox.Show("El pago ingresado es mayor al saldo de la factura.", "Advertencia");
                return;
            }

            if (flagVenta)
            {
                if (this.textBoxImportePago.Text != "")
                {
                    //VENTA REPUESTO
                    if (this.comboBoxMedioPago.Text == "Cheque" && this.textBoxBanco.Text == "" && this.textBoxCheque.Text == "")
                    {
                        MessageBox.Show("Debe completar los campos Banco y Número de Cheque.");
                        return;
                    }

                    if (this.pagosDataGridView2.Rows.Count > 0)
                    {
                        int r = this.pagosDataGridView2.Rows.Count - 1;
                        pago.NumeroPago = Convert.ToInt32(this.pagosDataGridView2.Rows[r].Cells["numeropago"].Value.ToString()) + 1;
                    }
                    else
                        pago.NumeroPago = 1;


                    pago.FechaPago = this.dateTimePickerPago.Value;
                    pago.BancoPago = this.textBoxBanco.Text;
                    pago.MedioPago = this.comboBoxMedioPago.Text;
                    pago.NumeroCheque = this.textBoxCheque.Text;
                    pago.ObservacionPago = this.textBoxObservacion.Text;
                    pago.ImportePago = Convert.ToDouble(this.textBoxImportePago.Text);

                    if (pago.existePagoVenta())
                    {
                        pago.actualizarVenta();

                    }
                    else
                    {
                        pago.agregarVenta(factura.IdFactura);
                    }                    

                    this.limpiarCampos();
                    MessageBox.Show("Pago acreditado correctamente.", "Información");
                    this.llenarPagos();
                }
                else
                {
                    MessageBox.Show("Debe introducir un monto al pago para poder guardarlo.", "Error");
                    return;
                }
            }
            else
            {
                if (this.textBoxImportePago.Text != "" && Convert.ToDouble(this.textBoxImportePago.Text) > 0)
                {
                    //REPARACION
                    if (this.comboBoxMedioPago.Text == "Cheque" && this.textBoxBanco.Text == "" && this.textBoxCheque.Text == "")
                    {
                        MessageBox.Show("Debe completar los campos Banco y Número de Cheque.");
                        return;
                    }

                    if (this.pagosDataGridView2.Rows.Count > 0)
                    {
                        int r = this.pagosDataGridView2.Rows.Count-1;
                        pago.NumeroPago = Convert.ToInt32(this.pagosDataGridView2.Rows[r].Cells["numeropago"].Value.ToString()) + 1;
                    }
                    else
                        pago.NumeroPago = 1;


                    if (pago.existePagoReparacion())
                    {
                        pago.FechaPago = this.dateTimePickerPago.Value;
                        pago.BancoPago = this.textBoxBanco.Text;
                        pago.MedioPago = this.comboBoxMedioPago.Text;
                        pago.NumeroCheque = this.textBoxCheque.Text;
                        pago.ObservacionPago = this.textBoxObservacion.Text;
                        pago.ImportePago = Convert.ToDouble(this.textBoxImportePago.Text);

                        pago.actualizarReparacion();
                    }
                    else 
                    {
                        pago.FechaPago = this.dateTimePickerPago.Value;
                        pago.BancoPago = this.textBoxBanco.Text;
                        pago.MedioPago = this.comboBoxMedioPago.Text;
                        pago.NumeroCheque = this.textBoxCheque.Text;
                        pago.ObservacionPago = this.textBoxObservacion.Text;
                        pago.ImportePago = Convert.ToDouble(this.textBoxImportePago.Text);

                        pago.agregarReparacion(factura.IdFactura);
                    }
                    
                    //Actualizamos el importe de la factura
                    factura.Saldo = factura.Saldo - pago.ImportePago;

                    factura.actualizarReparacion();

                    if (factura.Saldo != 0 && factura.Reparacion.Estado == 1)
                    {
                        //Facturada
                        factura.Reparacion.Estado = 2;
                        factura.Reparacion.actualizarEstado();
                    }
                    else if (factura.Saldo == 0 && factura.Reparacion.Estado == 2)
                    {
                        //Saldada
                        factura.Reparacion.Estado = 3;
                        factura.Reparacion.actualizarEstado();
                    }
                    else if (factura.Saldo == 0 && factura.Reparacion.Estado == 4)
                    {
                        //Tiene garantia y fue saldada
                        factura.Reparacion.Estado = 5;
                        factura.Reparacion.actualizarEstado();
                    }

                    this.limpiarCampos();
                    MessageBox.Show("Pago acreditado correctamente.", "Información");
                    this.llenarPagos();
                }
                else
                {
                    MessageBox.Show("Debe introducir un monto al pago para poder guardarlo.", "Error");
                    return;
                }

            }
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (flagVenta)
            {
                //VENTA REPARACION
                if (this.textBoxImportePago.Text != "")
                {
                    pago.FechaPago = this.dateTimePickerPago.Value;
                    pago.BancoPago = this.textBoxBanco.Text;
                    pago.MedioPago = this.comboBoxMedioPago.Text;
                    pago.NumeroCheque = this.textBoxCheque.Text;
                    pago.ObservacionPago = this.textBoxObservacion.Text;
                    pago.ImportePago = Convert.ToDouble(this.textBoxImportePago.Text);

                    pago.actualizarVenta();

                    //Actualizamos el importe de la factura
                    factura.Saldo = factura.Saldo - pago.ImportePago;

                    factura.actualizarVenta();

                    this.limpiarCampos();
                    MessageBox.Show("Pago actualizado correctamente.", "Información");
                    this.llenarPagos();
                }
                else
                {
                    MessageBox.Show("Debe introducir un monto al pago para poder guardarlo.", "Error");
                    return;
                }
            }
            else
            {
                //REPARACION
                if (this.textBoxImportePago.Text != "")
                {
                    pago.FechaPago = this.dateTimePickerPago.Value;
                    pago.BancoPago = this.textBoxBanco.Text;
                    pago.MedioPago = this.comboBoxMedioPago.Text;
                    pago.NumeroCheque = this.textBoxCheque.Text;
                    pago.ObservacionPago = this.textBoxObservacion.Text;
                    pago.ImportePago = Convert.ToDouble(this.textBoxImportePago.Text);

                    pago.actualizarReparacion();

                    //Actualizamos el importe de la factura
                    factura.Saldo = factura.Saldo - pago.ImportePago;

                    factura.actualizarReparacion();

                    this.limpiarCampos();
                    MessageBox.Show("Pago actualizado correctamente.", "Información");
                    this.llenarPagos();
                }
                else
                {
                    MessageBox.Show("Debe introducir un monto al pago para poder guardarlo.", "Error");
                    return;
                }
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (flagVenta)
            {
                //VENTA
                if (MessageBox.Show("¿Desea eliminar el pago seleccionado?", "Eliminación", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int r = this.pagosDataGridView2.CurrentCell.RowIndex;
                    pago.IdPago = Convert.ToInt32(this.pagosDataGridView2.Rows[r].Cells["idpago"].Value.ToString());
                    pago.ImportePago = Convert.ToDouble(this.pagosDataGridView2.Rows[r].Cells["importepago"].Value.ToString().Replace("$", ""));

                    //Actualizamos el importe de la factura
                    factura.Saldo = factura.Saldo + pago.ImportePago;

                    pago.eliminarVenta();

                    factura.actualizarVenta();

                    this.limpiarCampos();

                    this.llenarPagos();
                }
            }
            else
            {
                //REPARACION
                if (MessageBox.Show("¿Desea eliminar el pago seleccionado?", "Eliminación", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int r = this.pagosDataGridView2.CurrentCell.RowIndex;
                    pago.IdPago = Convert.ToInt32(this.pagosDataGridView2.Rows[r].Cells["idpago"].Value.ToString());
                    pago.ImportePago = Convert.ToDouble(this.pagosDataGridView2.Rows[r].Cells["importepago"].Value.ToString().Replace("$",""));

                    pago.eliminarReparacion();

                    this.limpiarCampos();

                    this.llenarPagos();

                    //Actualizamos el importe de la factura
                    factura.Saldo = Convert.ToDouble(this.textBoxSaldo.Text.Replace("$", ""));

                    factura.actualizarReparacion();

                    if (factura.Saldo == 0)
                    {
                        factura.Reparacion.Estado = 3;
                        factura.Reparacion.actualizarEstado();
                    }
                    else
                    {
                        //Indicamos que esa venta ya fue facturada
                        factura.Reparacion.Estado = 2;
                        factura.Reparacion.actualizarEstado();
                    }
                }
            }
        }

        private void pagosDataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.buttonEditar.Enabled = true;
            this.buttonEliminar.Enabled = true;

            if (flagVenta)
            {
                if (e.ColumnIndex == 8)
                {
                    //Imprimir el recibo del pago
                    if (Convert.ToBoolean(this.pagosDataGridView2.Rows[e.RowIndex].Cells["seleccionado"].Value) == true)
                        this.pagosDataGridView2.Rows[e.RowIndex].Cells["seleccionado"].Value = false;
                    else
                        this.pagosDataGridView2.Rows[e.RowIndex].Cells["seleccionado"].Value = true;
                }
                else
                {
                    pago.IdPago = Convert.ToInt32(this.pagosDataGridView2.Rows[e.RowIndex].Cells["idpago"].Value);
                    pago.NumeroPago = Convert.ToInt32(this.pagosDataGridView2.Rows[e.RowIndex].Cells["numeropago"].Value);
                    this.dateTimePickerPago.Value = DateTime.Parse(this.pagosDataGridView2.Rows[e.RowIndex].Cells["fechapago"].Value.ToString());
                    this.comboBoxMedioPago.SelectedIndex = this.comboBoxMedioPago.Items.IndexOf(this.pagosDataGridView2.Rows[e.RowIndex].Cells["mediopago"].Value.ToString());
                    this.textBoxImportePago.Text = this.pagosDataGridView2.Rows[e.RowIndex].Cells["importepago"].Value.ToString().Replace("$", "");
                    this.textBoxObservacion.Text = this.pagosDataGridView2.Rows[e.RowIndex].Cells["observaciones"].Value.ToString();
                    this.textBoxBanco.Text = this.pagosDataGridView2.Rows[e.RowIndex].Cells["banco"].Value.ToString();
                    this.textBoxCheque.Text = this.pagosDataGridView2.Rows[e.RowIndex].Cells["numerocheque"].Value.ToString();
                }
            }
            else
            {
                if (e.ColumnIndex == 8)
                {
                    //Imprimir el recibo del pago
                    if (Convert.ToBoolean(this.pagosDataGridView2.Rows[e.RowIndex].Cells["seleccionado"].Value) == true)
                        this.pagosDataGridView2.Rows[e.RowIndex].Cells["seleccionado"].Value = false;
                    else
                        this.pagosDataGridView2.Rows[e.RowIndex].Cells["seleccionado"].Value = true;
                }
                else
                {
                    pago.IdPago = Convert.ToInt32(this.pagosDataGridView2.Rows[e.RowIndex].Cells["idpago"].Value);
                    pago.NumeroPago = Convert.ToInt32(this.pagosDataGridView2.Rows[e.RowIndex].Cells["numeropago"].Value);
                    this.dateTimePickerPago.Value = DateTime.Parse(this.pagosDataGridView2.Rows[e.RowIndex].Cells["fechapago"].Value.ToString());
                    this.comboBoxMedioPago.SelectedIndex = this.comboBoxMedioPago.Items.IndexOf(this.pagosDataGridView2.Rows[e.RowIndex].Cells["mediopago"].Value.ToString());
                    this.textBoxImportePago.Text = this.pagosDataGridView2.Rows[e.RowIndex].Cells["importepago"].Value.ToString().Replace("$", "");
                    this.textBoxObservacion.Text = this.pagosDataGridView2.Rows[e.RowIndex].Cells["observaciones"].Value.ToString();
                    this.textBoxBanco.Text = this.pagosDataGridView2.Rows[e.RowIndex].Cells["banco"].Value.ToString();
                    this.textBoxCheque.Text = this.pagosDataGridView2.Rows[e.RowIndex].Cells["numerocheque"].Value.ToString();
                }
            }
        }

        private void comboBoxMedioPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxMedioPago.Text == "Cheque")
            {
                this.textBoxBanco.Enabled = true;
                this.textBoxCheque.Enabled = true;
            }
            else
            {
                this.textBoxBanco.Enabled = false;
                this.textBoxCheque.Enabled = false;
            }
        }

        private void textBoxImportePago_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.comprobarNumero(this, e, this.textBoxImportePago.Text);
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
            factura.Cliente = (Cliente)e.Cliente;
            //reparacion.Cliente.NombreRazonSocial = e.NombreCliente;

            this.facturaTextBoxRazonSocial.Text = factura.Cliente.NombreRazonSocial;
            this.facturaTextBoxCuit.Text = factura.Cliente.Cuit;
            this.facturaTextBoxDireccion.Text = factura.Cliente.Direccion;
        }

        private void buttonNuevoCliente_Click(object sender, EventArgs e)
        {
            frmAgregarEditarCliente faec = new frmAgregarEditarCliente(true);
            faec.ClienteEncontrado += new frmAgregarEditarCliente.BuscarClienteHandler(fbc_ClienteEncontrado);
            faec.MdiParent = this.MdiParent;
            faec.Show();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 1 && this.factura.IdFactura == 0 && this.textBoxCodigoFactura.Text == "")
            {
                this.buttonAgregar.Enabled = false;
                this.comboBoxMedioPago.Enabled = false;
                this.dateTimePickerPago.Enabled = false;
                this.pagosDataGridView2.Enabled = false;
                this.textBoxImportePago.Enabled = false;
                MessageBox.Show("Debe colocar el número de factura correspondiente para continuar.", "Información");
                return;
            }
            else if (this.textBoxCodigoFactura.Text != "" && this.tabControl1.SelectedIndex == 1 && this.factura.IdFactura == 0)
            {
                this.clickGuardar();
            }
            else if (factura.Saldo == 0)
            {
                this.buttonAgregar.Enabled = false;
            }
            else 
            {
                this.buttonAgregar.Enabled = true;
                this.comboBoxMedioPago.Enabled = true;
                this.dateTimePickerPago.Enabled = true;
                this.pagosDataGridView2.Enabled = true;
                this.textBoxImportePago.Enabled = true;
            }
        }

        private void buttonLimpiarCampos_Click(object sender, EventArgs e)
        {
            this.limpiarCampos();
            this.buttonEliminar.Enabled = false;
        }

        private string impresoraPredeterminada()
        {
            string nombreimpresora="";

            //Busco la impresora por defecto
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                PrinterSettings a = new PrinterSettings();
                a.PrinterName = PrinterSettings.InstalledPrinters[i].ToString();
                if (a.IsDefaultPrinter)
                {
                    nombreimpresora = PrinterSettings.InstalledPrinters[i].ToString();
                }
            }

            return nombreimpresora;
        }

        private void imprimirFactura()
        {
            dsIngresos dsFactura = new dsIngresos();
            
            if (((Iva)this.comboBoxIva.SelectedItem).PorcentajeIva == 10.5)
            {
                //IVA 10.5%
                dsFactura.Factura.Rows.Add(
                this.dateTimePickerFactura.Value.ToShortDateString(),//fechafactura
                factura.NumeroFactura,//numerofactura
                factura.ImporteFactura.ToString("0.00").Insert(0, "$ "),//importefactura
                factura.TipoFactura,//tipofactura
                factura.Cliente.NombreRazonSocial,//nombrerazonsocial
                factura.Cliente.Cuit,//cuit
                factura.Cliente.Direccion,//direccion
                factura.IvaFactura.CondicionIva,//condicioniva
                (factura.Bonificacion+factura.Reparacion.ImporteTotal).ToString("0.00").Insert(0,"$"),//importe sin iva
                this.textBoxIva.Text,//ivafactura
                factura.Bonificacion.ToString("0.00").Insert(0, "$ "), //bonificacion en pesos
                this.textBoxSubtotal.Text,//subtotal sin iva y bonificado
                "",//iva inscr
                factura.Reparacion.CodigoReparacion//codigo OT
                );
            }
            else
            {
                if (this.comboBoxTipoFactura.Text != "B")
                {
                    //IVA 21%
                    dsFactura.Factura.Rows.Add(
                    this.dateTimePickerFactura.Value.ToShortDateString(),//fechafactura
                    factura.NumeroFactura,//numerofactura
                    factura.ImporteFactura.ToString("0.00").Insert(0, "$ "),//importefactura
                    factura.TipoFactura,//tipofactura
                    factura.Cliente.NombreRazonSocial,//nombrerazonsocial
                    factura.Cliente.Cuit,//cuit
                    factura.Cliente.Direccion,//direccion
                    factura.IvaFactura.CondicionIva,//condicioniva
                    (factura.Bonificacion + factura.Reparacion.ImporteTotal).ToString("0.00").Insert(0, "$"),//importe sin iva
                    "",//iva 10.5%
                    factura.Bonificacion.ToString("0.00").Insert(0, "$ "), //bonificacion en pesos
                    this.textBoxSubtotal.Text,//subtotal sin iva y bonificado
                    this.textBoxIva.Text,//iva 21%
                    factura.Reparacion.CodigoReparacion//codigo OT
                    );
                }
                else
                {
                    //IVA 21%
                    dsFactura.Factura.Rows.Add(
                    this.dateTimePickerFactura.Value.ToShortDateString(),//fechafactura
                    factura.NumeroFactura,//numerofactura
                    factura.ImporteFactura.ToString("0.00").Insert(0, "$ "),//importefactura
                    factura.TipoFactura,//tipofactura
                    factura.Cliente.NombreRazonSocial,//nombrerazonsocial
                    factura.Cliente.Cuit,//cuit
                    factura.Cliente.Direccion,//direccion
                    factura.IvaFactura.CondicionIva,//condicioniva
                    factura.ImporteFactura.ToString("0.00").Insert(0, "$ "),//importe sin iva
                    "",//iva 10.5%
                    factura.Bonificacion.ToString("0.00").Insert(0, "$ "), //bonificacion en pesos
                    "",//subtotal sin iva y bonificado
                    "",//iva 21%
                    factura.Reparacion.CodigoReparacion//codigo OT
                    );
                }
            }

            dsFactura.Vehiculo.Rows.Add(
                factura.Reparacion.Vehiculo.Dominio,
                factura.Reparacion.Vehiculo.Marca,
                factura.Reparacion.Vehiculo.Modelo,
                factura.Reparacion.Vehiculo.Anio
                );

            if (factura.Reparacion.DetalleRepuestos.Count != 0)
            {
                for (int i = 0; i < factura.Reparacion.DetalleRepuestos.Count; i++)
                {
                    double porcentajeivaLocal = ((Iva)this.comboBoxIva.SelectedItem).PorcentajeIva;
                    double totalRepuesto = 0;
                    if (this.comboBoxTipoFactura.Text != "B")
                    {
                        totalRepuesto = ((RepuestoReparacion)factura.Reparacion.DetalleRepuestos[i]).PrecioTotal;
                    }
                    else
                    {
                        totalRepuesto = ((RepuestoReparacion)factura.Reparacion.DetalleRepuestos[i]).PrecioTotal * (1 + (porcentajeivaLocal / 100));
                    }
                    dsFactura.TablaRepuestos.Rows.Add(
                            ((RepuestoReparacion)factura.Reparacion.DetalleRepuestos[i]).CantidadRequerida.ToString(),
                            ((RepuestoReparacion)factura.Reparacion.DetalleRepuestos[i]).CodigoRepuesto.ToString().ToUpper(),
                            ((RepuestoReparacion)factura.Reparacion.DetalleRepuestos[i]).DescripcionRepuesto.ToString().ToUpper(),
                            ((RepuestoReparacion)factura.Reparacion.DetalleRepuestos[i]).PrecioUnitario.ToString("0.00"),
                            totalRepuesto.ToString("0.00"),
                            totalRepuesto.ToString("0.00")
                            );
                }
            }

            if (factura.Reparacion.DetalleCargas.Count != 0)
            {
                for (int i = 0; i < factura.Reparacion.DetalleCargas.Count; i++)
                {
                    if (this.comboBoxTipoFactura.Text != "B")
                    {
                        dsFactura.TablaRepuestos.Rows.Add(
                            ((RepuestoReparacion)factura.Reparacion.DetalleCargas[i]).CantidadRequerida.ToString(),
                            ((RepuestoReparacion)factura.Reparacion.DetalleCargas[i]).CodigoRepuesto.ToString().ToUpper(),
                            ((RepuestoReparacion)factura.Reparacion.DetalleCargas[i]).DescripcionRepuesto.ToString().ToUpper(),
                            ((RepuestoReparacion)factura.Reparacion.DetalleCargas[i]).PrecioUnitario.ToString("0.00"),
                            ((RepuestoReparacion)factura.Reparacion.DetalleCargas[i]).PrecioTotal.ToString("0.00"),
                            ((RepuestoReparacion)factura.Reparacion.DetalleCargas[i]).PrecioTotal.ToString("0.00")
                            );
                    }
                    else
                    {
                        dsFactura.TablaRepuestos.Rows.Add(
                            ((RepuestoReparacion)factura.Reparacion.DetalleCargas[i]).CantidadRequerida.ToString(),
                            ((RepuestoReparacion)factura.Reparacion.DetalleCargas[i]).CodigoRepuesto.ToString().ToUpper(),
                            ((RepuestoReparacion)factura.Reparacion.DetalleCargas[i]).DescripcionRepuesto.ToString().ToUpper(),
                            ((RepuestoReparacion)factura.Reparacion.DetalleCargas[i]).PrecioUnitario.ToString("0.00"),
                            ((RepuestoReparacion)factura.Reparacion.DetalleCargas[i]).PrecioTotal.ToString("0.00"),
                            ((RepuestoReparacion)factura.Reparacion.DetalleCargas[i]).PrecioTotal.ToString("0.00")
                            );
                    }
                }
            }

            if (factura.Reparacion.DetalleTarea.Count != 0)
            {
                for (int i = 0; i < factura.Reparacion.DetalleTarea.Count; i++)
                {
                    dsFactura.TablaRepuestos.Rows.Add(
                        1,
                        "",
                        ((TareaReparacion)factura.Reparacion.DetalleTarea[i]).DescripcionTarea.ToString().ToUpper(),
                        ((TareaReparacion)factura.Reparacion.DetalleTarea[i]).CostoTotal.ToString("0.00"),
                        ((TareaReparacion)factura.Reparacion.DetalleTarea[i]).Costo.ToString("0.00"),
                        ((TareaReparacion)factura.Reparacion.DetalleTarea[i]).Costo.ToString("0.00")
                        );
                }
            }

            if((factura.Reparacion.DetalleRepuestos.Count+factura.Reparacion.DetalleCargas.Count+factura.Reparacion.DetalleTarea.Count)<9)
            {
                int items=9-(factura.Reparacion.DetalleRepuestos.Count+factura.Reparacion.DetalleCargas.Count+factura.Reparacion.DetalleTarea.Count);
                for (int i = 0; i < items; i++)
                {
                    dsFactura.TablaRepuestos.Rows.Add(
                            "",
                            "",
                            "",
                            "",
                            "",
                            ""
                            );
                }
            }

            ReportDocument oRep = new ReportDocument();

            try
            {
                oRep.Load("../../CrystalReport1.rpt");
            }
            catch
            {
                oRep.Load("./Informes/CrystalReport1.rpt");
            }

 
            oRep.SetDataSource(dsFactura);

            //this.printCrystalReport(oRep, 1, 1, 1, this.impresoraPredeterminada());

            //oRep.PrintOptions.PrinterName = this.impresoraPredeterminada();
            //oRep.PrintToPrinter(2, false, 0, 0);

            frmImprimirReporte fr = new frmImprimirReporte(oRep);
            fr.MdiParent = this.MdiParent;
            fr.Show();
        }

        private void imprimirFacturaVenta()
        {
            dsIngresos dsFactura = new dsIngresos();

            if (((Iva)this.comboBoxIva.SelectedItem).PorcentajeIva == 10.5)
            {

                dsFactura.Factura.Rows.Add(
                    this.dateTimePickerFactura.Value.ToShortDateString(),//fechafactura
                    factura.NumeroFactura,//numerofactura
                    factura.ImporteFactura.ToString().Insert(0, "$ "),//importefactura
                    factura.TipoFactura,//tipofactura
                    factura.Cliente.NombreRazonSocial,//nombrerazonsocial
                    factura.Cliente.Cuit,//cuit
                    factura.Cliente.Direccion,//direccion
                    factura.IvaFactura.CondicionIva,//condicioniva
                    (factura.Bonificacion + factura.Reparacion.ImporteTotal).ToString("0.00").Insert(0, "$"),//importe sin iva
                    this.textBoxIva.Text,//iva 10.5% factura
                    factura.Bonificacion.ToString("0.00").Insert(0, "$ "), //bonificacion en pesos
                    this.textBoxSubtotal.Text,//subtotal sin iva y bonificado
                    "",//iva 21%
                    factura.Reparacion.CodigoReparacion//codigo OT
                    );
            }
            else
            {
                dsFactura.Factura.Rows.Add(
                    this.dateTimePickerFactura.Value.ToShortDateString(),//fechafactura
                    factura.NumeroFactura,//numerofactura
                    factura.ImporteFactura.ToString().Insert(0, "$ "),//importefactura
                    factura.TipoFactura,//tipofactura
                    factura.Cliente.NombreRazonSocial,//nombrerazonsocial
                    factura.Cliente.Cuit,//cuit
                    factura.Cliente.Direccion,//direccion
                    factura.IvaFactura.CondicionIva,//condicioniva
                    (factura.Bonificacion + factura.Reparacion.ImporteTotal).ToString("0.00").Insert(0, "$"),//importe sin iva
                    "",//iva 10.5%
                    factura.Bonificacion.ToString("0.00").Insert(0, "$ "), //bonificacion en pesos
                    this.textBoxSubtotal.Text,//subtotal sin iva y bonificado
                    this.textBoxIva.Text,//iva 21% factura
                    factura.Reparacion.CodigoReparacion//codigo OT
                    );
            }

            //Los pongo vacios porque en una Venta de Respuestos no se utilizan estos datos
            dsFactura.Vehiculo.Rows.Add(
                "",//Dominio
                "",//Modelo
                "",//Marca
                "" //Anio
                );

            if (factura.VentaRepuesto.DetalleRepuestos.Count != 0)
            {
                for (int i = 0; i < factura.VentaRepuesto.DetalleRepuestos.Count; i++)
                {
                    dsFactura.TablaRepuestos.Rows.Add(
                        ((RepuestoReparacion)factura.VentaRepuesto.DetalleRepuestos[i]).CantidadRequerida.ToString(),
                        ((RepuestoReparacion)factura.VentaRepuesto.DetalleRepuestos[i]).CodigoRepuesto.ToString().ToUpper(),
                        ((RepuestoReparacion)factura.VentaRepuesto.DetalleRepuestos[i]).DescripcionRepuesto.ToString().ToUpper(),
                        ((RepuestoReparacion)factura.VentaRepuesto.DetalleRepuestos[i]).PrecioUnitario.ToString("0.00"),
                        ((RepuestoReparacion)factura.VentaRepuesto.DetalleRepuestos[i]).PrecioTotal.ToString("0.00"),
                        ((RepuestoReparacion)factura.VentaRepuesto.DetalleRepuestos[i]).PrecioTotal.ToString("0.00")
                        );
                }
            }


            if (factura.VentaRepuesto.DetalleRepuestos.Count < 9)
            {
                int items = 9 - factura.VentaRepuesto.DetalleRepuestos.Count;
                for (int i = 0; i < items; i++)
                {
                    dsFactura.TablaRepuestos.Rows.Add(
                            "",
                            "",
                            "",
                            "",
                            "",
                            ""
                            );
                }
            }

            ReportDocument oRep = new ReportDocument();

            try
            {
                //oRep.Load("E:/DOCUMENTOS GABRIEL/Documentos/Visual Studio 2010/Projects/SistemaGestionTaller/SistemaGestionTaller/CrystalReport1.rpt");
                oRep.Load("E:\\DOCUMENTOS GABRIEL\\Mis documentos\\GitHub\\lukatorepo\\SistemaGestionTaller\\CrystalReport1.rpt");
            }
            catch
            {
                oRep.Load("./Informes/CrystalReport1.rpt");
            }


            oRep.SetDataSource(dsFactura);

            //this.printCrystalReport(oRep, 1, 1, 1, this.impresoraPredeterminada());

            //oRep.PrintOptions.PrinterName = this.impresoraPredeterminada();
            //oRep.PrintToPrinter(2, false, 0, 0);

            frmImprimirReporte fr = new frmImprimirReporte(oRep);
            fr.MdiParent = this.MdiParent;
            fr.Show();
        }

        private void printCrystalReport(CrystalDecisions.CrystalReports.Engine.ReportDocument aoReport,
                                int aiNumCopias, int aiPageBegin, int aiPageEnd, String asPrinterName)
        {
            if (asPrinterName == String.Empty)
            {
                //            Buscamos la impresora por defecto del sistema
                System.Drawing.Printing.PrintDocument printDoc = new System.Drawing.Printing.PrintDocument();
                asPrinterName = printDoc.PrinterSettings.PrinterName;
            }

            aoReport.PrintOptions.PrinterName = asPrinterName;
            aoReport.PrintToPrinter(aiNumCopias, false, aiPageBegin, aiPageEnd);
        }

        private void imprimirPago(ArrayList colRowindex)
        {
            dsIngresos dsPago = new dsIngresos();

            for (int i = 0; i < colRowindex.Count; i++ )
            {
                dsPago.Pago.Rows.Add(
                    DateTime.Parse(this.pagosDataGridView2.Rows[(int)colRowindex[i]].Cells["fechapago"].Value.ToString()).ToShortDateString(),
                    Convert.ToInt32(this.pagosDataGridView2.Rows[(int)colRowindex[i]].Cells["numeropago"].Value),
                    Convert.ToDouble(this.pagosDataGridView2.Rows[(int)colRowindex[i]].Cells["importepago"].Value.ToString()).ToString("0.00").Insert(0, "$"),
                    this.pagosDataGridView2.Rows[(int)colRowindex[i]].Cells["mediopago"].Value.ToString(),
                    this.pagosDataGridView2.Rows[(int)colRowindex[i]].Cells["banco"].Value.ToString(),
                    this.pagosDataGridView2.Rows[(int)colRowindex[i]].Cells["numerocheque"].Value.ToString(),
                    this.pagosDataGridView2.Rows[(int)colRowindex[i]].Cells["observaciones"].Value.ToString()
                    );
            }

            dsPago.Factura.Rows.Add(
                this.dateTimePickerFactura.Value,
                factura.NumeroFactura,
                factura.Saldo.ToString().Insert(0,"$ "),
                factura.TipoFactura,
                factura.Cliente.NombreRazonSocial,
                factura.Cliente.Cuit,
                factura.Cliente.Direccion,
                "",
                "",
                "",
                ""
                );

            try
            {
                dsPago.Vehiculo.Rows.Add(
                    factura.Reparacion.Vehiculo.Dominio,
                    factura.Reparacion.Vehiculo.Marca,
                    factura.Reparacion.Vehiculo.Modelo
                    );
            }
            catch
            {
                dsPago.Vehiculo.Rows.Add(
                    "",
                    "",
                    ""
                    );
            }

            ReportDocument oRep = new ReportDocument();
            try
            {
                oRep.Load("E:\\DOCUMENTOS DE GABRIEL\\Documentos\\Visual Studio 2010\\Projects\\SistemaGestionTaller\\SistemaGestionTaller\\crReciboPago.rpt");
            }
            catch
            {
                oRep.Load("./Informes/crReciboPago.rpt");
            }

            oRep.SetDataSource(dsPago);
            oRep.PrintOptions.PrinterName = this.impresoraPredeterminada();

            frmImprimirReporte fr = new frmImprimirReporte(oRep);
            fr.MdiParent = this.MdiParent;
            fr.Show();
        }

        private void clickGuardar()
        {
            if (flagVenta)
            {
                //VENTA DE REPUESTO
                if (factura.getFacturaVenta())
                {
                    //LA FACTURA YA EXISTE Y VAMOS A CARGAR NUEVOS PAGOS
                    factura.Saldo = Convert.ToDouble(this.textBoxSaldo.Text.Replace("$", ""));
                    factura.EstadoFactura = 0;
                    factura.actualizarVenta();

                    MessageBox.Show("Factura actualizada con éxito.", "Información");

                    //CAMBIAMOS EL NOMBRE DEL BOTON GUARDAR PARA GUIAR AL USUARIO
                    this.buttonGuardar.Text = "Terminar";
                    this.buttonGuardar.TextAlign = ContentAlignment.MiddleCenter;
                    this.buttonGuardar.Image = null;
                    //this.flagPestania = true;
                }
                else
                {
                    if (this.textBoxCodigoFactura.Text != "")
                    {
                        //CREAMOS POR 1RA VEZ LA FACTURA
                        factura.FechaFactura = this.dateTimePickerFactura.Value;
                        factura.Saldo = Convert.ToDouble(this.facturaTextBoxTotal.Text.Replace("$", ""));
                        factura.EstadoFactura = 0;
                        factura.TipoFactura = this.comboBoxTipoFactura.Text;
                        factura.NumeroFactura = this.textBoxCodigoFactura.Text.ToUpper();

                        factura.agregarVenta();

                        //Indicamos que esa venta ya fue facturada
                        factura.VentaRepuesto.EstadoVenta = 1;
                        factura.VentaRepuesto.actualizar();

                        MessageBox.Show("Factura guardada con éxito.", "Información");

                        //CAMBIAMOS EL NOMBRE DEL BOTON GUARDAR PARA GUIAR AL USUARIO
                        this.buttonGuardar.Text = "Terminar";
                        this.buttonGuardar.TextAlign = ContentAlignment.MiddleCenter;
                        this.buttonGuardar.Image = null;
                        //this.flagPestania = true;
                    }
                    else
                    {
                        MessageBox.Show("Debe colocar el número de factura correspondiente.", "Información");
                        return;
                    }
                }
            }
            else
            {
                //REPARACION
                if (factura.getFacturaReparacion())
                {
                    //LA FACTURA YA EXISTE Y VAMOS A CARGAR NUEVOS PAGOS
                    factura.Saldo = Convert.ToDouble(this.textBoxSaldo.Text.Replace("$", ""));
                    factura.EstadoFactura = 0;
                    factura.actualizarReparacion();

                    MessageBox.Show("Factura actualizada con éxito.", "Información");

                    //CAMBIAMOS EL NOMBRE DEL BOTON GUARDAR PARA GUIAR AL USUARIO
                    this.buttonGuardar.Text = "Terminar";
                    this.buttonGuardar.TextAlign = ContentAlignment.MiddleCenter;
                    this.buttonGuardar.Image = null;
                    //this.flagPestania = true;
                }
                else
                {
                    if (this.textBoxCodigoFactura.Text != "")
                    {
                        //CREAMOS POR 1RA VEZ LA FACTURA
                        factura.FechaFactura = this.dateTimePickerFactura.Value;
                        factura.Saldo = Convert.ToDouble(this.facturaTextBoxTotal.Text.Replace("$", ""));
                        factura.EstadoFactura = 0;
                        factura.TipoFactura = this.comboBoxTipoFactura.Text;
                        factura.NumeroFactura = this.textBoxCodigoFactura.Text.ToUpper();

                        factura.agregarReparacion();

                        MessageBox.Show("Factura guardada con éxito.", "Información");

                        //CAMBIAMOS EL NOMBRE DEL BOTON GUARDAR PARA GUIAR AL USUARIO
                        this.buttonGuardar.Text = "Terminar";
                        this.buttonGuardar.TextAlign = ContentAlignment.MiddleCenter;
                        this.buttonGuardar.Image = null;
                        //this.flagPestania = true;
                    }
                    else
                    {
                        MessageBox.Show("Debe colocar el número de factura correspondiente.", "Información");
                        return;
                    }
                }
            }
        }

        private void frmFactura_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.actualizarDataGridEvento != null)
                this.actualizarDataGridEvento();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFactura_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void textBoxImportePago_TextChanged(object sender, EventArgs e)
        {
            this.buttonAgregar.Enabled = true;
        }

        private void comboBoxIva_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flagControl)
            {
                this.calcular();
            }
            /*else
            {
                flagControl = true;
            }*/
        }

        private void textBoxBonificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.comprobarNumero(this, e, this.textBoxBonificacion.Text);
            this.calcular();
        }

        private void textBoxBonificacion_TextChanged(object sender, EventArgs e)
        {
            this.calcular();
        }

        private void buttonImprimir_Click(object sender, EventArgs e)
        {
            ArrayList colRowIndex = new ArrayList();

            foreach (DataGridViewRow row in this.pagosDataGridView2.Rows)
            {
                if (Convert.ToBoolean(row.Cells["seleccionado"].Value) == true)
                {
                    colRowIndex.Add((int)row.Index);
                }
            }
            if (colRowIndex.Count != 0)
                this.imprimirPago(colRowIndex);
            else
            {
                MessageBox.Show("Debe seleccionar al menos un pago para imprimir.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (DataGridViewRow row in this.pagosDataGridView2.Rows)
            {
                row.Cells["seleccionado"].Value = false;
            }
        }

        private void buttonImprimirFactura_Click(object sender, EventArgs e)
        {
            if (flagVenta)
            {
                this.imprimirFacturaVenta();
            }
            else
            {
                this.imprimirFactura();
            }
        }

        private void comboBoxTipoFactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.calcular();
            this.llenarDetalleFactura();
        }

    }

}
