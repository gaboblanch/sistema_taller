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
    class Repuesto:TipoRepuesto
    {
        protected Proveedor proveedor; // PROVEEDOR QUE TIENE EL REPUESTO
        protected int idRepuesto; // ID DEL REPUESTO TABLA STOCK
        protected int idHistorial;
        protected string idRepuestoManual;
        protected string codigo;
        protected string descripcionRepuesto; // DESCRIPCION DEL REPUESTO
        protected string marca;
        protected string modelo;
        protected double costo;
        protected double cantidadStock; // CANTIDAD QUE SE TIENE DEL REPUESTO
        protected double cantidadTemp; //SOLO SE UTILIZA EN LA CARGA DE STOCK
        protected double precioUnitario; // PRECIO UNITARIO DEL REPUESTO
        protected double minimoStock; // CANTIDAD MINIMA DE STOCK PARA PEDIR EL REPUESTO
        protected string filtro;
        protected string observacionajuste;
        protected DateTime fechainicio;
        protected DateTime fechafin;
        protected double preciohistorial;
        protected double minimoStockHistorial;

        public Repuesto()
        {
            proveedor = new Proveedor();
            fechafin = new DateTime();
            fechainicio = new DateTime();
        }

        public Proveedor Proveedor
        {
            get { return proveedor; }
            set { proveedor = value; }
        }

        public int IdRepuesto
        {
            get { return idRepuesto; }
            set { idRepuesto = value; }
        }

        public int IdHistorial
        {
            get { return idHistorial; }
            set { idHistorial = value; }
        }

        public string IdRepuestoManual
        {
            get { return idRepuestoManual; }
            set { idRepuestoManual = value; }
        }

        public string CodigoRepuesto
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public string DescripcionRepuesto
        {
            get { return descripcionRepuesto; }
            set { descripcionRepuesto = value; }
        }

        public string Marca
        {
            get{ return marca;}
            set{ marca = value;}
        }

        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }

        public double Costo
        {
            get { return costo; }
            set { costo = value; }
        }

        public double CantidadStock
        {
            get { return cantidadStock; }
            set { cantidadStock = value; }
        }

        public double CantidadTemp
        {
            get { return cantidadTemp; }
            set { cantidadTemp = value; }
        }

        public double PrecioUnitario
        {
            get { return precioUnitario; }
            set { precioUnitario= value; }
        }
        
        public double MinimoStock
        {
            get { return minimoStock; }
            set { minimoStock = value; }
        }

        public string Filtro
        {
            get { return filtro; }
            set { filtro = value; }
        }

        public string ObservacionAjuste
        {
            get { return observacionajuste; }
            set { observacionajuste = value; }
        }

        public DateTime FechaInicio
        {
            get { return fechainicio; }
            set { fechainicio = value; }
        }

        public DateTime FechaFin
        {
            get { return fechafin; }
            set { fechafin = value; }
        }

        public double PrecioHistorial
        {
            get { return preciohistorial; }
            set { preciohistorial = value; }
        }

        public double MinimoStockHistorial
        {
            get { return minimoStockHistorial; }
            set { minimoStockHistorial = value; }
        }

        //LISTADO DE REPUESTOS DISPONIBLES
        public override ArrayList coleccion()
        {
            string SQL_p;
            MySqlDataReader Reader;
            ArrayList colRepuestos = new ArrayList();

            SQL_p = "SELECT repuestostock.*, tipo.descripciontipo, tipo.gas, proveedor.razonsocial, historialprecio.* " +
                    "FROM repuestostock INNER JOIN tipo INNER JOIN proveedor INNER JOIN historialprecio " +
                    "ON tipo.idtipo = repuestostock.tipo_idtipo AND repuestostock.proveedor_idproveedor=proveedor.idproveedor " +
                    "AND historialprecio.repuestostock_idrepuestostock = repuestostock.idrepuestostock " +
                    "WHERE repuestostock.descripcion LIKE '%"+filtro+"%' "+
                    "GROUP BY repuestostock.idrepuestostock " +
                    "ORDER BY marca, modelo";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                Repuesto objRespuestoLocal = new Repuesto();
                
                //TIPO REPUESTO
                objRespuestoLocal.Idtipo = Reader.GetInt32("tipo_idtipo");
                objRespuestoLocal.DescripcionTipo = Reader.GetString("descripciontipo");
                objRespuestoLocal.Gas = Reader.GetInt32("gas");

                //DATOS REPUESTO
                objRespuestoLocal.IdRepuesto = Reader.GetInt32("idrepuestostock");
                objRespuestoLocal.CodigoRepuesto = Reader.GetString("codigorepuesto");
                objRespuestoLocal.DescripcionRepuesto = Reader.GetString("descripcion");
                objRespuestoLocal.Marca = Reader.GetString("marca");
                objRespuestoLocal.Modelo = Reader.GetString("modelo");
                objRespuestoLocal.CantidadStock = Reader.GetDouble("cantidad");
                objRespuestoLocal.Costo = Reader.GetDouble("costo");
                objRespuestoLocal.PrecioUnitario = Reader.GetDouble("precio");
                objRespuestoLocal.MinimoStock = Reader.GetDouble("minimo");

                //DATOS HISTORICOS
                objRespuestoLocal.IdHistorial = Reader.GetInt32("idhistorialprecio");
                objRespuestoLocal.FechaInicio = Reader.GetDateTime("fechainicio");
                objRespuestoLocal.FechaFin = Reader.GetDateTime("fechafin");
                objRespuestoLocal.PrecioHistorial = Reader.GetDouble("preciohistorial");
                objRespuestoLocal.MinimoStockHistorial = Reader.GetDouble("cantidadminima");

                //DATOS PROVEEDOR
                objRespuestoLocal.Proveedor.Id = Reader.GetInt32("proveedor_idproveedor");
                objRespuestoLocal.Proveedor.NombreRazonSocial = Reader.GetString("razonsocial");
                
                colRepuestos.Add(objRespuestoLocal);
            }

            Reader.Close();
            return colRepuestos;
        }

        //LISTADO DE REPUESTOS DISPONIBLES ESTADO GAS = 0
        public ArrayList coleccionCodigo()
        {
            string SQL_p;
            MySqlDataReader Reader;
            ArrayList colRepuestos = new ArrayList();

            SQL_p = "SELECT repuestostock.*, tipo.descripciontipo, tipo.gas, proveedor.razonsocial, historialprecio.* " +
                    "FROM repuestostock INNER JOIN tipo INNER JOIN proveedor INNER JOIN historialprecio " +
                    "ON tipo.idtipo = repuestostock.tipo_idtipo AND repuestostock.proveedor_idproveedor=proveedor.idproveedor " +
                    "AND historialprecio.repuestostock_idrepuestostock = repuestostock.idrepuestostock " +
                    "WHERE repuestostock.codigorepuesto LIKE '%" + filtro + "%' AND tipo.gas = '0' " +
                    "GROUP BY repuestostock.idrepuestostock " +
                    "ORDER BY marca, modelo";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                Repuesto objRespuestoLocal = new Repuesto();
                objRespuestoLocal.Proveedor = new SistemaGestionTaller.Proveedor();

                //TIPO REPUESTO
                objRespuestoLocal.Idtipo = Reader.GetInt32("tipo_idtipo");
                objRespuestoLocal.DescripcionTipo = Reader.GetString("descripciontipo");
                objRespuestoLocal.Gas = Reader.GetInt32("gas");

                //DATOS REPUESTO
                objRespuestoLocal.IdRepuesto = Reader.GetInt32("idrepuestostock");
                objRespuestoLocal.CodigoRepuesto = Reader.GetString("codigorepuesto");
                objRespuestoLocal.DescripcionRepuesto = Reader.GetString("descripcion");
                objRespuestoLocal.Marca = Reader.GetString("marca");
                objRespuestoLocal.Modelo = Reader.GetString("modelo");
                objRespuestoLocal.CantidadStock = Reader.GetDouble("cantidad");
                objRespuestoLocal.Costo = Reader.GetDouble("costo");
                objRespuestoLocal.PrecioUnitario = Reader.GetDouble("precio");
                objRespuestoLocal.MinimoStock = Reader.GetDouble("minimo");

                //DATOS HISTORICOS
                objRespuestoLocal.IdHistorial = Reader.GetInt32("idhistorialprecio");
                objRespuestoLocal.FechaInicio = Reader.GetDateTime("fechainicio");
                objRespuestoLocal.FechaFin = Reader.GetDateTime("fechafin");
                objRespuestoLocal.PrecioHistorial = Reader.GetDouble("preciohistorial");
                objRespuestoLocal.MinimoStockHistorial = Reader.GetDouble("cantidadminima");

                //DATOS PROVEEDOR
                objRespuestoLocal.Proveedor.Id = Reader.GetInt32("proveedor_idproveedor");
                objRespuestoLocal.Proveedor.NombreRazonSocial = Reader.GetString("razonsocial");


                colRepuestos.Add(objRespuestoLocal);
            }

            Reader.Close();
            return colRepuestos;
        }

        //LISTADO DE REPUESTOS DISPONIBLES POR MARCA Y MODELO
        public ArrayList coleccionMarcaModelo()
        {
            string SQL_p;
            MySqlDataReader Reader;
            ArrayList colRepuestos = new ArrayList();

            SQL_p = "SELECT repuestostock.*, tipo.descripciontipo, tipo.gas, proveedor.razonsocial, historialprecio.* " +
                    "FROM repuestostock INNER JOIN tipo INNER JOIN proveedor INNER JOIN historialprecio " +
                    "ON tipo.idtipo = repuestostock.tipo_idtipo AND repuestostock.proveedor_idproveedor=proveedor.idproveedor " +
                    "AND historialprecio.repuestostock_idrepuestostock = repuestostock.idrepuestostock " +
                    "WHERE repuestostock.marca LIKE '%" + filtro + "%' OR repuestostock.modelo LIKE '%" + filtro + "%' AND tipo.gas = '0' " +
                    "GROUP BY repuestostock.idrepuestostock " +
                    "ORDER BY marca, modelo";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                Repuesto objRespuestoLocal = new Repuesto();

                //TIPO REPUESTO
                objRespuestoLocal.Idtipo = Reader.GetInt32("tipo_idtipo");
                objRespuestoLocal.DescripcionTipo = Reader.GetString("descripciontipo");
                objRespuestoLocal.Gas = Reader.GetInt32("gas");

                //DATOS REPUESTO
                objRespuestoLocal.IdRepuesto = Reader.GetInt32("idrepuestostock");
                objRespuestoLocal.CodigoRepuesto = Reader.GetString("codigorepuesto");
                objRespuestoLocal.DescripcionRepuesto = Reader.GetString("descripcion");
                objRespuestoLocal.Marca = Reader.GetString("marca");
                objRespuestoLocal.Modelo = Reader.GetString("modelo");
                objRespuestoLocal.CantidadStock = Reader.GetDouble("cantidad");
                objRespuestoLocal.Costo = Reader.GetDouble("costo");
                objRespuestoLocal.PrecioUnitario = Reader.GetDouble("precio");
                objRespuestoLocal.MinimoStock = Reader.GetDouble("minimo");

                //DATOS HISTORICOS
                objRespuestoLocal.IdHistorial = Reader.GetInt32("idhistorialprecio");
                objRespuestoLocal.FechaInicio = Reader.GetDateTime("fechainicio");
                objRespuestoLocal.FechaFin = Reader.GetDateTime("fechafin");
                objRespuestoLocal.PrecioHistorial = Reader.GetDouble("preciohistorial");
                objRespuestoLocal.MinimoStockHistorial = Reader.GetDouble("cantidadminima");

                //DATOS PROVEEDOR
                objRespuestoLocal.Proveedor.Id = Reader.GetInt32("proveedor_idproveedor");
                objRespuestoLocal.Proveedor.NombreRazonSocial = Reader.GetString("razonsocial");

                colRepuestos.Add(objRespuestoLocal);
            }

            Reader.Close();
            return colRepuestos;
        }

        //LISTADO DE REPUESTOS DISPONIBLES ESTADO GAS = 0
        public ArrayList coleccionCodigoRepuestos()
        {
            string SQL_p;
            MySqlDataReader Reader;
            ArrayList colRepuestos = new ArrayList();

            SQL_p = "SELECT repuestostock.*, tipo.descripciontipo, tipo.gas, proveedor.razonsocial, historialprecio.* " +
                    "FROM repuestostock INNER JOIN tipo INNER JOIN proveedor INNER JOIN historialprecio " +
                    "ON tipo.idtipo = repuestostock.tipo_idtipo AND repuestostock.proveedor_idproveedor=proveedor.idproveedor " +
                    "AND historialprecio.repuestostock_idrepuestostock = repuestostock.idrepuestostock " +
                    "WHERE repuestostock.codigorepuesto LIKE '%" + filtro + "%' AND tipo.gas='0'" +
                    "GROUP BY repuestostock.idrepuestostock " +
                    "ORDER BY marca, modelo";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                Repuesto objRespuestoLocal = new Repuesto();
                objRespuestoLocal.Proveedor = new SistemaGestionTaller.Proveedor();

                //TIPO REPUESTO
                objRespuestoLocal.Idtipo = Reader.GetInt32("tipo_idtipo");
                objRespuestoLocal.DescripcionTipo = Reader.GetString("descripciontipo");
                objRespuestoLocal.Gas = Reader.GetInt32("gas");

                //DATOS REPUESTO
                objRespuestoLocal.IdRepuesto = Reader.GetInt32("idrepuestostock");
                objRespuestoLocal.CodigoRepuesto = Reader.GetString("codigorepuesto");
                objRespuestoLocal.DescripcionRepuesto = Reader.GetString("descripcion");
                objRespuestoLocal.Marca = Reader.GetString("marca");
                objRespuestoLocal.Modelo = Reader.GetString("modelo");
                objRespuestoLocal.CantidadStock = Reader.GetDouble("cantidad");
                objRespuestoLocal.Costo = Reader.GetDouble("costo");
                objRespuestoLocal.PrecioUnitario = Reader.GetDouble("precio");
                objRespuestoLocal.MinimoStock = Reader.GetDouble("minimo");

                //DATOS HISTORICOS
                objRespuestoLocal.IdHistorial = Reader.GetInt32("idhistorialprecio");
                objRespuestoLocal.FechaInicio = Reader.GetDateTime("fechainicio");
                objRespuestoLocal.FechaFin = Reader.GetDateTime("fechafin");
                objRespuestoLocal.PrecioHistorial = Reader.GetDouble("preciohistorial");
                objRespuestoLocal.MinimoStockHistorial = Reader.GetDouble("cantidadminima");

                //DATOS PROVEEDOR
                objRespuestoLocal.Proveedor.Id = Reader.GetInt32("proveedor_idproveedor");
                objRespuestoLocal.Proveedor.NombreRazonSocial = Reader.GetString("razonsocial");


                colRepuestos.Add(objRespuestoLocal);
            }

            Reader.Close();
            return colRepuestos;
        }

        //LISTADO DE REPUESTOS DISPONIBLES ESTADO GAS = 1
        public ArrayList coleccionCodigoGas()
        {
            string SQL_p;
            MySqlDataReader Reader;
            ArrayList colRepuestos = new ArrayList();

            SQL_p = "SELECT repuestostock.*, tipo.descripciontipo, tipo.gas, proveedor.razonsocial, historialprecio.* " +
                    "FROM repuestostock INNER JOIN tipo INNER JOIN proveedor INNER JOIN historialprecio " +
                    "ON tipo.idtipo = repuestostock.tipo_idtipo AND repuestostock.proveedor_idproveedor=proveedor.idproveedor " +
                    "AND historialprecio.repuestostock_idrepuestostock = repuestostock.idrepuestostock " +
                    "WHERE repuestostock.codigorepuesto LIKE '%" + filtro + "%' AND tipo.gas='1'" +
                    "GROUP BY repuestostock.idrepuestostock " +
                    "ORDER BY marca, modelo";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                Repuesto objRespuestoLocal = new Repuesto();
                objRespuestoLocal.Proveedor = new SistemaGestionTaller.Proveedor();

                //TIPO REPUESTO
                objRespuestoLocal.Idtipo = Reader.GetInt32("tipo_idtipo");
                objRespuestoLocal.DescripcionTipo = Reader.GetString("descripciontipo");
                objRespuestoLocal.Gas = Reader.GetInt32("gas");

                //DATOS REPUESTO
                objRespuestoLocal.IdRepuesto = Reader.GetInt32("idrepuestostock");
                objRespuestoLocal.CodigoRepuesto = Reader.GetString("codigorepuesto");
                objRespuestoLocal.DescripcionRepuesto = Reader.GetString("descripcion");
                objRespuestoLocal.Marca = Reader.GetString("marca");
                objRespuestoLocal.Modelo = Reader.GetString("modelo");
                objRespuestoLocal.CantidadStock = Reader.GetDouble("cantidad");
                objRespuestoLocal.Costo = Reader.GetDouble("costo");
                objRespuestoLocal.PrecioUnitario = Reader.GetDouble("precio");
                objRespuestoLocal.MinimoStock = Reader.GetDouble("minimo");

                //DATOS HISTORICOS
                objRespuestoLocal.IdHistorial = Reader.GetInt32("idhistorialprecio");
                objRespuestoLocal.FechaInicio = Reader.GetDateTime("fechainicio");
                objRespuestoLocal.FechaFin = Reader.GetDateTime("fechafin");
                objRespuestoLocal.PrecioHistorial = Reader.GetDouble("preciohistorial");
                objRespuestoLocal.MinimoStockHistorial = Reader.GetDouble("cantidadminima");

                //DATOS PROVEEDOR
                objRespuestoLocal.Proveedor.Id = Reader.GetInt32("proveedor_idproveedor");
                objRespuestoLocal.Proveedor.NombreRazonSocial = Reader.GetString("razonsocial");

                colRepuestos.Add(objRespuestoLocal);
            }

            Reader.Close();
            return colRepuestos;
        }

        //CARGAR UN NUEVO REPUESTO
        public override void agregar()
        {
            string SQL_p;

            SQL_p = "INSERT INTO repuestostock(codigorepuesto, descripcion, marca, modelo, cantidad, costo, precio, minimo, proveedor_idproveedor, tipo_idtipo) " +
                    "VALUES('" + CodigoRepuesto + "','" + DescripcionRepuesto + "','" + Marca + "','" + Modelo + "','" + CantidadStock + "','" + Costo + "','" + PrecioUnitario + "','" + MinimoStock
                    + "','" + Proveedor.Id + "', '" + Idtipo + "')";

            Conector.ejecutar(SQL_p);

            this.IdRepuesto = Conector.getLastID();

            SQL_p = "INSERT INTO historialprecio(fechainicio, fechafin, preciohistorial, cantidadminima, costohistorial, repuestostock_idrepuestostock) "+
                    "VALUES('" + String.Format("{0:yyyy/MM/dd}", FechaInicio) + "', '" + String.Format("{0:yyyy/MM/dd}", FechaInicio) + "', '" + PrecioUnitario + "', '" + MinimoStock + "', '"+Costo+"', '" + IdRepuesto + "')";

            Conector.ejecutar(SQL_p);
        }

        /// <summary>
        /// Actualizar solo datos
        /// </summary>
        public void actualizarDatos()
        {
            string SQL_p;

            SQL_p = "UPDATE repuestostock SET codigorepuesto = '" + CodigoRepuesto + "', descripcion='" + DescripcionRepuesto + "', "+
                    "marca='" + Marca + "', modelo='" + Modelo + "', tipo_idtipo='" + Idtipo + "' " +
                    " WHERE idrepuestostock ='" + IdRepuesto + "'";

            Conector.ejecutar(SQL_p);
        }

        //ACTUALIZAR
        public override void actualizar()
        {
            string SQL_p;

            SQL_p = "UPDATE repuestostock SET codigorepuesto = '" + CodigoRepuesto + "', descripcion='" + DescripcionRepuesto + "', marca='" + Marca + "', modelo='" + Modelo + "', cantidad='" + CantidadStock
                    + "', costo='" + Costo + "', precio='" + PrecioUnitario + "', minimo='" + MinimoStock + "', proveedor_idproveedor='" + Proveedor.Id + "', tipo_idtipo='" + Idtipo + "' " +
                    " WHERE idrepuestostock ='" + IdRepuesto + "'";

            Conector.ejecutar(SQL_p);

            if (this.FechaInicio.ToShortDateString() == this.FechaFin.ToShortDateString() && this.PrecioHistorial == 0)
            {
                //SE EJECUTA LA 1RA VEZ DESPUES DE AGREGAR UN REPUESTO NUEVO
                SQL_p = "UPDATE historialprecio SET preciohistorial = '" + PrecioUnitario + "', cantidadminima = '" + MinimoStock + "', costohistorial='" + Costo + "' " +
                        "WHERE idhistorialprecio = '" + IdHistorial + "' ";

                Conector.ejecutar(SQL_p);
            }
            else if (this.FechaInicio.ToShortDateString() != this.FechaFin.ToShortDateString() && this.PrecioUnitario != this.PrecioHistorial)
            {
                //SE EJECUTA CUANDO ACTUALIZAMOS LA CANTIDAD DEL STOCK DISPONIBLE
                SQL_p = "UPDATE historialprecio SET fechafin = '" + String.Format("{0:yyyy/MM/dd}", FechaFin) + "' " +
                        "WHERE idhistorialprecio = '" + IdHistorial + "' ";

                Conector.ejecutar(SQL_p);

                //NUEVO REGISTRO DEL NUEVO PRECIO
                SQL_p = "INSERT INTO historialprecio(fechainicio, fechafin, preciohistorial, cantidadminima, costohistorial, repuestostock_idrepuestostock) " +
                    "VALUES('" + String.Format("{0:yyyy/MM/dd}", FechaFin) + "', '" + String.Format("{0:yyyy/MM/dd}", FechaFin) + "', '" + PrecioUnitario + "', '" + MinimoStock + "', '" + Costo + "', '" + IdRepuesto + "')";

                Conector.ejecutar(SQL_p);
            }

        }

        //ACTUALIZAR
        /// <summary>
        /// Actualiza la tabla repuestostock y agrega a la tabla ajustesalidastock
        /// </summary>
        public void ajusteSalidaStock()
        {
            string SQL_p;

            this.actualizar();

            SQL_p = "INSERT INTO ajustesalidastock(observacion, fechaajuste, cantidadsalida, repuestostock_idrepuestostock) " +
                    "VALUES('" + ObservacionAjuste + "','" + String.Format("{0:yyyy/MM/dd}", DateTime.Now) + "','" + CantidadTemp + "','" + IdRepuesto + "')";

            Conector.ejecutar(SQL_p);
        }

        //ACTULIZAR TIPO DE REPUESTO PARA ELIMINAR EL TIPO DE LA BD
        /// <summary>
        /// Cuando queremos eliminar un tipo de repuesto debemos cambiar todos los repuestos realiza muchos cambios
        /// OJO al utilizarla
        /// </summary>
        /// <param name="idTipo_Nuevo">Id del tipo nuevo</param>
        public void cambiarTipoRepuesto(int idTipo_Nuevo)
        {
            string SQL_p;

            SQL_p = "UPDATE repuestostock SET tipo_idtipo='" + idTipo_Nuevo + "' " +
                    " WHERE tipo_idtipo='" + Idtipo + "' ";

            Conector.ejecutar(SQL_p);
            
        }

        
        //ELIMINAR
        public override void eliminar()
        {
            string SQL_p;

            SQL_p = "DELETE FROM repuestostock WHERE idrepuestostock = '" + IdRepuesto + "'";

            Conector.ejecutar(SQL_p);
        }

        public bool getDatosRepuesto()
        {
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT repuestostock.*, tipo.descripciontipo, tipo.gas, proveedor.razonsocial, historialprecio.* " +
                    "FROM repuestostock INNER JOIN tipo INNER JOIN proveedor INNER JOIN historialprecio " +
                    "ON tipo.idtipo = repuestostock.tipo_idtipo AND repuestostock.proveedor_idproveedor=proveedor.idproveedor " +
                    "AND historialprecio.repuestostock_idrepuestostock = repuestostock.idrepuestostock " +
                    "WHERE idrepuestostock ='" + IdRepuesto + "' "+
                    "ORDER BY historialprecio.idhistorialprecio DESC LIMIT 1";

            Reader = Conector.consultar(SQL_p);

            if (Reader.Read())
            {
                //TIPO
                this.Idtipo = Reader.GetInt32("tipo_idtipo");
                this.DescripcionTipo = Reader.GetString("descripciontipo");
                this.Gas = Reader.GetInt32("gas");

                //REPUESTO
                this.CodigoRepuesto = Reader.GetString("codigorepuesto");
                this.DescripcionRepuesto = Reader.GetString("descripcion");
                this.Marca = Reader.GetString("marca");
                this.Modelo = Reader.GetString("modelo");
                this.Costo = Reader.GetDouble("costo");
                this.CantidadStock = Reader.GetDouble("cantidad");
                this.PrecioUnitario = Reader.GetDouble("precio");
                this.MinimoStock = Reader.GetDouble("minimo");

                //DATOS HISTORICOS
                this.IdHistorial = Reader.GetInt32("idhistorialprecio");
                this.FechaInicio = Reader.GetDateTime("fechainicio");
                this.FechaFin = Reader.GetDateTime("fechafin");
                this.PrecioHistorial = Reader.GetDouble("preciohistorial");
                this.MinimoStockHistorial = Reader.GetDouble("cantidadminima");
                
                //PROVEEDOR
                this.Proveedor.Id = Reader.GetInt32("proveedor_idproveedor");
                this.Proveedor.NombreRazonSocial = Reader.GetString("razonsocial");


                Reader.Close();
                return true;
            }
            else
            {
                Reader.Close();
                return false;
            }
        }

        // TOSTRING
        public override string ToString()
        {
            return Marca + " " + Modelo + "//" + DescripcionRepuesto + "";
        }

        public bool repuestoDuplicado()
        {
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT repuestostock.* " +
                    "FROM repuestostock " +
                    "WHERE codigorepuesto = '"+CodigoRepuesto+"' LIMIT 1";

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

        public bool existeRepuesto()
        {
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT repuestostock.* " +
                    "FROM repuestostock " +
                    "WHERE idrepuestostock = '"+IdRepuesto+"' ";

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

        public ArrayList getHistorial()
        {
            string SQL_p;
            MySqlDataReader Reader;
            ArrayList colHistorial = new ArrayList();

            SQL_p = "SELECT historialprecio.* "+
                    "FROM historialprecio INNER JOIN repuestostock "+
                    "ON repuestostock.idrepuestostock = historialprecio.repuestostock_idrepuestostock "+
                    "WHERE repuestostock.idrepuestostock = '"+this.IdRepuesto+"' "+
                    "ORDER BY historialprecio.fechainicio";

            Reader = Conector.consultar(SQL_p);

            while(Reader.Read())
            {
                HistorialPrecio objHistorial = new HistorialPrecio();
                objHistorial.FechaInicio = Reader.GetDateTime("fechainicio");
                objHistorial.FechaFin = Reader.GetDateTime("fechafin");
                objHistorial.Precio = Reader.GetDouble("preciohistorial");
                objHistorial.Costo = Reader.GetDouble("costohistorial");
                objHistorial.CantidadMinima = Reader.GetDouble("cantidadminima");

                colHistorial.Add(objHistorial);
            }

            Reader.Close();
            return colHistorial;
        }

        public void aumentarRepuestos(double AumentoPrecio)
        {
            string SQL_p;
            SQL_p = "UPDATE repuestostock SET precio = precio*'" + AumentoPrecio + "', costo=costo*'" + AumentoPrecio + "'";
            Conector.ejecutar(SQL_p);
        }
    }
}
