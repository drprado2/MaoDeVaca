using MaoDeVaca.Domain.Commands;
using MaoDeVaca.Domain.Dto;
using MaoDeVaca.Domain.Entities;
using MaoDeVaca.Domain.Interfaces;
using MaoDeVaca.Domain.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaoDeVaca.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateAsync(CreateUserCommand request)
        {
            var user = new User(request.Name);
            await _userRepository.AddAsync(user);
        }

        public async Task UpdateAsync(UpdateUserCommand request)
        {
            var user = await _userRepository.GetAsync(request.Id);
            user.SetName(request.Name);
            _userRepository.Update(user);
        }

        public void Delete(Guid id)
        {
            _userRepository.Remove(id);
        }

        public async Task<IList<UserDto>> GetAsync(UserQuery query)
        {
            var users = await _userRepository.GetAsync();
            return users.Select(x => new UserDto() { Id = x.Id, Name = x.Name }).ToList();
        }
    }
}
