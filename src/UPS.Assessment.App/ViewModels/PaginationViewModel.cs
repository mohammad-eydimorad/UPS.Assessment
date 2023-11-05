using UPS.Assessment.ApplicationService.DTO;

namespace UPS.Assessment.App.ViewModels
{
    public class PaginationViewModel: BaseViewModel
    {
        public PaginationViewModel(PaginationDto pagination)
        {
            TotalCount = pagination.TotalCount;
            Limit = pagination.Limit;
            CurrentPage = pagination.CurrentPage;
            TotalPages = pagination.TotalPages;
        }

        public int TotalCount { get;private set; }
        public int Limit { get; private set; }
        private int _currentPage = 1;
        public int CurrentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                _currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
            }
        }

        public int TotalPages { get; private set; }
    }
}
