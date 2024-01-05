using System;
using System.Collections.Generic;

namespace Individuellt_Projekt.Models;

public partial class Student
{
    public string StudentId { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string Gender { get; set; } = null!;

    public int FkclassId { get; set; }

    public string PersonalNumber { get; set; } = null!;

    public string HealthInfo { get; set; } = null!;

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual Class Fkclass { get; set; } = null!;
}
