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
    class Pago
    {
        private int id;
        private int numeroPago;
        private DateTime fechaPago;
        private double importePago;
        private string medioPago;
        private string bancoPago;
        private string numeroCheque;
        private string observacionPago;

        public Pago()
        {
            fechaPago = new DateTime();
        }

        public int IdPago
        {
            get { return id;}
            set { id = value; }
        }

        public int NumeroPago
        {
            get { return numeroPago; }
            set { numeroPago = value; }
        }

        public DateTime FechaPago
        {
            get { return fechaPago; }
            set { fechaPago = value; }
        }

        public double ImportePago
        {
            get { return importePago; }
            set { importePago = value; }
        }

        public string MedioPago
        {
            get { return medioPago; }
            set { medioPago = value; }
        }

        public string BancoPago
        {
            get { return bancoPago; }
            set { bancoPago = value; }
        }

        public string NumeroCheque
        {
            get { return numeroCheque; }
            set { numeroCheque = value; }
        }

        public string ObservacionPago
        {
            get { return observacionPago; }
            set { observacionPago = value; }
        }

        public void agregarReparacion(int idFactura)
        {
            string SQL_p;

            SQL_p = "INSERT INTO pagosreparacion (fecha, numeropago, importepago, mediopago, banco, numerocheque, observacionpago, factura_idfactura) "+
                    "VALUES ('" + String.Format("{0:yyyy/MM/dd}", FechaPago) + "', '" + NumeroPago + "', '" + ImportePago.ToString("0.00") + "', '" + MedioPago + "', '" + BancoPago + "', '" + NumeroCheque + "', '" + ObservacionPago + "', '" + idFactura + "')";

            Conector.ejecutar(SQL_p);
        }

        public void agregarVenta(int idFactura)
        {
            string SQL_p;

            SQL_p = "INSERT INTO pagosventa (fecha, numeropago, importepago, mediopago, banco, numerocheque, observacionpago, facturaventa_idfactura) " +
                    "VALUES ('" + String.Format("{0:yyyy/MM/dd}", FechaPago) + "', '" + NumeroPago + "', '" + ImportePago.ToString("0.00") + "', '" + MedioPago + "', '" + BancoPago + "', '" + NumeroCheque + "', '" + ObservacionPago + "', '" + idFactura + "')";

            Conector.ejecutar(SQL_p);
        }

        public void actualizarReparacion()
        {
            string SQL_p;

            SQL_p = "UPDATE pagosreparacion SET fecha='" + String.Format("{0:yyyy/MM/dd}", FechaPago) + "', numeropago='" + NumeroPago + "', importepago='" + ImportePago.ToString("0.00") + "', mediopago='" + MedioPago + "'," +
                    "banco='" + BancoPago + "', numerocheque='" + NumeroCheque + "', observacionpago='" + ObservacionPago + "'" +
                    "WHERE idpagosreparacion='" + IdPago + "'";

            Conector.ejecutar(SQL_p);
        }

        public void actualizarVenta()
        {
            string SQL_p;

            SQL_p = "UPDATE pagosventa SET fecha='" + String.Format("{0:yyyy/MM/dd}", FechaPago) + "', numeropago='" + NumeroPago + "', importepago='" + ImportePago.ToString("0.00") + "', mediopago='" + MedioPago + "'," +
                    "banco='" + BancoPago + "', numerocheque='" + NumeroCheque + "', observacionpago='" + ObservacionPago + "'" +
                    "WHERE idpagosventa='" + IdPago + "'";

            Conector.ejecutar(SQL_p);
        }

        public void eliminarReparacion()
        {
            string SQL_p;

            SQL_p = "DELETE FROM pagosreparacion WHERE idpagosreparacion='"+IdPago+"'";

            Conector.ejecutar(SQL_p);
        }

        public void eliminarVenta()
        {
            string SQL_p;

            SQL_p = "DELETE FROM pagosventa WHERE idpagosventa='" + IdPago + "'";

            Conector.ejecutar(SQL_p);
        }

        public ArrayList getPagosReparacion(int idFactura)
        {
            string SQL_p;
            MySqlDataReader Reader;
            ArrayList colPagos = new ArrayList();

            SQL_p = "SELECT * FROM pagosreparacion WHERE factura_idfactura='" + idFactura + "' ORDER BY pagosreparacion.numeropago";

            Reader = Conector.consultar(SQL_p);

            while(Reader.Read())
            {
                Pago objPago = new Pago();

                objPago.IdPago = Reader.GetInt32("idpagosreparacion");
                objPago.NumeroPago = Reader.GetInt32("numeropago");
                objPago.FechaPago = Reader.GetDateTime("fecha");
                objPago.ImportePago = Reader.GetDouble("importepago");
                objPago.MedioPago = Reader.GetString("mediopago");
                objPago.BancoPago = Reader.GetString("banco");
                objPago.NumeroCheque = Reader.GetString("numerocheque");
                objPago.ObservacionPago = Reader.GetString("observacionpago");

                colPagos.Add(objPago);
                
            }

            Reader.Close();
            return colPagos;
        }

        public ArrayList getPagosVenta(int idFactura)
        {
            string SQL_p;
            MySqlDataReader Reader;
            ArrayList colPagos = new ArrayList();

            SQL_p = "SELECT * FROM pagosventa WHERE facturaventa_idfactura='" + idFactura + "' ORDER BY pagosventa.numeropago";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                Pago objPago = new Pago();

                objPago.IdPago = Reader.GetInt32("idpagosventa");
                objPago.NumeroPago = Reader.GetInt32("numeropago");
                objPago.FechaPago = Reader.GetDateTime("fecha");
                objPago.ImportePago = Reader.GetDouble("importepago");
                objPago.MedioPago = Reader.GetString("mediopago");
                objPago.BancoPago = Reader.GetString("banco");
                objPago.NumeroCheque = Reader.GetString("numerocheque");
                objPago.ObservacionPago = Reader.GetString("observacionpago");

                colPagos.Add(objPago);

            }

            Reader.Close();
            return colPagos;
        }

        public bool existePagoReparacion()
        {
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT * FROM pagosreparacion WHERE idpagosreparacion='" + IdPago + "'";

            Reader = Conector.consultar(SQL_p);

            if (Reader.Read())
            {
                this.NumeroPago = Reader.GetInt32("numeropago");
                Reader.Close();
                return true;
            }
            else
            {
                Reader.Close();
                return false;
            }
        }

        public bool existePagoVenta()
        {
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT * FROM pagosventa WHERE idpagosventa='" + IdPago + "'";

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
    }
}
