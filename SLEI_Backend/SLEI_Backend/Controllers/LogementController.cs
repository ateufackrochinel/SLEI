using Microsoft.AspNetCore.Mvc;
using SLEI.Domain.Repository;
using SLEI_Backend.Dtos;
using SLEI.Domain;
using static SLEI.Domain.Image;
using SLEI.Insfrastructure.Services;
using Microsoft.EntityFrameworkCore;
using SLEI.Insfrastructure.Data;
using static System.Net.Mime.MediaTypeNames;
using Image = SLEI.Domain.Image;
using Microsoft.AspNetCore.Authorization;
//using static System.Net.Mime.MediaTypeNames;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SLEI_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LogementController : ControllerBase
    {
        private readonly SLEIContext _context = null;
        private readonly LogementRepository _LogementRepository = null;

        private readonly VilleRepository _VilleRepository = null;
        private readonly AppartementRepository _AppartementRepository;
        private readonly StudioRepository _StudioRepository;

        public LogementController(LogementRepository LogementRepository, VilleRepository VilleRepository,AppartementRepository AppartementRepository, SLEIContext context, StudioRepository StudioRepository)
        {
            this._LogementRepository = LogementRepository;
            this._VilleRepository = VilleRepository;
            this._AppartementRepository = AppartementRepository;
            this._context = context;
            this._StudioRepository = StudioRepository;



        }


        // GET: api/<LogementController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LogementController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LogementController>
        [HttpPost]
        
        public async Task<IActionResult> AjouterLogement([FromForm] string Nom, [FromForm] string Description, [FromForm] string Adresse, [FromForm] int NbreApp,
            [FromForm] int NbreStudio, [FromForm] string NomVille, [FromForm] List<IFormFile> Images)
        {

           

            var Logement = _LogementRepository.findLogementByNom(Nom);
            var Ville = _VilleRepository.FindVilleByNom(NomVille);
           // if (Ville != null && Logement == null)
            if ( Ville == null )
            {

                return BadRequest(new { message = "Veuillez sélectionner une Ville." });

            } else if ( Logement != null)
            {
                return BadRequest(new { message = "Un logement avec ce nom existe deja " });
            } else {
                var logement = new Logement
                {
                    NomLogement = Nom,
                    Description = Description,
                    Adresse = Adresse,
                    NbreAppartement = NbreApp,
                    NbreStudio = NbreStudio,
                    ville = Ville,
                    Images = new List<Image>(),
                    Appartements = new List<Appartement>(),
                    Studios = new List<Studio>()
                };



                this._LogementRepository.AddLogement(logement);  // pour obtenir l'ID du logement
                // Sauvegarder les images sur le disque

                SaveImages("logements", Images, logement.LogementId.ToString(), logement:logement);

                // 3. Sauvegarder les URLs des images
                _context.SaveChanges();

                return Ok(logement);

            } 
        }

       
        [Route("AjouterAppartement")]
        [HttpPost]
        public async Task <IActionResult> AjouterAppartement([FromForm] string NomLogement, [FromForm] int NbrePieces, [FromForm] float Loyer, [FromForm] List<IFormFile> Images)
        {
            var Logement = _LogementRepository.findLogementByNom(NomLogement);
             if (Logement == null)
            {
                return BadRequest(new { message= " Ce Logement n'existe pas" });
            }else
            {

                var App = new Appartement
                {
                    Statut = "Libre",
                    NbreDePieces = NbrePieces,
                    Loyer = Loyer,
                    logement = Logement,
                    Images = new List<Image>()

                };

                this._AppartementRepository.AddAppartement(App);

                //Sauvegarder les images sur le disque 

                //  SaveImages(null, App, null, "Appartements", Images, App.AppartementId.ToString());
                SaveImages("Appartements", Images, App.AppartementId.ToString(), App: App);
                //  return this.BadRequest;

                _context.SaveChanges();

                return Ok(App);
            }
            
            
        }

        [Route("AjouterStudio")]
        [HttpPost]
        public async Task<IActionResult> AjouterStudio([FromForm] string NomLogement, [FromForm] float Loyer, [FromForm] List<IFormFile> Images)
        {
            var Logement = _LogementRepository.findLogementByNom(NomLogement);
            if (Logement == null)
            {
                return BadRequest(new { message = " Ce Logement n'existe pas" });
            }
            else
            {

                var Std = new Studio
                {
                    Statut = "Libre",
                    Loyer = Loyer,
                    logement = Logement,
                    Images = new List<Image>()

                };
                this._StudioRepository.AddStudio(Std);

                // Enregistrer les images

                SaveImages("Studios", Images, Std.StudioId.ToString(), Std: Std);
                _context.SaveChanges();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
                return Ok(Std);
            }
        }
            // PUT api/<LogementController>/5
            [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<LogementController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private async void SaveImages(string Type, List<IFormFile> Images, string numero, Logement logement= null , Appartement App= null, Studio Std=null)
        {
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", Type, numero);

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            foreach (var imageFile in Images)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                if (logement != null)
                {
                    logement.Images.Add(
                    new Image
                    {
                        Url = filePath,
                        LogementId = logement.LogementId
                    }

                );
                }
                if( App != null)
                {
                    App.Images.Add(
                        new Image
                        {
                            Url = filePath,
                            AppartementId = App.AppartementId
                        }
                        );
                }

                if (Std != null)
                {
                    Std.Images.Add(
                        new SLEI.Domain.Image
                        {
                            Url = filePath,
                            StudioId = Std.StudioId
                        }
                        );
                }
                
            }
        }
    }
}
