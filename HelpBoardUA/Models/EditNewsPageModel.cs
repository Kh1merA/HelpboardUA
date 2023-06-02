namespace HelpBoardUA.Models
{
    public class EditNewsPageModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public IFormFile NewsImage { get; set; }
        public IFormFile NewsBannerImage { get; set; }
    }
}
