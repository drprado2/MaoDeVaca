using System;
using System.Collections.Generic;
using System.Text;

namespace MaoDeVaca.Domain.Entities
{
    public class User : Entity
    {
        protected User()
        {
        }

        public User(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public void SetName(string name)
        {
            Name = name;
        }
    }
}
