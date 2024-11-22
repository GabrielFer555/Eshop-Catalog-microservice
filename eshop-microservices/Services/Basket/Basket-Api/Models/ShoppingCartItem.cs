﻿namespace Basket_Api.Models
{
	public class ShoppingCartItem
	{
        public Guid ProductId { get; set; } = default!;

		public int Quantity { get; set; } = default!;
        public string Colour { get; set; } = default!;
        public decimal Price { get; set; } = default!;
        public string ProductName { get; set; } = default!;


    }
}
