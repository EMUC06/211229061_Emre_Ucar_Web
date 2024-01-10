using System.ComponentModel.DataAnnotations;

namespace Project.Models.Data
{
	public class Ogrenci
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Ad { get; set; }
		[Required]
		public string SoyAd { get; set; }
		[Required]  // boş geçilemez
		public int Yas { get; set; }
	}
}