using EpitmenyadoWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EpitmenyadoWebApp.Pages
{
    public class FizetendoAdoModel : PageModel
    {
        private readonly EpitmenyadoWebApp.Data.EpitmenyadoDbContext _context;
        public IList<Epitmeny> Epitmenyek { get; set; } = default!;
        public FizetendoAdoModel(EpitmenyadoWebApp.Data.EpitmenyadoDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            Epitmenyek = _context.Epitmenyek.ToList();



        }
    }
}
