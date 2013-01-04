using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaGestionTaller
{
    public class BuscarProveedorEventArgs : System.EventArgs
    {
        private int idProveedor;
        private string razonsocialProveedor;

        //CONSTRUCTOR
        public BuscarProveedorEventArgs(int idProveedor_p, string razonsocialProveedor_p)
        {
            this.idProveedor = idProveedor_p;
            this.razonsocialProveedor = razonsocialProveedor_p;
        }

        public int IdProveedor
        {
            get { return idProveedor; }
        }

        public string RazonSocialProveedor
        {
            get { return razonsocialProveedor; }
        }
    }
}
