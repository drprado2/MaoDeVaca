using MaoDeVaca.Domain.Entities;
using MaoDeVaca.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaoDeVaca.Infra.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MaoDeVacaDbContext dbContext) : base(dbContext)
        {
        }
    }
}
