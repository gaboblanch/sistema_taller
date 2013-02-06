using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using MySql.Data.MySqlClient;

namespace SistemaGestionTaller
{
    class GlobalEgreso
    {
        private int id;
        private string descripcion;
        private double importe;
        private DateTime fecha;
        private string tipo;

        public GlobalEgreso()
        {
            fecha = new DateTime();
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

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public void agregar()
        {
            string SQL_p;
            SQL_p = "INSERT INTO globalegresos (descripcionegreso, importeegreso, fechaegreso, tipo) " +
                    "VALUES ('" + Descripcion + "', '" + Importe + "', '" + String.Format("{0:yyyy/MM/dd}", Fecha) + "', '" + Tipo + "')";

            Conector.ejecutar(SQL_p);
        }

        public void actualizar()
        {
            string SQL_p;
            SQL_p = "UPDATE globalegresos SET tipo='" + Tipo + "', descripcionegreso = '" + Descripcion + "' , importeegreso = '" + Importe + "' , fechaegreso = '" + String.Format("{0:yyyy/MM/dd}", Fecha) + "'" +
                    "WHERE idglobalegresos = '" + IdEgreso + "'";

            Conector.ejecutar(SQL_p);
        }

        public void eliminar()
        {
            string SQL_p;
            SQL_p = "DELETE FROM globalegresos WHERE idglobalegresos = '" + IdEgreso + "'";

            Conector.ejecutar(SQL_p);
        }

        public void getEgreso()
        {
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT * FROM globalegresos WHERE idglobalegresos = '" + IdEgreso + "'";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                //Datos Egreso
                this.Descripcion = Reader.GetString("descripcionegreso");
                this.Importe = Reader.GetDouble("importeegreso");
                this.Fecha = Reader.GetDateTime("fechaegreso");
                this.Tipo = Reader.GetString("tipo");
            }
            Reader.Close();
        }

        public ArrayList coleccion(string fechaInicio, string fechaFin)
        {
            string SQL_p;
            MySqlDataReader Reader;
            ArrayList colEgresos = new ArrayList();

            SQL_p = "SELECT * FROM globalegresos WHERE fechaegreso BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "' " +
                    "ORDER BY globalegresos.descripcionegreso";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                GlobalEgreso objEgreso = new GlobalEgreso();
                //Datos Egreso
                objEgreso.IdEgreso = Reader.GetInt32("idglobalegresos");
                objEgreso.Descripcion = Reader.GetString("descripcionegreso");
                objEgreso.Importe = Reader.GetDouble("importeegreso");
                objEgreso.Fecha = Reader.GetDateTime("fechaegreso");
                objEgreso.Tipo = Reader.GetString("tipo");

                colEgresos.Add(objEgreso);
            }
            Reader.Close();
            return colEgresos;
        }

        public ArrayList coleccionSumasEgresos(string fecha)
        {
            string SQL_p;
            MySqlDataReader Reader;
            ArrayList colSumas = new ArrayList();

            SQL_p = "SELECT DISTINCT "+
                    "(SELECT IFNULL(SUM(importeegreso),0) FROM globalegresos WHERE tipo='EFECTIVO' AND fechaegreso = '" + fecha + "') AS efectivo, " +
                    "(SELECT IFNULL(SUM(importeegreso),0) FROM globalegresos WHERE tipo='BANCO' AND fechaegreso = '" + fecha + "') AS banco, " +
                    "(SELECT IFNULL(SUM(importeegreso),0) FROM globalegresos WHERE tipo='CHEQUE' AND fechaegreso = '" + fecha + "') AS cheque, " +
                    "(SELECT IFNULL(SUM(importeegreso),0) FROM globalegresos WHERE tipo='GLOBAL' AND fechaegreso = '" + fecha + "') AS 'global', " +
                    "(SELECT IFNULL(SUM(importeegreso),0) FROM globalegresos WHERE tipo='TARJETA' AND fechaegreso = '" + fecha + "') AS tarjeta ";

            Reader = Conector.consultar(SQL_p);

            if (Reader.Read())
            {
                double banco, cheque, global, tarjeta, efectivo;

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
    }
}
