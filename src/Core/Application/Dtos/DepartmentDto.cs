namespace Application.Dtos
{
    public class DepartmentDto: BaseEntityDto
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int EnterpriseId { get; set; }
    }
}
