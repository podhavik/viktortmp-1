using System.ComponentModel.DataAnnotations;

namespace ViktorDataModel
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
