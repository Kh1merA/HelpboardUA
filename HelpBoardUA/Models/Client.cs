
﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpBoardUA.Models
{
    public class Client : IdentityUser
    {
        public Guid Id { get; set; }

        //[RegularExpression(@"^[^0-9]+$", ErrorMessage = "Поле не повинно мати цифри")]
        public string FirstName { get; set; }
        //[RegularExpression(@"^[^0-9]+$", ErrorMessage = "Поле не повинно мати цифри")]
        public string LastName { get; set; }

        //[RegularExpression(@"^[^0-9]+$", ErrorMessage = "Поле не повинно мати цифри")]
        public string Patronymic { get; set; }

        public string Sex { get; set; }
        //public bool VPO_Status { get; set; }
        public DateTime Birth { get; set; }
        public string? ImageFileName { get; set; }
        public string? ImageExtension { get; set; }
        public byte[]? ImageData { get; set; }

        [NotMapped]
        public IFormFile file { get; set; }
        //public DateTime RegistrationDate { get; set; }

        //[EmailAddress]
        //public string Email { get; set; }
        //[Phone] //[Remote] для удаленной проверки на пример на наличии емейла у других пользователей
        //public string Tel { get; set; }
        //public string Location { get; set; }

    }
}
