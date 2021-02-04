using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Models
{
    public class Inventario
    {
        [Required]
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Color { get; set; }
        public string Peso { get; set; }

        public DateTime FechaCaducidad { get; set; }

    }
}
