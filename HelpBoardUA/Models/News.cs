namespace HelpBoardUA.Models
{
    public class News
    {
        public int Id { get; set; }
        public string _title { get; set; }
        public string _subTitle { get; set; }
        public string description { get; set; }
        public DateTime _publicationDate { get; set; }
        public string _location { get; set; }
        public Organization _organization { get; set; }
    }
}
