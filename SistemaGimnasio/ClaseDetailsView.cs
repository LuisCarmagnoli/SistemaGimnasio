﻿using System;
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
        public int IdClase { get; set; }

        public ClaseDetailsView()
        {
            InitializeComponent();
            _businessLogicLayer = new BusinessLogicLayer();
        }

        public ClaseDetailsView(Clase clase)
        {
            InitializeComponent();
            _businessLogicLayer = new BusinessLogicLayer();

            // Rellenar los TextBox con los datos de la clase recibida
            txtNombreClase.Text = clase.NombreClase;
            txtNombreInstructor.Text = clase.NombreInstructor;
            txtHorario.Text = clase.Horario;
            txtCapacidad.Text = clase.Capacidad.ToString();
            txtEspaciosDisponibles.Text = clase.EspaciosDisponibles.ToString();

            // Almacenar el ID de la clase para la actualización
            IdClase = clase.IdClase;
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
            /*
            Clase clase = new Clase();
            clase.NombreClase = txtNombreClase.Text;
            clase.NombreInstructor = txtNombreInstructor.Text;
            clase.Horario = txtHorario.Text;
            clase.Capacidad = int.Parse(txtCapacidad.Text);
            clase.EspaciosDisponibles = int.Parse(txtEspaciosDisponibles.Text);

            _businessLogicLayer.GuardarClase(clase);
            */

            Clase clase = new Clase
            {
                IdClase = IdClase,
                NombreClase = txtNombreClase.Text,
                NombreInstructor = txtNombreInstructor.Text,
                Horario = txtHorario.Text,
                Capacidad = int.Parse(txtCapacidad.Text),
                EspaciosDisponibles = int.Parse(txtEspaciosDisponibles.Text)
            };

            _businessLogicLayer.GuardarClase(clase);
        }
    }
}
