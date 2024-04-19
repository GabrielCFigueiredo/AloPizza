using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Name;

namespace AloPizza.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        [StringLength(50)]

        public string Name { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Informe o Sobrenome")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Informe o seu Enderço")]
        [StringLength(100)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [StringLength(100)]
        [Display(Name = "Complement")]
        public string Complement { get; set; }

        [Required(ErrorMessage = "Informe o seu CEP")]
        [Display(Name = "ZipCode")]
        [StringLength(10, MinimumLength = 8)]

        public string ZipCode { get; set; }

        [StringLength(10)]
        public string State { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [Required(ErrorMessage = "Informe o seu telefone")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]

        public string Telephone { get; set; }

        [Required(ErrorMessage = "Informe o email")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
        ErrorMessage = "O email não possui um formato correto")]

        public string Email { get; set; }

        [ScaffoldColumn(false)]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Total Order")]

        public decimal TotalOrder { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Total Items Ordered ")]

        public int TotalItemsOrdered { get; set; }

        [Display(Name = "Request Date")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]

        public DateTime OrderDispatched { get; set; }

        [Display(Name = "Order Shipping Date")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]

        public DateTime? OrderDeliveredTo { get; set; }

        public List<OrderDetail> OrderItems { get; set; }


    }
}