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
    public partial class frmGestionGlobal : Form
    {
        private GlobalEgreso egreso;
        private GlobalIngreso ingreso;
        private GlobalIngreso ingresoEfectivo;
        private GlobalIngreso ingresoCheque;
        private GlobalIngreso ingresoTarjeta;
        private GlobalIngreso ingresoTrans;
        //Ingresos
        private double efectivoIngreso;
        private double bancoIngreso;
        private double chequeIngreso;
        private double globalIngreso;
        private double tarjetaIngreso;
        //Egresos
        private double efectivoEgreso;
        private double bancoEgreso;
        private double chequeEgreso;
        private double globalEgreso;
        //Totales
        private double efectivoTotal;
        private double bancoTotal;
        private double chequeTotal;
        private double globalTotal;
        private double tarjetaTotal;


        public frmGestionGlobal()
        {
            InitializeComponent();
        }

        private void calcularTotales()
        {
            this.textEfectivoTotal.Text = (efectivoTotal + efectivoIngreso-efectivoEgreso).ToString("0.00").Insert(0,"$");
            this.textBancoTotal.Text = (bancoTotal + bancoIngreso - bancoEgreso).ToString("0.00").Insert(0, "$"); ;
            this.textChequeTotal.Text = (chequeTotal + chequeIngreso - chequeEgreso).ToString("0.00").Insert(0, "$"); ;
            this.textGlobalTotal.Text = (globalTotal + globalIngreso - globalEgreso).ToString("0.00").Insert(0, "$"); ;
            this.textTarjetaTotal.Text = (tarjetaTotal + tarjetaIngreso).ToString("0.00").Insert(0, "$"); ;
        }

        private void calcularIngresos()
        {
            efectivoIngreso = 0;
            chequeIngreso = 0;
            globalIngreso = 0;
            bancoIngreso = 0;
            tarjetaIngreso = 0;
            //DATAGRID TAREA
            foreach (DataGridViewRow row in this.dataGridIngreso.Rows)
            {
                if (row.Cells["importeingreso"].Value != null)
                {
                    if (row.Cells["tipoingreso"].Value.ToString() == "EFECTIVO")
                    {
                        efectivoIngreso += (double)row.Cells["importeingreso"].Value;
                    }
                    else if (row.Cells["tipoingreso"].Value.ToString() == "CHEQUE")
                    {
                        chequeIngreso += (double)row.Cells["importeingreso"].Value;
                    }
                    else if (row.Cells["tipoingreso"].Value.ToString() == "GLOBAL")
                    {
                        globalIngreso += (double)row.Cells["importeingreso"].Value;
                    }
                    else if (row.Cells["tipoingreso"].Value.ToString() == "BANCO")
                    {
                        bancoIngreso += (double)row.Cells["importeingreso"].Value;
                    }
                    else if (row.Cells["tipoingreso"].Value.ToString() == "TARJETA")
                    {
                        tarjetaIngreso += (double)row.Cells["importeingreso"].Value;
                    }          
                }
            }

            //Imprimo los valores en los textBoxes
            this.textEfectivoIngreso.Text = efectivoIngreso.ToString("0.00").Insert(0, "$");
            this.textBancoIngreso.Text = bancoIngreso.ToString("0.00").Insert(0, "$");
            this.textChequeIngreso.Text = chequeIngreso.ToString("0.00").Insert(0, "$");
            this.textGlobalIngreso.Text = globalIngreso.ToString("0.00").Insert(0, "$");
            this.textTarjetaIngreso.Text = tarjetaIngreso.ToString("0.00").Insert(0, "$");

        }

        private void calcularEgresos()
        {
            efectivoEgreso = 0;
            chequeEgreso = 0;
            globalEgreso = 0;
            bancoEgreso = 0;

            //DATAGRID TAREA
            foreach (DataGridViewRow row in this.dataGridEgreso.Rows)
            {
                if (row.Cells["importeegreso"].Value != null)
                {
                    if (row.Cells["tipoegreso"].Value.ToString() == "EFECTIVO")
                    {
                        efectivoEgreso += (double)row.Cells["importeegreso"].Value;
                    }
                    else if (row.Cells["tipoegreso"].Value.ToString() == "CHEQUE")
                    {
                        chequeEgreso += (double)row.Cells["importeegreso"].Value;
                    }
                    else if (row.Cells["tipoegreso"].Value.ToString() == "GLOBAL")
                    {
                        globalEgreso += (double)row.Cells["importeegreso"].Value;
                    }
                    else if (row.Cells["tipoegreso"].Value.ToString() == "BANCO")
                    {
                        bancoEgreso += (double)row.Cells["importeegreso"].Value;
                    }
                }
            }

            //Imprimo los valores en los textBoxes
            this.textEfectivoEgreso.Text = efectivoEgreso.ToString("0.00").Insert(0, "$");
            this.textBancoEgreso.Text = bancoEgreso.ToString("0.00").Insert(0, "$");
            this.textChequeEgreso.Text = chequeEgreso.ToString("0.00").Insert(0, "$");
            this.textGlobalEgreso.Text = globalEgreso.ToString("0.00").Insert(0, "$");
        }

        private void llenarIngresos()
        {
            
            this.dataGridIngreso.Rows.Clear();

            ArrayList colIngresos = new ArrayList();

            colIngresos = ingreso.coleccion(
                                            String.Format("{0:yyyy/MM/dd}", dateTimePickerInicio.Value),
                                            String.Format("{0:yyyy/MM/dd}", dateTimePickerInicio.Value));

            ingresoCheque.getIngresosCheque(String.Format("{0:yyyy/MM/dd}", dateTimePickerInicio.Value));
            ingresoEfectivo.getIngresosEfectivo(String.Format("{0:yyyy/MM/dd}", dateTimePickerInicio.Value));
            ingresoTarjeta.getIngresosTarjeta(String.Format("{0:yyyy/MM/dd}", dateTimePickerInicio.Value));
            ingresoTrans.getIngresosTrans(String.Format("{0:yyyy/MM/dd}", dateTimePickerInicio.Value));

            colIngresos.Add(ingresoCheque);
            colIngresos.Add(ingresoEfectivo);
            colIngresos.Add(ingresoTarjeta);
            colIngresos.Add(ingresoTrans);

            for (int i = 0; i < colIngresos.Count; i++)
            {
                this.dataGridIngreso.Rows.Add();
                this.dataGridIngreso.Rows[i].Cells["idingreso"].Value = ((GlobalIngreso)colIngresos[i]).IdIngreso;
                this.dataGridIngreso.Rows[i].Cells["tipoingreso"].Value = ((GlobalIngreso)colIngresos[i]).Tipo;
                this.dataGridIngreso.Rows[i].Cells["descripcioningreso"].Value = "[" + ((GlobalIngreso)colIngresos[i]).Tipo + "] " + ((GlobalIngreso)colIngresos[i]).Descripcion;
                this.dataGridIngreso.Rows[i].Cells["importeingreso"].Value = ((GlobalIngreso)colIngresos[i]).Importe;
                this.dataGridIngreso.Rows[i].Cells["fechaingreso"].Value = ((GlobalIngreso)colIngresos[i]).Fecha.ToShortDateString();
            }

            this.dataGridIngreso.ClearSelection();
            
        }

        private void llenarEgresos()
        {
            this.dataGridEgreso.Rows.Clear();

            ArrayList colEgresos = new ArrayList();

            colEgresos = egreso.coleccion(
                                            String.Format("{0:yyyy/MM/dd}", dateTimePickerInicio.Value),
                                            String.Format("{0:yyyy/MM/dd}", dateTimePickerInicio.Value));

            for (int i = 0; i < colEgresos.Count; i++)
            {
                this.dataGridEgreso.Rows.Add();
                this.dataGridEgreso.Rows[i].Cells["idegreso"].Value = ((GlobalEgreso)colEgresos[i]).IdEgreso;
                this.dataGridEgreso.Rows[i].Cells["tipoegreso"].Value = ((GlobalEgreso)colEgresos[i]).Tipo;
                this.dataGridEgreso.Rows[i].Cells["descripcionegreso"].Value = "[" + ((GlobalEgreso)colEgresos[i]).Tipo + "] " + ((GlobalEgreso)colEgresos[i]).Descripcion;
                this.dataGridEgreso.Rows[i].Cells["importeegreso"].Value = ((GlobalEgreso)colEgresos[i]).Importe;
                this.dataGridEgreso.Rows[i].Cells["fechaegreso"].Value = ((GlobalEgreso)colEgresos[i]).Fecha.ToShortDateString();
            }

            this.dataGridEgreso.ClearSelection();
            
        }

        private void loadForm()
        {
            ArrayList colSumasIngresos = new ArrayList();
            //ArrayList colSumasEgresos = new ArrayList();
            
            //TODO:Buscar optimizar este codigo
            colSumasIngresos = ingreso.coleccionSumasIngresos(String.Format("{0:yyyy/MM/dd}", this.dateTimePickerInicio.Value.AddDays(-1)));
            //colSumasEgresos = egreso.coleccionSumasEgresos(String.Format("{0:yyyy/MM/dd}", this.dateTimePickerInicio.Value.AddDays(-1)));

            /*this.efectivoTotal = ((double)colSumasIngresos[0] - (double)colSumasEgresos[0]);
            this.bancoTotal = ((double)colSumasIngresos[1] - (double)colSumasEgresos[1]);
            this.chequeTotal = ((double)colSumasIngresos[2] - (double)colSumasEgresos[2]);
            this.globalTotal = ((double)colSumasIngresos[3] - (double)colSumasEgresos[3]);
            this.tarjetaTotal = ((double)colSumasIngresos[4] - (double)colSumasEgresos[4]);*/

            this.efectivoTotal = ((double)colSumasIngresos[0]);
            this.bancoTotal = ((double)colSumasIngresos[1]);
            this.chequeTotal = ((double)colSumasIngresos[2]);
            this.globalTotal = ((double)colSumasIngresos[3]);
            this.tarjetaTotal = ((double)colSumasIngresos[4]);


            this.textEfectivoInicio.Text = efectivoTotal.ToString("0.00").Insert(0, "$");
            this.textBancoInicio.Text = bancoTotal.ToString("0.00").Insert(0, "$");
            this.textChequeInicio.Text = chequeTotal.ToString("0.00").Insert(0, "$");
            this.textGlobalInicio.Text = globalTotal.ToString("0.00").Insert(0, "$");
            this.textTarjetaInicio.Text = tarjetaTotal.ToString("0.00").Insert(0, "$");
        }

        //Realiza los llenar datagrid y los calculos en el orden correcto
        private void calcular()
        {
            this.loadForm();
            this.llenarIngresos();
            this.llenarEgresos();

            this.calcularIngresos();
            this.calcularEgresos();

            this.calcularTotales();
        }

        private void frmGestionGlobal_Load(object sender, EventArgs e)
        {
            egreso = new GlobalEgreso();
            ingreso = new GlobalIngreso();

            ingresoEfectivo = new GlobalIngreso();
            ingresoCheque = new GlobalIngreso();
            ingresoTarjeta = new GlobalIngreso();
            ingresoTrans = new GlobalIngreso();

            this.calcular();

            if (this.efectivoTotal == 0 && this.bancoTotal == 0 &&
                this.chequeTotal == 0 && this.globalTotal == 0 && this.tarjetaTotal == 0)
            {
                MessageBox.Show("Debe Inicializar los valores de la caja para continuar.");
                this.soloLectura();
            }
        }

        private void soloLectura()
        {
            foreach (Control control in this.Controls)
            {
                if (control.HasChildren)
                {
                    foreach (Control controlChild in control.Controls)
                    {
                        controlChild.Enabled = false;
                    }
                }
                else if (control is Button)
                {
                    control.Enabled = false;
                }
            }
        }

        private void dateTimePickerInicio_ValueChanged(object sender, EventArgs e)
        {
            this.calcular();
        }

        private void dateTimePickerFin_ValueChanged(object sender, EventArgs e)
        {
            this.calcular();
        }

        private void buttonAgregarIngreso_Click(object sender, EventArgs e)
        {
            frmAgregarEditarIngresoGlobal faeig = new frmAgregarEditarIngresoGlobal();
            faeig.actualizarDataGridEvento += new frmAgregarEditarIngresoGlobal.actualizarDataGrid(calcular);
            //faeig.calcularDataGridEvento += new frmAgregarEditarIngresoGlobal.calcularDataGrid(calcular);
            faeig.MdiParent = this.MdiParent;
            faeig.Show();
        }

        private void buttonEditarIngreso_Click(object sender, EventArgs e)
        {
            int r = this.dataGridIngreso.CurrentCell.RowIndex;

            frmAgregarEditarIngresoGlobal faeig = new frmAgregarEditarIngresoGlobal(Convert.ToInt32(this.dataGridIngreso.Rows[r].Cells["idingreso"].Value));
            faeig.actualizarDataGridEvento += new frmAgregarEditarIngresoGlobal.actualizarDataGrid(llenarIngresos);
            faeig.MdiParent = this.MdiParent;
            faeig.Show();
        }

        private void buttonEliminarIngreso_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar el ingreso seleccionado?", "Eliminacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                int r = dataGridIngreso.CurrentCell.RowIndex;
                ingreso.IdIngreso = Convert.ToInt32(dataGridIngreso.Rows[r].Cells["idingreso"].Value);

                ingreso.eliminar();
                this.llenarIngresos();
            }
        }

        private void buttonAgregarEgreso_Click(object sender, EventArgs e)
        {
            frmAgregarEditarEgresoGlobal faee = new frmAgregarEditarEgresoGlobal();
            faee.actualizarDataGridEvento += new frmAgregarEditarEgresoGlobal.actualizarDataGrid(calcular);
            //faee.calcularDataGridEvento += new frmAgregarEditarEgresoGlobal.calcularDataGrid(calcular);
            faee.MdiParent = this.MdiParent;
            faee.Show();
        }

        private void buttonEditarEgreso_Click(object sender, EventArgs e)
        {
            frmAgregarEditarEgresoGlobal faee = new frmAgregarEditarEgresoGlobal();
            faee.actualizarDataGridEvento += new frmAgregarEditarEgresoGlobal.actualizarDataGrid(llenarEgresos);
            faee.MdiParent = this.MdiParent;
            faee.Show();
        }

        private void buttonEliminarEgreso_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar el egreso seleccionado?", "Eliminacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                int r = dataGridEgreso.CurrentCell.RowIndex;
                egreso.IdEgreso = Convert.ToInt32(dataGridEgreso.Rows[r].Cells["idegreso"].Value);

                egreso.eliminar();
                this.llenarEgresos();
            }
        }

        private void buttonTerminar_Click(object sender, EventArgs e)
        {
            try
            {
                //Guardamos los valores finales para comenzar el siguiente dia
                GlobalIngreso caja = new GlobalIngreso();
                GlobalIngreso banco = new GlobalIngreso();
                GlobalIngreso cheque = new GlobalIngreso();
                GlobalIngreso global = new GlobalIngreso();
                GlobalIngreso tarjeta = new GlobalIngreso();

                caja.Fecha = this.dateTimePickerInicio.Value;
                banco.Fecha = this.dateTimePickerInicio.Value;
                cheque.Fecha = this.dateTimePickerInicio.Value;
                global.Fecha = this.dateTimePickerInicio.Value;
                tarjeta.Fecha = this.dateTimePickerInicio.Value;

                caja.Descripcion = "Inicialización";
                banco.Descripcion = "Inicialización";
                cheque.Descripcion = "Inicialización";
                global.Descripcion = "Inicialización";
                tarjeta.Descripcion = "Inicialización";

                caja.Importe = Convert.ToDouble(this.textEfectivoTotal.Text.Replace("$", ""));
                banco.Importe = Convert.ToDouble(this.textBancoTotal.Text.Replace("$", ""));
                cheque.Importe = Convert.ToDouble(this.textChequeTotal.Text.Replace("$", ""));
                global.Importe = Convert.ToDouble(this.textGlobalTotal.Text.Replace("$", ""));
                tarjeta.Importe = Convert.ToDouble(this.textTarjetaTotal.Text.Replace("$", ""));

                caja.Tipo = "EFECTIVO";
                banco.Tipo = "BANCO";
                cheque.Tipo = "CHEQUE";
                global.Tipo = "GLOBAL";
                tarjeta.Tipo = "TARJETA";

                caja.terminarJornada();
                banco.terminarJornada();
                cheque.terminarJornada();
                global.terminarJornada();
                tarjeta.terminarJornada();

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: "+ex, "Error");
                return;
            }

            
        }

        private void frmGestionGlobal_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void frmGestionGlobal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.buttonTerminar.PerformClick();
        }

    }
}
