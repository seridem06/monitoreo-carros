using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MonitoreoCarros.Infrastructure.Persistence.Models;

[Table("liquidaciones")]
[Index("Fecha", Name = "ix_liquidaciones_fecha")]
public partial class Liquidacione
{
    [Key]
    [Column("id_liquidacion")]
    public int IdLiquidacion { get; set; }

    [Column("fecha")]
    public DateOnly Fecha { get; set; }

    [Column("id_punto")]
    public int IdPunto { get; set; }

    [Column("id_vehiculo_paga")]
    public int IdVehiculoPaga { get; set; }

    [Column("id_vehiculo_cobra")]
    public int? IdVehiculoCobra { get; set; }

    [Column("minutos")]
    public int Minutos { get; set; }

    [Column("monto")]
    [Precision(8, 2)]
    public decimal Monto { get; set; }

    [Column("concepto")]
    [StringLength(100)]
    public string Concepto { get; set; } = null!;

    [Column("generado_en", TypeName = "timestamp without time zone")]
    public DateTime GeneradoEn { get; set; }

    [ForeignKey("IdPunto")]
    [InverseProperty("Liquidaciones")]
    public virtual Punto IdPuntoNavigation { get; set; } = null!;

    [ForeignKey("IdVehiculoCobra")]
    [InverseProperty("LiquidacioneIdVehiculoCobraNavigations")]
    public virtual Vehiculo? IdVehiculoCobraNavigation { get; set; }

    [ForeignKey("IdVehiculoPaga")]
    [InverseProperty("LiquidacioneIdVehiculoPagaNavigations")]
    public virtual Vehiculo IdVehiculoPagaNavigation { get; set; } = null!;
}
