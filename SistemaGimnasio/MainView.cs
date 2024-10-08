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
    public partial class MainView : Form
    {
        private BusinessLogicLayer _businessLogicLayer;
        public MainView()
        {
            InitializeComponent();
            _businessLogicLayer = new BusinessLogicLayer();

            // Suscribir el evento CellClick
            gridClases.CellClick += gridClases_CellClick;
        }

        #region EVENTS
        private void MainView_Load(object sender, EventArgs e)
        {
            PopulateClases();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            OpenContactDetailsDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en el DataGridView
            if (gridClases.SelectedRows.Count > 0)
            {
                // Obtener la clase seleccionada
                Clase claseSeleccionada = (Clase)gridClases.SelectedRows[0].DataBoundItem;

                // Abrir la ventana de detalles de clase con los datos de la clase seleccionada
                ClaseDetailsView claseDetailsView = new ClaseDetailsView(claseSeleccionada);
                claseDetailsView.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una clase para editar.");
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en el DataGridView
            if (gridClases.SelectedRows.Count > 0)
            {
                // Obtener la clase seleccionada
                Clase claseSeleccionada = (Clase)gridClases.SelectedRows[0].DataBoundItem;

                // Confirmar la eliminación
                var confirmResult = MessageBox.Show("¿Estás seguro de que deseas eliminar esta clase?",
                                                     "Confirmar eliminación",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    // Llamar a la capa de negocio para eliminar la clase
                    _businessLogicLayer.BorrarClase(claseSeleccionada.IdClase);

                    // Actualizar el DataGridView
                    PopulateClases();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una clase para borrar.");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string searchTerm = txtBuscar.Text.Trim();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                // Llamar a la capa de negocio para buscar las clases
                List<Clase> resultados = _businessLogicLayer.SearchClases(searchTerm);

                // Actualizar el DataGridView con los resultados
                gridClases.DataSource = resultados;
            }
            else
            {
                // Si el campo de búsqueda está vacío, volver a cargar todas las clases
                PopulateClases();
            }
        }

        private void gridClases_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Permitir seleccionar la fila completa al hacer clic en cualquier celda
            if (e.RowIndex >= 0)
            {
                gridClases.Rows[e.RowIndex].Selected = true;
            }
        }
        #endregion

        #region PRIVATE METHODS

        private void OpenContactDetailsDialog()
        {
            ClaseDetailsView claseDetailsView = new ClaseDetailsView();
            claseDetailsView.ShowDialog(this);
        }
        public void PopulateClases()
        {
            List<Clase> clases = _businessLogicLayer.GetClases();
            gridClases.DataSource = clases;
        }

        #endregion
    }
}
