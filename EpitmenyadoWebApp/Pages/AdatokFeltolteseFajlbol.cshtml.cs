using EpitmenyadoWebApp.Data;
using EpitmenyadoWebApp.Models;
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

        public List<Epitmeny> Eps {  get; set; }

        public void OnGet()
        {
            Eps = _con.Epitmenyek.ToList();
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

            StreamReader sr = new StreamReader(FeltoltottFajlEleresiUtja);
            sr.ReadLine();
            while(!sr.EndOfStream)
            {
                var sor = sr.ReadLine();
                var elemek = sor.Split();
                Epitmeny ujEpitmeny = new Epitmeny();
                ujEpitmeny.Tulajdonos = int.Parse(elemek[0]);
                ujEpitmeny.Utca = elemek[1];
                ujEpitmeny.Hazszam = elemek[2];
                ujEpitmeny.Adosav = char.Parse(elemek[3]);
                ujEpitmeny.Alapterulet = int.Parse(elemek[4]);
                /*if(_con.Epitmenyek.
                    Select(x => x.Utca == ujEpitmeny.Utca && x.Hazszam == ujEpitmeny.Hazszam).
                    Count() == 0)*/
                    _con.Epitmenyek.Add(ujEpitmeny);
            }
            sr.Close();
            _con.SaveChanges();
            return Page();
        }
    }
}
