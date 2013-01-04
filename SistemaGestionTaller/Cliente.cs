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
    class Cliente:Persona
    {
        private string dni;
        private double dueda;
        
        private ArrayList colVehiculos;

        public Cliente()
        {
            colVehiculos = new ArrayList();
        }


        public string Dni
        {
            get { return dni; }
            set { dni = value; }
        }

        public double Deuda
        {
            get { return dueda; }
            set { dueda = value; }
        }
       
        /// <summary>
        /// Lista con todos los vehiculos de pertencia
        /// </summary>
        public ArrayList Vehiculos
        {
            get { return colVehiculos; }
            set { colVehiculos = value; }
        }

        //LISTADO DE CLIENTES CON TODOS LOS DATOS PERSONALES
        public ArrayList coleccionDominio()
        {
            string SQL_p;
            MySqlDataReader Reader;
            ArrayList colClientes = new ArrayList();

            SQL_p = "SELECT idcliente,razonsocial,cuit,direccion,telefono,codigopostal,ciudad,provincia,dni,email,observaciones " +
                    "FROM cliente INNER JOIN vehiculo " +
                    "ON cliente.idcliente = vehiculo.cliente_idcliente " +
                    "WHERE vehiculo.dominio LIKE '%"+Filtro+"%' AND cliente.idcliente>0 " +
                    "ORDER BY cliente.razonsocial";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                Cliente objClienteLocal = new Cliente();

                objClienteLocal.Id = Reader.GetInt32("idcliente");
                objClienteLocal.NombreRazonSocial = Reader.GetString("razonsocial");
                objClienteLocal.Cuit = Reader.GetString("cuit");
                objClienteLocal.Direccion = Reader.GetString("direccion");
                objClienteLocal.Telefono = Reader.GetString("telefono");
                objClienteLocal.Cp = Reader.GetString("codigopostal");
                objClienteLocal.Localidad = Reader.GetString("ciudad");
                objClienteLocal.Provincia = Reader.GetString("provincia");
                objClienteLocal.Dni = Reader.GetString("dni");
                objClienteLocal.Email = Reader.GetString("email");
                objClienteLocal.Observaciones = Reader.GetString("observaciones");

                colClientes.Add(objClienteLocal);

            }

            Reader.Close();
            
            return colClientes;
        }

        public override ArrayList coleccion()
        {
            string SQL_p;
            MySqlDataReader Reader;
            ArrayList colClientes = new ArrayList();

            SQL_p = "SELECT cliente.* " +
                    "FROM cliente " +
                    "WHERE cliente.razonsocial LIKE '%" + filtro + "%' AND cliente.idcliente>0 " +
                    "ORDER BY cliente.razonsocial";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                Cliente objClienteLocal = new Cliente();

                objClienteLocal.Id = Reader.GetInt32("idcliente");
                objClienteLocal.NombreRazonSocial = Reader.GetString("razonsocial");
                objClienteLocal.Cuit = Reader.GetString("cuit");
                objClienteLocal.Direccion = Reader.GetString("direccion");
                objClienteLocal.Telefono = Reader.GetString("telefono");
                objClienteLocal.Cp = Reader.GetString("codigopostal");
                objClienteLocal.Localidad = Reader.GetString("ciudad");
                objClienteLocal.Provincia = Reader.GetString("provincia");
                objClienteLocal.Dni = Reader.GetString("dni");
                objClienteLocal.Email = Reader.GetString("email");
                objClienteLocal.Observaciones = Reader.GetString("observaciones");

                colClientes.Add(objClienteLocal);

            }

            Reader.Close();
            
            return colClientes;
            
        }

        //AGREGAR UN NUEVO CLIENTE
        public override void agregar()
        {
            string SQL_p;

            SQL_p = "INSERT INTO cliente (razonsocial,cuit,direccion,telefono,codigopostal,ciudad,provincia,dni,email, observaciones, deuda) " +
                    "VALUES('" + nombreRazonSocial + "','" + cuit + "','" + direccion + "','" + telefono + "','" + cp 
                    + "','" + localidad + "','" + provincia + "','" + dni + "','" + email + "', '"+observaciones+"', '"+Deuda+"')";

            Conector.ejecutar(SQL_p);
            this.Id = Conector.getLastID();
        }

        //AGREGAR UN NUEVO CLIENTE NULL
        public void agregarNull()
        {
            string SQL_p;

            SQL_p = "INSERT INTO cliente (idcliente,razonsocial,cuit,direccion,telefono,codigopostal,ciudad,provincia,dni,email,observaciones,deuda) VALUES ('0','---','---','---','---','---','---','---','---','---','---','0')";
            Conector.ejecutar(SQL_p);

            this.Id = Conector.getLastID();

            SQL_p = "UPDATE cliente SET idcliente='0' WHERE idcliente='"+this.Id+"'";
            Conector.ejecutar(SQL_p);
        }

        // ACTUALIZAR
        public override void actualizar()
        {
            string SQL_p;

            SQL_p = "UPDATE cliente SET razonsocial='" + nombreRazonSocial + "', cuit='" + cuit + "', direccion='" + direccion +
                "', ciudad='" + localidad + "', provincia='" + provincia + "', codigopostal='" + cp + "', telefono='" + telefono +
                "', email='" + email + "', observaciones='" + observaciones + "', dni='" + dni + "', deuda= '" + Deuda + "'" +
                " WHERE idcliente = '" + id + "'";

            Conector.ejecutar(SQL_p);
        }

        // ELIMINAR
        public override void eliminar()
        {
            string SQL_p;

            this.getVehiculos();

            foreach(object o in Vehiculos)
            {
                ((Vehiculo)o).quitarVehiculo();
            }

            SQL_p = "DELETE FROM cliente WHERE idcliente = '" + id + "'";

            Conector.ejecutar(SQL_p);
        }

        public override string ToString()
        {
            return NombreRazonSocial;
        }

        public bool getDatosPersonales()
        {
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT cliente.* " +
                    "FROM cliente " +
                    "WHERE cliente.idcliente='" + id + "' LIMIT 1";

            Reader = Conector.consultar(SQL_p);

            if (Reader.Read())
            {
                this.NombreRazonSocial = Reader.GetString("razonsocial");
                this.Cuit = Reader.GetString("cuit");
                this.Direccion = Reader.GetString("direccion");
                this.Telefono = Reader.GetString("telefono");
                this.Cp = Reader.GetString("codigopostal");
                this.Localidad = Reader.GetString("ciudad");
                this.Provincia = Reader.GetString("provincia");
                this.Dni = Reader.GetString("dni");
                this.Email = Reader.GetString("email");
                this.Observaciones = Reader.GetString("observaciones");
                this.Deuda = Reader.GetDouble("deuda");

                Reader.Close();
                return true;
            }
            else
            {
                Reader.Close();
                return false;
            }

        }

        public void getVehiculos()
        {
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT vehiculo.* " +
                    "FROM vehiculo WHERE cliente_idcliente='" + id + "'";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                Vehiculo objVehiculoLocal = new Vehiculo();

                objVehiculoLocal.Id = Reader.GetInt32("idvehiculo");
                objVehiculoLocal.Dominio = Reader.GetString("dominio");
                objVehiculoLocal.Marca = Reader.GetString("marca");
                objVehiculoLocal.Modelo = Reader.GetString("modelo");
                objVehiculoLocal.Anio = Reader.GetString("anio");
                objVehiculoLocal.IdCliente = Id;

                this.Vehiculos.Add(objVehiculoLocal);
            }
            Reader.Close();

        }

        public void getDeuda()
        {
            string SQL_p;
            MySqlDataReader Reader;
            
            //Codigo Viejo borrar si el otro funciona
            /*SQL_p = "SELECT IFNULL(SUM(reparacion.importe * (1+ (condicionafip.porcentajeiva/100))),0) AS totalreparacion " +
                    "FROM reparacion INNER JOIN factura INNER JOIN condicionafip INNER JOIN cliente" +
                    "ON cliente.idcliente = reparacion.cliente_idcliente AND reparacion.idreparacion = factura.reparacion_idreparacion AND factura.condicionafip_idcondicionafip = condicionafip.idcondicionafip" +
                    "WHERE cliente.idcliente ='" + Id + "' AND reparacion.estado!=0 AND reparacion.estado!=6";*/

            SQL_p = "SELECT " +
                    "((SELECT IFNULL(SUM(reparacion.importe * (1+ (condicionafip.porcentajeiva/100))),0) " +
                    "FROM reparacion INNER JOIN factura INNER JOIN condicionafip INNER JOIN cliente " +
                    "ON cliente.idcliente = reparacion.cliente_idcliente AND reparacion.idreparacion = factura.reparacion_idreparacion AND factura.condicionafip_idcondicionafip = condicionafip.idcondicionafip " +
                    "WHERE cliente.idcliente = '" + Id + "' AND reparacion.estado != 0 AND reparacion.estado != 6 AND reparacion.estado !=1) + " +
                    "(SELECT IFNULL(SUM(reparacion.importe),0) " +
                    "FROM reparacion INNER JOIN cliente " +
                    "ON cliente.idcliente = reparacion.cliente_idcliente " +
                    "WHERE cliente.idcliente = '" + Id + "' AND reparacion.estado = 1 )) AS totalreparacion ";


            Reader = Conector.consultar(SQL_p);
            
            if (Reader.Read())
            {
                this.Deuda = Reader.GetDouble("totalreparacion");
                Reader.Close();
            }
            else
                Reader.Close();


            SQL_p = "SELECT IFNULL(SUM(pagosreparacion.importepago),0) AS pagostotales " +
                    "FROM cliente INNER JOIN reparacion INNER JOIN factura INNER JOIN pagosreparacion " +
                    "ON cliente.idcliente = reparacion.cliente_idcliente " +
                    "AND factura.idfactura = pagosreparacion.factura_idfactura " +
                    "AND factura.reparacion_idreparacion = reparacion.idreparacion " +
                    "WHERE cliente.idcliente='" + Id + "' ";

            Reader = Conector.consultar(SQL_p);
            if (Reader.Read())
            {
                this.Deuda -= Reader.GetDouble("pagostotales");
            }
            Reader.Close();
        }
    }
}
