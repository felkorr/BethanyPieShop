using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage ="User Name required")]
        [Display(Name = "User Name")]//O nome do campo que sera mostrado na pagina***pode-se definir-lo no label do campo tambem
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }




    }
}
