using Microsoft.AspNetCore.Mvc;
using WebCoreApp.Models;
using WebCoreApp.Services;

namespace WebCoreApp.Controllers
{
    public class WelcomeController : Controller
    {
		private readonly IProductService _productService;
        
		public IActionResult Index()
        {
			
			return View();
        }
        
    }
}
