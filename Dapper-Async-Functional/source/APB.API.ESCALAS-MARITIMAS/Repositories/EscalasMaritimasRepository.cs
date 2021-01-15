using APB.API.ESCALAS_MARITIMAS.Dtos;
using APB.API.ESCALAS_MARITIMAS.Extensions;
using Dapper;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace APB.API.ESCALAS_MARITIMAS.Repositories
{
    public class EscalasMaritimasRepository : IDisposable
    {
        private IConfiguration _configuration;
        private IDbConnection _connection;
        private static string _idioma;

        private Dictionary<string, string> DiccionarioIdiomas = new Dictionary<string, string>() {
            {"CA", "CT" },
            { "ES", "ES"},
            { "EN", "EN"},
            {"FR", "FR" }
        };

        public EscalasMaritimasRepository(IConfiguration configuration, string idioma)
        {
            _configuration = configuration;
            _connection = new OracleConnection(_configuration.GetConnectionString("SOSTRAT"));
            _idioma = DiccionarioIdiomas[idioma];
        }

        public async Task<PagedResult<EscalaMaritimaOutputDto>> GetPagedResult(EscalaMaritimaInputDto escalaMaritimaInputDto)
        {
            return PagedResult<EscalaMaritimaOutputDto>.ToPagedResult(await GetData(escalaMaritimaInputDto),
                (int)escalaMaritimaInputDto.PageNumber,
                (int)escalaMaritimaInputDto.PageSize);
        }

        public async Task<IQueryable<EscalaMaritimaOutputDto>> GetData(EscalaMaritimaInputDto escalaMaritimaInputDto)
        {
            var strQuery = BaseQuery();
            var builder = new SqlBuilder();
            var selector = builder.AddTemplate(strQuery);
            builder
                .Execute(b => AddInitialWhere(b))
                .AddFilter(escalaMaritimaInputDto, Criteria)
                .Execute(b => AddOrder(b));

            var queryResult = await _connection.QueryAsync<EscalaMaritimaOutputDto>(selector.RawSql, selector.Parameters);
            return queryResult.AsQueryable();
        }

        private static SqlBuilder AddInitialWhere(SqlBuilder builder)
        {
            builder.Where("ESC.IDSUBPORT = ESCASP.IDSUBPORT")
            .Where("ESC.ANYESCALA = ESCASP.ANYESCALA")
            .Where("ESC.NUMESCALA = ESCASP.NUMESCALA")
            .Where("ESC.ASPACTUAL = ESCASP.ASPECTE")
            .Where("ETEOI.IDESTOPERATIU = ESC.IDESTOPERATIU")
            .Where("VAI.IDVAIXELL = ESCASP.IDVAIXELL")
            .Where("USUARM.IDUSUARI = ESCASP.IDARMADOR")
            .Where("USUCON.IDUSUARI = ESCASP.IDCONSIGNATARI");

            return builder;
        }

        private SqlBuilder AddOrder(SqlBuilder builder)
        {
            return builder.OrderBy("ESC.IDSUBPORT").OrderBy("ESC.ANYESCALA DESC").OrderBy("ESC.NUMESCALA DESC");
        }

        private static SqlBuilder Criteria(EscalaMaritimaInputDto escalaMaritimaInputDto, SqlBuilder builder)
        {
            builder
                .AddCondition(escalaMaritimaInputDto.IdSubport, AddConditionSubPort)
                .AddCondition(escalaMaritimaInputDto.AnyEscala, AddConditionAnyEscala)
                .AddCondition(escalaMaritimaInputDto.NumEscala, AddConditionNumEscala)
                .AddCondition(escalaMaritimaInputDto.Fecha, AddConditionFecha)
                .AddCondition(escalaMaritimaInputDto.ConEstado, escalaMaritimaInputDto.Estados, AddConditionEstado)
                .AddCondition(_idioma, AddConditionIdioma);

            return builder;
        }

        private static SqlBuilder AddConditionIdioma(SqlBuilder builder, string idioma)
        {
            return builder.Where("ETEOI.CODIDIOMA = :idioma", new { idioma });
        }

        private static SqlBuilder AddConditionSubPort(SqlBuilder builder, string idSubPort)
        {
            if (idSubPort == string.Empty || idSubPort == null)
            {
                idSubPort = "B";
            }
            return builder.Where("ESC.IDSUBPORT = :idSubPort", new { idSubPort });
        }

        private static SqlBuilder AddConditionAnyEscala(SqlBuilder builder, int? anyEscala)
        {
            if (anyEscala != null)
            {
                return builder.Where("ESC.ANYESCALA = :anyEscala", new { anyEscala });
            }
            return builder;
        }

        private static SqlBuilder AddConditionNumEscala(SqlBuilder builder, int? numEscala)
        {
            if (numEscala != null)
            {
                return builder.Where("ESC.NUMESCALA = :numEscala", new { numEscala });
            }
            return builder;
        }

        private static SqlBuilder AddConditionFecha(SqlBuilder builder, DateTime? fecha)
        {
            if (fecha != null)
            {
                builder.Where("ESCASP.ETA <= :fecha", new { fecha });
                builder.Where("ESCASP.ETD >= :fecha", new { fecha });
                return builder;
            }
            return builder;
        }

        private static SqlBuilder AddConditionEstado(SqlBuilder builder, bool? ConEstado, string[] Estados)
        {
            var estados = Estados.Select(y => y.ToUpperInvariant()).ToArray();

            if (ConEstado != null && Estados != null && Estados.Length > 0)
            {
                _ = (ConEstado == true) ?
                     builder.Where("ESC.IDESTOPERATIU IN :Estados", new { estados }) :
                     builder.Where("ESC.IDESTOPERATIU NOT IN :Estados", new { estados });
                return builder;
            }

            return builder;
        }

        private string BaseQuery()
        {
            return $@"SELECT XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
                                             /**where**/
                                            /**orderby**/";
        }

        public void Dispose()
        {
            //  Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}