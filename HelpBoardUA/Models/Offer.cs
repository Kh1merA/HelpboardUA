using Newtonsoft.Json;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpBoardUA.Models
{
    public class Offer
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }

        //ENUM?
        //private type description {  get; set; }

        public string Area { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public DateTime startDateTime { get; set; }
        public DateTime FinishDateTime { get; set; }
        public Organization Organization { get; set; }
        public ICollection<DayForRecieve> DaysForRecieve { get; set; }
        public ICollection<OfferClient> OfferClients { get; set; }
    }
}
