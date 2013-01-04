using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaGestionTaller
{
    public class BuscarVehiculoEventArgs : System.EventArgs
    {
        //private int idVehiculo;
        private Vehiculo vehiculo;
        /*private string dominio;
        private string modelo;
        private string marca;*/

        //public BuscarVehiculoEventArgs(int idVehiculo_p, string dominio_p, string marca_p, string modelo_p)
        public BuscarVehiculoEventArgs(object vehiculo_p)
        {
            vehiculo = new Vehiculo();
            vehiculo = (Vehiculo)vehiculo_p;
            //idVehiculo = idVehiculo_p;
            /*dominio = dominio_p;
            modelo = modelo_p;
            marca = marca_p;*/
        }

        public object Vehiculo
        {
            get { return vehiculo; }
        }
        /*
        public int IdVehiculo
        {
            get { return idVehiculo; }
        }

        public string Dominio
        {
            get { return dominio; }
        }

        public string Modelo
        {
            get { return modelo; }
        }

        public string Marca
        {
            get { return marca; }
        }*/
    }
}
