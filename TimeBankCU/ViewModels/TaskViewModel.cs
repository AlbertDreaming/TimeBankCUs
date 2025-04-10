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
        public ObservableCollection<string> LocationOptions { get; } = new() { "Location1", "Location2" };
        public ObservableCollection<string> TimeOptions { get; } = new() { "Morning", "Afternoon", "Evening" };

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
            _selectedTime = TimeOptions.FirstOrDefault() ?? string.Empty;

            
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

        private async System.Threading.Tasks.Task OnCreateTask()
        {
            try
            {
                var page = Helpers.ServiceHelper.GetService<CreateTaskPage>();
                await Shell.Current.Navigation.PushAsync(page);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Navigation error: {ex.Message}");
            }
        }
    }
}
