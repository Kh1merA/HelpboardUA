namespace HelpBoardUA.Models
{
	public class OfferClient
	{
		public Guid Id { get; set; }
		public int OfferId { get; set; }

		public int ClientId { get; set; }
		public DateTime Date { get; set; }
	}
}