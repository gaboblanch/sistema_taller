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
    class Turnos
    {
        private int id;
        private DateTime fecha;
        private DateTime hora;
        private TimeSpan duracion;
        private Cliente cliente;
        private Vehiculo vehiculo;

        public Turnos()
        {
            cliente = new Cliente();
            vehiculo = new Vehiculo();
        }

        public int IdTurno
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public TimeSpan Duracion
        {
            get { return duracion; }
            set { duracion = value; }
        }

        public DateTime Hora
        {
            get { return hora; }
            set { hora = value; }
        }

        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        public Vehiculo Vehiculo
        {
            get { return vehiculo; }
            set { vehiculo = value; }
        }

        public void agregar()
        {
            string SQL_p;

            SQL_p = "INSERT INTO turno (fechaturno, cliente_idcliente, vehiculo_idvehiculo, hora, duracion) " +
                    "VALUES('" + String.Format("{0:yyyy/MM/dd}", Fecha) + "','" + Cliente.Id + "','" + Vehiculo.Id + "','" + String.Format("{0:HH:mm}", Hora) + "','" + Duracion + "')";

            Conector.ejecutar(SQL_p);
        }

        public void actualizar()
        {
            string SQL_p;

            SQL_p = "UPDATE turno SET fechaturno='" + String.Format("{0:yyyy/MM/dd}", Fecha) + "', cliente_idcliente='" + Cliente.Id + "', vehiculo_idvehiculo='" + Vehiculo.Id + "', " +
                    "hora='" + Hora.ToShortTimeString() + "', Duracion='" + Duracion + "' " +
                    "WHERE idturno='"+IdTurno+"'";

            Conector.ejecutar(SQL_p);
        }

        public void eliminar()
        {
            string SQL_p;

            SQL_p = "DELETE FROM turno WHERE idturno='" + IdTurno + "'";

            Conector.ejecutar(SQL_p);
        }

        public bool existeTurno()
        {
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT * FROM turno WHERE fechaturno='" + Fecha + "'AND hora='" + Hora + "' AND Duracion='" + Duracion + "'";

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

        public ArrayList coleccion(DateTime fechainicio_p, DateTime fechafin_p)
        {
            string SQL_p;
            MySqlDataReader Reader;
            ArrayList colTurnos = new ArrayList();

            SQL_p = "SELECT turno.*, cliente.razonsocial, vehiculo.dominio, vehiculo.marca, vehiculo.modelo "+
                    "FROM turno INNER JOIN cliente INNER JOIN vehiculo "+
                    "ON turno.cliente_idcliente = cliente.idcliente AND vehiculo.idvehiculo = turno.vehiculo_idvehiculo "+
                    "WHERE turno.fechaturno BETWEEN '" + String.Format("{0:yyyy/MM/dd}", fechainicio_p) + "' AND '" + String.Format("{0:yyyy/MM/dd}", fechafin_p) + "'";

            Reader = Conector.consultar(SQL_p);
            while (Reader.Read())
            {
                Turnos objTurnoLocal = new Turnos();
                
                //CLIENTE
                objTurnoLocal.Cliente.Id = Reader.GetInt32("cliente_idcliente");
                objTurnoLocal.Cliente.NombreRazonSocial = Reader.GetString("razonsocial");

                //TURNO
                objTurnoLocal.IdTurno = Reader.GetInt32("idturno");
                objTurnoLocal.Fecha = Reader.GetDateTime("fechaturno");
                objTurnoLocal.Duracion = Reader.GetTimeSpan("duracion");
                objTurnoLocal.Hora = DateTime.Parse(Reader.GetString("hora"));

                DateTime fecha = new DateTime(objTurnoLocal.Fecha.Year, objTurnoLocal.Fecha.Month, objTurnoLocal.Fecha.Day, objTurnoLocal.Hora.Hour, objTurnoLocal.Hora.Minute, 0);
                objTurnoLocal.Fecha = fecha;


                //VEHICULO
                objTurnoLocal.Vehiculo.Id = Reader.GetInt32("vehiculo_idvehiculo");
                objTurnoLocal.Vehiculo.Dominio = Reader.GetString("dominio");
                objTurnoLocal.Vehiculo.Marca = Reader.GetString("marca");
                objTurnoLocal.Vehiculo.Modelo = Reader.GetString("modelo");

                colTurnos.Add(objTurnoLocal);
            }
            Reader.Close();
            return colTurnos;

        }
    }
}
