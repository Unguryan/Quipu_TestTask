using Quipu.Core.Models.Algorithm;
using Quipu.Core.Services.Interfaces;

namespace Quipu.Core.Services
{
    class ValidationService : IValidationService
    {
        //Error message can be added. Or can use FluentValidation instead.
        public bool ValidateInput(InputData inputData/*, out string? errorMessage*/)
        {
            if(inputData == null)
            {
                return false;
            }

            if(inputData.MonthCount == 0)
            {
                return false;
            }

            if (inputData.PercentagePerYear <= 0 || inputData.PercentagePerYear > 100)
            {
                return false;
            }

            if(inputData.StartAmount <= 0)
            {
                return false;
            }

            return true;    
        }
    }
}
