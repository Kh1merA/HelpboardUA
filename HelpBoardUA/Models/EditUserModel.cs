namespace HelpBoardUA.Models
{
    public class EditUserProfileModel
    {
        //[RegularExpression(@"^[^0-9]+$", ErrorMessage = "Поле не повинно мати цифри")]
        public string FirstName { get; set; }
        //[RegularExpression(@"^[^0-9]+$", ErrorMessage = "Поле не повинно мати цифри")]
        public string LastName { get; set; }

        //[RegularExpression(@"^[^0-9]+$", ErrorMessage = "Поле не повинно мати цифри")]
        public string Patronymic { get; set; }

        public string Sex { get; set; }
        //public bool VPO_Status { get; set; }
        public DateTime Birth { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

    }
}
