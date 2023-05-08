namespace MV_DosTablas.Models
{
	public class MV_Promo
	{
		public int PromoId { get; set; }
		public int Descripcion { get; set; }
		public DateTime FechaPromo { get; set; }

		public int Id { get; set; }
		public MV_Burger? Burger { get; set; }
	}
}
