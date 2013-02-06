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
    public partial class frmPrecioPorMarca : Form
    {
        private MarcaModelo marca;
        public frmPrecioPorMarca()
        {
            InitializeComponent();
        }

        private void llenarComboMarca()
        {
            MarcaModelo objMarca = new MarcaModelo();
            ArrayList colMarca = new ArrayList();
            colMarca = objMarca.coleccionMarca();

            this.comboBoxMarca.Items.Clear();

            for (int i = 0; i < colMarca.Count; i++)
            {
                this.comboBoxMarca.Items.Add(((MarcaModelo)colMarca[i]));
            }
        }

        private void frmPrecioPorMarca_Load(object sender, EventArgs e)
        {
            marca = new MarcaModelo();
            this.llenarComboMarca();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (this.btnGuardar.Text == "Terminar")
            {
                this.Close();
                return;
            }

            if (this.textBoxAumento.Text != "")
            {
                try
                {
                    double porcentaje = 0;
                    porcentaje = Convert.ToInt32(this.textBoxAumento.Text);
                    porcentaje = porcentaje / 100;
                    marca.AumentoPrecio = porcentaje+1;
                    marca.aumentarRepuestos();

                    this.btnGuardar.Text = "Terminar";

                    MessageBox.Show("Aumento aplicado con éxito.", "Información");
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex, "ERROR");
                }
            }
            else
            {
                MessageBox.Show("Debe escribir un aumento para poder realizar la operación.", "ERROR");
                return;
            }
        }

        private void comboBoxMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            marca = ((MarcaModelo)this.comboBoxMarca.SelectedItem);
        }
    }
}
