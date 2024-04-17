using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace AloPizza.Models;

[Table("Pizzas")]
public class Pizza
{
    [Key]
    public int PizzaId { get; set; }
    [Required(ErrorMessage = "O nome da pizza de ser informado")]
    [Display(Name = "Nome da Pizza")]
    [StringLength(80, MinimumLength = 10, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2}")]
    public string Name { get; set; }
    [Required(ErrorMessage = "A descrição da pizza de ser informado")]
    [Display(Name = "Descrição da Pizza")]
    [MinLength(20, ErrorMessage = "Descrição deve ter no mínimo {1} caracteres")]
    [MaxLength(200, ErrorMessage = "Descrição não pode exceder {1} caracteres ")]
    public string ShortDescription { get; set; }

    [Required(ErrorMessage = "A descrição detalhada da pizza de ser informado")]
    [Display(Name = "Descrição detalhada da Pizza")]
    [MinLength(20, ErrorMessage = "Descrição detalhada deve ter no mínimo {1} caracteres")]
    [MaxLength(200, ErrorMessage = "Descrição detalhada não pode exceder {1} caracteres ")]
    public string LongDescription { get; set; }

    [Required(ErrorMessage = "Informe o preço da pizza")]
    [Display(Name = "Preço")]
    [Column(TypeName = "decimal(10,2)")]
    [Range(1,999.99, ErrorMessage = "O preço deve estar entre 1 e 999,99")]
    public decimal Price { get; set; }

    [Display(Name = "Caminho Imagem Normal")]
    [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
    public string ImageUrl { get; set; }

    [Display(Name = "Caminho Imagem Miniatura")]
    [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
    public string ThumbnailImage { get; set; }

    [Display(Name = "Preferido?")]
    public bool IsPizzaPreferred { get; set; }

    [Display(Name = "Estoque")]
    public bool InStock { get; set; }

    public int CategoryId { get; set; }
    
    [Display(Name = "Categoria")]
    public virtual Category Category { get; set; }
}