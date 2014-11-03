using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SistemaGestionTaller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGestionCliente fgc = new frmGestionCliente();
            fgc.MdiParent = this;
            fgc.Show();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGestionProveedor fgp = new frmGestionProveedor();
            fgp.MdiParent = this;
            fgp.Show();
        }

        private void repuestosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGestiónRepuesto fgr = new frmGestiónRepuesto();
            fgr.MdiParent = this;
            fgr.Show();
        }

        private void presupuestosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgregarEditarReparacion faer = new frmAgregarEditarReparacion(true);
            faer.MdiParent = this;
            faer.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-AR");
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";

            if (File.Exists("mydb.cfg"))
            {
                try
                {
                    Conector.leerConfiguracion();
                    Conector.conectar();

                }
                catch
                {
                    MessageBox.Show("Error de conexion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    frmGestionBD fgbd = new frmGestionBD();
                    fgbd.ShowDialog();
                }
            }
            else
            {

                Conector.crearConfiguracion();

                frmGestionBD fgbd = new frmGestionBD();
                fgbd.ShowDialog();

            }
        }


        private void ordenesDeTrabajoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGestionReparacion fgr = new frmGestionReparacion();
            fgr.MdiParent = this;
            fgr.Show();
        }

        private void baseDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGestionBD fgbd = new frmGestionBD();
            fgbd.MdiParent = this;
            fgbd.Show();
        }

        private void repuestosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAgregarEditarVentaRepuesto faevr = new frmAgregarEditarVentaRepuesto(false);
            faevr.MdiParent = this;
            faevr.Show();
        }

        private void ventaDeRepuestosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGestionVentaRepuesto fgvr = new frmGestionVentaRepuesto();
            fgvr.MdiParent = this;
            fgvr.Show();
        }

        private void reparacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgregarEditarReparacion faer = new frmAgregarEditarReparacion(false);
            faer.MdiParent = this;
            faer.Show();
        }

        private void turnosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAgregarEditarTurnos faet = new frmAgregarEditarTurnos();
            faet.MdiParent = this;
            faet.Show();
        }

        private void entradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgregarEditarStock faes = new frmAgregarEditarStock();
            faes.MdiParent = this;
            faes.Show();
        }

        private void salidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgregarEditarStockSalida faess = new frmAgregarEditarStockSalida();
            faess.MdiParent = this;
            faess.Show();
        }       

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tareasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGestionTarea fgt = new frmGestionTarea(false);
            fgt.MdiParent = this;
            fgt.Show();
        }

        private void tipoDeGasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmGestionTipoGas fgtg = new frmGestionTipoGas();
            fgtg.MdiParent = this;
            fgtg.Show();
        }

        private void tiposDeCuentasBancoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmGestionTipoCuenta fgtc = new frmGestionTipoCuenta();
            fgtc.MdiParent = this;
            fgtc.Show();
        }

        private void porProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrecioProveedor fpp = new frmPrecioProveedor();
            fpp.MdiParent = this;
            fpp.Show();
        }

        private void todosLosRepuestosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrecioTodosRepuestos fptr = new frmPrecioTodosRepuestos();
            fptr.MdiParent = this;
            fptr.Show();
        }

        private void tiposDeRepuestosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGestionTipoRepuesto fgtr = new frmGestionTipoRepuesto();
            fgtr.MdiParent = this;
            fgtr.Show();
        }

        private void presupuestoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGestionPresupuesto fgp = new frmGestionPresupuesto();
            fgp.MdiParent = this;
            fgp.Show();
        }

        private void garantiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGestionGarantia fgg = new frmGestionGarantia();
            fgg.MdiParent = this;
            fgg.Show();
        }

        private void condicionIVAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGestionIva fgiva = new frmGestionIva();
            fgiva.MdiParent = this;
            fgiva.Show();
        }

        private void oTImpagasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGestionDeudasOT fgdot = new frmGestionDeudasOT();
            fgdot.MdiParent = this;
            fgdot.Show();
        }

        private void libroContableToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmLibroContable flc = new frmLibroContable();
            flc.MdiParent = this;
            flc.Show();
        }

        private void gestiónIngresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGestionIngresos fgi = new frmGestionIngresos();
            fgi.MdiParent = this;
            fgi.Show();
        }

        private void gestiónEgresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGestionEgresos fge = new frmGestionEgresos();
            fge.MdiParent = this;
            fge.Show();
        }

        private void cajaDiariaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCajaDiaria fcd = new frmCajaDiaria();
            fcd.MdiParent = this;
            fcd.Show();
        }

        private void libroAnualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLibroAnual fla = new frmLibroAnual();
            fla.MdiParent = this;
            fla.Show();
        }

        private void correcciónBDToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void porMarcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrecioPorMarca fppm = new frmPrecioPorMarca();
            fppm.MdiParent = this;
            fppm.Show();
        }

        private void cajaDiariaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmGestionGlobal fgglobal = new frmGestionGlobal();
            fgglobal.MdiParent = this;
            fgglobal.Show();
        }

        private void inicializarCajaDiariaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIniciarCajaDiaria ficd = new frmIniciarCajaDiaria();
            ficd.MdiParent = this;
            ficd.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}
