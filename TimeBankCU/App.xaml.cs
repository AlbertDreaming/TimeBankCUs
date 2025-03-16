using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace TimeBankCU
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState) // 确保使用可空类型
        {
            var window = new Window(new NavigationPage(new Views.TaskPage()));
            return window;
        }
    }
}