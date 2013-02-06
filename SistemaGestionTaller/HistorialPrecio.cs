using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaGestionTaller
{
    class HistorialPrecio
    {
        private DateTime fechainicio;
        private DateTime fechafin;
        private double precio;
        private double costo;
        private double cantidadminima;
        private double porcentaje;

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

        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public double Costo
        {
            get { return costo; }
            set { costo = value; }
        }

        public double CantidadMinima
        {
            get { return cantidadminima; }
            set { cantidadminima = value; }
        }

        public double Porcentaje
        {
            get 
            {
                this.calcularPorcentaje();
                return porcentaje; 
            } 
        }

        private void calcularPorcentaje()
        {
            porcentaje = ((this.Precio * 100 / this.Costo) - 100);
        }
    }
}
