using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actron.WebApi.CustomExceptions
{
    public class InvalidInputException: Exception
    {
        public InvalidInputException(): base("Invalid input array [non-positive integers or empty array]")
        {
        }
    }
}