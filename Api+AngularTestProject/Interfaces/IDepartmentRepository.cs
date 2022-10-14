namespace Api_AngularTestProject.Interfaces
{
    public interface IDepartmentRepository
    {
        public IEnumerable<Department> GetAll();

        public Task<Department> GetById(int id);
        public void Add(Department person);
        public Task Update(Department person);
        public Task Delete(int id);

        void Save();
        Task SaveAsync();
    }
}
