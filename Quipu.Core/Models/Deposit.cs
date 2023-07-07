using System.Collections.Generic;

namespace Quipu.Core.Models
{
    public class Deposit
    {
        public Deposit(double startAmount,
                       double percentagePerYear,
                       PayoutType type,
                       int monthCount,
                       double accumulatedAmount,
                       double endAmount,
                       IEnumerable<MonthPayment> monthPayments)
        {
            StartAmount = startAmount;
            PercentagePerYear = percentagePerYear;
            Type = type;
            MonthCount = monthCount;
            AccumulatedAmount = accumulatedAmount;
            EndAmount = endAmount;
            MonthPayments = monthPayments;
        }

        public double StartAmount { get; }

        public double PercentagePerYear { get; }

        public PayoutType Type { get; }

        public int MonthCount { get; }

        public double AccumulatedAmount { get; }

        public double EndAmount { get; }

        public IEnumerable<MonthPayment> MonthPayments { get; }
    }
}
