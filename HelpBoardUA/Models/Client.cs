namespace HelpBoardUA.Models
{
    public class Client : U
    {
        private int _id { get; set; } 
        private string fullName { get; set; }
        private string sex { get; set; }
        private bool VPO_Status { get; set; }
        private DateTime birth { get; set; }
        private DateTime registrationDate { get; set; }
        private string email { get; set; }
        private string tel { get; set; }
        private string location { get; set; }
    }
}
