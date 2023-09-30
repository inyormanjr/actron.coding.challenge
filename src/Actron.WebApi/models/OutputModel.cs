using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Actron.WebApi.models
{
    public class OutputModel
    {
        [Required]
        public string Output { get; set; }
    }
}