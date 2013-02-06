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
    class Proveedor:Persona
    {
        private ArrayList colRepuestos;
        private string pagina;
        private string banconombre;
        private string cuentatipo;
        private string cuentanumero;
        private string titularcuenta;
        private double aumentoPrecio;

        public Proveedor()
        {
            colRepuestos = new ArrayList();
        }

        public ArrayList Repuestos
        {
            get { return colRepuestos; }
            set { colRepuestos = value; }
        }

        public string PaginaWeb
        {
            get { return pagina; }
            set { pagina = value; }
        }

        public string BancoNombre
        {
            get { return banconombre; }
            set { banconombre = value; }
        }

        public string CuentaTipo
        {
            get { return cuentatipo; }
            set { cuentatipo = value; }
        }

        public string CuentaNumero
        {
            get { return cuentanumero; }
            set { cuentanumero = value; }
        }

        public string TitularCuenta
        {
            get { return titularcuenta; }
            set { titularcuenta = value; }
        }

        public double AumentoPrecio
        {
            get { return aumentoPrecio; }
            set { aumentoPrecio = value; }
        }

        //AGREGAR UN NUEVO PROVEEDOR
        public override void agregar()
        {
            string SQL_p;

            SQL_p = "INSERT INTO proveedor (razonsocial,cuit,direccion,telefono,codigopostal,ciudad,provincia,email,observaciones,banconombre,cuentatipo,cuentanumero,titularcuenta,paginaweb) " +
                    "VALUES('" + nombreRazonSocial + "','" + cuit + "','" + direccion + "','" + telefono + "','" + cp
                    + "','" + localidad + "','" + provincia + "','" + email + "', '" + observaciones + "', '"+BancoNombre+"', '"+CuentaTipo+"', '"+CuentaNumero+"', '"+TitularCuenta+"', '"+PaginaWeb+"')";

            Conector.ejecutar(SQL_p);
        }

        // ACTUALIZAR
        public override void actualizar()
        {
            string SQL_p;

            SQL_p = "UPDATE proveedor SET razonsocial='" + nombreRazonSocial + "', cuit='" + cuit + "', direccion='" + direccion +
                "', ciudad='" + localidad + "', provincia='" + provincia + "', codigopostal='" + cp + "', telefono='" + telefono +
                "', email='" + email + "', observaciones='" + observaciones + "', banconombre='"+BancoNombre+"', cuentatipo='"+CuentaTipo+"', "+
                "cuentanumero='"+CuentaNumero+"', titularcuenta='"+TitularCuenta+"', paginaweb='"+PaginaWeb+"' "+
                "WHERE idproveedor = '" + id + "'";

            Conector.ejecutar(SQL_p);
        }

        // ELIMINAR
        public override void eliminar()
        {
            string SQL_p;

            SQL_p = "DELETE FROM proveedor WHERE idproveedor = '" + id + "'";

            Conector.ejecutar(SQL_p);
        }

        public bool getDatosProveedor()
        {
            string SQL_p;
            MySqlDataReader Reader;

            SQL_p = "SELECT * " +
                    "FROM proveedor WHERE idproveedor='" + id + "'";

            Reader = Conector.consultar(SQL_p);

            if (Reader.Read())
            {
                this.NombreRazonSocial = Reader.GetString("razonsocial");
                this.Cuit = Reader.GetString("cuit");
                this.Direccion = Reader.GetString("direccion");
                this.Telefono = Reader.GetString("telefono");
                this.Cp = Reader.GetString("codigopostal");
                this.Localidad = Reader.GetString("ciudad");
                this.Provincia = Reader.GetString("provincia");
                this.Email = Reader.GetString("email");
                this.Observaciones = Reader.GetString("observaciones");
                this.BancoNombre = Reader.GetString("banconombre");
                this.CuentaTipo = Reader.GetString("cuentatipo");
                this.CuentaNumero = Reader.GetString("cuentanumero");
                this.TitularCuenta = Reader.GetString("titularcuenta");
                this.PaginaWeb = Reader.GetString("paginaweb");

                Reader.Close();
                return true;
            }
            else
            {
                Reader.Close();
                return false;
            }
        }

        public override ArrayList coleccion()
        {
            string SQL_p;
            MySqlDataReader Reader;
            ArrayList colProveedor = new ArrayList();

            SQL_p = "SELECT * " +
                    "FROM proveedor " +
                    "WHERE razonsocial LIKE '%" + filtro + "%' " +
                    "ORDER BY razonsocial";

            Reader = Conector.consultar(SQL_p);

            while (Reader.Read())
            {
                Proveedor objProveedorLocal = new Proveedor();
                objProveedorLocal.Repuestos = new ArrayList();

                objProveedorLocal.Id = Reader.GetInt32("idproveedor");
                objProveedorLocal.NombreRazonSocial = Reader.GetString("razonsocial");
                objProveedorLocal.Cuit = Reader.GetString("cuit");
                objProveedorLocal.Direccion = Reader.GetString("direccion");
                objProveedorLocal.Telefono = Reader.GetString("telefono");
                objProveedorLocal.Cp = Reader.GetString("codigopostal");
                objProveedorLocal.Localidad = Reader.GetString("ciudad");
                objProveedorLocal.Provincia = Reader.GetString("provincia");
                objProveedorLocal.Email = Reader.GetString("email");
                objProveedorLocal.Observaciones = Reader.GetString("observaciones");
                objProveedorLocal.BancoNombre = Reader.GetString("banconombre");
                objProveedorLocal.CuentaTipo = Reader.GetString("cuentatipo");
                objProveedorLocal.CuentaNumero = Reader.GetString("cuentanumero");
                objProveedorLocal.TitularCuenta = Reader.GetString("titularcuenta");
                objProveedorLocal.PaginaWeb = Reader.GetString("paginaweb");

                colProveedor.Add(objProveedorLocal);

            }

            Reader.Close();
            return colProveedor;
        }

        public void aumentarRepuestos()
        {
            string SQL_p;
            SQL_p = "UPDATE repuestostock SET precio = precio*'" + AumentoPrecio + "', costo=costo*'" + AumentoPrecio + "' WHERE proveedor_idproveedor='" + Id + "'";
            Conector.ejecutar(SQL_p);
        }
    }
}
