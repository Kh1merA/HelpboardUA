namespace HelpBoardUA.Models
{
    public class AddNewNewsModel
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public IFormFile NewsImage { get; set; }
        public IFormFile NewsBannerImage { get; set; }

    }
}
