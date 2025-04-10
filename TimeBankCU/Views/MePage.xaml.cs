using TimeBankCU.ViewModels;

namespace TimeBankCU.Views
{
    public partial class MePage
    {
        public MePage(MeViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}