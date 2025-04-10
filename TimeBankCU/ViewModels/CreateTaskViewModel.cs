using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TimeBankCU.Models;
using TimeBankCU.Services;

namespace TimeBankCU.ViewModels
{
    public class CreateTaskViewModel : BindableObject
    {
        private readonly ITaskStore _taskStore;

        public string TaskTitle { get; set; } = string.Empty;
        public string TaskDetails { get; set; } = string.Empty;
        public string Reward { get; set; } = string.Empty;
        public string Participants { get; set; } = string.Empty;
        public string SelectedCampus { get; set; } = string.Empty;

        public ObservableCollection<string> CampusAreas { get; } = new()
        {
            "Coventry University", "CU Coventry", "Coventry University London", "CU London", "CU Scarborough", "Coventry University Wrocław", "National Institute of Teaching and Education (NITE)", 
        };

        public ICommand ReleaseCommand { get; }
        public ICommand UploadFileCommand { get; }

        public CreateTaskViewModel(ITaskStore taskStore)
        {
            _taskStore = taskStore;

            // ✅ Avoid async lambda in Command
            ReleaseCommand = new Command(ExecuteRelease);
            UploadFileCommand = new Command(OnUploadFile);
        }

        public bool IsFormValid =>
            !string.IsNullOrWhiteSpace(TaskTitle) &&
            !string.IsNullOrWhiteSpace(TaskDetails) &&
            !string.IsNullOrWhiteSpace(Reward) &&
            !string.IsNullOrWhiteSpace(Participants) &&
            !string.IsNullOrWhiteSpace(SelectedCampus);

        private async void ExecuteRelease()
        {
            try
            {
                await OnRelease();
                Console.WriteLine("✅ Release button clicked");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ ExecuteRelease Error: {ex.Message}");
            }
        }

        private async System.Threading.Tasks.Task OnRelease()
        {
            try
            {
                if (!IsFormValid)
                {
                    Console.WriteLine("⚠️ Form is incomplete.");
                    return;
                }

                var task = new TaskItem
                {
                    Title = TaskTitle,
                    TaskDetails = TaskDetails,
                    Reward = Reward,
                    Participants = Participants,
                    PublisherName = "Current User",
                    PublisherEmail = "user@example.com",
                    Campus = SelectedCampus
                };

                _taskStore.Add(task);

                Console.WriteLine("✅ Task added to store. Navigating back...");

                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ OnRelease Error: {ex.Message}");
            }
        }

        private void OnUploadFile()
        {
            Console.WriteLine("📎 Upload file triggered.");
        }
    }
}
