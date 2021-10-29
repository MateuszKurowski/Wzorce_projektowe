using System;
using System.Collections.Generic;
using System.Text;

public abstract class ProductPrototype
{
    public double Price;

    public ProductPrototype(double price)
    {
        Price = price;
    }

    public ProductPrototype Clone()
    {
        return (ProductPrototype)this.MemberwiseClone();
    }
}

public class Bread : ProductPrototype
{
    public Bread(double price) : base(price) { }
}

public class Butter : ProductPrototype
{
    public Butter(double price) : base(price) { }
}

public class Supermarket
{
    private Dictionary<string, ProductPrototype> _productList = new Dictionary<string, ProductPrototype>();

    public void AddProduct(string key, ProductPrototype productPrototype)
    {
        _productList.Add(key, productPrototype);
    }

    public ProductPrototype GetClonedProduct(string key)
    {
        ProductPrototype product = _productList[key];
        ProductPrototype clonedPrototype = product.Clone();

        return clonedPrototype;
    }
}

class MainClass
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Supermarket supermarket = new Supermarket();

        supermarket.AddProduct("Bread", new Bread(9.50));
        supermarket.AddProduct("Butter", new Butter(5.30));

        ProductPrototype product1 = supermarket.GetClonedProduct("Bread");
        Console.WriteLine($"Bread - {Math.Round(product1.Price, 2).ToString("N2")} zł > {Math.Round((product1.Price * 0.9), 2).ToString("N2")} zł");
        Console.WriteLine();

        ProductPrototype product = supermarket.GetClonedProduct("Bread");
        Console.WriteLine($"Bread - {Math.Round(product.Price, 2).ToString("N2")} zł");
        Console.WriteLine();

        ProductPrototype productButter = supermarket.GetClonedProduct("Butter");
        Console.WriteLine($"Butter - {Math.Round(productButter.Price, 2).ToString("N2")} zł");
        Console.WriteLine();
    }
}