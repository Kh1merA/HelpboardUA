﻿using Microsoft.AspNetCore.Identity;

namespace HelpBoardUA.Models
{
    public class Organization : IdentityUser
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        //public string Tel { get; set; }
        //public string Email { get; set; }
    }
}
