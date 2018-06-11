using MaoDeVaca.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaoDeVaca.Infra.Mappings
{
    public class UserMapping
    {
        public UserMapping(ModelBuilder builder)
        {
            var userMap = builder.Entity<User>();
            userMap.ToTable("User");
            userMap.HasKey(x => x.Id);
        }
    }
}
