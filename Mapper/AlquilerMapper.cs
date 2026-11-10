using Microsoft.Data.SqlClient;
using System;
using Entity;

namespace Mapper
{
    public static class AlquilerMapper
    {
        public static Alquiler Map(SqlDataReader reader)
        {
            return new Alquiler
            {
                NumeroAlquiler = Convert.ToInt32(reader["NUMERO_ALQUILER"]),
                DniCliente = reader["DNI_CLIENTE"].ToString(),
                ImporteTotal = Convert.ToDecimal(reader["IMPORTE_TOTAL"]),
                FechaRegistro = Convert.ToDateTime(reader["FECHA_REGISTRO"]),
                FechaAlquiler = Convert.ToDateTime(reader["FECHA_ALQUILER"]),
                TipoBicicleta = TipoBicicletaMapper.Map(reader)
            };
        }
    }
}
