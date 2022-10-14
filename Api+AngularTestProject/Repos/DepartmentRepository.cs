using Api_AngularTestProject.Data;
using Api_AngularTestProject.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace Api_AngularTestProject.Repos
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DataContext _appDbContext;
        public DepartmentRepository(DataContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Add(Department department)
        {

            _appDbContext.Add(department);
        }

        public async Task Delete(int id)
        {
            var depToDelete = await _appDbContext.DepartmentTbl.FirstOrDefaultAsync(d => d.Id == id);
            if (depToDelete != null)
            {
                _appDbContext.Remove(depToDelete);
            }

        }

        public IEnumerable<Department> GetAll()
        {

            return _appDbContext.DepartmentTbl.ToList();
        }

        public async Task<Department> GetById(int id)
        {
            var department = await _appDbContext.DepartmentTbl.FirstOrDefaultAsync(x => x.Id == id);
            return department;
        }

        public void Save()
        {
            _appDbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Update(Department department)
        {
            _appDbContext.Entry(department).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
        }
    }
}

