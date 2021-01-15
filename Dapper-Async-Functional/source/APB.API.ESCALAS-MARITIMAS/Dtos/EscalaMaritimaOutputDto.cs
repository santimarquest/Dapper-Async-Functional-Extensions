using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APB.API.ESCALAS_MARITIMAS.Dtos
{
    public class EscalaMaritimaOutputDto
    {
        public string IdSubport { get; set; }
        public int AnyEscala { get; set; }
        public int NumEscala { get; set; }
        public DateTime ETA { get; set; }
        public DateTime ETD { get; set; }
        public string NomEstatEscala { get; set; }
        public string CodiEstatEscala { get; set; }
        public string NomVaixell { get; set; }
        public string NomArmador { get; set; }
        public string NomConsignatari { get; set; }
    }
}