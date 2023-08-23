using System.Globalization;

namespace Principal.Entities {
    class OrderItem {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public OrderItem() {

        }
        public OrderItem (Product product, int quantity, double price) {
            Product = product;
            Quantity = quantity;
            Price = price;
        }
        public double Subtotal() {
            return Quantity * Price;
        }

        public override string ToString() {
            return $"{Product.Name}, ${Price}, Quantity: {Quantity}, Subtotal: ${Subtotal().ToString("F2", CultureInfo.InvariantCulture)}";
        }
    }
}