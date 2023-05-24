using System.Collections;

namespace HelpBoardUA.Models
{
    public class Offer
    {
        public int Id { get; set; }
        public string _title {  get; set; }
        public string _subtitle {  get; set; }
        public string _description {  get; set; }

        //ENUM?
        //private type description {  get; set; }

        public string _area { get; set; }
        public string _city { get; set; }
        public string _address { get; set; }
        public DateTime startDateTime { get; set; }
        public DateTime _finishDateTime { get; set; }
        public Organization _organization { get; set; }
        public ArrayList _daysForRecieve { get; set; }
        
        public Dictionary<Client,DateTime> _queue { get; set; }
    }
}
