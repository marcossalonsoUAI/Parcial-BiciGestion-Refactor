using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TipoBicicletaBLL
    {
        private readonly TipoBicicletaDAL _dal = new TipoBicicletaDAL();

        public List<TipoBicicleta> GetAll()
        {
            try
            {
                return _dal.GetAll();
            }
            catch (Exception ex)
            {
                throw new BusinessException("Error al obtener los tipos de bicicleta: " + ex.Message);
            }
        }
    }
}
