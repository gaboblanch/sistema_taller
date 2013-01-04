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
    class RepuestoReparacion:Repuesto
    {
        //DATOS REQUERIDOS PARA EL DETALLE DE LA REPARACION
        private int idrepuestoreparacion;
        private double cantidadRequerida;
        private double cantidadRequeridaAnterior;
        private double precioTotal;
        private double costoTotal;
        private double precioUnitarioFacturado;
        private double precioTotalFacturado;
        private bool flagRepuestoManual;
        
        /// <summary>
        /// Puede ser id de reparacion o id de garantia
        /// </summary>
        public int IdRepuestoReparacion
        {
            get { return idrepuestoreparacion; }
            set { idrepuestoreparacion = value; }
        }

        public double CantidadRequerida
        {
            get { return cantidadRequerida; }
            set { cantidadRequerida = value; }
        }

        public double CantidadRequeridaAnterior
        {
            get { return cantidadRequeridaAnterior; }
            set { cantidadRequeridaAnterior = value; }
        }

        public double PrecioTotal
        {
            get {
                precioTotal = CantidadRequerida * PrecioUnitario;
                return precioTotal; 
            }
        }

        public double CostoTotal
        {
            get
            {
                costoTotal = CantidadRequerida * Costo;
                return costoTotal;
            }
        }

        public double PrecioUnitarioFacturado
        {
            get { return precioUnitarioFacturado; }
            set { precioUnitarioFacturado = value; }
        }

        public double PrecioTotalFacturado
        {
            get
            {
                precioTotalFacturado = CantidadRequerida * PrecioUnitarioFacturado;
                return precioTotalFacturado;
            }
        }

        public bool FlagRepuestoManual
        {
            get { return flagRepuestoManual; }
            set { flagRepuestoManual = value; }
        }
        
        //LISTADO DE REPUESTOS DISPONIBLES
        public ArrayList coleccion(int idProveedor)
        {
            string SQL_p;
            MySqlDataReader Reader;
            ArrayList colRepuestos = new ArrayList();

            SQL_p = "SELECT repuestostock.*, tipo.descripciontipo, tipo.gas, proveedor.razonsocial, historialprecio.* " +
                    "FROM repuestostock INNER JOIN tipo INNER JOIN proveedor INNER JOIN historialprecio " +
                    "ON tipo.idtipo = repuestostock.tipo_idtipo AND repuestostock.proveedor_idproveedor=proveedor.idproveedor "+
                    "AND historialprecio.repuestostock_idrepuestostock = repuestostock.idrepuestostock " +
                    "WHERE repuestostock.descripcion LIKE '%" + filtro + "%' AND proveedor.idproveedor = '"+ idProveedor +"' " +
                    "GROUP BY repuestostock.idrepuestostock " +
                    "ORDER BY marca, modelo";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                RepuestoReparacion objRespuestoLocal = new RepuestoReparacion();

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
                //objRespuestoLocal.PrecioTotalFacturado = Reader.GetDouble("preciototal");

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
        public ArrayList coleccionCodigo(int idProveedor)
        {
            string SQL_p;
            MySqlDataReader Reader;
            ArrayList colRepuestos = new ArrayList();

            SQL_p = "SELECT repuestostock.*, tipo.descripciontipo, tipo.gas, proveedor.razonsocial, historialprecio.* " +
                    "FROM repuestostock INNER JOIN tipo INNER JOIN proveedor INNER JOIN historialprecio " +
                    "ON tipo.idtipo = repuestostock.tipo_idtipo AND repuestostock.proveedor_idproveedor=proveedor.idproveedor " +
                    "AND historialprecio.repuestostock_idrepuestostock = repuestostock.idrepuestostock " +
                    "WHERE repuestostock.codigorepuesto LIKE '%" + filtro + "%' AND proveedor.idproveedor = '" + idProveedor + "' " +
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

        //LISTADO DE REPUESTOS DISPONIBLES ESTADO GAS = 0
        public ArrayList coleccionRepuestos()
        {
            string SQL_p;
            MySqlDataReader Reader;
            ArrayList colRepuestos = new ArrayList();

            SQL_p = "SELECT repuestostock.*, tipo.descripciontipo, tipo.gas, proveedor.razonsocial, historialprecio.* " +
                    "FROM repuestostock INNER JOIN tipo INNER JOIN proveedor INNER JOIN historialprecio " +
                    "ON tipo.idtipo = repuestostock.tipo_idtipo AND repuestostock.proveedor_idproveedor=proveedor.idproveedor " +
                    "AND historialprecio.repuestostock_idrepuestostock = repuestostock.idrepuestostock " +
                    "WHERE repuestostock.descripcion LIKE '%" + filtro + "%' AND tipo.gas='0' " +
                    "GROUP BY repuestostock.idrepuestostock " +
                    "ORDER BY marca, modelo";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                RepuestoReparacion objRespuestoLocal = new RepuestoReparacion();

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
                //objRespuestoLocal.PrecioTotalFacturado = Reader.GetDouble("preciototal");

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
        public ArrayList coleccionRespuestoGas()
        {
            string SQL_p;
            MySqlDataReader Reader;
            ArrayList colRepuestos = new ArrayList();

            SQL_p = "SELECT repuestostock.*, tipo.descripciontipo, tipo.gas, proveedor.razonsocial, historialprecio.* " +
                    "FROM repuestostock INNER JOIN tipo INNER JOIN proveedor INNER JOIN historialprecio " +
                    "ON tipo.idtipo = repuestostock.tipo_idtipo AND repuestostock.proveedor_idproveedor=proveedor.idproveedor "+
                    "AND historialprecio.repuestostock_idrepuestostock = repuestostock.idrepuestostock " +
                    "WHERE repuestostock.descripcion LIKE '%" + filtro + "%' AND tipo.gas='1' " +
                    "GROUP BY repuestostock.idrepuestostock " +
                    "ORDER BY marca, modelo";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                RepuestoReparacion objRespuestoLocal = new RepuestoReparacion();

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
                //objRespuestoLocal.PrecioTotalFacturado = Reader.GetDouble("preciototal"); 

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

        //CARGAR UN NUEVO REPUESTO REPARACION
        public void agregarReparacion(int idReparacion_p)
        {
            string SQL_p;
            bool flagContinuar;

            //METODO DE UN REPUESTO TEMPORAL
            if (IdRepuesto == 0)
            {
                //INSERTAMOS EN TABLA repuestogenerico
                SQL_p = "INSERT INTO repuestogenerico(modelo, marca, descripcion, cantidadreparacion, preciototal, reparacion_idreparacion, codigorepuesto) " +
                        "VALUES('"+Modelo+"', '"+Marca+"', '"+DescripcionRepuesto+"', '" + CantidadRequerida + "', '"+PrecioTotal+"', '" + idReparacion_p + "', '"+CodigoRepuesto+"')";

                Conector.ejecutar(SQL_p);

                return;
            }

            //METODO DE UN REPUESTO ALMACENADO
            if ((CantidadStock - CantidadRequerida) >= 0)
            {
                try
                {
                    //INSERTAMOS EN TABLA repuestoreparacion
                    SQL_p = "INSERT INTO repuestoreparacion(cantidadreparacion, reparacion_idreparacion, repuestostock_idrepuestostock, preciototal) " +
                            "VALUES('" + CantidadRequerida + "','" + idReparacion_p + "','" + IdRepuesto + "', '" + PrecioTotal + "')";

                    Conector.ejecutar(SQL_p);
                    
                    flagContinuar = true;
                }
                catch { flagContinuar = false; }

                if (flagContinuar)
                {
                    //DESCONTAMOS LA CANTIDAD DE REPUESTOS UTILIZADOS
                    SQL_p = "UPDATE repuestostock SET cantidad='" + (CantidadStock - CantidadRequerida) + "' " +
                            "WHERE  idrepuestostock='" + IdRepuesto + "'";

                    Conector.ejecutar(SQL_p);
                }
            }

        }

        //CARGAR UN NUEVO REPUESTO REPARACION
        public void agregarPresupuesto(int idReparacion_p)
        {
            string SQL_p;

            //METODO DE UN REPUESTO TEMPORAL
            try
            {
                if (IdRepuesto == 0)
                {
                    //INSERTAMOS EN TABLA repuestogenerico
                    SQL_p = "INSERT INTO repuestogenerico(modelo, marca, descripcion, cantidadreparacion, preciototal, reparacion_idreparacion, codigorepuesto) " +
                            "VALUES('" + Modelo + "', '" + Marca + "', '" + DescripcionRepuesto + "', '" + CantidadRequerida + "', '" + PrecioTotal + "', '" + idReparacion_p + "', '"+CodigoRepuesto+"')";

                    Conector.ejecutar(SQL_p);

                    return;
                }
            }
            catch { }

            //METODO DE UN REPUESTO ALMACENADO
            try
            {
                //INSERTAMOS EN TABLA repuestoreparacion
                SQL_p = "INSERT INTO repuestoreparacion(cantidadreparacion, reparacion_idreparacion, repuestostock_idrepuestostock, preciototal) " +
                        "VALUES('" + CantidadRequerida + "','" + idReparacion_p + "','" + IdRepuesto + "', '" + PrecioTotal + "')";

                Conector.ejecutar(SQL_p);
            }
            catch {}           

        }

        public void agregarGarantia(int idGarantia)
        {
            string SQL_p;
            bool flagContinuar;

            //METODO DE UN REPUESTO TEMPORAL
            if (FlagRepuestoManual)
            {
                //INSERTAMOS EN TABLA repuestogenerico
                SQL_p = "INSERT INTO repuestogarantiagenerico(modelo, marca, descripcion, cantidadgarantia, preciototal, garantia_idgarantia, codigorepuesto) " +
                        "VALUES('" + Modelo + "', '" + Marca + "', '" + DescripcionRepuesto + "', '" + CantidadRequerida + "', '" + CostoTotal + "', '" + idGarantia + "', '"+CodigoRepuesto+"')";

                Conector.ejecutar(SQL_p);

                return;
            }
            else
            {
                //METODO DE UN REPUESTO ALMACENADO
                if ((CantidadStock - CantidadRequerida) >= 0)
                {
                    try
                    {
                        //INSERTAMOS EN TABLA repuestogarantia
                        SQL_p = "INSERT INTO repuestogarantia (cantidadreparacion, preciototal, repuestostock_idrepuestostock, garantia_idgarantia) "+
                                "VALUES ('" + CantidadRequerida + "','" + PrecioTotal + "','" + IdRepuesto + "', '" + idGarantia + "')";

                        Conector.ejecutar(SQL_p);
                        
                        flagContinuar = true;
                    }
                    catch { flagContinuar = false; }

                    if (flagContinuar)
                    {
                        //DESCONTAMOS LA CANTIDAD DE REPUESTOS UTILIZADOS
                        SQL_p = "UPDATE repuestostock SET cantidad='" + (CantidadStock - CantidadRequerida) + "' " +
                                "WHERE  idrepuestostock='" + IdRepuesto + "'";

                        Conector.ejecutar(SQL_p);
                    }
                }
            }
        }

        //CARGAR UN NUEVO VENTA REPUESTO
        public void agregarVenta(int idVentaRepuesto_p)
        {
            string SQL_p;
            bool flagContinuar;

            if ((CantidadStock - CantidadRequerida) >= 0)
            {
                try
                {
                    //DESCONTAMOS LA CANTIDAD DE REPUESTOS UTILIZADOS
                    SQL_p = "UPDATE repuestostock SET cantidad='" + (CantidadStock - CantidadRequerida) + "' " +
                            "WHERE  idrepuestostock='" + IdRepuesto + "'";

                    Conector.ejecutar(SQL_p);
                    flagContinuar = true;
                }
                catch { flagContinuar = false; }

                if (flagContinuar)
                {
                    //INSERTAMOS EN TABLA repuestoventa
                    SQL_p = "INSERT INTO repuestoventa(cantidadventa, preciototal, ventarepuesto_idventarepuesto, repuestostock_idrepuestostock) " +
                            "VALUES('" + CantidadRequerida + "', '"+PrecioTotal+"', '" + idVentaRepuesto_p + "','" + IdRepuesto + "')";

                    Conector.ejecutar(SQL_p);
                }
            }
        
        }

        //ACTUALIZAR REPARACION
        public void actualizarReparacion()
        {
            string SQL_p;
            bool flagContinuar;

            if ((CantidadStock - CantidadRequerida) >= 0 && !this.FlagRepuestoManual)
            {//REPUESTOS DE STOCK
                try
                {
                    //DEVOLVEMOS AL STOCK LA CANTIDAD DE REPUESTOS UTILIZADOS
                    SQL_p = "UPDATE repuestostock SET cantidad='" + (CantidadStock + CantidadRequeridaAnterior) + "' " +
                            "WHERE idrepuestostock='" + IdRepuesto + "'";

                    Conector.ejecutar(SQL_p);

                    //DESCONTAMOS LA CANTIDAD DE REPUESTOS UTILIZADOS
                    SQL_p = "UPDATE repuestostock SET cantidad='" + ((CantidadStock + CantidadRequeridaAnterior) - CantidadRequerida) + "' " +
                            "WHERE idrepuestostock='" + IdRepuesto + "'";

                    Conector.ejecutar(SQL_p);
                    flagContinuar = true;
                }
                catch { flagContinuar = false; }

                if (flagContinuar)
                {
                    SQL_p = "UPDATE repuestoreparacion SET cantidadreparacion='" + CantidadRequerida + "', preciototal='" + PrecioTotal + "' " +
                            "WHERE idrepuestoreparacion ='" + IdRepuestoReparacion + "'";

                    Conector.ejecutar(SQL_p);
                }

            }
            else if (this.FlagRepuestoManual)
            {//REPUESTOS GENERICOS
                SQL_p = "UPDATE repuestogenerico SET cantidadreparacion='" + CantidadRequerida + "', preciototal='" + PrecioTotal + "' " +
                            "WHERE idrepuestogenerico ='" + IdRepuestoReparacion + "'";

                Conector.ejecutar(SQL_p);
            }

        }

        //DEVOLVEMOS LOS REPUESTOS AL STOCK CUANDO CAMBIAMOS EL ESTADO DE OT A PRESUPUESTO
        public void DevolverRepuesto()
        {
            string SQL_p;

            //DEVOLVEMOS AL STOCK LA CANTIDAD DE REPUESTOS UTILIZADOS
            SQL_p = "UPDATE repuestostock SET cantidad='" + (CantidadStock + CantidadRequeridaAnterior) + "' " +
                    "WHERE idrepuestostock='" + IdRepuesto + "'";

            Conector.ejecutar(SQL_p);
        }

        //ACTUALIZAR REPARACION DESDE PRESUPUESTO
        public void actualizarReparacionPresupuesto()
        {
            string SQL_p;
            bool flagContinuar;

            if ((CantidadStock - CantidadRequerida) >= 0)
            {
                try
                {
                    //DESCONTAMOS LA CANTIDAD DE REPUESTOS UTILIZADOS
                    SQL_p = "UPDATE repuestostock SET cantidad='" + (CantidadStock - CantidadRequerida) + "' " +
                            "WHERE idrepuestostock='" + IdRepuesto + "'";

                    Conector.ejecutar(SQL_p);
                    flagContinuar = true;
                }
                catch { flagContinuar = false; }

                if (flagContinuar)
                {
                    SQL_p = "UPDATE repuestoreparacion SET cantidadreparacion='" + CantidadRequerida + "', preciototal='" + PrecioTotal + "' " +
                            "WHERE idrepuestoreparacion ='" + IdRepuestoReparacion + "'";

                    Conector.ejecutar(SQL_p);
                }

            }
        }


        //ACTUALIZAR PRESUPUESTO
        public void actualizarPresupuesto()
        {
            string SQL_p;

            try
            {
                if(this.FlagRepuestoManual)
                {
                    SQL_p = "UPDATE repuestogenerico SET cantidadreparacion='" + CantidadRequerida + "', preciototal='" + PrecioTotal + "' " +
                            "WHERE idrepuestogenerico ='" + IdRepuestoReparacion + "'";

                    Conector.ejecutar(SQL_p);                
                }
                else
                {
                    SQL_p = "UPDATE repuestoreparacion SET cantidadreparacion='" + CantidadRequerida + "', preciototal='" + PrecioTotal + "' " +
                        "WHERE idrepuestoreparacion ='" + IdRepuestoReparacion + "'";

                    Conector.ejecutar(SQL_p);
                }

            }
            catch { }


        }

        //ACTUALIZAR VENTA
        public void actualizarVenta()
        {
            string SQL_p;
            bool flagContinuar;

            if ((CantidadStock - CantidadRequerida) >= 0)
            {
                try
                {
                    //DEVOLVEMOS AL STOCK LA CANTIDAD DE REPUESTOS UTILIZADOS
                    SQL_p = "UPDATE repuestostock SET cantidad='" + (CantidadStock + CantidadRequeridaAnterior) + "' " +
                            "WHERE idrepuestostock='" + IdRepuesto + "'";

                    Conector.ejecutar(SQL_p);

                    //DESCONTAMOS LA CANTIDAD DE REPUESTOS UTILIZADOS
                    SQL_p = "UPDATE repuestostock SET cantidad='" + ((CantidadStock + CantidadRequeridaAnterior) - CantidadRequerida) + "' " +
                            "WHERE idrepuestostock='" + IdRepuesto + "'";

                    Conector.ejecutar(SQL_p);
                    flagContinuar = true;
                }
                catch { flagContinuar = false; }

                if (flagContinuar)
                {
                    SQL_p = "UPDATE repuestoventa SET cantidadventa='" + CantidadRequerida + "', preciototal='"+PrecioTotal+"' " +
                            "WHERE idrepuestoventa ='" + IdRepuestoReparacion + "'";

                    Conector.ejecutar(SQL_p);
                }

            }
        }

        //ACTUALIZAR REPARACION
        public void actualizarGarantia()
        {
            string SQL_p;
            bool flagContinuar;

            if ((CantidadStock - CantidadRequerida) >= 0 && !this.FlagRepuestoManual)
            {//REPUESTOS DE STOCK
                try
                {
                    //DEVOLVEMOS AL STOCK LA CANTIDAD DE REPUESTOS UTILIZADOS
                    SQL_p = "UPDATE repuestostock SET cantidad='" + (CantidadStock + CantidadRequeridaAnterior) + "' " +
                            "WHERE idrepuestostock='" + IdRepuesto + "'";

                    Conector.ejecutar(SQL_p);

                    //DESCONTAMOS LA CANTIDAD DE REPUESTOS UTILIZADOS
                    SQL_p = "UPDATE repuestostock SET cantidad='" + ((CantidadStock + CantidadRequeridaAnterior) - CantidadRequerida) + "' " +
                            "WHERE idrepuestostock='" + IdRepuesto + "'";

                    Conector.ejecutar(SQL_p);
                    flagContinuar = true;
                }
                catch { flagContinuar = false; }

                if (flagContinuar)
                {
                    SQL_p = "UPDATE repuestogarantia SET cantidadreparacion='" + CantidadRequerida + "', preciototal='" + PrecioTotal + "' " +
                            "WHERE idrepuestogarantia ='" + IdRepuestoReparacion + "'";

                    Conector.ejecutar(SQL_p);
                }

            }
            else if (this.FlagRepuestoManual)
            {//REPUESTOS GENERICOS
                SQL_p = "UPDATE repuestogenerico SET cantidadreparacion='" + CantidadRequerida + "', preciototal='" + PrecioTotal + "' " +
                            "WHERE idrepuestogenerico ='" + IdRepuestoReparacion + "'";

                Conector.ejecutar(SQL_p);
            }

        }

        /// <summary>
        /// ELIMINA todos los repuestos de stock asociados a una reparacion asignar idreparacion
        /// </summary>
        public void eliminarDetalle(int idReparacion_p)
        {
            string SQL_p;
            bool flagContinuar;

            if (FlagRepuestoManual)
            {
                SQL_p = "DELETE FROM repuestogenerico WHERE idrepuestogenerico = '" + this.IdRepuesto + "'";

                Conector.ejecutar(SQL_p);
            }
            else
            {
                try
                {
                    //DEVOLVEMOS AL STOCK LA CANTIDAD DE REPUESTOS UTILIZADOS
                    SQL_p = "UPDATE repuestostock SET cantidad='" + (CantidadStock + CantidadRequeridaAnterior) + "' " +
                            "WHERE idrepuestostock='" + IdRepuesto + "'";

                    Conector.ejecutar(SQL_p);
                    flagContinuar = true;
                }
                catch { flagContinuar = false; }

                if (flagContinuar)
                {
                    SQL_p = "DELETE FROM repuestoreparacion WHERE idrepuestoreparacion = '" + this.IdRepuestoReparacion + "' AND reparacion_idreparacion='" + idReparacion_p + "'";

                    Conector.ejecutar(SQL_p);
                }
            }
        }

        //FUNCION UTILIZADA POR PRESUPUESTO
        public void eliminarDetallePresupuesto(int idReparacion_p)
        {
            string SQL_p;
            
            if (FlagRepuestoManual)
            {
                SQL_p = "DELETE FROM repuestogenerico WHERE idrepuestogenerico = '" + idReparacion_p + "'";
                Conector.ejecutar(SQL_p);
            }
            else
            {
                SQL_p = "DELETE FROM repuestoreparacion WHERE repuestostock_idrepuestostock = '"+IdRepuesto+"' AND reparacion_idreparacion = '" + idReparacion_p + "'";
                Conector.ejecutar(SQL_p);
            }
            
        }

        /// <summary>
        /// ELIMINA todos los repuestos de stock asociados a una reparacion asignar idreparacion
        /// </summary>
        public void eliminarGenerico(int idReparacion_p)
        {
            string SQL_p;
            try
            {
                SQL_p = "DELETE FROM repuestogenerico WHERE idrepuestogenerico = '"+IdRepuesto+"' AND reparacion_idreparacion = '" + idReparacion_p + "'";
                Conector.ejecutar(SQL_p);
            }
            catch {  }

        }
    }
}
