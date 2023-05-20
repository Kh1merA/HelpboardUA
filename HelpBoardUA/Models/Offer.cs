using System.Collections;

namespace HelpBoardUA.Models
{
    public class Offer
    {
        private string title {  get; set; }
        private string subtitle {  get; set; }
        private string description {  get; set; }
        
        //ENUM?
        //private type description {  get; set; }

        private string area { get; set; }
        private string city { get; set; }
        private string address { get; set; }
        private DateTime startDateTime { get; set; }
        private DateTime finishDateTime { get; set; }
        private Organization organizationName { get; set; }
        private ArrayList daysForRecieve { get; set; }

        private Dictionary<Client, DateTime> queue { get; set; }
    }
}
