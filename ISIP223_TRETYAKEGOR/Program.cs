using System;
using System.Collections.Generic;

enum Category
{
    Food = 0,
    Electronics = 1,
    Clothes = 2
}

class Product
{
    public int Code;
    public string Name;
    public decimal Price;
    public int Quantity;
    public Category Category;

    public Product(int code, string name, decimal price, int quantity, Category category)
    {
        Code = code;
        Name = name;
        Price = price;
        Quantity = quantity;
        Category = category;
    }

    public void Print()
    {
        Console.WriteLine("Код: " + Code);
        Console.WriteLine("Название: " + Name);
        Console.WriteLine("Цена: " + Price);
        Console.WriteLine("Количество: " + Quantity);
        Console.WriteLine("В наличии: " + (Quantity > 0 ? "Да" : "Нет"));
        Console.WriteLine("Категория: " + Category);
        Console.WriteLine("------------------");
    }
}

class Program
{
    static List<Product> products = new List<Product>();
    static int nextCode = 1001;

    static void Main()
    {
       

        bool work = true;
        while (work)
        {
            Console.WriteLine("=== Меню ===");
            Console.WriteLine("1. Добавить товар");
            Console.WriteLine("2. Удалить товар");
            Console.WriteLine("3. Заказать поставку");
            Console.WriteLine("4. Продать товар");
            Console.WriteLine("5. Поиск товара");
            Console.WriteLine("6. Показать все товары");
            Console.WriteLine("0. Выход");

            string choice = Console.ReadLine();
            if (choice == "1") AddProduct();
            else if (choice == "2") DeleteProduct();
            else if (choice == "3") OrderProduct();
            else if (choice == "4") SellProduct();
            else if (choice == "5") SearchProduct();
            else if (choice == "6") ShowAll();
            else if (choice == "0") work = false;
            else Console.WriteLine("Неверный ввод!");
        }
    }

    static void AddProduct()
    {
        Console.Write("Название: ");
        string name = Console.ReadLine();
        if (name == "") { Console.WriteLine("Ошибка!"); return; }

        Console.Write("Цена: ");
        decimal price;
        if (!decimal.TryParse(Console.ReadLine(), out price) || price <= 0) 
        { Console.WriteLine("Ошибка!"); return; }

        Console.Write("Количество: ");
        int qty;
        if (!int.TryParse(Console.ReadLine(), out qty) || qty < 0) 
        { Console.WriteLine("Ошибка!"); return; }

        Console.WriteLine("Категория (0 - Food, 1 - Electronics, 2 - Clothes): ");
        int catNum;
        if (!int.TryParse(Console.ReadLine(), out catNum) || catNum < 0 || catNum > 2) 
        { Console.WriteLine("Ошибка!"); return; }

        products.Add(new Product(nextCode++, name, price, qty, (Category)catNum));
        Console.WriteLine("Товар добавлен!");
    }

    static void DeleteProduct()
    {
        Console.Write("Введите код: ");
        int code;
        if (int.TryParse(Console.ReadLine(), out code))
        {
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Code == code)
                {
                    products.RemoveAt(i);
                    Console.WriteLine("Товар удалён!");
                    return;
                }
            }
            Console.WriteLine("Не найден!");
        }
    }

    static void OrderProduct()
    {
        Console.Write("Введите код: ");
        int code;
        if (int.TryParse(Console.ReadLine(), out code))
        {
            foreach (var p in products)
            {
                if (p.Code == code)
                {
                    Console.Write("Введите количество: ");
                    int qty;
                    if (int.TryParse(Console.ReadLine(), out qty) && qty > 0)
                    {
                        p.Quantity += qty;
                        Console.WriteLine("Поставка добавлена!");
                        return;
                    }
                }
            }
            Console.WriteLine("Не найден!");
        }
    }

    static void SellProduct()
    {
        Console.Write("Введите код: ");
        int code;
        if (int.TryParse(Console.ReadLine(), out code))
        {
            foreach (var p in products)
            {
                if (p.Code == code)
                {
                    Console.Write("Введите количество: ");
                    int qty;
                    if (int.TryParse(Console.ReadLine(), out qty) && qty > 0)
                    {
                        if (p.Quantity >= qty)
                        {
                            p.Quantity -= qty;
                            Console.WriteLine("Товар продан!");
                        }
                        else Console.WriteLine("Нет столько товара!");
                        return;
                    }
                }
            }
            Console.WriteLine("Не найден!");
        }
    }

    static void SearchProduct()
    {
        Console.WriteLine("Поиск: 1 - код, 2 - название, 3 - категория");
        string ch = Console.ReadLine();
        if (ch == "1")
        {
            Console.Write("Введите код: ");
            int code;
            if (int.TryParse(Console.ReadLine(), out code))
            {
                foreach (var p in products)
                    if (p.Code == code) p.Print();
            }
        }
        else if (ch == "2")
        {
            Console.Write("Введите название: ");
            string name = Console.ReadLine();
            foreach (var p in products)
                if (p.Name.ToLower().Contains(name.ToLower())) p.Print();
        }
        else if (ch == "3")
        {
            Console.WriteLine("Введите категорию (0 - Food, 1 - Electronics, 2 - Clothes): ");
            int cat;
            if (int.TryParse(Console.ReadLine(), out cat) && cat >= 0 && cat <= 2)
            {
                foreach (var p in products)
                    if (p.Category == (Category)cat) p.Print();
            }
        }
    }

    static void ShowAll()
    {
        foreach (var p in products) p.Print();
    }
}
