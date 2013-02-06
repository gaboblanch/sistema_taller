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
    class TipoCuenta
    {
        private int idTipo;
        private string descripcionTipo;

        public int Idtipo
        {
            get { return idTipo; }
            set { idTipo = value; }
        }

        public string DescripcionTipo
        {
            get { return descripcionTipo; }
            set { descripcionTipo = value; }
        }

        //LISTADO DE TODOS LOS TIPOS DE REPUESTOS
        public ArrayList coleccion()
        {
            string SQL_p;
            ArrayList colTipos = new ArrayList();
            MySqlDataReader Reader;

            SQL_p = "SELECT * FROM tiposcuenta ORDER BY descripcioncuenta";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                TipoCuenta objTipoRepuestoLocal = new TipoCuenta();

                objTipoRepuestoLocal.Idtipo = Reader.GetInt32("idtiposcuenta");
                objTipoRepuestoLocal.DescripcionTipo = Reader.GetString("descripcioncuenta");

                colTipos.Add(objTipoRepuestoLocal);
            }

            Reader.Close();
            return colTipos;
        }

        //AGREGAR NUEVO TIPO
        public void agregar()
        {
            string SQL_p;

            SQL_p = "INSERT INTO tiposcuenta (descripcioncuenta) " +
                    "VALUES('" + descripcionTipo + "')";

            Conector.ejecutar(SQL_p);
        }

        //ACTUALIZAR TIPO
        public void actualizar()
        {
            string SQL_p;

            SQL_p = "UPDATE tiposcuenta SET descripcioncuenta = '" + descripcionTipo + "' " +
                    "WHERE idtiposcuenta='" + idTipo + "'";

            Conector.ejecutar(SQL_p);
        }

        //ELIMINAR TIPO
        public void eliminar()
        {
            string SQL_p;

            SQL_p = "DELETE FROM tiposcuenta WHERE idtiposcuenta='" + idTipo + "'";

            Conector.ejecutar(SQL_p);
        }

        // TOSTRING
        public override string ToString()
        {
            return descripcionTipo;
        }

        public virtual bool existeTipoGas()
        {
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT * FROM tiposcuenta WHERE descripcioncuenta='" + DescripcionTipo + "'";

            Reader = Conector.consultar(SQL_p);

            if (Reader.Read())
            {
                Reader.Close();
                return true;
            }
            else
            {
                Reader.Close();
                return false;
            }

        }

        public void getTipoCuenta()
        {
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT * FROM tiposcuenta WHERE idtiposcuenta='" + Idtipo + "'";

            Reader = Conector.consultar(SQL_p);

            if (Reader.Read())
            {
                this.DescripcionTipo = Reader.GetString("descripcioncuenta");
            }
            Reader.Close();

        }
    }
}

