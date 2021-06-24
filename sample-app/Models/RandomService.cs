using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app.Models
{
    public class RandomService : IRandomService
    {
        // Code to generate a random number
        private int _randomNumber;

        public RandomService()
        {
            // Built in Class
            Random random = new Random();
            _randomNumber = random.Next(100000);
        }
        // Returning the Random Number
        public int GetNumber()
        {
            return _randomNumber;
        }
    }
}
