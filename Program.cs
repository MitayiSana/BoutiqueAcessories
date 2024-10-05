using System;
namespace BoutiqueAcessories;


// Custom exception class for product out of stock
public class ProductOutOfStockException : Exception
{
    public ProductOutOfStockException(string message) : base(message) { }
}

//Adding out the properties to the Product........
public class Product
{
    public string Name { get; set; }
    public int Stock { get; set; }
}

public class DeliveryService
{
    //It is the custom exception we have created ..........
    public bool PlaceOrder(Product product)
    {
        if (product.Stock <= 0)
        {
            throw new ProductOutOfStockException("Product is out of stock");
        }
        return true;
    }
}

public class Program
{
    public static void Main()
    {
        DeliveryService deliveryService = new DeliveryService();
        Product product = new Product();

        Console.Write("Enter the product name: ");
        product.Name = Console.ReadLine();
        Console.Write("Enter the number of stocks: ");
        product.Stock = Convert.ToInt32(Console.ReadLine());

        try
        {
            if (deliveryService.PlaceOrder(product))
            {
                Console.WriteLine("Order placed successfully");
            }
        }
        catch (ProductOutOfStockException ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("Thank you !!!..Visit again...");
        }
    }
}