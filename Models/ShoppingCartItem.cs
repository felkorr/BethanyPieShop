using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public class ShoppingCartItem //para cada pie adicionada no carrinho, iremos criar uma instancia deste ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }

        public Pie Pie { get; set; }

        public int Amount { get; set; }

        public string ShoppingCartId { get; set; }
    }
}
