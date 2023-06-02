using System.ComponentModel.DataAnnotations;

namespace HelpBoardUA.Models
{
	public class OfferClient
	{
		public Guid Id { get; set; }
		public string OfferId { get; set; }
		public string ClientId { get; set; }
		public DateTime Date { get; set; }
		public string City { get; set; }
		public string Area { get; set; }
		public string Office { get; set; }
        public string PhoneNumber { get; set; }
	}
}