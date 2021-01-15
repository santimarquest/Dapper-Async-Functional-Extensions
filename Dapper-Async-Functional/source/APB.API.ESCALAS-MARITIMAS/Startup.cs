using APB.API.ESCALAS_MARITIMAS.Models;
using APB.ARQ.APIBASE;
using AutoMapper;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;

namespace APB.API.ESCALAS_MARITIMAS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
                    //.AllowCredentials();
                });
            });

            // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
            // note: the specified format code will format the version as "'v'major[.minor][-status]"
            services.AddApiVersioning(options =>
            {
                // reporting api versions will return the headers "api-supported-versions" and "api-deprecated-versions"
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
            });
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen();
            services.AddHealthChecks().AddCheck<ApbHealthCheck>("buildcheck", null, new string[] { "build" })
                .AddCheck("dbconnection", () =>
                {
                    using (var con = new OracleConnection(Configuration.GetConnectionString("ArqDB")))
                    {
                        try
                        {
                            con.Open();
                        }
                        catch
                        {
                            return HealthCheckResult.Unhealthy("Sin conexion a BBDD");
                        }
                    }
                    return HealthCheckResult.Healthy("Conexión a BBDD funciona.");
                }, new string[] { "database", "oracle" });
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                //options.RequireHttpsMetadata = false;
                //options.SaveToken = true;
                var envName = Configuration.GetValue<string>("SRV_PRO").Contains(Dns.GetHostName() + "|", StringComparison.InvariantCultureIgnoreCase) ? string.Empty : Configuration.GetValue<string>("SRV_PRE").Contains(Dns.GetHostName() + "|", StringComparison.InvariantCultureIgnoreCase) ? "pre" : "des";
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "https://tgt" + envName + ".portdebarcelona.cat",
                    ValidAudience = "https://api" + envName + ".portdebarcelona.cat",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<string>("Firma")))
                };
            });
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });
            services.AddVersionedApiExplorer(o =>
            {
                o.GroupNameFormat = "'v'VVV";
                o.SubstituteApiVersionInUrl = true;
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddDbContext<DbCtx>(options => options.UseOracle(Configuration.GetConnectionString("ArqDB")));
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                var dateConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter
                {
                    DateTimeFormat = "yyyy'/'MM'/'dd'T'HH':'mm"
                };

                options.SerializerSettings.Converters.Add(dateConverter);
                options.SerializerSettings.Culture = CultureInfo.CurrentCulture;
                options.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(options =>
            {
                foreach (var desc in provider.ApiVersionDescriptions)
                    options.SwaggerEndpoint($"./swagger/{desc.GroupName}/swagger.json",
                        desc.GroupName.ToUpperInvariant());
                options.RoutePrefix = string.Empty; //To serve from root
                options.DisplayOperationId();
                options.DisplayRequestDuration();
            });
            app.UseRouting();
            app.UseCors("EnableCORS");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseApbHealthChecks();
            app.UseApbApiLogging();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}