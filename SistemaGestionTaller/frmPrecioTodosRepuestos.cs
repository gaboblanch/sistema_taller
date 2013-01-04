using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaGestionTaller
{
    public partial class frmPrecioTodosRepuestos : Form
    {
        private Repuesto repuesto;

        public frmPrecioTodosRepuestos()
        {
            InitializeComponent();
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
                    repuesto.aumentarRepuestos(porcentaje + 1);

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

        private void frmPrecioTodosRepuestos_Load(object sender, EventArgs e)
        {
            repuesto = new Repuesto();
        }
    }
}
