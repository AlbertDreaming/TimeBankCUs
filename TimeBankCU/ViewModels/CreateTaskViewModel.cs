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

        private string selectedCampus;
        public string SelectedCampus
        {
            get => selectedCampus;
            set
            {
                selectedCampus = value;
                OnPropertyChanged();
            }
        }

        private string taskTitle;
        public string TaskTitle
        {
            get => taskTitle;
            set
            {
                taskTitle = value;
                OnPropertyChanged();
            }
        }

        private string reward;
        public string Reward
        {
            get => reward;
            set
            {
                reward = value;
                OnPropertyChanged();
            }
        }

        private string participants;
        public string Participants
        {
            get => participants;
            set
            {
                participants = value;
                OnPropertyChanged();
            }
        }

        private string taskDetails;
        public string TaskDetails
        {
            get => taskDetails;
            set
            {
                taskDetails = value;
                OnPropertyChanged();
            }
        }

        public CreateTaskViewModel()
        {
            CampusAreas = new ObservableCollection<string> { "Campus1", "Campus2" };
            UploadFileCommand = new Command(OnUploadFile);
            ReleaseCommand = new Command(OnRelease);

            // 确保在构造函数退出前初始化所有不可为null的字段
            selectedCampus = CampusAreas.FirstOrDefault() ?? string.Empty;
            taskTitle = string.Empty;
            reward = string.Empty;
            participants = string.Empty;
            taskDetails = string.Empty;
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
                TaskType = taskTitle,
                Rating = "0", // 初始评分为0
                Reward = reward,
                Participants = participants,
                TaskDetails = taskDetails
            };

            // 获取 TaskViewModel 实例并添加新任务
            var taskPage = Shell.Current.FindByName<NavigationPage>("TaskPage");
            if (taskPage?.CurrentPage?.BindingContext is TaskViewModel taskViewModel)
            {
                taskViewModel.Tasks.Add(newTask);
            }

            // 导航回 TaskPage
            if (Application.Current.Windows.Count > 0)
            {
                await Application.Current.Windows[0].Page.Navigation.PopAsync();
            }
        }
    }
}