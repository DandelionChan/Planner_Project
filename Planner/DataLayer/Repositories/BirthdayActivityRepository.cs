using BuisnessLayer.Models;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class BirthdayActivityRepository: PlannerContext
    {
        private readonly PlannerContext _context;

        public BirthdayActivityRepository(PlannerContext context)
        {
            _context = context;
        }

        public async Task<BirthdayActivity> Create(BirthdayActivity model)
        {
            var entity = model.ToEntity();
            await _context.BirthdayActivities.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<BirthdayActivity> Read(int id)
        {
            var entity = await _context.BirthdayActivities.SingleOrDefaultAsync(b => b.ActivityId == id);
            return entity;
        }

        public async Task<List<BirthdayActivity>> ReadAll()
        {
            var entities = await _context.BirthdayActivities.ToListAsync();
            return entities;
        }

        public async Task<BirthdayActivity> Update(BirthdayActivity model)
        {
            var entity = await _context.BirthdayActivities.SingleOrDefaultAsync(b => b.ActivityId == model.ActivityId);
            var updated = model.ToEntity();

            entity.Name = updated.Name;
            entity.UserId = updated.UserId;
            entity.Date = updated.Date;
            entity.Description = updated.Description;
            entity.Color = updated.Color;
            entity.Recurrence = updated.Recurrence;
            entity.BirthdayPerson = updated.BirthdayPerson;

            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var entity = await _context.BirthdayActivities.SingleAsync(b => b.ActivityId == id);
            _context.BirthdayActivities.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
