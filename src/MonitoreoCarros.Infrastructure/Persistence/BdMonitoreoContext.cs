using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MonitoreoCarros.Infrastructure.Persistence.Models;

namespace MonitoreoCarros.Infrastructure.Persistence;

public partial class BdMonitoreoContext : DbContext
{
    public BdMonitoreoContext(DbContextOptions<BdMonitoreoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Frecuencia> Frecuencias { get; set; }

    public virtual DbSet<Liquidacione> Liquidaciones { get; set; }

    public virtual DbSet<Marcacione> Marcaciones { get; set; }

    public virtual DbSet<Parametro> Parametros { get; set; }

    public virtual DbSet<Punto> Puntos { get; set; }

    public virtual DbSet<Recorrido> Recorridos { get; set; }

    public virtual DbSet<Ruta> Rutas { get; set; }

    public virtual DbSet<ToleranciasTemporale> ToleranciasTemporales { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Frecuencia>(entity =>
        {
            entity.HasKey(e => e.IdFrecuencia).HasName("frecuencias_pkey");

            entity.HasOne(d => d.IdRutaNavigation).WithMany(p => p.Frecuencia).HasConstraintName("frecuencias_id_ruta_fkey");
        });

        modelBuilder.Entity<Liquidacione>(entity =>
        {
            entity.HasKey(e => e.IdLiquidacion).HasName("liquidaciones_pkey");

            entity.Property(e => e.GeneradoEn).HasDefaultValueSql("now()");

            entity.HasOne(d => d.IdPuntoNavigation).WithMany(p => p.Liquidaciones)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("liquidaciones_id_punto_fkey");

            entity.HasOne(d => d.IdVehiculoCobraNavigation).WithMany(p => p.LiquidacioneIdVehiculoCobraNavigations).HasConstraintName("liquidaciones_id_vehiculo_cobra_fkey");

            entity.HasOne(d => d.IdVehiculoPagaNavigation).WithMany(p => p.LiquidacioneIdVehiculoPagaNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("liquidaciones_id_vehiculo_paga_fkey");
        });

        modelBuilder.Entity<Marcacione>(entity =>
        {
            entity.HasKey(e => e.IdMarcacion).HasName("marcaciones_pkey");

            entity.HasOne(d => d.IdPuntoNavigation).WithMany(p => p.Marcaciones)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("marcaciones_id_punto_fkey");

            entity.HasOne(d => d.IdRecorridoNavigation).WithMany(p => p.Marcaciones).HasConstraintName("marcaciones_id_recorrido_fkey");
        });

        modelBuilder.Entity<Parametro>(entity =>
        {
            entity.HasKey(e => e.Clave).HasName("parametros_pkey");
        });

        modelBuilder.Entity<Punto>(entity =>
        {
            entity.HasKey(e => e.IdPunto).HasName("puntos_pkey");

            entity.Property(e => e.AdelantoMaximo).HasDefaultValue(3);
            entity.Property(e => e.TamanoGrupo).HasDefaultValue(2);

            entity.HasOne(d => d.IdRutaNavigation).WithMany(p => p.Puntos).HasConstraintName("puntos_id_ruta_fkey");
        });

        modelBuilder.Entity<Recorrido>(entity =>
        {
            entity.HasKey(e => e.IdRecorrido).HasName("recorridos_pkey");

            entity.Property(e => e.Estado).HasDefaultValueSql("'Programado'::character varying");
            entity.Property(e => e.Origen).HasDefaultValueSql("'Manual'::character varying");

            entity.HasOne(d => d.IdRutaNavigation).WithMany(p => p.Recorridos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("recorridos_id_ruta_fkey");

            entity.HasOne(d => d.IdVehiculoNavigation).WithMany(p => p.Recorridos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("recorridos_id_vehiculo_fkey");
        });

        modelBuilder.Entity<Ruta>(entity =>
        {
            entity.HasKey(e => e.IdRuta).HasName("rutas_pkey");

            entity.Property(e => e.Color).HasDefaultValueSql("'#0d6efd'::character varying");
            entity.Property(e => e.OperaDomingos).HasDefaultValue(true);
            entity.Property(e => e.OperaFeriados).HasDefaultValue(true);
        });

        modelBuilder.Entity<ToleranciasTemporale>(entity =>
        {
            entity.HasKey(e => e.IdTolerancia).HasName("tolerancias_temporales_pkey");

            entity.HasOne(d => d.IdPuntoNavigation).WithMany(p => p.ToleranciasTemporales).HasConstraintName("tolerancias_temporales_id_punto_fkey");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.IdVehiculo).HasName("vehiculos_pkey");

            entity.Property(e => e.Activo).HasDefaultValue(true);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
