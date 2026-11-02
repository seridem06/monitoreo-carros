using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MonitoreoCarros.Infrastructure.Persistence.Models;

[Table("marcaciones")]
[Index("IdRecorrido", "IdPunto", Name = "marcaciones_id_recorrido_id_punto_key", IsUnique = true)]
public partial class Marcacione
{
    [Key]
    [Column("id_marcacion")]
    public int IdMarcacion { get; set; }

    [Column("id_recorrido")]
    public int IdRecorrido { get; set; }

    [Column("id_punto")]
    public int IdPunto { get; set; }

    [Column("hora_programada")]
    public TimeOnly HoraProgramada { get; set; }

    [Column("hora_real")]
    public TimeOnly? HoraReal { get; set; }

    [Column("retraso_min")]
    public int? RetrasoMin { get; set; }

    [ForeignKey("IdPunto")]
    [InverseProperty("Marcaciones")]
    public virtual Punto IdPuntoNavigation { get; set; } = null!;

    [ForeignKey("IdRecorrido")]
    [InverseProperty("Marcaciones")]
    public virtual Recorrido IdRecorridoNavigation { get; set; } = null!;
}
