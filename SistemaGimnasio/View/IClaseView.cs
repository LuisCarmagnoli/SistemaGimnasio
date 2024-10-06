using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaGimnasio.View
{
    public interface IClaseView
    {
        //Properties - Fields
        int IdClase { get; set; }
        string NombreClase { get; set; }
        string Instructor { get; set; }
        string Horario { get; set; }
        int Capacidad { get; set; }
        int EspaciosDisponibles { get; set; }

        string SearchValue { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }

        //Events
        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;

        //Methods
        void SetClaseListBindingSource(BindingSource claseList);
        void Show();//Optional
    }
}
