﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MenuItemWebApi.Model
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Free Delivery")]
        public bool freeDelivery { get; set; }
        [Required]
        public double Price { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime dateOfLaunch { get; set; }
        public bool Active { get; set; }
    }
}
