namespace HelpBoardUA.Models
{
    public class Client : User
    {
        private int _id { get; set; } 
        private string _fullName { get; set; }
        private string _sex { get; set; }
        private bool _VPO_Status { get; set; }
        private DateTime _birth { get; set; }
        private DateTime _registrationDate { get; set; }
        private string _email { get; set; }
        private string _tel { get; set; }
        private string _location { get; set; }
    }
}
