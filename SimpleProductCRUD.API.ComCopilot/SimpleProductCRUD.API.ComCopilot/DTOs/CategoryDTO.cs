using System.ComponentModel.DataAnnotations;

namespace SimpleProductCRUD.API.ComCopilot.DTOs;

public class CategoryDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(100, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 3)]
    public string Name { get; set; }
}