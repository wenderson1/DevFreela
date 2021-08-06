using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
           builder
                .HasKey(u => u.Id);

            builder
                   .HasMany(s => s.Skills)
                   .WithOne()
                   .HasForeignKey(u => u.IdSkill)
                   .OnDelete(DeleteBehavior.Restrict);



        }
    }
}
