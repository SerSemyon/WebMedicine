using System;
using System.Collections.Generic;

namespace WebMedicine.Models;

public partial class Inventory
{
    public int Id { get; set; }

    public DateOnly Date { get; set; }

    public int EquipmentId { get; set; }

    public int StructureId { get; set; }

    public virtual Equipment Equipment { get; set; } = null!;

    public virtual ICollection<Inventoryresult> Inventoryresults { get; set; } = new List<Inventoryresult>();

    public virtual Structure Structure { get; set; } = null!;
}
