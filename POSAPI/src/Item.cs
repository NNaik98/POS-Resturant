using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSAPI.src
{
    public abstract class SalesItem
    {
        public string Id { get; protected set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Name { get; protected set; }

        // double getPrice()
    }
}
