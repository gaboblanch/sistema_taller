using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using MySql.Data.MySqlClient;

namespace SistemaGestionTaller
{
    class Ingreso
    {
        private ArrayList detalleRepuestos;
        private ArrayList detalleTareas;
        private ArrayList detalleCargas;
        private int id;
        private string descripcion;
        private double importe;
        private DateTime fecha;
        private string filtro;
        //INICIO CODIGO NUEVO
        private ArrayList detalleFacturas;
        //FIN CODIGO NUEVO

        public Ingreso()
        {
            detalleRepuestos = new ArrayList();
            detalleTareas = new ArrayList();
            detalleCargas = new ArrayList();
            //INICIO CODIGO NUEVO
            detalleFacturas = new ArrayList();
            //FIN CODIGO NUEVO
            fecha = new DateTime();
        }

        public ArrayList DetalleRepuestos
        {
            get { return detalleRepuestos; }
            set { detalleRepuestos = value; }
        }

        public ArrayList DetalleTareas
        {
            get { return detalleTareas; }
            set { detalleTareas = value; }
        }

        public ArrayList DetalleCargas
        {
            get { return detalleCargas; }
            set { detalleCargas = value; }
        }

        public int IdIngreso
        {
            get { return id; }
            set { id = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public double Importe
        {
            get { return importe; }
            set { importe = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public string Filtro
        {
            get { return filtro; }
            set { filtro = value; }
        }
        //INICIO CODIGO NUEVO
        public ArrayList DetalleFacturas
        {
            get { return detalleFacturas; }
            set { detalleFacturas = value; }
        }
        //FIN CODIGO NUEVO
        public void agregar()
        {
            string SQL_p;
            SQL_p = "INSERT INTO ingreso (descripcioningreso, importeingreso, fechaingreso) " +
                    "VALUES ('" + Descripcion + "', '" + Importe + "', '" + String.Format("{0:yyyy/MM/dd}", Fecha) + "')";
            
            Conector.ejecutar(SQL_p);
        }

        public void actualizar()
        {
            string SQL_p;
            SQL_p = "UPDATE ingreso SET descripcioningreso = '" + Descripcion + "' , importeingreso = '" + Importe + "' , fechaingreso = '" + String.Format("{0:yyyy/MM/dd}", Fecha) + "'" +
	                "WHERE idingreso = '"+IdIngreso+"'";

            Conector.ejecutar(SQL_p);
        }

        public void eliminar()
        {
            string SQL_p;
            SQL_p = "DELETE FROM ingreso WHERE idingreso = '"+IdIngreso+"'";

            Conector.ejecutar(SQL_p);
        }

        public void getIngreso()
        {
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT * FROM ingreso WHERE idingreso = '" + IdIngreso + "'";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                //Datos Ingreso
                this.IdIngreso = Reader.GetInt32("idingreso");
                this.Descripcion = Reader.GetString("descripcioningreso");
                this.Importe = Reader.GetDouble("importeingreso");
                this.Fecha = Reader.GetDateTime("fechaingreso");
            }
            Reader.Close();
        }

        /// <summary>
        /// Lista de ingresos con rango de fechas y posibilidad de filtrado por descripcion
        /// </summary>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <returns>Lista de ingresos desde Inicio a Fin</returns>
        public ArrayList coleccion(string fechaInicio, string fechaFin)
        {
            string SQL_p;
            MySqlDataReader Reader;
            ArrayList colIngresos = new ArrayList();

            SQL_p = "SELECT * FROM ingreso WHERE descripcioningreso LIKE '%"+Filtro+"%' AND fechaingreso BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "' " +
                    "ORDER BY ingreso.descripcioningreso";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                Ingreso objIngreso = new Ingreso();
                //Datos Ingreso
                objIngreso.IdIngreso = Reader.GetInt32("idingreso");
                objIngreso.Descripcion = Reader.GetString("descripcioningreso");
                objIngreso.Importe = Reader.GetDouble("importeingreso");
                objIngreso.Fecha = Reader.GetDateTime("fechaingreso");

                colIngresos.Add(objIngreso);
            }
            Reader.Close();
            return colIngresos;
        }

        /// <summary>
        /// Ingresos generados por repuestos de stock
        /// </summary>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <returns>Coleccion de repuestos de stock</returns>
        public void coleccionRepuestoStock(string fechaInicio, string fechaFin)
        {
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT reparacion.fecha, repuestostock.idrepuestostock, repuestostock.descripcion, repuestostock.marca, repuestostock.modelo, repuestoreparacion.idrepuestoreparacion, " +
                    "SUM(repuestoreparacion.cantidadreparacion) AS cantidadtotal, (repuestoreparacion.preciototal/repuestoreparacion.cantidadreparacion) AS preciounitario, tipo.* " +
                    "FROM factura INNER JOIN reparacion INNER JOIN repuestoreparacion INNER JOIN tipo INNER JOIN repuestostock " +
                    "ON  factura.reparacion_idreparacion = reparacion.idreparacion AND "+
                    "repuestoreparacion.reparacion_idreparacion = reparacion.idreparacion " +
                    "AND repuestoreparacion.repuestostock_idrepuestostock = repuestostock.idrepuestostock " +
                    "AND repuestostock.tipo_idtipo = tipo.idtipo " +
                    "WHERE factura.fecha BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "' " +
                    "GROUP BY repuestoreparacion.repuestostock_idrepuestostock " +
                    "ORDER BY tipo.descripciontipo";

            Reader = Conector.consultar(SQL_p);
            
            while (Reader.Read())
            {
                RepuestoReparacion objRepuesto = new RepuestoReparacion();
                //Datos Repuesto
                objRepuesto.IdRepuesto = Reader.GetInt32("idrepuestostock");
                objRepuesto.Marca = Reader.GetString("marca");
                objRepuesto.Modelo = Reader.GetString("modelo");
                objRepuesto.DescripcionRepuesto = Reader.GetString("descripcion");
                objRepuesto.DescripcionTipo = Reader.GetString("descripciontipo");
                objRepuesto.Idtipo = Reader.GetInt32("idtipo");
                objRepuesto.Gas = Reader.GetInt32("gas");
                objRepuesto.FechaInicio = Reader.GetDateTime("fecha");

                //Repuesto Reparacion
                objRepuesto.IdRepuestoReparacion = Reader.GetInt32("idrepuestoreparacion");
                objRepuesto.FlagRepuestoManual = false;
                objRepuesto.PrecioUnitario = Reader.GetDouble("preciounitario");
                objRepuesto.CantidadRequerida = Reader.GetDouble("cantidadtotal");

                DetalleRepuestos.Add(objRepuesto);

            }
            Reader.Close();
        }

        /// <summary>
        /// Ingresos generados por repuestos agregados manualmente
        /// </summary>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <returns>Coleccion de repuestos de stock</returns>
        public void coleccionRepuestoGenericos(string fechaInicio, string fechaFin)
        {
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT reparacion.fecha, repuestogenerico.idrepuestogenerico, repuestogenerico.descripcion, SUM(repuestogenerico.cantidadreparacion) AS cantidadtotal, (repuestogenerico.preciototal/repuestogenerico.cantidadreparacion) AS preciounitario " +
                    "FROM factura INNER JOIN reparacion INNER JOIN repuestogenerico " +
                    "ON  factura.reparacion_idreparacion = reparacion.idreparacion "+
                    "AND repuestogenerico.reparacion_idreparacion = reparacion.idreparacion " +
                    "WHERE factura.fecha BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "' " +
                    "GROUP BY repuestogenerico.idrepuestogenerico "+
                    "ORDER BY repuestogenerico.descripcion";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                RepuestoReparacion objRepuesto = new RepuestoReparacion();
                //Datos Repuesto Manual
                objRepuesto.IdRepuesto = Reader.GetInt32("idrepuestogenerico");
                objRepuesto.DescripcionTipo = "Respuesto Manual";
                objRepuesto.DescripcionRepuesto = Reader.GetString("descripcion");
                objRepuesto.IdRepuestoReparacion = Reader.GetInt32("idrepuestogenerico");
                objRepuesto.FlagRepuestoManual = true;
                objRepuesto.PrecioUnitario = Reader.GetDouble("preciounitario");
                objRepuesto.CantidadRequerida = Reader.GetDouble("cantidadtotal");
                objRepuesto.FechaInicio = Reader.GetDateTime("fecha");

                DetalleRepuestos.Add(objRepuesto);

            }
            Reader.Close();
        }

        /// <summary>
        /// Ingresos generados por tareas precargadas
        /// </summary>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        public void coleccionTareas(string fechaInicio, string fechaFin)
        {
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT reparacion.fecha, tarea.idtarea, tarea.descripciontarea, tareareparacion.idtareareparacion, SUM(tareareparacion.preciotarea) AS preciototal " +
                    "FROM factura INNER JOIN reparacion INNER JOIN tarea INNER JOIN tareareparacion " +
                    "ON  factura.reparacion_idreparacion = reparacion.idreparacion "+
                    "AND tareareparacion.tarea_idtarea = tarea.idtarea " +
                    "AND tareareparacion.reparacion_idreparacion = reparacion.idreparacion "+
                    "WHERE factura.fecha BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "' " +
                    "GROUP BY tareareparacion.tarea_idtarea "+
                    "ORDER BY tarea.descripciontarea";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                TareaReparacion objTarea = new TareaReparacion();
                //Datos Repuesto Manual
                objTarea.IdTarea = Reader.GetInt32("idtarea");
                objTarea.DescripcionTarea = Reader.GetString("descripciontarea");
                objTarea.IdTareaReparacion = Reader.GetInt32("idtareareparacion");
                objTarea.FlagTareaManual = false;
                objTarea.Costo = Reader.GetDouble("preciototal");
                objTarea.Fecha = Reader.GetDateTime("fecha");

                DetalleTareas.Add(objTarea);

            }
            Reader.Close();
        }

        /// <summary>
        /// Ingresos generados por tareas manuales
        /// </summary>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        public void coleccionTareasGenericas(string fechaInicio, string fechaFin)
        {
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT reparacion.fecha, tareagenerica.idtareagenerica, tareagenerica.descripciontarea, SUM(tareagenerica.preciotarea) AS preciototal "+
                    "FROM factura INNER JOIN reparacion INNER JOIN tareagenerica " +
                    "ON factura.reparacion_idreparacion = reparacion.idreparacion "+
                    "AND tareagenerica.idtareagenerica = reparacion.idreparacion " +
                    "WHERE factura.fecha BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "' " +
                    "GROUP BY tareagenerica.idtareagenerica "+
                    "ORDER BY tareagenerica.descripciontarea";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                TareaReparacion objTarea = new TareaReparacion();
                //Datos Repuesto Manual
                objTarea.IdTarea = Reader.GetInt32("idtareagenerica");
                objTarea.DescripcionTarea = Reader.GetString("descripciontarea");
                objTarea.IdTareaReparacion = Reader.GetInt32("idtareagenerica");
                objTarea.FlagTareaManual = true;
                objTarea.Costo = Reader.GetDouble("preciototal");
                objTarea.Fecha = Reader.GetDateTime("fecha");

                DetalleTareas.Add(objTarea);

            }
            Reader.Close();
        }

        public void ingresoMensual(string fechaInicio, string fechaFin)
        {
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT (SELECT IFNULL(SUM(ingreso.importeingreso),0) " +
                    "FROM ingreso " +
                    "WHERE ingreso.fechaingreso BETWEEN '"+fechaInicio+"' AND '"+fechaFin+"') " +
                    "+ " +
                    "(SELECT IFNULL(SUM(pagosreparacion.importepago),0) " +
                    "FROM pagosreparacion " +
                    "WHERE pagosreparacion.fecha BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "') " +
                    "AS totalingresos";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                this.Descripcion = "Total ingresos del mes";
                this.Importe = Reader.GetDouble("totalingresos");
                this.Fecha = DateTime.Parse(fechaInicio);
            }
            Reader.Close();
        }

        //INICIO CODIGO NUEVO
        /// <summary>
        /// Ingresos generados por tareas manuales
        /// </summary>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        public void coleccionFacturas(string fechaInicio, string fechaFin)
        {
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT factura.idfactura,factura.fecha,factura.tipofactura,factura.codigofactura,factura.saldo, "+
	                "factura.bonificacion,reparacion.fecha,reparacion.codigoreparacion,SUM(pagosreparacion.importepago) AS importe_total " +
                    "FROM pagosreparacion INNER JOIN factura INNER JOIN reparacion " +
                    "ON factura.reparacion_idreparacion = reparacion.idreparacion AND pagosreparacion.factura_idfactura = factura.idfactura " +
                    "WHERE factura.fecha BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "' AND factura.anulada = 0 "+
                    "GROUP BY factura.idfactura " +
                    "ORDER BY factura.fecha";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                Factura objFactura = new Factura();
                objFactura.IdFactura = Reader.GetInt32("idfactura");
                objFactura.FechaFactura = Reader.GetDateTime("fecha");
                objFactura.TipoFactura = Reader.GetString("tipofactura");
                objFactura.NumeroFactura = Reader.GetString("codigofactura");
                objFactura.Saldo = Reader.GetDouble("saldo");
                objFactura.Bonificacion = Reader.GetDouble("bonificacion");
                objFactura.ImporteFactura = Reader.GetDouble("importe_total");
                objFactura.Reparacion.Fecha = Reader.GetDateTime("fecha");
                objFactura.Reparacion.CodigoReparacion = Reader.GetString("codigoreparacion");                

                DetalleFacturas.Add(objFactura);

            }
            Reader.Close();
        }
        //FIN CODIGO NUEVO
    }
}
