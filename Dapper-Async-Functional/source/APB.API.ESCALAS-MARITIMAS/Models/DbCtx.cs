using APB.ARQ.APIBASE;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace APB.API.ESCALAS_MARITIMAS.Models
{
    public partial class DbCtx : ApbDbContext
    {
        public DbCtx()
        {
        }

        public DbCtx(DbContextOptions<DbCtx> options)
            : base(options)
        {
        }

        public virtual DbSet<ARQ_EVENT> ARQ_EVENT { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "APBDOTNET");

            modelBuilder.Entity<ARQ_EVENT>(entity =>
            {
                entity.HasKey(e => e.ARQ_EVENT_ID)
                    .HasName("ARQ_EVENT_PK");

                entity.Property(e => e.ARQ_APP_NI)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ARQ_EVENTTIPUS_NI)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ARQ_EVENT_PARE).ValueGeneratedNever();

                entity.Property(e => e.ARQ_EXPEDIENT_NI)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ARQ_USUARI_NI)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AUDIT_APP)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AUDIT_DATAOPERACIOBBDD)
                    .HasColumnType("DATE")
                    .ValueGeneratedNever();

                entity.Property(e => e.AUDIT_OPERACIOBBDD_NI)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AUDIT_USER)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.DATAEVENT)
                    .HasColumnType("DATE")
                    .ValueGeneratedNever();

                entity.Property(e => e.DESCRIPCIO)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ESBORRAT)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NO'");

                entity.HasOne(d => d.ARQ_EVENT_PARENavigation)
                    .WithMany(p => p.InverseARQ_EVENT_PARENavigation)
                    .HasForeignKey(d => d.ARQ_EVENT_PARE)
                    .HasConstraintName("ARQ_EVENT_FK5");
            });

            //modelBuilder.HasSequence("ALFRESCODOCUMENT_SEQ");

            //modelBuilder.HasSequence("ALFRESCODOCUMENT_SEQ1");

            //modelBuilder.HasSequence("ALFRESCODOCUMENT_SEQ2");

            //modelBuilder.HasSequence("ALFRESCODOCUMENT_SEQ3");

            //modelBuilder.HasSequence("ALFRESCODOCUMENT_SEQ4");

            //modelBuilder.HasSequence("ALFRESCODOCUMENTTIPUS_SEQ");

            //modelBuilder.HasSequence("APLICACIO_SEQ");

            //modelBuilder.HasSequence("APLICACIO_SEQ1");

            //modelBuilder.HasSequence("APLICACIO_SEQ2");

            //modelBuilder.HasSequence("APLICACIO_SEQ3");

            //modelBuilder.HasSequence("APLICACIOFASES_SEQ");

            //modelBuilder.HasSequence("APLICACIOFASES_SEQ1");

            //modelBuilder.HasSequence("APLICACIOFASESHISTORIC_SEQ");

            //modelBuilder.HasSequence("APLICACIOFASESHISTORIC_SEQ1");

            //modelBuilder.HasSequence("APLICACIOFASESHISTORIC_SEQ2");

            //modelBuilder.HasSequence("APP_ORDREPAGAMENT_SEQ");

            //modelBuilder.HasSequence("ARCHIVOPDF_SEQ");

            //modelBuilder.HasSequence("ARCHIVOPDF_SEQ1");

            //modelBuilder.HasSequence("ARCHIVOPDF_SEQ2");

            //modelBuilder.HasSequence("ARCHIVOPDF_SEQ3");

            //modelBuilder.HasSequence("ARCHIVOPDF_SEQ4");

            //modelBuilder.HasSequence("ARCHIVOPDF_SEQ5");

            //modelBuilder.HasSequence("ARCHIVOPDF_SEQ6");

            //modelBuilder.HasSequence("ARCHIVOPDF_SEQ7");

            //modelBuilder.HasSequence("ARQ_AGRUPACIOROL_SEQ");

            //modelBuilder.HasSequence("ARQ_API_ACCES_SEQ");

            //modelBuilder.HasSequence("ARQ_API_PERMIS_SEQ");

            //modelBuilder.HasSequence("ARQ_APP_SEQ");

            //modelBuilder.HasSequence("ARQ_APPFASES_SEQ");

            //modelBuilder.HasSequence("ARQ_APPFASESHISTORIC_SEQ");

            //modelBuilder.HasSequence("ARQ_APPFASESHISTORIC_SEQ1");

            //modelBuilder.HasSequence("ARQ_BPMACTIVITAT_SEQ");

            //modelBuilder.HasSequence("ARQ_BPMHISTORIC_SEQ");

            //modelBuilder.HasSequence("ARQ_BPMHISTORIC_SEQ1");

            //modelBuilder.HasSequence("ARQ_BPMPROCES_SEQ");

            //modelBuilder.HasSequence("ARQ_BPMPROCESDEFINICIO_SEQ");

            //modelBuilder.HasSequence("ARQ_CATPROFESSIONAL_SEQ");

            //modelBuilder.HasSequence("ARQ_COMENTARI_SEQ");

            //modelBuilder.HasSequence("ARQ_COMENTARITIPUS_SEQ");

            //modelBuilder.HasSequence("ARQ_CORREUS_SEQ");

            //modelBuilder.HasSequence("ARQ_CORREUS_SEQ1");

            //modelBuilder.HasSequence("ARQ_DOC_SEQ");

            //modelBuilder.HasSequence("ARQ_EMPRESA_SEQ");

            //modelBuilder.HasSequence("ARQ_ENTRADAMENU_SEQ");

            //modelBuilder.HasSequence("ARQ_ENTRADAMENU_SEQ1");

            //modelBuilder.HasSequence("ARQ_ENTRADAMENU_SEQ2");

            //modelBuilder.HasSequence("ARQ_ENTRADAMENUTIPUS_SEQ");

            //modelBuilder.HasSequence("ARQ_ERROR_SEQ");

            //modelBuilder.HasSequence("ARQ_ERROR_SEQ1");

            //modelBuilder.HasSequence("ARQ_ERRORMISSATGE_SEQ");

            //modelBuilder.HasSequence("ARQ_ERRORMISSATGE_SEQ1");

            //modelBuilder.HasSequence("ARQ_ERRORMISSATGE_SEQ2");

            //modelBuilder.HasSequence("ARQ_ERRORNIVEL_SEQ");

            //modelBuilder.HasSequence("ARQ_ERRORTIPUS_SEQ");

            //modelBuilder.HasSequence("ARQ_EVENT_SEQ");

            //modelBuilder.HasSequence("ARQ_EVENTTIPUS_SEQ");

            //modelBuilder.HasSequence("ARQ_EVENTTIPUS_SEQ1");

            //modelBuilder.HasSequence("ARQ_EXPEDIENT_SEQ");

            //modelBuilder.HasSequence("ARQ_EXPEDIENTESTAT_SEQ");

            //modelBuilder.HasSequence("ARQ_EXPEDIENTESTATHISTORIC_SEQ");

            //modelBuilder.HasSequence("ARQ_EXPEDIENTTIPUS_SEQ");

            //modelBuilder.HasSequence("ARQ_GRIDCONFIG_SEQ");

            //modelBuilder.HasSequence("ARQ_IDIOMA_SEQ");

            //modelBuilder.HasSequence("ARQ_JERARQUIA_SEQ");

            //modelBuilder.HasSequence("ARQ_JERARQUIATIPUS_SEQ");

            //modelBuilder.HasSequence("ARQ_LOG_CLAVE_SEQ");

            //modelBuilder.HasSequence("ARQ_LOG_SEQ");

            //modelBuilder.HasSequence("ARQ_MISSATGETIPUS_SEQ");

            //modelBuilder.HasSequence("ARQ_OPERACIOBBDD_SEQ");

            //modelBuilder.HasSequence("ARQ_PAIS_SEQ");

            //modelBuilder.HasSequence("ARQ_PARAMETRECONSTANT_SEQ");

            //modelBuilder.HasSequence("ARQ_PERMIS_SEQ");

            //modelBuilder.HasSequence("ARQ_PTF_SEQ");

            //modelBuilder.HasSequence("ARQ_PTFESTAT_SEQ");

            //modelBuilder.HasSequence("ARQ_PTFESTATHISTORIC_SEQ");

            //modelBuilder.HasSequence("ARQ_ROL_AGRUPACIOROL_SEQ");

            //modelBuilder.HasSequence("ARQ_ROL_SEQ");

            //modelBuilder.HasSequence("ARQ_TIPOZONA_SEQ");

            //modelBuilder.HasSequence("ARQ_USUARI_SEQ");

            //modelBuilder.HasSequence("ARQ_USUARI2_SEQ");

            //modelBuilder.HasSequence("ARQ_USUARIESTAT_SEQ");

            //modelBuilder.HasSequence("ARQ_USUARIGRUP_SEQ");

            //modelBuilder.HasSequence("ARQ_ZONA_SEQ");

            //modelBuilder.HasSequence("ARQ_ZONA_SEQ1");

            //modelBuilder.HasSequence("AUDITORIABBDD_SEQ");

            //modelBuilder.HasSequence("BPMACTIVITAT_EXPED_HISTORIC_S");

            //modelBuilder.HasSequence("BPMACTIVITAT_SEQ");

            //modelBuilder.HasSequence("BPMACTIVITAT_SEQ1");

            //modelBuilder.HasSequence("BPMACTIVITAT_SEQ2");

            //modelBuilder.HasSequence("BPMACTIVITAT_SEQ3");

            //modelBuilder.HasSequence("BPMPROCES_SEQ");

            //modelBuilder.HasSequence("BPMPROCES_SEQ1");

            //modelBuilder.HasSequence("BPMPROCES_SEQ2");

            //modelBuilder.HasSequence("BPMPROCES_SEQ3");

            //modelBuilder.HasSequence("BPMPROCESDEFINICIO_SEQ");

            //modelBuilder.HasSequence("CATEGORIAPROFESSIONAL_SEQ");

            //modelBuilder.HasSequence("CATEGORIAPROFESSIONAL_SEQ1");

            //modelBuilder.HasSequence("CATEGORIAPROFESSIONAL_SEQ2");

            //modelBuilder.HasSequence("CATEGORIAPROFESSIONAL_SEQ3");

            //modelBuilder.HasSequence("CATEGORIAPROFESSIONAL_SEQ4");

            //modelBuilder.HasSequence("CATEGORIAPROFESSIONAL_SEQ5");

            //modelBuilder.HasSequence("COMENTARI_SEQ");

            //modelBuilder.HasSequence("COMENTARI_SEQ1");

            //modelBuilder.HasSequence("COMENTARI_SEQ2");

            //modelBuilder.HasSequence("COMENTARI_SEQ3");

            //modelBuilder.HasSequence("COMENTARI_SEQ4");

            //modelBuilder.HasSequence("COMENTARI_SEQ5");

            //modelBuilder.HasSequence("COMENTARI_SEQ6");

            //modelBuilder.HasSequence("COMENTARI_SEQ7");

            //modelBuilder.HasSequence("COMENTARI_SEQ8");

            //modelBuilder.HasSequence("COMENTARITIPUS_SEQ");

            //modelBuilder.HasSequence("COMENTARITIPUS_SEQ1");

            //modelBuilder.HasSequence("COMENTARITIPUS_SEQ2");

            //modelBuilder.HasSequence("DELEGAT_SEQ");

            //modelBuilder.HasSequence("DEMO_CUST_SEQ");

            //modelBuilder.HasSequence("DEMO_ORD_SEQ");

            //modelBuilder.HasSequence("DEMO_ORDER_ITEMS_SEQ");

            //modelBuilder.HasSequence("DEMO_PROD_SEQ");

            //modelBuilder.HasSequence("DEMO_USERS_SEQ");

            //modelBuilder.HasSequence("DOCUMENTOSHTML_SEQ");

            //modelBuilder.HasSequence("DOCUMENTOSHTML_SEQ1");

            //modelBuilder.HasSequence("DOCUMENTOSHTML_SEQ2");

            //modelBuilder.HasSequence("DOCUMENTOSHTML_SEQ3");

            //modelBuilder.HasSequence("DOCUMENTOSHTML_SEQ4");

            //modelBuilder.HasSequence("DOCUMENTOSHTML_SEQ5");

            //modelBuilder.HasSequence("DOCUMENTOSREGDOCUMENTACION_SE");

            //modelBuilder.HasSequence("DOCUMENTOSREGDOCUMENTACION_SEQ");

            //modelBuilder.HasSequence("ENTRADAMENU_SEQ");

            //modelBuilder.HasSequence("ENTRADAMENU_SEQ1");

            //modelBuilder.HasSequence("ENTRADAMENU_SEQ2");

            //modelBuilder.HasSequence("ENTRADAMENU_SEQ3");

            //modelBuilder.HasSequence("ENTRADAMENU_SEQ4");

            //modelBuilder.HasSequence("ENTRADAMENU_SEQ5");

            //modelBuilder.HasSequence("ENTRADAMENU_SEQ6");

            //modelBuilder.HasSequence("ENTRADAMENUTIPUS_SEQ");

            //modelBuilder.HasSequence("ENTRADAMENUTIPUS_SEQ1");

            //modelBuilder.HasSequence("ENTRADAMENUTIPUS_SEQ2");

            //modelBuilder.HasSequence("ENTRADAMENUTIPUS_SEQ3");

            //modelBuilder.HasSequence("ERROR_TIPUS_SEQ");

            //modelBuilder.HasSequence("ERROR_TIPUS_SEQ1");

            //modelBuilder.HasSequence("ERRORLOG_SEQ");

            //modelBuilder.HasSequence("ERRORLOG_SEQ1");

            //modelBuilder.HasSequence("ERRORLOG_SEQ2");

            //modelBuilder.HasSequence("ERRORLOG_SEQ3");

            //modelBuilder.HasSequence("ERRORLOG_SEQ4");

            //modelBuilder.HasSequence("ERRORLOG_SEQ5");

            //modelBuilder.HasSequence("ERRORMISSATGE_SEQ");

            //modelBuilder.HasSequence("ERRORNIVEL_SEQ");

            //modelBuilder.HasSequence("ERRORPARAMETRETIPUS_SEQ");

            //modelBuilder.HasSequence("EVENT_SEQ");

            //modelBuilder.HasSequence("EVENT_SEQ1");

            //modelBuilder.HasSequence("EVENT_SEQ2");

            //modelBuilder.HasSequence("EVENT_SEQ3");

            //modelBuilder.HasSequence("EVENT_SEQ4");

            //modelBuilder.HasSequence("EVENT_SEQ5");

            //modelBuilder.HasSequence("EXPEDIENT_SEQ");

            //modelBuilder.HasSequence("EXPEDIENT_SEQ1");

            //modelBuilder.HasSequence("EXPEDIENT_SEQ2");

            //modelBuilder.HasSequence("EXPEDIENTESTAT_SEQ");

            //modelBuilder.HasSequence("EXPEDIENTESTAT_SEQ1");

            //modelBuilder.HasSequence("EXPEDIENTESTATHISTORIC_SEQ");

            //modelBuilder.HasSequence("EXPEDIENTESTATHISTORIC_SEQ1");

            //modelBuilder.HasSequence("EXPEDIENTESTATHISTORIC_SEQ2");

            //modelBuilder.HasSequence("HOLIDAYLOCATIONS_SEQ");

            //modelBuilder.HasSequence("IDIOMA_SEQ");

            //modelBuilder.HasSequence("JERARQUIA_SEQ");

            //modelBuilder.HasSequence("JERARQUIA_SEQ1");

            //modelBuilder.HasSequence("JERARQUIA_SEQ2");

            //modelBuilder.HasSequence("JERARQUIA_SEQ3");

            //modelBuilder.HasSequence("MISSATGE_SEQ");

            //modelBuilder.HasSequence("MISSATGE_SEQ1");

            //modelBuilder.HasSequence("MISSATGETIPUS_SEQ");

            //modelBuilder.HasSequence("ORDPAG_ALFRESCODOCUMENTTIPUS_");

            //modelBuilder.HasSequence("ORDREPAGAMENT_SEQ");

            //modelBuilder.HasSequence("ORDREPAGAMENTALFRESCODOCUMENT1");

            //modelBuilder.HasSequence("ORDREPAGAMENTALFRESCODOCUMENT2");

            //modelBuilder.HasSequence("ORDREPAGAMENTTIPUSPAGAMENT_SE");

            //modelBuilder.HasSequence("ORDREPAGAMENTTIPUSPAGAMENT_SEQ");

            //modelBuilder.HasSequence("PAIS_SEQ");

            //modelBuilder.HasSequence("PAIS_SEQ1");

            //modelBuilder.HasSequence("PARAMETRE_SEQ");

            //modelBuilder.HasSequence("PARAMETRE_SEQ1");

            //modelBuilder.HasSequence("PARAMETRECONSTANT_SEQ");

            //modelBuilder.HasSequence("PARAMETRECONSTANT_SEQ1");

            //modelBuilder.HasSequence("PARAMETRECONSTANT_SEQ2");

            //modelBuilder.HasSequence("PERFILCONTRACTANT_SEQ");

            //modelBuilder.HasSequence("PERFILCONTRATANTEFINALIZADAS_");

            //modelBuilder.HasSequence("PERMIS_SEQ");

            //modelBuilder.HasSequence("PERMIS_SEQ1");

            //modelBuilder.HasSequence("PERMIS_SEQ2");

            //modelBuilder.HasSequence("PERMIS_SEQ3");

            //modelBuilder.HasSequence("PERMIS_SEQ4");

            //modelBuilder.HasSequence("PERMIS_SEQ5");

            //modelBuilder.HasSequence("PERMIS_SEQ6");

            //modelBuilder.HasSequence("PERMIS_SEQ7");

            //modelBuilder.HasSequence("PORTAFIRMA_SEQ");

            //modelBuilder.HasSequence("PORTAFIRMA_SEQ1");

            //modelBuilder.HasSequence("PORTAFIRMA_SEQ2");

            //modelBuilder.HasSequence("PORTAFIRMA_SEQ3");

            //modelBuilder.HasSequence("PORTAFIRMAESTAT_SEQ");

            //modelBuilder.HasSequence("PORTAFIRMAESTAT_SEQ1");

            //modelBuilder.HasSequence("PORTAFIRMAESTAT_SEQ2");

            //modelBuilder.HasSequence("PORTAFIRMAESTATHISTORIC_SEQ");

            //modelBuilder.HasSequence("PORTAFIRMAESTATHISTORIC_SEQ1");

            //modelBuilder.HasSequence("PORTALAPLICACIONES_SEQ");

            //modelBuilder.HasSequence("PORTALAPLICACIONES_SEQ1");

            //modelBuilder.HasSequence("PORTALAPLICACIONES_SEQ2");

            //modelBuilder.HasSequence("PORTALPAGINAS_SEQ");

            //modelBuilder.HasSequence("PORTALPAGINAS_SEQ1");

            //modelBuilder.HasSequence("PORTALPAGINAS_SEQ2");

            //modelBuilder.HasSequence("PORTALROLES_SEQ");

            //modelBuilder.HasSequence("PREGUNTASTECNICAS_SEQ");

            //modelBuilder.HasSequence("PREGUNTASTECNICAS_SEQ1");

            //modelBuilder.HasSequence("PRUEBASDESARROLLO_SEQ");

            //modelBuilder.HasSequence("QUEJASUGERENCIA_SEQ");

            //modelBuilder.HasSequence("QUEJASUGERENCIA_SEQ1");

            //modelBuilder.HasSequence("QUEJASUGERENCIA_SEQ2");

            //modelBuilder.HasSequence("REGISTRODOCUMENTACION_SEQ");

            //modelBuilder.HasSequence("REPRESENTANT_SEQ");

            //modelBuilder.HasSequence("ROLS_SEQ");

            //modelBuilder.HasSequence("ROLS_SEQ1");

            //modelBuilder.HasSequence("ROLS_SEQ2");

            //modelBuilder.HasSequence("SECCIONESHTML_SEQ");

            //modelBuilder.HasSequence("SECCIONESHTML_SEQ1");

            //modelBuilder.HasSequence("SECCIONESHTML_SEQ2");

            //modelBuilder.HasSequence("SECCIONESHTML_SEQ3");

            //modelBuilder.HasSequence("SEQ_EVENT");

            //modelBuilder.HasSequence("TIPOSPUBLICACIONHTML_SEQ");

            //modelBuilder.HasSequence("TIPUSEVENT_SEQ");

            //modelBuilder.HasSequence("TIPUSEVENT_SEQ1");

            //modelBuilder.HasSequence("TIPUSEVENT_SEQ2");

            //modelBuilder.HasSequence("TIPUSEVENT_SEQ3");

            //modelBuilder.HasSequence("TIPUSUNITATORGANIZATIVA_SEQ");

            //modelBuilder.HasSequence("TIPUSUNITATORGANIZATIVA_SEQ1");

            //modelBuilder.HasSequence("UNITATORGANIZATIVA_SEQ");

            //modelBuilder.HasSequence("UNITATORGANIZATIVA_SEQ1");

            //modelBuilder.HasSequence("UNITATORGANIZATIVA_SEQ2");

            //modelBuilder.HasSequence("UNITATORGANIZATIVA_SEQ3");

            //modelBuilder.HasSequence("UNITATORGANIZATIVA_SEQ4");

            //modelBuilder.HasSequence("UNITATORGANIZATIVA_SEQ5");

            //modelBuilder.HasSequence("UNITATORGANIZATIVA_SEQ6");

            //modelBuilder.HasSequence("USUARI_ESTAT_SEQ");

            //modelBuilder.HasSequence("USUARI_SEQ");

            //modelBuilder.HasSequence("USUARI_SEQ1");

            //modelBuilder.HasSequence("USUARI_SEQ10");

            //modelBuilder.HasSequence("USUARI_SEQ11");

            //modelBuilder.HasSequence("USUARI_SEQ2");

            //modelBuilder.HasSequence("USUARI_SEQ3");

            //modelBuilder.HasSequence("USUARI_SEQ4");

            //modelBuilder.HasSequence("USUARI_SEQ5");

            //modelBuilder.HasSequence("USUARI_SEQ6");

            //modelBuilder.HasSequence("USUARI_SEQ7");

            //modelBuilder.HasSequence("USUARI_SEQ8");

            //modelBuilder.HasSequence("USUARI_SEQ9");

            //modelBuilder.HasSequence("USUARIGRUP_SEQ");

            //modelBuilder.HasSequence("USUARIGRUP_SEQ1");

            //modelBuilder.HasSequence("USUARIO_SEQ");

            //modelBuilder.HasSequence("USUARIO_SEQ1");

            //modelBuilder.HasSequence("USUARIO_SEQ2");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
