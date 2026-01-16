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
    public class AppointmentActivityConfiguration : IEntityTypeConfiguration<AppointmentActivity>
    {
        public void Configure(EntityTypeBuilder<AppointmentActivity> builder)
        {

            builder.Property(t => t.StartTime)
                   .IsRequired();

            builder.Property(t => t.EndTime)
                   .IsRequired();

            builder.HasDiscriminator<string>("ActivityType")
                   .HasValue<TaskActivity>("Appointment");
        }
    }
}
