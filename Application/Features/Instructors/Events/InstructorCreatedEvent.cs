using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Instructors.Events;

public class InstructorCreatedEvent:IEvent
{
    public string InstructorFirstName { get; set; }
    public string InstructorLastName { get; set; }
    public string InstructorMailAddress { get; set; }
    public string InstructorPhoneNumber { get; set; }
    public string InstructorAddress { get; set; }
}
