using System;
using System.Collections.Generic;

namespace WebMedicine.Models;

public partial class Person
{
    public int Id { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? Patronymic { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public DateOnly? DateOfDeath { get; set; }

    public string? PhoneNumber { get; set; }

    public bool? HigherEducation { get; set; }

    public string Gender { get; set; } = null!;

    public virtual ICollection<Doctorvisit> Doctorvisits { get; set; } = new List<Doctorvisit>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Patientfeature> Patientfeatures { get; set; } = new List<Patientfeature>();

    public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();
}
