﻿namespace HelpBoardUA.Models
{
	public class OfferClient
	{
		public Guid Id { get; set; }
		public string OfferId { get; set; }
		public string ClientId { get; set; }
		public DateTime Date { get; set; }
	}
}