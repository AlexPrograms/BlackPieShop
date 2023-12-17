using BlackPieShop.Models;
using BlackPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BlackPieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;


        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult List()
        {

            PieListViewModel piesListViewModel = new PieListViewModel(_pieRepository.AllPies, "All Pies");
            return View(piesListViewModel);
        }

        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie==null)
            {
                return NotFound();
            }
            return View(pie);
        }
    }
}
