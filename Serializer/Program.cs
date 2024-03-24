using Serializer.SerializableTypes;
using Serializer.Services;
using Serializer.Types;
using System.Diagnostics;
using System.Text.Json;

string customSerializedString = new CustomSerializer().Serialize(new SerializableItem());
Console.WriteLine("[CustomSerializer] Результат сериализации: ");
Console.WriteLine(customSerializedString);
Console.WriteLine();

string systemJsonSerializedString = JsonSerializer.Serialize(new SerializableItem());
Console.WriteLine("[JsonSerializer] Результат сериализации: ");
Console.WriteLine(systemJsonSerializedString);
Console.WriteLine();

TimeSpan customSerializerResult = RunCustomSerializer(1000);
TimeSpan jsonSerializerResult = RunJsonSerializer(1000);
Console.WriteLine($"Разница customSerializerResult-jsonSerializerResult: {customSerializerResult - jsonSerializerResult}");
Console.WriteLine();

customSerializerResult = RunCustomSerializer(1000000);
jsonSerializerResult = RunJsonSerializer(1000000);
Console.WriteLine($"Разница customSerializerResult-jsonSerializerResult: {customSerializerResult - jsonSerializerResult}");
Console.WriteLine();

string json = File.ReadAllText("Files\\Test.json");
ICustomSerializer customSerializer = new CustomSerializer();

Stopwatch stopWatch = new();
stopWatch.Start();
var testObject1 = customSerializer.Deserialize(typeof(DeserializableItem), json);
stopWatch.Stop();
Console.WriteLine($"[CustomSerializer] Десериализация заняло {stopWatch.Elapsed}");
TimeSpan time1 = stopWatch.Elapsed;

stopWatch.Restart();
JsonSerializer.Deserialize<DeserializableItem>(json);
stopWatch.Stop();
Console.WriteLine($"[JsonSerializer] Десериализация заняло {stopWatch.Elapsed}");
TimeSpan time2 = stopWatch.Elapsed;
Console.WriteLine($"Разница customSerializerResult-jsonSerializerResult: {time1 - time2}");

Console.ReadKey();

static TimeSpan RunCustomSerializer(int itreations)
{
    List<SerializableItem> testObjects = [];
    for (int i = 0; i < itreations; i++)
    {
        testObjects.Add(new SerializableItem());
    }

    ICustomSerializer customSerializer = new CustomSerializer();
    var stopWatch = new Stopwatch();
    stopWatch.Start();
    foreach (SerializableItem testObject in testObjects)
    {
        string jsonResult = customSerializer.Serialize(testObject);
    }

    stopWatch.Stop();
    Console.WriteLine($"[CustomSerializer] Сериализация {itreations} объектов заняло {stopWatch.Elapsed}");

    return stopWatch.Elapsed;
}

static TimeSpan RunJsonSerializer(int itreations)
{
    List<SerializableItem> testObjects = [];
    for (int i = 0; i < itreations; i++)
    {
        testObjects.Add(new SerializableItem());
    }

    var stopWatch = new Stopwatch();
    stopWatch.Start();
    foreach (SerializableItem testObject in testObjects)
    {
        string jsonResult = JsonSerializer.Serialize(new SerializableItem());
    }

    stopWatch.Stop();
    Console.WriteLine($"[JsonSerializer] Сериализация {itreations} объектов заняло {stopWatch.Elapsed}");

    return stopWatch.Elapsed;
}
