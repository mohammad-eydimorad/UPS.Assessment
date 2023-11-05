namespace UPS.Assessment.ApplicationService.DTO
{
    public record PaginationDto(int CurrentPage, int Limit, int TotalPages, int TotalCount);
}
