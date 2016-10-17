using Entidades;
using System.Data.Entity;

namespace DAL
{
    public class Parcial1Aplicada1DB : DbContext
    {
        public Parcial1Aplicada1DB() : base ("name=ConStr")
        {
                
        }
        public virtual DbSet<Clientes> Cliente { get; set; }
    }
}
