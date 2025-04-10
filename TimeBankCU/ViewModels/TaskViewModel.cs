using System.Collections.ObjectModel;
using System.Windows.Input;
using TimeBankCU.Models;
using TimeBankCU.Services;
using TimeBankCU.Views;

namespace TimeBankCU.ViewModels
{
    public class TaskViewModel : BindableObject
    {
        private readonly ITaskStore _taskStore;

        public ObservableCollection<string> MethodOptions { get; } = new() { "Online", "Offline" };
        public ObservableCollection<string> LocationOptions { get; } = new() {             "Coventry University", "CU Coventry", "Coventry University London", "CU London", "CU Scarborough", "Coventry University Wrocław", "National Institute of Teaching and Education (NITE)", 
        };
        public ObservableCollection<string> TimeCreditsOptions { get; } = new() { "Premium Time Credits", "Time Credits" };

        public ObservableCollection<TaskItem> Tasks => _taskStore.Tasks;

        public ICommand MoreFiltersCommand { get; }
        public ICommand TalkCommand { get; }
        public ICommand CreateTaskCommand { get; }

        private string _selectedMethod;
        public string SelectedMethod
        {
            get => _selectedMethod;
            set
            {
                _selectedMethod = value;
                OnPropertyChanged();
            }
        }

        private string _selectedLocation;
        public string SelectedLocation
        {
            get => _selectedLocation;
            set
            {
                _selectedLocation = value;
                OnPropertyChanged();
            }
        }

        private string _selectedTime;
        public string SelectedTime
        {
            get => _selectedTime;
            set
            {
                _selectedTime = value;
                OnPropertyChanged();
            }
        }

        public TaskViewModel(ITaskStore taskStore)
        {
            _taskStore = taskStore;

            MoreFiltersCommand = new Command(OnMoreFilters);
            TalkCommand = new Command<TaskItem>(OnTalk);
            CreateTaskCommand = new Command(ExecuteCreateTask);

            
            _selectedMethod = MethodOptions.FirstOrDefault() ?? string.Empty;
            _selectedLocation = LocationOptions.FirstOrDefault() ?? string.Empty;
            _selectedTime = TimeCreditsOptions .FirstOrDefault() ?? string.Empty;

            
            foreach (var task in _taskStore.Tasks)
                task.TalkCommand = TalkCommand;
        }

        private void OnMoreFilters()
        {
           
            Console.WriteLine("More filters clicked");
        }

        private void OnTalk(TaskItem task)
        {
            
            Console.WriteLine($"Contacting {task.PublisherName} at {task.PublisherEmail}");
        }

        
        private async void ExecuteCreateTask()
        {
            await OnCreateTask();
        }

        private async Task OnCreateTask()
        {
            try
            {
                await Shell.Current.GoToAsync(nameof(CreateTaskPage));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Navigation error: {ex.Message}");
                await Shell.Current.DisplayAlert("Navigation Error", ex.Message, "OK");
            }
        }


    }
}
