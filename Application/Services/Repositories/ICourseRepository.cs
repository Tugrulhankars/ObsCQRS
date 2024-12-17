using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Repositories;

public interface ICourseRepository:IRepository<Course, int>
{
    public Task<Course> AssignInstructorToCourse(int courseCode,int instructureId);
    public Task<Course> GetById(int id);
}
