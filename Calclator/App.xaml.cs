namespace Calculator {
    using Calculator.View;
    using System.Windows;

    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application {
        private void Application_Startup(object sender, StartupEventArgs e) {
            var view = new MainView();
            view.Show();
        }   
    }
}
