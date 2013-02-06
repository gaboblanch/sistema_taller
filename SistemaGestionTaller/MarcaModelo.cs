using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using MySql.Data.MySqlClient;

namespace SistemaGestionTaller
{
    class MarcaModelo
    {
        private string marca;
        private string modelo;
        private double aumentoprecio;
        

        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }

        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }

        public double AumentoPrecio
        {
            get { return aumentoprecio; }
            set { aumentoprecio = value; }
        }

        public ArrayList coleccionMarca()
        {
            ArrayList colMarca = new ArrayList();
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT DISTINCT marca FROM repuestostock ORDER BY marca";
            Reader = Conector.consultar(SQL_p);
            
            while(Reader.Read())
            {
                MarcaModelo objMarca = new MarcaModelo();
                objMarca.Marca = Reader.GetString("marca");
                colMarca.Add(objMarca);
            }

            Reader.Close();
            return colMarca;
        }

        public ArrayList coleccionModelo()
        {
            ArrayList colModelo = new ArrayList();
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT DISTINCT modelo FROM repuestostock ORDER BY modelo";
            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                MarcaModelo objModelo = new MarcaModelo();
                objModelo.Modelo = Reader.GetString("modelo");
                colModelo.Add(objModelo);
            }

            Reader.Close();
            return colModelo;
        }

        public void aumentarRepuestos()
        {
            string SQL_p;
            SQL_p = "UPDATE repuestostock SET precio = precio*'" + AumentoPrecio + "', costo=costo*'" + AumentoPrecio + "' WHERE marca='" + Marca + "'";
            Conector.ejecutar(SQL_p);
        }

        public override string ToString()
        {
            return Marca;
        }
    }
}
