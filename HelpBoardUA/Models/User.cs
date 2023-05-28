using System.ComponentModel.DataAnnotations.Schema;

namespace HelpBoardUA.Models
{
    public abstract class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        [NotMapped]
        public string PassConfirmation { get; set; }

    }
}
