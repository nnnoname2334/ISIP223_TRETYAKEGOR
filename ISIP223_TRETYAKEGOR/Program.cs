void google(double[] intk, string[] str, string what)
{
    int i = Array.IndexOf(str, what);
    Console.WriteLine(str[i], intk[i]);
}

void converter(ref double[] inty, ref string val, double mod)
{
    val = "unknown";
    for (int i = 0; i < inty.Length; i++)
    {
        inty[i] = inty[i] * mod;
    }
}
void output(string[] str, double[] intik)
{
    for (int i = 0; i < str.Length; i++)
    {
        Console.WriteLine(str[i] + "; " + intik[i]);
    }
}

void statistik(double[] intik)
{
    Console.WriteLine("Минимальное  " + intik.Min());
    Console.WriteLine("Максимальное  " + intik.Max());
    Console.WriteLine("Среднее  " + intik.Max() / intik.Length);
    Console.WriteLine("Сумма  " + intik.Sum());
}
void sort(ref string[] str, ref double[] intik)
{
    double op_n;
    string op_str;
    for (int i = 0; i < intik.Length; i++)
    {
        for (int sort = 0; sort < intik.Length - 1; sort++)
        {
            if (intik[sort] > intik[sort + 1])
            {
                op_n = intik[sort + 1];
                intik[sort + 1] = intik[sort];
                intik[sort] = op_n;
                op_str = str[sort + 1];
                str[sort + 1] = str[sort];
                str[sort] = op_str;
            }
        }
    }

}
Console.Write("Количество операций: ");
int kol = int.Parse(Console.ReadLine());
string[] lst_name = new string[kol];
double[] lst_num = new double[kol];
bool flag = true;
string val = "rub";
double mod;
if (kol >= 2 && kol <= 40)
{
    for (int i = 0; i < kol; i++)
    {
        Console.Write($"Номер операции: {i} "); 
        string s = Console.ReadLine();
        string[] s_2 = s.Split("; ");
        lst_name[i] = s_2[0];
        lst_num[i] = double.Parse(s_2[1]);
    }

    while (flag)
    {
        Console.WriteLine("1. Вывод данных");
        Console.WriteLine("2. Статистика (среднее, максимальное, минимальное, сумма)");
        Console.WriteLine("3. Сортировка по цене");
        Console.WriteLine("4. Конвертация валюты");
        Console.WriteLine("5. Поиск по названию");
        Console.WriteLine("0. Выход");
        int operation = int.Parse(Console.ReadLine());
        switch (operation)
        {
            case 1:
                output(lst_name, lst_num);
                break;
            case 2:
                statistik(lst_num);
                break;
            case 3:
                sort(ref lst_name, ref lst_num);
                output(lst_name, lst_num);
                break;
            case 4:
                if (val == "rub")
                {
                    Console.WriteLine("1 Китайский Доллар, 2 Беларусский Евро, 3 другое");
                    mod = double.Parse(Console.ReadLine());
                    switch (mod)
                    {
                        case 1:
                            converter(ref lst_num, ref val, 20);
                            break;
                        case 2:
                            converter(ref lst_num, ref val, 2);
                            break;
                        default:
                            Console.WriteLine("Введите модификатор");
                            mod = double.Parse(Console.ReadLine());
                            converter(ref lst_num, ref val, mod);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Введите модификатор");
                    mod = double.Parse(Console.ReadLine());
                    converter(ref lst_num, ref val, mod);
                }
                output(lst_name, lst_num);
                break;

            case 5:
                string s = Console.ReadLine();
                google(lst_num, lst_name, s);
                break;
            default:
                flag = false;
                break;
        }
    }
}