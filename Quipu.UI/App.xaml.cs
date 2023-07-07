using Quipu.Core.Services.Interfaces;
using Quipu.UI.ViewModels;
using Quipu.UI.Views;
using System.Windows;

namespace Quipu.UI
{
    public partial class App : Application
    {
        private readonly IValidationService _validationService;
        private readonly ICalculatingService _calculatingService;

        private readonly MainWindow _mainWindow;

        public App(IValidationService validationService,
                   ICalculatingService calculatingService,
                   MainWindow mainWindow)
        {
            _validationService = validationService;
            _calculatingService = calculatingService;

            _mainWindow = mainWindow;
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            var mainViewModel = new MainViewModel(_validationService, _calculatingService);
            _mainWindow.DataContext = mainViewModel;
            _mainWindow.Show();

            base.OnStartup(e);
        }
    }
}
