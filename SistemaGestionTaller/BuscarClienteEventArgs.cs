using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaGestionTaller
{
    public class BuscarClienteEventArgs : System.EventArgs
    {
        private Cliente cliente;
        //private string apellidoCliente;

        //CONSTRUCTOR
        //public BuscarClienteEventArgs(int idCliente_p, string nombreCliente_p)
        public BuscarClienteEventArgs(object cliente_p)
        {
            //this.idCliente = idCliente_p;
            //this.nombreCliente = nombreCliente_p;
            this.cliente = (Cliente)cliente_p;
            //this.apellidoCliente = apellidoCliente_p;
        }

        public object Cliente
        {
            get { return cliente; }
        }

        /*public string ApellidoCliente
        {
            get { return apellidoCliente; }
        }*/
    }
}
