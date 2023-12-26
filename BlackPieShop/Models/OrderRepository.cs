namespace BlackPieShop.Models
{
	public class OrderRepository : IOrderRepository
	{
		private readonly BlackPieDbContext _blackPieShopDbContext;
		private readonly IShoppingCart _shoppingCart;

		public OrderRepository(BlackPieDbContext bethanysPieShopDbContext, IShoppingCart shoppingCart)
		{
			_blackPieShopDbContext = bethanysPieShopDbContext;
			_shoppingCart = shoppingCart;
		}

		public void CreateOrder(Order order)
		{
			order.OrderPlaced = DateTime.Now;

			List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.ShoppingCartItems;
			order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

			order.OrderDetails = new List<OrderDetail>();

			foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems)
			{
				var orderDetail = new OrderDetail
				{
					Amount = shoppingCartItem.Amount,
					PieId = shoppingCartItem.Pie.PieId,
					Price = shoppingCartItem.Pie.Price
				};

				order.OrderDetails.Add(orderDetail);
			}

			_blackPieShopDbContext.Orders.Add(order);

			_blackPieShopDbContext.SaveChanges();
		}
	}
}
