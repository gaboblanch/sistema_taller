using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using MySql.Data.MySqlClient;

namespace SistemaGestionTaller
{
    class TareaReparacion:Tarea
    {
        private int idtareareaparacion;
        private string idtareamanual;
        private double cantidad;
        private double costoTotal;
        private bool flagTareaManual;
        private DateTime fecha;

        public TareaReparacion()
        {
            fecha = new DateTime();
        }

        public int IdTareaReparacion
        {
            get { return idtareareaparacion; }
            set { idtareareaparacion = value; }
        }

        public string IdTareaManual
        {
            get { return idtareamanual; }
            set { idtareamanual = value; }
        }

        public double Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        /// <summary>
        /// Precio total de la tarea por la cantidad 
        /// </summary>
        public double CostoTotal
        {
            get 
            {
                //costoTotal = costo * cantidad;
                costoTotal = costo;
                return costoTotal; 
            }
        }

        public bool FlagTareaManual
        {
            get { return flagTareaManual; }
            set { flagTareaManual = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        /// <summary>
        /// Consulta de todas las tareas disponibles
        /// </summary>
        public override ArrayList coleccion()
        {
            string SQL_p;
            MySqlDataReader Reader;
            ArrayList colTareas = new ArrayList();

            SQL_p = "SELECT * FROM tarea WHERE descripciontarea LIKE '%" + Filtro + "%' ORDER BY descripciontarea";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                TareaReparacion objTareaLocal = new TareaReparacion();

                objTareaLocal.IdTarea = Reader.GetInt32("idtarea");
                objTareaLocal.DescripcionTarea = Reader.GetString("descripciontarea");
                objTareaLocal.Costo = Reader.GetDouble("costo");
                objTareaLocal.Duracion = Reader.GetTimeSpan("duracion");

                colTareas.Add(objTareaLocal);
            }
            Reader.Close();
            return colTareas;

        }

        public void agregar(int idReparacion_p)
        {
            string SQL_p;

            if (this.IdTareaManual == null)
            {
                SQL_p = "INSERT INTO tareareparacion(cantidad, preciotarea, reparacion_idreparacion, tarea_idtarea) VALUES('" + Cantidad + "', '" + CostoTotal + "', '" + idReparacion_p + "','" + IdTarea + "')";

                Conector.ejecutar(SQL_p);
            }
            else if (this.IdTareaManual.Contains('B'))
            {
                SQL_p = "INSERT INTO tareagenerica(cantidad, descripciontarea, preciotarea, reparacion_idreparacion) VALUES('" + Cantidad + "', '"+DescripcionTarea+"', '" + CostoTotal + "', '" + idReparacion_p + "')";

                Conector.ejecutar(SQL_p);
            }
        }

        public void agregarGarantia(int idGarantia)
        {
            string SQL_p;

            if (FlagTareaManual)
            {
                SQL_p = "INSERT INTO tareagarantiagenerica (descripciontarea, cantidad, preciotarea, garantia_idgarantia) "+
	                    "VALUES('"+DescripcionTarea+"','" + Cantidad + "', '" + CostoTotal + "', '" + idGarantia + "','" + IdTarea + "')";

                Conector.ejecutar(SQL_p);
            }
            else
            {
                SQL_p = "INSERT INTO tareagarantia (cantidadtarea, preciotareagarantia, tarea_idtarea, garantia_idgarantia) "+
	                    "VALUES ('" + Cantidad + "', '" + CostoTotal + "', '"+IdTarea+"','" + idGarantia + "')";

                Conector.ejecutar(SQL_p);
            }
        }

        public override void actualizar()
        {
            string SQL_p;
            
            if(this.FlagTareaManual)
            {
                SQL_p = "UPDATE tareagenerica SET cantidad='" + Cantidad + "', preciotarea='" + CostoTotal + "' WHERE idtareagenerica='" + idtarea + "'";

                Conector.ejecutar(SQL_p);
            }
            else
            {
                SQL_p = "UPDATE tareareparacion SET preciotarea='" + CostoTotal + "' WHERE idtareareparacion='" + IdTareaReparacion + "'";
                Conector.ejecutar(SQL_p);
            }
        }

        public void actualizarGarantia()
        {
            string SQL_p;

            if (FlagTareaManual)
            {
                SQL_p = "UPDATE tareagarantiagenerica SET cantidad='" + Cantidad + "', preciotarea='" + CostoTotal + "' WHERE idtareagarantiagenerica='" + idtarea + "'";

                Conector.ejecutar(SQL_p);
            }
            else
            {
                SQL_p = "UPDATE tareagarantia  SET preciotareagarantia='" + CostoTotal + "' WHERE idtareagarantia='" + IdTareaReparacion + "'";

                Conector.ejecutar(SQL_p);
            }
        }

        public override void eliminar()
        {
            string SQL_p;

            if (this.IdTarea == this.IdTareaReparacion)
            {
                SQL_p = "DELETE FROM tareagenerica WHERE idtareagenerica='" + IdTareaReparacion + "'";

                Conector.ejecutar(SQL_p);
            }
            else
            {
                SQL_p = "DELETE FROM tareareparacion WHERE idtareareparacion='" + IdTareaReparacion + "'";

                Conector.ejecutar(SQL_p);
            }
        }

        /// <summary>
        /// ELIMINA todas las tareas de una reparacion pasar el ID de la reparacion
        /// </summary>
        /// <param name="idReparacion_p"></param>
        public void eliminarDetalle(int idReparacion_p)
        {
            string SQL_p;
            if (FlagTareaManual)
            {
                SQL_p = "DELETE FROM tareagenerica WHERE idtareagenerica = '"+IdTarea+"' AND reparacion_idreparacion='" + idReparacion_p + "'";

                Conector.ejecutar(SQL_p);
            }
            else
            {
                //SQL_p = "DELETE FROM tareareparacion WHERE idtareareparacion = '" + IdTareaReparacion + "' AND reparacion_idreparacion='" + idReparacion_p + "'";
                SQL_p = "DELETE FROM tareareparacion WHERE idtareareparacion = '" + IdTareaReparacion + "'";

                Conector.ejecutar(SQL_p);
            }
            
        }
    }
}
