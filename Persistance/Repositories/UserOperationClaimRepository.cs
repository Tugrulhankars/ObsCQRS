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

public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, int, BaseDbContext>, IIUserOperationClaimRepository
{
    public UserOperationClaimRepository(BaseDbContext context) : base(context)
    {
    }

    public async Task<IList<OperationClaim>> GetOperationClaimsByUserIdAsync(int userId)
    {
        var operationClaims = await Query()
             .AsNoTracking()
             .Where(p => p.UserId == userId)
             .Select(p => new OperationClaim { Id = p.OperationClaimId, Name = p.OperationClaim.Name })
             .ToListAsync();
        return operationClaims;
    }
}
