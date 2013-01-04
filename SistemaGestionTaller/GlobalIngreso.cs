using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using MySql.Data.MySqlClient;

namespace SistemaGestionTaller
{
    class GlobalIngreso
    {
        private int id;
        private string descripcion;
        private double importe;
        private DateTime fecha;
        private string tipo;
        

        public GlobalIngreso()
        {
            fecha = new DateTime();
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

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public void agregar()
        {
            string SQL_p;
            SQL_p = "INSERT INTO globalingresos (descripcioningreso, importeingreso, fechaingreso, tipo) " +
                    "VALUES ('" + Descripcion + "', '" + Importe + "', '" + String.Format("{0:yyyy/MM/dd}", Fecha) + "', '" + Tipo + "')";

            Conector.ejecutar(SQL_p);
        }

        public void actualizar()
        {
            string SQL_p;
            SQL_p = "UPDATE globalingresos SET tipo='" + Tipo + "', descripcioningreso = '" + Descripcion + "' , importeingreso = '" + Importe + "' , fechaingreso = '" + String.Format("{0:yyyy/MM/dd}", Fecha) + "'" +
                    "WHERE idglobalingresos = '" + IdIngreso + "'";

            Conector.ejecutar(SQL_p);
        }

        public void eliminar()
        {
            string SQL_p;
            SQL_p = "DELETE FROM globalingresos WHERE idglobalingresos = '" + IdIngreso + "'";

            Conector.ejecutar(SQL_p);
        }

        public void getIngreso()
        {
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT * FROM globalingresos WHERE idglobalingresos = '" + IdIngreso + "'";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                //Datos Ingreso
                this.Descripcion = Reader.GetString("descripcioningreso");
                this.Importe = Reader.GetDouble("importeingreso");
                this.Fecha = Reader.GetDateTime("fechaingreso");
                this.Tipo = Reader.GetString("tipo");
            }
            Reader.Close();
        }

        public ArrayList coleccion(string fechaInicio, string fechaFin)
        {
            string SQL_p;
            MySqlDataReader Reader;
            ArrayList colIngresos = new ArrayList();

            SQL_p = "SELECT * FROM globalingresos "+
                    "WHERE fechaingreso BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "' AND globalingresos.descripcioningreso != 'Inicialización'" +
                    "ORDER BY globalingresos.descripcioningreso";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                GlobalIngreso objIngreso = new GlobalIngreso();

                //Datos Ingreso
                objIngreso.IdIngreso = Reader.GetInt32("idglobalingresos");
                objIngreso.Descripcion = Reader.GetString("descripcioningreso");
                objIngreso.Importe = Reader.GetDouble("importeingreso");
                objIngreso.Fecha = Reader.GetDateTime("fechaingreso");
                objIngreso.Tipo = Reader.GetString("tipo");

                colIngresos.Add(objIngreso);
            }
            Reader.Close();
            return colIngresos;
        }

        public ArrayList coleccionSumasIngresos(string fecha)
        {
            string SQL_p;
            MySqlDataReader Reader;
            ArrayList colSumas = new ArrayList();
            double banco, cheque, global, tarjeta, efectivo;

            SQL_p = "SELECT DISTINCT  "+
                    "IFNULL((SELECT importeingreso FROM globalingresos WHERE tipo='EFECTIVO' AND fechaingreso = '" + fecha + "' AND descripcioningreso = 'Inicialización' ORDER BY globalingresos.idglobalingresos DESC LIMIT 1),0) AS efectivo, " +
                    "IFNULL((SELECT importeingreso FROM globalingresos WHERE tipo='BANCO' AND fechaingreso = '" + fecha + "' AND descripcioningreso = 'Inicialización' ORDER BY globalingresos.idglobalingresos DESC LIMIT 1),0) AS banco, " +
                    "IFNULL((SELECT importeingreso FROM globalingresos WHERE tipo='CHEQUE' AND fechaingreso = '" + fecha + "' AND descripcioningreso = 'Inicialización' ORDER BY globalingresos.idglobalingresos DESC LIMIT 1),0) AS cheque, " +
                    "IFNULL((SELECT importeingreso FROM globalingresos WHERE tipo='GLOBAL' AND fechaingreso = '" + fecha + "' AND descripcioningreso = 'Inicialización' ORDER BY globalingresos.idglobalingresos DESC LIMIT 1),0) AS 'global', " +
                    "IFNULL((SELECT importeingreso FROM globalingresos WHERE tipo='TARJETA' AND fechaingreso = '" + fecha + "' AND descripcioningreso = 'Inicialización' ORDER BY globalingresos.idglobalingresos DESC LIMIT 1),0) AS tarjeta ";

            Reader = Conector.consultar(SQL_p);

            if (Reader.Read())
            {
               

                efectivo = Reader.GetDouble("efectivo");
                banco = Reader.GetDouble("banco");
                cheque = Reader.GetDouble("cheque");
                global = Reader.GetDouble("global");
                tarjeta = Reader.GetDouble("tarjeta");

                colSumas.Add(efectivo);
                colSumas.Add(banco);
                colSumas.Add(cheque);
                colSumas.Add(global);
                colSumas.Add(tarjeta);
            }

            Reader.Close();
            return colSumas;
        }

        //TODO: Investigar para pasar como parametro el tipo, por ej efectivo, cheque pero no tiene que hacer distincion de mayus
        //sino cambiar en las tablas de pagos todo a mayus y el combobox dnd se efectua el pago tmb.
        //Suman todos los pagos del dia de la fechaInicio de ventas y reparaciones en EFECTIVO
        public void getIngresosEfectivo(string fechaInicio)
        {
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT DISTINCT " +
                    "(SELECT IFNULL(SUM(pagosreparacion.importepago),0) FROM pagosreparacion WHERE pagosreparacion.fecha = '" + fechaInicio + "' AND mediopago='Efectivo')AS efectivoR, " +
                    "(SELECT IFNULL(SUM(pagosventa.importepago),0) FROM pagosventa WHERE pagosventa.fecha = '" + fechaInicio + "' AND mediopago='Efectivo')AS efectivoV";

            Reader = Conector.consultar(SQL_p);

            if (Reader.Read())
            {
                this.Fecha = Convert.ToDateTime(fechaInicio);
                this.Importe = Reader.GetDouble("efectivoR");
                this.Importe += Reader.GetDouble("efectivoV");
                this.Tipo = "EFECTIVO";
                this.Descripcion = "Pagos Venta de Respuestos y Pagos Reparaciones.";
            }

            Reader.Close();
        }

        //Suman todos los pagos del dia de la fechaInicio de ventas y reparaciones en CHEQUE
        public void getIngresosCheque(string fechaInicio)
        {
            string SQL_p;
            MySqlDataReader Reader;


            SQL_p = "SELECT DISTINCT " +
                    "(SELECT IFNULL(SUM(pagosreparacion.importepago),0) FROM pagosreparacion WHERE pagosreparacion.fecha = '" + fechaInicio + "' AND mediopago='Cheque')AS chequeR, " +
                    "(SELECT IFNULL(SUM(pagosventa.importepago),0) FROM pagosventa WHERE pagosventa.fecha = '" + fechaInicio + "' AND mediopago='Cheque')AS chequeV";

            Reader = Conector.consultar(SQL_p);

            if (Reader.Read())
            {
                this.Fecha = Convert.ToDateTime(fechaInicio);
                this.Importe = Reader.GetDouble("chequeR");
                this.Importe += Reader.GetDouble("chequeV");
                this.Tipo = "CHEQUE";
                this.Descripcion = "Pagos Venta de Respuestos y Pagos Reparaciones.";
            }

            Reader.Close();
        }

        //Suman todos los pagos del dia de la fechaInicio de ventas y reparaciones en TARJETA
        public void getIngresosTarjeta(string fechaInicio)
        {
            string SQL_p;
            MySqlDataReader Reader;


            SQL_p = "SELECT DISTINCT " +
                    "(SELECT IFNULL(SUM(pagosreparacion.importepago),0) FROM pagosreparacion WHERE pagosreparacion.fecha = '" + fechaInicio + "' AND mediopago='Tarjeta')AS tarjetaR, " +
                    "(SELECT IFNULL(SUM(pagosventa.importepago),0) FROM pagosventa WHERE pagosventa.fecha = '" + fechaInicio + "' AND mediopago='Tarjeta')AS tarjetaV";

            Reader = Conector.consultar(SQL_p);

            if (Reader.Read())
            {
                this.Fecha = Convert.ToDateTime(fechaInicio);
                this.Importe = Reader.GetDouble("tarjetaR");
                this.Importe += Reader.GetDouble("tarjetaV");
                this.Tipo = "TARJETA";
                this.Descripcion = "Pagos Venta de Respuestos y Pagos Reparaciones.";
            }

            Reader.Close();
        }

        //Suman todos los pagos del dia de la fechaInicio de ventas y reparaciones en TRANSFERENCIA
        public void getIngresosTrans(string fechaInicio)
        {
            string SQL_p;
            MySqlDataReader Reader;


            SQL_p = "SELECT DISTINCT " +
                    "(SELECT IFNULL(SUM(pagosreparacion.importepago),0) FROM pagosreparacion WHERE pagosreparacion.fecha = '" + fechaInicio + "' AND mediopago='Transferencia')AS transferenciaR, " +
                    "(SELECT IFNULL(SUM(pagosventa.importepago),0) FROM pagosventa WHERE pagosventa.fecha = '" + fechaInicio + "' AND mediopago='Transferencia')AS transferenciaV";

            Reader = Conector.consultar(SQL_p);

            if (Reader.Read())
            {
                this.Fecha = Convert.ToDateTime(fechaInicio);
                this.Importe = Reader.GetDouble("transferenciaR");
                this.Importe += Reader.GetDouble("transferenciaV");
                this.Tipo = "TRANSFERENCIA";
                this.Descripcion = "Pagos Venta de Respuestos y Pagos Reparaciones.";
            }

            Reader.Close();
        }


        public void terminarJornada()
        {
            string SQL_p;
            MySqlDataReader Reader;


            SQL_p = "SELECT * FROM globalingresos " +
                    "WHERE descripcioningreso = 'Inicialización' AND fechaingreso = '" + String.Format("{0:yyyy/MM/dd}", Fecha) + "' AND tipo='" + Tipo + "'" +
                    "ORDER BY idglobalingresos DESC LIMIT 1";

            Reader = Conector.consultar(SQL_p);

            if (Reader.Read())
            {
                this.IdIngreso = Reader.GetInt32("idglobalingresos");
                //Existe el ingreso de inicio hay que actualizar
                Reader.Close();
                this.actualizar();
            }
            else
            {
                Reader.Close();
                //No existe insertar uno nuevo
                this.agregar();
            }
            
        }
    }
}
