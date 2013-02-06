using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using MySql.Data.MySqlClient;
using System.IO;

namespace SistemaGestionTaller
{
    public static class Conector
    {
        private static string conn, server, userid, password, database;
        private static MySqlConnection sqlConn = null;
        private static MySqlCommand command = null;
        private static MySqlDataReader Reader = null;

        public static void setConn(string conn_p) { conn = conn_p; }
        public static string getConn() { return conn; }

        public static void setServer(string server_p) { server = server_p; }
        public static string getServer() { return server; }

        public static void setUserid(string userid_p) { userid = userid_p; }
        public static string getUserid() { return userid; }

        public static void setPassword(string password_p) { password = password_p; }
        public static string getPassword() { return password; }

        public static void setDatabase(string database_p) { database = database_p; }
        public static string getDatabase() { return database; }

        public static void conectar()
        {
            conn = "server=" + server + ";userid=" + userid + ";password=" + password + ";database=" + database;
            sqlConn = new MySqlConnection(conn);
            command = sqlConn.CreateCommand();
            sqlConn.Open();
        }

        public static void desconectar()
        {
            sqlConn.Close();
        }

        public static MySqlDataReader consultar(string SQL_p)
        {
            Reader = null;
            command.CommandText = SQL_p;
            Reader = command.ExecuteReader();
            return Reader;
            
        }

        public static void ejecutar(string SQL_p)
        {
            command.CommandText = SQL_p;
            command.ExecuteNonQuery();
        }

        public static int getLastID()
        {
            return (int)command.LastInsertedId;
        }

        public static void crearConfiguracion()
        {
            FileStream fileStream = new FileStream(@"mydb.cfg", FileMode.Create);
            fileStream.Close();
        }

        public static void guardarConfiguracion()
        {
            StreamWriter tw = new StreamWriter("mydb.cfg", false);
            tw.WriteLine(getServer() + ":" + getDatabase() + ":" + getUserid() + ":" + getPassword());
            tw.Close();
        }

        public static void leerConfiguracion()
        {
            StreamReader tr = new StreamReader("mydb.cfg");
            string[] configuracion = tr.ReadLine().ToString().Split(':');
            tr.Close();

            setServer(configuracion[0]);
            setDatabase(configuracion[1]);
            setUserid(configuracion[2]);
            setPassword(configuracion[3]);
        }

        
    }
}