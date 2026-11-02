using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MonitoreoCarros.Infrastructure.Persistence.Models;

[Table("frecuencias")]
public partial class Frecuencia
{
    [Key]
    [Column("id_frecuencia")]
    public int IdFrecuencia { get; set; }

    [Column("id_ruta")]
    public int IdRuta { get; set; }

    [Column("hora_inicio")]
    public TimeOnly HoraInicio { get; set; }

    [Column("hora_fin")]
    public TimeOnly HoraFin { get; set; }

    [Column("intervalo_min")]
    public int IntervaloMin { get; set; }

    [ForeignKey("IdRuta")]
    [InverseProperty("Frecuencia")]
    public virtual Ruta IdRutaNavigation { get; set; } = null!;
}
