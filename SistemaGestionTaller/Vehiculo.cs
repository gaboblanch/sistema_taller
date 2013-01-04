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
    class Vehiculo
    {
        private int id;
        private string dominio;
        private string marca;
        private string modelo;
        private string anio;
        private int idcliente;
        private string observaciones;
        private double capacidadcarga;
        private string tipogas;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Dominio
        {
            get { return dominio; }
            set { dominio = value; }
        }

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

        public string Anio
        {
            get { return anio; }
            set { anio = value; }
        }

        public int IdCliente
        {
            get { return idcliente; }
            set { idcliente = value; }
        }

        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }

        public string TipoGas
        {
            get { return tipogas; }
            set { tipogas = value; }
        }

        public double CapacidadCarga
        {
            get { return capacidadcarga; }
            set { capacidadcarga = value; }
        }

        //LISTADO DE TODOS LOS VEHICULOS DE LA BD
        public ArrayList coleccion()
        {
            ArrayList colVehiculos = new ArrayList();

            return colVehiculos;
        }

        //LISTADO DE VEHICULOS DE UNA CLIENTE
        public ArrayList vehiculosCliente()
        {
            ArrayList colVehiculos = new ArrayList();
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT * FROM vehiculo WHERE cliente_idcliente= '"+idcliente+"'";

            Reader = Conector.consultar(SQL_p);

            while(Reader.Read())
            {
                Vehiculo objVehiculoLocal = new Vehiculo();

                objVehiculoLocal.Id = Reader.GetInt32("idvehiculo");
                objVehiculoLocal.Dominio = Reader.GetString("dominio");
                objVehiculoLocal.Marca = Reader.GetString("marca");
                objVehiculoLocal.Modelo = Reader.GetString("modelo");
                objVehiculoLocal.Anio = Reader.GetString("anio");
                objVehiculoLocal.Observaciones = Reader.GetString("observacionesvehiculo");
                objVehiculoLocal.TipoGas = Reader.GetString("tipogas");
                objVehiculoLocal.CapacidadCarga = Reader.GetDouble("capacidadcarga");
                

                colVehiculos.Add(objVehiculoLocal);
            }

            Reader.Close();
            return colVehiculos;
        }

        //AGREGAR UN NUEVO VEHICULO A LA BD
        public void agregar()
        {
            string SQL_p;

            SQL_p = "INSERT INTO vehiculo (dominio, marca, modelo, anio, cliente_idcliente, observacionesvehiculo, tipogas, capacidadcarga) "+
                    "VALUES('"+dominio+"','"+marca+"', '"+modelo+"' ,'"+anio+"','"+idcliente+"', '"+Observaciones+"', '"+TipoGas+"', '"+CapacidadCarga+"')";

            Conector.ejecutar(SQL_p);
        }

        //ACTUALIZAR DATOS DEL VEHICULO
        public void actualizar()
        {
            string SQL_p;

            SQL_p = "UPDATE vehiculo SET dominio='"+dominio+"', marca='"+marca+"', modelo='"+modelo+"', anio='"+anio+"', "+
                    "observacionesvehiculo='"+Observaciones+"', tipogas='"+TipoGas+"', capacidadcarga='"+CapacidadCarga+"' "+
                    "WHERE idvehiculo='"+id+"'";

            Conector.ejecutar(SQL_p);
        }

        //CAMBIAR DUEÑO DEL VEHICULO
        public void cambiarDuenio()
        {
            string SQL_p;

            SQL_p = "UPDATE vehiculo SET modelo='" + modelo + "', anio='" + anio + "', cliente_idcliente='" + idcliente + "' " +
                    "WHERE idvehiculo='" + id + "' AND dominio='" + dominio + "'";

            Conector.ejecutar(SQL_p);
        }

        //ELIMINAR VEHICULO DE LA BD
        public void eliminar()
        {
            string SQL_p;

            SQL_p = "DELETE FROM vehiculo WHERE idvehiculo = '" + id + "'";

            Conector.ejecutar(SQL_p);
        }

        /// <summary>
        /// Quita el vehiculo de la lista del dueño pero el vehiculo permanece en la BD
        /// </summary>
        public void quitarVehiculo()
        {
            string SQL_p;

            SQL_p = "UPDATE vehiculo SET cliente_idcliente='0' " +
                    "WHERE idvehiculo='" + id + "' AND dominio='" + dominio + "'";

            Conector.ejecutar(SQL_p);
        }
        // TOSTRING
        public override string ToString()
        {
            return Dominio +", "+ Marca +", "+ Modelo;
        }

        /// <summary>
        /// Comprueba por dominio si el vehiculo existe
        /// </summary>
        /// <returns>True si existe, False si no existe</returns>
        public bool existeVehiculo()
        {
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT * FROM vehiculo WHERE dominio= '" + Dominio + "'";

            Reader = Conector.consultar(SQL_p);

            if (Reader.Read())
            {
                this.Id = Reader.GetInt32("idvehiculo");
                this.IdCliente = Reader.GetInt32("cliente_idcliente");
                Reader.Close();
                return true;
            }
            else
            {
                Reader.Close();
                return false;
            }
        }

    }
}
