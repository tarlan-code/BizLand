using System.ComponentModel.DataAnnotations;

namespace BizLand.Models
{
	public class Service
	{
		public int Id { get; set; }

		[MinLength(2),MaxLength(20),Required]
		public string Name { get; set; }

        [MinLength(2), MaxLength(100), Required]
        public string Title { get; set; }

		public string Icon { get; set; }
	}
}
