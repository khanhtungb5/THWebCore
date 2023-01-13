using WebCoreApp.Data;
using WebCoreApp.Models;

namespace WebCoreApp.Services
{
	public class CartService : ICartService
	{
		private readonly ApplicationDbContext _db;
		public CartService(ApplicationDbContext db)
		{
			_db = db;
		}
		public List<CartResponse> GetList()
		{

			var rs = _db.CartItems.Select(e => new CartResponse
			{
				CartId = e.CartId,
				ProductAvatar = e.Product.AvatarUrl,
				ProductId = e.ProductId,
				ProductName = e.Product.Name,
				Amount = e.Amount,
				TotalPrice = e.Product.Price * e.Amount,
				CartStatusId= e.CartStatusId,

			}).ToList();
			return rs;
		}
		public CartItem Get(int productid)
		{
			var rs = _db.CartItems.Where(e => e.ProductId == productid).FirstOrDefault();

			return rs;
		}
		public void AddProduct(int productId)
		{
			var item = Get(productId);
			if (item == null)
			{
				item = new CartItem
				{
					ProductId = productId,
					Amount = 1,
					CartStatusId = 1,
					AddedOn = DateTime.Now,
					UpdatedOn = DateTime.Now
				};
				_db.CartItems.Add(item);
			}
			else if(item!=null)
			{
				if (item.CartStatusId == 1)
				{
                    item.Amount+=1;
                    item.UpdatedOn = DateTime.Now;
                    _db.CartItems.Update(item);
                    
				}
				else
				{
                    item.CartStatusId = 1;
                    item.Amount = 1;
                    item.UpdatedOn = DateTime.Now;
                    _db.CartItems.Update(item);
                }
			}
			_db.SaveChanges();
		}
		public void IncreaseProduct(int productId)
		{
			var item = Get(productId);
			if (item != null)
			{
				item.Amount+=1;
				item.UpdatedOn = DateTime.Now;
				_db.CartItems.Update(item);
			}
			_db.SaveChanges();
		}
		public void DecreaseProduct(int productId)
		{
			var item = Get(productId);
			if (item != null)
			{
				item.Amount--;
				item.UpdatedOn = DateTime.Now;
				if (item.Amount == 0) _db.CartItems.Remove(item);
				else
				_db.CartItems.Update(item);
			}
			_db.SaveChanges();
		}
		public void RemoveProduct(int productId)
		{
			var item = Get(productId);
			if (item != null)
			{
				/*item.CartStatusId = 2;
				_db.CartItems.Update(item);*/
				_db.CartItems.Remove(item);
				_db.SaveChanges();
			}

		}
	}
}
