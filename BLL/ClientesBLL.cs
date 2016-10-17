using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClientesBLL
    {
        public static bool Insertar(Clientes nuevo)
        {
            bool resultado = false;
            using (var conexion = new Parcial1Aplicada1DB())
            {
                try
                {
                    conexion.Cliente.Add(nuevo);
                    conexion.SaveChanges();
                    resultado = true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return resultado;
        }
        public static Clientes Buscar(int ClientesId)
        {
            var cliente = new Clientes();
            using (var conexion = new Parcial1Aplicada1DB())
            {
                try
                {
                    cliente = conexion.Cliente.Find(ClientesId);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return cliente;
        }
        public static bool Eliminar(Clientes existente)
        {
            bool resultado = false;
            using (var conexion = new Parcial1Aplicada1DB())
            {
                try
                {
                    conexion.Entry(existente).State = EntityState.Deleted;
                    conexion.SaveChanges();
                    resultado = true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return resultado;
        }
        public static List<Clientes> GetLista()
        {
            var lista = new List<Clientes>();
            using (var conexion = new Parcial1Aplicada1DB())
            {
                try
                {
                    lista = conexion.Cliente.ToList();
                }catch(Exception)
                {
                    throw;
                }
            }
            return lista;
        }
    }
}
