using System;
using System.Reflection;


class Program
{
    public static void Main(string[] args)
    {
        Worker worker = new Worker();
        var workerType = worker.GetType();

        var fullNameProperty = workerType.GetProperty(nameof(Worker.FullName), typeof(string));
        var ageProperty = workerType.GetProperty(nameof(Worker.Age), typeof(int));
        if (fullNameProperty != null)
        {
            fullNameProperty.SetValue(worker, "Ivan Draganov");
            ageProperty.SetValue(worker, 55);
            Console.WriteLine(fullNameProperty.GetValue(worker));
        }

        var getCharacteristicsMethod = workerType.GetMethod(nameof(Worker.GetCharacteristics)); 
        if (getCharacteristicsMethod != null)
        {
            var result = getCharacteristicsMethod.Invoke(worker, new object[] { false });
            Console.WriteLine($"Method result: {result}");
        }
    }
}