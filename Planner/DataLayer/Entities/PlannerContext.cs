using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class PlannerContext: DbContext
    {

        public DbSet<ActivityEntity> Activities { get; set; }
        public DbSet<AppointmentActivityEntity> AppointmentActivities { get; set; }
        public DbSet<BirthdayActivityEntity> BirthdayActivities { get; set; }
    }
}
