using System.Reflection;
using System.Text;

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
}
