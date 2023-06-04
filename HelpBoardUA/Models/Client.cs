
﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpBoardUA.Models
{
    public class Client : IdentityUser
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Sex { get; set; }
        public DateTime Birth { get; set; }
        public string? ImageFileName { get; set; }
        public string? ImageExtension { get; set; }
        public byte[]? ImageData { get; set; }
		public int VPO_Status { get; set; }

		[NotMapped]
        public IFormFile file { get; set; }

        

        //[EmailAddress]
        //public string Email { get; set; }
        //[Phone] //[Remote] для удаленной проверки на пример на наличии емейла у других пользователей
        //public string Tel { get; set; }
        //public string Location { get; set; }

    }
}
