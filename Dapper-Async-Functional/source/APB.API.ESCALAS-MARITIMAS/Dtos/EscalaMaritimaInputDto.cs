using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APB.API.ESCALAS_MARITIMAS.Dtos
{
    public class EscalaMaritimaInputDto : PagingParameters
    {
        public string IdSubport { get; set; }
        public int? AnyEscala { get; set; }
        public int? NumEscala { get; set; }
        public DateTime? Fecha { get; set; }
        public bool? ConEstado { get; set; }
        public string[] Estados { get; set; }
    }
}