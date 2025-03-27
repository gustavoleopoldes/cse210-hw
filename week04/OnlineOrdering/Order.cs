public class Order
{
    private List<Product> _products;
    private Customer _customer;
    private ShippingType _shippingType;

    public Order(Customer customer, ShippingType shippingType = ShippingType.Standard)
    {
        _customer = customer;
        _products = new List<Product>();
        _shippingType = shippingType;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    private decimal GetShippingCost()
    {
        decimal baseCost = _customer.IsInUSA() ? 5m : 35m;

        switch (_shippingType)
        {
            case ShippingType.Economic:
                return baseCost * 0.8m; 
            case ShippingType.Express:
                return baseCost * 1.5m; 
            default: 
                return baseCost;
        }
    }

    public decimal CalculateTotalCost()
    {
        decimal totalCost = 0;
        foreach (Product product in _products)
        {
            totalCost += product.GetTotalCost();
        }

        return totalCost + GetShippingCost();
    }

    public string GetPackingLabel()
    {
        string label = "=== PACKING LABEL ===\n";
        foreach (Product product in _products)
        {
            label += product.GetPackingLabel() + "\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        string label = "=== SHIPPING LABEL ===\n";
        label += $"Shipping Method: {_shippingType}\n";
        label += $"Customer: {_customer.GetName()}\n";
        label += _customer.GetAddress().GetFullAddress();
        return label;
    }

    public string GetOrderSummary()
    {
        decimal shippingCost = GetShippingCost();
        decimal productsTotal = CalculateTotalCost() - shippingCost;

        string summary = "\n=== ORDER SUMMARY ===\n";
        summary += $"Products Total: ${productsTotal:F2}\n";
        summary += $"Shipping Type: {_shippingType}\n";
        summary += $"Shipping Cost: ${shippingCost:F2}\n";
        summary += $"Total Cost: ${CalculateTotalCost():F2}\n";
        return summary;
    }
}