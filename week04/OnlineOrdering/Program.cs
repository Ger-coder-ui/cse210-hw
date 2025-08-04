using System;
using System.Collections.Generic;
using System.Text;

namespace ProductOrdering
{
    public class Address
    {
        private string _street;
        private string _city;
        private string _stateOrProvince;
        private string _country;

        public Address(string street, string city, string stateOrProvince, string country)
        {
            _street = street;
            _city = city;
            _stateOrProvince = stateOrProvince;
            _country = country;
        }

        public bool IsInUSA()
        {
            return _country.Trim().Equals("USA", StringComparison.OrdinalIgnoreCase);
        }

        public string GetFormattedAddress()
        {
            return $"{_street}\n{_city}, {_stateOrProvince}\n{_country}";
        }
    }

    public class Customer
    {
        private string _name;
        private Address _address;

        public Customer(string name, Address address)
        {
            _name = name;
            _address = address;
        }

        public string GetName() => _name;

        public Address GetAddress() => _address;

        public bool LivesInUSA() => _address.IsInUSA();
    }

    public class Product
    {
        private string _name;
        private string _id;
        private double _unitPrice;
        private int _quantity;

        public Product(string name, string id, double unitPrice, int quantity)
        {
            _name = name;
            _id = id;
            _unitPrice = unitPrice;
            _quantity = quantity;
        }

        public double GetTotalCost() => _unitPrice * _quantity;

        public string GetPackingInfo() => $"{_name} (ID: {_id})";
    }

    public class Order
    {
        private List<Product> _products = new List<Product>();
        private Customer _customer;

        public Order(Customer customer)
        {
            _customer = customer;
        }

        public void AddProduct(Product p) => _products.Add(p);

        public IReadOnlyList<Product> GetProducts() => _products.AsReadOnly();

        public double GetTotalPrice()
        {
            double total = 0;
            foreach (var p in _products)
                total += p.GetTotalCost();

            total += _customer.LivesInUSA() ? 5 : 35;
            return total;
        }

        public string GetPackingLabel()
        {
            var sb = new StringBuilder("Packing Label:\n");
            foreach (var p in _products)
                sb.AppendLine(p.GetPackingInfo());
            return sb.ToString();
        }

        public string GetShippingLabel()
        {
            return $"Shipping Label:\n{_customer.GetName()}\n{_customer.GetAddress().GetFormattedAddress()}";
        }
    }

    class Program
    {
        static void Main()
        {
            var addr1 = new Address("123 Main St", "New York", "NY", "USA");
            var addr2 = new Address("456 Maple Rd", "Toronto", "ON", "Canada");

            var cust1 = new Customer("John Smith", addr1);
            var cust2 = new Customer("Anna Lee", addr2);

            var prod1 = new Product("Wireless Mouse", "WM100", 25.99, 2);
            var prod2 = new Product("Keyboard", "KB200", 45.50, 1);
            var prod3 = new Product("USB‑C Cable", "UC300", 10.00, 3);
            var prod4 = new Product("Monitor Stand", "MS400", 30.00, 1);

            var o1 = new Order(cust1);
            o1.AddProduct(prod1);
            o1.AddProduct(prod2);

            var o2 = new Order(cust2);
            o2.AddProduct(prod3);
            o2.AddProduct(prod4);

            foreach (var (order, num) in new List<(Order, int)> { (o1,1), (o2,2) })
            {
                Console.WriteLine($"=== Order #{num} ===");
                Console.WriteLine(order.GetPackingLabel());
                Console.WriteLine(order.GetShippingLabel());
                Console.WriteLine($"Total Price: ${order.GetTotalPrice():F2}");
                Console.WriteLine();
            }
        }
    }
}

