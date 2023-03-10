namespace Application.Dtos
{
    public class EnterpriseDto : BaseEntityDto
    {
        public string Address { get; set; }
        public string Name { get; set; }

        public string Phone { get; set; }
        public string DepartmentNames { get; set; }
    }
}
