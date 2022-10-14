namespace Api_AngularTestProject
{
    public class Staff
    {
        public Guid Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string adress { get; set; }
        public int departmentId { get; set; }
        public Department? Department { get; set; }
    }
}
