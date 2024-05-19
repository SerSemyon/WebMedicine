using System;
using System.Collections.Generic;

namespace WebMedicine.Models;

public partial class Visit
{
    public int Id { get; set; }

    public DateOnly Date { get; set; }

    public int EmployeeId { get; set; }

    public int PatientId { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Person Patient { get; set; } = null!;
}
