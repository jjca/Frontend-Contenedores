using System.Diagnostics;
using Frontend_Contenedores.Models;
using Frontend_Contenedores.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace Frontend_Contenedores.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ContenedorService _contenedorService;
        private const int PageSize = 10;

        public HomeController(ILogger<HomeController> logger, ContenedorService contenedorService)
        {
            _logger = logger;
            _contenedorService = contenedorService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var contenedores = await _contenedorService.GetContenedoresAsync();
            var totalItems = contenedores.Count;
            var items = contenedores.Skip((page - 1) * PageSize).Take(PageSize).ToList();
            ViewBag.TotalPages = (int)System.Math.Ceiling(totalItems / (double)PageSize);
            ViewBag.CurrentPage = page;
            return View(items);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
