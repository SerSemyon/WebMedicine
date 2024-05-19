using System;
using System.Collections.Generic;

namespace WebMedicine.Models;

public partial class Medicationcatalog
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Dosage { get; set; } = null!;

    public string Manufacturer { get; set; } = null!;

    public virtual ICollection<Medicationprescription> Medicationprescriptions { get; set; } = new List<Medicationprescription>();
}
