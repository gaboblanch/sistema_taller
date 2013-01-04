using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaGestionTaller
{
    public class BuscarTareaEventArgs : System.EventArgs
    {
        private TareaReparacion tarea;

        public BuscarTareaEventArgs(object tarea_p)
        {
            tarea = new TareaReparacion();
            this.tarea = (TareaReparacion)tarea_p;
        }

        public object Tarea
        {
            get { return tarea; }
        }
    }
}
