namespace HelpBoardUA.Models
{
    public class Organization : User
    {
        public int Id { get; set; }
        public string _name { get; set; }
        public string _location { get; set; }
        public string _tel { get; set; }
        public string _email { get; set; }
    }
}
