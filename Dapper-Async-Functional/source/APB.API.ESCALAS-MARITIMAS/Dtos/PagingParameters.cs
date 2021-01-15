using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APB.API.ESCALAS_MARITIMAS.Dtos
{
    public abstract class PagingParameters
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}