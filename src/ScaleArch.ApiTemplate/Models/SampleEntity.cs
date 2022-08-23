using Toolbelt.Abstractions.Entities;
using Toolbelt.Mongo.Models;

namespace ScaleArch.ApiTemplate.Models;

public class SampleEntity : MongoEntity
{
    public SampleEntity(string name) : base()
    {
        Name = name;
    }
    public string Name { get; set; }

    public override string GetPartitionKey()
    {
        return "sample";
    }
}
