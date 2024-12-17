using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Entities;

public class Instructor:Entity<int>
{
    public string InstructorFirstName { get; set; }
    public string InstructorLastName { get; set; }
    public string InstructorMailAddress { get; set; }
    public string InstructorPhoneNumber { get; set; }
    public string InstructorAddress { get; set; }
    public List<Course> Courses { get; set; }



}
