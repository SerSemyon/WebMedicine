using System;
using System.Collections.Generic;

namespace WebMedicine.Models;

public partial class Medicationprescription
{
    public int Id { get; set; }

    public int MedicationId { get; set; }

    public int TreatmentId { get; set; }

    public DateOnly Duration { get; set; }

    public virtual Medicationcatalog Medication { get; set; } = null!;

    public virtual Treatment Treatment { get; set; } = null!;
}
