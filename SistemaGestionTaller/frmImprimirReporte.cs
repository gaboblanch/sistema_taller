using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace SistemaGestionTaller
{
    public partial class frmImprimirReporte : Form
    {
        private ReportDocument oRep;

        public frmImprimirReporte(ReportDocument oRep)
        {
            InitializeComponent();
            //oRep = new ReportDocument();
            this.oRep = oRep;
        }

        private void frmImprimirReporte_Load(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = oRep;
        }

        private void frmImprimirReporte_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
