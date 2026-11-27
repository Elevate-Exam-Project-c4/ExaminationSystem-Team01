namespace exam_system.Features.Shared
{
    public class PaginationRequest
    {
        private const int MaxPageSize = 100;

        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value <= 0
                ? 10
                : Math.Min(value, MaxPageSize);
        }

        public int Skip => (PageNumber - 1) * PageSize;
    }
}
