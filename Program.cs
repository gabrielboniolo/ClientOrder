using Principal.Entities;
using Principal.Entities.Enums;
using System.Globalization;

namespace Principal {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Enter client data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Client client = new Client(name, email, birthDate);

            Console.WriteLine();

            Console.WriteLine("Enter order data: ");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            Console.Write("How many items to this order? ");
            int orderItems = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Order order = new Order(DateTime.Now, status, client);

            for(int i = 1; i <= orderItems; i++ ) {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();
                Console.Write("Product price: ");
                double productPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Product product = new Product(productName, productPrice);

                Console.Write("Quantity: ");
                int productQuantity = int.Parse(Console.ReadLine());
                OrderItem item = new OrderItem(product, productQuantity, productPrice);
                order.AddItem(item);

                Console.WriteLine();
            }

            Console.WriteLine(order);
            
        }
    }
}
