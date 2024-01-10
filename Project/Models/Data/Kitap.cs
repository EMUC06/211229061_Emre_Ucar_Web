using System.ComponentModel.DataAnnotations;

namespace Project.Models.Data
{
	public class Kitap
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Ad { get; set; }
		[Required]
		public int YasAraligiBaslangic { get; set; }
		[Required]
		public int YasAraligiBitis { get; set; }
		public bool PopulerMi { get; set; }
	}
}