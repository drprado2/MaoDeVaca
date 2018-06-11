using MaoDeVaca.Domain.Commands;
using MaoDeVaca.Domain.Dto;
using MaoDeVaca.Domain.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MaoDeVaca.Domain.Interfaces
{
    public interface IUserService
    {
        Task CreateAsync(CreateUserCommand request);

        Task UpdateAsync(UpdateUserCommand request);

        void Delete(Guid id);

        Task<IList<UserDto>> GetAsync(UserQuery query);
    }
}
