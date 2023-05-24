namespace HelpBoardUA.Models
{
    public class Client : User
    {
        public int Id { get; set; }
        public string _fullName { get; set; }
        public string _sex { get; set; }
        public bool _VPO_Status { get; set; }
        public DateTime _birth { get; set; }
        public DateTime _registrationDate { get; set; }
        public string _email { get; set; }
        public string _tel { get; set; }
        public string _location { get; set; }
    }
}
