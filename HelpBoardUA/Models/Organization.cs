namespace HelpBoardUA.Models
{
    public class Organization : User
    {
        private int _id { get; set; }
        private string _name { get; set; }
        private string _location { get; set; }
        private string _tel { get; set; }
        private string _email { get; set; }
    }
}
