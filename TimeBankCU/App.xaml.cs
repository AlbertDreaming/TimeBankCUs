using Microsoft.Maui.Controls;

namespace TimeBankCU
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // 设置主页面为导航页面，其中包含TaskPage
            MainPage = new NavigationPage(new Views.TaskPage());
        }
    }
}