using Application.Services.Repositories;
using Domain.Entities;
using Persistance.Context;
using Persistance.Repositories.EfRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories;

public class StudentRepository : EfRepositoryBase<Student, int, BaseDbContext>, IStudentRepository
{
    private readonly BaseDbContext _context;
    public StudentRepository(BaseDbContext context) : base(context)
    {
        _context=context;
    }

    public Student GetStudentById(int id)
    {
        var course =_context.Students.FirstOrDefault(x=>x.Id==id);
        return course;
    }
}
