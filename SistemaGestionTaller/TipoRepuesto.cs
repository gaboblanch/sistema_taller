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
    class TipoRepuesto
    {
        protected int idTipo;
        protected string descripcionTipo;
        protected int gas;


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

        public int Gas
        {
            get { return gas; }
            set { gas = value; }
        }

        //LISTADO DE TODOS LOS TIPOS DE REPUESTOS Y GAS
        public virtual ArrayList coleccionTodos()
        {
            string SQL_p;
            ArrayList colTipos = new ArrayList();
            MySqlDataReader Reader;

            SQL_p = "SELECT * FROM tipo ORDER BY descripciontipo";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                TipoRepuesto objTipoRepuestoLocal = new TipoRepuesto();

                objTipoRepuestoLocal.Idtipo = Reader.GetInt32("idtipo");
                objTipoRepuestoLocal.DescripcionTipo = Reader.GetString("descripciontipo");
                objTipoRepuestoLocal.Gas = Reader.GetInt32("gas");

                colTipos.Add(objTipoRepuestoLocal);
            }

            Reader.Close();
            return colTipos;
        }

        //LISTADO DE TODOS LOS TIPOS DE REPUESTOS
        public virtual ArrayList coleccion()
        {
            string SQL_p;
            ArrayList colTipos = new ArrayList();
            MySqlDataReader Reader;

            SQL_p = "SELECT * FROM tipo WHERE gas=0 ORDER BY descripciontipo";
            
            Reader = Conector.consultar(SQL_p);

            while(Reader.Read())
            {
                TipoRepuesto objTipoRepuestoLocal = new TipoRepuesto();

                objTipoRepuestoLocal.Idtipo = Reader.GetInt32("idtipo");
                objTipoRepuestoLocal.DescripcionTipo = Reader.GetString("descripciontipo");
                objTipoRepuestoLocal.Gas = Reader.GetInt32("gas");

                colTipos.Add(objTipoRepuestoLocal);
            }

            Reader.Close();
            return colTipos;
        }

        //LISTADO DE TODOS LOS TIPOS DE REPUESTOS
        public virtual ArrayList coleccionGas()
        {
            string SQL_p;
            ArrayList colTipos = new ArrayList();
            MySqlDataReader Reader;

            SQL_p = "SELECT * FROM tipo WHERE gas=1 ORDER BY descripciontipo";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                TipoRepuesto objTipoRepuestoLocal = new TipoRepuesto();

                objTipoRepuestoLocal.Idtipo = Reader.GetInt32("idtipo");
                objTipoRepuestoLocal.DescripcionTipo = Reader.GetString("descripciontipo");
                objTipoRepuestoLocal.Gas = Reader.GetInt32("gas");

                colTipos.Add(objTipoRepuestoLocal);
            }

            Reader.Close();
            return colTipos;
        }

        //AGREGAR NUEVO TIPO
        public virtual void agregar()
        {
            string SQL_p;

            SQL_p = "INSERT INTO tipo (descripciontipo, gas) "+
                    "VALUES('" + DescripcionTipo + "', '"+Gas+"')";

            Conector.ejecutar(SQL_p);
        }

        //ACTUALIZAR TIPO
        public virtual void actualizar()
        {
            string SQL_p;

            SQL_p = "UPDATE tipo SET descripciontipo = '" + DescripcionTipo + "', gas = '"+Gas+"' "+
                    "WHERE idtipo='"+idTipo+"'";

            Conector.ejecutar(SQL_p);
        }

        //ELIMINAR TIPO
        public virtual void eliminar()
        {
            string SQL_p;

            SQL_p = "DELETE FROM tipo WHERE idtipo='"+idTipo+"'";

            Conector.ejecutar(SQL_p);
        }

        // TOSTRING
        public override string ToString()
        {
            return descripcionTipo;
        }

        public virtual bool existeTipoRepuesto()
        {
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT * FROM tipo WHERE descripciontipo='"+DescripcionTipo+"'";

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

        public void getTipo()
        {
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT * FROM tipo WHERE idtipo='" + Idtipo + "'";

            Reader = Conector.consultar(SQL_p);

            if (Reader.Read())
            {
                this.DescripcionTipo = Reader.GetString("descripciontipo");
                this.Gas = Reader.GetInt32("gas");
                Reader.Close();
            }
            else
            {
                Reader.Close();
            }
        }
    }
}
