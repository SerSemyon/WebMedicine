using System;
using System.Collections.Generic;

namespace WebMedicine.Models;

public partial class Room
{
    public int Id { get; set; }

    public int DepartmentId { get; set; }

    public int RoomNumber { get; set; }

    public bool? IsolationFacility { get; set; }

    public virtual Structure Department { get; set; } = null!;
}
