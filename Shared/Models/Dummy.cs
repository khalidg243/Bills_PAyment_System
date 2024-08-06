using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPS_Shared.Models
{
    public class Dummy
    {
        [Required]
        public string Email { get; set; }
        [StringLength(50, ErrorMessage = "Name length can't be more than 30.", MinimumLength = 8)]
        public string Password { get; set; }
    }
}
