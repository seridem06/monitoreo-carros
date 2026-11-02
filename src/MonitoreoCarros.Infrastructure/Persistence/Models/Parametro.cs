using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MonitoreoCarros.Infrastructure.Persistence.Models;

[Table("parametros")]
public partial class Parametro
{
    [Key]
    [Column("clave")]
    [StringLength(50)]
    public string Clave { get; set; } = null!;

    [Column("valor")]
    [StringLength(100)]
    public string Valor { get; set; } = null!;

    [Column("descripcion")]
    [StringLength(200)]
    public string? Descripcion { get; set; }
}
