using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MonitoreoCarros.Infrastructure.Persistence.Models;

[Table("rutas")]
[Index("Nombre", Name = "rutas_nombre_key", IsUnique = true)]
public partial class Ruta
{
    [Key]
    [Column("id_ruta")]
    public int IdRuta { get; set; }

    [Column("nombre")]
    [StringLength(40)]
    public string Nombre { get; set; } = null!;

    [Column("descripcion")]
    [StringLength(200)]
    public string? Descripcion { get; set; }

    [Column("color")]
    [StringLength(9)]
    public string Color { get; set; } = null!;

    [Column("opera_domingos")]
    public bool OperaDomingos { get; set; }

    [Column("opera_feriados")]
    public bool OperaFeriados { get; set; }

    [InverseProperty("IdRutaNavigation")]
    public virtual ICollection<Frecuencia> Frecuencia { get; set; } = new List<Frecuencia>();

    [InverseProperty("IdRutaNavigation")]
    public virtual ICollection<Punto> Puntos { get; set; } = new List<Punto>();

    [InverseProperty("IdRutaNavigation")]
    public virtual ICollection<Recorrido> Recorridos { get; set; } = new List<Recorrido>();
}
