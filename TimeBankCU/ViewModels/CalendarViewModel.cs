using System.Collections.ObjectModel;
using System.Windows.Input;


namespace TimeBankCU.ViewModels
{
    public class CalendarViewModel : BindableObject
    {
        private string _currentMonth = string.Empty;  // 初始化字段
        public string CurrentMonth
        {
            get => _currentMonth;
            set
            {
                _currentMonth = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Day> Days { get; set; }
        public ICommand PreviousMonthCommand { get; }
        public ICommand NextMonthCommand { get; }
        public ICommand AddEventCommand { get; }

        public CalendarViewModel()
        {
            CurrentMonth = "March 2025";
            Days = new ObservableCollection<Day>
            {
                new Day { Date = new DateTime(2025, 3, 1), Events = new ObservableCollection<Event> { new Event { Title = "Event 1" } } },
                new Day { Date = new DateTime(2025, 3, 2), Events = new ObservableCollection<Event> { new Event { Title = "Event 2" } } }
            };

            PreviousMonthCommand = new Command(OnPreviousMonth);
            NextMonthCommand = new Command(OnNextMonth);
            AddEventCommand = new Command(OnAddEvent);
        }

        private void OnPreviousMonth()
        {
            // Implement previous month functionality here
        }

        private void OnNextMonth()
        {
            // Implement next month functionality here
        }

        private void OnAddEvent()
        {
            // Implement add event functionality here
        }
    }

    public class Day
    {
        public DateTime Date { get; set; }
        public ObservableCollection<Event> Events { get; set; } = new();
    }

    public class Event
    {
        public string Title { get; set; } = string.Empty; // 初始化属性
    }
}