using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace TimeBankCU.ViewModels
{
    public class MeViewModel : BindableObject
    {
        public string UserAvatar { get; set; }
        public string UserName { get; set; }
        public string UserSkills { get; set; }
        public ObservableCollection<Task> MyTasks { get; set; }
        public ObservableCollection<SearchHistory> SearchingHistory { get; set; }
        public string TimeCredits { get; set; }

        public ICommand AddSkillCommand { get; }
        public ICommand NavigateCommand { get; }
        public ICommand LogoutCommand { get; }

        public MeViewModel()
        {
            UserAvatar = "https://example.com/avatar.jpg";
            UserName = "John Doe";
            UserSkills = "C#, XAML, MAUI";
            MyTasks = new ObservableCollection<Task>
            {
                new Task { TaskName = "Task 1" },
                new Task { TaskName = "Task 2" }
            };
            SearchingHistory = new ObservableCollection<SearchHistory>
            {
                new SearchHistory { SearchTerm = "Search 1" },
                new SearchHistory { SearchTerm = "Search 2" }
            };
            TimeCredits = "100";

            AddSkillCommand = new Command(OnAddSkill);
            NavigateCommand = new Command<string>(OnNavigate);
            LogoutCommand = new Command(OnLogout);
        }

        private void OnAddSkill()
        {
            // Implement add skill functionality here
        }

        private void OnNavigate(string destination)
        {
            // Temporarily do nothing as a placeholder for real navigation
        }

        private void OnLogout()
        {
            // Implement logout functionality here
        }
    }

    public class Task
    {
        public string TaskName { get; set; }
    }

    public class SearchHistory
    {
        public string SearchTerm { get; set; }
    }
}