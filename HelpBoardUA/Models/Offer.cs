using System.Collections;

namespace HelpBoardUA.Models
{
    public class Offer
    {
        public Guid Id { get; set; }
        public string Title {  get; set; }
        public string Subtitle {  get; set; }
		public string Description {  get; set; }
        public string OfferType { get; set; } 
        public string HelpType { get; set; } 
        public int NumberOfAid{ get; set; } 
        public string Area { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime FinishDateTime { get; set; }
        public byte[]? OfferImage {  get; set; }
        
		//public ICollection<DayForRecieve> DaysForRecieve { get; set; } // <---- how???
		public ICollection<OfferClient> OfferClients { get; set; } // <---- how???

		public string OrganizationId { get; set; }
	}
}
