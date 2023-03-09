namespace Application.Dtos
{
    public class PagedResponseDto<T>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }
        public int PageCount { get; set; }
        public List<T> Results { get; set; }

        public PagedResponseDto()
        {
            Results = new List<T>();
        }
    }
}
