namespace HelpBoardUA.Models
{
    public class AspNetUser
    {
        public int Id { get; set; }
        public string Name { get; set; }           //org name
        public string Location { get; set; }       //org location
        public string Discriminator { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public DateTime Birth { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string Sex { get; set; }
    }
}
