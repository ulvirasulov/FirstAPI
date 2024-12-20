using System.ComponentModel.DataAnnotations;

namespace BlogApp.API.DTO
{
    public class CreateCategoryDto
    {
        [Required]
        public string Name { get; set; }

    }
}
