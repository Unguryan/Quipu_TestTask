using Quipu.Core.Models.Algorithm;
using System.Collections.Generic;

namespace Quipu.Core.Models
{
    public class Deposit
    {
        public Deposit(InputData inputData,
                       double accumulatedAmount,
                       double endAmount,
                       IEnumerable<MonthPayment> monthPayments)
        {
            InputData = inputData;
            AccumulatedAmount = accumulatedAmount;
            EndAmount = endAmount;
            MonthPayments = monthPayments;
        }

        public InputData InputData { get; }

        public double AccumulatedAmount { get; }

        public double EndAmount { get; }

        public IEnumerable<MonthPayment> MonthPayments { get; }
    }
}
