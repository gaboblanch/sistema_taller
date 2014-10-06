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
    public partial class frmGestiónRepuesto : Form
    {
        private Repuesto repuesto;
        private static ArrayList colRepuesto;

        private DateTime lastLoading;
        private int firstVisibleRow;
        private bool flagDataGrid = false;

        public frmGestiónRepuesto()
        {
            InitializeComponent();

            //attach scroll event.
            //dataGridRepuesto.Scroll += new ScrollEventHandler(dataGridRepuesto_Scroll);
        }
        //CODIGO DE PRUEBA
        private int GetDisplayedRowsCount()
        {
            int count = dataGridRepuesto.Rows[dataGridRepuesto.FirstDisplayedScrollingRowIndex].Height;
            count = dataGridRepuesto.Height / count;
            return count;
        }
        //TERMINA CODIGO DE PRUEBA
        private void buttonEditar_Click(object sender, EventArgs e)
        {
            int r = dataGridRepuesto.CurrentCell.RowIndex;

            frmAgregarEditarRepuestoUnico faer = new frmAgregarEditarRepuestoUnico(Convert.ToInt32(dataGridRepuesto.Rows[r].Cells["idRepuesto"].Value));
            faer.actualizarDataGridEvento += new frmAgregarEditarRepuestoUnico.actualizarDataGrid(llenarDataGrid);
            faer.MdiParent = this.MdiParent;
            faer.Show();
        }

        private void frmGestiónRepuesto_Load(object sender, EventArgs e)
        {
            repuesto = new Repuesto();
            repuesto.queryDataGridLimit(true);
            colRepuesto = new ArrayList();
            //this.comboBoxBuscar.SelectedIndex = 1;
            llenarDataGrid();
        }

        private void llenarDataGrid()
        {
            this.buttonEditar.Enabled = false;
            this.buttonEliminar.Enabled = false;

            if (this.textBoxCodigo.Text != "")
            {
                //BUSCAR POR CODIGO
                repuesto.MySQLLimit = 0;
                repuesto.Filtro = this.textBoxCodigo.Text;
                colRepuesto = repuesto.coleccionCodigo();
                this.dataGridRepuesto.Rows.Clear();
                
            }
            else if (this.textBoxMarca.Text != "")
            {
                //BUSCAR POR DESCRIPCION
                repuesto.MySQLLimit = 0;
                repuesto.Filtro = this.textBoxMarca.Text;
                colRepuesto = repuesto.coleccionMarcaModelo();
                this.dataGridRepuesto.Rows.Clear();
                flagDataGrid = true;
            }
            else if (this.textFiltro.Text != "")
            {
                //BUSCAR POR DESCRIPCION
                repuesto.MySQLLimit = 0;
                repuesto.Filtro = this.textFiltro.Text;
                colRepuesto = repuesto.coleccion();
                this.dataGridRepuesto.Rows.Clear();
            }
            else if (this.textBoxProveedor.Text != "")
            {
                //BUSCAR POR DESCRIPCION
                repuesto.MySQLLimit = 0;
                repuesto.Filtro = this.textBoxProveedor.Text;
                colRepuesto = repuesto.coleccionProveedor();
                this.dataGridRepuesto.Rows.Clear();
            }
            else
            {
                if (flagDataGrid)
                {
                    repuesto.Filtro = "";
                    this.dataGridRepuesto.Rows.Clear();
                    colRepuesto.Clear();
                    flagDataGrid = false;
                }
                colRepuesto.AddRange(repuesto.coleccion());
            }

            if (this.checkBoxFaltantes.Checked)
            {
                for (int i = 0; i < colRepuesto.Count; i++)
                {
                    if (((Repuesto)colRepuesto[i]).CantidadStock <= ((Repuesto)colRepuesto[i]).MinimoStock)
                    {
                        Repuesto objRepuesto = new Repuesto();
                        objRepuesto = (Repuesto)colRepuesto[i];
                        colRepuesto.RemoveAt(i);
                        colRepuesto.Insert(0, objRepuesto);
                        //i = 0;
                    }
                }
                this.dataGridRepuesto.Rows.Clear();
            }


            for (int i = 0; i < colRepuesto.Count; i++)
            {
                if (i == 0)
                {
                    i = this.dataGridRepuesto.Rows.Count;
                }

                this.dataGridRepuesto.Rows.Add();

                if (i == colRepuesto.Count)
                {
                    return;
                }

                if (((Repuesto)colRepuesto[i]).CantidadStock <= ((Repuesto)colRepuesto[i]).MinimoStock)
                {
                    this.dataGridRepuesto.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
                else
                {
                    this.dataGridRepuesto.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }

                this.dataGridRepuesto.Rows[i].Cells["idRepuesto"].Value = ((Repuesto)colRepuesto[i]).IdRepuesto;
                this.dataGridRepuesto.Rows[i].Cells["idtipo"].Value = ((Repuesto)colRepuesto[i]).Idtipo;
                this.dataGridRepuesto.Rows[i].Cells["codigorepuesto"].Value = ((Repuesto)colRepuesto[i]).CodigoRepuesto;
                this.dataGridRepuesto.Rows[i].Cells["descripciontipo"].Value = ((Repuesto)colRepuesto[i]).DescripcionTipo;
                this.dataGridRepuesto.Rows[i].Cells["descripcionrespuesto"].Value = ((Repuesto)colRepuesto[i]).DescripcionRepuesto;
                this.dataGridRepuesto.Rows[i].Cells["marca"].Value = ((Repuesto)colRepuesto[i]).Marca;
                this.dataGridRepuesto.Rows[i].Cells["modelo"].Value = ((Repuesto)colRepuesto[i]).Modelo;
                this.dataGridRepuesto.Rows[i].Cells["cantidad"].Value = ((Repuesto)colRepuesto[i]).CantidadStock;
                this.dataGridRepuesto.Rows[i].Cells["costo"].Value = ((Repuesto)colRepuesto[i]).Costo;
                this.dataGridRepuesto.Rows[i].Cells["precio"].Value = ((Repuesto)colRepuesto[i]).PrecioUnitario;
                this.dataGridRepuesto.Rows[i].Cells["minimo"].Value = ((Repuesto)colRepuesto[i]).MinimoStock;
                this.dataGridRepuesto.Rows[i].Cells["idproveedor"].Value = " "; //((Repuesto)colRepuesto[i]).Proveedor.Id;
                this.dataGridRepuesto.Rows[i].Cells["razonsocialproveedor"].Value = " "; // ((Repuesto)colRepuesto[i]).Proveedor.NombreRazonSocial;
            }
            this.dataGridRepuesto.ClearSelection();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Eliminar?", "Eliminacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    int r = dataGridRepuesto.CurrentCell.RowIndex;
                    repuesto.IdRepuesto = Convert.ToInt32(dataGridRepuesto.Rows[r].Cells["idRepuesto"].Value);
                    repuesto.eliminar();
                    llenarDataGrid();
                }
                catch
                {
                    MessageBox.Show("No se puede eliminar el repuesto seleccionado porque se utiliza en reparaciones o garantias.","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void dataGridRepuesto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.buttonEditar.Enabled = true;
            this.buttonEliminar.Enabled = true;
        }

        private void buttonFiltrar_Click(object sender, EventArgs e)
        {
            llenarDataGrid();
        }

        private void textFiltro_TextChanged(object sender, EventArgs e)
        {
            llenarDataGrid();
        }

        private void dataGridRepuesto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.buttonEditar.PerformClick();
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {

            repuesto.Filtro = "";
            this.dataGridRepuesto.Rows.Clear();
            colRepuesto.Clear();
            this.llenarDataGrid();
        }

        private void frmGestiónRepuesto_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void checkBoxFaltantes_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.checkBoxFaltantes.Checked)
            {
                this.flagDataGrid = true;
            }

            colRepuesto.Clear();
            this.llenarDataGrid();
        }

        private void textBoxCodigo_TextChanged(object sender, EventArgs e)
        {
            this.llenarDataGrid();
        }

        private void textBoxMarca_TextChanged(object sender, EventArgs e)
        {
            this.llenarDataGrid();
        }

        private void dataGridRepuesto_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.Type == ScrollEventType.SmallIncrement || e.Type == ScrollEventType.LargeIncrement)
            {
                if (e.NewValue >= dataGridRepuesto.Rows.Count - GetDisplayedRowsCount() && repuesto.DataGridLimit > dataGridRepuesto.Rows.Count)
                {
                    //prevent loading from autoscroll.
                    TimeSpan ts = DateTime.Now - lastLoading;
                    if (ts.TotalMilliseconds > 100)
                    {
                        firstVisibleRow = e.NewValue;
                        repuesto.MySQLLimit += 30; 
                        llenarDataGrid();
                        dataGridRepuesto.FirstDisplayedScrollingRowIndex = e.OldValue;
                    }
                    else
                    {
                        dataGridRepuesto.FirstDisplayedScrollingRowIndex = e.OldValue;
                    }
                }
            }
        }

        private void textBoxProveedor_TextChanged(object sender, EventArgs e)
        {
            this.llenarDataGrid();
        }

    }
}
