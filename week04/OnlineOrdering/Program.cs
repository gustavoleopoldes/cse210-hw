// I add the new class ShippingType to choose the type of order
class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Customer customer1 = new Customer("John Smith", address1);
        
        Order order1 = new Order(customer1, ShippingType.Express);
        order1.AddProduct(new Product("Laptop", "Accerz100", 999.99m, 1));
        order1.AddProduct(new Product("Mouse", "MB200", 29.99m, 2));

        Address address2 = new Address("456 Queen St", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Mary Johnson", address2);
        
        Order order2 = new Order(customer2, ShippingType.Economic);
        order2.AddProduct(new Product("Keyboard", "KABUM300", 89.99m, 1));
        order2.AddProduct(new Product("Monitor", "MN400", 299.99m, 2));
        order2.AddProduct(new Product("Headphones", "HP700", 49.99m, 1));

        Console.WriteLine("\n====== ORDER 1 ======");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine(order1.GetOrderSummary());
        
        Console.WriteLine("\n====== ORDER 2 ======");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine(order2.GetOrderSummary());
    }
}