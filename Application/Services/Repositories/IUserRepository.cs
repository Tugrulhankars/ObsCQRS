﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Repositories;

public interface IUserRepository:IRepository<User,int>
{
    Task<bool> Login(string email,byte[] passwordHash, byte[] passwordSalt);
}
