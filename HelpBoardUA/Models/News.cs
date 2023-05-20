namespace HelpBoardUA.Models
{
    public class News
    {
        private int _id { get; set; }
        private string _title { get; set; }
        private string _subTitle { get; set; }
        private string description { get; set; }
        private DateTime _publicationDate { get; set; }
        private string _location { get; set; }
        private Organization _organization { get; set; }
    }
}
