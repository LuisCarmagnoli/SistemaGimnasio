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
    public partial class MainView : Form
    {
        private BusinessLogicLayer _businessLogicLayer;
        public MainView()
        {
            InitializeComponent();
            _businessLogicLayer = new BusinessLogicLayer();
        }

        #region EVENTS

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            OpenContactDetailsDialog();
        }

        #endregion

        #region PRIVATE METHODS

        private void OpenContactDetailsDialog()
        {
            ClaseDetailsView claseDetailsView = new ClaseDetailsView();
            claseDetailsView.ShowDialog(this);
        }

        #endregion

        private void MainView_Load(object sender, EventArgs e)
        {
            PopulateClases();
        }

        public void PopulateClases()
        {
            List<Clase> clases = _businessLogicLayer.GetClases();
            gridClases.DataSource = clases;
        }
    }
}
