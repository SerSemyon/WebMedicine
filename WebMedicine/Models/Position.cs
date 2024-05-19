using System;
using System.Collections.Generic;

namespace WebMedicine.Models;

public partial class Position
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public decimal Rate { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
