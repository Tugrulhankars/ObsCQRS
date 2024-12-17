using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Entities;

public class Course:Entity<int>
{

    public string CourseName { get; set; }
    public long CourseCode { get; set; }
    public string CourseDescription { get; set; }
    public int CourseCredit { get; set; }
    public List<Student> Students { get; set; }
    public List<Instructor> Instructors { get; set; }



   
}
