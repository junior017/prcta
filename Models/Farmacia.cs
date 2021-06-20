using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Farmacia
    {
        [Key]
        public string cod_cli { get; set; }

        public string nom_cli { get; set; }

        public string sexo { get; set; }

    }
}
