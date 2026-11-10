using Entity;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public static class TipoBicicletaMapper
    {
        public static TipoBicicleta Map(SqlDataReader reader)
        {
            return new TipoBicicleta
            {
                IdTipoBicicleta = Convert.ToInt32(reader["ID_TIPO_BICICLETA"]),
                Descripcion = reader["DESCRIPCION"].ToString()
            };
        }
    }
}
