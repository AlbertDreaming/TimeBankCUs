using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace TimeBankCU.ViewModels
{
    public class MeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public string UserName { get; set; } = "Nike D";

        public string Avatar { get; set; } =
            "https://cdn-icons-png.flaticon.com/512/616/616408.png"; // 可替换为本地路径或绑定用户头像

        public int PremiumCredits { get; set; } = 60;

        public int TotalCredits { get; set; } = 1050;

        public ObservableCollection<string> Skills { get; set; } = new()
        {
            "Math Tutoring", "Experimental skill training"
        };

        public ICommand AddSkillCommand { get; }

        public MeViewModel()
        {
            AddSkillCommand = new Command(OnAddSkill);
        }

        private async void OnAddSkill()
        {
            try
            {
                string result = await Shell.Current.DisplayPromptAsync("New Skill", "Enter a skill you're good at:");
                if (!string.IsNullOrWhiteSpace(result))
                {
                    Skills.Add(result.Trim());
                    Console.WriteLine($"✅ Skill added: {result.Trim()}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Failed to add skill: {ex.Message}");
                await Shell.Current.DisplayAlert("Error", "Failed to add skill. Please try again.", "OK");
            }
        }
    }
}