using BuisnessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class BirthdayActivityConfiguration : IEntityTypeConfiguration<BirthdayActivity>
    {
        public void Configure(EntityTypeBuilder<BirthdayActivity> builder)
        {

            builder.Property(t => t.BirthdayPerson)
                   .IsRequired();

            builder.HasDiscriminator<string>("ActivityType")
                   .HasValue<TaskActivity>("Birthday");
        }
    }
}
