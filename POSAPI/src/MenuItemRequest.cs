using System;
using System.ComponentModel.DataAnnotations;

namespace POSAPI.src
{
    public class MenuItemRequest
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string CategoryId { get; set; }

        [Required]
        public DateTime EffectiveDate { get; set; }
    }
}
