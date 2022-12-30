using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BizLand.Models
{
    [Index(nameof(Twitter), IsUnique = true)]
    [Index(nameof(Facebook), IsUnique = true)]
    [Index(nameof(Instagram), IsUnique = true)]
    [Index(nameof(Linkedin), IsUnique = true)]
    public class Employee
    {
        public int Id { get; set; }
        [MinLength(2),MaxLength(20),Required]
        public string Name { get; set; }

        [MinLength(2), MaxLength(25),DefaultValue("")]
        public string? Surname { get; set; }
        [MinLength(1), MaxLength(30),Required]
        public string Position { get; set; }
        public string Image { get; set; }
        
        public string? Twitter { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? Linkedin { get; set; }

    }
}
