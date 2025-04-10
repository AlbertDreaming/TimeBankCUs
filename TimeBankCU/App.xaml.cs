

namespace TimeBankCU
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState) // 确保使用可空类型
        {
            var window = new Window(new AppShell()); // 使用 AppShell 作为根页面
            return window;
        }
    }
}