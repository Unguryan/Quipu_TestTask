using Quipu.Core.Models;
using Quipu.Core.Models.Algorithm;

namespace Quipu.Core.Services.Interfaces
{
    public interface ICalculatingService
    {
        Deposit Calculate(InputData inputData);
    }
}
