using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiGestores.Models
{
    public class Gestores_DB
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string nombre { get; set; }

        [Required]
        public int lanzamiento { get; set; }

        [Required]
        public string desarrollador { get; set; }

    }
}
