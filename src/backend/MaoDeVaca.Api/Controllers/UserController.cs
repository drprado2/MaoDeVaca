using MaoDeVaca.Domain.Commands;
using MaoDeVaca.Domain.Interfaces;
using MaoDeVaca.Domain.Query;
using MaoDeVaca.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaoDeVaca.Api.Controllers
{
    [Route("Users")]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommandQueryHandler _commandQueryHandler;

        public UserController(IUnitOfWork unitOfWork, ICommandQueryHandler commandQueryHandler)
        {
            _unitOfWork = unitOfWork;
            _commandQueryHandler = commandQueryHandler;
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            var response = await _commandQueryHandler.HandleAsync(command);
            if (response.Errors.Any())
                return BadRequest(response);

            await _unitOfWork.CommitAsync();
            return Ok(response);
        }

        [HttpPut("")]
        public async Task<IActionResult> Put([FromBody] UpdateUserCommand command)
        {
            var response = await _commandQueryHandler.HandleAsync(command);
            if (response.Errors.Any())
                return BadRequest(response);

            await _unitOfWork.CommitAsync();
            return Ok(response);
        }

        [HttpDelete("")]
        public async Task<IActionResult> Delete([FromBody] DeleteUserCommand command)
        {
            var response = await _commandQueryHandler.HandleAsync(command);
            if (response.Errors.Any())
                return BadRequest(response);

            await _unitOfWork.CommitAsync();
            return Ok(response);
        }

        [HttpGet("")]
        public async Task<IActionResult> Get([FromQuery] UserQuery query)
        {
            var response = await _commandQueryHandler.HandleAsync(query);
            if (response.Errors.Any())
                return BadRequest(response);

            return Ok(response);
        }
    }
}
