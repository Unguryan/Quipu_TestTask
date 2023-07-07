namespace Quipu.Core.Models.Algorithm
{
    public class InputData
    {
        public InputData(double startAmount, double percentagePerYear, PayoutType type, int monthCount)
        {
            StartAmount = startAmount;
            PercentagePerYear = percentagePerYear;
            Type = type;
            MonthCount = monthCount;
        }

        public double StartAmount { get; }

        public double PercentagePerYear { get; }

        public PayoutType Type { get; }

        public int MonthCount { get; }
    }
}
