using Individuellt_Projekt.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Spectre.Console;

namespace Individuellt_Projekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using SchoolSystemContext dBContext = new SchoolSystemContext();

            string[] Menu = { "All employees", "Salary for each role", "Average salary for each role", "All students' names and be able to sort them in differnt orders", "All students and their information", "All classes and their students", "All courses and average grades", "All grades from december month", "All active courses", "Add new students", "Add new employees", "Add new grades", "End program" };

            Console.WriteLine("NAVIGATION MENU");
            Console.WriteLine("~ALL SEVEN OPTIONS~");

            int i = 1;
            foreach (string option in Menu)
            {
                Console.WriteLine($"{i}. {option}");
                i++;
            }

            Console.Write("Enter your chosen number between 1 - 13 here: ");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine($"{Menu[0]}\n");

                    Console.WriteLine("Employee selction");
                    string[] employeeArray = { "See all employees", "See all teachers", "See principal", "See vice principal", "See admin", "See Nurse", "See janitors", "See librarian", "See cafeteria staff", "See career counselor", "See school counselors" };

                    int x = 1;
                    foreach (string employeeChoice in employeeArray)
                    {
                        Console.WriteLine($"{x}.{employeeChoice}");
                        x++;
                    }

                    Console.Write("Enter your chosen number: ");
                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine("All employees\n");

                            var allEmployees = (from Employee in dBContext.Employees
                                                join Roles in dBContext.Roles
                                                on Employee.FkroleId equals Roles.RoleId
                                                select new
                                                {
                                                    Employee,
                                                    Roles.Role1
                                                }).ToList();

                            var table = new Spectre.Console.Table();
                            table.AddColumn("Name");
                            table.AddColumn("Personal number");
                            table.AddColumn("Role");
                            table.AddColumn("Start of employment year");

                            foreach (var Employee in allEmployees)
                            {
                                string fullName = $"{Employee.Employee.FirstName} {Employee.Employee.LastName}";
                                table.AddRow(fullName, Employee.Employee.PersonalNumber, Employee.Role1, Employee.Employee.StartOfEmployment);
                            }
                            AnsiConsole.Render(table);
                            break;

                        case "2":
                            Console.Clear();
                            Console.WriteLine("All teachers\n");

                            var teachers = (from Employee in dBContext.Employees
                                            join R in dBContext.Roles on Employee.FkroleId equals R.RoleId
                                            where R.Role1 == "Teacher"
                                            select Employee).ToList();

                            foreach (var teacher in teachers)
                            {
                                Console.WriteLine($"Name: {teacher.FirstName} {teacher.LastName} Personal number: {teacher.PersonalNumber} Startof employment year: {teacher.StartOfEmployment}");
                            }

                            break;

                        case "3":
                            Console.Clear();
                            Console.WriteLine("Principal\n");

                            var principalRole = (from Employee in dBContext.Employees
                                                 join R in dBContext.Roles on Employee.FkroleId equals R.RoleId
                                                 where R.Role1 == "Principal"
                                                 select Employee).ToList();

                            foreach (var principal in principalRole)
                            {
                                Console.WriteLine($"Name: {principal.FirstName} {principal.LastName} Personal number: {principal.PersonalNumber} Start of employment year: {principal.StartOfEmployment}");
                            }

                            break;

                        case "4":
                            Console.Clear();
                            Console.WriteLine("Vice principal\n");

                            var vicePrincipalRole = (from Employee in dBContext.Employees
                                                     join R in dBContext.Roles on Employee.FkroleId equals R.RoleId
                                                     where R.Role1 == "Vice principal"
                                                     select Employee).ToList();

                            foreach (var vicePrincipal in vicePrincipalRole)
                            {
                                Console.WriteLine($"Name: {vicePrincipal.FirstName} {vicePrincipal.LastName} Personal number: {vicePrincipal.PersonalNumber} Start of employment year: {vicePrincipal.StartOfEmployment}");
                            }

                            break;

                        case "5":
                            Console.Clear();
                            Console.WriteLine("Admin\n");

                            var adminRole = (from Employee in dBContext.Employees
                                             join R in dBContext.Roles on Employee.FkroleId equals R.RoleId
                                             where R.Role1 == "Admin"
                                             select Employee).ToList();

                            foreach (var admin in adminRole)
                            {
                                Console.WriteLine($"Name: {admin.FirstName} {admin.LastName} Personal number: {admin.PersonalNumber} Start of employment year: {admin.StartOfEmployment}");
                            }

                            break;

                        case "6":
                            Console.Clear();
                            Console.WriteLine("Nurse\n");

                            var nurseRole = (from Employee in dBContext.Employees
                                             join R in dBContext.Roles on Employee.FkroleId equals R.RoleId
                                             where R.Role1 == "Nurse"
                                             select Employee).ToList();

                            foreach (var nurse in nurseRole)
                            {
                                Console.WriteLine($"Name: {nurse.FirstName} {nurse.LastName} Personal number: {nurse.PersonalNumber} Start of employment year: {nurse.StartOfEmployment}");
                            }

                            break;

                        case "7":
                            Console.Clear();
                            Console.WriteLine("Janitor\n");

                            var janitorRole = (from Employee in dBContext.Employees
                                               join R in dBContext.Roles on Employee.FkroleId equals R.RoleId
                                               where R.Role1 == "Janitor"
                                               select Employee).ToList();

                            foreach (var janitor in janitorRole)
                            {
                                Console.WriteLine($"Name: {janitor.FirstName} {janitor.LastName} Personal number: {janitor.PersonalNumber} Start of employment year: {janitor.StartOfEmployment}");
                            }

                            break;

                        case "8":
                            Console.Clear();
                            Console.WriteLine("Librarian\n");

                            var librarianRole = (from Employee in dBContext.Employees
                                                 join R in dBContext.Roles on Employee.FkroleId equals R.RoleId
                                                 where R.Role1 == "Librarian"
                                                 select Employee).ToList();

                            foreach (var librarian in librarianRole)
                            {
                                Console.WriteLine($"Name: {librarian.FirstName} {librarian.LastName} Personal number: {librarian.PersonalNumber} Start of employment year: {librarian.StartOfEmployment}");
                            }

                            break;

                        case "9":
                            Console.Clear();
                            Console.WriteLine("Cafeteria staff\n");

                            var cafeteriaRole = (from Employee in dBContext.Employees
                                                 join R in dBContext.Roles on Employee.FkroleId equals R.RoleId
                                                 where R.Role1 == "Cafeteria staff"
                                                 select Employee).ToList();

                            foreach (var cafeteriaStaff in cafeteriaRole)
                            {
                                Console.WriteLine($"Name: {cafeteriaStaff.FirstName} {cafeteriaStaff.LastName} Personal number: {cafeteriaStaff.PersonalNumber} Start of employment year: {cafeteriaStaff.StartOfEmployment}");
                            }

                            break;

                        case "10":
                            Console.Clear();
                            Console.WriteLine("Career counselor\n");

                            var ccRole = (from Employee in dBContext.Employees
                                          join R in dBContext.Roles on Employee.FkroleId equals R.RoleId
                                          where R.Role1 == "Career counselor"
                                          select Employee).ToList();

                            foreach (var cc in ccRole)
                            {
                                Console.WriteLine($"Name: {cc.FirstName} {cc.LastName}  Personal number: {cc.PersonalNumber} Start of employment year: {cc.StartOfEmployment}");
                            }

                            break;

                        case "11":
                            Console.Clear();
                            Console.WriteLine("School counselor\n");

                            var scRole = (from Employee in dBContext.Employees
                                          join R in dBContext.Roles on Employee.FkroleId equals R.RoleId
                                          where R.Role1 == "School counselor"
                                          select Employee).ToList();

                            foreach (var sc in scRole)
                            {
                                Console.WriteLine($"Name:  {sc.FirstName}   {sc.LastName}  Personal number:  {sc.PersonalNumber}  Start of employment year:  {sc.StartOfEmployment}");
                            }

                            break;
                    }

                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine($"{Menu[1]}\n");

                    string[] salaryArray = { "Principal salaries", "Vice principal salaries", "Teacher salaries", "Admin salaries", "Nurse salaries", "Janitor salaries", "Librarian salaries", "Cafeteria staff salaries", "Career counselor salaries", "School counselor salaries" };

                    int a = 1;
                    foreach (string chooseRole in salaryArray)
                    {
                        Console.WriteLine($"{a}.{chooseRole}");
                        a++;
                    }

                    string inputForUser = Console.ReadLine();
                    switch (inputForUser)
                    {
                        case "1":
                            Console.Clear();

                            var totalPrincipalSalaries = dBContext.Roles
                            .Where(role => role.Role1 == "Principal")
                            .Sum(role => role.Salary);

                            Console.WriteLine($"All principals combined salaries are: {totalPrincipalSalaries * 1:C}");

                            break;

                        case "2":
                            Console.Clear();

                            var totalVicePrincipalSalaries = dBContext.Roles
                            .Where(role => role.Role1 == "Vice principal")
                            .Sum(role => role.Salary);

                            Console.WriteLine($"All vice principals combined salaries are: {totalVicePrincipalSalaries * 1:C}");

                            break;

                        case "3":
                            Console.Clear();

                            var totalTeacherSalaries = dBContext.Roles
                            .Where(role => role.Role1 == "Teacher")
                            .Sum(role => role.Salary);

                            Console.WriteLine($"All teachers' combined salaries are: {totalTeacherSalaries * 10:C}" );

                            break;

                        case "4":
                            Console.Clear();

                            var totalAdminSalaries = dBContext.Roles
                           .Where(role => role.Role1 == "Admin")
                           .Sum(role => role.Salary);

                            Console.WriteLine($"All admins combined salaries are: {totalAdminSalaries * 1:C}");

                            break;

                        case "5":
                            Console.Clear();

                            var totalNurseSalaries = dBContext.Roles
                           .Where(role => role.Role1 == "Nurse")
                           .Sum(role => role.Salary);

                            Console.WriteLine($"All nurses combined salaries are: {totalNurseSalaries * 1:C}");

                            break;

                        case "6":
                            Console.Clear();

                            var totalJanitorSalaries = dBContext.Roles
                           .Where(role => role.Role1 == "Janitor")
                           .Sum(role => role.Salary);

                            Console.WriteLine($"All janitors combined salaries are: {totalJanitorSalaries * 3:C}");

                            break;

                        case "7":
                            Console.Clear();

                            var totalLibrarianSalaries = dBContext.Roles
                           .Where(role => role.Role1 == "Librarian")
                           .Sum(role => role.Salary);

                            Console.WriteLine($"All librarians combined salaries are: {totalLibrarianSalaries * 1:C}");

                            break;

                        case "8":
                            Console.Clear();

                            var totalCafeteriaSalaries = dBContext.Roles
                           .Where(role => role.Role1 == "Cafeteria staff")
                           .Sum(role => role.Salary);

                            Console.WriteLine($"All cafeteria staffs combined salaries are: {totalCafeteriaSalaries * 1:C}");

                            break;

                        case "9":
                            Console.Clear();

                            var totalCCSalaries = dBContext.Roles
                           .Where(role => role.Role1 == "Career counselor")
                           .Sum(role => role.Salary);

                            Console.WriteLine($"All career counselors combined salaries are: {totalCCSalaries * 1:C}");

                            break;

                        case "10":
                            Console.Clear();

                            var totalSCSalaries = dBContext.Roles
                           .Where(role => role.Role1 == "School counselor")
                           .Sum(role => role.Salary);

                            Console.WriteLine($"All School counselors combined salaries are: {totalSCSalaries * 2:C}");

                            break;
                    }
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine($"{Menu[2]}\n");

                    var averageSalaries = dBContext.Roles
                    .GroupBy(e => e.Role1 )
                    .Select(g => new
                    {
                        _roleId = g.Key,
                        AverageSalary = g.Average(e => e.Salary)
                    })
                    .ToList();

                    foreach (var averageSalary in averageSalaries)
                    {
                        Console.WriteLine($"Average salary: {averageSalary.AverageSalary:C}  Role: {averageSalary._roleId}"); 
                    }

                    break;

                case "4":
                    Console.Clear();

                    var students = dBContext.Students.ToList();
                    Console.WriteLine($"{Menu[3]}\n");

                    Console.WriteLine("Choose sorting option:");

                    string[] studentsMenuOptions = { "Students sorted by first name in an ascending order (A - Z)", "Students sorted by first name in a descending order (Z - A)", "Students sorted by last name in an ascending order (A - Z)", "Students sorted by last name in a descending order (Z - A)" };
                    int y = 1;
                    foreach (string menuOptions in studentsMenuOptions)
                    {
                        Console.WriteLine($"{y}. {menuOptions}");
                        y++;
                    }

                    string sortOption = Console.ReadLine();
                    switch (sortOption)
                    {
                        case "1":
                            students = dBContext.Students.OrderBy(s => s.FirstName).ToList();
                            break;
                        case "2":
                            students = dBContext.Students.OrderByDescending(s => s.FirstName).ToList();
                            break;
                        case "3":
                            students = dBContext.Students.OrderBy(s => s.LastName).ToList();
                            break;
                        case "4":
                            students = dBContext.Students.OrderByDescending(s => s.LastName).ToList();
                            break;
                        default:
                            Console.WriteLine("Invalid option selected.");
                            students = dBContext.Students.ToList();
                            break;
                    }

                    if (sortOption == "1" || sortOption == "2")
                    {
                        foreach (var student in students)
                        {
                            Console.WriteLine($"{student.FirstName} {student.LastName}");
                        }
                    }

                    else if (sortOption == "3" || sortOption == "4")
                    {
                        foreach (var student in students)
                        {
                            Console.WriteLine($"{student.LastName} {student.FirstName}");
                        }
                    }

                    else
                    {
                        Console.WriteLine("Error: invalid choice.");
                    }

                    break;


                case "5":
                    Console.Clear();
                    Console.WriteLine($"{Menu[4]}\n");

                    var studentInformation = (from Student in dBContext.Students
                                              join Enrollment in dBContext.Enrollments
                                              on Student.StudentId equals Enrollment.StudentId
                                              select new
                                              {
                                                  Student,
                                                  Enrollment.CourseId,
                                                  Enrollment.GradeInfo,
                                                  Enrollment.FkteacherId,
                                                  Enrollment.DateOfGrade
                                              }).ToList();

                    foreach (var studentInfo in studentInformation)
                    {
                        Console.WriteLine($"Student name: {studentInfo.Student.FirstName} {studentInfo.Student.LastName} StudentID: {studentInfo.Student.StudentId} Personal number: {studentInfo.Student.PersonalNumber} Gender: {studentInfo.Student.Gender} Class: {studentInfo.Student.FkclassId} Health information: {studentInfo.Student.HealthInfo} Courses: {studentInfo.CourseId} Grade: {studentInfo.GradeInfo} Date of grade: {studentInfo.DateOfGrade} Teacher of course: {studentInfo.FkteacherId}");
                    }

                    break;

                case "6":
                    Console.Clear();
                    Console.WriteLine($"{Menu[5]}\n");

                    var classesList = (from cls in dBContext.Classes
                                       select cls).ToList();

                    Console.WriteLine("List of all classes:");
                    foreach (var cls in classesList)
                    {
                        Console.WriteLine($"{cls.ClassName}");
                    }

                    Console.Write("Choose a class: ");
                    if (!int.TryParse(Console.ReadLine(), out int classChoice) || classChoice < 1 || classChoice > classesList.Count)
                    {
                        Console.WriteLine("Invalid choice.");
                        break;
                    }

                    // Get selected class
                    var selectedClass = classesList[classChoice - 1];

                    var studentsInSelectedClass = (from student in dBContext.Students
                                                   where student.FkclassId == selectedClass.ClassId
                                                   select student).ToList();

                    // Printing out students in chosen class
                    Console.WriteLine($"{selectedClass.ClassName}:");
                    foreach (var student in studentsInSelectedClass)
                    {
                        Console.WriteLine($"{student.FirstName} {student.LastName}");
                    }

                    break;

                case "7":
                    Console.Clear();
                    Console.WriteLine($"{Menu[6]}\n");

                    var coursesAndGrades = (
                        from enrollment in dBContext.Enrollments
                        group enrollment by enrollment.CourseId into courseGrades
                        select new
                        {
                            CourseId = courseGrades.Key,
                            AverageGrade = courseGrades.Average(e => e.GradeInfo),
                            HighestGrade = courseGrades.Max(e => e.GradeInfo),
                            LowestGrade = courseGrades.Min(e => e.GradeInfo)
                        }
                      ).ToList();

                    Console.WriteLine("\nList of all classes:");

                    foreach (var course in coursesAndGrades)
                    {
                        Console.WriteLine($"CourseID: {course.CourseId}  Highest course grade: {course.HighestGrade}   Lowest course grade: {course.LowestGrade}   Average course grade: {course.AverageGrade}");
                    }

                    break;

                case "8":
                    Console.Clear();
                    Console.WriteLine($"{Menu[7]}\n");

                    DateTime startDate = new DateTime(2023, 11, 30);
                    DateTime endDate = new DateTime(2023, 12, 30);

                    var gradesFromDecemberMonth = (
                        from enrollment in dBContext.Enrollments
                        where enrollment.DateOfGrade >= startDate && enrollment.DateOfGrade <= endDate
                        join course in dBContext.Courses on enrollment.CourseId equals course.CourseId
                        join student in dBContext.Students on enrollment.StudentId equals student.StudentId
                        select new
                        {
                            enrollment.StudentId,
                            enrollment.CourseId,
                            course.CourseName,
                            enrollment.GradeInfo,
                            enrollment.DateOfGrade
                        }
                    ).ToList();

                    Console.WriteLine("Grades from december month\n");
                    foreach (var grade in gradesFromDecemberMonth)
                    {
                        Console.WriteLine($"COURSE-ID: {grade.CourseId} GRADE:{grade.GradeInfo}  DATE: {grade.DateOfGrade} STUDENT-ID: {grade.StudentId} NAME OF COURSE: {grade.CourseName}");
                    }

                    break;

                case "9":
                    Console.Clear();
                    Console.WriteLine($"{Menu[8]}");

                    var activeCourses = (from Course in dBContext.Courses
                                         where Course.IsActive == true
                                         select Course).ToList();

                    foreach (var activeCourse in activeCourses)
                    {
                        Console.WriteLine($"Teacher's employee number: {activeCourse.FkemployeeId}  Classroom: {activeCourse.Classroom}  CourseID: {activeCourse.CourseId} Course name: {activeCourse.CourseName}");
                    }

                    break;

                case "10":
                    Console.Clear();
                    Console.WriteLine($"{Menu[9]}\n");

                    Console.WriteLine("Enter StudentID: ");
                    string studentId = Console.ReadLine();
                    Console.WriteLine("Enter first name of new student: ");
                    string _firstName = Console.ReadLine();
                    Console.WriteLine("Enter last name of new student: ");
                    string _lastName = Console.ReadLine();
                    Console.WriteLine("Enter gender of new student: ");
                    string gender = Console.ReadLine();
                    Console.WriteLine("Enter personal number of new employee (It should be written as such: YYYY-MM.DD): ");
                    string _personalNumber = Console.ReadLine();
                    Console.WriteLine("Enter eventual health infomation about new student. If nothing special, enter 'None': ");
                    string healthInfo = Console.ReadLine();
                    Console.WriteLine("Enter ClassID of new student: ");
                    int classId = Convert.ToInt32(Console.ReadLine());

                    Student newStudent = new Student()
                    {
                        StudentId = studentId,
                        FirstName = _firstName,
                        LastName = _lastName,
                        Gender = gender,
                        PersonalNumber = _personalNumber,
                        HealthInfo = healthInfo,
                        FkclassId = classId
                    };

                    dBContext.Students.Add(newStudent);
                    dBContext.SaveChanges();

                    break;

                case "11":
                    Console.Clear();
                    Console.WriteLine($"{Menu[10]}\n");

                    Console.WriteLine("Enter EmployeeID: ");
                    int employeeId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter first name of new employee: ");
                    string firstName = Console.ReadLine();
                    Console.WriteLine("Enter last name of new employee: ");
                    string lastName = Console.ReadLine();
                    Console.WriteLine("Enter personal number of new employee (It should be written as such: YYYY-MM.DD): ");
                    string personalNumber = Console.ReadLine();
                    Console.WriteLine("Enter role of new employee: ");
                    int fkRoleId = Convert.ToInt32(Console.ReadLine());

                    Employee newEmployee = new Employee()
                    {
                        EmployeesId = employeeId,
                        FirstName = firstName,
                        LastName = lastName,
                        PersonalNumber = personalNumber,
                        FkroleId = fkRoleId
                    };

                    dBContext.Employees.Add(newEmployee);
                    dBContext.SaveChanges();

                    break;

                    
                case "12":
                    Console.Clear();
                    Console.WriteLine($"{Menu[11]}\n");

                    using (var transaction = dBContext.Database.BeginTransaction())
                    {
                        try
                        {
                            Console.WriteLine("Enter studentID: ");
                            string _studentId = Console.ReadLine();
                            Console.WriteLine("Enter course: ");
                            string _courseId = Console.ReadLine();
                            Console.WriteLine("Enter grade: ");
                            int _grade = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter teachers employee number: ");
                            int teacherID = Convert.ToInt32(Console.ReadLine());

                            Enrollment newGrade = new Enrollment()
                            {
                                StudentId = _studentId,
                                CourseId = _courseId,
                                GradeInfo = _grade,
                                FkteacherId = teacherID,
                                DateOfGrade = DateTime.Now
                            };

                            dBContext.Enrollments.Add(newGrade);
                            dBContext.SaveChanges();

                            // Saves data
                            transaction.Commit();

                            var studentClass = dBContext.Students
                            .Where(s => s.StudentId == _studentId)
                            .Select(s => s.Fkclass.ClassId)
                            .ToList();

                            foreach (var _class in studentClass)
                            {
                                Console.WriteLine($"Student with the newly added grade, using ID '{_studentId}', is in class: {_class}");
                            }
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();

                            throw;
                        }
                    }

                    break;

                case "13":
                    Console.Clear();
                    Console.WriteLine($"{Menu[12]}");

                    Console.WriteLine("Enter 'exit' to exit program");
                    string endProgramInput = Console.ReadLine();

                    if (endProgramInput.ToLower() == "exit")
                    {
                        Environment.Exit(0);
                    }
                    break;
            }
        }
}
}
