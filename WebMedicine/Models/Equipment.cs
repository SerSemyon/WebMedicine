using System;
using System.Collections.Generic;

namespace WebMedicine.Models;

public partial class Equipment
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual ICollection<Inventoryresult> Inventoryresults { get; set; } = new List<Inventoryresult>();
}
