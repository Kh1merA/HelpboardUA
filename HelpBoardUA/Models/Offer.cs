using Newtonsoft.Json;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpBoardUA.Models
{
    public class Offer
    {
        public int Id { get; set; }
        public string _title { get; set; }
        public string _subtitle { get; set; }
        public string _description { get; set; }

        //ENUM?
        //private type description {  get; set; }

        public string _area { get; set; }
        public string _city { get; set; }
        public string _address { get; set; }
        public DateTime startDateTime { get; set; }
        public DateTime _finishDateTime { get; set; }
        public Organization _organization { get; set; }
        public ICollection<DayForRecieve> DaysForRecieve { get; set; }
        public ICollection<OfferClient> OfferClients { get; set; }
    }
}
