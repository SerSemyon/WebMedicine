using System;
using System.Collections.Generic;

namespace WebMedicine.Models;

public partial class Schedule
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public int StructureId { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Structure Structure { get; set; } = null!;
}
