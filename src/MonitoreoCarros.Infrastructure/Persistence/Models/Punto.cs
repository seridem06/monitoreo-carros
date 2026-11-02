using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MonitoreoCarros.Infrastructure.Persistence.Models;

[Table("puntos")]
[Index("IdRuta", "Orden", Name = "puntos_id_ruta_orden_key", IsUnique = true)]
public partial class Punto
{
    [Key]
    [Column("id_punto")]
    public int IdPunto { get; set; }

    [Column("id_ruta")]
    public int IdRuta { get; set; }

    [Column("orden")]
    public int Orden { get; set; }

    [Column("nombre")]
    [StringLength(40)]
    public string Nombre { get; set; } = null!;

    [Column("distancia_km")]
    [Precision(6, 2)]
    public decimal DistanciaKm { get; set; }

    [Column("minutos_desde_salida")]
    public int MinutosDesdeSalida { get; set; }

    [Column("tolerancia")]
    public int Tolerancia { get; set; }

    [Column("adelanto_maximo")]
    public int AdelantoMaximo { get; set; }

    [Column("tamano_grupo")]
    public int TamanoGrupo { get; set; }

    [Column("monto_fijo")]
    [Precision(6, 2)]
    public decimal? MontoFijo { get; set; }

    [Column("latitud")]
    [Precision(9, 6)]
    public decimal Latitud { get; set; }

    [Column("longitud")]
    [Precision(9, 6)]
    public decimal Longitud { get; set; }

    [Column("referencial")]
    public bool Referencial { get; set; }

    [ForeignKey("IdRuta")]
    [InverseProperty("Puntos")]
    public virtual Ruta IdRutaNavigation { get; set; } = null!;

    [InverseProperty("IdPuntoNavigation")]
    public virtual ICollection<Liquidacione> Liquidaciones { get; set; } = new List<Liquidacione>();

    [InverseProperty("IdPuntoNavigation")]
    public virtual ICollection<Marcacione> Marcaciones { get; set; } = new List<Marcacione>();

    [InverseProperty("IdPuntoNavigation")]
    public virtual ICollection<ToleranciasTemporale> ToleranciasTemporales { get; set; } = new List<ToleranciasTemporale>();
}
