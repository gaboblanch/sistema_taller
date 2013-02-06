using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using MySql.Data.MySqlClient;

namespace SistemaGestionTaller
{
    abstract class Persona
    {
        protected int id;
        protected string nombreRazonSocial;
        protected string direccion;
        protected string telefono;
        protected string cp;
        protected string localidad;
        protected string provincia;
        protected string observaciones;
        protected string email;
        protected string cuit;
        protected string filtro;

       

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string NombreRazonSocial
        {
            get { return nombreRazonSocial; }
            set { nombreRazonSocial = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string Cp
        {
            get { return cp; }
            set { cp = value; }
        }

        public string Localidad
        {
            get { return localidad; }
            set { localidad = value; }
        }

        public string Provincia
        {
            get { return provincia; }
            set { provincia = value; }
        }

        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Cuit
        {
            get { return cuit; }
            set { cuit = value; }
        }

        public string Filtro
        {
            get { return filtro; }
            set { filtro = value; }
        }

        public abstract ArrayList coleccion();

        public abstract void agregar();

        public abstract void actualizar();

        public abstract void eliminar();
    }
}
