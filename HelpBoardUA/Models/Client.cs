using Microsoft.AspNetCore.Identity;

namespace HelpBoardUA.Models
{
    public class Client : IdentityUser<string>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Sex { get; set; }
        //public bool VPO_Status { get; set; }
        public DateTime Birth { get; set; }
        //public DateTime RegistrationDate { get; set; }
        //public string Email { get; set; }
        //public string Tel { get; set; }
        //public string Location { get; set; }
    }
}
