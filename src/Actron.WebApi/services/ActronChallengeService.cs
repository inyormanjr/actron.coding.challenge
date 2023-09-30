using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actron.WebApi.services
{
    public class ActronChallengeService
    {
        public string FormLargestInt(List<int> input)
        {
            if (input == null || input.Count == 0 || input.Any(x => x <= 0))
            {
                throw new ArgumentException("Invalid input array [non-positive integers or empty array]");
            }
            string[] numberString = input.Select(x => x.ToString()).ToArray();
            Array.Sort(numberString, (x, y) => (y + x).CompareTo(x + y));
            var result = string.Join("", numberString);
            return result;
        }
    }
}