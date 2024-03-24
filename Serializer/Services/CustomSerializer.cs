using Serializer.Extensions;
using System.Reflection;
using System.Text;
using System.Text.Json.Nodes;

namespace Serializer.Services;

public class CustomSerializer : ICustomSerializer
{
    public string Serialize(object serializableObject)
    {
        StringBuilder stringBuilder = new();
        stringBuilder.Append("{");

        Type objectType = serializableObject.GetType();
        PropertyInfo[] objectProperties = objectType.GetProperties();
        foreach (PropertyInfo objectProperty in objectProperties)
        {
            stringBuilder.Append($"\"{objectProperty.Name}\":{objectProperty.GetValue(serializableObject)?.ToString()},");
        }

        stringBuilder.Append("}");

        return stringBuilder.ToString();
    }

    public object Deserialize(Type targetType, string json)
    {
        JsonNode jsonNode = JsonNode.Parse(json) 
            ?? throw new Exception();

        ConstructorInfo constructor = targetType.GetConstructors().First();
        ParameterInfo constructorParameter = constructor.GetParameters().First();
        string constructorValue = jsonNode[constructorParameter.Name!.Capitalize()]!.ToString();

        return Activator.CreateInstance(targetType, constructorValue)!;
    }
}
