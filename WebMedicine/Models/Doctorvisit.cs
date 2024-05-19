using System;
using System.Collections.Generic;

namespace WebMedicine.Models;

public partial class Doctorvisit
{
    public int Id { get; set; }

    public int PatientId { get; set; }

    public int DoctorId { get; set; }

    public DateOnly Date { get; set; }

    public string? SymptomsDescription { get; set; }

    public string? Conclusion { get; set; }

    public virtual Employee Doctor { get; set; } = null!;

    public virtual Person Patient { get; set; } = null!;

    public virtual ICollection<Treatment> Treatments { get; set; } = new List<Treatment>();
}
