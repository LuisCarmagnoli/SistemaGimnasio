using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaGimnasio.View
{
    public partial class ClaseDetailsView : Form
    {
        private BusinessLogicLayer _businessLogicLayer;
        public ClaseDetailsView()
        {
            InitializeComponent();
            _businessLogicLayer = new BusinessLogicLayer();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            GuardarClase();
            this.Close();
            ((MainView)this.Owner).PopulateClases();
        }

        private void GuardarClase()
        {
            Clase clase = new Clase();
            clase.NombreClase = txtNombreClase.Text;
            clase.NombreInstructor = txtNombreInstructor.Text;
            clase.Horario = txtHorario.Text;
            clase.Capacidad = int.Parse(txtCapacidad.Text);
            clase.EspaciosDisponibles = int.Parse(txtEspaciosDisponibles.Text);

            _businessLogicLayer.GuardarClase(clase);
        }
    }
}
