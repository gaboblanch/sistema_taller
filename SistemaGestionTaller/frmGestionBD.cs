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
    public partial class frmGestionBD : Form
    {
        public frmGestionBD()
        {
            InitializeComponent();
        }

        private void buttonConectar_Click(object sender, EventArgs e)
        {
            try
            {
                Conector.setServer(this.textIp.Text);
                Conector.setDatabase(this.textBd.Text);
                Conector.setUserid(this.textUsuario.Text);
                Conector.setPassword(this.textPassword.Text);
                Conector.guardarConfiguracion();
                Conector.conectar();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Error de conexion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmGestionBD_Load(object sender, EventArgs e)
        {
            this.textIp.Text = Conector.getServer();
            this.textBd.Text = Conector.getDatabase();
            this.textUsuario.Text = Conector.getUserid();
            this.textPassword.Text = Conector.getPassword();
        }
    }
}
