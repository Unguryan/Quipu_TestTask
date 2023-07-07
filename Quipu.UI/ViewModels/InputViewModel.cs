using Quipu.Core.Models;
using Quipu.Core.Models.Algorithm;
using Quipu.Core.Services.Interfaces;
using Quipu.UI.Commands;
using Quipu.UI.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Quipu.UI.ViewModels
{
    public class InputViewModel : ViewModelBase
    {
        private readonly Action<UserControl> _changeViewAction;
        private readonly IValidationService _validationService;
        private readonly ICalculatingService _calculatingService;

        private double _startAmount;
        private double _percentagePerYear;
        private string _selectedType;
        private int _monthCount;
        private Deposit _lastCalculated;

        public InputViewModel(Action<UserControl> changeViewAction,
                              IValidationService validationService,
                              ICalculatingService calculatingService)
        {
            _changeViewAction = changeViewAction;
            _validationService = validationService;
            _calculatingService = calculatingService;

            CalculateCommand = new RelayCommand((_) => Calculate());
            ShowResultsCommand = new RelayCommand((_) => ShowResults());
            ClearCommand = new RelayCommand((_) => Clear());
            Types = Enum.GetNames(typeof(PayoutType));
        }
        

        public ICommand CalculateCommand { get; }
        public ICommand ShowResultsCommand { get; }
        public ICommand ClearCommand { get; }


        public double StartAmount
        {
            get => _startAmount;
            set
            {
                _startAmount = value;
                OnPropertyChanged(nameof(StartAmount));
            }
        }

        public double PercentagePerYear
        {
            get => _percentagePerYear;
            set
            {
                _percentagePerYear = value;
                OnPropertyChanged(nameof(PercentagePerYear));
            }
        }

        public IEnumerable<string> Types { get; }

        public string SelectedType
        {
            get => _selectedType;
            set
            {
                _selectedType = value;
                OnPropertyChanged(nameof(SelectedType));
            }
        }

        public int MonthCount
        {
            get => _monthCount;
            set
            {
                _monthCount = value;
                OnPropertyChanged(nameof(MonthCount));
            }
        }

        public bool IsResultsAvailable => _lastCalculated != null;

        private void Calculate()
        {
            var inputData = CreateInputData();
            if (!_validationService.ValidateInput(inputData))
            {
                MessageBox.Show("Validation Error", "Error", MessageBoxButton.OK);
                return;
            }

            _lastCalculated = _calculatingService.Calculate(inputData);
            OnPropertyChanged(nameof(IsResultsAvailable));
            MessageBox.Show("Success.\nClick \"Show\" to see results.", "Success", MessageBoxButton.OK);
        }

        private void ShowResults()
        {
            var resultsView = new ResultView();
            var resultViewModel = new ResultViewModel(_changeViewAction, this, _lastCalculated);
            resultsView.DataContext = resultViewModel;
            _changeViewAction.Invoke(resultsView);
        }

        private void Clear()
        {
            StartAmount = 0;
            PercentagePerYear = 0;
            SelectedType = string.Empty;
            MonthCount = 0;
            _lastCalculated = null;
            OnPropertyChanged(nameof(IsResultsAvailable));
        }

        private InputData CreateInputData()
        {
            Enum.TryParse(SelectedType, out PayoutType type);
            return new InputData(StartAmount, PercentagePerYear, type, MonthCount);
        }
    }
}
