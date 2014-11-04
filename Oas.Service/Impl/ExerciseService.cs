using Oas.Infrastructure;
using Oas.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
