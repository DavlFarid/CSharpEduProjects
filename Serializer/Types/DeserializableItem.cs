namespace Serializer.Types;

public class DeserializableItem
{
    public string Id { get; }

    public DeserializableItem(string id)
    {
        Id = id;
    }

    public override string ToString() => $"My id is: {Id}";
}
