using TimeBankCU.ViewModels;

namespace TimeBankCU.Views
{
    public partial class TaskPage : ContentPage
    {
        public TaskPage(TaskViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}