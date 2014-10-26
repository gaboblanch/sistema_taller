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
    public partial class frmAgregarEditarRepuestoUnico : Form
    {
        private Repuesto repuesto;
        private TipoRepuesto tiporepuesto;

        private bool flagEditar;
        private bool flagTipo;
        private int idRepuesto;

        private int idProveedor=-1;

        //DELEGADO Y EVENTO PARA ACTUALIZAR GRILLA EN frmGestionCliente
        public delegate void actualizarDataGrid();
        public event actualizarDataGrid actualizarDataGridEvento;

        public frmAgregarEditarRepuestoUnico()
        {
            InitializeComponent();
        }

        public frmAgregarEditarRepuestoUnico(int idRepuesto_p)
        {
            InitializeComponent();
            flagEditar = true;
            idRepuesto = idRepuesto_p;
        }

        private void llenarComboTipo()
        {
            ArrayList colTipo = new ArrayList();
            colTipo = tiporepuesto.coleccionTodos();

            this.comboTipo.Items.Clear();

            for (int i = 0; i < colTipo.Count; i++)
            {
                TipoRepuesto objTipoLocal = new TipoRepuesto();
                objTipoLocal = (TipoRepuesto)colTipo[i];

                this.comboTipo.Items.Add(objTipoLocal);
            }
        }

        private void llenarComboMarca()
        {
            MarcaModelo objMarca = new MarcaModelo();
            ArrayList colMarca = new ArrayList();
            colMarca = objMarca.coleccionMarca();

            this.textMarca.Items.Clear();

            for (int i = 0; i < colMarca.Count; i++)
            {
                this.textMarca.Items.Add(((MarcaModelo)colMarca[i]).Marca);
            }
        }

        private void llenarComboModelo()
        {
            MarcaModelo objModelo = new MarcaModelo();
            ArrayList colModelo = new ArrayList();
            colModelo = objModelo.coleccionModelo();

            this.textModelo.Items.Clear();

            for (int i = 0; i < colModelo.Count; i++)
            {
                this.textModelo.Items.Add(((MarcaModelo)colModelo[i]).Modelo);
            }
        }

        private void llenarDataGrid()
        {
            ArrayList colHistorial = new ArrayList();
            colHistorial = repuesto.getHistorial();
            this.dataGridViewHistorial.Rows.Clear();

            //AGREGAR COLUMNAS
            int c = 1; //contador columna
            foreach (object o in colHistorial)
            {
                string colname="";
                colname = "columna"+c;
                c++;
                this.dataGridViewHistorial.Columns.Add(colname, String.Format("{0:MMMMMMMMM}", ((HistorialPrecio)o).FechaInicio).ToUpper());
            }

            foreach (DataGridViewColumn col in this.dataGridViewHistorial.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }

            //AGREGAR FILAS
            for (int i = 0; i < 3; i++)
            {
                this.dataGridViewHistorial.Rows.Add();
            }

            for (int j = 0; j < colHistorial.Count; j++)
            {
                foreach (DataGridViewRow row in this.dataGridViewHistorial.Rows)
                {
                    this.dataGridViewHistorial.Rows[0].Cells["columna" + (j + 1)].Value = ((HistorialPrecio)colHistorial[j]).Precio.ToString().Insert(0,"$");
                    this.dataGridViewHistorial.Rows[1].Cells["columna" + (j + 1)].Value = ((HistorialPrecio)colHistorial[j]).Costo.ToString().Insert(0, "$");
                    this.dataGridViewHistorial.Rows[2].Cells["columna" + (j + 1)].Value = ((HistorialPrecio)colHistorial[j]).Porcentaje.ToString("0.00")+"%";
                }
            }

            this.dataGridViewHistorial.ClearSelection();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (this.buttonGuardar.Text == "Terminar")
            {
                if (actualizarDataGridEvento != null)
                {
                    this.actualizarDataGridEvento();
                }
                
                this.Close();
                return;
            }

            //REVISAMOS QUE ESTEN COMPLETOS TODOS LOS DATOS
            if (repuesto.Proveedor.Id != -1 && flagTipo && textCosto.Text != "" && textMinimo.Text != "" && textPrecio.Text != "")
            {
                repuesto.Idtipo = ((TipoRepuesto)this.comboTipo.SelectedItem).Idtipo;
                repuesto.Proveedor.Id = idProveedor;
                repuesto.CodigoRepuesto = this.textCodigo.Text.ToUpper();
                repuesto.DescripcionRepuesto = this.textDescripcion.Text;
                repuesto.Marca = textMarca.Text.ToUpper();
                repuesto.Modelo = textModelo.Text.ToUpper();
                repuesto.Costo = Convert.ToDouble(textCosto.Text);
                if (textCantidad.Text!="")
                    repuesto.CantidadStock = Convert.ToDouble(textCantidad.Text)+Convert.ToDouble(textStockDisponible.Text);
                else
                    repuesto.CantidadStock = Convert.ToDouble(textStockDisponible.Text);
                repuesto.MinimoStock = Convert.ToDouble(textMinimo.Text);
                repuesto.PrecioUnitario = Convert.ToDouble(textPrecio.Text);
                repuesto.FechaFin = DateTime.Now;
            }
            else
            {
                MessageBox.Show("Compruebe que todos los datos han sido ingresados.","Error");
                return;
            }

            if (flagEditar)
            {
                repuesto.actualizar();
                //this.actualizarDataGridEvento();
                if (textCantidad.Text != "")
                    this.textStockDisponible.Text = (Convert.ToInt32(this.textCantidad.Text) + Convert.ToInt32(this.textStockDisponible.Text)).ToString();
                else
                    this.textStockDisponible.Text = (Convert.ToInt32(this.textStockDisponible.Text)).ToString();

                //CAMBIAMOS BOTON GUARDAR
                this.buttonGuardar.Text = "Terminar";
                this.buttonGuardar.TextAlign = ContentAlignment.MiddleCenter;
                this.buttonGuardar.Image = null;
            }
            else
            {
                if (!repuesto.existeRepuesto())
                {
                    repuesto.agregar();
                    
                    this.textStockDisponible.Text = (Convert.ToInt32(this.textCantidad.Text) + Convert.ToInt32(this.textStockDisponible.Text)).ToString();
                    this.textCantidad.Text = "";

                    //CAMBIAMOS BOTON GUARDAR
                    this.buttonGuardar.Text = "Terminar";
                    this.buttonGuardar.TextAlign = ContentAlignment.MiddleCenter;
                    this.buttonGuardar.Image = null;
                }
                else
                {
                    MessageBox.Show("El repuesto ya existe.","Advertencia");
                }
            }
        }

        private void frmAgregarEditarRespuesto_Load(object sender, EventArgs e)
        {
            tiporepuesto = new TipoRepuesto();
            llenarComboTipo();
            
            llenarComboMarca();
            llenarComboModelo();

            repuesto = new Repuesto();

            this.FormLoad();
        }

        private void FormLoad()
        {
            if (flagEditar)
            {
                //CARGAR DATOS DEL REPUESTO
                repuesto.IdRepuesto = idRepuesto;
                repuesto.getDatosRepuesto();
                llenarDataGrid();

                //LLENAR FORMULARIO
                this.comboTipo.Text = repuesto.DescripcionTipo;
                this.textCodigo.Text = repuesto.CodigoRepuesto.ToUpper();
                this.textMarca.Text = repuesto.Marca.ToUpper();
                this.textModelo.Text = repuesto.Modelo.ToUpper();
                this.textBoxProveedor.Text = repuesto.Proveedor.NombreRazonSocial;
                this.idProveedor = repuesto.Proveedor.Id;
                this.textPrecio.Text = repuesto.PrecioUnitario.ToString();
                this.textCosto.Text = repuesto.Costo.ToString();
                this.textStockDisponible.Text = repuesto.CantidadStock.ToString();
                this.textMinimo.Text = repuesto.MinimoStock.ToString();
                this.textDescripcion.Text = repuesto.DescripcionRepuesto;


                //CAMBIAMOS BOTON GUARDAR
                this.buttonGuardar.Text = "Terminar";
                this.buttonGuardar.TextAlign = ContentAlignment.MiddleCenter;
                this.buttonGuardar.Image = null;
            }
        }

        //BUSCAR PROVEEDOR
        private void buttonProveedor_Click(object sender, EventArgs e)
        {
            frmBuscarProveedor fbp = new frmBuscarProveedor();
            fbp.ProveedorEncontrado += new frmBuscarProveedor.BuscarProveedorHandler(fbp_ProveedorEncontrado);
            fbp.MdiParent = this.MdiParent;
            fbp.Show();
        }

        //MANEJO DE LOS DATOS DEL PROVEEDOR
        void fbp_ProveedorEncontrado(object sender, BuscarProveedorEventArgs e)
        {
            idProveedor = e.IdProveedor;
            this.textBoxProveedor.Text = e.RazonSocialProveedor;
        }

        private void comboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboTipo.Text != "")
            {
                flagTipo = true;
            }
            else
            {
                flagTipo = false;
            }
        }

        private void textMarca_TextChanged(object sender, EventArgs e)
        {
            //ASPECTO ORIGINAL DEL BOTON GUARDAR
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        }

        private void textModelo_TextChanged(object sender, EventArgs e)
        {
            //ASPECTO ORIGINAL DEL BOTON GUARDAR
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        }

        private void textPrecio_TextChanged(object sender, EventArgs e)
        {
            //ASPECTO ORIGINAL DEL BOTON GUARDAR
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        }

        private void textCosto_TextChanged(object sender, EventArgs e)
        {
            //ASPECTO ORIGINAL DEL BOTON GUARDAR
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        }

        private void textCantidad_TextChanged(object sender, EventArgs e)
        {
            //ASPECTO ORIGINAL DEL BOTON GUARDAR
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        }

        private void textMinimo_TextChanged(object sender, EventArgs e)
        {
            //ASPECTO ORIGINAL DEL BOTON GUARDAR
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        }

        private void textBoxProveedor_TextChanged(object sender, EventArgs e)
        {
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

        private void buttonTipo_Click(object sender, EventArgs e)
        {
            frmTipoRepuesto fgtr = new frmTipoRepuesto(true);
            fgtr.actualizarComboBoxEvento += new frmTipoRepuesto.actualizarComboBox(llenarComboTipo);
            fgtr.MdiParent = this.MdiParent;
            fgtr.Show();
        }

        private void textCantidad_TextChanged_1(object sender, EventArgs e)
        {
            //ASPECTO ORIGINAL DEL BOTON GUARDAR
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        }

        //SOLO PERMITE EL INGRESO DE NUMEROS Y UNA COMA
        private void comprobarNumero(object sender, KeyPressEventArgs e, String cadena)
        {
            if (cadena.Contains('.'))
            {
                      if(!char.IsDigit(e.KeyChar))
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
                          if(!char.IsDigit(e.KeyChar))
                           {
                                   e.Handled = true;
                            } 

                           if(e.KeyChar=='.' || e.KeyChar=='\b')
                           {
                                    e.Handled = false;
                           }
             }
        }

        private void textMinimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.comprobarNumero(this, e, this.textMinimo.Text);
        }

        private void textCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.comprobarNumero(this, e, this.textCosto.Text);
        }

        private void textPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.comprobarNumero(this, e, this.textPrecio.Text);
        }

        private void textCantidad_TextChanged_2(object sender, EventArgs e)
        {
            //ASPECTO ORIGINAL DEL BOTON GUARDAR
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        }

        private void textCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.comprobarNumero(this, e, this.textCantidad.Text);
        }

        private void buttonDeshacer_Click(object sender, EventArgs e)
        {
            this.FormLoad();
        }



    }
}
