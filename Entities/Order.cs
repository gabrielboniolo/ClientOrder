using Principal.Entities.Enums;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Principal.Entities {
    class Order {
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }

        public Order() {

        }

        public Order(DateTime moment, OrderStatus status, Client client) {
            Moment = moment;
            Status = status;
            Client = client;
        }


        public void AddItem(OrderItem item) {
            Items.Add(item);
        }
        public void RemoveItem(OrderItem item) {
            Items.Remove(item);
        }
        public double Total() {
            double total = 0.0;
            foreach(OrderItem item in Items) {
                total += item.Subtotal();
            }
            return total;
        }
        public override string ToString() {
            StringBuilder orderSummary = new StringBuilder();
            orderSummary.AppendLine("ORDER SUMMARY:");
            orderSummary.Append("Order Moment: ");
            orderSummary.AppendLine(Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            orderSummary.Append("Order Status: ");
            orderSummary.AppendLine(Status.ToString());
            orderSummary.Append("Client: ");
            orderSummary.Append(Client.Name);
            orderSummary.Append(" ");
            orderSummary.Append(Client.BirthDate.ToString("(dd/MM/yyyy)"));
            orderSummary.Append(" - ");
            orderSummary.AppendLine(Client.Email);
            orderSummary.AppendLine("Order items:");
            foreach(OrderItem item in Items) {
                orderSummary.AppendLine(item.ToString());
            }
            orderSummary.Append("Total price: ");
            orderSummary.AppendLine(Total().ToString("F2", CultureInfo.InvariantCulture));

            return orderSummary.ToString();
        }
    }
}