using TimeBankCU.ViewModels;

namespace TimeBankCU.Views
{
    public partial class MePage : ContentPage
    {
        public MePage()  // 改成无参构造函数
        {
            InitializeComponent();
            BindingContext = new MeViewModel();  // 强制使用你手动构造的
        }

    }
}