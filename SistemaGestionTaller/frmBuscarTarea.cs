using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace SistemaGestionTaller
{
    public partial class frmBuscarTarea : Form
    {
        private TareaReparacion tarea;
        /// <summary>
        /// Tareas que ya estan incluidas en el detalle
        /// </summary>
        private ArrayList colTareasDetalle;

        //DELEGACION Y EVENTO PARA PASAR PARAMETROS DE UN FORM A OTRO
        public delegate void BuscarTareaHandler(object sender, BuscarTareaEventArgs e);
        public event BuscarTareaHandler TareaEncontrada;

        /// <summary>
        /// Pasamos como parametro una lista de id de tareas
        /// que ya estan incluidas en la reparacion
        /// </summary>
        /// <param name="colTareas_p"></param>
        public frmBuscarTarea(ArrayList colTareas_p)
        {
            InitializeComponent();
            colTareasDetalle = new ArrayList();
            colTareasDetalle = colTareas_p;
        }

        private void llenarListBox()
        {
            ArrayList colTareas = new ArrayList();
            Tarea objTareaLocal = new Tarea();

            tarea.Filtro = textFiltro.Text;

            colTareas = tarea.coleccion();
            
            this.dataGridTarea.Rows.Clear();

            for (int i = 0; i < colTareas.Count; i++)
            {
                objTareaLocal = (Tarea)colTareas[i];

                if (colTareasDetalle.IndexOf(objTareaLocal.IdTarea) < 0)
                {
                    this.dataGridTarea.Rows.Add();
                    this.dataGridTarea.Rows[i].Cells["idtarea"].Value = objTareaLocal.IdTarea;
                    this.dataGridTarea.Rows[i].Cells["descripciontarea"].Value = objTareaLocal.DescripcionTarea;
                    this.dataGridTarea.Rows[i].Cells["costo"].Value = objTareaLocal.Costo;
                    this.dataGridTarea.Rows[i].Cells["duracion"].Value = objTareaLocal.Duracion.ToString(@"hh\:mm");

                    this.dataGridTarea.ClearSelection();
                }
                else
                {
                    colTareas.RemoveAt(i);
                    i--;
                }
            }


            if (this.dataGridTarea.Rows.Count == 0)
            {
                this.dataGridTarea.Rows.Add();
                this.dataGridTarea.Rows[0].Cells["descripciontarea"].Value = "No hay tareas disponibles.";
                this.dataGridTarea.Enabled = false;
            }
        }

        private void frmBuscarTarea_Load(object sender, EventArgs e)
        {
            tarea = new TareaReparacion();
            llenarListBox();
        }

        private void textFiltro_TextChanged(object sender, EventArgs e)
        {
            llenarListBox();
        }

        private void dataGridTarea_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tarea.IdTarea = Convert.ToInt32(this.dataGridTarea.Rows[e.RowIndex].Cells["idtarea"].Value);
            tarea.DescripcionTarea = this.dataGridTarea.Rows[e.RowIndex].Cells["descripciontarea"].Value.ToString();
            tarea.Costo = Convert.ToDouble(this.dataGridTarea.Rows[e.RowIndex].Cells["costo"].Value);
            tarea.Duracion = TimeSpan.Parse(this.dataGridTarea.Rows[e.RowIndex].Cells["duracion"].Value.ToString());

            BuscarTareaEventArgs arg = new BuscarTareaEventArgs(tarea);

            TareaEncontrada(this, arg);

            this.Close();
        }
    }
}
