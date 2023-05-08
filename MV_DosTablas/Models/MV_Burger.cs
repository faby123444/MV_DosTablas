namespace MV_DosTablas.Models
{
	public class MV_Burger
	{
		public int Id { get; set; }
		public int Name { get; set; }
		public int WithCheese { get; set; }

		public List<MV_Promo>? Promos { get; set; }
	}
}
