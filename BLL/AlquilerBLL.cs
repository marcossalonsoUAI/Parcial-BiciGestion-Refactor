using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Entity;
using DAL;

namespace BLL
{
    public class AlquilerBLL
    {
        private readonly AlquilerDAL _dal = new AlquilerDAL();

        public void Insert(Alquiler alquiler)
        {
            try
            {
                ValidateCommon(alquiler);
                alquiler.FechaRegistro = DateTime.Now;
                _dal.Insert(alquiler);
            }
            catch (BusinessException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new BusinessException("Error al registrar el alquiler en la base de datos: " + ex.Message);
            }
        }
        public void GuardarBorrador(List<Alquiler> borrador)
        {
            try
            {
                if (borrador == null || !borrador.Any())
                    throw new BusinessException("El borrador no tiene alquileres para registrar.");

                using (TransactionScope scope = new TransactionScope())
                {
                    foreach (var alquiler in borrador)
                    {
                        Insert(alquiler);
                    }

                    scope.Complete();
                }
            }
            catch (BusinessException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new BusinessException("Error al procesar la transacción del borrador: " + ex.Message);
            }
        }
        private void ValidateCommon(Alquiler alquiler)
        {
            if (string.IsNullOrWhiteSpace(alquiler.DniCliente))
                throw new BusinessException("El número de DNI del cliente no puede estar vacío.");

            if (alquiler.DniCliente.Length <= 5)
                throw new BusinessException("La cantidad de caracteres del DNI debe ser mayor a 5.");

            if (alquiler.TipoBicicleta == null || alquiler.TipoBicicleta.IdTipoBicicleta <= 0)
                throw new BusinessException("Debe seleccionar un tipo de bicicleta.");

            if (alquiler.ImporteTotal <= 0)
                throw new BusinessException("El importe total debe ser mayor a cero.");

            if (alquiler.FechaAlquiler.Date < DateTime.Now.Date)
                throw new BusinessException("La fecha del alquiler no puede ser menor a la fecha actual.");
        }

        public void Update(int id, decimal importeTotal, DateTime fechaAlquiler)
        {
            try
            {
                if (id <= 0)
                    throw new BusinessException("El ID ingresado debe ser un numero entero o mayor a cero");

                Alquiler existing = GetById(id);
                if (existing == null)
                    throw new BusinessException("No existe un alquiler con el ID indicado");

                if (importeTotal <= 0)
                    throw new BusinessException("El importe total debe ser mayor a cero");

                if (fechaAlquiler.Date < DateTime.Now.Date)
                    throw new BusinessException("La fecha de alquiler debe ser igual o posterior a la fecha actual");

                existing.ImporteTotal = importeTotal;
                existing.FechaAlquiler = fechaAlquiler;

                _dal.Update(existing);
            }
            catch (BusinessException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new BusinessException("Error al modificar el alquiler: " + ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                if (id <= 0)
                    throw new BusinessException("El Id ingresado debe ser un numero entero o mayor a cero");

                Alquiler existing = GetById(id);
                if (existing == null)
                    throw new BusinessException("No existe un alquiler con el Id indicado");

                _dal.Delete(id);
            }
            catch (BusinessException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new BusinessException("Error al eliminar el alquiler: " + ex.Message);
            }
        }

        public Alquiler GetById(int id)
        {
            try
            {
                if (id <= 0)
                    throw new BusinessException("El ID ingresado debe ser un número entero mayor a cero.");

                return _dal.GetById(id);
            }
            catch (BusinessException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new BusinessException("Error al obtener el alquiler: " + ex.Message);
            }
        }

        public List<Alquiler> GetAll()
        {
            try
            {
                return _dal.GetAll();
            }
            catch (Exception ex)
            {
                throw new BusinessException("Error al obtener la lista de alquileres: " + ex.Message);
            }
        }
    }
}
