class Human
{
    public string name = "";
    public int weight;
    public int age;
    public void print()
    {
        Console.WriteLine($"Имя человека: {name}");
        Console.WriteLine($"Возраст: {age}");
        Console.WriteLine($"Вес человека: {weight}");
        // var output = 
        // $@"Имя человека: {name}
        // Возраст: {age}
        // Вес человека: {weight}";
        // Console.WriteLine(output);
    }
}

class Point
{
    public int x = 0;
    public int y = 0;
};
// class Progarm
// {
//     static void Main(string[] args)
//     {
//         // Human firstHuman = new Human();
//         // firstHuman.name = "Misha";
//         // firstHuman.age = 21;
//         // firstHuman.weight = 65;
//         // firstHuman.print();
//     }
// }
