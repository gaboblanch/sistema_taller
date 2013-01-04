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
    class Tarea
    {
        protected int idtarea;
        protected string descripciontarea;
        protected double costo;
        protected TimeSpan duracion;
        protected string filtro;

        public int IdTarea
        {
            get { return idtarea; }
            set { idtarea = value; }
        }

        public string DescripcionTarea
        {
            get { return descripciontarea; }
            set { descripciontarea = value; }
        }
        /// <summary>
        /// Costo de unitario de la tarea
        /// </summary>
        public double Costo
        {
            get { return costo; }
            set { costo = value; }
        }

        public TimeSpan Duracion
        {
            get { return duracion; }
            set { duracion = value; }
        }

        public string Filtro
        {
            get { return filtro; }
            set { filtro = value; } 
        }

        

        /// <summary>
        /// Consulta de todas las tareas disponibles
        /// </summary>
        public virtual ArrayList coleccion()
        {
            string SQL_p;
            MySqlDataReader Reader;
            ArrayList colTareas = new ArrayList();

            SQL_p = "SELECT * FROM tarea WHERE descripciontarea LIKE '%"+Filtro+"%' ORDER BY descripciontarea";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                Tarea objTareaLocal = new Tarea();

                objTareaLocal.IdTarea = Reader.GetInt32("idtarea");
                objTareaLocal.DescripcionTarea = Reader.GetString("descripciontarea");
                objTareaLocal.Costo = Reader.GetDouble("costo");
                objTareaLocal.Duracion = Reader.GetTimeSpan("duracion");

                colTareas.Add(objTareaLocal);
            }
            Reader.Close();
            return colTareas;

        }

        /// <summary>
        /// Permite guardar nuevas tareas en la base de datos
        /// </summary>
        public virtual void agregar()
        {
            string SQL_p;

            SQL_p = "INSERT INTO tarea (descripciontarea, costo, duracion) VALUES('"+DescripcionTarea+"', '"+Costo+"', '"+Duracion+"')";

            Conector.ejecutar(SQL_p);
        }

        /// <summary>
        /// Actualiza los datos de la tarea segun el idtarea
        /// </summary>
        public virtual void actualizar()
        {
            string SQL_p;

            SQL_p = "UPDATE tarea SET descripciontarea='"+DescripcionTarea+"', costo='"+Costo+"', duracion='"+Duracion
                    +"' WHERE idtarea='"+IdTarea+"'";

            Conector.ejecutar(SQL_p);
        }

        /// <summary>
        /// Elimina de la BD la tarea indicada por idtarea
        /// </summary>
        public virtual void eliminar()
        {
            string SQL_p;

            SQL_p = "DELETE FROM tarea WHERE idtarea='" + IdTarea + "'";

            Conector.ejecutar(SQL_p);
        }

        /// <summary>
        /// Obtenemos todos los datos de la BD
        /// </summary>
        public void getDatos()
        {
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT * FROM tarea WHERE idtarea='"+IdTarea+"'";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                this.IdTarea = Reader.GetInt32("idtarea");
                this.DescripcionTarea = Reader.GetString("descripciontarea");
                this.Costo = Reader.GetDouble("costo");
                this.Duracion = Reader.GetTimeSpan("duracion");
            }

            Reader.Close();
        }

        // TOSTRING
        public override string ToString()
        {
            //return DescripcionTarea + ", $" + Costo;
            return DescripcionTarea;
        }
    }
}
