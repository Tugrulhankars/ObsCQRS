using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using Persistance.Repositories.EfRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories;

public class InstructorRepository : EfRepositoryBase<Instructor, int, BaseDbContext>, IInstructorRepository
{
    private readonly BaseDbContext _context;
    public InstructorRepository(BaseDbContext context) : base(context)
    {
        _context = context; 
    }

    public async Task<Instructor> GetById(int id)
    {
        var instructor =await _context.Instructors.FirstOrDefaultAsync(x=>x.Id==id);

        return instructor;
    }
}
