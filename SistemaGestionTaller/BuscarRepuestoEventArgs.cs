using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaGestionTaller
{
    public class BuscarRepuestoEventArgs:System.EventArgs
    {
        private RepuestoReparacion repuesto;

        public BuscarRepuestoEventArgs(object repuesto_p)
        {
            repuesto = new RepuestoReparacion();
            this.repuesto = (RepuestoReparacion)repuesto_p;
        }

        public object Repuesto
        {
            get { return repuesto; }
        }
    }
}
