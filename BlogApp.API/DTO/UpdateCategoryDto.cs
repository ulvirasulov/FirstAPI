using System.ComponentModel.DataAnnotations;

namespace BlogApp.API.DTO
{
    public class UpdateCategoryDto
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
