namespace HelpBoardUA.Models
{
    public class NewsViewModel
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Location { get; set; }
        public List<News> NewsList { get; set; }
    }
}
