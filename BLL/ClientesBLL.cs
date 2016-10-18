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
        public static List<Clientes> GetList()
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


        public static List<Clientes> GetList(string Nombres)
        {
            var lista = new List<Clientes>();
            using(var conexion = new Parcial1Aplicada1DB())
            {
                try
                {
                    lista = conexion.Cliente.Where(x => x.Nombres.Equals(Nombres)).ToList();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return lista;
        }
        public static List<Clientes> GetList(string Nombres, DateTime Desde, DateTime Hasta)
        {
            var lista = new List<Clientes>();
            using (var conexion = new Parcial1Aplicada1DB())
            {
                try
                {
                    lista = conexion.Cliente.Where(x => x.Nombres.Equals(Nombres) && x.FechaNacimiento >= Desde && x.FechaNacimiento <= Hasta).ToList();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return lista;
        }
        public static List<Clientes> GetList(DateTime Desde, DateTime Hasta)
        {
            var lista = new List<Clientes>();
            using (var conexion = new Parcial1Aplicada1DB())
            {
                try
                {
                    lista = conexion.Cliente.Where(x => x.FechaNacimiento >= Desde && x.FechaNacimiento <= Hasta).ToList();
                }
                catch (Exception) { throw; }
            }
            return lista;
        }
        public static int UltimoCliente()
        {
            int ultimo;
            using (var conexion = new Parcial1Aplicada1DB())
            {
                    ultimo = conexion.Cliente.Max(x => x.ClienteId);
            }
            return ultimo;
        }
    }
}
