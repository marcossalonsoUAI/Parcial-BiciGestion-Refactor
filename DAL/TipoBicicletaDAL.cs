using Entity;
using Mapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TipoBicicletaDAL
    {
        public List<TipoBicicleta> GetAll()
        {
            var list = new List<TipoBicicleta>();
            using (var connection = new SqlConnection(ConnectionHelper.GetConnectionString()))
            {
                var query = "SELECT ID_TIPO_BICICLETA, DESCRIPCION FROM TIPO_BICICLETA";
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(TipoBicicletaMapper.Map(reader));
                        }
                    }
                }
            }
            return list;
        }
    }
}

