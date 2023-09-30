using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Actron.WebApi.models
{
    public class InputModel
    {
        [Required]
        public List<int> Input { get; set; }
    }
}