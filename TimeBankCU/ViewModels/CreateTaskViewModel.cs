using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;

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

        private void OnRelease()
        {
            // Implement task release functionality here
        }
    }
}