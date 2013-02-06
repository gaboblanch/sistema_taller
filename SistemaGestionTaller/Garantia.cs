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
    class Garantia
    {
        private Reparacion reparacion;        
        private int id;
        private DateTime fechasistema;
        private DateTime fechagarantia;
        private string descripciongarantia;
        private double importegarantia;

        //COLECCIONES DE LA GARANTIA
        private ArrayList detalleRepuestos;
        private ArrayList detalleCargas;
        private ArrayList detalleTareas;

        //COLECCIONES DE ELEMENTOS ELIMINADOS
        private ArrayList detalleRepuestosEliminados;
        private ArrayList detalleCargasEliminadas;
        private ArrayList detalleTareasEliminadas;

        public Garantia()
        {
            reparacion = new Reparacion();
            fechagarantia = new DateTime();
            fechasistema = new DateTime();
            
            detalleCargas = new ArrayList();
            detalleRepuestos = new ArrayList();
            detalleTareas = new ArrayList();

            detalleCargasEliminadas = new ArrayList();
            detalleRepuestosEliminados = new ArrayList();
            detalleTareasEliminadas = new ArrayList();
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime FechaSistema
        {
            get { return fechasistema; }
            set { fechasistema = value; }
        }

        public DateTime FechaGarantia
        {
            get { return fechagarantia; }
            set { fechagarantia = value; }
        }

        public string Descripcion
        {
            get { return descripciongarantia; }
            set { descripciongarantia = value; }
        }

        public double Importe
        {
            get { return importegarantia; }
            set { importegarantia = value; }
        }

        public Reparacion Reparacion
        {
            get { return reparacion; }
            set { reparacion = value; }
        }

        public ArrayList DetalleRepuestos
        {
            get { return detalleRepuestos; }
            set { detalleRepuestos = value; }
        }

        public ArrayList DetalleCargas
        {
            get { return detalleCargas; }
            set { detalleCargas = value; }
        }

        public ArrayList DetalleTareas
        {
            get { return detalleTareas; }
            set { detalleTareas = value; }
        }

        public ArrayList DetalleRepuestosEliminados
        {
            get { return detalleRepuestosEliminados; }
            set { detalleRepuestosEliminados = value; }
        }

        public ArrayList DetalleCargasEliminadas
        {
            get { return detalleCargasEliminadas; }
            set { detalleCargasEliminadas = value; }
        }

        public ArrayList DetalleTareasEliminadas
        {
            get { return detalleTareasEliminadas; }
            set { detalleTareasEliminadas = value; }
        }

        public void agregar()
        {
            string SQL_p;

            SQL_p = "INSERT INTO garantia (fechasistema, fechagarantia, descripciongarantia, importegarantia, reparacion_idreparacion, estadoanteriorreparacion) " +
                    "VALUES ('" + String.Format("{0:yyyy/MM/dd}", FechaSistema) + "', '" + String.Format("{0:yyyy/MM/dd}", FechaGarantia) + "', '" + Descripcion + "', '" + Importe + "', '" + Reparacion.IdReparacion + "', '"+Reparacion.Estado+"')";

            Conector.ejecutar(SQL_p);
            this.Id = Conector.getLastID();

            Reparacion.Estado = 4;
            Reparacion.actualizarEstado();

            foreach (object o in DetalleRepuestos)
            {
                ((RepuestoReparacion)o).agregarGarantia(this.Id);
            }

            foreach (object o in DetalleCargas)
            {
                ((RepuestoReparacion)o).agregarGarantia(this.Id);
            }

            foreach (object o in DetalleTareas)
            {
                ((TareaReparacion)o).agregarGarantia(this.Id);
            }

        }

        public void actualizar()
        {
            string SQL_p;

            SQL_p = "UPDATE garantia SET descripciongarantia='" + Descripcion + "', importegarantia='" + Importe + "' " +
                    "WHERE idgarantia='" + Id + "'";

            Conector.ejecutar(SQL_p);

            foreach (object o in DetalleRepuestos)
            {
                if (((RepuestoReparacion)o).IdRepuestoReparacion == 0)
                    ((RepuestoReparacion)o).agregarGarantia(this.Id);
                else
                    ((RepuestoReparacion)o).actualizarGarantia();
            }

            foreach (object o in DetalleCargas)
            {
                if (((RepuestoReparacion)o).IdRepuestoReparacion == 0)
                    ((RepuestoReparacion)o).agregarGarantia(this.Id);
                else
                    ((RepuestoReparacion)o).actualizarGarantia();
            }

            foreach (object o in DetalleTareas)
            {
                if (((TareaReparacion)o).IdTareaReparacion == 0)
                    ((TareaReparacion)o).agregarGarantia(this.Id);
                else
                    ((TareaReparacion)o).actualizarGarantia();
            }
        }

        public void eliminar()
        {
            string SQL_p;

            SQL_p = "DELETE FROM garantia WHERE idgarantia = '" + Id + "'";

            Conector.ejecutar(SQL_p);

            //Buscar se la reparacion esta saldada o no para poner estado 3 o 2.
        }

        public bool getGarantia()
        {
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT garantia.*, reparacion.codigoreparacion, cliente.idcliente, cliente.razonsocial, " +
                    "vehiculo.idvehiculo, vehiculo.dominio, vehiculo.marca, vehiculo.modelo " +
                    "FROM garantia INNER JOIN reparacion INNER JOIN cliente INNER JOIN vehiculo " +
                    "ON garantia.reparacion_idreparacion = reparacion.idreparacion AND reparacion.cliente_idcliente = cliente.idcliente " +
                    "AND reparacion.vehiculo_idvehiculo = vehiculo.idvehiculo WHERE garantia.idgarantia = '" + this.Id + "' ";

            Reader = Conector.consultar(SQL_p);

            if (Reader.Read())
            {
                //Detalles Garantia
                this.Id = Reader.GetInt32("idgarantia");
                this.Importe = Reader.GetDouble("importegarantia");
                this.Descripcion = Reader.GetString("descripciongarantia");
                this.FechaGarantia = Reader.GetDateTime("fechagarantia");
                this.FechaSistema = Reader.GetDateTime("fechasistema");

                //Detalles Reparacion
                this.Reparacion.IdReparacion = Reader.GetInt32("reparacion_idreparacion");
                this.Reparacion.CodigoReparacion = Reader.GetString("codigoreparacion");
                this.Reparacion.EstadoAnterior = Reader.GetInt32("estadoanteriorreparacion");

                //Detalles Cliente
                this.Reparacion.Cliente.Id = Reader.GetInt32("idcliente");
                this.Reparacion.Cliente.NombreRazonSocial = Reader.GetString("razonsocial");

                //Detalles Vehiculos
                this.Reparacion.Vehiculo.Id = Reader.GetInt32("idvehiculo");
                this.Reparacion.Vehiculo.Dominio = Reader.GetString("dominio");
                this.Reparacion.Vehiculo.Marca = Reader.GetString("marca");
                this.Reparacion.Vehiculo.Modelo = Reader.GetString("modelo");

                Reader.Close();
                this.getRepuestos();
                this.getRepuestosGas();
                this.getRepuestosGenericos();
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

        /// <summary>
        /// Busca por nombre del cliente
        /// </summary>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <returns></returns>
        public ArrayList coleccionRazonsocial(string fechaInicio, string fechaFin)
        {
            ArrayList colGarantias = new ArrayList();
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT garantia.*, reparacion.codigoreparacion, cliente.idcliente, cliente.razonsocial, "+
                    "vehiculo.idvehiculo, vehiculo.dominio, vehiculo.marca, vehiculo.modelo "+
                    "FROM garantia INNER JOIN reparacion INNER JOIN cliente INNER JOIN vehiculo "+
                    "ON garantia.reparacion_idreparacion = reparacion.idreparacion AND reparacion.cliente_idcliente = cliente.idcliente "+
                    "AND reparacion.vehiculo_idvehiculo = vehiculo.idvehiculo WHERE cliente.razonsocial LIKE '%"+Reparacion.Cliente.Filtro+"%' "+
                    "AND garantia.fechagarantia BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "' ORDER BY cliente.razonsocial";

            Reader = Conector.consultar(SQL_p);

            while(Reader.Read())
            {
                Garantia objGarantia = new Garantia();

                //Detalles Garantia
                objGarantia.Id = Reader.GetInt32("idgarantia");
                objGarantia.Importe = Reader.GetDouble("importegarantia");
                objGarantia.Descripcion = Reader.GetString("descripciongarantia");
                objGarantia.FechaGarantia = Reader.GetDateTime("fechagarantia");
                objGarantia.FechaSistema = Reader.GetDateTime("fechasistema");

                //Detalles Reparacion
                objGarantia.Reparacion.IdReparacion = Reader.GetInt32("reparacion_idreparacion");
                objGarantia.Reparacion.CodigoReparacion = Reader.GetString("codigoreparacion");
                objGarantia.Reparacion.EstadoAnterior = Reader.GetInt32("estadoanteriorreparacion");

                //Detalles Cliente
                objGarantia.Reparacion.Cliente.Id = Reader.GetInt32("idcliente");
                objGarantia.Reparacion.Cliente.NombreRazonSocial = Reader.GetString("razonsocial");

                //Detalles Vehiculos
                objGarantia.Reparacion.Vehiculo.Id = Reader.GetInt32("idvehiculo");
                objGarantia.Reparacion.Vehiculo.Dominio = Reader.GetString("dominio");
                objGarantia.Reparacion.Vehiculo.Marca = Reader.GetString("marca");
                objGarantia.Reparacion.Vehiculo.Modelo = Reader.GetString("modelo");

                colGarantias.Add(objGarantia);
            }
            Reader.Close();
            return colGarantias;
        }

        public ArrayList coleccionDominio(string fechaInicio, string fechaFin)
        {
            ArrayList colGarantias = new ArrayList();
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT garantia.*, reparacion.codigoreparacion, cliente.idcliente, cliente.razonsocial, " +
                    "vehiculo.idvehiculo, vehiculo.dominio, vehiculo.marca, vehiculo.modelo " +
                    "FROM garantia INNER JOIN reparacion INNER JOIN cliente INNER JOIN	vehiculo " +
                    "ON garantia.reparacion_idreparacion = reparacion.idreparacion AND reparacion.cliente_idcliente = cliente.idcliente " +
                    "AND reparacion.vehiculo_idvehiculo = vehiculo.idvehiculo WHERE vehiculo.dominio='" + Reparacion.Cliente.Filtro + "' " +
                    "AND garantia.fechagarantia BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "' ORDER BY cliente.razonsocial";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                Garantia objGarantia = new Garantia();

                //Detalles Garantia
                objGarantia.Id = Reader.GetInt32("idgarantia");
                objGarantia.Importe = Reader.GetDouble("importegarantia");
                objGarantia.Descripcion = Reader.GetString("descripciongarantia");
                objGarantia.FechaGarantia = Reader.GetDateTime("fechagarantia");
                objGarantia.FechaSistema = Reader.GetDateTime("fechasistema");

                //Detalles Reparacion
                objGarantia.Reparacion.IdReparacion = Reader.GetInt32("reparacion_idreparacion");
                objGarantia.Reparacion.CodigoReparacion = Reader.GetString("codigoreparacion");
                objGarantia.Reparacion.EstadoAnterior = Reader.GetInt32("estadoanteriorreparacion");

                //Detalles Cliente
                objGarantia.Reparacion.Cliente.Id = Reader.GetInt32("idcliente");
                objGarantia.Reparacion.Cliente.NombreRazonSocial = Reader.GetString("razonsocial");

                //Detalles Vehiculos
                objGarantia.Reparacion.Vehiculo.Id = Reader.GetInt32("idvehiculo");
                objGarantia.Reparacion.Vehiculo.Dominio = Reader.GetString("dominio");
                objGarantia.Reparacion.Vehiculo.Marca = Reader.GetString("marca");
                objGarantia.Reparacion.Vehiculo.Modelo = Reader.GetString("modelo");

                colGarantias.Add(objGarantia);
            }
            Reader.Close();
            return colGarantias;
        }

        public void getTareas()
        {
            string SQL_p;
            MySqlDataReader Reader;

            //TAREAS CON PRECIOS DEFINIDOS AL MOMENTO DE LA REPARACION
            SQL_p = "SELECT tarea.descripciontarea, tareagarantia.* "+
                    "FROM tareagarantia INNER JOIN tarea "+
                    "ON tareagarantia.tarea_idtarea = tarea.idtarea "+
                    "WHERE tareagarantia.garantia_idgarantia = '"+this.Id+"'";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                TareaReparacion objTareaLocal = new TareaReparacion();

                objTareaLocal.IdTareaReparacion = Reader.GetInt32("idtareagarantia");
                objTareaLocal.IdTarea = Reader.GetInt32("tarea_idtarea");
                objTareaLocal.DescripcionTarea = Reader.GetString("descripciontarea");
                //objTareaLocal.Duracion = Reader.GetTimeSpan("duracion");
                objTareaLocal.Costo = Reader.GetDouble("preciotareagarantia"); //DEBEMOS CAMBIAR ESTE CAMPO SI QUEREMOS USAR LA OTRA CONSULTA
                objTareaLocal.Cantidad = Reader.GetDouble("cantidadtarea");

                this.DetalleTareas.Add(objTareaLocal);
            }

            Reader.Close();
        }

        //REPUESTOS NO GAS
        public void getRepuestos()
        {
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT repuestogarantia.*, repuestostock.codigorepuesto, repuestostock.descripcion, repuestostock.marca, repuestostock.modelo, repuestostock.costo, repuestostock.cantidad, tipo.gas "+
                    "FROM repuestogarantia INNER JOIN repuestostock INNER JOIN tipo "+
                    "ON repuestogarantia.repuestostock_idrepuestostock = repuestostock.idrepuestostock AND repuestostock.tipo_idtipo = tipo.idtipo "+
                    "WHERE repuestogarantia.garantia_idgarantia = '"+Id+"' AND tipo.gas='0'";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                RepuestoReparacion objRepuestoLocal = new RepuestoReparacion();

                objRepuestoLocal.Gas = Reader.GetInt32("gas");
                objRepuestoLocal.IdRepuestoReparacion = Reader.GetInt32("idrepuestogarantia");
                objRepuestoLocal.IdRepuesto = Reader.GetInt32("repuestostock_idrepuestostock");
                objRepuestoLocal.DescripcionRepuesto = Reader.GetString("descripcion");
                objRepuestoLocal.CodigoRepuesto = Reader.GetString("codigorepuesto");
                objRepuestoLocal.Marca = Reader.GetString("marca");
                objRepuestoLocal.Modelo = Reader.GetString("modelo");
                objRepuestoLocal.Costo = Reader.GetDouble("costo"); // Aca traigo el ultimo precio deberia ver de traer el precio total y dividirlo por las unidades requeridas
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

            SQL_p = "SELECT repuestogarantia.*, repuestostock.codigorepuesto, repuestostock.descripcion, repuestostock.marca, repuestostock.modelo, repuestostock.costo, repuestostock.cantidad, tipo.gas " +
                    "FROM repuestogarantia INNER JOIN repuestostock INNER JOIN tipo " +
                    "ON repuestogarantia.repuestostock_idrepuestostock = repuestostock.idrepuestostock AND repuestostock.tipo_idtipo = tipo.idtipo " +
                    "WHERE repuestogarantia.garantia_idgarantia = '"+Id+"' AND tipo.gas='1'";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                RepuestoReparacion objRepuestoLocal = new RepuestoReparacion();

                objRepuestoLocal.Gas = Reader.GetInt32("gas");
                objRepuestoLocal.IdRepuestoReparacion = Reader.GetInt32("idrepuestogarantia");
                objRepuestoLocal.IdRepuesto = Reader.GetInt32("repuestostock_idrepuestostock");
                objRepuestoLocal.DescripcionRepuesto = Reader.GetString("descripcion");
                objRepuestoLocal.CodigoRepuesto = Reader.GetString("codigorepuesto");
                objRepuestoLocal.Marca = Reader.GetString("marca");
                objRepuestoLocal.Modelo = Reader.GetString("modelo");
                objRepuestoLocal.Costo = Reader.GetDouble("costo");
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

            SQL_p = "SELECT *, (preciototal/cantidadgarantia) AS preciounitario "+
                    "FROM repuestogarantiagenerico "+
                    "WHERE repuestogarantiagenerico.garantia_idgarantia = '"+this.Id+"'";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                RepuestoReparacion objRepuestoLocal = new RepuestoReparacion();

                objRepuestoLocal.IdRepuestoReparacion = Reader.GetInt32("idrepuestogarantiagenerico");
                objRepuestoLocal.CodigoRepuesto = Reader.GetString("codigorepuesto");
                objRepuestoLocal.IdRepuesto = Reader.GetInt32("idrepuestogarantiagenerico");
                objRepuestoLocal.DescripcionRepuesto = Reader.GetString("descripcion");
                objRepuestoLocal.Marca = Reader.GetString("marca");
                objRepuestoLocal.Modelo = Reader.GetString("modelo");
                objRepuestoLocal.Costo = Reader.GetDouble("preciounitario");
                objRepuestoLocal.CantidadRequerida = Reader.GetDouble("cantidadgarantia");
                objRepuestoLocal.CantidadRequeridaAnterior = Reader.GetDouble("cantidadgarantia");
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
                    "FROM tareagarantiagenerica " +
                    "WHERE tareagarantiagenerica.garantia_idgarantia = '" + this.Id + "'";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                TareaReparacion objTareaLocal = new TareaReparacion();

                objTareaLocal.IdTareaReparacion = Reader.GetInt32("idtareagarantigenerica");
                objTareaLocal.IdTarea = Reader.GetInt32("idtareagarantigenerica");
                objTareaLocal.DescripcionTarea = Reader.GetString("descripciontarea");
                objTareaLocal.Costo = Reader.GetDouble("preciotarea");
                objTareaLocal.Cantidad = Reader.GetDouble("cantidad");
                objTareaLocal.FlagTareaManual = true;

                this.DetalleTareas.Add(objTareaLocal);
            }
            Reader.Close();
        }
    }
}
