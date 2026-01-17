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
            await _context.AppointmentActivities.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity/*.ToDomainModel*/;
        }

        public async Task<AppointmentActivity> Read(int id)
        {
            var entity = await _context.AppointmentActivities.SingleOrDefaultAsync(a => a.ActivityId == id);
            return entity;
        }

        public async Task<List<AppointmentActivity>> ReadAll()
        {
            var entities = await _context.AppointmentActivities.ToListAsync();
            return entities;
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
            entity.StartTime = updated.StartTime;
            entity.EndTime = updated.EndTime;

            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var entity = await _context.AppointmentActivities.SingleOrDefaultAsync(a => a.ActivityId == id);
            _context.AppointmentActivities.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
