using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Repositories;

public interface IInstructorRepository:IRepository<Instructor,int>
{
   public Task<Instructor> GetById(int id);
}
