using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using MySql.Data.MySqlClient;

namespace SistemaGestionTaller
{
    class Localidad
    {
        private int id;
        private string descripcion;

        public int IdLocalidad
        {
            get { return id; }
            set { id = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public ArrayList coleccion(int idProvincia)
        {
            string SQL_p;
            ArrayList colLocalidades = new ArrayList();
            MySqlDataReader Reader;

            SQL_p = "SELECT * FROM departamentos WHERE provincia_id = '" + idProvincia + "' ORDER BY nombre";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                Localidad objLocalidad = new Localidad();

                objLocalidad.IdLocalidad = Reader.GetInt32("id");
                objLocalidad.Descripcion = Reader.GetString("nombre");

                colLocalidades.Add(objLocalidad);
            }

            Reader.Close();
            return colLocalidades;
        }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
