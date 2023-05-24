namespace HelpBoardUA.Models
{
    public class News
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Location { get; set; }
        public Organization Organization { get; set; }
    }
}
