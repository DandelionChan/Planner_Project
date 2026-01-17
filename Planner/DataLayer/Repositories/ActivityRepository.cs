using DataLayer.Entities;
using BuisnessLayer.Models.Activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuisnessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    internal class ActivityRepository: PlannerContext
    {
        private readonly PlannerContext _context;

        public ActivityRepository(PlannerContext context)
        {
            _context = context;
        }
        
        public async Task<Activity> Create(Activity model)
        {
            var entity = model.ToEntity();
            await _context.Activities.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity/*.ToDomainModel()*/;
        }

        public async Task<Activity> Read(int ActivityId)
        {
            var entity = await _context.Activities.SingleOrDefaultAsync(a => a.ActivityId == ActivityId);
            return entity/*.ToDomainModel()*/;
        }

        public async Task<List<Activity>> ReadAll()
        {
            var entities = await _context.Activities.ToListAsync();
            return entities/*.ToDomainModelList()*/;
        }

        public async Task<Activity> Update(Activity model)
        {
            var entity = await _context.Activities.SingleAsync(a => a.ActivityId == model.ActivityId);
            var updated = model.ToEntity();

            entity.Name = updated.Name;
            entity.UserId = updated.UserId;
            entity.Date = updated.Date;
            entity.Description = updated.Description;
            entity.Color = updated.Color;
            entity.Recurrence = updated.Recurrence;

            await _context.SaveChangesAsync();
            return entity/*.ToDomainModel()*/;
        }

        public async Task Delete(int ActivityId)
        {
            var entity = await _context.Activities.SingleOrDefaultAsync(a => a.ActivityId == Activity);
            _context.Activities.Remove(entity);
            _context.SaveChangesAsync();
        }
    }
}
