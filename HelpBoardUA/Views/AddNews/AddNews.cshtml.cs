using HelpBoardUA.Data;
using HelpBoardUA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace HelpBoardUA.Views.AddNews
{

    // DELETE!


    public class AddNewsModel : PageModel
    {
        private readonly AppDbContext _appDbContext;
        public AddNewsModel(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //[BindProperty] <<<--- ?????
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Title")]
            public string Title { get; set; }

            [Required]
            [Display(Name = "SubTitle")]
            public string SubTitle { get; set; }

            [Required]
            [Display(Name = "Description")]
            public string Description { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            var news = new News()
            {

            };

            using (var context = _appDbContext)
            {
                
            }
            return Page();
        }
    }
}
