using System;
using System.Collections.Generic;

namespace WebMedicine.Models;

public partial class Patientfeature
{
    public int Id { get; set; }

    public int PatientId { get; set; }

    public string FeaturesDescription { get; set; } = null!;

    public virtual Person Patient { get; set; } = null!;
}
