namespace Serializer.Services;

public interface ICustomSerializer
{
    object Deserialize(Type targetType, string json);
    string Serialize(object serializableObject);
}