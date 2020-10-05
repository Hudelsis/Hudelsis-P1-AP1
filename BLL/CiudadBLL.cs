using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Hudelsis_P1_AP1.DAL;
using Hudelsis_P1_AP1.Entidades;

namespace Hudelsis_P1_AP1.BLL
{
    class CiudadBLL
    {
        public static bool Guardar(Ciudad ciudad)
        {
            if (!Existe(ciudad.CiudadId))
                return Insertar(ciudad);

            else
                return Modificar(ciudad);
        }

        private static bool Existe(object ciudadId)
        {
            throw new NotImplementedException();
        }

        private static bool Insertar(Ciudad ciudad)
        {
            Contexto context = new Contexto();
            bool paso = false;

            try
            {
                context.Ciudad.Add(ciudad);
                paso = context.SaveChanges() > 0;
            }
            catch (Exception)
            {  
                throw;
            }
            finally
            {
                context.Dispose();

            }
            return paso;


        }

        public static bool Modificar(Ciudad ciudad)
        {

            Contexto context = new Contexto();
            bool paso = false;

            try
            {
                context.Entry(ciudad).State = EntityState.Modified;
                paso = context.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();

            }
            return paso;

        }
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto context = new Contexto();

            try
            {
                var ciudad = context.Ciudad.Find(id);

                if (ciudad != null)
                {
                    context.Ciudad.Remove(ciudad);
                    paso = context.SaveChanges() > 0;

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }
            return paso;

        }
        public static Ciudad Buscar(int id)
        {
           Ciudad  ciudad;
            Contexto context = new Contexto();


            try
            {
                ciudad = (Ciudad)context.Ciudad.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }
            return ciudad;

        }
        public static bool Existe(int id)
        {

            Contexto context = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = context.Ciudad.Find(id) != null;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }

            return encontrado;

        }
        public static List<Ciudad> GetList(Expression<Func<Ciudad, bool>> criterio)
        {
            List<Ciudad> lista = new List<Ciudad>();
            Contexto context = new Contexto();

            try
            {
                lista = context.Ciudad.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                context.Dispose();
            }
            return lista;

        }
    }
}