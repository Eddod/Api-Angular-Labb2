namespace Api_AngularTestProject.Interfaces
{
    public interface IStaffRepository
    {
        public Task<IEnumerable<Staff>> GetAll();

        public Task<Staff> GetById(Guid id);
        public void Add(Staff person);
        public void Update(Staff person);
        public Task Delete(Guid id);

        void Save();
        Task SaveAsync();
    }
}
