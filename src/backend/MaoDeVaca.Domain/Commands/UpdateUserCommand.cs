using System;
using System.Collections.Generic;
using System.Text;

namespace MaoDeVaca.Domain.Commands
{
    public class UpdateUserCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
