using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderItem.Model
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public int userId { get; set; }

        public int menuItemId { get; set; }

        public string menuItemName { set; get; }
    }
} 
