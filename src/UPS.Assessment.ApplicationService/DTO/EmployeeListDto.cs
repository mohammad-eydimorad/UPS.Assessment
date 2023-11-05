namespace UPS.Assessment.ApplicationService.DTO
{
    public class EmployeeListDto
    {
        public List<EmployeeDto> Employees { get; set; }
        public PaginationDataDto PaginationData { get; set; }
    }

    public class PaginationDataDto
    {
        public int CurrentPage { get; set;}
        public int Limit { get; set;}
        public int TotalPages { get; set;}
        public int TotalCount { get; set;}
    }
}
