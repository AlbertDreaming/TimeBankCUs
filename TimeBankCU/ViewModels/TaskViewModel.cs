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

        public TaskViewModel()
        {
            MethodOptions = new ObservableCollection<string> { "Online", "Offline" };
            LocationOptions = new ObservableCollection<string> { "Location1", "Location2" };
            TimeOptions = new ObservableCollection<string> { "Morning", "Afternoon", "Evening" };

            Tasks = new ObservableCollection<TaskItem>
            {
                new TaskItem { PublisherName = "John Doe", PublisherEmail = "john@example.com", TaskType = "Type1", Reward = "$100", Participants = "5", TaskDetails = "Details1", Campus = "Campus1" },
                new TaskItem { PublisherName = "Jane Smith", PublisherEmail = "jane@example.com", TaskType = "Type2", Reward = "$200", Participants = "3", TaskDetails = "Details2", Campus = "Campus2" }
            };

            MoreFiltersCommand = new Command(OnMoreFilters);
            TalkCommand = new Command<TaskItem>(OnTalk);
            CreateTaskCommand = new Command(OnCreateTask);

            // 确保在构造函数退出前初始化所有不可为null的字段
            _selectedMethod = MethodOptions.FirstOrDefault() ?? string.Empty;
            _selectedLocation = LocationOptions.FirstOrDefault() ?? string.Empty;
            _selectedTime = TimeOptions.FirstOrDefault() ?? string.Empty;
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
            // 检查 Application.Current 和 Application.Current.Windows 是否为 null
            if (Application.Current?.Windows?.Count > 0 && Application.Current.Windows[0]?.Page != null)
            {
                Application.Current.Windows[0].Page.Navigation.PushAsync(new Views.CreateTaskPage());
            }
            else
            {
                // 处理可能的 null 引用情况，例如记录日志或显示错误消息
                Console.WriteLine("Navigation failed: Application.Current or Application.Current.Windows is null.");
            }
        }
    }
}