namespace Serializer.Services;

public interface ICustomSerializer
{
    string Serialize(object serializableObject);
}