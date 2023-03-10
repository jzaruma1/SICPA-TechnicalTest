namespace Application.Dtos
{
    public class EmployeeDto : BaseEntityDto
    {
        public int Age { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Surname { get; set; }
        public string DepartmentNames { get; set; }
        public List<int> Departments { get; set; }
    }
}
