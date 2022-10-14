using Api_AngularTestProject.Data;
using Api_AngularTestProject.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace Api_AngularTestProject.Repos
{
    public class StaffRepository : IStaffRepository
    {
        
            private readonly DataContext _context;
            public StaffRepository(DataContext context)
            {
                _context = context;
            }

            public void Add(Staff personal)
            {

                _context.Staff.Add(personal);
            }

            public async Task Delete(Guid id)
            {
                var personalToDelete = await _context.Staff.FirstOrDefaultAsync(p => p.Id == id);

                _context.Remove(personalToDelete);

            }

            public async Task<IEnumerable<Staff>> GetAll()
            {
                return await _context.Staff.ToListAsync();
            }

            public async Task<Staff> GetById(Guid id)
            {
                var personal = await _context.Staff.FirstOrDefaultAsync(x => x.Id == id);
                return personal;
            }

            public void Save()
            {
                _context.SaveChanges();
            }

            public async Task SaveAsync()
            {
                await _context.SaveChangesAsync();
            }

            public void Update(Staff personal)
            {
                _context.Entry(personal).State = EntityState.Modified;

            }
        }
}
