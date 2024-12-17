using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Repositories;

public interface IIUserOperationClaimRepository
{
    Task<IList<OperationClaim>> GetOperationClaimsByUserIdAsync(int userId);
}
