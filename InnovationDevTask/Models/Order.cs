using InnovationDevTask.Attributes;
using System.ComponentModel.DataAnnotations;

namespace InnovationDevTask.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required]
        [Display(Name = "Order ID")]
        public string OrderSerialNo { get; set; }
        [Required]
        [Display(Name = "Order Status")]
        [StatusValidator("Shipped", "Not-Shipped", ErrorMessage = "Shipped/Not-Shipped are only allowed values!")]
        public string OrderStatus { get; set; }
        [Required]
        [Display(Name = "Shipping Status")]
        [StatusValidator("Received", "Completed", "Canceled", ErrorMessage = "Received/Completed/Canceled are only allowed values!")]
        public string ShippingStatus { get; set; }
    }
}
