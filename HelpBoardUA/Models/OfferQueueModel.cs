namespace HelpBoardUA.Models
{
	public class OfferQueueModel
	{
		public OfferClient OfferClient { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Patronymic { get; set; }
		public string Sex { get; set; }
		public DateTime Birth { get; set; }
		public string Tel {get; set; }
		public string Email { get; set; }
		public DateTime RecordOnOffer { get; set; }
	}
}
