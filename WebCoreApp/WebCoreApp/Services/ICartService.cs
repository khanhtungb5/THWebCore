using WebCoreApp.Data;
using WebCoreApp.Models;

namespace WebCoreApp.Services
{
	public interface ICartService
	{
		void AddProduct(int productId);
		List<CartResponse> GetList();
		CartItem Get(int productid);
		void IncreaseProduct(int productid);
		void DecreaseProduct(int productid);
		void RemoveProduct(int productId);

	}
}