using System.ComponentModel.DataAnnotations;

namespace BizLand.Models
{
	public class Tophero
	{
		public int Id { get; set; }

		[MinLength(5),MaxLength(100),Required]
		public string Title { get; set; }

		public string? GetStartedUrl { get; set; }
		public string? VideoUrl { get; set; }
	}
}
