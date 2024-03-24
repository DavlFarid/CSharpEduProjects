using Serializer.SerializableTypes;
using Serializer.Services;
using System.Diagnostics;
using System.Text.Json;

string customSerializedString = new CustomSerializer().Serialize(new F());
Console.WriteLine("[CustomSerializer] Результат сериализации: ");
Console.WriteLine(customSerializedString);
Console.WriteLine();

string systemJsonSerializedString = JsonSerializer.Serialize(new F());
Console.WriteLine("[JsonSerializer] Результат сериализации: ");
Console.WriteLine(systemJsonSerializedString);
Console.WriteLine();

TimeSpan customSerializerResult = CustomSerializerRun(1000);
TimeSpan jsonSerializerResult = JsonSerializerRun(1000);
Console.WriteLine($"Разница: {customSerializerResult- jsonSerializerResult}");
Console.WriteLine();

customSerializerResult = CustomSerializerRun(1000000);
jsonSerializerResult = JsonSerializerRun(1000000);
Console.WriteLine($"Разница: {customSerializerResult - jsonSerializerResult}");
Console.WriteLine();

Console.ReadKey();

static TimeSpan CustomSerializerRun(int itreations)
{
    List<F> testObjects = [];
    for (int i = 0; i < itreations; i++)
    {
        testObjects.Add(new F());
    }

    var stopWatch = new Stopwatch();
    stopWatch.Start();
    foreach (F testObject in testObjects)
    {
        string jsonResult = new CustomSerializer().Serialize(testObject);
    }

    stopWatch.Stop();
    Console.WriteLine($"[CustomSerializer] Сериализация {itreations} объектов заняло {stopWatch.Elapsed}");

    return stopWatch.Elapsed;
}

static TimeSpan JsonSerializerRun(int itreations)
{
    List<F> testObjects = [];
    for (int i = 0; i < itreations; i++)
    {
        testObjects.Add(new F());
    }

    var stopWatch = new Stopwatch();
    stopWatch.Start();
    foreach (F testObject in testObjects)
    {
        string jsonResult = JsonSerializer.Serialize(new F());
    }

    stopWatch.Stop();
    Console.WriteLine($"[JsonSerializer] Сериализация {itreations} объектов заняло {stopWatch.Elapsed}");

    return stopWatch.Elapsed;
}
