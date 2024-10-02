using EpitmenyadoWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EpitmenyadoWebApp.Pages
{
    public class AdatokFeltolteseFajlbolModel : PageModel
    {
        private readonly IWebHostEnvironment _env;
        private readonly EpitmenyadoDbContext _con;

        public AdatokFeltolteseFajlbolModel(IWebHostEnvironment env, EpitmenyadoDbContext con)
        {
            _con = con;
            _env = env;
        }

        [BindProperty]
        public IFormFile FajlFeltoltes { get; set; }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var FeltoltottFajlEleresiUtja = Path.Combine(
                                                            _env.ContentRootPath,
                                                            @".\Files\Uploads",
                                                            FajlFeltoltes.FileName
                                                        );

            using (var stream = new FileStream(FeltoltottFajlEleresiUtja,FileMode.Create))
            {
                await FajlFeltoltes.CopyToAsync(stream);
            }


                return Page();
        }
    }
}
