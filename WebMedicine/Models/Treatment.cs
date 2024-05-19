using System;
using System.Collections.Generic;

namespace WebMedicine.Models;

public partial class Treatment
{
    public int Id { get; set; }

    public int? EventId { get; set; }

    public int DoctorId { get; set; }

    public DateOnly PrescriptionDate { get; set; }

    public virtual Employee Doctor { get; set; } = null!;

    public virtual Doctorvisit? Event { get; set; }

    public virtual ICollection<Medicationprescription> Medicationprescriptions { get; set; } = new List<Medicationprescription>();
}
