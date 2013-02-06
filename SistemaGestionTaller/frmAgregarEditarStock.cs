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
    public partial class frmAgregarEditarStock : Form
    {
        private Proveedor proveedor;
        private ArrayList colRepuestosAgregados;
        private Repuesto repuesto;

        public frmAgregarEditarStock()
        {
            InitializeComponent();
        }

        private void frmAgregarEditarStock_Load(object sender, EventArgs e)
        {
            proveedor = new Proveedor();
            repuesto = new Repuesto();
            colRepuestosAgregados = new ArrayList();
            this.buttonEliminarRepuesto.Enabled = false;
            this.buttonAgregarRepuesto.Enabled = false;
            this.buttonNuevoRepuesto.Enabled = false;
            this.buttonBuscarRepuesto.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAgregarEditarRepuestoStock faer = new frmAgregarEditarRepuestoStock(proveedor.Id, this.dateTimePicker1.Value);
            faer.RepuestoEncontrado += new frmAgregarEditarRepuestoStock.BuscarRepuestoHandler(fbr_RepuestoEncontrado);
            faer.MdiParent = this.MdiParent;
            faer.Show();

            this.buttonAgregarRepuesto.Focus();
        }

        private void buttonProveedor_Click(object sender, EventArgs e)
        {
            this.proveedor.Id = 0;
            this.proveedor.NombreRazonSocial = "";
            this.proveedor.Repuestos.RemoveRange(0, proveedor.Repuestos.Count);

            frmBuscarProveedor fbp = new frmBuscarProveedor();
            fbp.ProveedorEncontrado += new frmBuscarProveedor.BuscarProveedorHandler(fbp_ProveedorEncontrado);
            fbp.MdiParent = this.MdiParent;
            fbp.Show();

        }

        void fbp_ProveedorEncontrado(object sender, BuscarProveedorEventArgs e)
        {
            proveedor.Id = e.IdProveedor;
            proveedor.getDatosProveedor();

            this.textBoxProveedor.Text = proveedor.NombreRazonSocial;
            if (proveedor.Id != 0)
            {
                this.buttonBuscarRepuesto.Enabled = true;
            }
        }

        private void buttonBuscarRepuesto_Click(object sender, EventArgs e)
        {
            frmBuscarRepuestoStock fbr = new frmBuscarRepuestoStock(colRepuestosAgregados, proveedor.Id);
            fbr.RepuestoEncontrado += new frmBuscarRepuestoStock.BuscarRepuestoHandler(fbr_RepuestoEncontrado);
            fbr.MdiParent = this.MdiParent;
            fbr.Show();
        }

        void fbr_RepuestoEncontrado(object sender, BuscarRepuestoEventArgs e)
        {
            repuesto = (Repuesto)e.Repuesto;
            repuesto.getDatosRepuesto();
            this.textRepuesto.Text = repuesto.ToString();
            this.buttonAgregarRepuesto.Focus();
            this.buttonEditar.Enabled = true;
        }

        private void llenarDataGrid()
        {
            colRepuestosAgregados.RemoveRange(0, colRepuestosAgregados.Count);
            this.dataGridRepuesto.Rows.Clear();
            for (int i = 0; i < proveedor.Repuestos.Count; i++ )
            {
                this.colRepuestosAgregados.Add(((Repuesto)proveedor.Repuestos[i]).IdRepuesto);
                this.dataGridRepuesto.Rows.Add();
                this.dataGridRepuesto.Rows[i].Cells["idrepuesto"].Value = ((Repuesto)proveedor.Repuestos[i]).IdRepuesto;
                this.dataGridRepuesto.Rows[i].Cells["codigorepuesto"].Value = ((Repuesto)proveedor.Repuestos[i]).CodigoRepuesto;
                this.dataGridRepuesto.Rows[i].Cells["marca"].Value = ((Repuesto)proveedor.Repuestos[i]).Marca;
                this.dataGridRepuesto.Rows[i].Cells["modelo"].Value = ((Repuesto)proveedor.Repuestos[i]).Modelo;
                this.dataGridRepuesto.Rows[i].Cells["descripcionrepuesto"].Value = ((Repuesto)proveedor.Repuestos[i]).DescripcionRepuesto;
                this.dataGridRepuesto.Rows[i].Cells["cantidad"].Value = ((Repuesto)proveedor.Repuestos[i]).CantidadTemp;
                this.dataGridRepuesto.Rows[i].Cells["cantidaddeposito"].Value = ((Repuesto)proveedor.Repuestos[i]).CantidadStock;
                this.dataGridRepuesto.Rows[i].Cells["minimo"].Value = ((Repuesto)proveedor.Repuestos[i]).MinimoStock;
                this.dataGridRepuesto.Rows[i].Cells["costo"].Value = ((Repuesto)proveedor.Repuestos[i]).Costo;
                this.dataGridRepuesto.Rows[i].Cells["preciounitario"].Value = ((Repuesto)proveedor.Repuestos[i]).PrecioUnitario;
            }
            this.dataGridRepuesto.ClearSelection();
        }

        private void buttonAgregarRepuesto_Click(object sender, EventArgs e)
        {
            repuesto.Proveedor.Id = proveedor.Id;
            repuesto.FechaFin = this.dateTimePicker1.Value;

            proveedor.Repuestos.Add(repuesto);
            this.llenarDataGrid();
            this.textRepuesto.ResetText();
        }

        private void dataGridRepuesto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.buttonEliminarRepuesto.Enabled = true;
        }

        private void textBoxProveedor_TextChanged(object sender, EventArgs e)
        {
            this.buttonBuscarRepuesto.Enabled = true;
            this.buttonNuevoRepuesto.Enabled = true;
        }

        private void textRepuesto_TextChanged(object sender, EventArgs e)
        {
            this.buttonAgregarRepuesto.Enabled = true;
        }

        private void dataGridRepuesto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //DEBE CAMBIAR EL ASPECTO DEL BOTON POR CUALQUIER CAMBIO
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (this.buttonGuardar.Text == "Terminar")
            {
                this.Close();
                return;
            }

            //BUSCAMOS EN LA COLECCION PROVEEDORES Y PONEMOS LOS DETALLES DE LOS REPUESTOS
            for (int i = 0; i < proveedor.Repuestos.Count; i++ )
            {
                for (int j = 0; j < dataGridRepuesto.Rows.Count; j++)
                {
                    if (((Repuesto)proveedor.Repuestos[i]).IdRepuesto == (int)this.dataGridRepuesto.Rows[j].Cells["idrepuesto"].Value)
                    {
                        if (this.dataGridRepuesto.Rows[j].Cells["cantidad"].Value != null)
                            ((Repuesto)proveedor.Repuestos[i]).CantidadStock += Double.Parse(this.dataGridRepuesto.Rows[j].Cells["cantidad"].Value.ToString());
                        else
                            ((Repuesto)proveedor.Repuestos[i]).CantidadStock = ((Repuesto)proveedor.Repuestos[i]).CantidadStock;
                        /*((Repuesto)proveedor.Repuestos[i]).MinimoStock = Double.Parse(this.dataGridRepuesto.Rows[j].Cells["minimo"].Value.ToString());
                        ((Repuesto)proveedor.Repuestos[i]).Costo = Double.Parse(this.dataGridRepuesto.Rows[j].Cells["costo"].Value.ToString());
                        ((Repuesto)proveedor.Repuestos[i]).PrecioUnitario = Double.Parse(this.dataGridRepuesto.Rows[j].Cells["preciounitario"].Value.ToString());*/
                        break;
                    }
                }
            }

            //GUARDAMOS EN LA BASE DE DATOS
            try
            {
                for (int i = 0; i < proveedor.Repuestos.Count; i++)
                {
                    if (((Repuesto)proveedor.Repuestos[i]).existeRepuesto())
                    {
                        ((Repuesto)proveedor.Repuestos[i]).actualizar();

                    }
                    else
                    {
                        ((Repuesto)proveedor.Repuestos[i]).agregar();
                    }

                }

                MessageBox.Show("Carga de stock EXISTOSA", "INFORMACION");
                this.buttonGuardar.Text = "Terminar";
                this.buttonGuardar.TextAlign = ContentAlignment.MiddleCenter;
                this.buttonGuardar.Image = null;
                //this.llenarDataGrid();
            }
            catch (MySql.Data.MySqlClient.MySqlException error)
            {
                MessageBox.Show("Error: " + error, "ERROR");
                return;
            }
        }

        private void buttonEliminarRepuesto_Click(object sender, EventArgs e)
        {
            int r = this.dataGridRepuesto.CurrentCell.RowIndex;
            int idRepuesto = Convert.ToInt32(this.dataGridRepuesto.Rows[r].Cells["idrepuesto"].Value);

            //BUSCAMOS EN LA COLECCION PROVEEDORES Y ELIMINAMOS
            for (int i = 0; i < proveedor.Repuestos.Count; i++)
            {
                if (((Repuesto)proveedor.Repuestos[i]).IdRepuesto == idRepuesto)
                {
                    proveedor.Repuestos.RemoveAt(i);
                    break;
                }
            }

            //ELIMINAMOS ID DEL LISTADO QUE PASAMOS PARA EVITAR REPUESTOS DUPLICADOS
            for (int i = 0; i < colRepuestosAgregados.Count; i++)
            {
                colRepuestosAgregados.RemoveAt(colRepuestosAgregados.IndexOf(this.dataGridRepuesto.Rows[r].Cells["idrepuesto"].Value));
                //break;
            }

            this.dataGridRepuesto.Rows.RemoveAt(r);

            llenarDataGrid();
        }

        private void dataGridRepuesto_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //CANTIDAD ENTRADA
            if(e.ColumnIndex == 5)
            {
                for (int i = 0; i < proveedor.Repuestos.Count; i++)
                {
                    if(((Repuesto)proveedor.Repuestos[i]).IdRepuesto == (int)this.dataGridRepuesto.Rows[e.RowIndex].Cells["idrepuesto"].Value)
                    {
                        ((Repuesto)proveedor.Repuestos[i]).CantidadTemp = Double.Parse(this.dataGridRepuesto.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        //this.llenarDataGrid();
                        break;
                    }
                }
                return;
            }
            //MINIMO
            else if (e.ColumnIndex == 7)
            {
                for (int i = 0; i < proveedor.Repuestos.Count; i++)
                {
                    if (((Repuesto)proveedor.Repuestos[i]).IdRepuesto == (int)this.dataGridRepuesto.Rows[e.RowIndex].Cells["idrepuesto"].Value)
                    {
                        ((Repuesto)proveedor.Repuestos[i]).MinimoStock = Double.Parse(this.dataGridRepuesto.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        //this.llenarDataGrid();
                        break;
                    }
                }
                return;
            }
            //COSTO
            else if (e.ColumnIndex == 8)
            {
                for (int i = 0; i < proveedor.Repuestos.Count; i++)
                {
                    if (((Repuesto)proveedor.Repuestos[i]).IdRepuesto == (int)this.dataGridRepuesto.Rows[e.RowIndex].Cells["idrepuesto"].Value)
                    {
                        //TIENE SIGNO $
                        if (this.dataGridRepuesto.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Contains('$'))
                        {
                            //TIENE COMA EN VEZ DE PUNTO
                            if (this.dataGridRepuesto.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Contains(','))
                            {
                                string costocadena = this.dataGridRepuesto.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Replace(",", ".");
                                ((Repuesto)proveedor.Repuestos[i]).Costo = Double.Parse(costocadena.Replace("$", ""));
                                ((Repuesto)proveedor.Repuestos[i]).FechaFin = this.dateTimePicker1.Value;
                            }
                            else
                            {
                                ((Repuesto)proveedor.Repuestos[i]).Costo = Double.Parse(this.dataGridRepuesto.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Replace("$", ""));
                                ((Repuesto)proveedor.Repuestos[i]).FechaFin = this.dateTimePicker1.Value;
                            }
                        }
                        else
                        {
                            ((Repuesto)proveedor.Repuestos[i]).Costo = Double.Parse(this.dataGridRepuesto.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                            ((Repuesto)proveedor.Repuestos[i]).FechaFin = this.dateTimePicker1.Value;
                        }
                        //this.llenarDataGrid();
                        break;
                    }
                }
                //this.llenarDataGrid();
                return;
            }
            //PRECIO UNITARIO
            else if (e.ColumnIndex == 9)
            {
                for (int i = 0; i < proveedor.Repuestos.Count; i++)
                {
                    if (((Repuesto)proveedor.Repuestos[i]).IdRepuesto == (int)this.dataGridRepuesto.Rows[e.RowIndex].Cells["idrepuesto"].Value)
                    {
                        //TIENE SIGNO $
                        if (this.dataGridRepuesto.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Contains('$'))
                        {
                            //TIENE COMA EN VEZ DE PUNTO
                            if (this.dataGridRepuesto.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Contains(','))
                            {
                                string preciocadena;
                                preciocadena = this.dataGridRepuesto.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Replace(",", ".");
                                ((Repuesto)proveedor.Repuestos[i]).PrecioUnitario = Double.Parse(preciocadena.Replace("$", ""));
                                ((Repuesto)proveedor.Repuestos[i]).FechaFin = this.dateTimePicker1.Value;
                            }
                            else
                            {
                                ((Repuesto)proveedor.Repuestos[i]).PrecioUnitario = Double.Parse(this.dataGridRepuesto.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Replace("$", ""));
                                ((Repuesto)proveedor.Repuestos[i]).FechaFin = this.dateTimePicker1.Value;
                            }
                        }
                        else
                        {
                            ((Repuesto)proveedor.Repuestos[i]).PrecioUnitario = Double.Parse(this.dataGridRepuesto.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                            ((Repuesto)proveedor.Repuestos[i]).FechaFin = this.dateTimePicker1.Value;
                        }
                        //this.llenarDataGrid();
                        break;
                    }
                }
                this.llenarDataGrid();
                return;
            }
            
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            frmAgregarEditarRepuestoStock faer = new frmAgregarEditarRepuestoStock(proveedor.Id, this.repuesto.IdRepuesto);
            faer.RepuestoEncontrado += new frmAgregarEditarRepuestoStock.BuscarRepuestoHandler(fbr_RepuestoEncontrado);
            faer.MdiParent = this.MdiParent;
            faer.Show();
        }

        
    }
}
