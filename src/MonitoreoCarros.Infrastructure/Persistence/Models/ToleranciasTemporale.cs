using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MonitoreoCarros.Infrastructure.Persistence.Models;

[Table("tolerancias_temporales")]
public partial class ToleranciasTemporale
{
    [Key]
    [Column("id_tolerancia")]
    public int IdTolerancia { get; set; }

    [Column("id_punto")]
    public int IdPunto { get; set; }

    [Column("fecha")]
    public DateOnly Fecha { get; set; }

    [Column("hora_desde")]
    public TimeOnly HoraDesde { get; set; }

    [Column("hora_hasta")]
    public TimeOnly? HoraHasta { get; set; }

    [Column("tolerancia")]
    public int Tolerancia { get; set; }

    [Column("motivo")]
    [StringLength(150)]
    public string Motivo { get; set; } = null!;

    [ForeignKey("IdPunto")]
    [InverseProperty("ToleranciasTemporales")]
    public virtual Punto IdPuntoNavigation { get; set; } = null!;
}
