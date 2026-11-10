using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Entity;
using Mapper;

namespace DAL
{
    public class AlquilerDAL
    {
        public void Insert(Alquiler alquiler)
        {
            using (var connection = new SqlConnection(ConnectionHelper.GetConnectionString()))
            {
                var query = @"INSERT INTO ALQUILER (ID_TIPO_BICICLETA, DNI_CLIENTE, IMPORTE_TOTAL, FECHA_REGISTRO, FECHA_ALQUILER) 
                              VALUES (@IdTipoBicicleta, @DniCliente, @ImporteTotal, @FechaRegistro, @FechaAlquiler);
                              SELECT SCOPE_IDENTITY();";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdTipoBicicleta", alquiler.TipoBicicleta.IdTipoBicicleta);
                    command.Parameters.AddWithValue("@DniCliente", alquiler.DniCliente);
                    command.Parameters.AddWithValue("@ImporteTotal", alquiler.ImporteTotal);
                    command.Parameters.AddWithValue("@FechaRegistro", alquiler.FechaRegistro);
                    command.Parameters.AddWithValue("@FechaAlquiler", alquiler.FechaAlquiler);

                    connection.Open();
                    alquiler.NumeroAlquiler = Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }
        public void Update(Alquiler alquiler)
        {
            using (var connection = new SqlConnection(ConnectionHelper.GetConnectionString()))
            {
                var query = @"UPDATE ALQUILER 
                              SET IMPORTE_TOTAL = @ImporteTotal, FECHA_ALQUILER = @FechaAlquiler
                              WHERE NUMERO_ALQUILER = @NumeroAlquiler";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NumeroAlquiler", alquiler.NumeroAlquiler);
                    command.Parameters.AddWithValue("@ImporteTotal", alquiler.ImporteTotal);
                    command.Parameters.AddWithValue("@FechaAlquiler", alquiler.FechaAlquiler);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public void Delete(int numeroAlquiler)
        {
            using (var connection = new SqlConnection(ConnectionHelper.GetConnectionString()))
            {
                var query = "DELETE FROM ALQUILER WHERE NUMERO_ALQUILER = @NumeroAlquiler";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NumeroAlquiler", numeroAlquiler);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public Alquiler GetById(int id)
        {
            Alquiler result = null;
            using (var connection = new SqlConnection(ConnectionHelper.GetConnectionString()))
            {
                var query = @"SELECT a.NUMERO_ALQUILER, a.ID_TIPO_BICICLETA, a.DNI_CLIENTE, 
                             a.IMPORTE_TOTAL, a.FECHA_REGISTRO, a.FECHA_ALQUILER,
                             tb.DESCRIPCION 
                      FROM ALQUILER a
                      INNER JOIN TIPO_BICICLETA tb ON a.ID_TIPO_BICICLETA = tb.ID_TIPO_BICICLETA
                      WHERE a.NUMERO_ALQUILER = @NumeroAlquiler";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NumeroAlquiler", id);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            result = AlquilerMapper.Map(reader);
                        }
                    }
                }
            }
            return result;
        }
        public List<Alquiler> GetAll()
        {
            var list = new List<Alquiler>();
            using (var connection = new SqlConnection(ConnectionHelper.GetConnectionString()))
            {
                var query = @"SELECT a.NUMERO_ALQUILER, a.ID_TIPO_BICICLETA, a.DNI_CLIENTE, 
                                     a.IMPORTE_TOTAL, a.FECHA_REGISTRO, a.FECHA_ALQUILER,
                                     tb.DESCRIPCION 
                              FROM ALQUILER a
                              INNER JOIN TIPO_BICICLETA tb ON a.ID_TIPO_BICICLETA = tb.ID_TIPO_BICICLETA";
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(AlquilerMapper.Map(reader));
                        }
                    }
                }
            }
            return list;
        }
    }
}
