using System;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }

        public string Nombres { get; set; }

        public DateTime MyProperty { get; set; }

        public int LimiteCredito { get; set; }
}
}
