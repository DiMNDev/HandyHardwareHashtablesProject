namespace HashtableAssignment.Library;
using System.Collections;

public class ProductsHashtable
{
    public Hashtable ProductHashtable { get; set; } = [];

    public void AddProduct(string product, int quantity)
    {
        ProductHashtable.Add(product, quantity);
    }
    public void DisplayProducts()
    {
        foreach (DictionaryEntry product in ProductHashtable)
        {
            Console.WriteLine($"Product: {product.Key} - Quantity: {product.Value}");
        }
    }
    public bool HasProduct(string productName)
    {
        return ProductHashtable.Contains(productName);
    }
}
