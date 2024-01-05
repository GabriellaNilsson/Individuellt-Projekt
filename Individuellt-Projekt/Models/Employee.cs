using System;
using System.Collections.Generic;

namespace Individuellt_Projekt.Models;

public partial class Employee
{
    public int EmployeesId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? PersonalNumber { get; set; }

    public int? FkroleId { get; set; }

    public string? StartOfEmployment { get; set; }

    public int? Fksalary { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
