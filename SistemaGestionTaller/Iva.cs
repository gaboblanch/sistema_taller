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
    class Iva
    {
        private int id;
        private string condicioniva;
        private Double porcentajeiva;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string CondicionIva
        {
            get { return condicioniva; }
            set { condicioniva = value; }
        }

        public Double PorcentajeIva
        {
            get { return porcentajeiva; }
            set { porcentajeiva = value; }
        }


        public void agregar()
        {
            string SQL_p;

            SQL_p = "INSERT INTO condicionafip (condicioniva, porcentajeiva) VALUES('" + CondicionIva + "','" + PorcentajeIva + "')";

            Conector.ejecutar(SQL_p);
        }

        public void actualizar()
        {
            string SQL_p;

            SQL_p = "UPDATE condicionafip SET condicioniva='" + CondicionIva + "', porcentajeiva='" + PorcentajeIva + "' WHERE idcondicionafip='" + Id + "'";

            Conector.ejecutar(SQL_p);
        }

        public void eliminar()
        {
            string SQL_p;

            SQL_p = "DELETE FROM condicionafip WHERE idcondicionafip='" + Id + "'";

            Conector.ejecutar(SQL_p);
        }

        public ArrayList coleccion()
        {
            string SQL_p;
            MySqlDataReader Reader;
            ArrayList colIva = new ArrayList();

            SQL_p = "SELECT * FROM condicionafip";
            Reader = Conector.consultar(SQL_p);

            while(Reader.Read())
            {
                Iva objIva = new Iva();

                objIva.Id = Reader.GetInt32("idcondicionafip");
                objIva.CondicionIva = Reader.GetString("condicioniva");
                objIva.PorcentajeIva = Reader.GetDouble("porcentajeiva");

                colIva.Add(objIva);
            }

            Reader.Close();
            return colIva;
        }

        public override string ToString()
        {
            return CondicionIva + "("+PorcentajeIva+"%)";
        }

        /// <summary>
        /// Obtener iva por id
        /// </summary>
        public void getIva()
        {
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT * FROM condicionafip WHERE idcondicionafip='"+Id+"'";
            Reader = Conector.consultar(SQL_p);

            if (Reader.Read())
            {
                this.CondicionIva = Reader.GetString("condicioniva");
                this.PorcentajeIva = Reader.GetDouble("porcentaje");
            }
            Reader.Close();
        }

        /// <summary>
        /// Obetener iva por condicioniva
        /// </summary>
        public void getIvaCondicion()
        {
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT * FROM condicionafip WHERE condicioniva='" + CondicionIva + "'";
            Reader = Conector.consultar(SQL_p);

            if (Reader.Read())
            {
                this.PorcentajeIva = Reader.GetDouble("porcentaje");
            }
            Reader.Close();
        }
    }
}
