namespace HashtableAssignment.Library;
using System.Collections;

public class TableBuilder(string title)
{
    private string title { get; init; } = title;
    private int WindowWidth = Console.WindowWidth;
    private Hashtable Products { get; set; } = new();
    private int ProductColumnWidth { get; set; } = 0;
    private int QuantityColumnWidth { get; set; } = 0;

    public void BuildHeader()
    {
        BuildFullRow();
        int center = BuildFullRow().Top;
        BuildFullRow();
        DisplayTitle(center);
    }
    private Cursor BuildFullRow()
    {
        Console.Write("|");
        Console.Write(new string('=', WindowWidth - 2));
        Console.Write("|");
        return Console.GetCursorPosition();
    }
    public void DisplayTitle(int row)
    {
        Console.SetCursorPosition(WindowWidth / 2 - (title.Length / 2), row);
        Console.Write($" {title} ");
        Console.SetCursorPosition(0, row + 2);
    }

    public void DisplayTableHeader()
    {
        Console.WriteLine($"|{new string('-', WindowWidth / 2 - 6)}|");
        Console.SetCursorPosition(WindowWidth / 4 - 28, Console.GetCursorPosition().Top - 1);
        Console.Write($"| {"Product",-20} |{new string('-', WindowWidth / 4 - 24)}");
        Console.Write($"| {"Quantity"} |");
        Console.WriteLine();
        Console.Write($"|--|{new string('=', WindowWidth / 2 - 9),-20}|");
    }

    public void DisplayProduct(string product)
    {
        Console.WriteLine();
        Console.Write($"|--| {product,-20} |{new string('-', WindowWidth / 4 - 24)}| ");
        Console.Write($"{"",-4}{Products[product]:0000} |{new string('-', WindowWidth / 4 - 20)}|");
    }
    public void DisplayAllProducts()
    {
        if (Products.Count > 0)
        {
            DisplayTableHeader();
            foreach (DictionaryEntry product in Products)
            {
                DisplayProduct(product.Key.ToString()!);
            }
        }
    }

    public void AddProduct(string product, int quantity)
    {
        Products.Add(product, quantity);
        GetColumnWidths();
    }

    public void GetColumnWidths()
    {
        foreach (DictionaryEntry product in Products)
        {
            if (ProductColumnWidth < product.Key.ToString().Length) { ProductColumnWidth = product.Key.ToString().Length; }
            if (QuantityColumnWidth < product.Value.ToString().Length) { QuantityColumnWidth = product.Value.ToString().Length; }
        }
    }

}
internal record struct Cursor(int Left, int Top)
{
    public static implicit operator (int Left, int Top)(Cursor value)
    {
        return (value.Left, value.Top);
    }

    public static implicit operator Cursor((int Left, int Top) value)
    {
        return new Cursor(value.Left, value.Top);
    }
}