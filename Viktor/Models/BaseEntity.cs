using System.ComponentModel.DataAnnotations;

namespace Viktor.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
