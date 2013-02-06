using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using MySql.Data.MySqlClient;
using System.Net;
using System.Net.Sockets;

namespace SistemaGestionTaller
{
    class VentaRepuesto
    {
        private int id;

        private DateTime fecha;
        /// <summary>
        /// Fecha sin posibilidad de cambio, utilizada por el sistema
        /// </summary>
        private DateTime fechaSistema;
        private Cliente cliente;
        private string descripcion;
        private double importeTotal;
        private int estadoventa;
        //Colecciones con repuestos y tareas de la reparacion
        private ArrayList detalleRepuestos;

        //Colecciones con repuestos y tareas eliminados, hay que sacarlos del detalle a guardar
        private ArrayList detalleRepuestosElimindas;

        //CONSTRUCTOR
        public VentaRepuesto()
        {
            cliente = new Cliente();            
            detalleRepuestos = new ArrayList();
            detalleRepuestosElimindas = new ArrayList();
        }

        public int IdVentaRepuesto
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public DateTime FechaSistema
        {
            get { return fechaSistema; }
            set { fechaSistema = value; }
        }

        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        /// <summary>
        /// Algun comentario que quiera agregar el mecanico
        /// </summary>
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public double ImporteTotal
        {
            get { return importeTotal; }
            set { importeTotal = value; }
        }

        public int EstadoVenta
        {
            get { return estadoventa; }
            set { estadoventa = value; }
        }

        /// <summary>
        /// Listado de repuestos utilizados en la reparacion, 
        /// contiene objetos RepuestoReparacion
        /// </summary>
        public ArrayList DetalleRepuestos
        {
            get { return detalleRepuestos; }
            set { detalleRepuestos = value; }
        }

        public ArrayList DetalleRepuestosEliminados
        {
            get { return detalleRepuestosElimindas; }
            set { detalleRepuestosElimindas = value; }
        }


        /// <summary>
        /// Listado de reparaciones completas con repuestos y tareas
        /// </summary>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <returns></returns>
        public virtual ArrayList coleccion(string fechaInicio, string fechaFin)
        {
            string SQL_p;
            MySqlDataReader Reader;
            ArrayList colReparacion = new ArrayList();

            SQL_p = "SELECT ventarepuesto.*, cliente.razonsocial " +
                    "FROM ventarepuesto INNER JOIN cliente " +
                    "ON ventarepuesto.cliente_idcliente = cliente.idcliente " +
                    "WHERE cliente.razonsocial LIKE '%" + Cliente.Filtro + "%' AND ventarepuesto.fecha BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "' " +
                    "ORDER BY cliente.razonsocial";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                VentaRepuesto objReparacioLocal = new VentaRepuesto();

                //DATOS REPARACION
                objReparacioLocal.IdVentaRepuesto = Reader.GetInt32("idventarepuesto");
                objReparacioLocal.ImporteTotal = Reader.GetDouble("importe");
                objReparacioLocal.Fecha = Reader.GetDateTime("fecha");
                objReparacioLocal.FechaSistema = Reader.GetDateTime("fechasistema");
                objReparacioLocal.Descripcion = Reader.GetString("descripcionventa");
                objReparacioLocal.EstadoVenta = Reader.GetInt32("estadoventa");

                //DATOS CLIENTE
                objReparacioLocal.Cliente.Id = Reader.GetInt32("cliente_idcliente");
                objReparacioLocal.Cliente.NombreRazonSocial = Reader.GetString("razonsocial");

                colReparacion.Add(objReparacioLocal);
            }

            Reader.Close();
            return colReparacion;

        }

        public virtual void agregar()
        {
            string SQL_p;

            SQL_p = "INSERT INTO ventarepuesto(fechasistema, fecha, descripcionventa, importe, cliente_idcliente, estadoventa) " +
                    "VALUES('" + String.Format("{0:yyyy/MM/dd}", FechaSistema) + "', '" + String.Format("{0:yyyy/MM/dd}", Fecha)
                    + "','" + Descripcion + "','" + ImporteTotal + "','" + Cliente.Id + "', '" + EstadoVenta + "')";

            Conector.ejecutar(SQL_p);

            this.IdVentaRepuesto = Conector.getLastID();

            //AGREGAR LOS REPUESTOS UTILIZADOS
            foreach (object o in DetalleRepuestos)
            {
                ((RepuestoReparacion)o).agregarVenta(this.IdVentaRepuesto);
            }
        }

        public virtual void actualizar()
        {
            string SQL_p;

            SQL_p = "UPDATE ventarepuesto SET fecha='" + String.Format("{0:yyyy/MM/dd}", Fecha) + "', descripcionventa='" + Descripcion + "', importe='" + ImporteTotal
                    +"', cliente_idcliente='"+Cliente.Id+"', estadoventa='"+EstadoVenta+"' " +
                    "WHERE idventarepuesto='" + IdVentaRepuesto + "'";

            Conector.ejecutar(SQL_p);

            //ACTUZALIZAR LOS REPUESTOS UTILIZADOS
            foreach (object o in DetalleRepuestos)
            {
                if (((RepuestoReparacion)o).IdRepuestoReparacion != 0)
                {
                    ((RepuestoReparacion)o).actualizarVenta();
                }
                else
                {
                    ((RepuestoReparacion)o).agregarVenta(IdVentaRepuesto);
                }
            }

            //REPUESTOS ELIMINADOS
            foreach (object o in DetalleRepuestosEliminados)
            {
                
                ((RepuestoReparacion)o).eliminar();
                
            }
        }

        //ELIMINAR USADO EN GESTIONVENTAREPUESTO
        public virtual void eliminar()
        {
            string SQL_p;
            //Eliminamos todos los repuestos
            this.getRepuestos();
            foreach (object o in DetalleRepuestos)
            {
                //Comprobamos que el repuesto sea del stock y no agregado manualmente
                if (!((RepuestoReparacion)o).FlagRepuestoManual)
                {
                    ((RepuestoReparacion)o).DevolverRepuesto();
                }
            }

            //Finalmente eliminamos las venta
            SQL_p = "DELETE FROM ventarepuesto WHERE idventarepuesto='" + IdVentaRepuesto + "'";

            Conector.ejecutar(SQL_p);
        }

        /// <summary>
        /// Eliminar cuando ocurre un error al guardar entonces debo devolver los repuestos
        /// </summary>
        public void eliminarError()
        {
            string SQL_p;

            //AGREGAR LOS REPUESTOS UTILIZADOS
            foreach (object o in DetalleRepuestos)
            {
                try
                {
                    ((RepuestoReparacion)o).DevolverRepuesto();
                }
                catch { }
            }

            SQL_p = "DELETE FROM ventarepuesto WHERE idventarepuesto='" + IdVentaRepuesto + "'";

            Conector.ejecutar(SQL_p);
        }

        /// <summary>
        /// Obtengo los datos principales de la reparacion sin las tareas ni los repuestos
        /// </summary>
        /// <returns></returns>
        public bool getVentaRepuesto()
        {
            string SQL_p;
            MySqlDataReader Reader;
            ArrayList colReparacion = new ArrayList();

            SQL_p = "SELECT ventarepuesto.*, cliente.razonsocial " +
                    "FROM ventarepuesto INNER JOIN cliente " +
                    "ON ventarepuesto.cliente_idcliente = cliente.idcliente " +
                    "WHERE ventarepuesto.idventarepuesto='" + IdVentaRepuesto + "' LIMIT 1";

            Reader = Conector.consultar(SQL_p);

            if (Reader.Read())
            {
                //DATOS REPARACION
                this.IdVentaRepuesto = Reader.GetInt32("idventarepuesto");
                this.ImporteTotal = Reader.GetDouble("importe");
                this.Fecha = Reader.GetDateTime("fecha");
                this.FechaSistema = Reader.GetDateTime("fechasistema");
                this.Descripcion = Reader.GetString("descripcionventa");
                this.EstadoVenta = Reader.GetInt32("estadoventa");

                //DATOS CLIENTE
                this.Cliente.Id = Reader.GetInt32("cliente_idcliente");
                this.Cliente.NombreRazonSocial = Reader.GetString("razonsocial");

                Reader.Close();

                this.getRepuestos();
                return true;
            }
            else
            {
                Reader.Close();
                return false;
            }

        }

        public void getRepuestos()
        {
            string SQL_p;
            MySqlDataReader Reader;
            ArrayList colReparacion = new ArrayList();

            SQL_p = "SELECT repuestoventa.*, repuestostock.codigorepuesto, repuestostock.descripcion, repuestostock.marca, repuestostock.modelo, repuestostock.precio, repuestostock.cantidad " +
                    "FROM repuestoventa INNER JOIN repuestostock " +
                    "ON repuestoventa.repuestostock_idrepuestostock = repuestostock.idrepuestostock " +
                    "WHERE repuestoventa.ventarepuesto_idventarepuesto = '" + IdVentaRepuesto + "'";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                RepuestoReparacion objRepuestoLocal = new RepuestoReparacion();

                objRepuestoLocal.IdRepuestoReparacion = Reader.GetInt32("idrepuestoventa");
                objRepuestoLocal.IdRepuesto = Reader.GetInt32("repuestostock_idrepuestostock");
                objRepuestoLocal.DescripcionRepuesto = Reader.GetString("descripcion");
                objRepuestoLocal.CodigoRepuesto = Reader.GetString("codigorepuesto");
                objRepuestoLocal.Marca = Reader.GetString("marca");
                objRepuestoLocal.Modelo = Reader.GetString("modelo");
                objRepuestoLocal.PrecioUnitario = Reader.GetDouble("precio");
                objRepuestoLocal.CantidadStock = Reader.GetDouble("cantidad");
                objRepuestoLocal.CantidadRequerida = Reader.GetDouble("cantidadventa");
                objRepuestoLocal.CantidadRequeridaAnterior = Reader.GetDouble("cantidadventa");

                this.DetalleRepuestos.Add(objRepuestoLocal);
            }
            Reader.Close();
        }

        public void getIva()
        {
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT facturaventa.iva FROM facturaventa " +
                    "WHERE facturaventa.ventarepuesto_idventarepuesto = '" + this.IdVentaRepuesto + "'";

            Reader = Conector.consultar(SQL_p);
            if (Reader.Read())
            {
                string condicion;
                double porcentaje;
                condicion = Reader.GetString("iva");
                porcentaje = Convert.ToDouble(condicion.Substring(condicion.IndexOf("(") + 1, condicion.IndexOf("%") - condicion.IndexOf("(") - 1));
                porcentaje = porcentaje / 100;
                this.ImporteTotal = Convert.ToDouble((ImporteTotal + (ImporteTotal * porcentaje)).ToString("0.00"));
            }
            Reader.Close();
        }
    }
}
