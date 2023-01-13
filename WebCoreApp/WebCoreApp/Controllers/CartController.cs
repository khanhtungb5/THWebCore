using Microsoft.AspNetCore.Mvc;
using WebCoreApp.Models;
using WebCoreApp.Services;

namespace WebCoreApp.Controllers
{
	public class CartController : Controller
	{
		private readonly ICartService _cartService;
		private readonly IProductService _productService;
		public CartController(ICartService cartService, IProductService productService)
		{
			_cartService= cartService;
			_productService=productService;
		}
		public IActionResult Index()
		{
			var model = new CartViewModel();
			model.CartResponses=_cartService.GetList();
			return View(model);
		}
		public IActionResult AddProduct(ProductViewModel model)
		{
			_cartService.AddProduct(model.ProductRequest.Id);
			return RedirectToAction("Index","Home");
		}
		public IActionResult RemoveProduct(CartViewModel model)
		{
			_cartService.RemoveProduct(model.productId);
			return RedirectToAction("Index", "Cart");
		}
		public IActionResult IncreaseProduct(CartViewModel model)
		{
			_cartService.IncreaseProduct(model.productId);
			return RedirectToAction("Index", "Cart");
		}
		public IActionResult DecreaseProduct(CartViewModel model)
		{
			_cartService.DecreaseProduct(model.productId);
			return RedirectToAction("Index", "Cart");
		}
	}
}
