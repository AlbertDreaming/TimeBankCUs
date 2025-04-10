using TimeBankCU.ViewModels;

namespace TimeBankCU.Views
{
    public partial class CalendarPage
    {
        public CalendarPage(CalendarViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}