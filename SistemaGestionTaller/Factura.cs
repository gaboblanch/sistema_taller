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
    class Factura
    {
        private Cliente cliente;
        private Reparacion reparacion;
        private VentaRepuesto ventarepuesto;
        private ArrayList colPagos;
        private int id;
        private string codigoFactura;
        private string tipoFactura;
        private Iva iva;
        private DateTime fechaFactura;
        private DateTime fechaSistema;
        private double saldo;
        private double importe;
        private double bonificacion;
        private int estado; //ANULADA O NO

        public Factura()
        {
            cliente = new Cliente();
            reparacion = new Reparacion();
            iva = new Iva();
            colPagos = new ArrayList();
            ventarepuesto = new VentaRepuesto();
        }

        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        public Reparacion Reparacion
        {
            get { return reparacion; }
            set { reparacion = value; }
        }

        public VentaRepuesto VentaRepuesto
        {
            get { return ventarepuesto; }
            set { ventarepuesto = value; }
        }

        public ArrayList Pagos
        {
            get { return colPagos; }
            set { colPagos = value; }
        }

        public int IdFactura
        {
            get { return id; }
            set { id = value; }
        }

        public string TipoFactura
        {
            get { return tipoFactura; }
            set { tipoFactura = value; }
        }

        public DateTime FechaFactura
        {
            get { return fechaFactura; }
            set { fechaFactura = value; }
        }

        public DateTime FechaSistema
        {
            get { return fechaSistema; }
            set { fechaSistema = value; }
        }

        public double Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }

        public double ImporteFactura
        {
            get { return importe; }
            set { importe = value; }
        }

        public double Bonificacion
        {
            get { return bonificacion; }
            set { bonificacion = value; }
        }

        /// <summary>
        /// Anualada o No
        /// </summary>
        public int EstadoFactura
        {
            get { return estado; }
            set { estado = value; }
        }

        public string NumeroFactura
        {
            get { return codigoFactura; }
            set { codigoFactura = value; }
        }

        public Iva IvaFactura
        {
            get { return iva; }
            set { iva = value; }
        }

        //REPARACION
        //REPARACION
        //REPARACION
        public void agregarReparacion()
        {
            string SQL_p;

            SQL_p = "INSERT INTO factura (codigofactura, tipofactura, fecha, saldo, anulada, reparacion_idreparacion, cliente_idcliente, condicionafip_idcondicionafip, bonificacion) " +
                    "VALUES ('" + NumeroFactura + "', '" + TipoFactura + "', '" + String.Format("{0:yyyy/MM/dd}", FechaFactura) +
                    "', '" + Saldo.ToString("0.00") + "', '" + EstadoFactura + "', '" + Reparacion.IdReparacion + "', '" + Cliente.Id + "', '" + IvaFactura.Id + "', '" + Bonificacion + "')";

            Conector.ejecutar(SQL_p);

            this.IdFactura = Conector.getLastID();

            Reparacion.Estado = 2;
            Reparacion.actualizarEstado();
        }

        //VENTA REPUESTO
        //VENTA REPUESTO
        //VENTA REPUESTO
        public void agregarVenta()
        {
            string SQL_p;

            SQL_p = "INSERT INTO facturaventa (codigofactura, tipofactura, fecha, saldo, anulada, ventarepuesto_idventarepuesto, cliente_idcliente, condicionafip_idcondicionafip, bonificacion) " +
                    "VALUES ('" + NumeroFactura + "', '" + TipoFactura + "', '" + String.Format("{0:yyyy/MM/dd}", FechaFactura) +
                    "', '" + Saldo.ToString("0.00") + "', '" + EstadoFactura + "', '" + VentaRepuesto.IdVentaRepuesto + "', '" + Cliente.Id + "', '" + IvaFactura.Id + "', '" + Bonificacion + "')";

            Conector.ejecutar(SQL_p);

            this.IdFactura = Conector.getLastID();

            Reparacion.Estado = 2;
            Reparacion.actualizarEstado();
        }

        //REPARACION
        //REPARACION
        //REPARACION
        public void actualizarReparacion()
        {
            string SQL_p;

            /*SQL_p = "UPDATE factura SET tipofactura='" + TipoFactura + "', fecha='" + String.Format("{0:yyyy/MM/dd}", FechaFactura) + "', saldo='" + Saldo + "', anulada='" + EstadoFactura + "', reparacion_idreparacion='" + Reparacion.IdReparacion + "' " +
                    "WHERE idfactura='" + IdFactura + "'";*/

            SQL_p = "UPDATE factura SET saldo='" + Saldo.ToString("0.00") + "', anulada='" + EstadoFactura + "' " +
                    "WHERE idfactura='" + IdFactura + "'";

            Conector.ejecutar(SQL_p);
        }

        //VENTA REPUESTO
        //VENTA REPUESTO
        //VENTA REPUESTO
        public void actualizarVenta()
        {
            string SQL_p;

            /*SQL_p = "UPDATE factura SET tipofactura='" + TipoFactura + "', fecha='" + String.Format("{0:yyyy/MM/dd}", FechaFactura) + "', saldo='" + Saldo + "', anulada='" + EstadoFactura + "', reparacion_idreparacion='" + Reparacion.IdReparacion + "' " +
                    "WHERE idfactura='" + IdFactura + "'";*/

            SQL_p = "UPDATE facturaventa SET saldo='" + Saldo.ToString("0.00") + "', anulada='" + EstadoFactura + "' " +
                    "WHERE idfactura='" + IdFactura + "'";

            Conector.ejecutar(SQL_p);
        }

        public void eliminarReparacion()
        {
            string SQL_p;

            //SQL_p = "DELETE FROM factura WHERE idfactura='"+IdFactura+"'";
            SQL_p = "DELETE FROM pagosreparacion WHERE factura_idfactura='" + IdFactura + "'";

            Conector.ejecutar(SQL_p);
        }

        public void eliminarVenta()
        {
            string SQL_p;

            //SQL_p = "DELETE FROM facturaventa WHERE idfactura='" + IdFactura + "'";
            SQL_p = "DELETE FROM pagosventa WHERE facturaventa_idfactura='" + IdFactura + "'";

            Conector.ejecutar(SQL_p);
        }

        /// <summary>
        /// Traemos los datos de la factura sin los pagos mediante id de factura
        /// </summary>
        /// <returns></returns>
        public bool getFacturaReparacion()
        {
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT * FROM factura WHERE idfactura='" + IdFactura + "'";

            Reader = Conector.consultar(SQL_p);

            if (Reader.Read())
            {
                this.TipoFactura = Reader.GetString("tipofactura");
                this.FechaFactura = Reader.GetDateTime("fecha");
                this.Saldo = Reader.GetDouble("saldo");
                this.EstadoFactura = Reader.GetInt32("anulada");
                this.Reparacion.IdReparacion = Reader.GetInt32("reparacion_idreparacion");
                this.NumeroFactura = Reader.GetString("codigofactura");
                this.Cliente.Id = Reader.GetInt32("cliente_idcliente");
                this.IvaFactura.Id = Reader.GetInt32("condicionafip_idcondicionafip");
                this.Bonificacion = Reader.GetDouble("bonificacion");
                Reader.Close();
                return true;
            }
            else
            {
                Reader.Close();
                return false;
            }
        }

        public bool getFacturaVenta()
        {
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT * FROM facturaventa WHERE idfactura='" + IdFactura + "'";

            Reader = Conector.consultar(SQL_p);

            if (Reader.Read())
            {
                this.TipoFactura = Reader.GetString("tipofactura");
                this.FechaFactura = Reader.GetDateTime("fecha");
                this.Saldo = Reader.GetDouble("saldo");
                this.EstadoFactura = Reader.GetInt32("anulada");
                this.Reparacion.IdReparacion = Reader.GetInt32("ventarepuesto_idventarepuesto");
                this.NumeroFactura = Reader.GetString("codigofactura");
                this.Cliente.Id = Reader.GetInt32("cliente_idcliente");
                this.IvaFactura.Id = Reader.GetInt32("condicionafip_idcondicionafip");
                this.Bonificacion = Reader.GetDouble("bonificacion");
                Reader.Close();
                return true;
            }
            else
            {
                Reader.Close();
                return false;
            }
        }

        /// <summary>
        /// Traemos los datos de la factura mediante el id de reparacion
        /// </summary>
        /// <returns></returns>
        public bool existeFacturaReparacion()
        {
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT factura.*, condicionafip.condicioniva, condicionafip.porcentajeiva " +
                    "FROM factura INNER JOIN condicionafip " +
                    "ON factura.condicionafip_idcondicionafip = condicionafip.idcondicionafip " +
                    "WHERE factura.reparacion_idreparacion='" + this.Reparacion.IdReparacion + "'";

            Reader = Conector.consultar(SQL_p);

            if (Reader.Read())
            {
                this.TipoFactura = Reader.GetString("tipofactura");
                this.FechaFactura = Reader.GetDateTime("fecha");
                this.Saldo = Reader.GetDouble("saldo");
                this.EstadoFactura = Reader.GetInt32("anulada");
                this.IdFactura = Reader.GetInt32("idfactura");
                this.NumeroFactura = Reader.GetString("codigofactura");
                this.Cliente.Id = Reader.GetInt32("cliente_idcliente");
                this.IvaFactura.Id = Reader.GetInt32("condicionafip_idcondicionafip");
                this.IvaFactura.CondicionIva = Reader.GetString("condicioniva");
                this.IvaFactura.PorcentajeIva = Reader.GetInt32("porcentajeiva");
                this.Bonificacion = Reader.GetDouble("bonificacion");
                Reader.Close();
                return true;
            }
            else
            {
                Reader.Close();
                return false;
            }
        }

        public bool existeFacturaVenta()
        {
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT facturaventa.*, condicionafip.condicioniva, condicionafip.porcentajeiva " +
                    "FROM facturaventa INNER JOIN condicionafip "+
                    "ON facturaventa.condicionafip_idcondicionafip = condicionafip.idcondicionafip " +
                    "WHERE facturaventa.ventarepuesto_idventarepuesto='" + this.VentaRepuesto.IdVentaRepuesto + "'";

            Reader = Conector.consultar(SQL_p);

            if (Reader.Read())
            {
                this.TipoFactura = Reader.GetString("tipofactura");
                this.FechaFactura = Reader.GetDateTime("fecha");
                this.Saldo = Reader.GetDouble("saldo");
                this.EstadoFactura = Reader.GetInt32("anulada");
                this.IdFactura = Reader.GetInt32("idfactura");
                this.NumeroFactura = Reader.GetString("codigofactura");
                this.Cliente.Id = Reader.GetInt32("cliente_idcliente");
                this.IvaFactura.Id = Reader.GetInt32("condicionafip_idcondicionafip");
                this.IvaFactura.CondicionIva = Reader.GetString("condicioniva");
                this.IvaFactura.PorcentajeIva = Reader.GetInt32("porcentajeiva");
                this.Bonificacion = Reader.GetDouble("bonificacion");
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
