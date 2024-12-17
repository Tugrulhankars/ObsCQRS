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

public class UserRepository : EfRepositoryBase<User, int, BaseDbContext>, IUserRepository
{
    private readonly BaseDbContext _context;
    public UserRepository(BaseDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<bool> Login(string email, byte[] passwordHash, byte[] passwordSalt)
    {
        var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Email == email
                              && x.PasswordHash == passwordHash
                              && x.PasswordSalt == passwordSalt);
        if (user == null)
        {
            return false;
        }
        return true;

    }
}
