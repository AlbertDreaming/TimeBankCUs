using TimeBankCU.ViewModels;

namespace TimeBankCU.Views
{
    public partial class CreateTaskPage : ContentPage
    {
        public CreateTaskPage(CreateTaskViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}