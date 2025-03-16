using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using TimeBankCU.Models;

namespace TimeBankCU.ViewModels
{
    public class CreateTaskViewModel : BindableObject
    {
        public ObservableCollection<string> CampusAreas { get; set; }

        public ICommand UploadFileCommand { get; }
        public ICommand ReleaseCommand { get; }

        private string _selectedCampus;
        public string SelectedCampus
        {
            get => _selectedCampus;
            set
            {
                _selectedCampus = value;
                OnPropertyChanged();
            }
        }

        private string _taskTitle;
        public string TaskTitle
        {
            get => _taskTitle;
            set
            {
                _taskTitle = value;
                OnPropertyChanged();
            }
        }

        private string _reward;
        public string Reward
        {
            get => _reward;
            set
            {
                _reward = value;
                OnPropertyChanged();
            }
        }

        private string _participants;
        public string Participants
        {
            get => _participants;
            set
            {
                _participants = value;
                OnPropertyChanged();
            }
        }

        private string _taskDetails;
        public string TaskDetails
        {
            get => _taskDetails;
            set
            {
                _taskDetails = value;
                OnPropertyChanged();
            }
        }

        public CreateTaskViewModel()
        {
            CampusAreas = new ObservableCollection<string> { "Campus1", "Campus2" };
            UploadFileCommand = new Command(OnUploadFile);
            ReleaseCommand = new Command(OnRelease);

            // 确保在构造函数退出前初始化所有不可为null的字段
            _selectedCampus = string.Empty;
            _taskTitle = string.Empty;
            _reward = string.Empty;
            _participants = string.Empty;
            _taskDetails = string.Empty;
        }

        private void OnUploadFile()
        {
            // Implement file upload functionality here
        }

        private async void OnRelease()
        {
            // 创建新任务
            var newTask = new TaskItem
            {
                PublisherName = "Current User", // 替换为实际发布者信息
                PublisherEmail = "user@example.com", // 替换为实际发布者邮箱
                TaskType = _taskTitle,
                Reward = _reward,
                Participants = _participants,
                TaskDetails = _taskDetails,
                Campus = _selectedCampus,
                Title = _taskTitle,
                Description = _taskDetails
            };

            // 获取 TaskViewModel 实例并添加新任务
            var taskPage = Shell.Current.FindByName<NavigationPage>("TaskPage");
            if (taskPage?.CurrentPage?.BindingContext is TaskViewModel taskViewModel)
            {
                taskViewModel.Tasks.Add(newTask);
            }

            // 导航回 TaskPage
            if (Application.Current?.Windows?.Count > 0 && Application.Current.Windows[0]?.Page != null)
            {
                await Application.Current.Windows[0].Page.Navigation.PopAsync();
            }
            else
            {
                // 处理可能的 null 引用情况，例如记录日志或显示错误消息
                Console.WriteLine("Navigation failed: Application.Current or Application.Current.Windows is null.");
            }
        }
    }
}