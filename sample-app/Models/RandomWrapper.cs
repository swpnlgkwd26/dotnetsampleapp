using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app.Models
{
    public class RandomWrapper : IRandomWrapper
    {
        private readonly IRandomService _randomService;

        public RandomWrapper(IRandomService randomService)
        {
            _randomService = randomService;
        }
        public int GetRandomNumberFromRandomService()
        {
           return _randomService.GetNumber();
        }
    }
}
