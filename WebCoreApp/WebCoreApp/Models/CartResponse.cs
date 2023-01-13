using System.ComponentModel.DataAnnotations.Schema;
using WebCoreApp.Data;

namespace WebCoreApp.Models
{
	public class CartResponse
	{
		public int CartId { get; set; }
		public string? ProductAvatar { get; set; }
		public int ProductId { get; set; }
		public string? ProductName { get; set; }
		
		public int Amount { get; set; }
		public int? TotalPrice { get; set; }
		public int CartStatusId { get; set; }
	}
}
