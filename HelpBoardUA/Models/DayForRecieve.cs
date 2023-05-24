using Newtonsoft.Json;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpBoardUA.Models
{
    public class DayForRecieve
    {
        public int Id { get; set; }
        public string Day { get; set; }
        public int OfferId { get; set; }
        public Offer Offer { get; set; }
    }
}
