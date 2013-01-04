using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaGestionTaller
{
    class Mantenimiento
    {
        private Iva iva;

        public Mantenimiento()
        {
            iva = new Iva();
        }

        public Iva Iva
        {
            get { return iva; }
            set { iva = value; }
        }


        public void tablaFactura()
        {
            string SQL_p;

            SQL_p = "UPDATE factura SET iva='"+Iva+"'";
        }
    }
}
