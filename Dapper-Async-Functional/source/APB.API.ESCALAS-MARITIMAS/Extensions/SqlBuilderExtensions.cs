using APB.API.ESCALAS_MARITIMAS.Dtos;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APB.API.ESCALAS_MARITIMAS.Extensions
{
    public static class SqlBuilderExtensions
    {
        public static SqlBuilder AddFilter<SqlBuilder>(this SqlBuilder @this,
            EscalaMaritimaInputDto escalaMaritimaInputDto,
            Func<EscalaMaritimaInputDto, SqlBuilder, SqlBuilder> fn)
        {
            return fn(escalaMaritimaInputDto, @this);
        }
    }
}