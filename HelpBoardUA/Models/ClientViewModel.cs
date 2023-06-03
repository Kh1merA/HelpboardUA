using Microsoft.AspNetCore.Identity;

namespace HelpBoardUA.Models
{
	public class ClientViewModel
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public string Patronymic { get; set; }
		public string PhoneNumber { get; set; }
		public string Sex { get; set; }
		public DateTime Birth { get; set; }
		public string Email { get; set; }
		public int VPO_Status { get; set; }
		public List<Client> ClientsList { get; set; }
		public List<IdentityUser> UsersList { get; set; }
	}
}
