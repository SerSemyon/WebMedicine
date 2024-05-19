using System;
using System.Collections.Generic;

namespace WebMedicine.Models;

public partial class Employee
{
    public int Id { get; set; }

    public int PersonId { get; set; }

    public int PositionId { get; set; }

    public DateOnly HireDate { get; set; }

    public int StructureId { get; set; }

    public virtual ICollection<Doctorvisit> Doctorvisits { get; set; } = new List<Doctorvisit>();

    public virtual Person Person { get; set; } = null!;

    public virtual Position Position { get; set; } = null!;

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    public virtual Structure Structure { get; set; } = null!;

    public virtual ICollection<Treatment> Treatments { get; set; } = new List<Treatment>();

    public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();
}
