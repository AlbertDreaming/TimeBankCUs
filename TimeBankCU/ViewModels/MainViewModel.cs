using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using TimeBankCU.Models;

namespace TimeBankCU.ViewModels
{
    public class MainViewModel : BindableObject
    {
        public ObservableCollection<CarouselItem> CarouselItems { get; set; }
        public ObservableCollection<TaskItem> TaskItems { get; set; }

        public ICommand SearchCommand { get; }
        public ICommand NavigateCommand { get; }

        private string _searchQuery;
        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                _searchQuery = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            _searchQuery = string.Empty; // 初始化 _searchQuery

            CarouselItems = new ObservableCollection<CarouselItem>
            {
                new CarouselItem { ImageUrl = "https://example.com/image1.jpg" },
                new CarouselItem { ImageUrl = "https://example.com/image2.jpg" }
            };

            TaskItems = new ObservableCollection<TaskItem>
            {
                new TaskItem { PublisherName = "John Doe", PublisherEmail = "john@example.com", TaskType = "Type1", Rating = "4.5", Reward = "$100", Participants = "5" },
                new TaskItem { PublisherName = "Jane Smith", PublisherEmail = "jane@example.com", TaskType = "Type2", Rating = "4.0", Reward = "$200", Participants = "3" }
            };

            SearchCommand = new Command(OnSearch);
            NavigateCommand = new Command<string>(OnNavigate);
        }

        private void OnSearch()
        {
            // Implement search functionality here
        }

        private void OnNavigate(string destination)
        {
            // Implement navigation functionality here
        }
    }
}