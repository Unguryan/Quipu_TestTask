using Quipu.Core.Models;
using Quipu.Core.Models.Algorithm;
using Quipu.Core.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Quipu.Core.Services
{
    class CalculatingService : ICalculatingService
    {
        public Deposit Calculate(InputData inputData)
        {
            var accomulatedList = new List<MonthPayment>();
            var percentagePerMonth = inputData.PercentagePerYear / (12 * 100);
            var temp = inputData.StartAmount;
            var accomulated = 0.0d;

            for (int i = 0; i < inputData.MonthCount; i++)
            {
                var monthAccomulated = Math.Round(temp * percentagePerMonth, 2);

                accomulated += monthAccomulated;

                if(inputData.Type == PayoutType.Capitalization)
                {
                    temp = Math.Round(temp + monthAccomulated, 2);
                }

                accomulatedList.Add(new MonthPayment(i + 1, temp, monthAccomulated));
            }

            return new Deposit(inputData, accomulated, temp, accomulatedList);
        }
    }
}
