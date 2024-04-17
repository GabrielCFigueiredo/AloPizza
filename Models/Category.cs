using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AloPizza.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int CategoryId {get; set; }
        [StringLength(100, ErrorMessage ="O tamanho maximo é de 100 caracter")]
        [Required(ErrorMessage ="Informe o nome da Categoria")]
        [Display(Name ="Name")]
        public string CategoryName { get; set; }
        [StringLength(200, ErrorMessage = "O tamanho maximo é de 200 caracteres")]
        [Required(ErrorMessage = "Informe a descrição da categoria")]
        [Display(Name = "Name")]
        public string Description { get; set; }

        public List<Pizza> Pizza { get; set; }
    }
}