namespace HelpBoardUA.Models
{
    public class Client : User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Sex { get; set; }
        public bool VPO_Status { get; set; }
        public DateTime Birth { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Location { get; set; }
    }
}
