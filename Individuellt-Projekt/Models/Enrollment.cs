using System;
using System.Collections.Generic;

namespace Individuellt_Projekt.Models;

public partial class Enrollment
{
    public string? StudentId { get; set; }

    public string? CourseId { get; set; }

    public int? GradeInfo { get; set; }

    public DateTime? DateOfGrade { get; set; }

    public int? FkteacherId { get; set; }

    public int Id { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Employee? Fkteacher { get; set; }

    public virtual Student? Student { get; set; }
}
