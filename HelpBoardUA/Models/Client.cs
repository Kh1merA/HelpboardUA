

namespace HelpBoardUA.Models
{
    public class Client : User
    {
        public Guid Id { get; set; }

        //[RegularExpression(@"^[^0-9]+$", ErrorMessage = "Поле не повинно мати цифри")]
        public string FirstName { get; set; }
        //[RegularExpression(@"^[^0-9]+$", ErrorMessage = "Поле не повинно мати цифри")]
        public string LastName { get; set; }
        //[RegularExpression(@"^[^0-9]+$", ErrorMessage = "Поле не повинно мати цифри")]
        public string SurName { get; set; }
        public string Sex { get; set; }
        public bool VPO_Status { get; set; }
        public DateTime Birth { get; set; }
        public DateTime RegistrationDate { get; set; }

        //[EmailAddress]
        public string Email { get; set; }
        //[Phone] //[Remote] для удаленной проверки на пример на наличии емейла у других пользователей
        public string Tel { get; set; }
        public string Location { get; set; }
    }
}
