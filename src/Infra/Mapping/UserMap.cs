using Base.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeConfiguration<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x => x.Id);


        }
    }
}
