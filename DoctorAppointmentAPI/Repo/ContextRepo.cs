using DoctorAppointmentAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorAppointmentAPI.Repo
{
    public class ContextRepo<T> : IAppointRepo<T> where T : class
    {
        public readonly AppoinmentDbContext _context;
        public ContextRepo(AppoinmentDbContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetT()
        {
            var t = await _context.Set<T>().ToListAsync();
            return t;
        }

        public async Task<T> GetTById(int id)
        {
            var t = await _context.Set<T>().FindAsync(id);
            return t;
        }

        public async Task<T> SaveAsync(T entity)
        {
            await _context.SaveChangesAsync();
            return entity;
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
