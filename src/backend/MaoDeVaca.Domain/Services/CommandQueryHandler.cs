using MaoDeVaca.Domain.Commands;
using MaoDeVaca.Domain.Dto;
using MaoDeVaca.Domain.Interfaces;
using MaoDeVaca.Domain.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MaoDeVaca.Domain.Services
{
    public class CommandQueryHandler : ICommandQueryHandler
    {
        private readonly IUserService _userService;

        public CommandQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<DefaultResponse> HandleAsync(CreateUserCommand command)
        {
            await _userService.CreateAsync(command);
            return new DefaultResponse();
        }

        public async Task<DefaultResponse> HandleAsync(UpdateUserCommand command)
        {
            await _userService.UpdateAsync(command);
            return new DefaultResponse();
        }

        public async Task<DefaultResponse> HandleAsync(DeleteUserCommand command)
        {
            _userService.Delete(command.Id);
            return new DefaultResponse();
        }

        public async Task<DefaultResponse> HandleAsync(UserQuery query)
        {
            var users = await _userService.GetAsync(query);
            return new DefaultResponse()
            {
                Data = users,
                TotalItems = users.Count
            };
        }
    }
}
