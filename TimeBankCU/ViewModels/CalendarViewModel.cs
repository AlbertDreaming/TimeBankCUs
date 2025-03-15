using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace TimeBankCU.ViewModels
{
    public class CalendarViewModel : BindableObject
    {
        public string CurrentMonth { get; set; }
        public ObservableCollection<Day> Days { get; set; }
        public ICommand PreviousMonthCommand { get; }
        public ICommand NextMonthCommand { get; }
        public ICommand AddEventCommand { get; }

        public CalendarViewModel()
        {
            CurrentMonth = "March 2025";
            Days = new ObservableCollection<Day>
            {
                new Day { Date = "1", Events = new ObservableCollection<Event> { new Event { Title = "Event 1" } } },
                new Day { Date = "2", Events = new ObservableCollection<Event> { new Event { Title = "Event 2" } } }
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
        public string Date { get; set; }
        public ObservableCollection<Event> Events { get; set; }
    }

    public class Event
    {
        public string Title { get; set; }
    }
}