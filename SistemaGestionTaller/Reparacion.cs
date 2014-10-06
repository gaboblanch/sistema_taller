using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace SistemaGestionTaller
{
    class Reparacion
    {
        private int id;
        private string codigoReparacion;
        private DateTime fecha;
        /// <summary>
        /// Fecha sin posibilidad de cambio, utilizada por el sistema
        /// </summary>
        private DateTime fechaSistema;
        private Cliente cliente;
        private Vehiculo vehiculo;
        private string descripcion;
        private double importeTotal;
        /* Indica el estado de la reparacion 
         * Presupuesto(0)
         * Orden de trabajo(1)
         * Facturada(2)
         * Saldada(3)
         * Con Garantia(4)
         * Con Garantia y Saldada (5)
         * Reparacion Eliminada (6)*/
        private int estado; 
        private int estadoAnterior;
        
        //Colecciones con repuestos y tareas de la reparacion
        private ArrayList detalleRepuestos;
        private ArrayList detalleTareas;
        private ArrayList detalleCargas;

        //Colecciones con repuestos y tareas eliminados, hay que sacarlos del detalle a guardar
        private ArrayList detalleRepuestosElimindas;
        private ArrayList detalleTareasEliminadas;
        private ArrayList detalleCargasEliminadas;

        //CONSTRUCTOR
        public Reparacion()
        {
            cliente = new Cliente();
            vehiculo = new Vehiculo();
            detalleRepuestos = new ArrayList();
            detalleTareas = new ArrayList();
            detalleCargas = new ArrayList();

            detalleRepuestosElimindas = new ArrayList();
            detalleTareasEliminadas = new ArrayList();
            detalleCargasEliminadas = new ArrayList();
        }

        public int IdReparacion
        {
            get { return id; }
            set { id = value; }
        }

        public string CodigoReparacion
        {
            get { return codigoReparacion; }
            set { codigoReparacion = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public DateTime FechaSistema
        {
            get { return fechaSistema; }
            set { fechaSistema = value; }
        }

        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        public Vehiculo Vehiculo
        {
            get { return vehiculo; }
            set { vehiculo = value; }
        }

        /// <summary>
        /// Algun comentario que quiera agregar el mecanico
        /// </summary>
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public double ImporteTotal
        {
            get { return importeTotal; }
            set { importeTotal = value; }
        }

        public int Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public int EstadoAnterior
        {
            get { return estadoAnterior; }
            set { estadoAnterior = value; }
        }

        /// <summary>
        /// Listado de repuestos utilizados en la reparacion, 
        /// contiene objetos RepuestoReparacion
        /// </summary>
        public ArrayList DetalleRepuestos
        {
            get { return detalleRepuestos; }
            set { detalleRepuestos = value; }
        }

        public ArrayList DetalleRepuestosEliminados
        {
            get { return detalleRepuestosElimindas; }
            set { detalleRepuestosElimindas = value; }
        }

        /// <summary>
        /// Listado de tareas realizados en la reparacion,
        /// contiene objetos Tarea
        /// </summary>
        public ArrayList DetalleTarea
        {
            get { return detalleTareas; }
            set { detalleTareas = value; }
        }

        public ArrayList DetalleTareaEliminados
        {
            get { return detalleTareasEliminadas; }
            set { detalleTareasEliminadas = value; }
        }

        /// <summary>
        /// Listado de cargas de gas realizadas en la reparacion,
        /// contiene objetos CargaGasReparacion
        /// </summary>
        public ArrayList DetalleCargas
        {
            get { return detalleCargas; }
            set { detalleCargas = value; }
        }

        public ArrayList DetalleCargaEliminados
        {
            get { return detalleCargasEliminadas; }
            set { detalleCargasEliminadas = value; }
        }

        /// <summary>
        /// Listado Total de reparaciones con deudas
        /// </summary>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <returns></returns>
        public virtual ArrayList coleccionDeudas()
        {
            string SQL_p;
            MySqlDataReader Reader;
            ArrayList colReparacion = new ArrayList();

            SQL_p = "SELECT reparacion.*, vehiculo.dominio, vehiculo.marca, vehiculo.modelo, cliente.razonsocial, IFNULL(factura.saldo, reparacion.importe) AS saldo " +
                    "FROM reparacion INNER JOIN cliente INNER JOIN vehiculo INNER JOIN factura " +
                    "ON reparacion.vehiculo_idvehiculo = vehiculo.idvehiculo AND reparacion.cliente_idcliente = cliente.idcliente AND reparacion.idreparacion = factura.reparacion_idreparacion " +
                    "WHERE factura.saldo != 0 AND (reparacion.estado = '1' OR reparacion.estado = '2' OR reparacion.estado = '4') " +
                    "GROUP BY reparacion.idreparacion HAVING cliente.razonsocial LIKE '%" + Cliente.Filtro + "%' " +
                    "ORDER BY reparacion.fecha DESC";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                Reparacion objReparacioLocal = new Reparacion();

                //DATOS REPARACION
                objReparacioLocal.IdReparacion = Reader.GetInt32("idreparacion");
                objReparacioLocal.ImporteTotal = Reader.GetDouble("importe");
                objReparacioLocal.Fecha = Reader.GetDateTime("fecha");
                objReparacioLocal.FechaSistema = Reader.GetDateTime("fechasistema");
                objReparacioLocal.Descripcion = Reader.GetString("descripcion");
                objReparacioLocal.Estado = Reader.GetInt32("estado");
                objReparacioLocal.EstadoAnterior = Reader.GetInt32("estado");
                objReparacioLocal.CodigoReparacion = Reader.GetString("codigoreparacion");

                //DATOS VEHICULO
                objReparacioLocal.Vehiculo.Id = Reader.GetInt32("vehiculo_idvehiculo");
                objReparacioLocal.Vehiculo.Dominio = Reader.GetString("dominio");
                objReparacioLocal.Vehiculo.Marca = Reader.GetString("marca");
                objReparacioLocal.Vehiculo.Modelo = Reader.GetString("modelo");

                //DATOS CLIENTE
                objReparacioLocal.Cliente.Id = Reader.GetInt32("cliente_idcliente");
                objReparacioLocal.Cliente.NombreRazonSocial = Reader.GetString("razonsocial");
                objReparacioLocal.Cliente.Deuda = Reader.GetDouble("saldo");

                colReparacion.Add(objReparacioLocal);
            }

            Reader.Close();
            return colReparacion;

        }

        /// <summary>
        /// Listado de reparaciones completas con repuestos y tareas
        /// </summary>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <returns></returns>
        public virtual ArrayList coleccion(string fechaInicio, string fechaFin)
        {
            string SQL_p;
            MySqlDataReader Reader;
            ArrayList colReparacion = new ArrayList();

            SQL_p = "SELECT reparacion.*, vehiculo.dominio, vehiculo.marca, vehiculo.modelo, cliente.razonsocial " +
                    "FROM reparacion INNER JOIN cliente INNER JOIN vehiculo " +
                    "ON reparacion.vehiculo_idvehiculo = vehiculo.idvehiculo AND reparacion.cliente_idcliente = cliente.idcliente " +
                    "WHERE cliente.razonsocial LIKE '%"+Cliente.Filtro+"%' AND reparacion.estado != '"+Estado+"' AND reparacion.fecha BETWEEN '"+fechaInicio+"' AND '"+fechaFin+"' "+
                    "GROUP BY reparacion.idreparacion " +
                    "ORDER BY reparacion.fecha, reparacion.idreparacion DESC ";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                Reparacion objReparacioLocal = new Reparacion();

                //DATOS REPARACION
                objReparacioLocal.IdReparacion = Reader.GetInt32("idreparacion");
                objReparacioLocal.ImporteTotal = Reader.GetDouble("importe");
                objReparacioLocal.Fecha = Reader.GetDateTime("fecha");
                objReparacioLocal.FechaSistema = Reader.GetDateTime("fechasistema");
                objReparacioLocal.Descripcion = Reader.GetString("descripcion");
                objReparacioLocal.Estado = Reader.GetInt32("estado");
                objReparacioLocal.EstadoAnterior = Reader.GetInt32("estado");
                objReparacioLocal.CodigoReparacion = Reader.GetString("codigoreparacion");

                //DATOS VEHICULO
                objReparacioLocal.Vehiculo.Id = Reader.GetInt32("vehiculo_idvehiculo");
                objReparacioLocal.Vehiculo.Dominio = Reader.GetString("dominio");
                objReparacioLocal.Vehiculo.Marca = Reader.GetString("marca");
                objReparacioLocal.Vehiculo.Modelo = Reader.GetString("modelo");

                //DATOS CLIENTE
                objReparacioLocal.Cliente.Id = Reader.GetInt32("cliente_idcliente");
                objReparacioLocal.Cliente.NombreRazonSocial = Reader.GetString("razonsocial");
                //objReparacioLocal.Cliente.Deuda = Reader.GetDouble("saldo");

                colReparacion.Add(objReparacioLocal);
            }

            Reader.Close();
            return colReparacion;

        }

        /// <summary>
        /// Presupuesto listado igual a un estado
        /// </summary>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <returns></returns>
        public ArrayList coleccionPresupuesto(string fechaInicio, string fechaFin)
        {
            string SQL_p;
            MySqlDataReader Reader;
            ArrayList colReparacion = new ArrayList();

            SQL_p = "SELECT reparacion.*, vehiculo.dominio, vehiculo.marca, vehiculo.modelo, cliente.razonsocial " +
                    "FROM reparacion INNER JOIN cliente INNER JOIN vehiculo " +
                    "ON reparacion.vehiculo_idvehiculo = vehiculo.idvehiculo AND reparacion.cliente_idcliente = cliente.idcliente " +
                    "WHERE cliente.razonsocial LIKE '%" + Cliente.Filtro + "%' AND reparacion.estado = '" + Estado + "' AND reparacion.fecha BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "' " +
                    "ORDER BY reparacion.fecha, reparacion.idreparacion DESC ";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                Reparacion objReparacioLocal = new Reparacion();

                //DATOS REPARACION
                objReparacioLocal.IdReparacion = Reader.GetInt32("idreparacion");
                objReparacioLocal.ImporteTotal = Reader.GetDouble("importe");
                objReparacioLocal.Fecha = Reader.GetDateTime("fecha");
                objReparacioLocal.FechaSistema = Reader.GetDateTime("fechasistema");
                objReparacioLocal.Descripcion = Reader.GetString("descripcion");
                objReparacioLocal.Estado = Reader.GetInt32("estado");
                objReparacioLocal.EstadoAnterior = Reader.GetInt32("estado");
                objReparacioLocal.CodigoReparacion = Reader.GetString("codigoreparacion");

                //DATOS VEHICULO
                objReparacioLocal.Vehiculo.Id = Reader.GetInt32("vehiculo_idvehiculo");
                objReparacioLocal.Vehiculo.Dominio = Reader.GetString("dominio");
                objReparacioLocal.Vehiculo.Marca = Reader.GetString("marca");
                objReparacioLocal.Vehiculo.Modelo = Reader.GetString("modelo");

                //DATOS CLIENTE
                objReparacioLocal.Cliente.Id = Reader.GetInt32("cliente_idcliente");
                objReparacioLocal.Cliente.NombreRazonSocial = Reader.GetString("razonsocial");

                colReparacion.Add(objReparacioLocal);
            }

            Reader.Close();
            return colReparacion;

        }


        public ArrayList coleccionDominio(string fechaInicio, string fechaFin)
        {
            string SQL_p;
            MySqlDataReader Reader;
            ArrayList colReparacion = new ArrayList();

            SQL_p = "SELECT reparacion.*, vehiculo.dominio, vehiculo.marca, vehiculo.modelo, cliente.razonsocial " +
                    "FROM reparacion INNER JOIN cliente INNER JOIN vehiculo " +
                    "ON reparacion.vehiculo_idvehiculo = vehiculo.idvehiculo AND reparacion.cliente_idcliente = cliente.idcliente " +
                    "WHERE vehiculo.dominio LIKE '%" + Cliente.Filtro + "%' AND reparacion.estado != '"+Estado+"' AND reparacion.fecha BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "' " +
                    "GROUP BY reparacion.idreparacion " +
                    "ORDER BY reparacion.fecha, reparacion.idreparacion DESC ";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                Reparacion objReparacioLocal = new Reparacion();

                //DATOS REPARACION
                objReparacioLocal.IdReparacion = Reader.GetInt32("idreparacion");
                objReparacioLocal.ImporteTotal = Reader.GetDouble("importe");
                objReparacioLocal.Fecha = Reader.GetDateTime("fecha");
                objReparacioLocal.FechaSistema = Reader.GetDateTime("fechasistema");
                objReparacioLocal.Descripcion = Reader.GetString("descripcion");
                objReparacioLocal.Estado = Reader.GetInt32("estado");
                objReparacioLocal.EstadoAnterior = Reader.GetInt32("estado");
                objReparacioLocal.CodigoReparacion = Reader.GetString("codigoreparacion");

                //DATOS VEHICULO
                objReparacioLocal.Vehiculo.Id = Reader.GetInt32("vehiculo_idvehiculo");
                objReparacioLocal.Vehiculo.Dominio = Reader.GetString("dominio");
                objReparacioLocal.Vehiculo.Marca = Reader.GetString("marca");
                objReparacioLocal.Vehiculo.Modelo = Reader.GetString("modelo");

                //DATOS CLIENTE
                objReparacioLocal.Cliente.Id = Reader.GetInt32("cliente_idcliente");
                objReparacioLocal.Cliente.NombreRazonSocial = Reader.GetString("razonsocial");
                //objReparacioLocal.Cliente.Deuda = Reader.GetDouble("saldo");

                colReparacion.Add(objReparacioLocal);
            }

            Reader.Close();
            return colReparacion;

        }

        public ArrayList coleccionMarca(string fechaInicio, string fechaFin)
        {
            string SQL_p;
            MySqlDataReader Reader;
            ArrayList colReparacion = new ArrayList();

            SQL_p = "SELECT reparacion.*, vehiculo.dominio, vehiculo.marca, vehiculo.modelo, cliente.razonsocial " +
                    "FROM reparacion INNER JOIN cliente INNER JOIN vehiculo " +
                    "ON reparacion.vehiculo_idvehiculo = vehiculo.idvehiculo AND reparacion.cliente_idcliente = cliente.idcliente " +
                    "WHERE (vehiculo.marca LIKE '%" + Cliente.Filtro + "%' OR vehiculo.modelo LIKE '%" + Cliente.Filtro + "%') AND reparacion.estado != '" + Estado + "' AND reparacion.fecha BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "' " +
                    "GROUP BY reparacion.idreparacion " +
                    "ORDER BY reparacion.fecha, reparacion.idreparacion DESC ";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                Reparacion objReparacioLocal = new Reparacion();

                //DATOS REPARACION
                objReparacioLocal.IdReparacion = Reader.GetInt32("idreparacion");
                objReparacioLocal.ImporteTotal = Reader.GetDouble("importe");
                objReparacioLocal.Fecha = Reader.GetDateTime("fecha");
                objReparacioLocal.FechaSistema = Reader.GetDateTime("fechasistema");
                objReparacioLocal.Descripcion = Reader.GetString("descripcion");
                objReparacioLocal.Estado = Reader.GetInt32("estado");
                objReparacioLocal.EstadoAnterior = Reader.GetInt32("estado");
                objReparacioLocal.CodigoReparacion = Reader.GetString("codigoreparacion");

                //DATOS VEHICULO
                objReparacioLocal.Vehiculo.Id = Reader.GetInt32("vehiculo_idvehiculo");
                objReparacioLocal.Vehiculo.Dominio = Reader.GetString("dominio");
                objReparacioLocal.Vehiculo.Marca = Reader.GetString("marca");
                objReparacioLocal.Vehiculo.Modelo = Reader.GetString("modelo");

                //DATOS CLIENTE
                objReparacioLocal.Cliente.Id = Reader.GetInt32("cliente_idcliente");
                objReparacioLocal.Cliente.NombreRazonSocial = Reader.GetString("razonsocial");
                //objReparacioLocal.Cliente.Deuda = Reader.GetDouble("saldo");

                colReparacion.Add(objReparacioLocal);
            }

            Reader.Close();
            return colReparacion;

        }

        /// <summary>
        /// Presupuesto buscamos con condicion igual a un estado
        /// </summary>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <returns></returns>
        public ArrayList coleccionDominioPresupuesto(string fechaInicio, string fechaFin)
        {
            string SQL_p;
            MySqlDataReader Reader;
            ArrayList colReparacion = new ArrayList();

            SQL_p = "SELECT reparacion.*, vehiculo.dominio, vehiculo.marca, vehiculo.modelo, cliente.razonsocial " +
                    "FROM reparacion INNER JOIN cliente INNER JOIN vehiculo " +
                    "ON reparacion.vehiculo_idvehiculo = vehiculo.idvehiculo AND reparacion.cliente_idcliente = cliente.idcliente " +
                    "WHERE vehiculo.dominio LIKE '%" + Cliente.Filtro + "%' AND reparacion.estado = '" + Estado + "' AND reparacion.fecha BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "' " +
                    "ORDER BY reparacion.fecha, reparacion.idreparacion DESC ";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                Reparacion objReparacioLocal = new Reparacion();

                //DATOS REPARACION
                objReparacioLocal.IdReparacion = Reader.GetInt32("idreparacion");
                objReparacioLocal.ImporteTotal = Reader.GetDouble("importe");
                objReparacioLocal.Fecha = Reader.GetDateTime("fecha");
                objReparacioLocal.FechaSistema = Reader.GetDateTime("fechasistema");
                objReparacioLocal.Descripcion = Reader.GetString("descripcion");
                objReparacioLocal.Estado = Reader.GetInt32("estado");
                objReparacioLocal.EstadoAnterior = Reader.GetInt32("estado");
                objReparacioLocal.CodigoReparacion = Reader.GetString("codigoreparacion");

                //DATOS VEHICULO
                objReparacioLocal.Vehiculo.Id = Reader.GetInt32("vehiculo_idvehiculo");
                objReparacioLocal.Vehiculo.Dominio = Reader.GetString("dominio");
                objReparacioLocal.Vehiculo.Marca = Reader.GetString("marca");
                objReparacioLocal.Vehiculo.Modelo = Reader.GetString("modelo");

                //DATOS CLIENTE
                objReparacioLocal.Cliente.Id = Reader.GetInt32("cliente_idcliente");
                objReparacioLocal.Cliente.NombreRazonSocial = Reader.GetString("razonsocial");

                colReparacion.Add(objReparacioLocal);
            }

            Reader.Close();
            return colReparacion;

        }

        public ArrayList coleccionFactura(string fechaInicio, string fechaFin)
        {
            string SQL_p;
            MySqlDataReader Reader;
            ArrayList colReparacion = new ArrayList();

            SQL_p = "SELECT reparacion.*, vehiculo.dominio, vehiculo.marca, vehiculo.modelo, cliente.razonsocial, IFNULL(factura.saldo, reparacion.importe) AS saldo " +
                    "FROM reparacion INNER JOIN cliente INNER JOIN vehiculo INNER JOIN factura " +
                    "ON reparacion.vehiculo_idvehiculo = vehiculo.idvehiculo " +
                    "AND reparacion.cliente_idcliente = cliente.idcliente " +
                    "AND factura.reparacion_idreparacion = reparacion.idreparacion " +
                    "WHERE factura.codigofactura LIKE '%" + Cliente.Filtro + "%' AND reparacion.estado != '" + Estado + "' AND reparacion.fecha BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "' " +
                    "GROUP BY reparacion.idreparacion " +
                    "ORDER BY reparacion.fecha, reparacion.idreparacion DESC ";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                Reparacion objReparacioLocal = new Reparacion();

                //DATOS REPARACION
                objReparacioLocal.IdReparacion = Reader.GetInt32("idreparacion");
                objReparacioLocal.ImporteTotal = Reader.GetDouble("importe");
                objReparacioLocal.Fecha = Reader.GetDateTime("fecha");
                objReparacioLocal.FechaSistema = Reader.GetDateTime("fechasistema");
                objReparacioLocal.Descripcion = Reader.GetString("descripcion");
                objReparacioLocal.Estado = Reader.GetInt32("estado");
                objReparacioLocal.EstadoAnterior = Reader.GetInt32("estado");
                objReparacioLocal.CodigoReparacion = Reader.GetString("codigoreparacion");

                //DATOS VEHICULO
                objReparacioLocal.Vehiculo.Id = Reader.GetInt32("vehiculo_idvehiculo");
                objReparacioLocal.Vehiculo.Dominio = Reader.GetString("dominio");
                objReparacioLocal.Vehiculo.Marca = Reader.GetString("marca");
                objReparacioLocal.Vehiculo.Modelo = Reader.GetString("modelo");

                //DATOS CLIENTE
                objReparacioLocal.Cliente.Id = Reader.GetInt32("cliente_idcliente");
                objReparacioLocal.Cliente.NombreRazonSocial = Reader.GetString("razonsocial");
                //objReparacioLocal.Cliente.Deuda = Reader.GetDouble("saldo");

                colReparacion.Add(objReparacioLocal);
            }

            Reader.Close();
            return colReparacion;

        }

        public ArrayList coleccionCodigoReparacion(string fechaInicio, string fechaFin)
        {
            string SQL_p;
            MySqlDataReader Reader;
            ArrayList colReparacion = new ArrayList();

            SQL_p = "SELECT reparacion.*, vehiculo.dominio, vehiculo.marca, vehiculo.modelo, cliente.razonsocial " +
                    "FROM reparacion INNER JOIN cliente INNER JOIN vehiculo " +
                    "ON reparacion.vehiculo_idvehiculo = vehiculo.idvehiculo AND reparacion.cliente_idcliente = cliente.idcliente " +
                    "WHERE reparacion.codigoreparacion LIKE '%" + Cliente.Filtro + "%' AND reparacion.estado != '" + Estado + "' AND reparacion.fecha BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "' " +
                    "GROUP BY reparacion.idreparacion " +
                    "ORDER BY reparacion.fecha, reparacion.idreparacion DESC ";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                Reparacion objReparacioLocal = new Reparacion();

                //DATOS REPARACION
                objReparacioLocal.IdReparacion = Reader.GetInt32("idreparacion");
                objReparacioLocal.ImporteTotal = Reader.GetDouble("importe");
                objReparacioLocal.Fecha = Reader.GetDateTime("fecha");
                objReparacioLocal.FechaSistema = Reader.GetDateTime("fechasistema");
                objReparacioLocal.Descripcion = Reader.GetString("descripcion");
                objReparacioLocal.Estado = Reader.GetInt32("estado");
                objReparacioLocal.EstadoAnterior = Reader.GetInt32("estado");
                objReparacioLocal.CodigoReparacion = Reader.GetString("codigoreparacion");

                //DATOS VEHICULO
                objReparacioLocal.Vehiculo.Id = Reader.GetInt32("vehiculo_idvehiculo");
                objReparacioLocal.Vehiculo.Dominio = Reader.GetString("dominio");
                objReparacioLocal.Vehiculo.Marca = Reader.GetString("marca");
                objReparacioLocal.Vehiculo.Modelo = Reader.GetString("modelo");

                //DATOS CLIENTE
                objReparacioLocal.Cliente.Id = Reader.GetInt32("cliente_idcliente");
                objReparacioLocal.Cliente.NombreRazonSocial = Reader.GetString("razonsocial");
                //objReparacioLocal.Cliente.Deuda = Reader.GetDouble("saldo");
                

                colReparacion.Add(objReparacioLocal);
            }

            Reader.Close();
            return colReparacion;

        }

        public void getIva()
        {
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT condicionafip.* FROM factura INNER JOIN condicionafip "+
                    "ON factura.condicionafip_idcondicionafip = condicionafip.idcondicionafip " +
                    "WHERE factura.reparacion_idreparacion = '" + this.IdReparacion + "'";

            Reader = Conector.consultar(SQL_p);

            if (Reader.Read())
            {
                //string condicion;
                double porcentaje;

                Iva objIvaLocal = new Iva();
                objIvaLocal.Id = Reader.GetInt32("idcondicionafip");
                objIvaLocal.CondicionIva = Reader.GetString("condicioniva");
                objIvaLocal.PorcentajeIva = Reader.GetInt32("porcentajeiva");

                if (objIvaLocal.CondicionIva.IndexOf("INCLUIDO") <= 0)
                {
                    //porcentaje = Convert.ToDouble(condicion.Substring(condicion.IndexOf("(") + 1, (condicion.IndexOf(")") - condicion.IndexOf("(") - 1)));
                    porcentaje = objIvaLocal.PorcentajeIva;
                    porcentaje = porcentaje / 100;
                    this.ImporteTotal = Convert.ToDouble((ImporteTotal + (ImporteTotal * porcentaje)).ToString("0.00"));
                }
            }
            Reader.Close();
        }

        public virtual void agregar()
        {
            string SQL_p;
            int ultimoId = this.getUltimoId();

            SQL_p = "INSERT INTO reparacion(codigoreparacion, fechasistema, fecha, descripcion, importe, vehiculo_idvehiculo, cliente_idcliente, estado) "+
                    "VALUES('"+CodigoReparacion+"', '" + String.Format("{0:yyyy/MM/dd}", FechaSistema) + "', '" + String.Format("{0:yyyy/MM/dd}", Fecha) 
                    + "','" + Descripcion + "','" + ImporteTotal.ToString("0.00") + "','" + Vehiculo.Id + "', '"+Cliente.Id+"', '"+Estado+"')";

            Conector.ejecutar(SQL_p);

            this.IdReparacion = Conector.getLastID();

            if (Estado == 0)
            {
                //Agregamos el codigo de reparacion
                this.actualizarCodigoReparacion("PS-" + String.Format("{0:yyyyMM}", FechaSistema) + "-"+(ultimoId+1)+"");

                //PRESUPUESTO
                //AGREGAR LOS REPUESTOS
                foreach (object o in DetalleRepuestos)
                {
                    ((RepuestoReparacion)o).agregarPresupuesto(this.IdReparacion);
                }

                //AGREGAR LAS CARGAS
                foreach (object o in DetalleCargas)
                {
                    ((RepuestoReparacion)o).agregarPresupuesto(this.IdReparacion);
                }
            }
            else if (Estado == 1)
            {
                this.actualizarCodigoReparacion("OT-" + String.Format("{0:yyyyMM}", FechaSistema) + "-" + (ultimoId + 1) + "");
                //ORDEN DE TRABAJO
                //AGREGAR LOS REPUESTOS
                foreach (object o in DetalleRepuestos)
                {
                    ((RepuestoReparacion)o).agregarReparacion(this.IdReparacion);
                }

                foreach (object o in DetalleCargas)
                {
                    ((RepuestoReparacion)o).agregarReparacion(this.IdReparacion);
                }
            }

            //AGREGAR LAS TAREAS REALIZADAS
            foreach (object o in DetalleTarea)
            {
                ((TareaReparacion)o).agregar(this.IdReparacion);
            }
        }


        public virtual void actualizar(int estado_p)
        {
            string SQL_p;
            bool flagContinuar;

            //ES UN PRESUPUESTO
            //ES UN PRESUPUESTO
            //ES UN PRESUPUESTO
            if (estado_p == 0)
            {
                //ACTUALIZAR O ELIMINAR REPUESTOS SIN TENER EN CUENTA EL STOCK
                try
                {
                    //ACTUALIZAR LOS REPUESTOS UTILIZADOS
                    foreach (object o in DetalleRepuestos)
                    {
                        if (((RepuestoReparacion)o).IdRepuestoReparacion != 0)
                        {
                            ((RepuestoReparacion)o).actualizarPresupuesto();
                        }
                        else
                        {
                            ((RepuestoReparacion)o).agregarPresupuesto(IdReparacion);
                        }
                    }

                    //ACTUALIZAR LAS CARGAS DE GAS
                    foreach (object o in DetalleCargas)
                    {
                        if (((RepuestoReparacion)o).IdRepuestoReparacion != 0)
                        {
                            ((RepuestoReparacion)o).actualizarPresupuesto();
                        }
                        else
                        {
                            ((RepuestoReparacion)o).agregarPresupuesto(IdReparacion);
                        }
                    }

                    //ELIMINAR LOS REPUESTOS QUE SE QUITARON
                    foreach (object o in DetalleRepuestosEliminados)
                    {
                        ((RepuestoReparacion)o).eliminarDetallePresupuesto(IdReparacion);                        
                    }

                    //ELIMINAR LAS CARGAS QUE SE QUITARON
                    foreach (object o in DetalleCargaEliminados)
                    {
                        ((RepuestoReparacion)o).eliminarDetallePresupuesto(IdReparacion);
                    }

                    //ACTUALIZAR LAS TAREAS REALIZADAS
                    foreach (object o in DetalleTarea)
                    {
                        if (((TareaReparacion)o).IdTareaReparacion != 0)
                        {
                            ((TareaReparacion)o).actualizar();
                        }
                        else
                        {
                            ((TareaReparacion)o).agregar(IdReparacion);
                        }
                    }

                    //ELIMINAR LAS TAREAS QUE SE ELIMINARON
                    foreach (object o in DetalleTareaEliminados)
                    {
                        ((TareaReparacion)o).eliminarDetalle(IdReparacion);
                    }

                    flagContinuar = true;
                }
                catch { flagContinuar = false; }

                if (flagContinuar)
                {
                    SQL_p = "UPDATE reparacion SET fecha='" + String.Format("{0:yyyy/MM/dd}", Fecha) + "', descripcion='" + Descripcion + "', importe='" + ImporteTotal
                        + "', vehiculo_idvehiculo='" + Vehiculo.Id + "', cliente_idcliente='" + Cliente.Id + "', estado='" + Estado + "' " +
                        "WHERE idreparacion='" + IdReparacion + "'";

                    Conector.ejecutar(SQL_p);
                }
                return;
            }
            else if (estado_p == 1)
            {
                //ES UNA OT
                //ES UNA OT
                //ES UNA OT
                //ES UNA OT
                try
                {
                    //ACTUALIZAR LOS REPUESTOS UTILIZADOS
                    foreach (object o in DetalleRepuestos)
                    {
                        if (((RepuestoReparacion)o).IdRepuestoReparacion != 0)
                        {
                            //CAMBIOS EN LA REPARACION
                            ((RepuestoReparacion)o).actualizarReparacion();
                        }
                        else
                        {
                            ((RepuestoReparacion)o).agregarReparacion(IdReparacion);
                        }
                    }

                    //ACTUALIZAR LAS CARGAS DE GAS HECHAS
                    foreach (object o in DetalleCargas)
                    {
                        if (((RepuestoReparacion)o).IdRepuestoReparacion != 0)
                        {
                            //CAMBIOS EN LA REPARACION
                            ((RepuestoReparacion)o).actualizarReparacion();    
                        }
                        else
                        {
                            ((RepuestoReparacion)o).agregarReparacion(IdReparacion);
                        }
                    }

                    //ELIMINAR LOS REPUESTOS QUE SE QUITARON
                    foreach (object o in DetalleRepuestosEliminados)
                    {
                        //ES UNA OT SE ELIMINAN LOS REPUESTOS DE LA REPARACION
                        //SE DEVUELVE LA CANTIDAD AL STOCK DE REPUESTOS    
                        ((RepuestoReparacion)o).eliminarDetalle(IdReparacion);   
                    }

                    //ELIMINAR LAS CARGAS DE GAS QUE SE QUITARON
                    foreach (object o in DetalleCargaEliminados)
                    {
                        ((RepuestoReparacion)o).eliminarDetalle(IdReparacion);
                    }

                    //ACTUALIZAR LAS TAREAS REALIZADAS
                    foreach (object o in DetalleTarea)
                    {
                        if (((TareaReparacion)o).IdTareaReparacion != 0)
                        {
                            ((TareaReparacion)o).actualizar();
                        }
                        else
                        {
                            ((TareaReparacion)o).agregar(IdReparacion);
                        }
                    }

                    //ELIMINAR LAS TAREAS QUE SE ELIMINARON
                    foreach (object o in DetalleTareaEliminados)
                    {
                        ((TareaReparacion)o).eliminarDetalle(IdReparacion);
                    }

                    flagContinuar = true;
                }
                catch { flagContinuar = false; }

                if (flagContinuar)
                {
                    SQL_p = "UPDATE reparacion SET fecha='" + String.Format("{0:yyyy/MM/dd}", Fecha) + "', descripcion='" + Descripcion + "', importe='" + ImporteTotal
                        + "', vehiculo_idvehiculo='" + Vehiculo.Id + "', cliente_idcliente='" + Cliente.Id + "', estado='" + Estado + "', codigoreparacion='"+CodigoReparacion+"' " +
                        "WHERE idreparacion='" + IdReparacion + "'";

                    Conector.ejecutar(SQL_p);

                    if (EstadoAnterior == 0)
                    {
                        this.actualizarCodigoReparacion("OT-" + String.Format("{0:yyyyMM}", FechaSistema) + "-" + this.IdReparacion + "");
                    }
                }

            }
            else if (estado_p==4) //es 4 porque 2 es para ya facturada
            {
                //CAMBIO DE OT A PRESUPUESTO
                //CAMBIO DE OT A PRESUPUESTO
                //CAMBIO DE OT A PRESUPUESTO

                SQL_p = "UPDATE reparacion SET estado='" + Estado + "' " +
                    "WHERE idreparacion='" + IdReparacion + "'";

                Conector.ejecutar(SQL_p);

                //ACTUALIZAR LOS REPUESTOS UTILIZADOS
                foreach (object o in DetalleRepuestos)
                {
                    if (((RepuestoReparacion)o).IdRepuestoReparacion != ((RepuestoReparacion)o).IdRepuesto)
                    {
                        ((RepuestoReparacion)o).DevolverRepuesto();
                    }
                }

                //ACTUALIZAR LAS CARGAS UTILIZADAS
                foreach (object o in DetalleCargas)
                {
                    if (((RepuestoReparacion)o).IdRepuestoReparacion != ((RepuestoReparacion)o).IdRepuesto)
                    {
                        ((RepuestoReparacion)o).DevolverRepuesto();
                    }
                }
                return;
            }
        }

        /// <summary>
        /// Actualiza solamente el estado de la reparacion
        /// </summary>
        public void actualizarEstado()
        {
            string SQL_p;

            SQL_p = "UPDATE reparacion SET estado='" + Estado + "' " +
                       "WHERE idreparacion='" + IdReparacion + "'";

            Conector.ejecutar(SQL_p);
        }

        public virtual void eliminar()
        {
            string SQL_p;

            SQL_p = "DELETE FROM reparacion WHERE idreparacion='" + IdReparacion + "'";

            Conector.ejecutar(SQL_p);
        }

        //Eliminar pero queda en el sistema
        public virtual void eliminarBeta()
        {
            this.getReparacion();
            this.Estado = 6;
            this.actualizarEstado();

            //ACTUALIZAR LOS REPUESTOS UTILIZADOS
            foreach (object o in DetalleRepuestos)
            {
                if (!((RepuestoReparacion)o).FlagRepuestoManual)
                {
                    ((RepuestoReparacion)o).DevolverRepuesto();
                }
            }

            //ACTUALIZAR LAS CARGAS UTILIZADAS
            foreach (object o in DetalleCargas)
            {
                ((RepuestoReparacion)o).DevolverRepuesto();
            }
        }

        public void getReparacionSaldo()
        {
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT IFNULL(factura.saldo, reparacion.importe) AS saldo " +
                    "FROM reparacion INNER JOIN factura "+
                    "ON reparacion.idreparacion = factura.reparacion_idreparacion "+
                    "WHERE reparacion.idreparacion='" + IdReparacion + "' ";

            Reader = Conector.consultar(SQL_p);

            if (Reader.Read())
            {
                //DATOS REPARACION
                this.Cliente.Deuda = Reader.GetDouble("saldo");
            }
            else
            {
                this.Cliente.Deuda = 0;
            }

            Reader.Close();
            
        }

        /// <summary>
        /// Obtengo los datos principales de la reparacion sin las tareas ni los repuestos
        /// </summary>
        /// <returns></returns>
        public bool getReparacion()
        {
            string SQL_p;
            MySqlDataReader Reader;
            ArrayList colReparacion = new ArrayList();

            SQL_p = "SELECT reparacion.*, vehiculo.*, cliente.razonsocial " +
                    "FROM reparacion INNER JOIN cliente INNER JOIN vehiculo " +
                    "ON reparacion.vehiculo_idvehiculo = vehiculo.idvehiculo AND reparacion.cliente_idcliente = cliente.idcliente " +
                    "WHERE reparacion.idreparacion='" + IdReparacion + "' LIMIT 1";

            Reader = Conector.consultar(SQL_p);

            if (Reader.Read())
            {
                //DATOS REPARACION
                this.IdReparacion = Reader.GetInt32("idreparacion");
                this.ImporteTotal = Reader.GetDouble("importe");
                this.Fecha = Reader.GetDateTime("fecha");
                this.FechaSistema = Reader.GetDateTime("fechasistema");
                this.Descripcion = Reader.GetString("descripcion");
                this.Estado = Reader.GetInt32("estado");
                this.EstadoAnterior = Reader.GetInt32("estado");
                this.CodigoReparacion = Reader.GetString("codigoreparacion");

                //DATOS VEHICULO
                this.Vehiculo.Id = Reader.GetInt32("vehiculo_idvehiculo");
                this.Vehiculo.Dominio = Reader.GetString("dominio");
                this.Vehiculo.Marca = Reader.GetString("marca");
                this.Vehiculo.Modelo = Reader.GetString("modelo");
                this.Vehiculo.Anio = Reader.GetString("anio");
                this.Vehiculo.CapacidadCarga = Reader.GetDouble("capacidadcarga");

                //DATOS CLIENTE
                this.Cliente.Id = Reader.GetInt32("cliente_idcliente");
                this.Cliente.NombreRazonSocial = Reader.GetString("razonsocial");

                Reader.Close();

                this.getRepuestos();
                this.getRepuestosGenericos();
                this.getRepuestosGas();
                this.getTareas();
                this.getTareasGenericas();
                return true;
            }
            else
            {
                Reader.Close();
                return false;
            }

        }

        public void getTareas()
        {
            string SQL_p;
            MySqlDataReader Reader;

            //TAREAS CON PRECIOS PREDEFINIDOS
            /*SQL_p = "SELECT tareareparacion.*, tarea.descripciontarea, tarea.costo, tarea.duracion " +
                    "FROM tareareparacion INNER JOIN tarea " +
                    "ON tareareparacion.tarea_idtarea = tarea.idtarea " +
                    "WHERE tareareparacion.reparacion_idreparacion = '" + IdReparacion + "'";*/

            //TAREAS CON PRECIOS DEFINIDOS AL MOMENTO DE LA REPARACION
            SQL_p = "SELECT tareareparacion.*, tarea.descripciontarea, tarea.costo, tarea.duracion " +
                    "FROM tareareparacion INNER JOIN tarea " +
                    "ON tareareparacion.tarea_idtarea = tarea.idtarea " +
                    "WHERE tareareparacion.reparacion_idreparacion = '" + IdReparacion + "'";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                TareaReparacion objTareaLocal = new TareaReparacion();

                objTareaLocal.IdTareaReparacion = Reader.GetInt32("idtareareparacion");
                objTareaLocal.IdTarea = Reader.GetInt32("tarea_idtarea");
                objTareaLocal.DescripcionTarea = Reader.GetString("descripciontarea");
                objTareaLocal.Duracion = Reader.GetTimeSpan("duracion");
                objTareaLocal.Costo = Reader.GetDouble("preciotarea"); //DEBEMOS CAMBIAR ESTE CAMPO SI QUEREMOS USAR LA OTRA CONSULTA
                objTareaLocal.Cantidad = Reader.GetDouble("cantidad");

                this.DetalleTarea.Add(objTareaLocal);
            }

            Reader.Close();
        }

        //REPUESTOS NO GAS
        public void getRepuestos()
        {
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT repuestoreparacion.*, (repuestoreparacion.preciototal/repuestoreparacion.cantidadreparacion) AS preciounitariofacturado, "+
                    "repuestostock.codigorepuesto, repuestostock.descripcion, repuestostock.marca, repuestostock.modelo, repuestostock.precio, repuestostock.cantidad, tipo.gas " +
                    "FROM repuestoreparacion INNER JOIN repuestostock INNER JOIN tipo " +
                    "ON repuestoreparacion.repuestostock_idrepuestostock = repuestostock.idrepuestostock AND repuestostock.tipo_idtipo = tipo.idtipo " +
                    "WHERE repuestoreparacion.reparacion_idreparacion = '" + IdReparacion + "' AND tipo.gas='0'";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                RepuestoReparacion objRepuestoLocal = new RepuestoReparacion();

                objRepuestoLocal.Gas = Reader.GetInt32("gas");
                objRepuestoLocal.IdRepuestoReparacion = Reader.GetInt32("idrepuestoreparacion");
                objRepuestoLocal.IdRepuesto = Reader.GetInt32("repuestostock_idrepuestostock");
                objRepuestoLocal.IdRepuestoManual = "";
                objRepuestoLocal.DescripcionRepuesto = Reader.GetString("descripcion");
                objRepuestoLocal.CodigoRepuesto = Reader.GetString("codigorepuesto");
                objRepuestoLocal.Marca = Reader.GetString("marca");
                objRepuestoLocal.Modelo = Reader.GetString("modelo");
                objRepuestoLocal.PrecioUnitario = Reader.GetDouble("precio");
                objRepuestoLocal.PrecioUnitarioFacturado = Reader.GetDouble("preciounitariofacturado");
                objRepuestoLocal.CantidadStock = Reader.GetDouble("cantidad");
                objRepuestoLocal.CantidadRequerida = Reader.GetDouble("cantidadreparacion");
                objRepuestoLocal.CantidadRequeridaAnterior = Reader.GetDouble("cantidadreparacion");
                objRepuestoLocal.FlagRepuestoManual = false;

                this.DetalleRepuestos.Add(objRepuestoLocal);
            }
            Reader.Close();
        }

        //REPUESTOS GAS
        public void getRepuestosGas()
        {
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT repuestoreparacion.*, (repuestoreparacion.preciototal/repuestoreparacion.cantidadreparacion) AS preciounitariofacturado, "+
                    "repuestostock.codigorepuesto, repuestostock.descripcion, repuestostock.marca, repuestostock.modelo, repuestostock.precio, repuestostock.cantidad, tipo.gas " +
                    "FROM repuestoreparacion INNER JOIN repuestostock INNER JOIN tipo " +
                    "ON repuestoreparacion.repuestostock_idrepuestostock = repuestostock.idrepuestostock AND repuestostock.tipo_idtipo = tipo.idtipo " +
                    "WHERE repuestoreparacion.reparacion_idreparacion = '" + IdReparacion + "' AND tipo.gas='1'";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                RepuestoReparacion objRepuestoLocal = new RepuestoReparacion();

                objRepuestoLocal.Gas = Reader.GetInt32("gas");
                objRepuestoLocal.IdRepuestoReparacion = Reader.GetInt32("idrepuestoreparacion");
                objRepuestoLocal.IdRepuesto = Reader.GetInt32("repuestostock_idrepuestostock");
                objRepuestoLocal.IdRepuestoManual = "";
                objRepuestoLocal.DescripcionRepuesto = Reader.GetString("descripcion");
                objRepuestoLocal.CodigoRepuesto = Reader.GetString("codigorepuesto");
                objRepuestoLocal.Marca = Reader.GetString("marca");
                objRepuestoLocal.Modelo = Reader.GetString("modelo");
                objRepuestoLocal.PrecioUnitario = Reader.GetDouble("precio");
                objRepuestoLocal.PrecioUnitarioFacturado = Reader.GetDouble("preciounitariofacturado");
                objRepuestoLocal.CantidadStock = Reader.GetDouble("cantidad");
                objRepuestoLocal.CantidadRequerida = Reader.GetDouble("cantidadreparacion");
                objRepuestoLocal.CantidadRequeridaAnterior = Reader.GetDouble("cantidadreparacion");
                objRepuestoLocal.FlagRepuestoManual = false;

                this.DetalleCargas.Add(objRepuestoLocal);
            }
            Reader.Close();
        }

        public void getRepuestosGenericos()
        {
            string SQL_p;
            MySqlDataReader Reader;
            ArrayList colReparacion = new ArrayList();

            SQL_p = "SELECT *, (preciototal/cantidadreparacion) AS preciounitario " +
                    "FROM repuestogenerico " +
                    "WHERE repuestogenerico.reparacion_idreparacion = '" + IdReparacion + "'";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                RepuestoReparacion objRepuestoLocal = new RepuestoReparacion();

                objRepuestoLocal.IdRepuestoReparacion = Reader.GetInt32("idrepuestogenerico");
                objRepuestoLocal.CodigoRepuesto = Reader.GetString("codigorepuesto");
                objRepuestoLocal.IdRepuesto = Reader.GetInt32("idrepuestogenerico");
                objRepuestoLocal.DescripcionRepuesto = Reader.GetString("descripcion");
                objRepuestoLocal.Marca = Reader.GetString("marca");
                objRepuestoLocal.Modelo = Reader.GetString("modelo");
                objRepuestoLocal.PrecioUnitario = Reader.GetDouble("preciounitario");
                objRepuestoLocal.CantidadRequerida = Reader.GetDouble("cantidadreparacion");
                objRepuestoLocal.CantidadRequeridaAnterior = Reader.GetDouble("cantidadreparacion");
                objRepuestoLocal.FlagRepuestoManual = true;

                this.DetalleRepuestos.Add(objRepuestoLocal);
            }
            Reader.Close();
        }

        public void getTareasGenericas()
        {
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT * " +
                    "FROM tareagenerica " +
                    "WHERE tareagenerica.reparacion_idreparacion = '" + IdReparacion + "'";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                TareaReparacion objTareaLocal = new TareaReparacion();

                objTareaLocal.IdTareaReparacion = Reader.GetInt32("idtareagenerica");
                objTareaLocal.IdTarea = Reader.GetInt32("idtareagenerica");
                objTareaLocal.DescripcionTarea = Reader.GetString("descripciontarea");
                objTareaLocal.Costo = Reader.GetDouble("preciotarea");
                objTareaLocal.Cantidad = Reader.GetDouble("cantidad");
                objTareaLocal.FlagTareaManual = true;

                this.DetalleTarea.Add(objTareaLocal);
            }
            Reader.Close();
        }

        public void actualizarCodigoReparacion(string codigoReparacion_p)
        {
            string SQL_p;

            SQL_p = "UPDATE reparacion SET codigoreparacion = '" + codigoReparacion_p + "' WHERE idreparacion='"+this.IdReparacion+"'";
            Conector.ejecutar(SQL_p);

            this.CodigoReparacion = codigoReparacion_p;
        }

        public int getUltimoId()
        {
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT idreparacion FROM reparacion ORDER BY idreparacion DESC LIMIT 1";

            Reader = Conector.consultar(SQL_p);
            if (Reader.Read())
            {
                int ultimoId = Reader.GetInt32("idreparacion");
                Reader.Close();
                return ultimoId;
            }
            else
            {
                Reader.Close();
                return 0;
            }
        }
    }
}
