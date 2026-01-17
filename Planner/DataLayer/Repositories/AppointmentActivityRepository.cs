using BuisnessLayer.Models;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class AppointmentActivityRepository: PlannerContext
    {
        private readonly PlannerContext _context;

        public AppointmentActivityRepository(PlannerContext context)
        {
            _context = context;
        }

        public async Task<AppointmentActivity> Create(AppointmentActivity model)
        {
            var entity = model.ToEntity();
            await _context.Activities.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity/*.ToDomainModel*/;
        }

        public async Task<AppointmentActivity> Update(AppointmentActivity model)
        {
            var entity = await _context.AppointmentActivities.SingleAsync(a => a.ActivityId == model.ActivityId);
            var updated = model.ToEntity();

            entity.Name = updated.Name;
            entity.UserId = updated.UserId;
            entity.Date = updated.Date;
            entity.Description = updated.Description;
            entity.Color = updated.Color;

            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
