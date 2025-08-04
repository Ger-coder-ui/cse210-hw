using System;

class Program
{
    static void Main(string[] args)
    {
         // Encapsulated Address class
    public class Address
    {
        private string street;
        private string city;
        private string stateOrProvince;
        private string country;

        public Address(string street, string city, string stateOrProvince, string country)
        {
            this.street = street;
            this.city = city;
            this.stateOrProvince = stateOrProvince;
            this.country = country;
        }

        public bool IsInUSA()
        {
            return country.Trim().ToLower() == "usa";
        }

        public string GetFullAddress()
        {
            return $"{street}\n{city}, {stateOrProvince}\n{country}";
        }
    }

    // Encapsulated Customer class
    public class Customer
    {
        private string name;
        private Address address;

        public Customer(string name, Address address)
        {
            this.name = name;
            this.address = address;
        }

        public string GetName()
        {
            return name;
        }

        public Address GetAddress()
        {
            return address;
        }

        public bool LivesInUSA()
        {
            return address.IsInUSA();
        }
    }

    // Encapsulated Product class
    public class Product
    {
        private string name;
        private string productId;
        private double price;
        private int quantity;

        public Product(string name, string productId, double price, int quantity)
        {
            this.name = name;
            this.productId = productId;
            this.price = price;
            this.quantity = quantity;
        }

        public double GetTotalCost()
        {
            return price * quantity;
        }

        public string GetPackingInfo()
        {
            return $"{name} (ID: {productId})";
        }
    }

    // Encapsulated Order class
    public class Order
    {
        private List<Product> products;
        private Customer customer;

        public Order(Customer customer)
        {
            this.customer = customer;
            products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public double GetTotalCost()
        {
            double total = 0;
            foreach (var product in products)
            {
                total += product.GetTotalCost();
            }
            total += customer.LivesInUSA() ? 5 : 35;
            return total;
        }

        public string GetPackingLabel()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Packing Label:");
            foreach (var product in products)
            {
                sb.AppendLine(product.GetPackingInfo());
            }
            return sb.ToString();
        }

        public string GetShippingLabel()
        {
            return $"Shipping Label:\n{customer.GetName()}\n{customer.GetAddress().GetFullAddress()}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create addresses
            Address usaAddress = new Address("123 Main St", "New York", "NY", "USA");
            Address canadaAddress = new Address("456 Maple Rd", "Toronto", "ON", "Canada");

            // Create customers
            Customer customer1 = new Customer("John Smith", usaAddress);
            Customer customer2 = new Customer("Anna Lee", canadaAddress);

            // Create products
            Product product1 = new Product("Wireless Mouse", "WM100", 25.99, 2);
            Product product2 = new Product("Keyboard", "KB200", 45.50, 1);
            Product product3 = new Product("USB-C Cable", "UC300", 10.00, 3);
            Product product4 = new Product("Monitor Stand", "MS400", 30.00, 1);

            // Create orders
            Order order1 = new Order(customer1);
            order1.AddProduct(product1);
            order1.AddProduct(product2);

            Order order2 = new Order(customer2);
            order2.AddProduct(product3);
            order2.AddProduct(product4);

            // Display order 1
            Console.WriteLine(order1.GetPackingLabel());
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order1.GetTotalCost():0.00}");
            Console.WriteLine(new string('-', 40));

            // Display order 2
            Console.WriteLine(order2.GetPackingLabel());
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order2.GetTotalCost():0.00}");
        }
    }
}
