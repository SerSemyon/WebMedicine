using System;
using System.Collections.Generic;

namespace WebMedicine.Models;

public partial class Structure
{
    public int Id { get; set; }

    public string DepartmentName { get; set; } = null!;

    public bool? IsolationFacility { get; set; }

    public bool? EmploymentAvailability { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
