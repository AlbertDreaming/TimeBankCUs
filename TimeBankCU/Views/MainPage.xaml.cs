using TimeBankCU.ViewModels;

namespace TimeBankCU.Views
{
    public partial class MainPage
    {
        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}