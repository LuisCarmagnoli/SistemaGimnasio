using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGimnasio
{
    public class BusinessLogicLayer
    {
        private DataAccessLayer _dataAccessLayer;

        public BusinessLogicLayer()
        {
            _dataAccessLayer = new DataAccessLayer();
        }

        public Clase GuardarClase(Clase clase)
        {
            if (clase.IdClase == 0)
                _dataAccessLayer.InsertClase(clase);
            //else
            //_dataAccessLayer.UpdateClase
            return clase;
        }

        public List<Clase> GetClases()
        {
            return _dataAccessLayer.GetClases();
        }
    }
}
