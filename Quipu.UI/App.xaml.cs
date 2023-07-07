using Quipu.UI.Views;
using System.Windows;

namespace Quipu.UI
{
    public partial class App : Application
    {
        readonly MainWindow _mainWindow;

        public App(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _mainWindow.Show(); 
            base.OnStartup(e);
        }
    }
}
