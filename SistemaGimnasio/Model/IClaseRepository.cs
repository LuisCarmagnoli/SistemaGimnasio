using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGimnasio.Model
{
    public interface IClaseRepository
    {
        void Add(ClaseModel claseModel);
        void Edit(ClaseModel claseModel);
        void Delete(int id);
        IEnumerable<ClaseModel> GetAll();
        IEnumerable<ClaseModel> GetByValue(); //Searchs
    }
}
