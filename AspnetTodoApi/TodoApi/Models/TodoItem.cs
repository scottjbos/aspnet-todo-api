using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    /// <summary>
    /// A Todo Item entity.
    /// </summary>
    public class TodoItem
    {
        [Required]
        public long Id { get; set; }

        [Required]
        [MaxLength(30)]
        [MinLength(5)]
        public string Name { get; set; }

        [DefaultValue(false)]
        public bool IsComplete { get; set; }
    }
}