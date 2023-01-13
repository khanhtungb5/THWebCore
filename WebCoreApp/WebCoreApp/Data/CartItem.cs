using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCoreApp.Data
{
	public class CartItem
	{
		[Key]
		public int CartId { get; set; }
		
		public int ProductId { get; set; }
		[ForeignKey("ProductId")]
		public virtual Product Product { get; set; }
		public int Amount { get; set; }

		public int CartStatusId { get; set; }
		
		public DateTime? AddedOn { get; set; }
		public DateTime? UpdatedOn { get; set; }

	}
}
