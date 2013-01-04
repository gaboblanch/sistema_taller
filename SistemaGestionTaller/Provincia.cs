using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using MySql.Data.MySqlClient;

namespace SistemaGestionTaller
{
    class Provincia
    {
        private int id;
        private string descripcion;

        public int IdProvincia
        {
            get { return id; }
            set { id = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public ArrayList coleccion()
        {
            string SQL_p;
            ArrayList colProvincia = new ArrayList();
            MySqlDataReader Reader;

            SQL_p = "SELECT * FROM provincia ORDER BY nombre";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                Provincia objProvincia = new Provincia();

                objProvincia.IdProvincia = Reader.GetInt32("idprovincia");
                objProvincia.Descripcion = Reader.GetString("nombre");

                colProvincia.Add(objProvincia);
            }

            Reader.Close();
            return colProvincia;
        }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
