namespace HelpBoardUA.Models
{
    public class EditOrganizationViewModel
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public IFormFile AvatarImage { get; set; }
        public IFormFile BannerImage { get; set; }
        public IFormFile Certificate { get; set; }

    }
}
