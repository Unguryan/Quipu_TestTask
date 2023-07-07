using Quipu.Core.Services.Interfaces;
using Quipu.UI.Views.UserControls;
using System.Windows.Controls;

namespace Quipu.UI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        //private readonly IValidationService _validationService;
        //private readonly ICalculatingService _calculatingService;

        private UserControl _activeView;

        public MainViewModel(IValidationService validationService, ICalculatingService calculatingService)
        {
            var inputView = new InputView();
            var inputViewModel = new InputViewModel(SetActiveView, validationService, calculatingService);
            inputView.DataContext = inputViewModel;

            SetActiveView(inputView);
        }

        public void SetActiveView(UserControl userControl)
        {
            ActiveView = userControl;
        }

        public UserControl ActiveView
        {
            get
            {
                return _activeView;
            }
            private set
            {
                _activeView = value;
                OnPropertyChanged(nameof(ActiveView));
            }
        }
    }
}
