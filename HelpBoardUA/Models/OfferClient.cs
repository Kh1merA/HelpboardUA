namespace HelpBoardUA.Models
{
    public class OfferClient
    {
        public int Id { get; set; }
        public int OfferId { get; set; }
        public Offer Offer { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
