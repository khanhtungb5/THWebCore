using WebCoreApp.Data;

namespace WebCoreApp.Models
{
	public class CartRequest
	{
		public int CartId { get; set; }

		public int ProductId { get; set; }
		public virtual Product Product { get; set; }
		public int Amount { get; set; }
		public int CartStatusId { get; set; }
		public DateTime? AddedOn { get; set; }
		public DateTime? UpdatedOn { get; set; }
	}
}
