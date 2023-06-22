using tz_mindbox;

try
{
    while (true)
    {
        Console.WriteLine("Выберите тип фигуры, для которой хотите расчитать площадь:");
        var classesNames = GetAllTypes();
        for (int i = 0; i < classesNames.Count; i++)
            Console.WriteLine($"{i} - {classesNames[i].Name}");
        var selectedClassIndex = Convert.ToInt32(Console.ReadLine());
        if (selectedClassIndex > classesNames.Count)
            throw new Exception("Такого класса не существует");

        var selectedClass = classesNames[selectedClassIndex];
        double[] arg = new double[] { };
        switch (selectedClass.Name)
        {
            case nameof(Circle):
                Console.Write("Введите радиус: ");
                var radius = Convert.ToDouble(Console.ReadLine());
                arg = new double[] { radius };
                break;
            case nameof(Triangle):
                Console.WriteLine("Введите три стороны: ");
                var a = Convert.ToDouble(Console.ReadLine());
                var b = Convert.ToDouble(Console.ReadLine());
                var c = Convert.ToDouble(Console.ReadLine());
                arg = new double[] { a, b, c };
                break;
            default:
                return;
        }
        Console.WriteLine($"Площадь выбранной фигуры с заданными параметрами: {SquareFinder.FindSquare(selectedClass, arg)}");
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.ReadLine();


static List<Type> GetAllTypes()
{
    var type = typeof(IFigure);
    return
        AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(item => type.IsAssignableFrom(item) && !item.IsInterface)
                .ToList();
}