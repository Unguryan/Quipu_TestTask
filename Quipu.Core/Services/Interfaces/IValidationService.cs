using Quipu.Core.Models.Algorithm;

namespace Quipu.Core.Services.Interfaces
{
    public interface IValidationService
    {
        bool ValidateInput(InputData inputData);
    }
}
