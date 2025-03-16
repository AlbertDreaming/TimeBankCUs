using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using TimeBankCU.Models;

namespace TimeBankCU.ViewModels
{
    public class TaskViewModel : BindableObject
    {
        public ObservableCollection<string> MethodOptions { get; set; }
        public ObservableCollection<string> LocationOptions { get; set; }
        public ObservableCollection<string> TimeOptions { get; set; }
        public ObservableCollection<TaskItem> Tasks { get; set; }

        public ICommand MoreFiltersCommand { get; }
        public ICommand TalkCommand { get; }
        public ICommand CreateTaskCommand { get; }

        private string selectedMethod;
        public string SelectedMethod
        {
            get => selectedMethod;
            set
            {
                selectedMethod = value;
                OnPropertyChanged();
            }
        }

        private string selectedLocation;
        public string SelectedLocation
        {
            get => selectedLocation;
            set
            {
                selectedLocation = value;
                OnPropertyChanged();
            }
        }

        private string selectedTime;
        public string SelectedTime
        {
            get => selectedTime;
            set
            {
                selectedTime = value;
                OnPropertyChanged();
            }
        }

        public TaskViewModel()
        {
            MethodOptions = new ObservableCollection<string> { "Online", "Offline" };
            LocationOptions = new ObservableCollection<string> { "Location1", "Location2" };
            TimeOptions = new ObservableCollection<string> { "Morning", "Afternoon", "Evening" };

            Tasks = new ObservableCollection<TaskItem>
            {
                new TaskItem { PublisherName = "John Doe", PublisherEmail = "john@example.com", TaskType = "Type1", Rating = "4.5", Reward = "$100", Participants = "5" },
                new TaskItem { PublisherName = "Jane Smith", PublisherEmail = "jane@example.com", TaskType = "Type2", Rating = "4.0", Reward = "$200", Participants = "3" }
            };

            MoreFiltersCommand = new Command(OnMoreFilters);
            TalkCommand = new Command<TaskItem>(OnTalk);
            CreateTaskCommand = new Command(OnCreateTask);

            // 确保在构造函数退出前初始化所有不可为null的字段
            selectedMethod = MethodOptions.FirstOrDefault() ?? string.Empty;
            selectedLocation = LocationOptions.FirstOrDefault() ?? string.Empty;
            selectedTime = TimeOptions.FirstOrDefault() ?? string.Empty;
        }

        private void OnMoreFilters()
        {
            // Implement more filters functionality here
        }

        private void OnTalk(TaskItem task)
        {
            // Implement talk functionality here
        }

        private void OnCreateTask()
        {
            // Navigate to CreateTaskPage using the new API
            if (Application.Current.Windows.Count > 0)
            {
                Application.Current.Windows[0].Page.Navigation.PushAsync(new Views.CreateTaskPage());
            }
        }
    }
}