using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TimeBankCU.Models;

namespace TimeBankCU.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        // 🔍 Search
        private string _searchQuery = string.Empty;
        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                _searchQuery = value;
                OnPropertyChanged();
            }
        }

        public ICommand SearchCommand { get; }

        private void OnSearch()
        {
            Console.WriteLine($"Search triggered: {SearchQuery}");
        }

        // 🖼️ Carousel images (top1, top2, etc.)
        public ObservableCollection<CarouselItem> CarouselItems { get; set; } = new()
        {
            new CarouselItem { ImageUrl = "top1" },
            new CarouselItem { ImageUrl = "top2" },
            new CarouselItem { ImageUrl = "top3" }
        };

        // 📤 Quick icon bar (Emoji)
        public ObservableCollection<QuickIcon> QuickIcons { get; set; } = new()
        {
            new QuickIcon { Emoji = "📤", Label = "Share" },
            new QuickIcon { Emoji = "📚", Label = "" },
            new QuickIcon { Emoji = "💡", Label = "" },
            new QuickIcon { Emoji = "🛠", Label = "" },
            new QuickIcon { Emoji = "🗂", Label = "" }
        };

        // 🧭 Tab switching
        private string _selectedTab = "Guide";
        public string SelectedTab
        {
            get => _selectedTab;
            set
            {
                if (_selectedTab != value)
                {
                    _selectedTab = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand SwitchTabCommand { get; }

        private void OnSwitchTab(string tabName)
        {
            SelectedTab = tabName;
        }

        // 📋 Suggest - task list
        public ObservableCollection<TaskItem> TaskItems { get; set; } = new()
        {
            new TaskItem
            {
                PublisherName = "Albert",
                PublisherEmail = "albert@coventry.ac.uk",
                Title = "Report Writing",
                Reward = "200T",
                Participants = "10 person",
                Rating = "5.0",
                TaskType = "Online",
                TalkCommand = new Command(() => Console.WriteLine("Talk to Albert"))
            },
            new TaskItem
            {
                PublisherName = "Emma",
                PublisherEmail = "emma@example.com",
                Title = "Design Support",
                Reward = "100T",
                Participants = "3 person",
                Rating = "4.7",
                TaskType = "Offline",
                TalkCommand = new Command(() => Console.WriteLine("Talk to Emma"))
            }
        };

        // 💬 Experience - emoji share cards
        public ObservableCollection<ExperienceItem> Experiences { get; set; } = new()
        {
            new ExperienceItem
            {
                Emoji = "🌟",
                Title = "My experience with Task",
                Description = "Impressive experience!!！！！！！！"
            },
            new ExperienceItem
            {
                Emoji = "📝",
                Title = "Translation for classmates",
                Description = "Helped others and earned time credits. Great feeling!"
            }
        };

        public MainViewModel()
        {
            SearchCommand = new Command(OnSearch);
            SwitchTabCommand = new Command<string>(OnSwitchTab);
        }
    }

    // Models
    public class QuickIcon
    {
        public string Emoji { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
    }

    public class ExperienceItem
    {
        public string Emoji { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
