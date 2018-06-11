using MaoDeVaca.Domain.Commands;
using MaoDeVaca.Domain.Dto;
using MaoDeVaca.Domain.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MaoDeVaca.Domain.Interfaces
{
    public interface ICommandQueryHandler
    {
        Task<DefaultResponse> HandleAsync(CreateUserCommand @event);

        Task<DefaultResponse> HandleAsync(UpdateUserCommand @event);

        Task<DefaultResponse> HandleAsync(DeleteUserCommand @event);

        Task<DefaultResponse> HandleAsync(UserQuery query);
    }
}
