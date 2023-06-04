﻿using System.ComponentModel.DataAnnotations.Schema;

namespace HelpBoardUA.Models
{
	public class OfferClient
	{
		public Guid Id { get; set; }
		public string OfferId { get; set; }
		public string ClientId { get; set; }
		public DateTime Date { get; set; }
		public string? City { get; set; }
		public string? Area { get; set; }
		public string? Office { get; set; }
		public string? PhoneNumber { get; set; }

		[NotMapped]
		public DateTime Time { get; set; }
	}
}