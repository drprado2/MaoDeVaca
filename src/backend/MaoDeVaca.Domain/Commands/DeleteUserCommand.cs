using System;
using System.Collections.Generic;
using System.Text;

namespace MaoDeVaca.Domain.Commands
{
    public class DeleteUserCommand
    {
        public Guid Id { get; set; }
    }
}
