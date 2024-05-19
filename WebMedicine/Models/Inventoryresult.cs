using System;
using System.Collections.Generic;

namespace WebMedicine.Models;

public partial class Inventoryresult
{
    public int Id { get; set; }

    public int InventoryId { get; set; }

    public int EquipmentId { get; set; }

    public bool EquipmentPresence { get; set; }

    public string? Description { get; set; }

    public virtual Equipment Equipment { get; set; } = null!;

    public virtual Inventory Inventory { get; set; } = null!;
}
