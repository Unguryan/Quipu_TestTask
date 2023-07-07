using Quipu.Core.Models;
using Quipu.Core.Models.Algorithm;
using Quipu.UI.Commands;
using Quipu.UI.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Windows.Controls;
using System.Windows.Input;

namespace Quipu.UI.ViewModels
{
    public class ResultViewModel
    {
        private readonly Action<UserControl> _changeViewAction;
        private readonly InputViewModel _inputViewModel;
        private readonly Deposit _deposit;

        public ResultViewModel(Action<UserControl> changeViewAction,
                               InputViewModel inputViewModel,
                               Deposit deposit)
        {
            _changeViewAction = changeViewAction;
            _inputViewModel = inputViewModel;
            _deposit = deposit;

            InputData = _deposit.InputData;
            AccumulatedAmount = _deposit.AccumulatedAmount;
            EndAmount = _deposit.EndAmount;
            MonthPayments = _deposit.MonthPayments;

            BackCommand = new RelayCommand((_) => Back());
        }
        public ICommand BackCommand { get; }


        public InputData InputData { get; }

        public double AccumulatedAmount { get; }

        public double EndAmount { get; }

        public IEnumerable<MonthPayment> MonthPayments { get; }

        private void Back()
        {
            var view = new InputView();
            view.DataContext = _inputViewModel;
            _changeViewAction.Invoke(view);
        }
    }
}
