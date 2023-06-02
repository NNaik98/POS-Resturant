using System.ComponentModel.DataAnnotations;

namespace POSAPI.src
{
    public class OpenItem : SalesItem
    {
        [Required]
        public double Price { get; set; }
    }
}
