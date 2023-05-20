using System.Collections;

namespace HelpBoardUA.Models
{
    public class Offer
    {
        private int _id { get; set; }
        private string _title {  get; set; }
        private string _subtitle {  get; set; }
        private string _description {  get; set; }
        
        //ENUM?
        //private type description {  get; set; }

        private string _area { get; set; }
        private string _city { get; set; }
        private string _address { get; set; }
        private DateTime startDateTime { get; set; }
        private DateTime _finishDateTime { get; set; }
        private Organization _organization { get; set; }
        private ArrayList _daysForRecieve { get; set; }

        private Dictionary<Client, DateTime> _queue { get; set; }
    }
}
