Console.Write("введите количество операций за день(от 2 до 40): ");
int numOper = int.Parse(Console.ReadLine());
int[] price = { };
string[] nameOb = new string[numOper];
if (numOper < 2 || numOper > 40)
{
    Console.WriteLine("количество операций превышает допустимую норму, или не добирает до нормы!");
}
else
{
    Console.WriteLine("Введите траты по шаблону: Название услуги или товара;Количество денег ");
    for (int i = 0; i < numOper; i++)
    {
        Console.WriteLine($"Операция номер: {i} ");
        nameOb[i] = Console.ReadLine();

    }
}
Console.WriteLine("Меню:");
Console.WriteLine("1. Вывод данных");
Console.WriteLine("2. Статистика(среднее, максимальное, минимальное	, сумма");
Console.WriteLine("3. Сортировка по цене");
Console.WriteLine("4. Конвертация валюты");
Console.WriteLine("5. Поиск по названию");
Console.WriteLine("0. Выход");
int menuNumber = int.Parse(Console.ReadLine());
switch (menuNumber)
{
    case 1:
        for (int i = 0; i < nameOb.Length; i++)
        {
            Console.WriteLine(nameOb[i]);
        }
        break;
    case 2:
        for (int i = 0; i < nameOb.Length; i++)
        {
        }
        break;
    default:
        break;
}


