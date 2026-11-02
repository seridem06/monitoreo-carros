using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MonitoreoCarros.Infrastructure.Persistence.Models;

[Table("vehiculos")]
[Index("Codigo", Name = "vehiculos_codigo_key", IsUnique = true)]
[Index("Placa", Name = "vehiculos_placa_key", IsUnique = true)]
public partial class Vehiculo
{
    [Key]
    [Column("id_vehiculo")]
    public int IdVehiculo { get; set; }

    [Column("placa")]
    [StringLength(10)]
    public string Placa { get; set; } = null!;

    [Column("codigo")]
    [StringLength(10)]
    public string Codigo { get; set; } = null!;

    [Column("propietario")]
    [StringLength(100)]
    public string? Propietario { get; set; }

    [Column("activo")]
    public bool Activo { get; set; }

    [InverseProperty("IdVehiculoCobraNavigation")]
    public virtual ICollection<Liquidacione> LiquidacioneIdVehiculoCobraNavigations { get; set; } = new List<Liquidacione>();

    [InverseProperty("IdVehiculoPagaNavigation")]
    public virtual ICollection<Liquidacione> LiquidacioneIdVehiculoPagaNavigations { get; set; } = new List<Liquidacione>();

    [InverseProperty("IdVehiculoNavigation")]
    public virtual ICollection<Recorrido> Recorridos { get; set; } = new List<Recorrido>();
}
