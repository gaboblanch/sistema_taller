using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using MySql.Data.MySqlClient;

namespace SistemaGestionTaller
{
    class Egreso
    {
        private ArrayList detalleRepuestos;
        private ArrayList detalleTareas;
        private ArrayList detalleCargas;
        private int id;
        private string descripcion;
        private double importe;
        private string filtro;
        private DateTime fecha;

        public Egreso()
        {
            detalleRepuestos = new ArrayList();
            detalleTareas = new ArrayList();
            detalleCargas = new ArrayList();
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

        public int IdEgreso
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

        public void agregar()
        {
            string SQL_p;
            SQL_p = "INSERT INTO egreso (descripcionegreso, importeegreso, fechaegreso) " +
                    "VALUES ('" + Descripcion + "', '" + Importe + "', '" + String.Format("{0:yyyy/MM/dd}", Fecha) + "')";

            Conector.ejecutar(SQL_p);
        }

        public void actualizar()
        {
            string SQL_p;
            SQL_p = "UPDATE egreso SET descripcionegreso = '" + Descripcion + "' , importeegreso = '" + Importe + "' , fechaegreso = '" + String.Format("{0:yyyy/MM/dd}", Fecha) + "'" +
                    "WHERE idegreso = '" + IdEgreso + "'";

            Conector.ejecutar(SQL_p);
        }

        public void eliminar()
        {
            string SQL_p;
            SQL_p = "DELETE FROM egreso WHERE idegreso = '" + IdEgreso + "'";

            Conector.ejecutar(SQL_p);
        }

        public void getEgreso()
        {
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT * FROM egreso WHERE idegreso = '" + IdEgreso + "'";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                //Datos Ingreso
                this.IdEgreso = Reader.GetInt32("idegreso");
                this.Descripcion = Reader.GetString("descripcionegreso");
                this.Importe = Reader.GetDouble("importeegreso");
                this.Fecha = Reader.GetDateTime("fechaegreso");
            }
            Reader.Close();
        }

        public ArrayList coleccion(string fechaInicio, string fechaFin)
        {
            string SQL_p;
            MySqlDataReader Reader;
            ArrayList colEgresos = new ArrayList();

            SQL_p = "SELECT * FROM egreso WHERE descripcionegreso LIKE '%" + Filtro + "%' AND fechaegreso BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "' " +
                    "ORDER BY egreso.descripcionegreso";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                Egreso objEgreso = new Egreso();
                //Datos Engreso
                objEgreso.IdEgreso = Reader.GetInt32("idegreso");
                objEgreso.Descripcion = Reader.GetString("descripcionegreso");
                objEgreso.Importe = Reader.GetDouble("importeegreso");
                objEgreso.Fecha = Reader.GetDateTime("fechaegreso");

                colEgresos.Add(objEgreso);
            }
            Reader.Close();
            return colEgresos;
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
                    "SUM(repuestoreparacion.cantidadreparacion) AS cantidadtotal, repuestostock.costo, tipo.* " +
                    "FROM reparacion INNER JOIN repuestoreparacion INNER JOIN tipo INNER JOIN repuestostock " +
                    "ON  repuestoreparacion.reparacion_idreparacion = reparacion.idreparacion " +
                    "AND repuestoreparacion.repuestostock_idrepuestostock = repuestostock.idrepuestostock " +
                    "AND repuestostock.tipo_idtipo = tipo.idtipo " +
                    "WHERE reparacion.fecha BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "' " +
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

                //Repuesto Reparacion
                objRepuesto.IdRepuestoReparacion = Reader.GetInt32("idrepuestoreparacion");
                objRepuesto.FlagRepuestoManual = false;
                objRepuesto.Costo = Reader.GetDouble("costo");
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

            SQL_p = "SELECT repuestogenerico.idrepuestogenerico, repuestogenerico.descripcion, SUM(repuestogenerico.cantidadreparacion) AS cantidadtotal, (repuestogenerico.preciototal/repuestogenerico.cantidadreparacion) AS preciounitario "+
                    "FROM reparacion INNER JOIN repuestogenerico "+
                    "ON  repuestogenerico.reparacion_idreparacion = reparacion.idreparacion " +
                    "WHERE reparacion.fecha BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "' " +
                    "GROUP BY repuestogenerico.idrepuestogenerico "+
                    "ORDER BY repuestogenerico.descripcion";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                RepuestoReparacion objRepuesto = new RepuestoReparacion();
                //Datos Repuesto Manual
                objRepuesto.IdRepuesto = Reader.GetInt32("idrepuestogenerico");
                objRepuesto.DescripcionRepuesto = Reader.GetString("descripcion");
                objRepuesto.IdRepuestoReparacion = Reader.GetInt32("idrepuestogenerico");
                objRepuesto.FlagRepuestoManual = true;
                objRepuesto.PrecioUnitario = Reader.GetDouble("preciounitario");
                objRepuesto.CantidadRequerida = Reader.GetDouble("cantidadtotal");

                DetalleRepuestos.Add(objRepuesto);

            }
            Reader.Close();
        }

        public void egresoMensual(string fechaInicio, string fechaFin)
        {
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT (SELECT IFNULL(SUM(egreso.importeegreso),0) FROM egreso WHERE egreso.fechaegreso BETWEEN '2013/08/01' AND '2013/08/31') " +
                    "+ (SELECT IFNULL(SUM(repuestostock.costo * repuestoreparacion.cantidadreparacion),0) "+
                    "FROM reparacion INNER JOIN repuestoreparacion INNER JOIN repuestostock "+
                    "ON repuestostock.idrepuestostock = repuestoreparacion.repuestostock_idrepuestostock AND repuestoreparacion.reparacion_idreparacion = reparacion.idreparacion "+
                    "WHERE reparacion.fecha BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "' AND reparacion.codigoreparacion NOT LIKE 'PS-%') AS totalegresos";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                //Datos Engreso
                this.Descripcion = "Total de egresos del Mes";
                this.Importe = Reader.GetDouble("totalegresos");
                this.Fecha = DateTime.Parse(fechaInicio);

            }
            Reader.Close();
        }
        //INICIO CODIGO NUEVO
        /// <summary>
        /// Ingresos generados por repuestos agregados manualmente
        /// </summary>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <returns>Coleccion de repuestos de stock</returns>
        public ArrayList coleccionReparaciones(string fechaInicio, string fechaFin)
        {
            string SQL_p;
            MySqlDataReader Reader;
            ArrayList colCostosFacturados = new ArrayList();

            SQL_p = "SELECT repuestostock.idrepuestostock, reparacion.codigoreparacion, reparacion.fecha, " +
                    "(repuestoreparacion.cantidadreparacion * repuestostock.costo) AS costo_total " +
                    "FROM reparacion INNER JOIN repuestoreparacion INNER JOIN repuestostock " +
                    "ON reparacion.idreparacion = repuestoreparacion.reparacion_idreparacion AND " +
                    "repuestoreparacion.repuestostock_idrepuestostock = repuestostock.idrepuestostock " +
                    "WHERE reparacion.fecha BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "' AND reparacion.codigoreparacion NOT LIKE 'PS-%' " +
                    "GROUP BY repuestostock.idrepuestostock ORDER BY reparacion.fecha";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                Egreso costoFactura = new Egreso();
                //Datos Repuesto Manual
                costoFactura.IdEgreso = Reader.GetInt32("idrepuestostock");
                costoFactura.Descripcion = "Reparación: " + Reader.GetString("codigoreparacion") + " - Respuesto Cod.: " + Reader.GetString("idrepuestostock");
                costoFactura.Importe = Reader.GetDouble("costo_total");
                costoFactura.Fecha = Reader.GetDateTime("fecha");

                colCostosFacturados.Add(costoFactura);

            }
            Reader.Close();

            return colCostosFacturados;
        }
        //FIN CODIGO NUEVO
    }
}
