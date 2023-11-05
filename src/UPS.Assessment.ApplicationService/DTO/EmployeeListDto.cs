namespace UPS.Assessment.ApplicationService.DTO
{
    public class EmployeeListDto
    {
        public List<EmployeeDto> Employees { get; set; } = new List<EmployeeDto>();
        public PaginationDto PaginationData { get; set; } = new PaginationDto(1, 10, 1, 1);
    }
}
