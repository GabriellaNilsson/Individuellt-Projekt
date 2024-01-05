using System;
using System.Collections.Generic;

namespace Individuellt_Projekt.Models;

public partial class Course
{
    public string CourseId { get; set; } = null!;

    public string? CourseName { get; set; }

    public string? Classroom { get; set; }

    public int? FkemployeeId { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual Employee? Fkemployee { get; set; }
}
