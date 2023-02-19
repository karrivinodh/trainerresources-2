using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MenuItemListing.Model
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name="Free Delivery")]
        public Boolean freeDelivery { get; set; }
        [Required]
        public long Price { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
            public DateTime dateOfLaunch { get; set; }
        public Boolean Active { get; set; }
    }
}
