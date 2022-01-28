using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutomotiveStore.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

        [Required(ErrorMessage = "Proszę podać imię.")]
        [StringLength(20)]
        [Display(Name = "Imię")]
        public string FirstName{ get; set; }

        [Required(ErrorMessage = "Proszę podać nazwisko.")]
        [StringLength(30)]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Proszę podać adres zamieszkania.")]
        [StringLength(50)]
        [Display(Name = "Adres")]
        public string Adress { get; set; }

        [Required(ErrorMessage = "Proszę podać kod pocztowy.")]
        [StringLength(50)]
        [Display(Name = "Kod pocztowy")]

        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Proszę podać województwo.")]
        [Display(Name = "Województwo")]

        public string State { get; set; }

        [Required(ErrorMessage = "Proszę podać numer telefonu.")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Numer telefonu")]

        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Proszę podać email.")]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            ErrorMessage = "Zły format adresu email.")]
        [Display(Name = "Email")]

        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal OrderTotal { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderPlaced { get; set; }

    }
}
