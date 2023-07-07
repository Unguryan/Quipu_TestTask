namespace Quipu.Core.Models
{
    public class MonthPayment
    {
        public MonthPayment(int month, double currentAmount, double accomulatedAmount)
        {
            Month = month;
            CurrentAmount = currentAmount;
            AccomulatedAmount = accomulatedAmount;
        }

        public int Month { get; }

        public double CurrentAmount { get; }

        public double AccomulatedAmount { get; }
    }
}
