using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RicckyStore.Models;
using RicckyStore.Services;

namespace RicckyStore.Controllers
{
    public class ProduitsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment environnement;

        public ProduitsController(ApplicationDbContext context, IWebHostEnvironment environnement)
        {
            this.context = context;
            this.environnement = environnement;
        }

        public IActionResult Index()
        {
            var products = context.Produits.ToList();
            return View(products);
        }



        public IActionResult Create(ProduitDto produitDto)
        {
            if (produitDto.imageFichierNom == null)
            {
                ModelState.AddModelError("Fichier Image", "Le champ image est obligatoire");
            }

            if (!ModelState.IsValid)
            {
                return View(produitDto);
            }

            // sauvegarde du fichier image
            string nouveauFichierImage = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            nouveauFichierImage += Path.GetExtension(produitDto.imageFichierNom!.FileName);

            string imageFullPath = environnement.WebRootPath + "/produitsImages/" + nouveauFichierImage;
            using (var stream = System.IO.File.Create(imageFullPath))
            {
                produitDto.imageFichierNom.CopyTo(stream);
            }

            // enregistrement du fichier dans la base de données
            Produits produits = new Produits()
            {
                nom = produitDto.nom,
                marque = produitDto.marque,
                categorie = produitDto.categorie,
                prix = produitDto.prix,
                description = produitDto.description,
                imageFichierNom = nouveauFichierImage,
                dateAjout = DateTime.Now,

            };

            context.Produits.Add(produits);
            context.SaveChanges();
            TempData["SuccessMessage"] = "Le produit a été ajouté avec succès.";
            return RedirectToAction("Index", "Produits");
        }

        public IActionResult Edit(int id)
        {
            var product = context.Produits.Find(id);

            if (product == null)
            {
                return RedirectToAction("Index", "Produits");
            }
             
            // modification du produit (1)
            var productDto = new ProduitDto()
            {
                nom = product.nom,
                marque = product.marque,
                categorie = product.categorie,
                prix = product.prix,
                description = product.description,
            };

            ViewData["ProduitsId"] = product.id;
            ViewData["imageFichierNom"] = product.imageFichierNom;
            ViewData["dateAjout"] = product.dateAjout.ToString("MM/dd/yyyy");

            return View(productDto);
        }

        [HttpPost]
        public IActionResult Edit(int id, ProduitDto produitDto)
        {
            var product = context.Produits.Find(id);

            if (product == null)
            {
                return RedirectToAction("Index", "Produits");
            }

            if (!ModelState.IsValid)
            {
                ViewData["ProduitsId"] = product.id;
                ViewData["imageFichierNom"] = product.imageFichierNom;
                ViewData["dateAjout"] = product.dateAjout.ToString("MM/dd/yyyy");

                return View(produitDto);
            }

            // modification du produit (2) champ de l'image
            string nouveauFichierNom = product.imageFichierNom;
            if (produitDto.imageFichierNom != null)
            {
                nouveauFichierNom = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                nouveauFichierNom += Path.GetExtension(produitDto.imageFichierNom.FileName);

                string imageFullPath = environnement.WebRootPath + "/produitsImages/" + nouveauFichierNom;
                using (var stream = System.IO.File.Create(imageFullPath))
                {
                    produitDto.imageFichierNom.CopyTo(stream);
                }

                // supression de l'ancienne image
                string oldImageFullPath = environnement.WebRootPath + "/produitsImages/" + product.imageFichierNom;
                System.IO.File.Delete(oldImageFullPath);

            }

            // mise à jour du produit dans la base de données
            product.nom = produitDto.nom;
            product.marque = produitDto.marque;
            product.categorie = produitDto.categorie;
            product.prix = produitDto.prix;
            product.description = produitDto.description;
            product.imageFichierNom = nouveauFichierNom;

            context.SaveChanges();
            
            return RedirectToAction("Index", "Produits");
        }

        public IActionResult Delete(int id)
        {
            var produits = context.Produits.Find(id);
            if (produits == null)
            {
                return RedirectToAction("Index", "Produits");
            }

            string imageFullPath = environnement.WebRootPath + "/produitsImages/" + produits.imageFichierNom;
            System.IO.File.Delete(imageFullPath);

            context.Produits.Remove(produits);
            context.SaveChanges(true);

            return RedirectToAction("Index", "Produits");
        }

        public async Task<IActionResult> Search(string searchString)
        {
            var produits = from p in context.Produits
                           select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                produits = produits.Where(p => p.nom.Contains(searchString) ||
                                               p.categorie.Contains(searchString) ||
                                               p.marque.Contains(searchString));
            }

            var produitsList = await produits.ToListAsync();

            if (!produitsList.Any())
            {
                ViewBag.Message = "Aucun produit trouvé pour la recherche : " + searchString;
            }

            return View("Index", produitsList);
        }
    }
}

