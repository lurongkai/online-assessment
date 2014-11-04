using Oas.Infrastructure;
using Oas.Service.Interfaces;

namespace Oas.Service.Impl
{
    public class ExerciseService : IExerciseService
    {
        private OasContext _oasContext;

        public ExerciseService(OasContext oasContext) {
            _oasContext = oasContext;
        }
    }
}