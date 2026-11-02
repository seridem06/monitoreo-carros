using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MonitoreoCarros.Infrastructure.Persistence.Models;

[Table("recorridos")]
[Index("Fecha", "IdRuta", Name = "ix_recorridos_fecha_ruta")]
[Index("NumeroPlanilla", Name = "recorridos_numero_planilla_key", IsUnique = true)]
public partial class Recorrido
{
    [Key]
    [Column("id_recorrido")]
    public int IdRecorrido { get; set; }

    [Column("numero_planilla")]
    public int NumeroPlanilla { get; set; }

    [Column("fecha")]
    public DateOnly Fecha { get; set; }

    [Column("id_ruta")]
    public int IdRuta { get; set; }

    [Column("id_vehiculo")]
    public int IdVehiculo { get; set; }

    [Column("hora_salida")]
    public TimeOnly HoraSalida { get; set; }

    [Column("estado")]
    [StringLength(15)]
    public string Estado { get; set; } = null!;

    [Column("origen")]
    [StringLength(20)]
    public string Origen { get; set; } = null!;

    [ForeignKey("IdRuta")]
    [InverseProperty("Recorridos")]
    public virtual Ruta IdRutaNavigation { get; set; } = null!;

    [ForeignKey("IdVehiculo")]
    [InverseProperty("Recorridos")]
    public virtual Vehiculo IdVehiculoNavigation { get; set; } = null!;

    [InverseProperty("IdRecorridoNavigation")]
    public virtual ICollection<Marcacione> Marcaciones { get; set; } = new List<Marcacione>();
}
