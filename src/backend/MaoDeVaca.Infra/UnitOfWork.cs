using MaoDeVaca.Domain.Interfaces;
using MaoDeVaca.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MaoDeVaca.Infra
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MaoDeVacaDbContext _dbContext;

        public UnitOfWork(MaoDeVacaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
